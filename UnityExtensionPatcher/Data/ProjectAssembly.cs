using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensionPatcher.Data
{
	public struct ProjectAssembly
	{
		public string Path;
		public bool Load;

		public override string ToString()
		{
			return $"ProjectAssembly [Path: {Path}][Load: {Load}]";
        }
	}
}
