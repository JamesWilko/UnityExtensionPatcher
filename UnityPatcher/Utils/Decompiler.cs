using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace UnityPatcher.Utils
{
	public static class Decompiler
	{

		public static string ToIL(MethodDefinition methodDefinition)
		{
			StringBuilder builder = new StringBuilder();
			if (methodDefinition.HasBody)
			{
				foreach (var instruction in methodDefinition.Body.Instructions)
				{
					builder.AppendLine(instruction.ToString());
				}
			}
			return builder.ToString();
		}

		public static string ToSource(MethodDefinition methodDefinition)
		{
			var settings = new DecompilerSettings { UsingDeclarations = false };
			var context = new DecompilerContext(methodDefinition.Module)
			{
				CurrentType = methodDefinition.DeclaringType,
				Settings = settings,
			};
			var astBuilder = new AstBuilder(context);
            astBuilder.AddMethod(methodDefinition);
			var textOutput = new PlainTextOutput();
			astBuilder.GenerateCode(textOutput);
			return textOutput.ToString();
		}

	}
}
