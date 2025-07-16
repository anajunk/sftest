using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace New_SF_IT.OptionMonth
{
	// Token: 0x02000026 RID: 38
	public partial class optionArbitrage : UserControl
	{
		// Token: 0x060001FE RID: 510 RVA: 0x000204F4 File Offset: 0x0001E6F4
		public optionArbitrage()
		{
			this.InitializeComponent();
			optionArbitrageViewModel vm = new optionArbitrageViewModel();
			base.DataContext = vm;
		}
	}
}
