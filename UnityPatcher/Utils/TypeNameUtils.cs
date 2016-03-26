using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityPatcher.Utils
{
	public static class TypeNameUtils
	{

		public class AlphabeticalTypeComparer : IComparer<TypeDefinition>
		{
			public int Compare(TypeDefinition x, TypeDefinition y)
			{
				return x.Name.CompareTo(y.Name);
			}
		}

		public static string TransformTypeName(string oldName)
		{
			const string prefix = "System.";
			if (oldName.Length >= prefix.Length && oldName.Substring(0, prefix.Length) == prefix)
			{
				string smallertype = oldName.Substring(prefix.Length);
				string newtype = TransformTypeName(smallertype);
				if (newtype == smallertype)
				{
					return oldName;
				}
				else
				{
					return newtype;
				}
			}
			switch (oldName)
			{
				case "String":
				case "Object":
				case "Double":
				case "Void":
				case "Byte":
					return oldName.ToLower();
				case "Integer":
					return "int";
				case "Boolean":
					return "bool";
				case "UInt16":
					return "ushort";
				case "UInt32":
					return "uint";
				case "UInt64":
					return "ulong";
				case "Int16":
					return "short";
				case "Int32":
					return "int";
				case "Int64":
					return "long";
				case "Single":
					return "float";
				default:
					return oldName;
			}
		}

		public static string GetTypeNameWithGenerics(TypeDefinition typeDefinition)
		{
			// Check if the type contains generics
			if (typeDefinition.HasGenericParameters)
			{
				// Build a string using the type name and the generic parameter names
				string[] splitTypeName = typeDefinition.Name.Split('`');
				string parametersString = "";
				foreach (GenericParameter param in typeDefinition.GenericParameters)
				{
					string separator = parametersString.Length > 0 ? ", " : "";
					parametersString = $"{parametersString}{separator}{param.Name}";
				}
				return $"{splitTypeName[0]}<{parametersString}>";
			}
			else
			{
				// No generics, return the type name
				return typeDefinition.Name;
			}
		}

		public static string GetTypeDeclarationString(TypeDefinition typeDefinition)
		{
			try
			{
				// Build declaration information
				string typeStr = "";
				string defineStr = "";
				string typeNameStr = GetTypeNameWithGenerics(typeDefinition);
				string baseTypeStr = typeDefinition.BaseType != null && typeDefinition.BaseType.Name != "Object" ? $" : {GetTypeNameWithGenerics(typeDefinition?.BaseType.Resolve())}" : "";

				if (typeDefinition.IsClass)
				{
					typeStr = "class ";
					defineStr = typeDefinition.IsPublic ? $"{defineStr}public " : $"{defineStr}private ";
					defineStr = typeDefinition.IsAbstract ? $"{defineStr}abstract " : $"{defineStr}";
					defineStr = typeDefinition.IsSealed ? $"{defineStr}sealed " : $"{defineStr}";
				}
				if (typeDefinition.IsInterface)
				{
					typeStr = "interface ";
					defineStr = typeDefinition.IsPublic ? $"{defineStr}public " : $"{defineStr}private ";
					defineStr = typeDefinition.IsSealed ? $"{defineStr}sealed " : $"{defineStr}";
				}

				// Check for generics
				string genericsStr = "";
				if (typeDefinition.HasGenericParameters)
				{
					bool addedGenericParameters = false;
					foreach (GenericParameter param in typeDefinition.GenericParameters)
					{
						string parameterName = param.Name;

						// Check if parameter is a property defined parameter, or if it has a set type
						bool foundAsProperty = false;
						foreach (PropertyDefinition property in typeDefinition.Properties)
						{
							// Check if parameter is a property defined parameter
							if ((property?.PropertyType?.Name.Equals(param.Name)).GetValueOrDefault(false))
							{
								foundAsProperty = true;
								break;
							}

							// Check if parameter has its type defined by a property
							Console.WriteLine($"{parameterName} = {property.Name}");
						}

						if (foundAsProperty && !param.HasConstraints)
						{
							continue;
						}

						// Otherwise add it to the declaration
						string separator = genericsStr.Length == 0 ? "" : ", ";
						string paramString = "";
						if (param.HasConstraints)
						{
							paramString = $"{parameterName} : ";
							foreach (var constraint in param.Constraints)
							{
								paramString = $"{paramString}{constraint.Name}";
							}
						}
						else
						{
							paramString = $"{parameterName} : new()";
						}
						genericsStr = $"{genericsStr}{separator}{paramString}";
						addedGenericParameters = true;
					}
					if (addedGenericParameters)
					{
						genericsStr = $" where {genericsStr}";
					}
				}

				// Return the full declaration string
				return $"{defineStr}{typeStr}{typeNameStr}{baseTypeStr}{genericsStr}";
			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				return "Error: exception";
			}
		}

		public static string GetFieldDefinitionScope(this FieldDefinition def)
		{
			if (def.IsPublic)
				return "public";
			else if (def.IsPrivate)
				return "private";
			else if (def.IsFamilyAndAssembly)
				return "protected";
			else
				return "internal";
		}

		public static string GetFieldDefintionQualifier(this FieldDefinition def)
		{
			if (def.IsStatic)
				return $"{GetFieldDefinitionScope(def)} static";
			else
				return $"{GetFieldDefinitionScope(def)}";
		}

		public static string GetFieldDefintionFullName(this FieldDefinition def)
		{
			return $"{def.GetFieldDefintionQualifier()} {TransformTypeName(def.FieldType.Name)} {def.Name}";
		}

		public static string GetMethodDefintionScope(this MethodDefinition def)
		{
			if (def.IsPublic)
				return "public";
			else if (def.IsPrivate)
				return "private";
			else if (def.IsFamilyAndAssembly)
				return "protected";
			else
				return "internal";
		}

		public static string GetMethodDefintionQualifier(this MethodDefinition def)
		{
			if (def.IsStatic)
				return $"{def.GetMethodDefintionScope()} static";
			else if (def.IsAbstract)
				return $"{def.GetMethodDefintionScope()} abstract";
			else if (def.IsVirtual)
				return $"{def.GetMethodDefintionScope()} virtual";
			else
				return $"{def.GetMethodDefintionScope()}";
		}

		public static string GetMethodDefinitionParameters(this MethodDefinition def)
		{
			if (def.HasParameters)
			{
				string parameterString = string.Empty;
				foreach (var parameter in def.Parameters)
				{
					if (parameterString != string.Empty)
						parameterString = $"{parameterString}, ";
					parameterString = $"{parameterString}{TransformTypeName(parameter.ParameterType.FullName)}";
				}
				return parameterString;
			}
			return string.Empty;
		}

		public static string GetMethodDefintionFullName(this MethodDefinition def)
		{
			if (def.IsConstructor)
				return $"{def.GetMethodDefintionQualifier()} {def.DeclaringType.FullName}({def.GetMethodDefinitionParameters()})";
			else
				return $"{def.GetMethodDefintionQualifier()} {TransformTypeName(def.ReturnType.Name)} {def.Name}({def.GetMethodDefinitionParameters()})";
		}

	}
}
