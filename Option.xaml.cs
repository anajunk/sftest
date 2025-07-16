using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using FnOHelper;
using HtmlAgilityPack;
using ltp10Days;
using New_SF_IT.OptionMonth;
using SFHelper;
using siteDownLoadHelper;

namespace New_SF_IT
{
	// Token: 0x02000014 RID: 20
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Option : UserControl
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000836F File Offset: 0x0000656F
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00008376 File Offset: 0x00006576
		public static double PrevHigh { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000837E File Offset: 0x0000657E
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00008385 File Offset: 0x00006585
		public static double PrevLow { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000838D File Offset: 0x0000658D
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00008394 File Offset: 0x00006594
		public static Dictionary<string, string> callStrike { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000839C File Offset: 0x0000659C
		// (set) Token: 0x060000DA RID: 218 RVA: 0x000083A3 File Offset: 0x000065A3
		public static Dictionary<string, string> putStrike { get; set; }

		// Token: 0x060000DB RID: 219 RVA: 0x000083AC File Offset: 0x000065AC
		public Option()
		{
			this.curTab = MainWindow.currentTab;
			this.optInt = new optionIntraday(this);
			this.optPos = new optionPositional(this);
			this.InitializeComponent();
			this.read_fromFile(this._profilePATH);
			if (this.curTab == "OPT")
			{
				this.instrumentCb.Items.Add("STOCK FUTURE");
				this.instrumentCb.Items.Add("INDEX FUTURE");
			}
			else
			{
				this.instrumentCb.Items.Add("INDEX FUTURE");
			}
			base.Loaded += this.Option_Loaded;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000084CC File Offset: 0x000066CC
		private void Option_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.curTab == "OPT")
			{
				this.EXPIRYURLNIFTY = "https://smartfinance.in/expiry/ExpiryURLNifty.txt";
				this.EXPIRYURLBANKNIFTY = "https://smartfinance.in/expiry/ExpiryURLBanknifty.txt";
				this.subtab2.Visibility = Visibility.Visible;
				this.subtab3.Visibility = Visibility.Visible;
				return;
			}
			this.EXPIRYURLNIFTY = "https://smartfinance.in/expiry/nifty_stk_week.txt";
			this.EXPIRYURLBANKNIFTY = "https://smartfinance.in/expiry/banknifty_week.txt";
			this.subtab2.Visibility = Visibility.Collapsed;
			this.subtab3.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00008548 File Offset: 0x00006748
		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Option.<btnLoad_Click>d__50 <btnLoad_Click>d__;
			<btnLoad_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<btnLoad_Click>d__.<>4__this = this;
			<btnLoad_Click>d__.<>1__state = -1;
			<btnLoad_Click>d__.<>t__builder.Start<Option.<btnLoad_Click>d__50>(ref <btnLoad_Click>d__);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00008580 File Offset: 0x00006780
		private static void ChangeExp()
		{
			using (HttpClient client = new HttpClient())
			{
				string url;
				if (Option.selectedSymbol == "BANKNIFTY")
				{
					url = "https://smartfinance.in/expiry/ExpiryURLBanknifty.txt";
				}
				else if (Option.selectedSymbol == "FINNIFTY")
				{
					url = "https://smartfinance.in/expiry/ExpiryURLNifty.txt";
				}
				else
				{
					url = "https://smartfinance.in/expiry/ExpiryURLNifty.txt";
				}
				HttpResponseMessage response = client.GetAsync(url).Result;
				if (response.IsSuccessStatusCode)
				{
					Option.selectedExpiry = Option.FindMatchingDate(response.Content.ReadAsStringAsync().Result.Split(new string[]
					{
						"\r\n",
						"\r",
						"\n"
					}, StringSplitOptions.RemoveEmptyEntries), Option.selectedExpiry);
					Option.selectedSymbol.Replace("&", "%26");
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00008654 File Offset: 0x00006854
		private static string FindMatchingDate(string[] dateList, string inputDate)
		{
			string inputMonth = inputDate.Substring(2, 3);
			return dateList.FirstOrDefault((string date) => date.Substring(2, 3) == inputMonth);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00008688 File Offset: 0x00006888
		private void btnCalculate_Click(object sender, RoutedEventArgs e)
		{
			this.optInt.Initialize_Variable();
			this.optInt.CalCulate();
			Option.strikeChoosen = Convert.ToInt32(Convert.ToDouble(this.listBxStrike.SelectedItem));
			Option.premiumOfStrike = Convert.ToDouble(this.txtbxOptionPremium.Text);
			Option.strikeIndex = this.listBxStrike.SelectedIndex;
			this.optArbit = new optionArbitrage();
			this.optFrame1.Content = this.optInt;
			Option.binomialLock = true;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008710 File Offset: 0x00006910
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
				string[] array2 = this.LoadExpiryDates(this.EXPIRYURLNIFTY);
				this.expiryDateCb.Items.Clear();
				foreach (string date in array2)
				{
					this.expiryDateCb.Items.Add(date);
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
				foreach (string symbol2 in symbols2)
				{
					this.symbolAutoBox.Items.Add(symbol2);
				}
				this.symbolAutoBox.SelectionChanged += delegate(object s, SelectionChangedEventArgs args)
				{
					object selectedItem = this.symbolAutoBox.SelectedItem;
					string selectedSymbol = (selectedItem != null) ? selectedItem.ToString() : null;
					if (selectedSymbol != null)
					{
						this.expiryDateCb.Items.Clear();
						string[] expiryDates;
						if (selectedSymbol == "NIFTY")
						{
							expiryDates = this.LoadExpiryDates(this.EXPIRYURLNIFTY);
						}
						else if (selectedSymbol == "BANKNIFTY")
						{
							expiryDates = this.LoadExpiryDates(this.EXPIRYURLBANKNIFTY);
						}
						else
						{
							expiryDates = this.LoadExpiryDates(this.EXPIRYURLNIFTY);
						}
						this.expiryDateCb.Items.Clear();
						foreach (string date2 in expiryDates)
						{
							this.expiryDateCb.Items.Add(date2);
						}
					}
				};
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00008948 File Offset: 0x00006B48
		public bool checkDate()
		{
			return DateTime.Now.Day % 2 == 0;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00008968 File Offset: 0x00006B68
		private void rBtnCall_Checked(object sender, RoutedEventArgs e)
		{
			this.rBtnCall.FontWeight = FontWeights.Bold;
			this.rBtnPut.FontWeight = FontWeights.Normal;
			Option.btnCall = true;
			Option.btnPut = false;
			if (Option.callStrike != null)
			{
				this.listBxStrike.ItemsSource = null;
				this.listBxStrike.Items.Clear();
				this.listBxStrike.ItemsSource = Option.callStrike.Keys;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000089DC File Offset: 0x00006BDC
		private void rBtnPut_Checked(object sender, RoutedEventArgs e)
		{
			this.rBtnPut.FontWeight = FontWeights.Bold;
			this.rBtnCall.FontWeight = FontWeights.Normal;
			Option.btnCall = false;
			Option.btnPut = true;
			if (Option.putStrike != null)
			{
				this.listBxStrike.ItemsSource = null;
				this.listBxStrike.Items.Clear();
				this.listBxStrike.ItemsSource = Option.putStrike.Keys;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00008A50 File Offset: 0x00006C50
		private void read_fromFile(string _path)
		{
			if (File.Exists(_path))
			{
				StreamReader readerObj = File.OpenText(_path);
				this.username = readerObj.ReadLine();
				readerObj.Dispose();
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00008A80 File Offset: 0x00006C80
		private void listBxStrike_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.listBxStrike.ItemsSource != null)
			{
				string selectedStrike = this.listBxStrike.SelectedItem.ToString();
				bool? isChecked = this.rBtnCall.IsChecked;
				bool flag = true;
				if ((isChecked.GetValueOrDefault() == flag & isChecked != null) && Option.callStrike.ContainsKey(selectedStrike))
				{
					this.txtbxOptionPremium.Text = Option.callStrike[selectedStrike];
				}
				isChecked = this.rBtnPut.IsChecked;
				flag = true;
				if ((isChecked.GetValueOrDefault() == flag & isChecked != null) && Option.putStrike.ContainsKey(selectedStrike))
				{
					this.txtbxOptionPremium.Text = Option.putStrike[selectedStrike];
				}
			}
			Option.binomialLock = false;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00008B40 File Offset: 0x00006D40
		public static double gannAngle_High_AND_Low(string _symbol, string url, string variable)
		{
			double getData = 0.0;
			if (Option.IsInternetAvailable())
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

		// Token: 0x060000E8 RID: 232 RVA: 0x00008C4F File Offset: 0x00006E4F
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00008C5B File Offset: 0x00006E5B
		private void optInt_Tabclick(object sender, MouseButtonEventArgs e)
		{
			this.optFrame1.Content = this.optInt;
			this.btncalborder.Visibility = Visibility.Visible;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00008C7A File Offset: 0x00006E7A
		private void optPos_Tabclick(object sender, MouseButtonEventArgs e)
		{
			this.optFrame2.Content = this.optPos;
			this.btncalborder.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00008C99 File Offset: 0x00006E99
		private void OptArbit_Tabclick(object sender, MouseButtonEventArgs e)
		{
			this.optFrame3.Content = this.optArbit;
			this.btncalborder.Visibility = Visibility.Visible;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008CB8 File Offset: 0x00006EB8
		private void OptBino_TabClick(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00008CBA File Offset: 0x00006EBA
		private void btnSummary_Click(object sender, RoutedEventArgs e)
		{
			this.btncalborder.Visibility = Visibility.Visible;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00008CC8 File Offset: 0x00006EC8
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

		// Token: 0x060000EF RID: 239 RVA: 0x00008D4C File Offset: 0x00006F4C
		private LiveMarketQuoteDataCls getLiveData()
		{
			LiveMarketQuoteCls liveMarketQuoteCls = new LiveMarketQuoteCls();
			string _selectedSymbolForLiveData = Option.selectedSymbol.Replace("&", "%26");
			return liveMarketQuoteCls.get_Quote(Option.selectedInstrument, _selectedSymbolForLiveData, Option.selectedExpiry);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008D84 File Offset: 0x00006F84
		private List<double> get_historicalData()
		{
			List<double> tenDaysLTP = new ltp10dayscls().get_10DaysLTP(Option.selectedInstrument, Option.selectedSymbol, Option.selectedExpiry, "1month");
			if (tenDaysLTP != null)
			{
				return tenDaysLTP;
			}
			return null;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008DB6 File Offset: 0x00006FB6
		private string[] LoadExpiryDates(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008DCB File Offset: 0x00006FCB
		private string[] LoadSymbols(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008DE0 File Offset: 0x00006FE0
		private void expiryDateCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.expiryDateCb.SelectedItem != null)
			{
				this.btnLoad.Content = "Load";
				this.btnLoad.IsEnabled = true;
				DateTime date = DateTime.Parse(this.expiryDateCb.SelectedItem.ToString()).Date;
				DateTime todays_day = DateTime.Now.Date;
				Option.DAYS_LEFT_TILL_EXPIRY = (date - todays_day).Days + 1;
			}
		}

		// Token: 0x04000118 RID: 280
		public static DataTable OPTIONCHAIN_TABLE;

		// Token: 0x04000119 RID: 281
		private readonly string STOCKFUTUREPATH = "https://smartfinance.in/symbols/STK.txt";

		// Token: 0x0400011A RID: 282
		private readonly string INDEXPATH = "https://smartfinance.in/symbols/IDX.txt";

		// Token: 0x0400011B RID: 283
		private string EXPIRYURLNIFTY = "https://smartfinance.in/workweb/links/ExpiryURLNifty.txt";

		// Token: 0x0400011C RID: 284
		private string EXPIRYURLBANKNIFTY = "https://smartfinance.in/workweb/links/ExpiryURLBanknifty.txt";

		// Token: 0x0400011D RID: 285
		public static string gannTimeFutureDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeFutureDataDownload.php?symbol={0}";

		// Token: 0x0400011E RID: 286
		public static string gannTimeIndexDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeIndexDataDownload.php?symbol={0}";

		// Token: 0x0400011F RID: 287
		public static string selectedSymbol;

		// Token: 0x04000120 RID: 288
		public static string selectedInstrument;

		// Token: 0x04000121 RID: 289
		public static string selectedExpiry;

		// Token: 0x04000124 RID: 292
		public static List<double> LTP_MONTH;

		// Token: 0x04000125 RID: 293
		public static LiveMarketQuoteDataCls LIVE_DATA;

		// Token: 0x04000128 RID: 296
		public static int DAYS_LEFT_TILL_EXPIRY;

		// Token: 0x04000129 RID: 297
		private BackgroundWorker BGWORKER;

		// Token: 0x0400012A RID: 298
		public static bool btnCall;

		// Token: 0x0400012B RID: 299
		public static bool btnPut;

		// Token: 0x0400012C RID: 300
		public static int strikeChoosen;

		// Token: 0x0400012D RID: 301
		public static double premiumOfStrike;

		// Token: 0x0400012E RID: 302
		public static int strikeIndex;

		// Token: 0x0400012F RID: 303
		private optionIntraday optInt;

		// Token: 0x04000130 RID: 304
		private optionPositional optPos;

		// Token: 0x04000131 RID: 305
		private optionArbitrage optArbit;

		// Token: 0x04000132 RID: 306
		public static bool binomialLock = true;

		// Token: 0x04000133 RID: 307
		private string curTab;

		// Token: 0x04000134 RID: 308
		private string _profilePATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\stt_trail_software.txt";

		// Token: 0x04000135 RID: 309
		private string loadRawUrl = Option.baseSmartFinanceInfo + "/load_click.php?username={0}";

		// Token: 0x04000136 RID: 310
		public static string baseSmartFinanceInfo = "https://smartfinance.in/stt_software/desktop_trail";

		// Token: 0x04000137 RID: 311
		private string updateLoadUrl = Option.baseSmartFinanceInfo + "/update_load_click.php?username={0}&load_click={1}";

		// Token: 0x04000138 RID: 312
		private string loadURL;

		// Token: 0x04000139 RID: 313
		private string load_clickURL;

		// Token: 0x0400013A RID: 314
		private int loadValue;

		// Token: 0x0400013B RID: 315
		private string username;
	}
}
