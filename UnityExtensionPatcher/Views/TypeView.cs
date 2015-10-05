using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Cecil;

namespace UnityExtensionPatcher.Views
{
	public partial class TypeView : UserControl
	{
		public TypeView()
		{
			InitializeComponent();
		}

		public void SetType(TypeDefinition typeDefinition)
		{
			// Create declaration string
			StringBuilder builder = new StringBuilder();
			
			string accessibilityStr = typeDefinition.IsPublic ? "public " : "private ";
			string sealedStr = typeDefinition.IsSealed ? "sealed " : "";
			string typeStr = "";
			if (typeDefinition.IsClass)
			{
				typeStr = "class ";
            }
			textDeclaration.Text = $"{accessibilityStr}{sealedStr}{typeStr}{typeDefinition.Name} : {typeDefinition.BaseType.Name}";
        }
	}
}
