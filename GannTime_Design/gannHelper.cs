using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using HtmlAgilityPack;
using siteDownLoadHelper;

namespace New_SF_IT.GannTime_Design
{
	// Token: 0x02000032 RID: 50
	[NullableContext(1)]
	[Nullable(0)]
	internal class gannHelper
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00033CCC File Offset: 0x00031ECC
		public static List<string> _60daysLTPfromDB(string Symbol, string url)
		{
			List<string> downloadedData = new List<string>();
			if (gannHelper.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, Symbol))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					downloadedData.Add(data);
				}
			}
			return downloadedData;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00033D0D File Offset: 0x00031F0D
		public static List<string> splitData(string Data, string Surl)
		{
			return new List<string>(Data.Split(',', StringSplitOptions.None));
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00033D20 File Offset: 0x00031F20
		public static double Volatility(List<double> _sym_PriceList)
		{
			int i = 1;
			double sumA = 0.0;
			double sumB = 0.0;
			int count = _sym_PriceList.Count;
			while (i < count)
			{
				double valueA = Math.Log(Convert.ToDouble(_sym_PriceList[i]) / Convert.ToDouble(_sym_PriceList[i - 1]));
				double valueB = Math.Pow(valueA, 2.0);
				sumA += valueA;
				sumB += valueB;
				i++;
			}
			double avgA = sumA / (double)(count - 1);
			return Math.Sqrt(sumB / (double)(count - 1) - Math.Pow(avgA, 2.0));
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00033DD8 File Offset: 0x00031FD8
		public static double get1SDPriceRange(double _price, double _vola)
		{
			return _price * _vola * Math.Sqrt(1.0) / Math.Sqrt(365.0);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00033DFC File Offset: 0x00031FFC
		public static List<string> get_HighLowFormationDates(int highIndex, int lowIndex, string url)
		{
			List<string> downloadedData = new List<string>();
			if (gannHelper.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, highIndex, lowIndex))).getSite();
				if (data == null)
				{
					MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					data = data.Replace("\r", "");
					if (!string.IsNullOrWhiteSpace(data))
					{
						downloadedData = data.Split(',', StringSplitOptions.None).ToList<string>();
					}
				}
			}
			return downloadedData;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00033E7C File Offset: 0x0003207C
		public static double gannAngle_High_AND_Low(string _symbol, string url, string variable)
		{
			double getData = 0.0;
			if (gannHelper.IsInternetAvailable())
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

		// Token: 0x06000296 RID: 662 RVA: 0x00033F8C File Offset: 0x0003218C
		public static string gannAngle_formationDates(string _symbol, string url, string variable)
		{
			string getData = string.Empty;
			if (gannHelper.IsInternetAvailable())
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
						if (variable == "highFormationDate")
						{
							getData = _htmlDoc.GetElementbyId("highFormationDate").InnerHtml;
						}
						else if (variable == "lowFormationDate")
						{
							getData = _htmlDoc.GetElementbyId("lowFormationDate").InnerHtml;
						}
						else if (variable == "previousHighFormationDate")
						{
							getData = _htmlDoc.GetElementbyId("previousHighFormationDate").InnerHtml;
						}
						else if (variable == "previousLowFormationDate")
						{
							getData = _htmlDoc.GetElementbyId("previousLowFormationDate").InnerHtml;
						}
					}
				}
			}
			return getData;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00034083 File Offset: 0x00032283
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00034090 File Offset: 0x00032290
		public static int gannAngle_tradingDays(string _symbol, string url, string variable)
		{
			int getData = 0;
			if (gannHelper.IsInternetAvailable())
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
						if (variable == "trailingTD")
						{
							getData = Convert.ToInt32(_htmlDoc.GetElementbyId("trailingTD").InnerHtml);
						}
						else if (variable == "previousTD")
						{
							getData = Convert.ToInt32(_htmlDoc.GetElementbyId("previousTD").InnerHtml);
						}
					}
				}
			}
			return getData;
		}
	}
}
