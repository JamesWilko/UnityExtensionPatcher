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
			textDeclaration.Text = Utils.TypeNameUtils.GetTypeDeclarationString(typeDefinition);
        }
	}
}
