using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityExtensionPatcher.Utils
{
	public static class TypeNameUtils
	{
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
				string accessibilityStr = typeDefinition.IsPublic ? "public " : "private ";
				string sealedStr = typeDefinition.IsSealed ? "sealed " : "";
				string typeStr = "";
				string typeNameStr = GetTypeNameWithGenerics(typeDefinition);
				string baseTypeStr = typeDefinition.BaseType.Name != "Object" ? $" : {typeDefinition.BaseType.Name}" : "";

				if (typeDefinition.IsClass)
				{
					typeStr = "class ";
				}

				// Check for generics
				string genericsStr = "";
				if (typeDefinition.HasGenericParameters)
				{
					foreach (GenericParameter param in typeDefinition.GenericParameters)
					{
						string separator = genericsStr.Length == 0 ? "" : ", ";
						string paramString = "";
						if (param.HasConstraints)
						{
							paramString = $"{param.Name} : ";
							foreach (var constraint in param.Constraints)
							{
								paramString = $"{paramString}{constraint.Name}";
							}
						}
						else
						{
							paramString = $"{param.Name} : new()";
						}
						genericsStr = $"{genericsStr}{separator}{paramString}";
					}
					genericsStr = $" where {genericsStr}";
				}

				// Return the full declaration string
				return $"{accessibilityStr}{sealedStr}{typeStr}{typeNameStr}{baseTypeStr}{genericsStr}";
			}
			catch(Exception exception)
			{
				return "Error: exception";
			}
		}
    }
}
