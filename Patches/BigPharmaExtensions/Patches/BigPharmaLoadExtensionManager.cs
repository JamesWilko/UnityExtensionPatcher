using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions
{
	class BigPharmaLoadExtensionManager : LineAdditionPatch
	{
		public override string InsertionPoint { get { return "// end of method Backbone::Awake"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.After; } }
		public override int InsertionPointOffset { get { return 0; } }
		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
".method public hidebysig ",
"	instance void LoadAssembly () cil managed ",
"{",
"	// Method begins at RVA 0x208c",
"	// Code size 205 (0xcd)",
"	.maxstack 4",
"	.locals init (",
"		[0] string modsFolder,",
"		[1] string assemblyFilePath,",
"		[2] string filePath,",
"		[3] class [mscorlib]System.Reflection.Assembly extensionManagerAsm,",
"		[4] class [mscorlib]System.Type[] types,",
"		[5] class [mscorlib]System.Type t,",
"		[6] class [mscorlib]System.Reflection.MethodInfo initializeMethod,",
"		[7] bool CS$4$0000,",
"		[8] class [mscorlib]System.Type[] CS$6$0001,",
"		[9] int32 CS$7$0002",
"	)",
"",
"	IL_0000: nop",
"	IL_0001: ldstr \"Mods\"",
"	IL_0006: stloc.0",
"	IL_0007: ldstr \"BigPharmaExtensionAPI.dll\"",
"	IL_000c: stloc.1",
"	IL_000d: ldstr \"{0}/{1}/{2}\"",
"	IL_0012: call string ['Assembly-CSharp']Backbone::get_USER_DATA_PATH()",
"	IL_0017: ldloc.0",
"	IL_0018: ldloc.1",
"	IL_0019: call string [mscorlib]System.String::Format(string, object, object, object)",
"	IL_001e: stloc.2",
"	IL_001f: ldloc.2",
"	IL_0020: call bool [mscorlib]System.IO.File::Exists(string)",
"	IL_0025: ldc.i4.0",
"	IL_0026: ceq",
"	IL_0028: stloc.s CS$4$0000",
"	IL_002a: ldloc.s CS$4$0000",
"	IL_002c: brtrue IL_00cc",
"",
"	IL_0031: nop",
"	IL_0032: ldloc.2",
"	IL_0033: call class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::LoadFrom(string)",
"	IL_0038: stloc.3",
"	IL_0039: ldloc.3",
"	IL_003a: callvirt instance class [mscorlib]System.Type[] [mscorlib]System.Reflection.Assembly::GetTypes()",
"	IL_003f: stloc.s types",
"	IL_0041: nop",
"	IL_0042: ldloc.s types",
"	IL_0044: stloc.s CS$6$0001",
"	IL_0046: ldc.i4.0",
"	IL_0047: stloc.s CS$7$0002",
"	IL_0049: br.s IL_00bd",
"	// loop start (head: IL_00bd)",
"		IL_004b: ldloc.s CS$6$0001",
"		IL_004d: ldloc.s CS$7$0002",
"		IL_004f: ldelem.ref",
"		IL_0050: stloc.s t",
"		IL_0052: nop",
"		IL_0053: ldstr \"t: \"",
"		IL_0058: ldloc.s t",
"		IL_005a: callvirt instance string [mscorlib]System.Type::get_FullName()",
"		IL_005f: call string [mscorlib]System.String::Concat(string, string)",
"		IL_0064: call void [UnityEngine]UnityEngine.Debug::Log(object)",
"		IL_0069: nop",
"		IL_006a: ldloc.s t",
"		IL_006c: callvirt instance string [mscorlib]System.Type::get_FullName()",
"		IL_0071: ldstr \"BigPharmaExtensionAPI.ExtensionManager\"",
"		IL_0076: callvirt instance bool [mscorlib]System.String::Equals(string)",
"		IL_007b: ldc.i4.0",
"		IL_007c: ceq",
"		IL_007e: stloc.s CS$4$0000",
"		IL_0080: ldloc.s CS$4$0000",
"		IL_0082: brtrue.s IL_00b6",
"",
"		IL_0084: nop",
"		IL_0085: ldarg.0",
"		IL_0086: ldloc.s t",
"		IL_0088: ldc.i4.1",
"		IL_0089: call object [mscorlib]System.Activator::CreateInstance(class [mscorlib]System.Type, bool)",
"		IL_008e: stfld object Backbone::_extensionManager",
"		IL_0093: ldloc.s t",
"		IL_0095: ldstr \"Initialize\"",
"		IL_009a: callvirt instance class [mscorlib]System.Reflection.MethodInfo [mscorlib]System.Type::GetMethod(string)",
"		IL_009f: stloc.s initializeMethod",
"		IL_00a1: ldloc.s initializeMethod",
"		IL_00a3: ldarg.0",
"		IL_00a4: ldfld object Backbone::_extensionManager",
"		IL_00a9: ldc.i4.0",
"		IL_00aa: newarr [mscorlib]System.Object",
"		IL_00af: callvirt instance object [mscorlib]System.Reflection.MethodBase::Invoke(object, object[])",
"		IL_00b4: pop",
"		IL_00b5: nop",
"",
"		IL_00b6: nop",
"		IL_00b7: ldloc.s CS$7$0002",
"		IL_00b9: ldc.i4.1",
"		IL_00ba: add",
"		IL_00bb: stloc.s CS$7$0002",
"",
"		IL_00bd: ldloc.s CS$7$0002",
"		IL_00bf: ldloc.s CS$6$0001",
"		IL_00c1: ldlen",
"		IL_00c2: conv.i4",
"		IL_00c3: clt",
"		IL_00c5: stloc.s CS$4$0000",
"		IL_00c7: ldloc.s CS$4$0000",
"		IL_00c9: brtrue.s IL_004b",
"	// end loop",
"",
"	IL_00cb: nop",
"",
"	IL_00cc: ret",
"} // end of method ExtensionManager::LoadAssembly",
""
				};
			}
		}

	}
}
