using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using New_SF_IT.classes;
using SFHelper;
using siteDownLoadHelper;

namespace New_SF_IT
{
	// Token: 0x02000015 RID: 21
	public partial class pairTrade : UserControl
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x000092BC File Offset: 0x000074BC
		public pairTrade()
		{
			this.InitializeComponent();
			this.instrument.SelectionChanged += this.instrument_SelectionChanged;
			this.instrument.SelectedIndex = 0;
			if (Comman.IsInternetAvailable())
			{
				this.loadExpiry();
				this.loadSymbols();
				this.PairTradeReport_Grid.Visibility = Visibility.Collapsed;
				return;
			}
			MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00009378 File Offset: 0x00007578
		[NullableContext(1)]
		private void instrument_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.loadSymbols();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00009380 File Offset: 0x00007580
		public void loadSymbols()
		{
			string _instrument = string.Empty;
			if (this.instrument.SelectedIndex == 0)
			{
				_instrument = "STOCK FUTURE";
			}
			else if (this.instrument.SelectedIndex == 1)
			{
				_instrument = "INDEX FUTURE";
			}
			if (!(_instrument == "STOCK FUTURE"))
			{
				if (!(_instrument == "INDEX FUTURE"))
				{
					return;
				}
				string data2 = new downloadSiteCls(new Uri(this.INDEXPATH)).getSite();
				if (data2 == null)
				{
					MessageBox.Show("Please try after sometimes", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				data2 = data2.Replace("\r", "");
				if (!string.IsNullOrWhiteSpace(data2))
				{
					this._indexSymbols = new ObservableCollection<string>(data2.Split('\n', StringSplitOptions.None).ToList<string>());
					this.scriptCode1.ItemsSource = this._indexSymbols;
					this.scriptCode1.Text = "NIFTY";
				}
				return;
			}
			else
			{
				string data3 = new downloadSiteCls(new Uri(this.STOCKFUTUREPATH)).getSite();
				if (data3 == null)
				{
					MessageBox.Show("Please try after sometimes", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				data3 = data3.Replace("\r", "");
				if (!string.IsNullOrWhiteSpace(data3))
				{
					this._stockSymbols = new ObservableCollection<string>(data3.Split('\n', StringSplitOptions.None).ToList<string>());
					this.scriptCode1.ItemsSource = this._stockSymbols;
					this.scriptCode2.ItemsSource = this._stockSymbols;
					this.scriptCode3.ItemsSource = this._stockSymbols;
				}
				this.scriptCode1.Text = "ICICIBANK";
				return;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00009500 File Offset: 0x00007700
		public void loadExpiry()
		{
			string data = new downloadSiteCls(new Uri(this.EXPIRYURL + "IDX-STKexpiry.txt")).getSite();
			if (data == null)
			{
				MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			data = data.Replace("\r", "");
			if (!string.IsNullOrWhiteSpace(data))
			{
				this._expiry = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
				this.expiry.ItemsSource = this._expiry;
				this.expiry.Text = this._expiry[0];
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000095A0 File Offset: 0x000077A0
		[NullableContext(1)]
		public void LoadData(object sender, RoutedEventArgs e)
		{
			this.loadButton.Content = "Loading...";
			string _60daysPrice_Url = string.Empty;
			string symbol = "";
			this.symbol1_liveLTP = 0.0;
			this.symbol2_liveLTP = 0.0;
			this.symbol3_liveLTP = 0.0;
			this.symbol1_underlyingPrice = 0.0;
			this.symbol2_underlyingPrice = 0.0;
			this.symbol3_underlyingPrice = 0.0;
			List<double> symbol1_60daysLTP_DB = new List<double>();
			double symbol1_priceDifference = 0.0;
			List<double> symbol2_60daysLTP_DB = new List<double>();
			double symbol2_priceDifference = 0.0;
			List<double> symbol3_60daysLTP_DB = new List<double>();
			double symbol3_priceDifference = 0.0;
			this.selectedSymbol1 = this.scriptCode1.Text;
			this.selectedSymbol2 = this.scriptCode2.Text;
			this.selectedSymbol3 = this.scriptCode3.Text;
			string selectedExpiry = this.expiry.Text;
			if (this.instrument.SelectedIndex == 0)
			{
				this.selectedInstrument = "STOCK FUTURE";
				_60daysPrice_Url = pairTrade.EQ_60daysPrice_Url;
				symbol = this._stockSymbols.FirstOrDefault((string i) => i == this.selectedSymbol1);
			}
			else if (this.instrument.SelectedIndex == 1)
			{
				this.selectedInstrument = "INDEX FUTURE";
				_60daysPrice_Url = pairTrade.IDX_60daysPrice_Url;
				symbol = this._indexSymbols.FirstOrDefault((string i) => i == this.selectedSymbol1);
			}
			if (this.selectedSymbol1.Equals(this.selectedSymbol2) || this.selectedSymbol1.Equals(this.selectedSymbol3) || this.selectedSymbol2.Equals(this.selectedSymbol3))
			{
				MessageBox.Show("Please select 3 different Symbols", "Duplicate symbol found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
			else
			{
				if (symbol == null)
				{
					MessageBox.Show(this.selectedSymbol1 + " is a wrong Script Code", "Check the Spelling", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					LiveMarketQuoteDataCls symbol1_allLivePrices = this.liveData.get_Quote(this.selectedInstrument, this.selectedSymbol1, selectedExpiry);
					if (symbol1_allLivePrices.ltp != 0.0)
					{
						this.symbol1_liveLTP = Convert.ToDouble(symbol1_allLivePrices.ltp);
						this.symbol1_underlyingPrice = Convert.ToDouble(symbol1_allLivePrices.underlyingValue);
						string _selectedSymbol = this.selectedSymbol1.Replace("&", "AND");
						symbol1_60daysLTP_DB = this.get60DaysLTP(_selectedSymbol, _60daysPrice_Url);
						symbol1_priceDifference = this.symbol1_liveLTP - this.symbol1_underlyingPrice;
					}
					else
					{
						MessageBox.Show("Live data is not available for " + this.selectedSymbol1, "Check the script code", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
				}
				if (this._stockSymbols.FirstOrDefault((string i) => i == this.selectedSymbol2) == null)
				{
					MessageBox.Show(this.selectedSymbol2 + " is a wrong Script Code", "Check the Spelling", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					LiveMarketQuoteDataCls symbol2_allLivePrices = this.liveData.get_Quote("STOCK FUTURE", this.selectedSymbol2, selectedExpiry);
					if (symbol2_allLivePrices.ltp != 0.0)
					{
						this.symbol2_liveLTP = Convert.ToDouble(symbol2_allLivePrices.ltp);
						this.symbol2_underlyingPrice = Convert.ToDouble(symbol2_allLivePrices.underlyingValue);
						string _selectedSymbol2 = this.selectedSymbol2.Replace("&", "AND");
						symbol2_60daysLTP_DB = this.get60DaysLTP(_selectedSymbol2, pairTrade.EQ_60daysPrice_Url);
						symbol2_priceDifference = this.symbol2_liveLTP - this.symbol2_underlyingPrice;
					}
					else
					{
						MessageBox.Show("Live data is not available for " + this.selectedSymbol2, "Check the script code", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
				}
				if (this._stockSymbols.FirstOrDefault((string i) => i == this.selectedSymbol3) == null)
				{
					MessageBox.Show(this.selectedSymbol3 + " is a wrong Script Code", "Check the Spelling", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					LiveMarketQuoteDataCls symbol3_allLivePrices = this.liveData.get_Quote("STOCK FUTURE", this.selectedSymbol3, selectedExpiry);
					if (symbol3_allLivePrices.ltp != 0.0)
					{
						this.symbol3_liveLTP = Convert.ToDouble(symbol3_allLivePrices.ltp);
						this.symbol3_underlyingPrice = Convert.ToDouble(symbol3_allLivePrices.underlyingValue);
						string _selectedSymbol3 = this.selectedSymbol3.Replace("&", "AND");
						symbol3_60daysLTP_DB = this.get60DaysLTP(_selectedSymbol3, pairTrade.EQ_60daysPrice_Url);
						symbol3_priceDifference = this.symbol3_liveLTP - this.symbol3_underlyingPrice;
					}
					else
					{
						MessageBox.Show("Live data is not available for " + this.selectedSymbol3, "Check the script code", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
				}
				bool flag = !symbol1_60daysLTP_DB.Any<double>();
				bool isSymbol2_60daysData_Empty = !symbol2_60daysLTP_DB.Any<double>();
				bool isSymbol3_60daysData_Empty = !symbol3_60daysLTP_DB.Any<double>();
				if (flag || isSymbol2_60daysData_Empty || isSymbol3_60daysData_Empty)
				{
					MessageBox.Show("Please wait for few minutes, then try to Load", "Pair Trade data is not available", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					List<double> symbol1_60daysPriceANDdifferecePrice = new List<double>();
					List<double> symbol2_60daysPriceANDdifferecePrice = new List<double>();
					List<double> symbol3_60daysPriceANDdifferecePrice = new List<double>();
					symbol1_60daysPriceANDdifferecePrice = this.addDifferencePricewithDBprice(symbol1_60daysLTP_DB, symbol1_priceDifference);
					symbol2_60daysPriceANDdifferecePrice = this.addDifferencePricewithDBprice(symbol2_60daysLTP_DB, symbol2_priceDifference);
					symbol3_60daysPriceANDdifferecePrice = this.addDifferencePricewithDBprice(symbol3_60daysLTP_DB, symbol3_priceDifference);
					MessageBox.Show("Data is loaded successfully", "Pair Trade data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					this.pairTrade_Calc(symbol1_60daysPriceANDdifferecePrice, symbol2_60daysPriceANDdifferecePrice, symbol3_60daysPriceANDdifferecePrice);
					this.PairTradeReport_Grid.Visibility = Visibility.Visible;
				}
			}
			this.loadButton.Content = "Load & Analyse";
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00009A90 File Offset: 0x00007C90
		[NullableContext(1)]
		public void pairTrade_Calc(List<double> sym1_PriceList, List<double> sym2_PriceList, List<double> sym3_PriceList)
		{
			sym1_PriceList.Add(this.symbol1_liveLTP);
			sym2_PriceList.Add(this.symbol2_liveLTP);
			sym3_PriceList.Add(this.symbol3_liveLTP);
			List<double> List = new List<double>();
			List<double> List2 = new List<double>();
			List<double> List3 = new List<double>();
			Label label = new Label();
			Label label2 = new Label();
			Label label3 = new Label();
			if (this.selectedInstrument == "INDEX FUTURE")
			{
				pairTradeHelper.dataLoader(sym1_PriceList, List, this.selectedSymbol1, label);
				pairTradeHelper.dataLoader(sym2_PriceList, List2, this.selectedSymbol2, label2);
				pairTradeHelper.dataLoader(sym3_PriceList, List3, this.selectedSymbol3, label3);
			}
			else
			{
				double vola = pairTradeHelper.Volatility(sym1_PriceList);
				double vola2 = pairTradeHelper.Volatility(sym2_PriceList);
				double vola3 = pairTradeHelper.Volatility(sym3_PriceList);
				pairTradeHelper.Swaper(sym1_PriceList, sym2_PriceList, sym3_PriceList, vola, vola2, vola3, this.selectedSymbol1, this.selectedSymbol2, this.selectedSymbol3, List, List2, List3, label, label2, label3);
			}
			double volatility = pairTradeHelper.Volatility(List);
			double volatility2 = pairTradeHelper.Volatility(List2);
			double volatility3 = pairTradeHelper.Volatility(List3);
			List<double> List1ForCalc = new List<double>();
			List<double> List2ForCalc = new List<double>();
			List<double> List3ForCalc = new List<double>();
			pairTradeHelper.Percentage(List, List1ForCalc);
			pairTradeHelper.Percentage(List2, List2ForCalc);
			pairTradeHelper.Percentage(List3, List3ForCalc);
			double upTrend = pairTradeHelper.upTrend(volatility, List[List.Count - 1]);
			double downTrend = pairTradeHelper.downTrend(volatility, List[List.Count - 1]);
			double upTrend2 = pairTradeHelper.upTrend(volatility2, List2[List2.Count - 1]);
			double downTrend2 = pairTradeHelper.downTrend(volatility2, List2[List2.Count - 1]);
			double upTrend3 = pairTradeHelper.upTrend(volatility3, List3[List3.Count - 1]);
			double downTrend3 = pairTradeHelper.downTrend(volatility3, List3[List3.Count - 1]);
			volatility = volatility * 100.0 * Math.Sqrt(365.0);
			volatility2 = volatility2 * 100.0 * Math.Sqrt(365.0);
			volatility3 = volatility3 * 100.0 * Math.Sqrt(365.0);
			double betaXy = pairTradeHelper.Beta(List1ForCalc, List2ForCalc);
			double betaXz = pairTradeHelper.Beta(List1ForCalc, List3ForCalc);
			double betaYz = pairTradeHelper.Beta(List2ForCalc, List3ForCalc);
			double alphaXy = pairTradeHelper.Alpha(List1ForCalc, List2ForCalc);
			double alphaXz = pairTradeHelper.Alpha(List1ForCalc, List3ForCalc);
			double alphaYz = pairTradeHelper.Alpha(List2ForCalc, List3ForCalc);
			double jalphaXy = pairTradeHelper.JensenAlpha(List1ForCalc, List2ForCalc);
			double jalphaYx = pairTradeHelper.JensenAlpha(List2ForCalc, List1ForCalc);
			double jalphaXz = pairTradeHelper.JensenAlpha(List1ForCalc, List3ForCalc);
			double jalphaZx = pairTradeHelper.JensenAlpha(List3ForCalc, List1ForCalc);
			double jalphaYz = pairTradeHelper.JensenAlpha(List2ForCalc, List3ForCalc);
			double jalphaZy = pairTradeHelper.JensenAlpha(List3ForCalc, List2ForCalc);
			double sratioX = pairTradeHelper.SharpRatio(List1ForCalc, List);
			double sratioY = pairTradeHelper.SharpRatio(List2ForCalc, List2);
			double sratioZ = pairTradeHelper.SharpRatio(List3ForCalc, List3);
			double tratioXy = pairTradeHelper.TreynorRatio(List1ForCalc, List2ForCalc);
			double tratioYx = pairTradeHelper.TreynorRatio(List2ForCalc, List1ForCalc);
			double tratioXz = pairTradeHelper.TreynorRatio(List1ForCalc, List3ForCalc);
			double tratioZx = pairTradeHelper.TreynorRatio(List3ForCalc, List1ForCalc);
			double tratioYz = pairTradeHelper.TreynorRatio(List2ForCalc, List3ForCalc);
			double tratioZy = pairTradeHelper.TreynorRatio(List3ForCalc, List2ForCalc);
			double CorRelationXy = pairTradeHelper.CorRelations(List1ForCalc, List2ForCalc);
			double CorRelationXz = pairTradeHelper.CorRelations(List1ForCalc, List3ForCalc);
			double CorRelationYz = pairTradeHelper.CorRelations(List2ForCalc, List3ForCalc);
			List<double> newList1ForBetaDecoupling = new List<double>();
			List<double> newList2ForBetaDecoupling = new List<double>();
			List<double> newList3ForBetaDecoupling = new List<double>();
			double netBDCXy = pairTradeHelper.BetaDecoupling(List1ForCalc, List2ForCalc, newList1ForBetaDecoupling);
			double netBDCXz = pairTradeHelper.BetaDecoupling(List1ForCalc, List3ForCalc, newList2ForBetaDecoupling);
			double netBDCYz = pairTradeHelper.BetaDecoupling(List2ForCalc, List3ForCalc, newList3ForBetaDecoupling);
			this.clearTableValues();
			InlineCollection inlines = this.beta_pair1.Inlines;
			object content = label.Content;
			string str = (content != null) ? content.ToString() : null;
			string str2 = "-";
			object content2 = label2.Content;
			inlines.Add(str + str2 + ((content2 != null) ? content2.ToString() : null) + "     ");
			this.beta_pair1.Inlines.Add(new Bold(new Run(Math.Round(betaXy, 3).ToString() ?? "")));
			InlineCollection inlines2 = this.beta_pair2.Inlines;
			object content3 = label.Content;
			string str3 = (content3 != null) ? content3.ToString() : null;
			string str4 = "-";
			object content4 = label3.Content;
			inlines2.Add(str3 + str4 + ((content4 != null) ? content4.ToString() : null) + "     ");
			this.beta_pair2.Inlines.Add(new Bold(new Run(Math.Round(betaXz, 3).ToString() ?? "")));
			InlineCollection inlines3 = this.beta_pair3.Inlines;
			object content5 = label2.Content;
			string str5 = (content5 != null) ? content5.ToString() : null;
			string str6 = "-";
			object content6 = label3.Content;
			inlines3.Add(str5 + str6 + ((content6 != null) ? content6.ToString() : null) + "     ");
			this.beta_pair3.Inlines.Add(new Bold(new Run(Math.Round(betaYz, 3).ToString() ?? "")));
			InlineCollection inlines4 = this.alpha_pair1.Inlines;
			object content7 = label.Content;
			string str7 = (content7 != null) ? content7.ToString() : null;
			string str8 = "-";
			object content8 = label2.Content;
			inlines4.Add(str7 + str8 + ((content8 != null) ? content8.ToString() : null) + "     ");
			this.alpha_pair1.Inlines.Add(new Bold(new Run(Math.Round(alphaXy, 3).ToString() ?? "")));
			InlineCollection inlines5 = this.alpha_pair2.Inlines;
			object content9 = label.Content;
			string str9 = (content9 != null) ? content9.ToString() : null;
			string str10 = "-";
			object content10 = label3.Content;
			inlines5.Add(str9 + str10 + ((content10 != null) ? content10.ToString() : null) + "     ");
			this.alpha_pair2.Inlines.Add(new Bold(new Run(Math.Round(alphaXz, 3).ToString() ?? "")));
			InlineCollection inlines6 = this.alpha_pair3.Inlines;
			object content11 = label2.Content;
			string str11 = (content11 != null) ? content11.ToString() : null;
			string str12 = "-";
			object content12 = label3.Content;
			inlines6.Add(str11 + str12 + ((content12 != null) ? content12.ToString() : null) + "     ");
			this.alpha_pair3.Inlines.Add(new Bold(new Run(Math.Round(alphaYz, 3).ToString() ?? "")));
			InlineCollection inlines7 = this.sharpRatio_pair1.Inlines;
			object content13 = label.Content;
			inlines7.Add(((content13 != null) ? content13.ToString() : null) + "     ");
			this.sharpRatio_pair1.Inlines.Add(new Bold(new Run(Math.Round(sratioX, 3).ToString() ?? "")));
			InlineCollection inlines8 = this.sharpRatio_pair2.Inlines;
			object content14 = label3.Content;
			inlines8.Add(((content14 != null) ? content14.ToString() : null) + "     ");
			this.sharpRatio_pair2.Inlines.Add(new Bold(new Run(Math.Round(sratioZ, 3).ToString() ?? "")));
			InlineCollection inlines9 = this.sharpRatio_pair3.Inlines;
			object content15 = label2.Content;
			inlines9.Add(((content15 != null) ? content15.ToString() : null) + "     ");
			this.sharpRatio_pair3.Inlines.Add(new Bold(new Run(Math.Round(sratioY, 3).ToString() ?? "")));
			InlineCollection inlines10 = this.jensenAlpha_pair1.Inlines;
			object content16 = label.Content;
			inlines10.Add(((content16 != null) ? content16.ToString() : null) + ":     ");
			this.jensenAlpha_pair1.Inlines.Add(new Bold(new Run(Math.Round(jalphaXy, 3).ToString() + " | ")));
			InlineCollection inlines11 = this.jensenAlpha_pair1.Inlines;
			object content17 = label2.Content;
			inlines11.Add(((content17 != null) ? content17.ToString() : null) + ":     ");
			this.jensenAlpha_pair1.Inlines.Add(new Bold(new Run(Math.Round(jalphaYx, 3).ToString() ?? "")));
			InlineCollection inlines12 = this.jensenAlpha_pair2.Inlines;
			object content18 = label.Content;
			inlines12.Add(((content18 != null) ? content18.ToString() : null) + ":     ");
			this.jensenAlpha_pair2.Inlines.Add(new Bold(new Run(Math.Round(jalphaXz, 3).ToString() + " | ")));
			InlineCollection inlines13 = this.jensenAlpha_pair2.Inlines;
			object content19 = label3.Content;
			inlines13.Add(((content19 != null) ? content19.ToString() : null) + ":     ");
			this.jensenAlpha_pair2.Inlines.Add(new Bold(new Run(Math.Round(jalphaZx, 3).ToString() ?? "")));
			InlineCollection inlines14 = this.jensenAlpha_pair3.Inlines;
			object content20 = label2.Content;
			inlines14.Add(((content20 != null) ? content20.ToString() : null) + ":     ");
			this.jensenAlpha_pair3.Inlines.Add(new Bold(new Run(Math.Round(jalphaYz, 3).ToString() + " | ")));
			InlineCollection inlines15 = this.jensenAlpha_pair3.Inlines;
			object content21 = label3.Content;
			inlines15.Add(((content21 != null) ? content21.ToString() : null) + ":     ");
			this.jensenAlpha_pair3.Inlines.Add(new Bold(new Run(Math.Round(jalphaZy, 3).ToString() ?? "")));
			InlineCollection inlines16 = this.treynorRatio_pair1.Inlines;
			object content22 = label.Content;
			inlines16.Add(((content22 != null) ? content22.ToString() : null) + ":     ");
			this.treynorRatio_pair1.Inlines.Add(new Bold(new Run(Math.Round(tratioXy, 3).ToString() + " | ")));
			InlineCollection inlines17 = this.treynorRatio_pair1.Inlines;
			object content23 = label2.Content;
			inlines17.Add(((content23 != null) ? content23.ToString() : null) + ":     ");
			this.treynorRatio_pair1.Inlines.Add(new Bold(new Run(Math.Round(tratioYx, 3).ToString() ?? "")));
			InlineCollection inlines18 = this.treynorRatio_pair2.Inlines;
			object content24 = label.Content;
			inlines18.Add(((content24 != null) ? content24.ToString() : null) + ":     ");
			this.treynorRatio_pair2.Inlines.Add(new Bold(new Run(Math.Round(tratioXz, 3).ToString() + " | ")));
			InlineCollection inlines19 = this.treynorRatio_pair2.Inlines;
			object content25 = label3.Content;
			inlines19.Add(((content25 != null) ? content25.ToString() : null) + ":     ");
			this.treynorRatio_pair2.Inlines.Add(new Bold(new Run(Math.Round(tratioZx, 3).ToString() ?? "")));
			InlineCollection inlines20 = this.treynorRatio_pair3.Inlines;
			object content26 = label2.Content;
			inlines20.Add(((content26 != null) ? content26.ToString() : null) + ":     ");
			this.treynorRatio_pair3.Inlines.Add(new Bold(new Run(Math.Round(tratioYz, 3).ToString() + " | ")));
			InlineCollection inlines21 = this.treynorRatio_pair3.Inlines;
			object content27 = label3.Content;
			inlines21.Add(((content27 != null) ? content27.ToString() : null) + ":     ");
			this.treynorRatio_pair3.Inlines.Add(new Bold(new Run(Math.Round(tratioZy, 3).ToString() ?? "")));
			InlineCollection inlines22 = this.correlation_pair1.Inlines;
			object content28 = label.Content;
			string str13 = (content28 != null) ? content28.ToString() : null;
			string str14 = "-";
			object content29 = label2.Content;
			inlines22.Add(str13 + str14 + ((content29 != null) ? content29.ToString() : null) + "     ");
			this.correlation_pair1.Inlines.Add(new Bold(new Run(Math.Round(CorRelationXy, 3).ToString() ?? "")));
			InlineCollection inlines23 = this.correlation_pair2.Inlines;
			object content30 = label.Content;
			string str15 = (content30 != null) ? content30.ToString() : null;
			string str16 = "-";
			object content31 = label3.Content;
			inlines23.Add(str15 + str16 + ((content31 != null) ? content31.ToString() : null) + "     ");
			this.correlation_pair2.Inlines.Add(new Bold(new Run(Math.Round(CorRelationXz, 3).ToString() ?? "")));
			InlineCollection inlines24 = this.correlation_pair3.Inlines;
			object content32 = label2.Content;
			string str17 = (content32 != null) ? content32.ToString() : null;
			string str18 = "-";
			object content33 = label3.Content;
			inlines24.Add(str17 + str18 + ((content33 != null) ? content33.ToString() : null) + "     ");
			this.correlation_pair3.Inlines.Add(new Bold(new Run(Math.Round(CorRelationYz, 3).ToString() ?? "")));
			InlineCollection inlines25 = this.netBetaDecoupling_pair1.Inlines;
			object content34 = label.Content;
			string str19 = (content34 != null) ? content34.ToString() : null;
			string str20 = "-";
			object content35 = label2.Content;
			inlines25.Add(str19 + str20 + ((content35 != null) ? content35.ToString() : null) + "     ");
			this.netBetaDecoupling_pair1.Inlines.Add(new Bold(new Run(Math.Round(netBDCXy, 3).ToString() ?? "")));
			InlineCollection inlines26 = this.netBetaDecoupling_pair2.Inlines;
			object content36 = label.Content;
			string str21 = (content36 != null) ? content36.ToString() : null;
			string str22 = "-";
			object content37 = label3.Content;
			inlines26.Add(str21 + str22 + ((content37 != null) ? content37.ToString() : null) + "     ");
			this.netBetaDecoupling_pair2.Inlines.Add(new Bold(new Run(Math.Round(netBDCXz, 3).ToString() ?? "")));
			InlineCollection inlines27 = this.netBetaDecoupling_pair3.Inlines;
			object content38 = label2.Content;
			string str23 = (content38 != null) ? content38.ToString() : null;
			string str24 = "-";
			object content39 = label3.Content;
			inlines27.Add(str23 + str24 + ((content39 != null) ? content39.ToString() : null) + "     ");
			this.netBetaDecoupling_pair3.Inlines.Add(new Bold(new Run(Math.Round(netBDCYz, 3).ToString() ?? "")));
			this.intraPosiAnalysisReport.ToolTip = "Scroll down for full Analysis";
			bool? isChecked = this.positional.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				volatility = pairTradeHelper.doErrorFCheck(volatility);
				volatility2 = pairTradeHelper.doErrorFCheck(volatility2);
				volatility3 = pairTradeHelper.doErrorFCheck(volatility3);
				this.techReport.Document.Blocks.Clear();
				this.techReport.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				this.techReport.ToolTip = "Positional Trend";
				Paragraph ObjPara0 = new Paragraph();
				ObjPara0.Inlines.Add(new Bold(new Run("                                                         Pair Trade Trend:" + Environment.NewLine + Environment.NewLine)));
				Paragraph ObjPara = new Paragraph();
				TextElementCollection<Inline> inlines28 = ObjPara.Inlines;
				string[] array = new string[15];
				array[0] = "Volatility:        ";
				int num = 1;
				object content40 = label.Content;
				array[num] = ((content40 != null) ? content40.ToString() : null);
				array[2] = " : ";
				array[3] = Math.Round(volatility, 2).ToString();
				array[4] = "%  ---  ";
				int num2 = 5;
				object content41 = label2.Content;
				array[num2] = ((content41 != null) ? content41.ToString() : null);
				array[6] = " : ";
				array[7] = Math.Round(volatility2, 2).ToString();
				array[8] = "%  ---  ";
				int num3 = 9;
				object content42 = label3.Content;
				array[num3] = ((content42 != null) ? content42.ToString() : null);
				array[10] = " : ";
				array[11] = Math.Round(volatility3, 2).ToString();
				array[12] = "%";
				array[13] = Environment.NewLine;
				array[14] = Environment.NewLine;
				inlines28.Add(new Run(string.Concat(array)));
				ObjPara.Foreground = new SolidColorBrush(Colors.Purple);
				Paragraph ObjPara2 = new Paragraph();
				TextElementCollection<Inline> inlines29 = ObjPara2.Inlines;
				string[] array2 = new string[14];
				array2[0] = "UpTrend:        ";
				int num4 = 1;
				object content43 = label.Content;
				array2[num4] = ((content43 != null) ? content43.ToString() : null);
				array2[2] = " : ";
				array2[3] = Math.Round(upTrend, 3).ToString();
				array2[4] = "  ---  ";
				int num5 = 5;
				object content44 = label2.Content;
				array2[num5] = ((content44 != null) ? content44.ToString() : null);
				array2[6] = " : ";
				array2[7] = Math.Round(upTrend2, 3).ToString();
				array2[8] = "  ---  ";
				int num6 = 9;
				object content45 = label3.Content;
				array2[num6] = ((content45 != null) ? content45.ToString() : null);
				array2[10] = " : ";
				array2[11] = Math.Round(upTrend3, 3).ToString();
				array2[12] = Environment.NewLine;
				array2[13] = Environment.NewLine;
				inlines29.Add(new Run(string.Concat(array2)));
				ObjPara2.Foreground = new SolidColorBrush(Colors.Green);
				Paragraph ObjPara3 = new Paragraph();
				TextElementCollection<Inline> inlines30 = ObjPara3.Inlines;
				string[] array3 = new string[14];
				array3[0] = "DownTrend:   ";
				int num7 = 1;
				object content46 = label.Content;
				array3[num7] = ((content46 != null) ? content46.ToString() : null);
				array3[2] = " : ";
				array3[3] = Math.Round(downTrend, 3).ToString();
				array3[4] = "  ---  ";
				int num8 = 5;
				object content47 = label2.Content;
				array3[num8] = ((content47 != null) ? content47.ToString() : null);
				array3[6] = " : ";
				array3[7] = Math.Round(downTrend2, 3).ToString();
				array3[8] = "  ---  ";
				int num9 = 9;
				object content48 = label3.Content;
				array3[num9] = ((content48 != null) ? content48.ToString() : null);
				array3[10] = " : ";
				array3[11] = Math.Round(downTrend3, 3).ToString();
				array3[12] = Environment.NewLine;
				array3[13] = Environment.NewLine;
				inlines30.Add(new Run(string.Concat(array3)));
				ObjPara3.Foreground = new SolidColorBrush(Colors.Red);
				FlowDocument ObjFdoc = new FlowDocument();
				ObjFdoc.Blocks.Add(ObjPara0);
				ObjFdoc.Blocks.Add(ObjPara);
				ObjFdoc.Blocks.Add(ObjPara2);
				ObjFdoc.Blocks.Add(ObjPara3);
				this.techReport.Document = ObjFdoc;
				this.intraPosiAnalysisReport.Document.Blocks.Clear();
				Paragraph ObjPara4 = new Paragraph();
				ObjPara4.Inlines.Add(new Bold(new Run("\t\t\t\tPositional Pair Trade ANALYSIS REPORT")));
				Paragraph ObjPara5 = new Paragraph();
				TextElementCollection<Inline> inlines31 = ObjPara5.Inlines;
				string[] array4 = new string[12];
				int num10 = 0;
				object content49 = label.Content;
				array4[num10] = ((content49 != null) ? content49.ToString() : null);
				array4[1] = "[";
				array4[2] = List[List.Count - 1].ToString();
				array4[3] = "] - ";
				int num11 = 4;
				object content50 = label2.Content;
				array4[num11] = ((content50 != null) ? content50.ToString() : null);
				array4[5] = "[";
				array4[6] = List2[List2.Count - 1].ToString();
				array4[7] = "] - ";
				int num12 = 8;
				object content51 = label3.Content;
				array4[num12] = ((content51 != null) ? content51.ToString() : null);
				array4[9] = "[";
				array4[10] = List3[List3.Count - 1].ToString();
				array4[11] = "]";
				inlines31.Add(new Run(string.Concat(array4)));
				ObjPara5.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				ObjPara5.Foreground = new SolidColorBrush(Colors.MediumVioletRed);
				this.storeSelectedScript(label.Content.ToString(), label2.Content.ToString(), label3.Content.ToString(), List[List.Count - 1].ToString(), List2[List2.Count - 1].ToString(), List3[List3.Count - 1].ToString());
				this.storeScriptVola(volatility, volatility2, volatility3);
				Paragraph ObjPara6 = new Paragraph();
				TextElementCollection<Inline> inlines32 = ObjPara6.Inlines;
				string newLine = Environment.NewLine;
				object content52 = label.Content;
				string str25 = (content52 != null) ? content52.ToString() : null;
				string str26 = "-";
				object content53 = label2.Content;
				inlines32.Add(new Bold(new Run(newLine + str25 + str26 + ((content53 != null) ? content53.ToString() : null))));
				pairTradeHelper.MaxMin(jalphaXy, jalphaYx, label, label2, this.txtHigh, this.txtLow);
				Paragraph ObjPara7 = new Paragraph();
				ObjPara7.Inlines.Add(new Run(" * Jensen Alpha : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(sratioX, sratioY, label, label2, this.txtHigh, this.txtLow);
				Paragraph ObjPara8 = new Paragraph();
				ObjPara8.Inlines.Add(new Run(" * Sharp Ratio : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(tratioXy, tratioYx, label, label2, this.txtHigh, this.txtLow);
				Paragraph ObjPara9 = new Paragraph();
				ObjPara9.Inlines.Add(new Run(" * Treynor Ratio : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				Paragraph ObjPara10 = new Paragraph();
				if (pairTradeHelper.BDCVal4P(netBDCXy, label, label2, this.txtHigh, this.txtLow))
				{
					ObjPara10.Inlines.Add(new Run(" * Beta Decoupling : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
					this.checkScripts(this.txtLow.Text, this.firstScript, 1);
					this.checkScripts(this.txtLow.Text, this.secondScript, 1);
					this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
					this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
					this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
					this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				}
				else
				{
					ObjPara10.Inlines.Add(new Run(" * Beta Decoupling : TRADE IS NOT RECOMMENDED"));
				}
				Paragraph ObjPara11 = new Paragraph();
				if (alphaXy > 0.0)
				{
					TextElementCollection<Inline> inlines33 = ObjPara11.Inlines;
					string str27 = " * Alpha : Buy - ";
					object content54 = label.Content;
					string str28 = (content54 != null) ? content54.ToString() : null;
					string str29 = ", SELL - ";
					object content55 = label2.Content;
					inlines33.Add(new Run(str27 + str28 + str29 + ((content55 != null) ? content55.ToString() : null)));
					this.checkScripts(label.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label2.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label2.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label2.Content.ToString(), this.thirdScript, -1);
				}
				else
				{
					TextElementCollection<Inline> inlines34 = ObjPara11.Inlines;
					string str30 = " * Alpha : Buy - ";
					object content56 = label2.Content;
					string str31 = (content56 != null) ? content56.ToString() : null;
					string str32 = ", SELL - ";
					object content57 = label.Content;
					inlines34.Add(new Run(str30 + str31 + str32 + ((content57 != null) ? content57.ToString() : null)));
					this.checkScripts(label2.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label2.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label2.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label.Content.ToString(), this.thirdScript, -1);
				}
				Paragraph ObjPara12 = new Paragraph();
				ObjPara12.Inlines.Add(new Run(" * Correlations : Trade - " + pairTradeHelper.CRVal(CorRelationXy)));
				Paragraph ObjPara13 = new Paragraph();
				ObjPara13.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List, List2)));
				Paragraph ObjPara14 = new Paragraph();
				ObjPara14.Inlines.Add(new Run(this.displayFinalResult()));
				ObjPara14.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				Paragraph ObjPara15 = new Paragraph();
				if (this.countBuy(this._scriptA) == this.countBuy(this._scriptB))
				{
					ObjPara15.Inlines.Add(new Run("##Trade NOT recommended"));
					ObjPara15.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				}
				else
				{
					if (this.countBuy(this._scriptA) > this.countBuy(this._scriptB))
					{
						ObjPara15.Inlines.Add(new Run(this.getBuySellReport(this._scriptA, this._scriptB)));
					}
					if (this.countBuy(this._scriptB) > this.countBuy(this._scriptA))
					{
						ObjPara15.Inlines.Add(new Run(this.getBuySellReport(this._scriptB, this._scriptA)));
					}
				}
				this.reset123Counters();
				Paragraph ObjPara16 = new Paragraph();
				TextElementCollection<Inline> inlines35 = ObjPara16.Inlines;
				string[] array5 = new string[5];
				array5[0] = Environment.NewLine;
				array5[1] = Environment.NewLine;
				int num13 = 2;
				object content58 = label.Content;
				array5[num13] = ((content58 != null) ? content58.ToString() : null);
				array5[3] = "-";
				int num14 = 4;
				object content59 = label3.Content;
				array5[num14] = ((content59 != null) ? content59.ToString() : null);
				inlines35.Add(new Bold(new Run(string.Concat(array5))));
				pairTradeHelper.MaxMin(jalphaXz, jalphaZx, label, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara17 = new Paragraph();
				ObjPara17.Inlines.Add(new Run(" * Jensen Alpha : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(sratioX, sratioZ, label, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara18 = new Paragraph();
				ObjPara18.Inlines.Add(new Run(" * Sharp Ratio : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(tratioXz, tratioZx, label, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara19 = new Paragraph();
				ObjPara19.Inlines.Add(new Run(" * Treynor Ratio : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				Paragraph ObjPara20 = new Paragraph();
				if (pairTradeHelper.BDCVal4P(netBDCXz, label, label3, this.txtHigh, this.txtLow))
				{
					ObjPara20.Inlines.Add(new Run(" * Beta Decoupling : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
					this.checkScripts(this.txtLow.Text, this.firstScript, 1);
					this.checkScripts(this.txtLow.Text, this.secondScript, 1);
					this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
					this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
					this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
					this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				}
				else
				{
					ObjPara20.Inlines.Add(new Run(" * Beta Decoupling : TRADE IS NOT RECOMMENDED"));
				}
				Paragraph ObjPara21 = new Paragraph();
				if (alphaXz > 0.0)
				{
					TextElementCollection<Inline> inlines36 = ObjPara21.Inlines;
					string str33 = " * Alpha : Buy - ";
					object content60 = label.Content;
					string str34 = (content60 != null) ? content60.ToString() : null;
					string str35 = ", SELL - ";
					object content61 = label3.Content;
					inlines36.Add(new Run(str33 + str34 + str35 + ((content61 != null) ? content61.ToString() : null)));
					this.checkScripts(label.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label3.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label3.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label3.Content.ToString(), this.thirdScript, -1);
				}
				else
				{
					TextElementCollection<Inline> inlines37 = ObjPara21.Inlines;
					string str36 = " * Alpha : Buy - ";
					object content62 = label3.Content;
					string str37 = (content62 != null) ? content62.ToString() : null;
					string str38 = ", SELL - ";
					object content63 = label.Content;
					inlines37.Add(new Run(str36 + str37 + str38 + ((content63 != null) ? content63.ToString() : null)));
					this.checkScripts(label3.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label3.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label3.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label.Content.ToString(), this.thirdScript, -1);
				}
				Paragraph ObjPara22 = new Paragraph();
				ObjPara22.Inlines.Add(new Run(" * Correlations : Trade - " + pairTradeHelper.CRVal(CorRelationXz)));
				Paragraph ObjPara23 = new Paragraph();
				ObjPara23.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List, List3)));
				Paragraph ObjPara24 = new Paragraph();
				ObjPara24.Inlines.Add(new Run(this.displayFinalResult()));
				ObjPara24.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				Paragraph ObjPara25 = new Paragraph();
				if (this.countBuy(this._scriptA) == this.countBuy(this._scriptB))
				{
					ObjPara25.Inlines.Add(new Run("##Trade NOT recommended"));
				}
				else
				{
					if (this.countBuy(this._scriptA) > this.countBuy(this._scriptB))
					{
						ObjPara25.Inlines.Add(new Run(this.getBuySellReport(this._scriptA, this._scriptB)));
					}
					if (this.countBuy(this._scriptB) > this.countBuy(this._scriptA))
					{
						ObjPara25.Inlines.Add(new Run(this.getBuySellReport(this._scriptB, this._scriptA)));
					}
				}
				this.reset123Counters();
				Paragraph ObjPara26 = new Paragraph();
				TextElementCollection<Inline> inlines38 = ObjPara26.Inlines;
				string[] array6 = new string[5];
				array6[0] = Environment.NewLine;
				array6[1] = Environment.NewLine;
				int num15 = 2;
				object content64 = label2.Content;
				array6[num15] = ((content64 != null) ? content64.ToString() : null);
				array6[3] = "-";
				int num16 = 4;
				object content65 = label3.Content;
				array6[num16] = ((content65 != null) ? content65.ToString() : null);
				inlines38.Add(new Bold(new Run(string.Concat(array6))));
				pairTradeHelper.MaxMin(jalphaYz, jalphaZy, label2, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara27 = new Paragraph();
				ObjPara27.Inlines.Add(new Run(" * Jensen Alpha : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(sratioY, sratioZ, label2, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara28 = new Paragraph();
				ObjPara28.Inlines.Add(new Run(" * Sharp Ratio  : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				pairTradeHelper.MaxMin(tratioYz, tratioZy, label2, label3, this.txtHigh, this.txtLow);
				Paragraph ObjPara29 = new Paragraph();
				ObjPara29.Inlines.Add(new Run(" * Treynor Ratio : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
				this.checkScripts(this.txtLow.Text, this.firstScript, 1);
				this.checkScripts(this.txtLow.Text, this.secondScript, 1);
				this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
				this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
				this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
				this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				Paragraph ObjPara30 = new Paragraph();
				if (pairTradeHelper.BDCVal4P(netBDCYz, label2, label3, this.txtHigh, this.txtLow))
				{
					ObjPara30.Inlines.Add(new Run(" * Beta Decoupling : BUY - " + this.txtLow.Text + ", SELL - " + this.txtHigh.Text));
					this.checkScripts(this.txtLow.Text, this.firstScript, 1);
					this.checkScripts(this.txtLow.Text, this.secondScript, 1);
					this.checkScripts(this.txtLow.Text, this.thirdScript, 1);
					this.checkScripts(this.txtHigh.Text, this.firstScript, -1);
					this.checkScripts(this.txtHigh.Text, this.secondScript, -1);
					this.checkScripts(this.txtHigh.Text, this.thirdScript, -1);
				}
				else
				{
					ObjPara30.Inlines.Add(new Run(" * Beta Decoupling : TRADE IS NOT RECOMMENDED"));
				}
				Paragraph ObjPara31 = new Paragraph();
				if (alphaYz > 0.0)
				{
					TextElementCollection<Inline> inlines39 = ObjPara31.Inlines;
					string str39 = " * Alpha : Buy - ";
					object content66 = label2.Content;
					string str40 = (content66 != null) ? content66.ToString() : null;
					string str41 = ", SELL - ";
					object content67 = label3.Content;
					inlines39.Add(new Run(str39 + str40 + str41 + ((content67 != null) ? content67.ToString() : null)));
					this.checkScripts(label2.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label2.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label2.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label3.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label3.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label3.Content.ToString(), this.thirdScript, -1);
				}
				else
				{
					TextElementCollection<Inline> inlines40 = ObjPara31.Inlines;
					string str42 = " * Alpha : Buy - ";
					object content68 = label3.Content;
					string str43 = (content68 != null) ? content68.ToString() : null;
					string str44 = ", SELL - ";
					object content69 = label2.Content;
					inlines40.Add(new Run(str42 + str43 + str44 + ((content69 != null) ? content69.ToString() : null)));
					this.checkScripts(label3.Content.ToString(), this.firstScript, 1);
					this.checkScripts(label3.Content.ToString(), this.secondScript, 1);
					this.checkScripts(label3.Content.ToString(), this.thirdScript, 1);
					this.checkScripts(label2.Content.ToString(), this.firstScript, -1);
					this.checkScripts(label2.Content.ToString(), this.secondScript, -1);
					this.checkScripts(label2.Content.ToString(), this.thirdScript, -1);
				}
				Paragraph ObjPara32 = new Paragraph();
				ObjPara32.Inlines.Add(new Run(" * Correlations : Trade - " + pairTradeHelper.CRVal(CorRelationYz)));
				Paragraph ObjPara33 = new Paragraph();
				ObjPara33.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List2, List3)));
				Paragraph ObjPara34 = new Paragraph();
				ObjPara34.Inlines.Add(new Run(this.displayFinalResult()));
				ObjPara34.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
				Paragraph ObjPara35 = new Paragraph();
				if (this.countBuy(this._scriptA) == this.countBuy(this._scriptB))
				{
					ObjPara35.Inlines.Add(new Run("##Trade NOT recommended"));
				}
				else
				{
					if (this.countBuy(this._scriptA) > this.countBuy(this._scriptB))
					{
						ObjPara35.Inlines.Add(new Run(this.getBuySellReport(this._scriptA, this._scriptB)));
					}
					if (this.countBuy(this._scriptB) > this.countBuy(this._scriptA))
					{
						ObjPara35.Inlines.Add(new Run(this.getBuySellReport(this._scriptB, this._scriptA)));
					}
				}
				this.reset123Counters();
				FlowDocument ObjFdoc2 = new FlowDocument();
				ObjFdoc2.Blocks.Add(ObjPara4);
				ObjFdoc2.Blocks.Add(ObjPara5);
				ObjFdoc2.Blocks.Add(ObjPara6);
				ObjFdoc2.Blocks.Add(ObjPara7);
				ObjFdoc2.Blocks.Add(ObjPara8);
				ObjFdoc2.Blocks.Add(ObjPara9);
				ObjFdoc2.Blocks.Add(ObjPara10);
				ObjFdoc2.Blocks.Add(ObjPara11);
				ObjFdoc2.Blocks.Add(ObjPara12);
				ObjFdoc2.Blocks.Add(ObjPara13);
				ObjFdoc2.Blocks.Add(ObjPara14);
				ObjFdoc2.Blocks.Add(ObjPara15);
				ObjFdoc2.Blocks.Add(ObjPara16);
				ObjFdoc2.Blocks.Add(ObjPara17);
				ObjFdoc2.Blocks.Add(ObjPara18);
				ObjFdoc2.Blocks.Add(ObjPara19);
				ObjFdoc2.Blocks.Add(ObjPara20);
				ObjFdoc2.Blocks.Add(ObjPara21);
				ObjFdoc2.Blocks.Add(ObjPara22);
				ObjFdoc2.Blocks.Add(ObjPara23);
				ObjFdoc2.Blocks.Add(ObjPara24);
				ObjFdoc2.Blocks.Add(ObjPara25);
				ObjFdoc2.Blocks.Add(ObjPara26);
				ObjFdoc2.Blocks.Add(ObjPara27);
				ObjFdoc2.Blocks.Add(ObjPara28);
				ObjFdoc2.Blocks.Add(ObjPara29);
				ObjFdoc2.Blocks.Add(ObjPara30);
				ObjFdoc2.Blocks.Add(ObjPara31);
				ObjFdoc2.Blocks.Add(ObjPara32);
				ObjFdoc2.Blocks.Add(ObjPara33);
				ObjFdoc2.Blocks.Add(ObjPara34);
				ObjFdoc2.Blocks.Add(ObjPara35);
				this.intraPosiAnalysisReport.Document = ObjFdoc2;
				return;
			}
			this.techReport.Document.Blocks.Clear();
			this.techReport.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
			this.techReport.ToolTip = "Intraday Trend";
			Paragraph ObjPara36 = new Paragraph();
			ObjPara36.Inlines.Add(new Bold(new Run("                                                         Pair Trade Trend:" + Environment.NewLine + Environment.NewLine)));
			Paragraph ObjPara37 = new Paragraph();
			TextElementCollection<Inline> inlines41 = ObjPara37.Inlines;
			string[] array7 = new string[15];
			array7[0] = "Volatility:        ";
			int num17 = 1;
			object content70 = label.Content;
			array7[num17] = ((content70 != null) ? content70.ToString() : null);
			array7[2] = " : ";
			array7[3] = Math.Round(volatility, 2).ToString();
			array7[4] = "%  ---  ";
			int num18 = 5;
			object content71 = label2.Content;
			array7[num18] = ((content71 != null) ? content71.ToString() : null);
			array7[6] = " : ";
			array7[7] = Math.Round(volatility2, 2).ToString();
			array7[8] = "%  ---  ";
			int num19 = 9;
			object content72 = label3.Content;
			array7[num19] = ((content72 != null) ? content72.ToString() : null);
			array7[10] = " : ";
			array7[11] = Math.Round(volatility3, 2).ToString();
			array7[12] = "%";
			array7[13] = Environment.NewLine;
			array7[14] = Environment.NewLine;
			inlines41.Add(new Run(string.Concat(array7)));
			ObjPara37.Foreground = new SolidColorBrush(Colors.Purple);
			Paragraph ObjPara38 = new Paragraph();
			TextElementCollection<Inline> inlines42 = ObjPara38.Inlines;
			string[] array8 = new string[14];
			array8[0] = "UpTrend:        ";
			int num20 = 1;
			object content73 = label.Content;
			array8[num20] = ((content73 != null) ? content73.ToString() : null);
			array8[2] = " : ";
			array8[3] = Math.Round(upTrend, 3).ToString();
			array8[4] = "  ---  ";
			int num21 = 5;
			object content74 = label2.Content;
			array8[num21] = ((content74 != null) ? content74.ToString() : null);
			array8[6] = " : ";
			array8[7] = Math.Round(upTrend2, 3).ToString();
			array8[8] = "  ---  ";
			int num22 = 9;
			object content75 = label3.Content;
			array8[num22] = ((content75 != null) ? content75.ToString() : null);
			array8[10] = " : ";
			array8[11] = Math.Round(upTrend3, 3).ToString();
			array8[12] = Environment.NewLine;
			array8[13] = Environment.NewLine;
			inlines42.Add(new Run(string.Concat(array8)));
			ObjPara38.Foreground = new SolidColorBrush(Colors.Green);
			Paragraph ObjPara39 = new Paragraph();
			TextElementCollection<Inline> inlines43 = ObjPara39.Inlines;
			string[] array9 = new string[14];
			array9[0] = "DownTrend:   ";
			int num23 = 1;
			object content76 = label.Content;
			array9[num23] = ((content76 != null) ? content76.ToString() : null);
			array9[2] = " : ";
			array9[3] = Math.Round(downTrend, 3).ToString();
			array9[4] = "  ---  ";
			int num24 = 5;
			object content77 = label2.Content;
			array9[num24] = ((content77 != null) ? content77.ToString() : null);
			array9[6] = " : ";
			array9[7] = Math.Round(downTrend2, 3).ToString();
			array9[8] = "  ---  ";
			int num25 = 9;
			object content78 = label3.Content;
			array9[num25] = ((content78 != null) ? content78.ToString() : null);
			array9[10] = " : ";
			array9[11] = Math.Round(downTrend3, 3).ToString();
			array9[12] = Environment.NewLine;
			array9[13] = Environment.NewLine;
			inlines43.Add(new Run(string.Concat(array9)));
			ObjPara39.Foreground = new SolidColorBrush(Colors.Red);
			FlowDocument ObjFdoc3 = new FlowDocument();
			ObjFdoc3.Blocks.Add(ObjPara36);
			ObjFdoc3.Blocks.Add(ObjPara37);
			ObjFdoc3.Blocks.Add(ObjPara38);
			ObjFdoc3.Blocks.Add(ObjPara39);
			this.techReport.Document = ObjFdoc3;
			this.intraPosiAnalysisReport.Document.Blocks.Clear();
			Paragraph ObjPara40 = new Paragraph();
			ObjPara40.Inlines.Add(new Bold(new Run("\t\t\t\tIntraday Pair Trade ANALYSIS REPORT")));
			Paragraph ObjPara41 = new Paragraph();
			TextElementCollection<Inline> inlines44 = ObjPara41.Inlines;
			object content79 = label.Content;
			string str45 = (content79 != null) ? content79.ToString() : null;
			string str46 = " - ";
			object content80 = label2.Content;
			inlines44.Add(new Bold(new Run(str45 + str46 + ((content80 != null) ? content80.ToString() : null))));
			Paragraph ObjPara42 = new Paragraph();
			if (pairTradeHelper.BDCVal4I(newList1ForBetaDecoupling, label, label2, this.txtHigh, this.txtLow))
			{
				ObjPara42.Inlines.Add(new Run(" * Beta Decoupling Recommended : BUY - " + this.txtLow.Text + " - , SELL - " + this.txtHigh.Text));
			}
			else
			{
				ObjPara42.Inlines.Add(new Run(" * Beta Decoupling Recommended : Trade is NOT Recommended"));
			}
			Paragraph ObjPara43 = new Paragraph();
			ObjPara43.Inlines.Add(new Run(" * Correlations Recommended : Trade - " + pairTradeHelper.CRVal(CorRelationXy)));
			Paragraph ObjPara44 = new Paragraph();
			ObjPara44.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List, List2) + Environment.NewLine));
			Paragraph ObjPara45 = new Paragraph();
			TextElementCollection<Inline> inlines45 = ObjPara45.Inlines;
			string newLine2 = Environment.NewLine;
			object content81 = label.Content;
			string str47 = (content81 != null) ? content81.ToString() : null;
			string str48 = " - ";
			object content82 = label3.Content;
			inlines45.Add(new Bold(new Run(newLine2 + str47 + str48 + ((content82 != null) ? content82.ToString() : null))));
			Paragraph ObjPara46 = new Paragraph();
			if (pairTradeHelper.BDCVal4I(newList2ForBetaDecoupling, label, label3, this.txtHigh, this.txtLow))
			{
				ObjPara46.Inlines.Add(new Run(" * Beta Decoupling Recommended : BUY - " + this.txtLow.Text + " - , SELL - " + this.txtHigh.Text));
			}
			else
			{
				ObjPara46.Inlines.Add(new Run(" * Beta Decoupling Recommended : Trade is NOT Recommended"));
			}
			Paragraph ObjPara47 = new Paragraph();
			ObjPara47.Inlines.Add(new Run(" * Correlations Recommended : Trade - " + pairTradeHelper.CRVal(CorRelationXz)));
			Paragraph ObjPara48 = new Paragraph();
			ObjPara48.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List, List3) + Environment.NewLine));
			Paragraph ObjPara49 = new Paragraph();
			TextElementCollection<Inline> inlines46 = ObjPara49.Inlines;
			string newLine3 = Environment.NewLine;
			object content83 = label2.Content;
			string str49 = (content83 != null) ? content83.ToString() : null;
			string str50 = " - ";
			object content84 = label3.Content;
			inlines46.Add(new Bold(new Run(newLine3 + str49 + str50 + ((content84 != null) ? content84.ToString() : null))));
			Paragraph ObjPara50 = new Paragraph();
			if (pairTradeHelper.BDCVal4I(newList3ForBetaDecoupling, label2, label3, this.txtHigh, this.txtLow))
			{
				ObjPara50.Inlines.Add(new Run(" * Beta Decoupling Recommended : BUY - " + this.txtLow.Text + " - , SELL - " + this.txtHigh.Text));
			}
			else
			{
				ObjPara50.Inlines.Add(new Run(" * Beta Decoupling Recommended : Trade is NOT Recommended"));
			}
			Paragraph ObjPara51 = new Paragraph();
			ObjPara51.Inlines.Add(new Run(" * Correlations Recommended : Trade - " + pairTradeHelper.CRVal(CorRelationYz)));
			Paragraph ObjPara52 = new Paragraph();
			ObjPara52.Inlines.Add(new Run(" * Spread Analysis : " + pairTradeHelper.Spread(List2, List3) + Environment.NewLine));
			FlowDocument ObjFdoc4 = new FlowDocument();
			ObjFdoc4.Blocks.Add(ObjPara40);
			ObjFdoc4.Blocks.Add(ObjPara41);
			ObjFdoc4.Blocks.Add(ObjPara42);
			ObjFdoc4.Blocks.Add(ObjPara43);
			ObjFdoc4.Blocks.Add(ObjPara44);
			ObjFdoc4.Blocks.Add(ObjPara45);
			ObjFdoc4.Blocks.Add(ObjPara46);
			ObjFdoc4.Blocks.Add(ObjPara47);
			ObjFdoc4.Blocks.Add(ObjPara48);
			ObjFdoc4.Blocks.Add(ObjPara49);
			ObjFdoc4.Blocks.Add(ObjPara50);
			ObjFdoc4.Blocks.Add(ObjPara51);
			ObjFdoc4.Blocks.Add(ObjPara52);
			this.intraPosiAnalysisReport.Document = ObjFdoc4;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000CE28 File Offset: 0x0000B028
		[NullableContext(1)]
		public List<double> get60DaysLTP(string _symbol, string _URL)
		{
			List<double> _60DaysLTPfromDatabase = new List<double>();
			List<string> _60daysPrice = pairTradeHelper._60daysLTPfromDB(_symbol, _URL);
			if (_60daysPrice.Any<string>())
			{
				_60DaysLTPfromDatabase = (from x in pairTradeHelper.splitData(string.Join("", _60daysPrice.ToArray()), _URL)
				select double.Parse(x)).ToList<double>();
			}
			return _60DaysLTPfromDatabase;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000CE90 File Offset: 0x0000B090
		[NullableContext(1)]
		public List<double> addDifferencePricewithDBprice(List<double> DBpriceList, double differencePrice)
		{
			List<double> _60daysPriceANDdifferencePrice = new List<double>();
			for (int index = 0; index <= DBpriceList.Count<double>() - 1; index++)
			{
				double addDifferenceWithDatabasePrice = DBpriceList.ElementAt(index) + differencePrice;
				_60daysPriceANDdifferencePrice.Add(addDifferenceWithDatabasePrice);
			}
			return _60daysPriceANDdifferencePrice;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
		public void clearTableValues()
		{
			this.beta_pair1.Inlines.Clear();
			this.beta_pair2.Inlines.Clear();
			this.beta_pair3.Inlines.Clear();
			this.alpha_pair1.Inlines.Clear();
			this.alpha_pair2.Inlines.Clear();
			this.alpha_pair3.Inlines.Clear();
			this.sharpRatio_pair1.Inlines.Clear();
			this.sharpRatio_pair2.Inlines.Clear();
			this.sharpRatio_pair3.Inlines.Clear();
			this.jensenAlpha_pair1.Inlines.Clear();
			this.jensenAlpha_pair2.Inlines.Clear();
			this.jensenAlpha_pair3.Inlines.Clear();
			this.treynorRatio_pair1.Inlines.Clear();
			this.treynorRatio_pair2.Inlines.Clear();
			this.treynorRatio_pair3.Inlines.Clear();
			this.correlation_pair1.Inlines.Clear();
			this.correlation_pair2.Inlines.Clear();
			this.correlation_pair3.Inlines.Clear();
			this.netBetaDecoupling_pair1.Inlines.Clear();
			this.netBetaDecoupling_pair2.Inlines.Clear();
			this.netBetaDecoupling_pair3.Inlines.Clear();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000D028 File Offset: 0x0000B228
		[NullableContext(1)]
		private void checkBoxChecked(object sender, RoutedEventArgs e)
		{
			CheckBox cb = sender as CheckBox;
			if (cb.Name == "intraday")
			{
				this.positional.IsChecked = new bool?(false);
				this.intraday.FontWeight = FontWeights.Bold;
				this.positional.FontWeight = FontWeights.Normal;
				return;
			}
			if (cb.Name == "positional")
			{
				this.intraday.IsChecked = new bool?(false);
				this.positional.FontWeight = FontWeights.Bold;
				this.intraday.FontWeight = FontWeights.Normal;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000D0C3 File Offset: 0x0000B2C3
		private void storeScriptVola(double volatilityX, double volatilityY, double volatilityZ)
		{
			this.firstScript.volatility = volatilityX;
			this.secondScript.volatility = volatilityY;
			this.thirdScript.volatility = volatilityZ;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000D0EC File Offset: 0x0000B2EC
		[NullableContext(1)]
		private void storeSelectedScript(string p, string p_2, string p_3, string _fPriceA, string _fPriceB, string _fPriceC)
		{
			this.firstScript = new pairTrade.scriptCls();
			this.secondScript = new pairTrade.scriptCls();
			this.thirdScript = new pairTrade.scriptCls();
			this.firstScript.Name = p;
			this.secondScript.Name = p_2;
			this.thirdScript.Name = p_3;
			this.firstScript.futurePrice = double.Parse(_fPriceA);
			this.secondScript.futurePrice = double.Parse(_fPriceB);
			this.thirdScript.futurePrice = double.Parse(_fPriceC);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000D174 File Offset: 0x0000B374
		[NullableContext(1)]
		private void checkScripts(string Name, pairTrade.scriptCls script, int _signal)
		{
			if (Name == script.Name)
			{
				if (_signal > 0)
				{
					script.Counter.Add(1);
					return;
				}
				script.Counter.Add(-1);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000D1A4 File Offset: 0x0000B3A4
		[NullableContext(1)]
		private string displayFinalResult()
		{
			string data = string.Empty;
			if (this.firstScript.Counter.Count > 0)
			{
				this.firstScript.considered4Pair = true;
				if (this._scriptA == null)
				{
					this._scriptA = new pairTrade.scriptCls();
					this._scriptA = this.firstScript;
				}
				else if (this._scriptB == null)
				{
					this._scriptB = new pairTrade.scriptCls();
					this._scriptB = this.firstScript;
				}
				data = string.Concat(new string[]
				{
					data,
					" ",
					this.firstScript.Name,
					" : Buy ",
					this.countBuy(this.firstScript).ToString(),
					", Sell ",
					this.countSell(this.firstScript).ToString(),
					Environment.NewLine
				});
			}
			if (this.secondScript.Counter.Count > 0)
			{
				this.secondScript.considered4Pair = true;
				if (this._scriptA == null)
				{
					this._scriptA = new pairTrade.scriptCls();
					this._scriptA = this.secondScript;
				}
				else if (this._scriptB == null)
				{
					this._scriptB = new pairTrade.scriptCls();
					this._scriptB = this.secondScript;
				}
				data = string.Concat(new string[]
				{
					data,
					" ",
					this.secondScript.Name,
					" : Buy ",
					this.countBuy(this.secondScript).ToString(),
					", Sell ",
					this.countSell(this.secondScript).ToString(),
					Environment.NewLine
				});
			}
			if (this.thirdScript.Counter.Count > 0)
			{
				this.thirdScript.considered4Pair = true;
				if (this._scriptA == null)
				{
					this._scriptA = new pairTrade.scriptCls();
					this._scriptA = this.thirdScript;
				}
				else if (this._scriptB == null)
				{
					this._scriptB = new pairTrade.scriptCls();
					this._scriptB = this.thirdScript;
				}
				data = string.Concat(new string[]
				{
					data,
					" ",
					this.thirdScript.Name,
					" : Buy ",
					this.countBuy(this.thirdScript).ToString(),
					", Sell ",
					this.countSell(this.thirdScript).ToString(),
					Environment.NewLine
				});
			}
			return data;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000D424 File Offset: 0x0000B624
		[NullableContext(1)]
		private int countSell(pairTrade.scriptCls _script)
		{
			int sell = 0;
			using (List<int>.Enumerator enumerator = _script.Counter.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current < 0)
					{
						sell++;
					}
				}
			}
			return sell;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000D47C File Offset: 0x0000B67C
		[NullableContext(1)]
		private int countBuy(pairTrade.scriptCls _script)
		{
			int buy = 0;
			using (List<int>.Enumerator enumerator = _script.Counter.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current > 0)
					{
						buy++;
					}
				}
			}
			return buy;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000D4D4 File Offset: 0x0000B6D4
		[NullableContext(1)]
		private string getBuySellReport(pairTrade.scriptCls _greaterScript, pairTrade.scriptCls _lowerScript)
		{
			double _priceRangeGreater = pairTradeHelper.get1SDPriceRange(_greaterScript.futurePrice, _greaterScript.volatility / 100.0);
			double FactorGreater = Math.Round(_priceRangeGreater * 0.382, 2);
			double _priceRangeLower = pairTradeHelper.get1SDPriceRange(_lowerScript.futurePrice, _lowerScript.volatility / 100.0);
			double FactorLower = Math.Round(_priceRangeLower * 0.382, 2);
			string buyHedge = Environment.NewLine + "    & Hedge with a PUT option strike, equal OR less than " + Math.Round(_greaterScript.futurePrice - _priceRangeGreater * 1.236, 0).ToString() + " Strike.";
			string sellHedge = Environment.NewLine + "     & Hedge with a CALL option strike, equal OR greater than " + Math.Round(_lowerScript.futurePrice + _priceRangeLower * 1.236, 0).ToString() + " Strike.";
			string entryStrategy = string.Concat(new string[]
			{
				":Entry ::",
				Environment.NewLine,
				"##Buy ",
				_greaterScript.Name,
				", Range @ ",
				_greaterScript.futurePrice.ToString(),
				" to ",
				Math.Round(_greaterScript.futurePrice + FactorGreater, 2).ToString(),
				", ",
				pairTradeHelper.withOption ? buyHedge : "",
				Environment.NewLine,
				"    Sell ",
				_lowerScript.Name,
				", Range @ ",
				_lowerScript.futurePrice.ToString(),
				" to ",
				(_lowerScript.futurePrice - FactorLower).ToString(),
				" ",
				pairTradeHelper.withOption ? sellHedge : ""
			});
			string existStrategy = string.Concat(new string[]
			{
				":Exit ::",
				Environment.NewLine,
				"##if ",
				_greaterScript.Name,
				" Fall below ",
				Math.Round(_greaterScript.futurePrice - _priceRangeGreater * 0.888, 2).ToString(),
				" -OR- if ",
				_lowerScript.Name,
				" raise above ",
				Math.Round(_lowerScript.futurePrice + _priceRangeLower * 0.888, 2).ToString(),
				" Then Exit the Pair Position."
			});
			return entryStrategy + Environment.NewLine + existStrategy;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000D755 File Offset: 0x0000B955
		private void reset123Counters()
		{
			this.clearCounter(this.firstScript);
			this.clearCounter(this.secondScript);
			this.clearCounter(this.thirdScript);
			this._scriptA = null;
			this._scriptB = null;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000D789 File Offset: 0x0000B989
		[NullableContext(1)]
		private void clearCounter(pairTrade.scriptCls _sCls)
		{
			_sCls.Counter.Clear();
			_sCls.considered4Pair = false;
		}

		// Token: 0x0400015D RID: 349
		[Nullable(1)]
		private ObservableCollection<string> _indexSymbols;

		// Token: 0x0400015E RID: 350
		[Nullable(1)]
		private ObservableCollection<string> _stockSymbols;

		// Token: 0x0400015F RID: 351
		[Nullable(1)]
		private ObservableCollection<string> _expiry;

		// Token: 0x04000160 RID: 352
		[Nullable(1)]
		private readonly string STOCKFUTUREPATH = "https://smartfinance.in/symbols/STK.txt";

		// Token: 0x04000161 RID: 353
		[Nullable(1)]
		private readonly string INDEXPATH = "https://smartfinance.in/symbols/IDX.txt";

		// Token: 0x04000162 RID: 354
		[Nullable(1)]
		private readonly string EXPIRYURL = "https://smartfinance.in/expiry/";

		// Token: 0x04000163 RID: 355
		[Nullable(1)]
		private LiveMarketQuoteCls liveData = new LiveMarketQuoteCls();

		// Token: 0x04000164 RID: 356
		[Nullable(1)]
		public static string EQ_60daysPrice_Url = "https://smartfinance.in/PHPusedForSoftwares/pairTrade/EQ_60daysPrice.php?script={0}";

		// Token: 0x04000165 RID: 357
		[Nullable(1)]
		public static string IDX_60daysPrice_Url = "https://smartfinance.in/PHPusedForSoftwares/pairTrade/IDX_60daysPrice.php?script={0}";

		// Token: 0x04000166 RID: 358
		[Nullable(1)]
		private string selectedInstrument = string.Empty;

		// Token: 0x04000167 RID: 359
		private double symbol1_liveLTP;

		// Token: 0x04000168 RID: 360
		private double symbol2_liveLTP;

		// Token: 0x04000169 RID: 361
		private double symbol3_liveLTP;

		// Token: 0x0400016A RID: 362
		private double symbol1_underlyingPrice;

		// Token: 0x0400016B RID: 363
		private double symbol2_underlyingPrice;

		// Token: 0x0400016C RID: 364
		private double symbol3_underlyingPrice;

		// Token: 0x0400016D RID: 365
		[Nullable(1)]
		private string selectedSymbol1;

		// Token: 0x0400016E RID: 366
		[Nullable(1)]
		private string selectedSymbol2;

		// Token: 0x0400016F RID: 367
		[Nullable(1)]
		private string selectedSymbol3;

		// Token: 0x04000170 RID: 368
		[Nullable(1)]
		private TextBox txtHigh = new TextBox();

		// Token: 0x04000171 RID: 369
		[Nullable(1)]
		private TextBox txtLow = new TextBox();

		// Token: 0x04000172 RID: 370
		[Nullable(1)]
		private pairTrade.scriptCls firstScript;

		// Token: 0x04000173 RID: 371
		[Nullable(1)]
		private pairTrade.scriptCls secondScript;

		// Token: 0x04000174 RID: 372
		[Nullable(1)]
		private pairTrade.scriptCls thirdScript;

		// Token: 0x04000175 RID: 373
		[Nullable(1)]
		private pairTrade.scriptCls _scriptA;

		// Token: 0x04000176 RID: 374
		[Nullable(1)]
		private pairTrade.scriptCls _scriptB;

		// Token: 0x02000060 RID: 96
		[NullableContext(1)]
		[Nullable(0)]
		public class scriptCls
		{
			// Token: 0x17000043 RID: 67
			// (get) Token: 0x06000408 RID: 1032 RVA: 0x0008ADBE File Offset: 0x00088FBE
			// (set) Token: 0x06000409 RID: 1033 RVA: 0x0008ADC6 File Offset: 0x00088FC6
			public string Name { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x0600040A RID: 1034 RVA: 0x0008ADCF File Offset: 0x00088FCF
			// (set) Token: 0x0600040B RID: 1035 RVA: 0x0008ADD7 File Offset: 0x00088FD7
			public bool considered4Pair { get; set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x0600040C RID: 1036 RVA: 0x0008ADE0 File Offset: 0x00088FE0
			// (set) Token: 0x0600040D RID: 1037 RVA: 0x0008ADE8 File Offset: 0x00088FE8
			public double futurePrice { get; set; }

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x0600040E RID: 1038 RVA: 0x0008ADF1 File Offset: 0x00088FF1
			// (set) Token: 0x0600040F RID: 1039 RVA: 0x0008ADF9 File Offset: 0x00088FF9
			public double volatility { get; set; }

			// Token: 0x0400127A RID: 4730
			public List<int> Counter = new List<int>();
		}
	}
}
