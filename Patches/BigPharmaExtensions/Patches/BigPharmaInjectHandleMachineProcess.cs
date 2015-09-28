using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions.Patches
{
	class BigPharmaInjectHandleMachineProcess : LineAdditionPatch
	{
		public override string InsertionPoint { get { return "IL_01dc:  callvirt   instance class EquipmentSpec/Processor EquipmentSpec::get_processor()"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.Before; } }
		public override int InsertionPointOffset { get { return 1; } }
		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
"IL_P_0000: nop",
"IL_P_0001: ldc.i4 32",
"IL_P_0002: stloc 32",
"IL_P_0003: call !0 class ['Assembly-CSharp']SingletonPrefab`1<class ['Assembly-CSharp']Backbone>::get_instance()",
"IL_P_0008: ldfld object ['Assembly-CSharp']Backbone::extensionManagerObject",
"IL_P_000d: ldnull",
"IL_P_000e: ceq",
"IL_P_0010: stloc 35",
"IL_P_0011: ldloc 35",
"IL_P_0012: brtrue IL_P_008b",
"",
"IL_P_0014: nop",
"IL_P_0015: nop",
"IL_P_0016: call !0 class ['Assembly-CSharp']SingletonPrefab`1<class ['Assembly-CSharp']Backbone>::get_instance()",
"IL_P_001b: ldfld class [mscorlib]System.Type[] ['Assembly-CSharp']Backbone::extensionManagerTypes",
"IL_P_0020: stloc.s 36",
"IL_P_0022: ldc.i4.0",
"IL_P_0023: stloc.s 37",
"IL_P_0025: br IL_P_007f",
"// loop start (head: IL_P_007f)",
"	IL_P_0027: ldloc.s 36",
"	IL_P_0029: ldloc.s 37",
"	IL_P_002b: ldelem.ref",
"	IL_P_002c: stloc 33",
"	IL_P_002d: nop",
"	IL_P_002e: ldloc 33",
"	IL_P_002f: callvirt instance string [mscorlib]System.Type::get_FullName()",
"	IL_P_0034: ldstr \"BigPharmaExtensionAPI.ExtensionManager\"",
"	IL_P_0039: callvirt instance bool [mscorlib]System.String::Equals(string)",
"	IL_P_003e: ldc.i4.0",
"	IL_P_003f: ceq",
"	IL_P_0041: stloc 35",
"	IL_P_0042: ldloc 35",
"	IL_P_0043: brtrue IL_P_0078",
"",
"	IL_P_0045: nop",
"	IL_P_0046: ldloc 33",
"	IL_P_0047: ldstr \"MachineDoProduction\"",
"	IL_P_004c: callvirt instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string)",
"	IL_P_0051: stloc 34",
"	IL_P_0052: ldloc 34",
"	IL_P_0053: call !0 class ['Assembly-CSharp']SingletonPrefab`1<class ['Assembly-CSharp']Backbone>::get_instance()",
"	IL_P_0058: ldfld object ['Assembly-CSharp']Backbone::extensionManagerObject",
"	IL_P_005d: ldc.i4.1",
"	IL_P_005e: newarr [mscorlib]System.Object",
"	IL_P_0063: stloc.s 38",
"	IL_P_0065: ldloc.s 38",
"	IL_P_0067: ldc.i4.0",
"	IL_P_0068: ldarg.0",
"	IL_P_0069: stelem.ref",
"	IL_P_006a: ldloc.s 38",
"	IL_P_006c: callvirt instance object [mscorlib]System.Reflection.MethodBase::Invoke(object, object[])",
"	IL_P_0071: unbox.any [mscorlib]System.Boolean",
"	IL_P_0076: stloc.s 32",
"	IL_P_0077: nop",
"",
"	IL_P_0078: nop",
"	IL_P_0079: ldloc.s 37",
"	IL_P_007b: ldc.i4.1",
"	IL_P_007c: add",
"	IL_P_007d: stloc.s 37",
"",
"	IL_P_007f: ldloc.s 37",
"	IL_P_0081: ldloc.s 36",
"	IL_P_0083: ldlen",
"	IL_P_0084: conv.i4",
"	IL_P_0085: clt",
"	IL_P_0087: stloc 35",
"	IL_P_0088: ldloc 35",
"	IL_P_0089: brtrue IL_P_0027",
"// end loop",
"",
"IL_P_008b: nop",
"",
				};
			}
		}
	}
}
