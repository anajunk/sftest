using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace New_SF_IT
{
	// Token: 0x0200000D RID: 13
	public class EF : UserControl, IComponentConnector
	{
		// Token: 0x06000074 RID: 116 RVA: 0x000059D4 File Offset: 0x00003BD4
		public EF()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000059E2 File Offset: 0x00003BE2
		[NullableContext(1)]
		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000059E4 File Offset: 0x00003BE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocater = new Uri("/New SF_IT;component/eq_fu.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005A14 File Offset: 0x00003C14
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.instrumentCb = (ComboBox)target;
				return;
			case 2:
				this.symbolAutoBox = (TextBox)target;
				return;
			case 3:
				this.expiryDateCb = (ComboBox)target;
				return;
			case 4:
				this.btnLoad = (Button)target;
				this.btnLoad.Click += this.btnLoad_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000DC RID: 220
		internal ComboBox instrumentCb;

		// Token: 0x040000DD RID: 221
		internal TextBox symbolAutoBox;

		// Token: 0x040000DE RID: 222
		internal ComboBox expiryDateCb;

		// Token: 0x040000DF RID: 223
		internal Button btnLoad;

		// Token: 0x040000E0 RID: 224
		private bool _contentLoaded;
	}
}
