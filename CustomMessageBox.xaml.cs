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
	// Token: 0x0200000A RID: 10
	public partial class CustomMessageBox : Window
	{
		// Token: 0x0600001C RID: 28 RVA: 0x0000240B File Offset: 0x0000060B
		public CustomMessageBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002419 File Offset: 0x00000619
		[NullableContext(1)]
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(true);
			base.Close();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000242D File Offset: 0x0000062D
		public static bool? Show()
		{
			return new CustomMessageBox().ShowDialog();
		}
	}
}
