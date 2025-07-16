using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using New_SF_IT.OotionScanner;

namespace New_SF_IT
{
	// Token: 0x02000013 RID: 19
	[NullableContext(1)]
	[Nullable(0)]
	public partial class MainWindow : Window
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00007EA0 File Offset: 0x000060A0
		public MainWindow()
		{
			this.InitializeComponent();
			this.equtiy_Future = new Equtiy_Future();
			this.MainFrame.Content = this.equtiy_Future;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00007ECC File Offset: 0x000060CC
		private void OpenUrl(string url)
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
				MessageBox.Show("Failed to open the link: " + ex.Message);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00007F20 File Offset: 0x00006120
		private void menuEquity_Click(object sender, RoutedEventArgs e)
		{
			this.menuEquity.BorderBrush = new SolidColorBrush(Colors.Azure);
			this.menuOption.BorderBrush = null;
			this.menuOptionWeekly.BorderBrush = null;
			this.menupairtrade.BorderBrush = null;
			this.menucommodity.BorderBrush = null;
			this.MainFrame.Content = null;
			this.MainFrame.Content = new Equtiy_Future();
			MainWindow.currentTab = "EQ";
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00007F98 File Offset: 0x00006198
		private void menuOption_Click(object sender, RoutedEventArgs e)
		{
			this.menuOption.BorderBrush = new SolidColorBrush(Colors.Azure);
			this.menuEquity.BorderBrush = null;
			this.menuOptionWeekly.BorderBrush = null;
			this.menupairtrade.BorderBrush = null;
			this.menucommodity.BorderBrush = null;
			this.MainFrame.Content = null;
			MainWindow.currentTab = "OPT";
			this.MainFrame.Content = new Option();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00008010 File Offset: 0x00006210
		private void menupairtrade_Click(object sender, RoutedEventArgs e)
		{
			this.menupairtrade.BorderBrush = new SolidColorBrush(Colors.Azure);
			this.menuEquity.BorderBrush = null;
			this.menuOptionWeekly.BorderBrush = null;
			this.menuOption.BorderBrush = null;
			this.menucommodity.BorderBrush = null;
			this.MainFrame.Content = null;
			this.MainFrame.Content = new pairTrade();
			MainWindow.currentTab = "PT";
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00008088 File Offset: 0x00006288
		private void menuOptionWeekly_Click(object sender, RoutedEventArgs e)
		{
			this.menuOption.BorderBrush = null;
			this.menuEquity.BorderBrush = null;
			this.menuOptionWeekly.BorderBrush = new SolidColorBrush(Colors.Azure);
			this.menupairtrade.BorderBrush = null;
			this.menucommodity.BorderBrush = null;
			this.MainFrame.Content = null;
			MainWindow.currentTab = "OPTWEEK";
			this.MainFrame.Content = new Option();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00008100 File Offset: 0x00006300
		private void menucommodity_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Under Development");
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000810D File Offset: 0x0000630D
		private void userManual_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Under Development");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000811A File Offset: 0x0000631A
		private void aboutUs_Click(object sender, RoutedEventArgs e)
		{
			this.OpenUrl("https://www.smartfinancein.com/contactus.php");
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00008127 File Offset: 0x00006327
		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			new StepToUseSoftware
			{
				WindowStartupLocation = WindowStartupLocation.CenterScreen
			}.Show();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000813A File Offset: 0x0000633A
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			if (this.ShouldOpenLogoutWindow())
			{
				new Logout().Show();
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00008155 File Offset: 0x00006355
		private bool ShouldOpenLogoutWindow()
		{
			return true;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00008158 File Offset: 0x00006358
		private void menuOptionScanner_Click(object sender, RoutedEventArgs e)
		{
			new optionsScannerView().Show();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00008164 File Offset: 0x00006364
		private void disclaimer_Click(object sender, RoutedEventArgs e)
		{
			new Disclaimer
			{
				WindowStartupLocation = WindowStartupLocation.CenterScreen
			}.Show();
		}

		// Token: 0x04000109 RID: 265
		public static string currentTab = "EQ";

		// Token: 0x0400010A RID: 266
		internal static string serverCurrentTrialDate;

		// Token: 0x0400010B RID: 267
		private DispatcherTimer loadingTimer;

		// Token: 0x0400010C RID: 268
		private Equtiy_Future equtiy_Future;
	}
}
