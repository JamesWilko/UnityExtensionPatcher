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

		public static string ToIL(MethodBody methodBody)
		{
			StringBuilder builder = new StringBuilder();
			if (methodBody != null)
			{
				foreach (var instruction in methodBody.Instructions)
				{
					builder.AppendLine(instruction.ToString());
				}
			}
			return builder.ToString();
		}

	}
}
