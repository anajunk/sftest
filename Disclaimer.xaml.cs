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
	// Token: 0x0200000B RID: 11
	public partial class Disclaimer : Window
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000024A4 File Offset: 0x000006A4
		public Disclaimer()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024B2 File Offset: 0x000006B2
		[NullableContext(1)]
		private void closeClick(object sender, RoutedEventArgs e)
		{
			base.Close();
		}
	}
}
