using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using New_SF_IT.classes;
using siteDownLoadHelper;

namespace New_SF_IT.OotionScanner
{
	// Token: 0x0200002E RID: 46
	public partial class optionsScannerView : Window
	{
		// Token: 0x0600025D RID: 605 RVA: 0x000313F8 File Offset: 0x0002F5F8
		public optionsScannerView()
		{
			this.InitializeComponent();
			this.dataGrid1.RowBackground = Brushes.Beige;
			this.dataGrid2.RowBackground = Brushes.Beige;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0003146F File Offset: 0x0002F66F
		[NullableContext(1)]
		private void AutoCompleteBox_TextChanged(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00031471 File Offset: 0x0002F671
		[NullableContext(1)]
		private void WrapPanel_Scroll(object sender, ScrollEventArgs e)
		{
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00031474 File Offset: 0x0002F674
		[NullableContext(1)]
		private void CB_checked(object sender, RoutedEventArgs e)
		{
			this.analyse.IsEnabled = true;
			CheckBox cb = sender as CheckBox;
			if (cb.Name == "all")
			{
				this.call.IsChecked = new bool?(false);
				this.put.IsChecked = new bool?(false);
				this.greaterthan.IsChecked = new bool?(false);
				this.lessthan.IsChecked = new bool?(false);
				this.between.IsChecked = new bool?(false);
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				this.greaterthan.IsEnabled = false;
				this.lessthan.IsEnabled = false;
				this.between.IsEnabled = false;
				this.ltp.IsEnabled = false;
				this.cBuyinUp.IsEnabled = false;
				this.cSellinDown.IsEnabled = false;
				this.pSellinUp.IsEnabled = false;
				this.pBuyinDown.IsEnabled = false;
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BW_BE_Tgts.IsEnabled = false;
				this.BW_SE_Tgts.IsEnabled = false;
				this.BestWC_Buy_Up.IsEnabled = false;
				this.BestWC_Sell_Down.IsEnabled = false;
				this.BestWP_Sell_Up.IsEnabled = false;
				this.BestWP_Buy_Down.IsEnabled = false;
				optionsScannerView.optionType = "All";
				optionsScannerView.condition = "";
				optionsScannerView.parameter = "";
				return;
			}
			if (cb.Name == "call")
			{
				this.all.IsChecked = new bool?(false);
				this.put.IsChecked = new bool?(false);
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				this.ltp.IsEnabled = false;
				this.cBuyinUp.IsEnabled = false;
				this.cSellinDown.IsEnabled = false;
				this.pSellinUp.IsEnabled = false;
				this.pBuyinDown.IsEnabled = false;
				this.greaterthan.IsEnabled = true;
				this.lessthan.IsEnabled = true;
				this.between.IsEnabled = true;
				this.greaterthan.IsChecked = new bool?(false);
				this.lessthan.IsChecked = new bool?(false);
				this.between.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsEnabled = false;
				this.BestWC_Sell_Down.IsEnabled = false;
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsEnabled = false;
				this.BestWP_Sell_Up.IsEnabled = false;
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				this.trends.Visibility = Visibility.Collapsed;
				optionsScannerView.optionType = "Call ";
				return;
			}
			if (cb.Name == "put")
			{
				this.all.IsChecked = new bool?(false);
				this.call.IsChecked = new bool?(false);
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				this.ltp.IsEnabled = false;
				this.cBuyinUp.IsEnabled = false;
				this.cSellinDown.IsEnabled = false;
				this.pSellinUp.IsEnabled = false;
				this.pBuyinDown.IsEnabled = false;
				this.greaterthan.IsEnabled = true;
				this.lessthan.IsEnabled = true;
				this.between.IsEnabled = true;
				this.greaterthan.IsChecked = new bool?(false);
				this.lessthan.IsChecked = new bool?(false);
				this.between.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsEnabled = false;
				this.BestWC_Sell_Down.IsEnabled = false;
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsEnabled = false;
				this.BestWP_Sell_Up.IsEnabled = false;
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				this.trends.Visibility = Visibility.Collapsed;
				optionsScannerView.optionType = "Put ";
				return;
			}
			if (cb.Name == "greaterthan")
			{
				this.lessthan.IsChecked = new bool?(false);
				this.between.IsChecked = new bool?(false);
				this.ltp.IsEnabled = true;
				this.cBuyinUp.IsEnabled = true;
				this.cSellinDown.IsEnabled = true;
				this.pSellinUp.IsEnabled = true;
				this.pBuyinDown.IsEnabled = true;
				this.BW_BE_Tgts.IsEnabled = false;
				this.BW_SE_Tgts.IsEnabled = false;
				this.BestWC_Buy_Up.IsEnabled = false;
				this.BestWC_Sell_Down.IsEnabled = false;
				this.BestWP_Buy_Down.IsEnabled = false;
				this.BestWP_Sell_Up.IsEnabled = false;
				optionsScannerView.condition = ">= ";
				return;
			}
			if (cb.Name == "lessthan")
			{
				this.greaterthan.IsChecked = new bool?(false);
				this.between.IsChecked = new bool?(false);
				this.ltp.IsEnabled = true;
				this.cBuyinUp.IsEnabled = false;
				this.cSellinDown.IsEnabled = false;
				this.pSellinUp.IsEnabled = false;
				this.pBuyinDown.IsEnabled = false;
				this.BW_BE_Tgts.IsEnabled = false;
				this.BW_SE_Tgts.IsEnabled = false;
				this.BestWC_Buy_Up.IsEnabled = false;
				this.BestWC_Sell_Down.IsEnabled = false;
				this.BestWP_Buy_Down.IsEnabled = false;
				this.BestWP_Sell_Up.IsEnabled = false;
				optionsScannerView.condition = "<= ";
				return;
			}
			if (cb.Name == "between")
			{
				this.greaterthan.IsChecked = new bool?(false);
				this.lessthan.IsChecked = new bool?(false);
				this.ltp.IsEnabled = false;
				this.cBuyinUp.IsEnabled = false;
				this.cSellinDown.IsEnabled = false;
				this.pSellinUp.IsEnabled = false;
				this.pBuyinDown.IsEnabled = false;
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				this.BW_BE_Tgts.IsEnabled = true;
				this.BW_SE_Tgts.IsEnabled = true;
				this.BestWC_Buy_Up.IsEnabled = true;
				this.BestWC_Sell_Down.IsEnabled = true;
				this.BestWP_Buy_Down.IsEnabled = true;
				this.BestWP_Sell_Up.IsEnabled = true;
				optionsScannerView.condition = "between ";
				return;
			}
			if (cb.Name == "ltp")
			{
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				optionsScannerView.parameter = "LTP";
				return;
			}
			if (cb.Name == "cBuyinUp")
			{
				this.ltp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Buy in UpTrend";
				return;
			}
			if (cb.Name == "cSellinDown")
			{
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Sell in DownTrend";
				return;
			}
			if (cb.Name == "pSellinUp")
			{
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pBuyinDown.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Sell in UpTrend";
				return;
			}
			if (cb.Name == "pBuyinDown")
			{
				this.ltp.IsChecked = new bool?(false);
				this.cBuyinUp.IsChecked = new bool?(false);
				this.cSellinDown.IsChecked = new bool?(false);
				this.pSellinUp.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Buy in DownTrend";
				return;
			}
			if (cb.Name == "BW_BE_Tgts")
			{
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Buy Entry Targets";
				return;
			}
			if (cb.Name == "BW_SE_Tgts")
			{
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Sell Entry Targets";
				return;
			}
			if (cb.Name == "BestWC_Buy_Up")
			{
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Best weekly call to Buy in UpTrend";
				return;
			}
			if (cb.Name == "BestWC_Sell_Down")
			{
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Best weekly call to Sell in DownTrend";
				return;
			}
			if (cb.Name == "BestWP_Sell_Up")
			{
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWP_Buy_Down.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Best weekly put to Sell in UpTrend";
				return;
			}
			if (cb.Name == "BestWP_Buy_Down")
			{
				this.BW_BE_Tgts.IsChecked = new bool?(false);
				this.BW_SE_Tgts.IsChecked = new bool?(false);
				this.BestWC_Buy_Up.IsChecked = new bool?(false);
				this.BestWC_Sell_Down.IsChecked = new bool?(false);
				this.BestWP_Sell_Up.IsChecked = new bool?(false);
				optionsScannerView.parameter = "Best weekly put to Buy in DownTrend";
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0003210B File Offset: 0x0003030B
		[NullableContext(1)]
		private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			this.scrollViewer.ScrollToVerticalOffset(this.scrollViewer.VerticalOffset - (double)(e.Delta / 3));
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00032130 File Offset: 0x00030330
		[NullableContext(1)]
		private void Window1_StateChanged(object sender, EventArgs e)
		{
			if (base.WindowState == WindowState.Normal)
			{
				base.SizeToContent = SizeToContent.Width;
				double screenWidth = SystemParameters.PrimaryScreenWidth;
				double screenHeight = SystemParameters.PrimaryScreenHeight;
				double windowWidth = base.Width;
				double windowHeight = base.Height;
				base.Left = screenWidth / 2.0 - windowWidth / 2.0;
				base.Top = screenHeight / 2.0 - windowHeight / 2.0;
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000321A0 File Offset: 0x000303A0
		[NullableContext(1)]
		private void IvRank_CLicked(object sender, RoutedEventArgs e)
		{
			optionsScannerView.get30daysIvRank("");
			optionsScannerView.get60daysIvRank("");
			this.get90daysIvRank("");
			this.get1YearIvRank("");
			MessageBox.Show(string.Concat(new string[]
			{
				"30 days IV Rank          : ",
				optionsScannerView._30daysIVrank.ToString(),
				Environment.NewLine,
				"30 days IV Percentile  : ",
				optionsScannerView._30daysIVpercentile.ToString(),
				Environment.NewLine,
				Environment.NewLine,
				"60 days IV Rank          : ",
				optionsScannerView._60daysIVrank.ToString(),
				Environment.NewLine,
				"60 days IV Percentile  : ",
				optionsScannerView._60daysIVpercentile.ToString(),
				Environment.NewLine,
				Environment.NewLine,
				"90 days IV Rank          : ",
				optionsScannerView._90daysIVrank.ToString(),
				Environment.NewLine,
				"90 days IV Percentile  : ",
				optionsScannerView._90daysIVpercentile.ToString(),
				Environment.NewLine,
				Environment.NewLine,
				"1 year IV Rank             : ",
				optionsScannerView._1YearIVrank.ToString(),
				Environment.NewLine,
				"1 year IV Percentile     : ",
				optionsScannerView._1YearIVpercentile.ToString()
			}), "IV Rank & IV Percentile for NIFTY", MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000322FC File Offset: 0x000304FC
		[NullableContext(1)]
		public static void get30daysIvRank(string Symbol)
		{
			string forTheMonth = "";
			List<string> IVrankAndPercentile_splitedList = optionsScannerView.splitData(optionsScannerView.getIVrankAndPercentile(optionsScannerView.getIVrankAndPercentile_URL, forTheMonth));
			IVrankAndPercentile_splitedList = IVrankAndPercentile_splitedList.Distinct<string>().ToList<string>();
			if (IVrankAndPercentile_splitedList.Count<string>() != 30)
			{
				MessageBox.Show("Not enough data to calculate", "IV Rank & Percentile:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			optionsScannerView._30daysIV = optionsScannerView.calc30_60_90daysIV(IVrankAndPercentile_splitedList, "Call");
			double minValue = optionsScannerView._30daysIV.Min();
			double maxValue = optionsScannerView._30daysIV.Max();
			optionsScannerView._30daysIVrank = Math.Round((optionsScannerView._30daysIV[0] - minValue) / (maxValue - minValue) * 100.0, 2);
			optionsScannerView._30daysIVpercentile = optionsScannerView.get30daysIvPercentile(optionsScannerView._30daysIV);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000323A8 File Offset: 0x000305A8
		[NullableContext(1)]
		public static double get30daysIvPercentile(List<double> __30daysIV)
		{
			int count = 0;
			List<double> Percentile = new List<double>();
			for (int x = 0; x <= __30daysIV.Count<double>() - 1; x++)
			{
				double currentValue = __30daysIV[x];
				if (currentValue <= __30daysIV[0])
				{
					count++;
					Percentile.Add(currentValue);
				}
			}
			return Math.Round(Convert.ToDouble(count) / 30.0 * 100.0, 2);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00032410 File Offset: 0x00030610
		[NullableContext(1)]
		public static void get60daysIvRank(string Symbol)
		{
			string forTheMonth = "";
			List<string> IVrankAndPercentile_splitedList = optionsScannerView.splitData(optionsScannerView.getIVrankAndPercentile(optionsScannerView.get60IVrankAndPercentile_URL, forTheMonth));
			IVrankAndPercentile_splitedList = IVrankAndPercentile_splitedList.Distinct<string>().ToList<string>();
			if (IVrankAndPercentile_splitedList.Count<string>() != 60)
			{
				MessageBox.Show("Not enough data to calculate", "IV Rank & Percentile:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			optionsScannerView._60daysIV = optionsScannerView.calc30_60_90daysIV(IVrankAndPercentile_splitedList, "Call");
			double minValue = optionsScannerView._60daysIV.Min();
			double maxValue = optionsScannerView._60daysIV.Max();
			optionsScannerView._60daysIVrank = Math.Round((optionsScannerView._60daysIV[0] - minValue) / (maxValue - minValue) * 100.0, 2);
			optionsScannerView._60daysIVpercentile = optionsScannerView.get60daysIvPercentile(optionsScannerView._60daysIV);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000324BC File Offset: 0x000306BC
		[NullableContext(1)]
		public static double get60daysIvPercentile(List<double> __60daysIV)
		{
			int count = 0;
			List<double> Percentile = new List<double>();
			for (int x = 0; x <= __60daysIV.Count<double>() - 1; x++)
			{
				double currentValue = __60daysIV[x];
				if (currentValue <= __60daysIV[0])
				{
					count++;
					Percentile.Add(currentValue);
				}
			}
			return Math.Round(Convert.ToDouble(count) / 60.0 * 100.0, 2);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00032524 File Offset: 0x00030724
		[NullableContext(1)]
		public void get90daysIvRank(string Symbol)
		{
			string forTheMonth = "";
			List<string> IVrankAndPercentile_splitedList = optionsScannerView.splitData(optionsScannerView.getIVrankAndPercentile(optionsScannerView.get90IVrankAndPercentile_URL, forTheMonth));
			IVrankAndPercentile_splitedList = IVrankAndPercentile_splitedList.Distinct<string>().ToList<string>();
			if (IVrankAndPercentile_splitedList.Count<string>() != 90)
			{
				MessageBox.Show("Not enough data to calculate", "IV Rank & Percentile:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			optionsScannerView._90daysIV = optionsScannerView.calc30_60_90daysIV(IVrankAndPercentile_splitedList, "Call");
			double minValue = optionsScannerView._90daysIV.Min();
			double maxValue = optionsScannerView._90daysIV.Max();
			optionsScannerView._90daysIVrank = Math.Round((optionsScannerView._90daysIV[0] - minValue) / (maxValue - minValue) * 100.0, 2);
			optionsScannerView._90daysIVpercentile = optionsScannerView.get90daysIvPercentile(optionsScannerView._90daysIV);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000325D0 File Offset: 0x000307D0
		[NullableContext(1)]
		public static double get90daysIvPercentile(List<double> __90daysIV)
		{
			int count = 0;
			List<double> Percentile = new List<double>();
			for (int x = 0; x <= __90daysIV.Count<double>() - 1; x++)
			{
				double currentValue = __90daysIV[x];
				if (currentValue <= __90daysIV[0])
				{
					count++;
					Percentile.Add(currentValue);
				}
			}
			return Math.Round(Convert.ToDouble(count) / 90.0 * 100.0, 2);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00032638 File Offset: 0x00030838
		[NullableContext(1)]
		public void get1YearIvRank(string Symbol)
		{
			string forTheMonth = "";
			List<string> IVrankAndPercentile_splitedList = optionsScannerView.splitData(optionsScannerView.getIVrankAndPercentile(optionsScannerView.get1YearIVrankAndPercentile_URL, forTheMonth));
			IVrankAndPercentile_splitedList = IVrankAndPercentile_splitedList.Distinct<string>().ToList<string>();
			if (IVrankAndPercentile_splitedList.Count<string>() != 365)
			{
				MessageBox.Show("Not enough data to calculate", "IV Rank & Percentile:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			optionsScannerView._1YearIV = optionsScannerView.calc30_60_90daysIV(IVrankAndPercentile_splitedList, "Call");
			double minValue = optionsScannerView._1YearIV.Min();
			double maxValue = optionsScannerView._1YearIV.Max();
			optionsScannerView._1YearIVrank = Math.Round((optionsScannerView._1YearIV[0] - minValue) / (maxValue - minValue) * 100.0, 2);
			optionsScannerView._1YearIVpercentile = optionsScannerView.get1YearIvPercentile(optionsScannerView._1YearIV);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000326E4 File Offset: 0x000308E4
		[NullableContext(1)]
		public static double get1YearIvPercentile(List<double> _1YearIV)
		{
			int count = 0;
			List<double> Percentile = new List<double>();
			for (int x = 0; x <= _1YearIV.Count<double>() - 1; x++)
			{
				double currentValue = _1YearIV[x];
				if (currentValue <= _1YearIV[0])
				{
					count++;
					Percentile.Add(currentValue);
				}
			}
			return Math.Round(Convert.ToDouble(count) / 365.0 * 100.0, 2);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0003274C File Offset: 0x0003094C
		[NullableContext(1)]
		public static List<double> calc30_60_90daysIV(List<string> _IVrankAndPercentileList, string OT)
		{
			int count = _IVrankAndPercentileList.Count;
			new List<string>();
			List<double> _30Or60Or90daysIVList = new List<double>();
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				List<string> list = optionsScannerView.splitData(_IVrankAndPercentileList.ElementAt(currentRow), "");
				Convert.ToString(list[1]);
				double Spot = Convert.ToDouble(list[2]);
				double Strike = Convert.ToDouble(list[3]);
				double Premium = Convert.ToDouble(list[4]);
				int Days = Convert.ToInt32(list[5]);
				Convert.ToDouble(list[7]);
				if (OT == "Call")
				{
					double IV = optionsScannerfMathCls.ImpliedVolatility(Premium, Days, Spot, Strike, OT);
					if (!double.IsNaN(IV) && IV != 0.0)
					{
						_30Or60Or90daysIVList.Add(IV);
					}
				}
				if (OT == "Put")
				{
					double IV2 = optionsScannerfMathCls.ImpliedVolatility(Premium, Days, Spot, Strike, OT);
					if (!double.IsNaN(IV2) && IV2 != 0.0)
					{
						_30Or60Or90daysIVList.Add(IV2);
					}
				}
			}
			return _30Or60Or90daysIVList;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00032856 File Offset: 0x00030A56
		[NullableContext(1)]
		public static List<string> splitData(string Data, string Surl)
		{
			return new List<string>(Data.Split(',', StringSplitOptions.None));
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00032868 File Offset: 0x00030A68
		[NullableContext(1)]
		public static string getIVrankAndPercentile(string _getIVrankAndPercentile_URL, string _forTheMonth)
		{
			_getIVrankAndPercentile_URL = string.Format(_getIVrankAndPercentile_URL, _forTheMonth);
			string IVrankAndPercentile = optionsScannerView.dataDownload("", _getIVrankAndPercentile_URL);
			if (!IVrankAndPercentile.Any<char>())
			{
				return "";
			}
			return IVrankAndPercentile;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000328A4 File Offset: 0x00030AA4
		[NullableContext(1)]
		public static string dataDownload(string Expiry, string url)
		{
			string downloadedSymbols = "";
			if (Comman.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, Expiry))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					downloadedSymbols = data;
				}
			}
			return downloadedSymbols;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000328E0 File Offset: 0x00030AE0
		[NullableContext(1)]
		public static List<string> splitData(string Data)
		{
			string[] splitList = new string[]
			{
				"<br>"
			};
			string[] array = (from x in Data.Split(splitList, StringSplitOptions.None)
			where !string.IsNullOrEmpty(x)
			select x).ToArray<string>();
			List<string> final_spltd = new List<string>();
			foreach (string text in array)
			{
				string s_new = text.Remove(text.Length - 1, 1);
				final_spltd.Add(s_new);
			}
			return final_spltd;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00032960 File Offset: 0x00030B60
		[NullableContext(1)]
		private void maxPain_CLicked(object sender, RoutedEventArgs e)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>(optionsScannerMainClass.filertered_cOI_Strikes);
			Dictionary<string, string> pOI_Strikes = new Dictionary<string, string>(optionsScannerMainClass.filertered_pOI_Strikes);
			List<double> list = (from s in new List<string>(dictionary.Keys)
			select double.Parse(s)).ToList<double>();
			Converter<double, int> converter;
			if ((converter = optionsScannerView.<>O.<0>__ToInt32) == null)
			{
				converter = (optionsScannerView.<>O.<0>__ToInt32 = new Converter<double, int>(Convert.ToInt32));
			}
			List<int> strikePrice = list.ConvertAll<int>(converter);
			List<int> callOI = (from s in new List<string>(dictionary.Values)
			select int.Parse(s)).ToList<int>();
			List<int> putOI = (from s in new List<string>(pOI_Strikes.Values)
			select int.Parse(s)).ToList<int>();
			strikePrice.Max();
			int lowestStrike = strikePrice.Min();
			List<int> lowestStrike_v_allStrike = new List<int>();
			for (int i = 0; i <= strikePrice.Count<int>() - 1; i++)
			{
				lowestStrike_v_allStrike.Add(strikePrice[i] - lowestStrike);
			}
			List<int> _putOI = putOI.ToList<int>();
			List<int> _lowestStrike_v_allStrike = lowestStrike_v_allStrike.ToList<int>();
			List<long> cumulativePut_List = new List<long>();
			for (int a = 0; a < putOI.Count<int>(); a++)
			{
				long cumulativePutResult = this.getCumulativePut(_putOI, _lowestStrike_v_allStrike);
				cumulativePut_List.Add(cumulativePutResult);
				_putOI.RemoveAt(0);
				_lowestStrike_v_allStrike.RemoveAt(_lowestStrike_v_allStrike.Count - 1);
			}
			List<int> _callOI = callOI.ToList<int>();
			_lowestStrike_v_allStrike = lowestStrike_v_allStrike.ToList<int>();
			List<long> cumulativeCall_List = new List<long>();
			new List<long>();
			cumulativeCall_List = this.getCumulativeCall(_callOI, _lowestStrike_v_allStrike);
			new List<long>();
			List<long> maxPainResult = this.getMaxPainResult(cumulativeCall_List, cumulativePut_List);
			long maxPain_Min = maxPainResult.Min();
			long maxPain_Max = maxPainResult.Max();
			int indexMin = maxPainResult.IndexOf(maxPainResult.Min());
			int indexMax = maxPainResult.IndexOf(maxPainResult.Max());
			int strikePriceOfMin = strikePrice[indexMin];
			int num = strikePrice[indexMax];
			if (maxPain_Min == 0L || maxPain_Max == 0L)
			{
				MessageBox.Show("Not enough data to calculate", "Max Pain:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			MessageBox.Show(string.Concat(new string[]
			{
				"Option MaxPain Strike ",
				strikePriceOfMin.ToString(),
				" value is : ",
				maxPain_Min.ToString(),
				Environment.NewLine
			}), "MaxPain for " + this.autoCText.Text, MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00032BD0 File Offset: 0x00030DD0
		[NullableContext(1)]
		private void maxPain_Weekly_CLicked(object sender, RoutedEventArgs e)
		{
			new optionsScannerMainClass().LoadOptionsDataTable_Weekly();
			Dictionary<string, string> dictionary = new Dictionary<string, string>(optionsScannerMainClass.filertered_cOI_Strikes_weekly);
			Dictionary<string, string> pOI_Strikes = new Dictionary<string, string>(optionsScannerMainClass.filertered_pOI_Strikes_weekly);
			List<double> list = (from s in new List<string>(dictionary.Keys)
			select double.Parse(s)).ToList<double>();
			Converter<double, int> converter;
			if ((converter = optionsScannerView.<>O.<0>__ToInt32) == null)
			{
				converter = (optionsScannerView.<>O.<0>__ToInt32 = new Converter<double, int>(Convert.ToInt32));
			}
			List<int> strikePrice = list.ConvertAll<int>(converter);
			List<int> callOI = (from s in new List<string>(dictionary.Values)
			select int.Parse(s)).ToList<int>();
			List<int> putOI = (from s in new List<string>(pOI_Strikes.Values)
			select int.Parse(s)).ToList<int>();
			strikePrice.Max();
			int lowestStrike = strikePrice.Min();
			List<int> lowestStrike_v_allStrike = new List<int>();
			for (int i = 0; i <= strikePrice.Count<int>() - 1; i++)
			{
				lowestStrike_v_allStrike.Add(strikePrice[i] - lowestStrike);
			}
			List<int> _putOI = putOI.ToList<int>();
			List<int> _lowestStrike_v_allStrike = lowestStrike_v_allStrike.ToList<int>();
			List<long> cumulativePut_List = new List<long>();
			for (int a = 0; a < putOI.Count<int>(); a++)
			{
				long cumulativePutResult = this.getCumulativePut(_putOI, _lowestStrike_v_allStrike);
				cumulativePut_List.Add(cumulativePutResult);
				_putOI.RemoveAt(0);
				_lowestStrike_v_allStrike.RemoveAt(_lowestStrike_v_allStrike.Count - 1);
			}
			List<int> _callOI = callOI.ToList<int>();
			_lowestStrike_v_allStrike = lowestStrike_v_allStrike.ToList<int>();
			List<long> cumulativeCall_List = new List<long>();
			new List<long>();
			cumulativeCall_List = this.getCumulativeCall(_callOI, _lowestStrike_v_allStrike);
			new List<long>();
			List<long> maxPainResult = this.getMaxPainResult(cumulativeCall_List, cumulativePut_List);
			long maxPain_Min = maxPainResult.Min();
			long maxPain_Max = maxPainResult.Max();
			int indexMin = maxPainResult.IndexOf(maxPainResult.Min());
			int indexMax = maxPainResult.IndexOf(maxPainResult.Max());
			int strikePriceOfMin = strikePrice[indexMin];
			int num = strikePrice[indexMax];
			if (maxPain_Min == 0L || maxPain_Max == 0L)
			{
				MessageBox.Show("Not enough data to calculate", "Max Pain:", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			MessageBox.Show(string.Concat(new string[]
			{
				"Option MaxPain Strike ",
				strikePriceOfMin.ToString(),
				" value is : ",
				maxPain_Min.ToString(),
				Environment.NewLine
			}), "MaxPain for " + this.autoCText.Text, MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00032E48 File Offset: 0x00031048
		[NullableContext(1)]
		private long getCumulativePut(List<int> _putOI, List<int> _lowestStrike_v_allStrike)
		{
			long result = 0L;
			for (int i = 0; i < _putOI.Count<int>(); i++)
			{
				long num = Convert.ToInt64(_putOI[i]);
				long element2 = Convert.ToInt64(_lowestStrike_v_allStrike[i]);
				long curResult = num * element2;
				result += curResult;
			}
			return result;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00032E90 File Offset: 0x00031090
		[NullableContext(1)]
		private List<long> getCumulativeCall(List<int> _callOI, List<int> _lowestStrike_v_allStrike)
		{
			List<long> result = new List<long>();
			for (int i = 0; i < _callOI.Count<int>(); i++)
			{
				long curResult;
				if (i == 0 || i == 1)
				{
					long element = Convert.ToInt64(_callOI[0]);
					long element2 = Convert.ToInt64(_lowestStrike_v_allStrike[i]);
					curResult = element * element2;
				}
				else
				{
					List<int> helper_IndexToIndex = _lowestStrike_v_allStrike.GetRange(1, i);
					helper_IndexToIndex.Reverse();
					List<int> callOI_IndexToIndex = _callOI.GetRange(0, i);
					List<long> multiplied_elements = new List<long>();
					for (int j = 0; j <= callOI_IndexToIndex.Count - 1; j++)
					{
						long element = Convert.ToInt64(callOI_IndexToIndex[j]);
						long element2 = Convert.ToInt64(helper_IndexToIndex[j]);
						multiplied_elements.Add(element * element2);
					}
					curResult = multiplied_elements.Sum((long x) => x);
				}
				result.Add(curResult);
			}
			return result;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00032F84 File Offset: 0x00031184
		[NullableContext(1)]
		private List<long> getMaxPainResult(List<long> _cumulativeCall_List, List<long> _cumulativePut_List)
		{
			List<long> _getMaxPainResult = new List<long>();
			for (int i = 0; i <= _cumulativeCall_List.Count - 1; i++)
			{
				long num = Convert.ToInt64(_cumulativeCall_List[i]);
				long element2 = Convert.ToInt64(_cumulativePut_List[i]);
				long currentIndexResult = num + element2;
				_getMaxPainResult.Add(currentIndexResult);
			}
			return _getMaxPainResult;
		}

		// Token: 0x040005D9 RID: 1497
		[Nullable(1)]
		public static string optionType;

		// Token: 0x040005DA RID: 1498
		[Nullable(1)]
		public static string condition;

		// Token: 0x040005DB RID: 1499
		[Nullable(1)]
		public static string parameter;

		// Token: 0x040005DC RID: 1500
		[Nullable(1)]
		private MainWindow mainWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault((Window window) => window is MainWindow) as MainWindow;

		// Token: 0x040005DD RID: 1501
		public static double _30daysIVrank = 0.0;

		// Token: 0x040005DE RID: 1502
		public static double _30daysIVpercentile = 0.0;

		// Token: 0x040005DF RID: 1503
		[Nullable(1)]
		public static List<double> _30daysIV = new List<double>();

		// Token: 0x040005E0 RID: 1504
		public static double _60daysIVrank = 0.0;

		// Token: 0x040005E1 RID: 1505
		public static double _60daysIVpercentile = 0.0;

		// Token: 0x040005E2 RID: 1506
		[Nullable(1)]
		public static List<double> _60daysIV = new List<double>();

		// Token: 0x040005E3 RID: 1507
		public static double _90daysIVrank = 0.0;

		// Token: 0x040005E4 RID: 1508
		public static double _90daysIVpercentile = 0.0;

		// Token: 0x040005E5 RID: 1509
		[Nullable(1)]
		public static List<double> _90daysIV = new List<double>();

		// Token: 0x040005E6 RID: 1510
		public static double _1YearIVrank = 0.0;

		// Token: 0x040005E7 RID: 1511
		public static double _1YearIVpercentile = 0.0;

		// Token: 0x040005E8 RID: 1512
		[Nullable(1)]
		public static List<double> _1YearIV = new List<double>();

		// Token: 0x040005E9 RID: 1513
		[Nullable(1)]
		public static string getIVrankAndPercentile_URL = "https://smartfinance.in/PHPusedForSoftwares/getIVrankAndPercentile.php?calMonth={0}";

		// Token: 0x040005EA RID: 1514
		[Nullable(1)]
		public static string get60IVrankAndPercentile_URL = "https://smartfinance.in/PHPusedForSoftwares/get60IVrankAndPercentile.php?calMonth={0}";

		// Token: 0x040005EB RID: 1515
		[Nullable(1)]
		public static string get90IVrankAndPercentile_URL = "https://smartfinance.in/PHPusedForSoftwares/get90IVrankAndPercentile.php?calMonth={0}";

		// Token: 0x040005EC RID: 1516
		[Nullable(1)]
		public static string get1YearIVrankAndPercentile_URL = "https://smartfinance.in/PHPusedForSoftwares/get1YearIVrankAndPercentile.php?calMonth={0}";

		// Token: 0x02000074 RID: 116
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04001326 RID: 4902
			public static Converter<double, int> <0>__ToInt32;
		}
	}
}
