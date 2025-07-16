using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using FnOHelper;
using HtmlAgilityPack;
using ltp10Days;
using New_SF_IT.Average_and_Pivot_Principle;
using New_SF_IT.chartWindow;
using New_SF_IT.EF_Designs;
using New_SF_IT.Elliot_Designs;
using New_SF_IT.Fibonacci;
using New_SF_IT.GannTime_Design;
using New_SF_IT.Volatality_Designs;
using SFHelper;
using siteDownLoadHelper;

namespace New_SF_IT
{
	// Token: 0x0200000C RID: 12
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Equtiy_Future : UserControl
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002511 File Offset: 0x00000711
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002518 File Offset: 0x00000718
		public static double PrevHigh { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002520 File Offset: 0x00000720
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002527 File Offset: 0x00000727
		public static double PrevLow { get; private set; }

		// Token: 0x06000029 RID: 41 RVA: 0x00002530 File Offset: 0x00000730
		public Equtiy_Future()
		{
			this.InitializeComponent();
			this.instrumentCb.Items.Add("EQUITY");
			this.instrumentCb.Items.Add("STOCK FUTURE");
			this.instrumentCb.Items.Add("INDEX FUTURE");
			this.expiryDate.Items.Add("Previous Month");
			this.expiryDate.Items.Add("Trailing One Month");
			this.read_fromFile(this._profilePATH);
			this.IntradayRadioButton.IsChecked = new bool?(true);
			this.LoadDataAsync();
			this.EqFrame0.Content = this.sup;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002664 File Offset: 0x00000864
		private Task LoadDataAsync()
		{
			Equtiy_Future.<LoadDataAsync>d__93 <LoadDataAsync>d__;
			<LoadDataAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<LoadDataAsync>d__.<>4__this = this;
			<LoadDataAsync>d__.<>1__state = -1;
			<LoadDataAsync>d__.<>t__builder.Start<Equtiy_Future.<LoadDataAsync>d__93>(ref <LoadDataAsync>d__);
			return <LoadDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000026A8 File Offset: 0x000008A8
		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Equtiy_Future.<btnLoad_Click>d__94 <btnLoad_Click>d__;
			<btnLoad_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<btnLoad_Click>d__.<>4__this = this;
			<btnLoad_Click>d__.<>1__state = -1;
			<btnLoad_Click>d__.<>t__builder.Start<Equtiy_Future.<btnLoad_Click>d__94>(ref <btnLoad_Click>d__);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000026E0 File Offset: 0x000008E0
		private void btnCal_Click(object sender, RoutedEventArgs e)
		{
			Equtiy_Future.neutralCount = new List<string>();
			Equtiy_Future.buyCount = new List<string>();
			Equtiy_Future.sellCount = new List<string>();
			if (this.tabItem7.IsSelected)
			{
				this.lowAngle.Initialize_Variable();
				this.highAngle.Initialize_Variable();
				this.staticAngle.Initialize_Variable();
				this.gannAngle.Initialize_Variable();
				this.HLSquaring.Initialize_Variable();
				this.HexaAngle.Initialize_Variable();
				this.pricetime.Initialize_Variable();
				this.pricerange.Initialize_Variable();
				this.Gannsummary.Initialize_Variable();
				MessageBox.Show("Calculation Completed", "STT");
				this.TimeFrame1.Content = this.lowAngle;
				return;
			}
			bool? isChecked = this.PositionalRadioButton.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				Equtiy_Future.NoOfHoldDays = int.Parse(this.PositionalTextBox.Text);
			}
			else
			{
				Equtiy_Future.NoOfHoldDays = 0;
			}
			try
			{
				this.gav.Initialize_Variable();
				this.nC_Trend.calculate();
				this.gann_Vib.Initialize_Variable();
				this.intraday_Vib.Initialize_Variable();
				this.GannHexCal();
				this.gann_Hexagonal.Display();
				this.intraday_Tetra.Display();
				this.gann9.InitializeVariable();
				this.gann12.InitializeVariable();
				this.gann_Price.Initialize_Variable();
				this.oneSD.Display();
				this.volatalityScanner.Calculate();
				this.intradayTopBottom.Initialize_Variable();
				this.volatalityOHLC.Initialize_Variable();
				this.volatalityLN.Initialize_Variable();
				this.volatalityDrift.Initialize_Variable();
				this.impelsive_And_Correction.Calculate();
				this.corrective.Calculate();
				this.camarila.Calculate();
				this.pivotpoint.Calculate();
				this.projection.Calculate();
				this.retracement.calculate();
				this.Cal = 1;
				MessageBox.Show("Calculation Completed", "STT");
				this.EqFrame0.Content = null;
				this.EqFrame1.Content = this.gav;
			}
			catch (Exception)
			{
				MessageBox.Show("Calculation Error");
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002930 File Offset: 0x00000B30
		public static void daysList()
		{
			for (int i = 1; i <= 31; i++)
			{
				Equtiy_Future.monthlyDaysList.Add(Convert.ToString(i));
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000295C File Offset: 0x00000B5C
		public static double gannAngle_High_AND_Low(string _symbol, string url, string variable)
		{
			double getData = 0.0;
			if (Equtiy_Future.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, _symbol))).getSite();
				if (data == null)
				{
					MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					data = data.Replace("\r", "");
					if (!string.IsNullOrWhiteSpace(data))
					{
						HtmlDocument _htmlDoc = new HtmlDocument();
						_htmlDoc.LoadHtml(data);
						if (variable == "trailingHigh")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("high").InnerHtml);
						}
						else if (variable == "trailingLow")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("low").InnerHtml);
						}
						else if (variable == "previousHigh")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousHigh").InnerHtml);
						}
						else if (variable == "previousLow")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousLow").InnerHtml);
						}
					}
				}
			}
			return getData;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002A6C File Offset: 0x00000C6C
		[NullableContext(2)]
		private DataTable get_optionChainTable()
		{
			DataTable result;
			try
			{
				FnOHelperCls dObj = new FnOHelperCls();
				DateTime.Now.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
				if (dObj != null)
				{
					result = dObj.downloadWebPage(this.instrumentCb.Text.Trim(), this.symbolAutoBox.Text.Trim(), this.expiryDateCb.Text.Trim());
				}
				else
				{
					result = null;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002AFC File Offset: 0x00000CFC
		private List<double> get_historicalData()
		{
			List<double> tenDaysLTP = new ltp10dayscls().get_10DaysLTP(Equtiy_Future.selectedInstrument, Equtiy_Future.selectedSymbol, Equtiy_Future.selectedExpiry, "1month");
			if (tenDaysLTP != null)
			{
				return tenDaysLTP;
			}
			return null;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002B30 File Offset: 0x00000D30
		private LiveMarketQuoteDataCls getLiveData()
		{
			LiveMarketQuoteCls liveMarketQuoteCls = new LiveMarketQuoteCls();
			string _selectedSymbolForLiveData = Equtiy_Future.selectedSymbol.Replace("&", "%26");
			return liveMarketQuoteCls.get_Quote(Equtiy_Future.selectedInstrument, _selectedSymbolForLiveData, Equtiy_Future.selectedExpiry);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002B67 File Offset: 0x00000D67
		private void ProgressBarMain_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002B6C File Offset: 0x00000D6C
		private void EFmaintab1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Clear_Frame();
			this.expiryDate.Visibility = Visibility.Collapsed;
			if (this.instrumentCb.Text.Trim() != "EQUITY")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
			}
			else
			{
				this.expiryDateCb.Visibility = Visibility.Collapsed;
			}
			this.expiryDate.Items.Clear();
			this.subtab1.Visibility = Visibility.Visible;
			this.subtab2.Visibility = Visibility.Visible;
			this.subtab3.Visibility = Visibility.Visible;
			this.subtab4.Visibility = Visibility.Visible;
			this.subtab5.Visibility = Visibility.Visible;
			this.subtab6.Visibility = Visibility.Visible;
			this.subtab7.Visibility = Visibility.Visible;
			this.subtab8.Visibility = Visibility.Visible;
			this.subtab9.Visibility = Visibility.Visible;
			this.subtab10.Visibility = Visibility.Visible;
			this.subtab16.Visibility = Visibility.Collapsed;
			this.subtab17.Visibility = Visibility.Collapsed;
			this.subtab18.Visibility = Visibility.Collapsed;
			this.subtab19.Visibility = Visibility.Collapsed;
			this.subtab20.Visibility = Visibility.Collapsed;
			this.subtab21.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Collapsed;
			this.subtab23.Visibility = Visibility.Collapsed;
			this.subtab24.Visibility = Visibility.Collapsed;
			this.subtab25.Visibility = Visibility.Collapsed;
			this.subtab26.Visibility = Visibility.Collapsed;
			this.subtab27.Visibility = Visibility.Collapsed;
			this.subtab28.Visibility = Visibility.Collapsed;
			this.subtab29.Visibility = Visibility.Collapsed;
			this.subtab30.Visibility = Visibility.Collapsed;
			this.subtab31.Visibility = Visibility.Collapsed;
			this.subtab32.Visibility = Visibility.Collapsed;
			this.subtab33.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Collapsed;
			this.subtabscan.Visibility = Visibility.Collapsed;
			this.subtabnif.Visibility = Visibility.Collapsed;
			this.subtab12.Visibility = Visibility.Collapsed;
			this.subtab13.Visibility = Visibility.Collapsed;
			this.subtab14.Visibility = Visibility.Collapsed;
			this.subtabOHLC.Visibility = Visibility.Collapsed;
			this.subtabDrift.Visibility = Visibility.Collapsed;
			this.subtab15.Visibility = Visibility.Collapsed;
			this.subtab34.Visibility = Visibility.Collapsed;
			this.subtab35.Visibility = Visibility.Collapsed;
			this.subtab36.Visibility = Visibility.Collapsed;
			this.subtab37.Visibility = Visibility.Collapsed;
			this.subtab38.Visibility = Visibility.Collapsed;
			this.subtab39.Visibility = Visibility.Collapsed;
			this.subtab40.Visibility = Visibility.Collapsed;
			this.subtab41.Visibility = Visibility.Collapsed;
			this.subtab42.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002DFC File Offset: 0x00000FFC
		private void EFmaintab2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Clear_Frame();
			this.expiryDate.Visibility = Visibility.Collapsed;
			if (this.instrumentCb.Text.Trim() != "EQUITY")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
			}
			else
			{
				this.expiryDateCb.Visibility = Visibility.Collapsed;
			}
			this.expiryDate.Items.Clear();
			this.subtab1.Visibility = Visibility.Collapsed;
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
			this.subtab4.Visibility = Visibility.Collapsed;
			this.subtab5.Visibility = Visibility.Collapsed;
			this.subtab6.Visibility = Visibility.Collapsed;
			this.subtab7.Visibility = Visibility.Collapsed;
			this.subtab8.Visibility = Visibility.Collapsed;
			this.subtab9.Visibility = Visibility.Collapsed;
			this.subtab10.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Visible;
			this.subtabscan.Visibility = Visibility.Visible;
			this.subtabnif.Visibility = Visibility.Visible;
			this.subtab12.Visibility = Visibility.Visible;
			this.subtab13.Visibility = Visibility.Visible;
			this.subtab14.Visibility = Visibility.Visible;
			this.subtabOHLC.Visibility = Visibility.Visible;
			this.subtabDrift.Visibility = Visibility.Visible;
			this.subtab15.Visibility = Visibility.Visible;
			this.subtab16.Visibility = Visibility.Collapsed;
			this.subtab17.Visibility = Visibility.Collapsed;
			this.subtab18.Visibility = Visibility.Collapsed;
			this.subtab19.Visibility = Visibility.Collapsed;
			this.subtab20.Visibility = Visibility.Collapsed;
			this.subtab21.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Collapsed;
			this.subtab23.Visibility = Visibility.Collapsed;
			this.subtab24.Visibility = Visibility.Collapsed;
			this.subtab25.Visibility = Visibility.Collapsed;
			this.subtab26.Visibility = Visibility.Collapsed;
			this.subtab27.Visibility = Visibility.Collapsed;
			this.subtab28.Visibility = Visibility.Collapsed;
			this.subtab29.Visibility = Visibility.Collapsed;
			this.subtab30.Visibility = Visibility.Collapsed;
			this.subtab31.Visibility = Visibility.Collapsed;
			this.subtab32.Visibility = Visibility.Collapsed;
			this.subtab33.Visibility = Visibility.Collapsed;
			this.subtab34.Visibility = Visibility.Collapsed;
			this.subtab35.Visibility = Visibility.Collapsed;
			this.subtab36.Visibility = Visibility.Collapsed;
			this.subtab37.Visibility = Visibility.Collapsed;
			this.subtab38.Visibility = Visibility.Collapsed;
			this.subtab39.Visibility = Visibility.Collapsed;
			this.subtab40.Visibility = Visibility.Collapsed;
			this.subtab41.Visibility = Visibility.Collapsed;
			this.subtab42.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000308C File Offset: 0x0000128C
		private void EFmaintab3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.subtab1.Visibility = Visibility.Collapsed;
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
			this.subtab4.Visibility = Visibility.Collapsed;
			this.subtab5.Visibility = Visibility.Collapsed;
			this.subtab6.Visibility = Visibility.Collapsed;
			this.subtab7.Visibility = Visibility.Collapsed;
			this.subtab8.Visibility = Visibility.Collapsed;
			this.subtab9.Visibility = Visibility.Collapsed;
			this.subtab10.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Collapsed;
			this.subtabscan.Visibility = Visibility.Collapsed;
			this.subtab12.Visibility = Visibility.Collapsed;
			this.subtab13.Visibility = Visibility.Collapsed;
			this.subtab14.Visibility = Visibility.Collapsed;
			this.subtabOHLC.Visibility = Visibility.Collapsed;
			this.subtabDrift.Visibility = Visibility.Collapsed;
			this.subtab15.Visibility = Visibility.Collapsed;
			this.subtab16.Visibility = Visibility.Visible;
			this.subtab17.Visibility = Visibility.Visible;
			this.subtab18.Visibility = Visibility.Collapsed;
			this.subtab19.Visibility = Visibility.Collapsed;
			this.subtab20.Visibility = Visibility.Collapsed;
			this.subtabnif.Visibility = Visibility.Collapsed;
			this.subtab21.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Collapsed;
			this.subtab23.Visibility = Visibility.Collapsed;
			this.subtab24.Visibility = Visibility.Collapsed;
			this.subtab25.Visibility = Visibility.Collapsed;
			this.subtab26.Visibility = Visibility.Collapsed;
			this.subtab27.Visibility = Visibility.Collapsed;
			this.subtab28.Visibility = Visibility.Collapsed;
			this.subtab29.Visibility = Visibility.Collapsed;
			this.subtab30.Visibility = Visibility.Collapsed;
			this.subtab31.Visibility = Visibility.Collapsed;
			this.subtab32.Visibility = Visibility.Collapsed;
			this.subtab33.Visibility = Visibility.Collapsed;
			this.subtab34.Visibility = Visibility.Collapsed;
			this.subtab35.Visibility = Visibility.Collapsed;
			this.subtab36.Visibility = Visibility.Collapsed;
			this.subtab37.Visibility = Visibility.Collapsed;
			this.subtab38.Visibility = Visibility.Collapsed;
			this.subtab39.Visibility = Visibility.Collapsed;
			this.subtab40.Visibility = Visibility.Collapsed;
			this.subtab41.Visibility = Visibility.Collapsed;
			this.subtab42.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000032C4 File Offset: 0x000014C4
		private void EFmaintab4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Clear_Frame();
			this.expiryDate.Visibility = Visibility.Collapsed;
			if (this.instrumentCb.Text.Trim() != "EQUITY")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
			}
			else
			{
				this.expiryDateCb.Visibility = Visibility.Collapsed;
			}
			this.expiryDate.Items.Clear();
			this.subtab1.Visibility = Visibility.Collapsed;
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
			this.subtab4.Visibility = Visibility.Collapsed;
			this.subtab5.Visibility = Visibility.Collapsed;
			this.subtab6.Visibility = Visibility.Collapsed;
			this.subtab7.Visibility = Visibility.Collapsed;
			this.subtab8.Visibility = Visibility.Collapsed;
			this.subtab9.Visibility = Visibility.Collapsed;
			this.subtab10.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Collapsed;
			this.subtabscan.Visibility = Visibility.Collapsed;
			this.subtabnif.Visibility = Visibility.Collapsed;
			this.subtab12.Visibility = Visibility.Collapsed;
			this.subtab13.Visibility = Visibility.Collapsed;
			this.subtab14.Visibility = Visibility.Collapsed;
			this.subtabOHLC.Visibility = Visibility.Collapsed;
			this.subtabDrift.Visibility = Visibility.Collapsed;
			this.subtab15.Visibility = Visibility.Collapsed;
			this.subtab16.Visibility = Visibility.Collapsed;
			this.subtab17.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Visible;
			this.subtab23.Visibility = Visibility.Visible;
			this.subtab28.Visibility = Visibility.Collapsed;
			this.subtab29.Visibility = Visibility.Collapsed;
			this.subtab30.Visibility = Visibility.Collapsed;
			this.subtab31.Visibility = Visibility.Collapsed;
			this.subtab32.Visibility = Visibility.Collapsed;
			this.subtab33.Visibility = Visibility.Collapsed;
			this.subtab34.Visibility = Visibility.Collapsed;
			this.subtab35.Visibility = Visibility.Collapsed;
			this.subtab36.Visibility = Visibility.Collapsed;
			this.subtab37.Visibility = Visibility.Collapsed;
			this.subtab38.Visibility = Visibility.Collapsed;
			this.subtab39.Visibility = Visibility.Collapsed;
			this.subtab40.Visibility = Visibility.Collapsed;
			this.subtab41.Visibility = Visibility.Collapsed;
			this.subtab42.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000034F4 File Offset: 0x000016F4
		private void EFmaintab5_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Clear_Frame();
			this.expiryDate.Visibility = Visibility.Collapsed;
			if (this.instrumentCb.Text.Trim() != "EQUITY")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
			}
			else
			{
				this.expiryDateCb.Visibility = Visibility.Collapsed;
			}
			this.expiryDate.Items.Clear();
			this.subtab1.Visibility = Visibility.Collapsed;
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
			this.subtab4.Visibility = Visibility.Collapsed;
			this.subtab5.Visibility = Visibility.Collapsed;
			this.subtab6.Visibility = Visibility.Collapsed;
			this.subtab7.Visibility = Visibility.Collapsed;
			this.subtab8.Visibility = Visibility.Collapsed;
			this.subtab9.Visibility = Visibility.Collapsed;
			this.subtab10.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Collapsed;
			this.subtab12.Visibility = Visibility.Collapsed;
			this.subtab13.Visibility = Visibility.Collapsed;
			this.subtab14.Visibility = Visibility.Collapsed;
			this.subtab15.Visibility = Visibility.Collapsed;
			this.subtab16.Visibility = Visibility.Collapsed;
			this.subtab17.Visibility = Visibility.Collapsed;
			this.subtab18.Visibility = Visibility.Collapsed;
			this.subtab19.Visibility = Visibility.Collapsed;
			this.subtab20.Visibility = Visibility.Collapsed;
			this.subtab21.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Collapsed;
			this.subtab23.Visibility = Visibility.Collapsed;
			this.subtab24.Visibility = Visibility.Collapsed;
			this.subtab25.Visibility = Visibility.Collapsed;
			this.subtab26.Visibility = Visibility.Collapsed;
			this.subtab27.Visibility = Visibility.Collapsed;
			this.subtab28.Visibility = Visibility.Visible;
			this.subtab29.Visibility = Visibility.Visible;
			this.subtab34.Visibility = Visibility.Collapsed;
			this.subtab35.Visibility = Visibility.Collapsed;
			this.subtab36.Visibility = Visibility.Collapsed;
			this.subtab37.Visibility = Visibility.Collapsed;
			this.subtab38.Visibility = Visibility.Collapsed;
			this.subtab39.Visibility = Visibility.Collapsed;
			this.subtab40.Visibility = Visibility.Collapsed;
			this.subtab41.Visibility = Visibility.Collapsed;
			this.subtab42.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003721 File Offset: 0x00001921
		private void EFmaintab6_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Under Development", "STT");
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003734 File Offset: 0x00001934
		private void EFmaintab7_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.Clear_Frame();
			this.expiryDate.Visibility = Visibility.Visible;
			this.expiryDate.Items.Clear();
			this.expiryDate.Items.Add("Previous Month");
			this.expiryDate.Items.Add("Trailing One Month");
			this.expiryDateCb.Visibility = Visibility.Collapsed;
			base.Dispatcher.BeginInvoke(new Action(delegate()
			{
				MessageBox.Show("For GannStudy Time, you need to load data again!", "Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}), DispatcherPriority.ApplicationIdle, Array.Empty<object>());
			this.expiryDateCb.Visibility = Visibility.Collapsed;
			this.expiryDate.Visibility = Visibility.Visible;
			this.subtab1.Visibility = Visibility.Collapsed;
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
			this.subtab4.Visibility = Visibility.Collapsed;
			this.subtab5.Visibility = Visibility.Collapsed;
			this.subtab6.Visibility = Visibility.Collapsed;
			this.subtab7.Visibility = Visibility.Collapsed;
			this.subtab8.Visibility = Visibility.Collapsed;
			this.subtab9.Visibility = Visibility.Collapsed;
			this.subtab10.Visibility = Visibility.Collapsed;
			this.subtab11.Visibility = Visibility.Collapsed;
			this.subtabscan.Visibility = Visibility.Collapsed;
			this.subtab12.Visibility = Visibility.Collapsed;
			this.subtab13.Visibility = Visibility.Collapsed;
			this.subtab14.Visibility = Visibility.Collapsed;
			this.subtabOHLC.Visibility = Visibility.Collapsed;
			this.subtabDrift.Visibility = Visibility.Collapsed;
			this.subtab15.Visibility = Visibility.Collapsed;
			this.subtab16.Visibility = Visibility.Collapsed;
			this.subtab17.Visibility = Visibility.Collapsed;
			this.subtab18.Visibility = Visibility.Collapsed;
			this.subtab19.Visibility = Visibility.Collapsed;
			this.subtab20.Visibility = Visibility.Collapsed;
			this.subtab21.Visibility = Visibility.Collapsed;
			this.subtab22.Visibility = Visibility.Collapsed;
			this.subtab23.Visibility = Visibility.Collapsed;
			this.subtab24.Visibility = Visibility.Collapsed;
			this.subtab25.Visibility = Visibility.Collapsed;
			this.subtab26.Visibility = Visibility.Collapsed;
			this.subtab27.Visibility = Visibility.Collapsed;
			this.subtab28.Visibility = Visibility.Collapsed;
			this.subtab29.Visibility = Visibility.Collapsed;
			this.subtab30.Visibility = Visibility.Collapsed;
			this.subtab31.Visibility = Visibility.Collapsed;
			this.subtab32.Visibility = Visibility.Collapsed;
			this.subtab33.Visibility = Visibility.Collapsed;
			this.subtabnif.Visibility = Visibility.Collapsed;
			this.subtab34.Visibility = Visibility.Visible;
			this.subtab35.Visibility = Visibility.Visible;
			this.subtab36.Visibility = Visibility.Visible;
			this.subtab37.Visibility = Visibility.Visible;
			this.subtab38.Visibility = Visibility.Visible;
			this.subtab39.Visibility = Visibility.Visible;
			this.subtab40.Visibility = Visibility.Visible;
			this.subtab41.Visibility = Visibility.Visible;
			this.subtab42.Visibility = Visibility.Visible;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003A0C File Offset: 0x00001C0C
		private void EFmaintab8_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Under Development", "STT");
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003A1E File Offset: 0x00001C1E
		private void EFmaintab9_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Under Development", "STT");
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003A30 File Offset: 0x00001C30
		private void EFmaintab10_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Under Development", "STT");
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003A42 File Offset: 0x00001C42
		private void EFmaintab11_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Under Development", "STT");
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003A54 File Offset: 0x00001C54
		private void Pivot_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.AvrFrame1.Content = this.pivotpoint;
				this.AvrFrame1.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003A8D File Offset: 0x00001C8D
		private void Camrila_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.AvrFrame2.Content = this.camarila;
				this.AvrFrame2.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003AC6 File Offset: 0x00001CC6
		private void GAV_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame1.Content = this.gav;
				this.EqFrame1.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003AFF File Offset: 0x00001CFF
		private void NC_Trend_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame2.Content = this.nC_Trend;
				this.EqFrame2.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003B38 File Offset: 0x00001D38
		private void Gann_Vib_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal != 1)
			{
				MessageBox.Show("Please Calculate the Data", "STT");
				return;
			}
			if (Equtiy_Future.selectedInstrument == "EQUITY" || Equtiy_Future.selectedInstrument == null)
			{
				MessageBox.Show("Gann Vibration is only for Stock and Index", "STT");
				return;
			}
			this.EqFrame3.Content = this.gann_Vib;
			this.EqFrame3.Visibility = Visibility.Visible;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003BA8 File Offset: 0x00001DA8
		private void Intraday_Vib_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal != 1)
			{
				MessageBox.Show("Please Calculate the Data", "STT");
				return;
			}
			if (Equtiy_Future.selectedInstrument == "EQUITY" || Equtiy_Future.selectedInstrument == null)
			{
				MessageBox.Show("Intraday Vibration is only for Stock and Index", "STT");
				return;
			}
			this.EqFrame4.Content = this.intraday_Vib;
			this.EqFrame4.Visibility = Visibility.Visible;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003C15 File Offset: 0x00001E15
		private void Gann9_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame5.Content = this.gann9;
				this.EqFrame5.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003C4E File Offset: 0x00001E4E
		private void Gann12_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame6.Content = this.gann12;
				this.EqFrame6.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003C87 File Offset: 0x00001E87
		private void IntradayTetra_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame8.Content = this.intraday_Tetra;
				this.EqFrame8.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003CC0 File Offset: 0x00001EC0
		private void GannHex_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame7.Content = this.gann_Hexagonal;
				this.EqFrame7.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003CF9 File Offset: 0x00001EF9
		private void Gann_Price_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.EqFrame9.Content = this.gann_Price;
				this.EqFrame9.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003D34 File Offset: 0x00001F34
		private void Summary_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				try
				{
					this.summary = new E_F_summary(Equtiy_Future.LIVE_DATA.ltp, this.gav, this.nC_Trend, this.gann9, this.gann12, this.gann_Hexagonal, this.intraday_Tetra, this.gann_Price);
					this.EqFrame10.Content = this.summary;
					this.EqFrame10.Visibility = Visibility.Visible;
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003DD8 File Offset: 0x00001FD8
		private void FiboRetrace_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.FiboFrame1.Content = this.retracement;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003E05 File Offset: 0x00002005
		private void FiboParallel_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.FiboFrame2.Content = this.projection;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003E32 File Offset: 0x00002032
		private void Elliot_Impulsive_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.ElliotFrame1.Content = this.impelsive_And_Correction;
				this.ElliotFrame1.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003E6B File Offset: 0x0000206B
		private void Elliot_Corrective_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.ElliotFrame2.Content = this.corrective;
				this.ElliotFrame2.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003EA4 File Offset: 0x000020A4
		private void cbINSTRUMENT_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedInstrument = this.instrumentCb.SelectedItem.ToString();
			this.expiryDateCb.Visibility = Visibility.Collapsed;
			this.expLabel.Visibility = Visibility.Collapsed;
			this.expiryDateCb.IsEnabled = false;
			if (selectedInstrument == "STOCK FUTURE")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
				this.expLabel.Visibility = Visibility.Visible;
				this.expiryDateCb.IsEnabled = true;
				string[] symbols = this.LoadSymbols(this.STOCKFUTUREPATH);
				int midpoint = (symbols.Length + 1) / 2;
				string[] firstHalf = new string[midpoint];
				string[] secondHalf = new string[symbols.Length - midpoint];
				Array.Copy(symbols, 0, firstHalf, 0, firstHalf.Length);
				Array.Copy(symbols, midpoint, secondHalf, 0, secondHalf.Length);
				if (this.checkDate())
				{
					symbols = firstHalf;
				}
				else
				{
					symbols = secondHalf;
				}
				this.symbolAutoBox.Items.Clear();
				foreach (string symbol in symbols)
				{
					this.symbolAutoBox.Items.Add(symbol);
				}
				string[] array2 = this.LoadExpiryDates(Equtiy_Future.EXPIRYURLNIFTY);
				this.expiryDateCb.Items.Clear();
				foreach (string symbol2 in array2)
				{
					this.expiryDateCb.Items.Add(symbol2);
				}
				return;
			}
			if (selectedInstrument == "INDEX FUTURE")
			{
				this.expiryDateCb.Visibility = Visibility.Visible;
				this.expLabel.Visibility = Visibility.Visible;
				this.expiryDateCb.IsEnabled = true;
				string[] symbols2 = this.LoadSymbols(this.INDEXPATH);
				if (this.checkDate())
				{
					string[] removedIndex0 = new string[symbols2.Length - 1];
					Array.Copy(symbols2, 0, removedIndex0, 0, 1);
					symbols2 = removedIndex0;
				}
				else
				{
					string[] removedIndex = new string[symbols2.Length - 1];
					Array.Copy(symbols2, 1, removedIndex, 0, symbols2.Length - 1);
					symbols2 = removedIndex;
				}
				this.symbolAutoBox.Items.Clear();
				foreach (string symbol3 in symbols2)
				{
					this.symbolAutoBox.Items.Add(symbol3);
				}
				this.symbolAutoBox.SelectionChanged += delegate(object sender, SelectionChangedEventArgs args)
				{
					object selectedItem = this.symbolAutoBox.SelectedItem;
					string selectedSymbol = (selectedItem != null) ? selectedItem.ToString() : null;
					if (selectedSymbol != null)
					{
						if (selectedSymbol == "NIFTY")
						{
							this.expiryDateCb.Items.Clear();
							string[] array4 = this.LoadExpiryDates(Equtiy_Future.EXPIRYURLNIFTY);
							this.expiryDateCb.Items.Clear();
							foreach (string symbol5 in array4)
							{
								this.expiryDateCb.Items.Add(symbol5);
							}
							return;
						}
						if (selectedSymbol == "BANKNIFTY")
						{
							this.expiryDateCb.Items.Clear();
							string[] array6 = this.LoadExpiryDates(this.EXPIRYURLBANKNIFTY);
							this.expiryDateCb.Items.Clear();
							foreach (string symbol6 in array6)
							{
								this.expiryDateCb.Items.Add(symbol6);
							}
							return;
						}
						this.expiryDateCb.Items.Clear();
						string[] array7 = this.LoadExpiryDates(Equtiy_Future.EXPIRYURLNIFTY);
						this.expiryDateCb.Items.Clear();
						foreach (string symbol7 in array7)
						{
							this.expiryDateCb.Items.Add(symbol7);
						}
					}
				};
				return;
			}
			if (selectedInstrument == "EQUITY")
			{
				string[] array3 = this.LoadSymbols(this.EQUITYPATH);
				this.symbolAutoBox.Items.Clear();
				foreach (string symbol4 in array3)
				{
					this.symbolAutoBox.Items.Add(symbol4);
				}
				this.expiryDateCb.IsEnabled = false;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000413E File Offset: 0x0000233E
		private void IntradayRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			this.PositionalTextBox.Visibility = Visibility.Collapsed;
			this.PositionalLabel.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004158 File Offset: 0x00002358
		private void PositionalRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			this.PositionalTextBox.Visibility = Visibility.Visible;
			this.PositionalLabel.Visibility = Visibility.Visible;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004172 File Offset: 0x00002372
		private string[] LoadSymbols(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004187 File Offset: 0x00002387
		public string[] LoadExpiryDates(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000419C File Offset: 0x0000239C
		private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !Equtiy_Future.IsTextNumeric(e.Text);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000041B4 File Offset: 0x000023B4
		private void NumericTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(typeof(string)))
			{
				if (!Equtiy_Future.IsTextNumeric((string)e.DataObject.GetData(typeof(string))))
				{
					e.CancelCommand();
					return;
				}
			}
			else
			{
				e.CancelCommand();
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004206 File Offset: 0x00002406
		private static bool IsTextNumeric(string text)
		{
			return !new Regex("[^0-9]+").IsMatch(text);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000421C File Offset: 0x0000241C
		private void VolatalitySummary_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				try
				{
					this.VolSumary = new Volatality_Sumary(Equtiy_Future.LIVE_DATA.ltp, this.oneSD, this.volatalityScanner, this.volatalityLN, this.volatalityOHLC, this.volatalityDrift);
					this.VolFrame_Sum.Content = this.VolSumary;
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}
			MessageBox.Show("Please Calculate the Data", "STT");
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000042A8 File Offset: 0x000024A8
		private void Volatality_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame1.Content = this.volatalityScanner;
				this.VolFrame1.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000042DC File Offset: 0x000024DC
		private void OneSD_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame2.Content = this.oneSD;
				this.VolFrame2.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004310 File Offset: 0x00002510
		private void IntradayTopBottom_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame3.Content = this.intradayTopBottom;
				this.VolFrame3.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004344 File Offset: 0x00002544
		private void NiftyTopBottom_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame4.Content = this.niftyTopBottom;
				this.VolFrame4.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004378 File Offset: 0x00002578
		private void VolatalityOHLC_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame6.Content = this.volatalityOHLC;
				this.VolFrame6.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000043AC File Offset: 0x000025AC
		private void VolatalityLN_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame5.Content = this.volatalityLN;
				this.VolFrame5.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000043E0 File Offset: 0x000025E0
		private void VolatalityDrift_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.VolFrame7.Content = this.volatalityDrift;
				this.VolFrame7.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004414 File Offset: 0x00002614
		private void VolatalityScanner_Tabclick(object sender, MouseButtonEventArgs e)
		{
			this.VolFrame8.Content = this.Scanner;
			this.VolFrame8.Visibility = Visibility.Visible;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004433 File Offset: 0x00002633
		private void GannLow_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame1.Content = this.lowAngle;
				this.TimeFrame1.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004467 File Offset: 0x00002667
		private void GannHigh_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame2.Content = this.highAngle;
				this.TimeFrame2.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000449B File Offset: 0x0000269B
		private void GannStatic_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame3.Content = this.staticAngle;
				this.TimeFrame3.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000044CF File Offset: 0x000026CF
		private void GannAngle_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame4.Content = this.gannAngle;
				this.TimeFrame4.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004503 File Offset: 0x00002703
		private void HighLow_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame5.Content = this.HLSquaring;
				this.TimeFrame5.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004537 File Offset: 0x00002737
		private void Hexagon_Tabclick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame6.Content = this.HexaAngle;
				this.TimeFrame6.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000456B File Offset: 0x0000276B
		private void PriceTime_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame7.Content = this.pricetime;
				this.TimeFrame7.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000459F File Offset: 0x0000279F
		private void PriceRange_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame8.Content = this.pricerange;
				this.TimeFrame8.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000045D3 File Offset: 0x000027D3
		private void GannSummary_TabClick(object sender, MouseButtonEventArgs e)
		{
			if (this.Cal == 1)
			{
				this.TimeFrame9.Content = this.Gannsummary;
				this.TimeFrame9.Visibility = Visibility.Visible;
				return;
			}
			MessageBox.Show("Please Calculate the Data");
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004608 File Offset: 0x00002808
		private void GannHexCal()
		{
			bool? isChecked = this.PositionalRadioButton.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				Equtiy_Future.Items = "Positional";
				Equtiy_Future.NoOfHoldDays = int.Parse(this.PositionalTextBox.Text);
				Equtiy_Future.CF = 1.0;
				Equtiy_Future.seed = Equtiy_Future.LIVE_DATA.ltp;
				Equtiy_Future.volatality = this.get_Volatility(Equtiy_Future.LTP_MONTH) / 100.0 / Math.Sqrt(365.0);
				Equtiy_Future.step = Equtiy_Future.volatality * Equtiy_Future.seed * Math.Sqrt((double)Equtiy_Future.NoOfHoldDays) / 81.0;
				return;
			}
			Equtiy_Future.Items = "Intraday";
			Equtiy_Future.NoOfHoldDays = 0;
			Equtiy_Future.CF = 1.0;
			double ltp = Equtiy_Future.LIVE_DATA.ltp;
			Equtiy_Future.volatality = this.get_Volatility(Equtiy_Future.LTP_MONTH) / 100.0 / Math.Sqrt(365.0);
			Equtiy_Future.step = Equtiy_Future.volatality * ltp / 81.0;
			Equtiy_Future.seed = Equtiy_Future.LIVE_DATA.open;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004740 File Offset: 0x00002940
		private double get_Volatility(List<double> ltp)
		{
			double num3 = 0.0;
			double num4 = 0.0;
			int num5 = ltp.Count - 1;
			for (int i = 0; i < num5; i++)
			{
				double num8 = ltp[i + 1];
				double num9 = ltp[i];
				double num6 = Math.Log(ltp[i + 1] / ltp[i]);
				double num7 = num6 * num6;
				num3 += num6;
				num4 += num7;
			}
			return Math.Sqrt(num4 / (double)num5 - Math.Pow(num3 / (double)num5, 2.0)) * Math.Sqrt(365.0) * 100.0;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004800 File Offset: 0x00002A00
		public bool checkDate()
		{
			return DateTime.Now.Day % 2 == 0;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004820 File Offset: 0x00002A20
		private void read_fromFile(string _path)
		{
			if (File.Exists(_path))
			{
				StreamReader readerObj = File.OpenText(_path);
				this.username = readerObj.ReadLine();
				readerObj.Dispose();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004850 File Offset: 0x00002A50
		private void Clear_Frame()
		{
			this.EqFrame1.Visibility = Visibility.Collapsed;
			this.EqFrame2.Visibility = Visibility.Collapsed;
			this.EqFrame3.Visibility = Visibility.Collapsed;
			this.EqFrame4.Visibility = Visibility.Collapsed;
			this.EqFrame5.Visibility = Visibility.Collapsed;
			this.EqFrame6.Visibility = Visibility.Collapsed;
			this.EqFrame7.Visibility = Visibility.Collapsed;
			this.EqFrame8.Visibility = Visibility.Collapsed;
			this.EqFrame9.Visibility = Visibility.Collapsed;
			this.EqFrame10.Visibility = Visibility.Collapsed;
			this.VolFrame1.Visibility = Visibility.Collapsed;
			this.VolFrame2.Visibility = Visibility.Collapsed;
			this.VolFrame3.Visibility = Visibility.Collapsed;
			this.VolFrame4.Visibility = Visibility.Collapsed;
			this.VolFrame5.Visibility = Visibility.Collapsed;
			this.VolFrame6.Visibility = Visibility.Collapsed;
			this.VolFrame7.Visibility = Visibility.Collapsed;
			this.TimeFrame1.Visibility = Visibility.Collapsed;
			this.TimeFrame2.Visibility = Visibility.Collapsed;
			this.TimeFrame3.Visibility = Visibility.Collapsed;
			this.TimeFrame4.Visibility = Visibility.Collapsed;
			this.TimeFrame5.Visibility = Visibility.Collapsed;
			this.TimeFrame6.Visibility = Visibility.Collapsed;
			this.TimeFrame7.Visibility = Visibility.Collapsed;
			this.TimeFrame8.Visibility = Visibility.Collapsed;
			this.ElliotFrame1.Visibility = Visibility.Collapsed;
			this.ElliotFrame2.Visibility = Visibility.Collapsed;
			this.AvrFrame1.Visibility = Visibility.Collapsed;
			this.AvrFrame2.Visibility = Visibility.Collapsed;
		}

		// Token: 0x0400000C RID: 12
		public static string EXPIRYURLNIFTY = "https://smartfinance.in/workweb/links/ExpiryURLNifty.txt";

		// Token: 0x0400000D RID: 13
		private readonly string EXPIRYURLBANKNIFTY = "https://smartfinance.in/workweb/links/ExpiryURLBanknifty.txt";

		// Token: 0x0400000E RID: 14
		private readonly string EQUITYPATH = "https://smartfinance.in/symbols/EQ.txt";

		// Token: 0x0400000F RID: 15
		private readonly string STOCKFUTUREPATH = "https://smartfinance.in/symbols/STK.txt";

		// Token: 0x04000010 RID: 16
		private readonly string INDEXPATH = "https://smartfinance.in/symbols/IDX.txt";

		// Token: 0x04000011 RID: 17
		private string username;

		// Token: 0x04000012 RID: 18
		public static LiveMarketQuoteDataCls LIVE_DATA;

		// Token: 0x04000013 RID: 19
		public static List<double> LTP_MONTH;

		// Token: 0x04000014 RID: 20
		public static DataTable OPTIONCHAIN_TABLE;

		// Token: 0x04000015 RID: 21
		public static int NoOfHoldDays;

		// Token: 0x04000016 RID: 22
		public static string selectedTime;

		// Token: 0x04000017 RID: 23
		public static string selectedSymbol;

		// Token: 0x04000018 RID: 24
		public static string selectedInstrument;

		// Token: 0x04000019 RID: 25
		public static string selectedExpiry;

		// Token: 0x0400001A RID: 26
		internal static List<string> neutralCount;

		// Token: 0x0400001B RID: 27
		internal static List<string> buyCount;

		// Token: 0x0400001C RID: 28
		internal static List<string> sellCount;

		// Token: 0x0400001D RID: 29
		internal static bool dataLoaded = false;

		// Token: 0x0400001E RID: 30
		public static string gannTimeFutureDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeFutureDataDownload.php?symbol={0}";

		// Token: 0x0400001F RID: 31
		public static string gannTimeIndexDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeIndexDataDownload.php?symbol={0}";

		// Token: 0x04000020 RID: 32
		private string loadRawUrl = Equtiy_Future.baseSmartFinanceInfo + "/load_click.php?username={0}";

		// Token: 0x04000021 RID: 33
		public static string baseSmartFinanceInfo = "https://smartfinance.in/stt_software/desktop_trail";

		// Token: 0x04000022 RID: 34
		private string updateLoadUrl = Equtiy_Future.baseSmartFinanceInfo + "/update_load_click.php?username={0}&load_click={1}";

		// Token: 0x04000023 RID: 35
		private string loadURL;

		// Token: 0x04000024 RID: 36
		private string load_clickURL;

		// Token: 0x04000025 RID: 37
		private int loadValue;

		// Token: 0x04000026 RID: 38
		private DispatcherTimer timer;

		// Token: 0x04000027 RID: 39
		private int progressValue;

		// Token: 0x0400002A RID: 42
		public static double seed;

		// Token: 0x0400002B RID: 43
		public static double step;

		// Token: 0x0400002C RID: 44
		public static double volatality;

		// Token: 0x0400002D RID: 45
		public static double CF;

		// Token: 0x0400002E RID: 46
		public static string Items;

		// Token: 0x0400002F RID: 47
		public int Cal;

		// Token: 0x04000030 RID: 48
		private string _profilePATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\stt_trail_software.txt";

		// Token: 0x04000031 RID: 49
		private support sup = new support();

		// Token: 0x04000032 RID: 50
		private GAV gav;

		// Token: 0x04000033 RID: 51
		private NC_Trend nC_Trend;

		// Token: 0x04000034 RID: 52
		private Gann_Vib gann_Vib;

		// Token: 0x04000035 RID: 53
		private Intraday_Vib intraday_Vib;

		// Token: 0x04000036 RID: 54
		private Gann9 gann9;

		// Token: 0x04000037 RID: 55
		private GannHexChart gannHexChart;

		// Token: 0x04000038 RID: 56
		private Gann_Hexagonal gann_Hexagonal;

		// Token: 0x04000039 RID: 57
		private Intraday_Tetra intraday_Tetra;

		// Token: 0x0400003A RID: 58
		private Gann12 gann12;

		// Token: 0x0400003B RID: 59
		private Gann_Price gann_Price;

		// Token: 0x0400003C RID: 60
		private E_F_summary summary;

		// Token: 0x0400003D RID: 61
		private OneSD oneSD;

		// Token: 0x0400003E RID: 62
		private Volatality_Scanner volatalityScanner;

		// Token: 0x0400003F RID: 63
		private Intraday_TopBottom intradayTopBottom;

		// Token: 0x04000040 RID: 64
		private Nifty_TopBottom niftyTopBottom;

		// Token: 0x04000041 RID: 65
		private Volatality_OHLC volatalityOHLC;

		// Token: 0x04000042 RID: 66
		private Volatality_LN volatalityLN;

		// Token: 0x04000043 RID: 67
		private Volatality_Drift volatalityDrift;

		// Token: 0x04000044 RID: 68
		private volatilityStockScanner Scanner;

		// Token: 0x04000045 RID: 69
		private Volatality_Sumary VolSumary;

		// Token: 0x04000046 RID: 70
		public static double High;

		// Token: 0x04000047 RID: 71
		public static double Low;

		// Token: 0x04000048 RID: 72
		public static double seed1Value;

		// Token: 0x04000049 RID: 73
		public static double seed1Value_GS9;

		// Token: 0x0400004A RID: 74
		public static double seed1Value_mGS9;

		// Token: 0x0400004B RID: 75
		public static double seed1Value_GS12;

		// Token: 0x0400004C RID: 76
		public static double seed1Value_mGS12;

		// Token: 0x0400004D RID: 77
		public static double Gannstep;

		// Token: 0x0400004E RID: 78
		public static int tradingDays;

		// Token: 0x0400004F RID: 79
		public static int calenderDays;

		// Token: 0x04000050 RID: 80
		public static string HighFormationDate;

		// Token: 0x04000051 RID: 81
		public static string LowFormationDate;

		// Token: 0x04000052 RID: 82
		public static List<string> monthlyDaysList = new List<string>();

		// Token: 0x04000053 RID: 83
		private Gann_LowAngle lowAngle;

		// Token: 0x04000054 RID: 84
		private Gann_HighAngle highAngle;

		// Token: 0x04000055 RID: 85
		private Gann_StaticAngle staticAngle;

		// Token: 0x04000056 RID: 86
		private Gann_GannAngle gannAngle;

		// Token: 0x04000057 RID: 87
		private Gann_HLSquaring HLSquaring;

		// Token: 0x04000058 RID: 88
		private Gann_HexagonAngle HexaAngle;

		// Token: 0x04000059 RID: 89
		private Gann_PriceTime pricetime;

		// Token: 0x0400005A RID: 90
		private Gann_PriceRange pricerange;

		// Token: 0x0400005B RID: 91
		private Gann_Summary Gannsummary;

		// Token: 0x0400005C RID: 92
		private Impelsive_and_Correction impelsive_And_Correction;

		// Token: 0x0400005D RID: 93
		private Corrective corrective;

		// Token: 0x0400005E RID: 94
		private Camarila camarila;

		// Token: 0x0400005F RID: 95
		private Pivotpoint pivotpoint;

		// Token: 0x04000060 RID: 96
		private ParallelProjection projection;

		// Token: 0x04000061 RID: 97
		private Retracement retracement;
	}
}
