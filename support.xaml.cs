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
	// Token: 0x02000018 RID: 24
	public partial class support : UserControl
	{
		// Token: 0x06000128 RID: 296 RVA: 0x0000E12D File Offset: 0x0000C32D
		public support()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000E13B File Offset: 0x0000C33B
		[NullableContext(1)]
		private void reviewClick(object sender, RoutedEventArgs e)
		{
			this.OpenBrowser("https://g.page/r/CdLUv7r99q7_EB0/review");
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000E148 File Offset: 0x0000C348
		[NullableContext(1)]
		private void OpenBrowser(string url)
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = url,
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open link: " + ex.Message);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000E19C File Offset: 0x0000C39C
		[NullableContext(1)]
		private void productClick(object sender, RoutedEventArgs e)
		{
			this.OpenBrowser("https://smartfinancein.com/smart_trading_tool.php");
		}
	}
}
