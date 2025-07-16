using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using HtmlAgilityPack;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001B RID: 27
	public partial class Nifty_TopBottom : UserControl
	{
		// Token: 0x0600013B RID: 315 RVA: 0x0000F31C File Offset: 0x0000D51C
		public Nifty_TopBottom()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000F338 File Offset: 0x0000D538
		private void getTheData()
		{
			this.trailingHigh = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingHigh");
			this.trailingLow = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingLow");
			this.previousHigh = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousHigh");
			this.previousLow = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousLow");
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000F3AD File Offset: 0x0000D5AD
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000F3BC File Offset: 0x0000D5BC
		[NullableContext(1)]
		public static double nifty_High_AND_Low(string _symbol, string url, string variable)
		{
			double getData = 0.0;
			if (Nifty_TopBottom.IsInternetAvailable())
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
						else if (variable == "trailingHighVix")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("trailingHighVix").InnerHtml);
						}
						else if (variable == "trailingLowVix")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("trailingLowVix").InnerHtml);
						}
						else if (variable == "previousHigh")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousHigh").InnerHtml);
						}
						else if (variable == "previousLow")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousLow").InnerHtml);
						}
						else if (variable == "previousHighVix")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousHighVix").InnerHtml);
						}
						else if (variable == "previousLowVix")
						{
							getData = Convert.ToDouble(_htmlDoc.GetElementbyId("previousLowVix").InnerHtml);
						}
					}
				}
			}
			return getData;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000F56C File Offset: 0x0000D76C
		private void getVIX_previousMonth(double _previousHigh, double _previousLow, double _previousHighVix, double _previousLowVix)
		{
			double T = 1.0;
			double T2 = 1.272;
			double T3 = 1.618;
			double T4 = 2.0;
			double T5 = 2.618;
			double T6 = 4.237;
			List<double> bottomFibonacciTargets_List = new List<double>();
			bottomFibonacciTargets_List.Add(T);
			bottomFibonacciTargets_List.Add(T2);
			bottomFibonacciTargets_List.Add(T3);
			bottomFibonacciTargets_List.Add(T4);
			bottomFibonacciTargets_List.Add(T5);
			bottomFibonacciTargets_List.Add(T6);
			List<double> topFibonacciTargets_List = new List<double>();
			topFibonacciTargets_List.Add(T);
			topFibonacciTargets_List.Add(T2);
			topFibonacciTargets_List.Add(T3);
			topFibonacciTargets_List.Add(T4);
			topFibonacciTargets_List.Add(T5);
			topFibonacciTargets_List.Add(T6);
			double monthlyVIXforBottom_previousMonth = _previousHighVix / Math.Sqrt(30.0);
			double monthlyVIXforTop_previousMonth = _previousLowVix / Math.Sqrt(30.0);
			this.monthlyPricerangeforBottom_previousMonth = monthlyVIXforBottom_previousMonth * _previousHigh / 100.0;
			this.monthlyPricerangeforTop_previousMonth = monthlyVIXforTop_previousMonth * _previousLow / 100.0;
			double T1_pricerangeforBottom_previousMonth = T * this.monthlyPricerangeforBottom_previousMonth;
			double T2_pricerangeforBottom_previousMonth = T2 * this.monthlyPricerangeforBottom_previousMonth;
			double T3_pricerangeforBottom_previousMonth = T3 * this.monthlyPricerangeforBottom_previousMonth;
			double T4_pricerangeforBottom_previousMonth = T4 * this.monthlyPricerangeforBottom_previousMonth;
			double T5_pricerangeforBottom_previousMonth = T5 * this.monthlyPricerangeforBottom_previousMonth;
			double T6_pricerangeforBottom_previousMonth = T6 * this.monthlyPricerangeforBottom_previousMonth;
			List<double> bottomPriceRangeTargets_List = new List<double>();
			bottomPriceRangeTargets_List.Add(Math.Round(T1_pricerangeforBottom_previousMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T2_pricerangeforBottom_previousMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T3_pricerangeforBottom_previousMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T4_pricerangeforBottom_previousMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T5_pricerangeforBottom_previousMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T6_pricerangeforBottom_previousMonth, 2));
			double T1_pricerangeforTop_previousMonth = T * this.monthlyPricerangeforTop_previousMonth;
			double T2_pricerangeforTop_previousMonth = T2 * this.monthlyPricerangeforTop_previousMonth;
			double T3_pricerangeforTop_previousMonth = T3 * this.monthlyPricerangeforTop_previousMonth;
			double T4_pricerangeforTop_previousMonth = T4 * this.monthlyPricerangeforTop_previousMonth;
			double T5_pricerangeforTop_previousMonth = T5 * this.monthlyPricerangeforTop_previousMonth;
			double T6_pricerangeforTop_previousMonth = T6 * this.monthlyPricerangeforTop_previousMonth;
			List<double> topPriceRange_List = new List<double>();
			topPriceRange_List.Add(Math.Round(T1_pricerangeforTop_previousMonth, 2));
			topPriceRange_List.Add(Math.Round(T2_pricerangeforTop_previousMonth, 2));
			topPriceRange_List.Add(Math.Round(T3_pricerangeforTop_previousMonth, 2));
			topPriceRange_List.Add(Math.Round(T4_pricerangeforTop_previousMonth, 2));
			topPriceRange_List.Add(Math.Round(T5_pricerangeforTop_previousMonth, 2));
			topPriceRange_List.Add(Math.Round(T6_pricerangeforTop_previousMonth, 2));
			double T1_Bottom_previousMonth = _previousHigh - T1_pricerangeforBottom_previousMonth;
			double T2_Bottom_previousMonth = _previousHigh - T2_pricerangeforBottom_previousMonth;
			double T3_Bottom_previousMonth = _previousHigh - T3_pricerangeforBottom_previousMonth;
			double T4_Bottom_previousMonth = _previousHigh - T4_pricerangeforBottom_previousMonth;
			double T5_Bottom_previousMonth = _previousHigh - T5_pricerangeforBottom_previousMonth;
			double T6_Bottom_previousMonth = _previousHigh - T6_pricerangeforBottom_previousMonth;
			List<double> bottomTargets_List = new List<double>();
			bottomTargets_List.Add(Math.Round(T1_Bottom_previousMonth, 2));
			bottomTargets_List.Add(Math.Round(T2_Bottom_previousMonth, 2));
			bottomTargets_List.Add(Math.Round(T3_Bottom_previousMonth, 2));
			bottomTargets_List.Add(Math.Round(T4_Bottom_previousMonth, 2));
			bottomTargets_List.Add(Math.Round(T5_Bottom_previousMonth, 2));
			bottomTargets_List.Add(Math.Round(T6_Bottom_previousMonth, 2));
			double T1_Bottom_MID_previousMonth = (T2_Bottom_previousMonth + T1_Bottom_previousMonth) / 2.0;
			double T2_Bottom_MID_previousMonth = (T3_Bottom_previousMonth + T2_Bottom_previousMonth) / 2.0;
			double T3_Bottom_MID_previousMonth = (T4_Bottom_previousMonth + T3_Bottom_previousMonth) / 2.0;
			double T4_Bottom_MID_previousMonth = (T5_Bottom_previousMonth + T4_Bottom_previousMonth) / 2.0;
			double T5_Bottom_MID_previousMonth = (T6_Bottom_previousMonth + T5_Bottom_previousMonth) / 2.0;
			List<string> bottomMidTargets_List = new List<string>();
			bottomMidTargets_List.Add("");
			bottomMidTargets_List.Add(Math.Round(T1_Bottom_MID_previousMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T2_Bottom_MID_previousMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T3_Bottom_MID_previousMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T4_Bottom_MID_previousMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T5_Bottom_MID_previousMonth, 2).ToString());
			double T1_Top_previousMonth = T1_pricerangeforTop_previousMonth + _previousLow;
			double T2_Top_previousMonth = T2_pricerangeforTop_previousMonth + _previousLow;
			double T3_Top_previousMonth = T3_pricerangeforTop_previousMonth + _previousLow;
			double T4_Top_previousMonth = T4_pricerangeforTop_previousMonth + _previousLow;
			double T5_Top_previousMonth = T5_pricerangeforTop_previousMonth + _previousLow;
			double T6_Top_previousMonth = T6_pricerangeforTop_previousMonth + _previousLow;
			List<double> topTargets_List = new List<double>();
			topTargets_List.Add(Math.Round(T1_Top_previousMonth, 2));
			topTargets_List.Add(Math.Round(T2_Top_previousMonth, 2));
			topTargets_List.Add(Math.Round(T3_Top_previousMonth, 2));
			topTargets_List.Add(Math.Round(T4_Top_previousMonth, 2));
			topTargets_List.Add(Math.Round(T5_Top_previousMonth, 2));
			topTargets_List.Add(Math.Round(T6_Top_previousMonth, 2));
			double T1_Top_MID_previousMonth = (T2_Top_previousMonth + T1_Top_previousMonth) / 2.0;
			double T2_Top_MID_previousMonth = (T3_Top_previousMonth + T2_Top_previousMonth) / 2.0;
			double T3_Top_MID_previousMonth = (T4_Top_previousMonth + T3_Top_previousMonth) / 2.0;
			double T4_Top_MID_previousMonth = (T5_Top_previousMonth + T4_Top_previousMonth) / 2.0;
			double T5_Top_MID_previousMonth = (T6_Top_previousMonth + T5_Top_previousMonth) / 2.0;
			List<string> topMidTargets_List = new List<string>();
			topMidTargets_List.Add("");
			topMidTargets_List.Add(Math.Round(T1_Top_MID_previousMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T2_Top_MID_previousMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T3_Top_MID_previousMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T4_Top_MID_previousMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T5_Top_MID_previousMonth, 2).ToString());
			this.bottomFibonacciTargets.ItemsSource = bottomFibonacciTargets_List;
			this.bottomPriceRangeTargets.ItemsSource = bottomPriceRangeTargets_List;
			this.bottomTargets.ItemsSource = bottomTargets_List;
			this.bottomMidTargets.ItemsSource = bottomMidTargets_List;
			this.topFibonacciTargets.ItemsSource = topFibonacciTargets_List;
			this.topPriceRangeTargets.ItemsSource = topPriceRange_List;
			this.topTargets.ItemsSource = topTargets_List;
			this.topMidTargets.ItemsSource = topMidTargets_List;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000FB00 File Offset: 0x0000DD00
		private void getVIX_trailingMonth(double _trailingHigh, double _trailingLow, double _trailingHighVix, double _trailingLowVix)
		{
			double T = 1.0;
			double T2 = 1.272;
			double T3 = 1.618;
			double T4 = 2.0;
			double T5 = 2.618;
			double T6 = 4.237;
			List<double> bottomFibonacciTargets_List = new List<double>();
			bottomFibonacciTargets_List.Add(T);
			bottomFibonacciTargets_List.Add(T2);
			bottomFibonacciTargets_List.Add(T3);
			bottomFibonacciTargets_List.Add(T4);
			bottomFibonacciTargets_List.Add(T5);
			bottomFibonacciTargets_List.Add(T6);
			List<double> topFibonacciTargets_List = new List<double>();
			topFibonacciTargets_List.Add(T);
			topFibonacciTargets_List.Add(T2);
			topFibonacciTargets_List.Add(T3);
			topFibonacciTargets_List.Add(T4);
			topFibonacciTargets_List.Add(T5);
			topFibonacciTargets_List.Add(T6);
			double monthlyVIXforBottom_trailingMonth = _trailingHighVix / Math.Sqrt(30.0);
			double monthlyVIXforTop_trailingMonth = _trailingLowVix / Math.Sqrt(30.0);
			this.monthlyPricerangeforBottom_trailingMonth = monthlyVIXforBottom_trailingMonth * _trailingHigh / 100.0;
			this.monthlyPricerangeforTop_trailingMonth = monthlyVIXforTop_trailingMonth * _trailingLow / 100.0;
			double T1_pricerangeforBottom_trailingMonth = T * this.monthlyPricerangeforBottom_trailingMonth;
			double T2_pricerangeforBottom_trailingMonth = T2 * this.monthlyPricerangeforBottom_trailingMonth;
			double T3_pricerangeforBottom_trailingMonth = T3 * this.monthlyPricerangeforBottom_trailingMonth;
			double T4_pricerangeforBottom_trailingMonth = T4 * this.monthlyPricerangeforBottom_trailingMonth;
			double T5_pricerangeforBottom_trailingMonth = T5 * this.monthlyPricerangeforBottom_trailingMonth;
			double T6_pricerangeforBottom_trailingMonth = T6 * this.monthlyPricerangeforBottom_trailingMonth;
			List<double> bottomPriceRangeTargets_List = new List<double>();
			bottomPriceRangeTargets_List.Add(Math.Round(T1_pricerangeforBottom_trailingMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T2_pricerangeforBottom_trailingMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T3_pricerangeforBottom_trailingMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T4_pricerangeforBottom_trailingMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T5_pricerangeforBottom_trailingMonth, 2));
			bottomPriceRangeTargets_List.Add(Math.Round(T6_pricerangeforBottom_trailingMonth, 2));
			double T1_pricerangeforTop_trailingMonth = T * this.monthlyPricerangeforTop_trailingMonth;
			double T2_pricerangeforTop_trailingMonth = T2 * this.monthlyPricerangeforTop_trailingMonth;
			double T3_pricerangeforTop_trailingMonth = T3 * this.monthlyPricerangeforTop_trailingMonth;
			double T4_pricerangeforTop_trailingMonth = T4 * this.monthlyPricerangeforTop_trailingMonth;
			double T5_pricerangeforTop_trailingMonth = T5 * this.monthlyPricerangeforTop_trailingMonth;
			double T6_pricerangeforTop_trailingMonth = T6 * this.monthlyPricerangeforTop_trailingMonth;
			List<double> topPriceRange_List = new List<double>();
			topPriceRange_List.Add(Math.Round(T1_pricerangeforTop_trailingMonth, 2));
			topPriceRange_List.Add(Math.Round(T2_pricerangeforTop_trailingMonth, 2));
			topPriceRange_List.Add(Math.Round(T3_pricerangeforTop_trailingMonth, 2));
			topPriceRange_List.Add(Math.Round(T4_pricerangeforTop_trailingMonth, 2));
			topPriceRange_List.Add(Math.Round(T5_pricerangeforTop_trailingMonth, 2));
			topPriceRange_List.Add(Math.Round(T6_pricerangeforTop_trailingMonth, 2));
			double T1_Bottom_trailingMonth = _trailingHigh - T1_pricerangeforBottom_trailingMonth;
			double T2_Bottom_trailingMonth = _trailingHigh - T2_pricerangeforBottom_trailingMonth;
			double T3_Bottom_trailingMonth = _trailingHigh - T3_pricerangeforBottom_trailingMonth;
			double T4_Bottom_trailingMonth = _trailingHigh - T4_pricerangeforBottom_trailingMonth;
			double T5_Bottom_trailingMonth = _trailingHigh - T5_pricerangeforBottom_trailingMonth;
			double T6_Bottom_trailingMonth = _trailingHigh - T6_pricerangeforBottom_trailingMonth;
			List<double> bottomTargets_List = new List<double>();
			bottomTargets_List.Add(Math.Round(T1_Bottom_trailingMonth, 2));
			bottomTargets_List.Add(Math.Round(T2_Bottom_trailingMonth, 2));
			bottomTargets_List.Add(Math.Round(T3_Bottom_trailingMonth, 2));
			bottomTargets_List.Add(Math.Round(T4_Bottom_trailingMonth, 2));
			bottomTargets_List.Add(Math.Round(T5_Bottom_trailingMonth, 2));
			bottomTargets_List.Add(Math.Round(T6_Bottom_trailingMonth, 2));
			double T1_Bottom_MID_trailingMonth = (T2_Bottom_trailingMonth + T1_Bottom_trailingMonth) / 2.0;
			double T2_Bottom_MID_trailingMonth = (T3_Bottom_trailingMonth + T2_Bottom_trailingMonth) / 2.0;
			double T3_Bottom_MID_trailingMonth = (T4_Bottom_trailingMonth + T3_Bottom_trailingMonth) / 2.0;
			double T4_Bottom_MID_trailingMonth = (T5_Bottom_trailingMonth + T4_Bottom_trailingMonth) / 2.0;
			double T5_Bottom_MID_trailingMonth = (T6_Bottom_trailingMonth + T5_Bottom_trailingMonth) / 2.0;
			List<string> bottomMidTargets_List = new List<string>();
			bottomMidTargets_List.Add("");
			bottomMidTargets_List.Add(Math.Round(T1_Bottom_MID_trailingMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T2_Bottom_MID_trailingMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T3_Bottom_MID_trailingMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T4_Bottom_MID_trailingMonth, 2).ToString());
			bottomMidTargets_List.Add(Math.Round(T5_Bottom_MID_trailingMonth, 2).ToString());
			double T1_Top_trailingMonth = T1_pricerangeforTop_trailingMonth + _trailingLow;
			double T2_Top_trailingMonth = T2_pricerangeforTop_trailingMonth + _trailingLow;
			double T3_Top_trailingMonth = T3_pricerangeforTop_trailingMonth + _trailingLow;
			double T4_Top_trailingMonth = T4_pricerangeforTop_trailingMonth + _trailingLow;
			double T5_Top_trailingMonth = T5_pricerangeforTop_trailingMonth + _trailingLow;
			double T6_Top_trailingMonth = T6_pricerangeforTop_trailingMonth + _trailingLow;
			List<double> topTargets_List = new List<double>();
			topTargets_List.Add(Math.Round(T1_Top_trailingMonth, 2));
			topTargets_List.Add(Math.Round(T2_Top_trailingMonth, 2));
			topTargets_List.Add(Math.Round(T3_Top_trailingMonth, 2));
			topTargets_List.Add(Math.Round(T4_Top_trailingMonth, 2));
			topTargets_List.Add(Math.Round(T5_Top_trailingMonth, 2));
			topTargets_List.Add(Math.Round(T6_Top_trailingMonth, 2));
			double T1_Top_MID_trailingMonth = (T2_Top_trailingMonth + T1_Top_trailingMonth) / 2.0;
			double T2_Top_MID_trailingMonth = (T3_Top_trailingMonth + T2_Top_trailingMonth) / 2.0;
			double T3_Top_MID_trailingMonth = (T4_Top_trailingMonth + T3_Top_trailingMonth) / 2.0;
			double T4_Top_MID_trailingMonth = (T5_Top_trailingMonth + T4_Top_trailingMonth) / 2.0;
			double T5_Top_MID_trailingMonth = (T6_Top_trailingMonth + T5_Top_trailingMonth) / 2.0;
			List<string> topMidTargets_List = new List<string>();
			topMidTargets_List.Add("");
			topMidTargets_List.Add(Math.Round(T1_Top_MID_trailingMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T2_Top_MID_trailingMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T3_Top_MID_trailingMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T4_Top_MID_trailingMonth, 2).ToString());
			topMidTargets_List.Add(Math.Round(T5_Top_MID_trailingMonth, 2).ToString());
			this.bottomFibonacciTargets.ItemsSource = bottomFibonacciTargets_List;
			this.bottomPriceRangeTargets.ItemsSource = bottomPriceRangeTargets_List;
			this.bottomTargets.ItemsSource = bottomTargets_List;
			this.bottomMidTargets.ItemsSource = bottomMidTargets_List;
			this.topFibonacciTargets.ItemsSource = topFibonacciTargets_List;
			this.topPriceRangeTargets.ItemsSource = topPriceRange_List;
			this.topTargets.ItemsSource = topTargets_List;
			this.topMidTargets.ItemsSource = topMidTargets_List;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00010094 File Offset: 0x0000E294
		private void getVIX_trailingMonth_OLD()
		{
			double num = 1.0;
			double T2 = 1.272;
			double T3 = 1.618;
			double T4 = 2.0;
			double T5 = 2.618;
			double T6 = 4.237;
			double trailingMonth_High = 17353.35;
			double trailingMonth_Low = 15671.45;
			double num2 = 33.9725;
			double trailingMonth_Low_VIX = 20.57;
			double num3 = num2 / Math.Sqrt(30.0);
			double monthlyVIXforTop_trailingMonth = trailingMonth_Low_VIX / Math.Sqrt(30.0);
			double monthlyPricerangeforBottom_trailingMonth = num3 * trailingMonth_High / 100.0;
			double monthlyPricerangeforTop_trailingMonth = monthlyVIXforTop_trailingMonth * trailingMonth_Low / 100.0;
			double T1_pricerangeforBottom_trailingMonth = num * monthlyPricerangeforBottom_trailingMonth;
			double T2_pricerangeforBottom_trailingMonth = T2 * monthlyPricerangeforBottom_trailingMonth;
			double T3_pricerangeforBottom_trailingMonth = T3 * monthlyPricerangeforBottom_trailingMonth;
			double T4_pricerangeforBottom_trailingMonth = T4 * monthlyPricerangeforBottom_trailingMonth;
			double T5_pricerangeforBottom_trailingMonth = T5 * monthlyPricerangeforBottom_trailingMonth;
			double T6_pricerangeforBottom_trailingMonth = T6 * monthlyPricerangeforBottom_trailingMonth;
			double num4 = num * monthlyPricerangeforTop_trailingMonth;
			double T2_pricerangeforTop_trailingMonth = T2 * monthlyPricerangeforTop_trailingMonth;
			double T3_pricerangeforTop_trailingMonth = T3 * monthlyPricerangeforTop_trailingMonth;
			double T4_pricerangeforTop_trailingMonth = T4 * monthlyPricerangeforTop_trailingMonth;
			double T5_pricerangeforTop_trailingMonth = T5 * monthlyPricerangeforTop_trailingMonth;
			double T6_pricerangeforTop_trailingMonth = T6 * monthlyPricerangeforTop_trailingMonth;
			double T1_Bottom_trailingMonth = trailingMonth_High - T1_pricerangeforBottom_trailingMonth;
			double T2_Bottom_trailingMonth = trailingMonth_High - T2_pricerangeforBottom_trailingMonth;
			double T3_Bottom_trailingMonth = trailingMonth_High - T3_pricerangeforBottom_trailingMonth;
			double T4_Bottom_trailingMonth = trailingMonth_High - T4_pricerangeforBottom_trailingMonth;
			double T5_Bottom_trailingMonth = trailingMonth_High - T5_pricerangeforBottom_trailingMonth;
			double num5 = trailingMonth_High - T6_pricerangeforBottom_trailingMonth;
			double num6 = (T2_Bottom_trailingMonth + T1_Bottom_trailingMonth) / 2.0;
			double num7 = (T3_Bottom_trailingMonth + T2_Bottom_trailingMonth) / 2.0;
			double num8 = (T4_Bottom_trailingMonth + T3_Bottom_trailingMonth) / 2.0;
			double num9 = (T5_Bottom_trailingMonth + T4_Bottom_trailingMonth) / 2.0;
			double num10 = (num5 + T5_Bottom_trailingMonth) / 2.0;
			double T1_Top_trailingMonth = num4 + trailingMonth_Low;
			double T2_Top_trailingMonth = T2_pricerangeforTop_trailingMonth + trailingMonth_Low;
			double T3_Top_trailingMonth = T3_pricerangeforTop_trailingMonth + trailingMonth_Low;
			double T4_Top_trailingMonth = T4_pricerangeforTop_trailingMonth + trailingMonth_Low;
			double T5_Top_trailingMonth = T5_pricerangeforTop_trailingMonth + trailingMonth_Low;
			double num11 = T6_pricerangeforTop_trailingMonth + trailingMonth_Low;
			double num12 = (T2_Top_trailingMonth + T1_Top_trailingMonth) / 2.0;
			double num13 = (T3_Top_trailingMonth + T2_Top_trailingMonth) / 2.0;
			double num14 = (T4_Top_trailingMonth + T3_Top_trailingMonth) / 2.0;
			double num15 = (T5_Top_trailingMonth + T4_Top_trailingMonth) / 2.0;
			double num16 = (num11 + T5_Top_trailingMonth) / 2.0;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0001027A File Offset: 0x0000E47A
		[NullableContext(1)]
		private void scroll_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0001027C File Offset: 0x0000E47C
		[NullableContext(1)]
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.selectedItem_text = ((e.AddedItems[0] as ComboBoxItem).Content as string);
			if (this.topTargets != null)
			{
				this.topTargets.ItemsSource = null;
			}
			if (this.topMidTargets != null)
			{
				this.topMidTargets.ItemsSource = null;
			}
			if (this.bottomTargets != null)
			{
				this.bottomTargets.ItemsSource = null;
			}
			if (this.bottomMidTargets != null)
			{
				this.bottomMidTargets.ItemsSource = null;
			}
			if (this.topReversalTargets != null)
			{
				this.topReversalTargets.ItemsSource = null;
			}
			if (this.bottomReversalTargets != null)
			{
				this.bottomReversalTargets.ItemsSource = null;
			}
			if (this.topPriceRangeTargets != null)
			{
				this.topPriceRangeTargets.ItemsSource = null;
			}
			if (this.topReversalPriceRangeTargets != null)
			{
				this.topReversalPriceRangeTargets.ItemsSource = null;
			}
			if (this.bottomPriceRangeTargets != null)
			{
				this.bottomPriceRangeTargets.ItemsSource = null;
			}
			if (this.bottomReversalPriceRangeTargets != null)
			{
				this.bottomReversalPriceRangeTargets.ItemsSource = null;
			}
			if (this.refPriceHigh != null)
			{
				this.refPriceHigh.Content = "";
				this.refPriceLow.Content = "";
				this.refVixHigh.Content = "";
				this.refVixLow.Content = "";
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000103BC File Offset: 0x0000E5BC
		[NullableContext(1)]
		private void load_Click(object sender, RoutedEventArgs e)
		{
			if (this.selectedItem_text == "Previous Month")
			{
				this.previousHigh = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousHigh");
				this.previousLow = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousLow");
				this.previousHighVix = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousHighVix");
				this.previousLowVix = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "previousLowVix");
				this.getVIX_previousMonth(this.previousHigh, this.previousLow, this.previousHighVix, this.previousLowVix);
				this.refPriceHigh.Content = "High: " + this.previousHigh.ToString();
				this.refPriceLow.Content = "Low: " + this.previousLow.ToString();
				this.refVixHigh.Content = "High: " + this.previousHighVix.ToString();
				this.refVixLow.Content = "Low: " + this.previousLowVix.ToString();
				this.refPriceBox.Visibility = Visibility.Visible;
				this.refVixBox.Visibility = Visibility.Visible;
				return;
			}
			if (this.selectedItem_text == "Trailing One Month")
			{
				this.trailingHigh = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingHigh");
				this.trailingLow = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingLow");
				this.trailingHighVix = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingHighVix");
				this.trailingLowVix = Nifty_TopBottom.nifty_High_AND_Low("NIFTY", Nifty_TopBottom.IndexDataDownload_URL, "trailingLowVix");
				this.getVIX_trailingMonth(this.trailingHigh, this.trailingLow, this.trailingHighVix, this.trailingLowVix);
				this.refPriceHigh.Content = "High: " + this.trailingHigh.ToString();
				this.refPriceLow.Content = "Low: " + this.trailingLow.ToString();
				this.refVixHigh.Content = "High: " + this.trailingHighVix.ToString();
				this.refVixLow.Content = "Low: " + this.trailingLowVix.ToString();
				this.refPriceBox.Visibility = Visibility.Visible;
				this.refVixBox.Visibility = Visibility.Visible;
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00010630 File Offset: 0x0000E830
		[NullableContext(1)]
		private void bottomTargets_Click(object sender, EventArgs e)
		{
			this.bottomTargets.FontWeight = FontWeights.Normal;
			object firstSelectedItem = this.bottomTargets.SelectedItems[0];
			this.bottomReversalCalc(Convert.ToDouble(firstSelectedItem));
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0001066C File Offset: 0x0000E86C
		[NullableContext(1)]
		private void bottomMidTargets_Click(object sender, EventArgs e)
		{
			object firstSelectedItem = this.bottomMidTargets.SelectedItems[0];
			this.bottomReversalCalc(Convert.ToDouble(firstSelectedItem));
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00010698 File Offset: 0x0000E898
		private void bottomReversalCalc(double selectedTargetPrice)
		{
			double T = 0.236;
			double T2 = 0.382;
			double T3 = 0.5;
			double T4 = 0.618;
			double T5 = 0.786;
			double T6 = 0.888;
			double T7 = 1.236;
			double T8 = 1.618;
			double T9 = 2.0;
			List<double> bottomFibonacciTargets_List = new List<double>();
			bottomFibonacciTargets_List.Add(T);
			bottomFibonacciTargets_List.Add(T2);
			bottomFibonacciTargets_List.Add(T3);
			bottomFibonacciTargets_List.Add(T4);
			bottomFibonacciTargets_List.Add(T5);
			bottomFibonacciTargets_List.Add(T6);
			bottomFibonacciTargets_List.Add(T7);
			bottomFibonacciTargets_List.Add(T8);
			bottomFibonacciTargets_List.Add(T9);
			if (this.selectedItem_text == "Previous Month")
			{
				double T1_pricerangeforBottom_previousMonth = T * this.monthlyPricerangeforBottom_previousMonth;
				double T2_pricerangeforBottom_previousMonth = T2 * this.monthlyPricerangeforBottom_previousMonth;
				double T3_pricerangeforBottom_previousMonth = T3 * this.monthlyPricerangeforBottom_previousMonth;
				double T4_pricerangeforBottom_previousMonth = T4 * this.monthlyPricerangeforBottom_previousMonth;
				double T5_pricerangeforBottom_previousMonth = T5 * this.monthlyPricerangeforBottom_previousMonth;
				double T6_pricerangeforBottom_previousMonth = T6 * this.monthlyPricerangeforBottom_previousMonth;
				double T7_pricerangeforBottom_previousMonth = T7 * this.monthlyPricerangeforBottom_previousMonth;
				double T8_pricerangeforBottom_previousMonth = T8 * this.monthlyPricerangeforBottom_previousMonth;
				double T9_pricerangeforBottom_previousMonth = T9 * this.monthlyPricerangeforBottom_previousMonth;
				List<double> bottomPriceRangeTargets_List = new List<double>();
				bottomPriceRangeTargets_List.Add(Math.Round(T1_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T2_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T3_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T4_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T5_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T6_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T7_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T8_pricerangeforBottom_previousMonth, 2));
				bottomPriceRangeTargets_List.Add(Math.Round(T9_pricerangeforBottom_previousMonth, 2));
				double T1_bottomReversals_previousMonth = T1_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T2_bottomReversals_previousMonth = T2_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T3_bottomReversals_previousMonth = T3_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T4_bottomReversals_previousMonth = T4_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T5_bottomReversals_previousMonth = T5_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T6_bottomReversals_previousMonth = T6_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T7_bottomReversals_previousMonth = T7_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T8_bottomReversals_previousMonth = T8_pricerangeforBottom_previousMonth + selectedTargetPrice;
				double T9_bottomReversals_previousMonth = T9_pricerangeforBottom_previousMonth + selectedTargetPrice;
				List<double> reversalTargets_List = new List<double>();
				reversalTargets_List.Add(Math.Round(T1_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T2_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T3_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T4_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T5_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T6_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T7_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T8_bottomReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T9_bottomReversals_previousMonth, 2));
				this.bottomReversalFibonacciTargets.ItemsSource = bottomFibonacciTargets_List;
				this.bottomReversalPriceRangeTargets.ItemsSource = bottomPriceRangeTargets_List;
				this.bottomReversalTargets.ItemsSource = reversalTargets_List;
				return;
			}
			if (this.selectedItem_text == "Trailing One Month")
			{
				double T1_pricerangeforBottom_trailingMonth = T * this.monthlyPricerangeforBottom_trailingMonth;
				double T2_pricerangeforBottom_trailingMonth = T2 * this.monthlyPricerangeforBottom_trailingMonth;
				double T3_pricerangeforBottom_trailingMonth = T3 * this.monthlyPricerangeforBottom_trailingMonth;
				double T4_pricerangeforBottom_trailingMonth = T4 * this.monthlyPricerangeforBottom_trailingMonth;
				double T5_pricerangeforBottom_trailingMonth = T5 * this.monthlyPricerangeforBottom_trailingMonth;
				double T6_pricerangeforBottom_trailingMonth = T6 * this.monthlyPricerangeforBottom_trailingMonth;
				double T7_pricerangeforBottom_trailingMonth = T7 * this.monthlyPricerangeforBottom_trailingMonth;
				double T8_pricerangeforBottom_trailingMonth = T8 * this.monthlyPricerangeforBottom_trailingMonth;
				double T9_pricerangeforBottom_trailingMonth = T9 * this.monthlyPricerangeforBottom_trailingMonth;
				List<double> bottomPriceRangeTargets_List2 = new List<double>();
				bottomPriceRangeTargets_List2.Add(Math.Round(T1_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T2_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T3_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T4_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T5_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T6_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T7_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T8_pricerangeforBottom_trailingMonth, 2));
				bottomPriceRangeTargets_List2.Add(Math.Round(T9_pricerangeforBottom_trailingMonth, 2));
				double T1_bottomReversals_trailingMonth = T1_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T2_bottomReversals_trailingMonth = T2_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T3_bottomReversals_trailingMonth = T3_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T4_bottomReversals_trailingMonth = T4_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T5_bottomReversals_trailingMonth = T5_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T6_bottomReversals_trailingMonth = T6_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T7_bottomReversals_trailingMonth = T7_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T8_bottomReversals_trailingMonth = T8_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				double T9_bottomReversals_trailingMonth = T9_pricerangeforBottom_trailingMonth + selectedTargetPrice;
				List<double> reversalTargets_List2 = new List<double>();
				reversalTargets_List2.Add(Math.Round(T1_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T2_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T3_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T4_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T5_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T6_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T7_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T8_bottomReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T9_bottomReversals_trailingMonth, 2));
				this.bottomReversalFibonacciTargets.ItemsSource = bottomFibonacciTargets_List;
				this.bottomReversalPriceRangeTargets.ItemsSource = bottomPriceRangeTargets_List2;
				this.bottomReversalTargets.ItemsSource = reversalTargets_List2;
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00010B34 File Offset: 0x0000ED34
		[NullableContext(1)]
		private void topTargets_Click(object sender, EventArgs e)
		{
			object firstSelectedItem = this.topTargets.SelectedItems[0];
			this.topReversalCalc(Convert.ToDouble(firstSelectedItem));
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00010B60 File Offset: 0x0000ED60
		[NullableContext(1)]
		private void topMidTargets_Click(object sender, EventArgs e)
		{
			object firstSelectedItem = this.topMidTargets.SelectedItems[0];
			this.topReversalCalc(Convert.ToDouble(firstSelectedItem));
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00010B8C File Offset: 0x0000ED8C
		private void topReversalCalc(double selectedTargetPrice)
		{
			double T = 0.236;
			double T2 = 0.382;
			double T3 = 0.5;
			double T4 = 0.618;
			double T5 = 0.786;
			double T6 = 0.888;
			double T7 = 1.236;
			double T8 = 1.618;
			double T9 = 2.0;
			List<double> topFibonacciTargets_List = new List<double>();
			topFibonacciTargets_List.Add(T);
			topFibonacciTargets_List.Add(T2);
			topFibonacciTargets_List.Add(T3);
			topFibonacciTargets_List.Add(T4);
			topFibonacciTargets_List.Add(T5);
			topFibonacciTargets_List.Add(T6);
			topFibonacciTargets_List.Add(T7);
			topFibonacciTargets_List.Add(T8);
			topFibonacciTargets_List.Add(T9);
			if (this.selectedItem_text == "Previous Month")
			{
				double T1_pricerangefortop_previousMonth = T * this.monthlyPricerangeforTop_previousMonth;
				double T2_pricerangefortop_previousMonth = T2 * this.monthlyPricerangeforTop_previousMonth;
				double T3_pricerangefortop_previousMonth = T3 * this.monthlyPricerangeforTop_previousMonth;
				double T4_pricerangefortop_previousMonth = T4 * this.monthlyPricerangeforTop_previousMonth;
				double T5_pricerangefortop_previousMonth = T5 * this.monthlyPricerangeforTop_previousMonth;
				double T6_pricerangefortop_previousMonth = T6 * this.monthlyPricerangeforTop_previousMonth;
				double T7_pricerangefortop_previousMonth = T7 * this.monthlyPricerangeforTop_previousMonth;
				double T8_pricerangefortop_previousMonth = T8 * this.monthlyPricerangeforTop_previousMonth;
				double T9_pricerangefortop_previousMonth = T9 * this.monthlyPricerangeforTop_previousMonth;
				List<double> topPriceRangeTargets_List = new List<double>();
				topPriceRangeTargets_List.Add(Math.Round(T1_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T2_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T3_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T4_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T5_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T6_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T7_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T8_pricerangefortop_previousMonth, 2));
				topPriceRangeTargets_List.Add(Math.Round(T9_pricerangefortop_previousMonth, 2));
				double T1_topReversals_previousMonth = selectedTargetPrice - T1_pricerangefortop_previousMonth;
				double T2_topReversals_previousMonth = selectedTargetPrice - T2_pricerangefortop_previousMonth;
				double T3_topReversals_previousMonth = selectedTargetPrice - T3_pricerangefortop_previousMonth;
				double T4_topReversals_previousMonth = selectedTargetPrice - T4_pricerangefortop_previousMonth;
				double T5_topReversals_previousMonth = selectedTargetPrice - T5_pricerangefortop_previousMonth;
				double T6_topReversals_previousMonth = selectedTargetPrice - T6_pricerangefortop_previousMonth;
				double T7_topReversals_previousMonth = selectedTargetPrice - T7_pricerangefortop_previousMonth;
				double T8_topReversals_previousMonth = selectedTargetPrice - T8_pricerangefortop_previousMonth;
				double T9_topReversals_previousMonth = selectedTargetPrice - T9_pricerangefortop_previousMonth;
				List<double> reversalTargets_List = new List<double>();
				reversalTargets_List.Add(Math.Round(T1_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T2_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T3_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T4_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T5_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T6_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T7_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T8_topReversals_previousMonth, 2));
				reversalTargets_List.Add(Math.Round(T9_topReversals_previousMonth, 2));
				this.topReversalFibonacciTargets.ItemsSource = topFibonacciTargets_List;
				this.topReversalPriceRangeTargets.ItemsSource = topPriceRangeTargets_List;
				this.topReversalTargets.ItemsSource = reversalTargets_List;
				return;
			}
			if (this.selectedItem_text == "Trailing One Month")
			{
				double T1_pricerangefortop_trailingMonth = T * this.monthlyPricerangeforTop_trailingMonth;
				double T2_pricerangefortop_trailingMonth = T2 * this.monthlyPricerangeforTop_trailingMonth;
				double T3_pricerangefortop_trailingMonth = T3 * this.monthlyPricerangeforTop_trailingMonth;
				double T4_pricerangefortop_trailingMonth = T4 * this.monthlyPricerangeforTop_trailingMonth;
				double T5_pricerangefortop_trailingMonth = T5 * this.monthlyPricerangeforTop_trailingMonth;
				double T6_pricerangefortop_trailingMonth = T6 * this.monthlyPricerangeforTop_trailingMonth;
				double T7_pricerangefortop_trailingMonth = T7 * this.monthlyPricerangeforTop_trailingMonth;
				double T8_pricerangefortop_trailingMonth = T8 * this.monthlyPricerangeforTop_trailingMonth;
				double T9_pricerangefortop_trailingMonth = T9 * this.monthlyPricerangeforTop_trailingMonth;
				List<double> topPriceRangeTargets_List2 = new List<double>();
				topPriceRangeTargets_List2.Add(Math.Round(T1_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T2_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T3_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T4_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T5_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T6_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T7_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T8_pricerangefortop_trailingMonth, 2));
				topPriceRangeTargets_List2.Add(Math.Round(T9_pricerangefortop_trailingMonth, 2));
				double T1_topReversals_trailingMonth = selectedTargetPrice - T1_pricerangefortop_trailingMonth;
				double T2_topReversals_trailingMonth = selectedTargetPrice - T2_pricerangefortop_trailingMonth;
				double T3_topReversals_trailingMonth = selectedTargetPrice - T3_pricerangefortop_trailingMonth;
				double T4_topReversals_trailingMonth = selectedTargetPrice - T4_pricerangefortop_trailingMonth;
				double T5_topReversals_trailingMonth = selectedTargetPrice - T5_pricerangefortop_trailingMonth;
				double T6_topReversals_trailingMonth = selectedTargetPrice - T6_pricerangefortop_trailingMonth;
				double T7_topReversals_trailingMonth = selectedTargetPrice - T7_pricerangefortop_trailingMonth;
				double T8_topReversals_trailingMonth = selectedTargetPrice - T8_pricerangefortop_trailingMonth;
				double T9_topReversals_trailingMonth = selectedTargetPrice - T9_pricerangefortop_trailingMonth;
				List<double> reversalTargets_List2 = new List<double>();
				reversalTargets_List2.Add(Math.Round(T1_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T2_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T3_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T4_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T5_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T6_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T7_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T8_topReversals_trailingMonth, 2));
				reversalTargets_List2.Add(Math.Round(T9_topReversals_trailingMonth, 2));
				this.topReversalFibonacciTargets.ItemsSource = topFibonacciTargets_List;
				this.topReversalPriceRangeTargets.ItemsSource = topPriceRangeTargets_List2;
				this.topReversalTargets.ItemsSource = reversalTargets_List2;
			}
		}

		// Token: 0x040001D6 RID: 470
		[Nullable(1)]
		public static string IndexDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/IT/vixIndexDataDownload.php?symbol={0}";

		// Token: 0x040001D7 RID: 471
		private double trailingHigh;

		// Token: 0x040001D8 RID: 472
		private double trailingLow;

		// Token: 0x040001D9 RID: 473
		private double trailingHighVix;

		// Token: 0x040001DA RID: 474
		private double trailingLowVix;

		// Token: 0x040001DB RID: 475
		private double previousHigh;

		// Token: 0x040001DC RID: 476
		private double previousLow;

		// Token: 0x040001DD RID: 477
		private double previousHighVix;

		// Token: 0x040001DE RID: 478
		private double previousLowVix;

		// Token: 0x040001DF RID: 479
		[Nullable(1)]
		private string selectedItem_text = string.Empty;

		// Token: 0x040001E0 RID: 480
		private double monthlyPricerangeforBottom_previousMonth;

		// Token: 0x040001E1 RID: 481
		private double monthlyPricerangeforTop_previousMonth;

		// Token: 0x040001E2 RID: 482
		private double monthlyPricerangeforBottom_trailingMonth;

		// Token: 0x040001E3 RID: 483
		private double monthlyPricerangeforTop_trailingMonth;
	}
}
