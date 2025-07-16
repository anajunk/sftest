using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001D RID: 29
	[NullableContext(1)]
	[Nullable(0)]
	internal class StocksBasedVolatility
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00013FC4 File Offset: 0x000121C4
		public static void getStocksBasedOnVolatility()
		{
			StocksBasedVolatility.symbolList = new List<string>();
			new List<string>();
			StocksBasedVolatility.volatility_Rise = new Dictionary<string, double>();
			StocksBasedVolatility.volatility_Fall = new Dictionary<string, double>();
			StocksBasedVolatility.volatility_NoChange = new Dictionary<string, double>();
			List<string> DBsymbols = new List<string>();
			DBsymbols = StocksBasedVolatility.dataDownload("", StocksBasedVolatility.symbolsURL);
			if (DBsymbols.Any<string>())
			{
				string text = string.Join("", DBsymbols.ToArray());
				StocksBasedVolatility.symbolList = StocksBasedVolatility.splitData(text.Remove(text.Length - 1), StocksBasedVolatility.symbolsURL);
				StocksBasedVolatility.symbolList.Add("BANKNIFTY");
				StocksBasedVolatility.symbolList.Add("NIFTY");
				StocksBasedVolatility.symbolList.Add("FINNIFTY");
			}
			string[] _11dayDataArray = StocksBasedVolatility._11dayDataInArray(StocksBasedVolatility._leading11daysLtpUrl);
			string[] _trailing11dayDataArray = StocksBasedVolatility._11dayDataInArray(StocksBasedVolatility._trailing11daysLtpUrl);
			string[] _11dayDataArray_IDX = StocksBasedVolatility._11dayDataInArray(StocksBasedVolatility._leading11daysLtpUrl_IDX);
			string[] _trailing11dayDataArray_IDX = StocksBasedVolatility._11dayDataInArray(StocksBasedVolatility._trailing11daysLtpUrl_IDX);
			string[] y = new string[_11dayDataArray.Length + _11dayDataArray_IDX.Length];
			_11dayDataArray.CopyTo(y, 0);
			_11dayDataArray_IDX.CopyTo(y, _11dayDataArray.Length);
			_11dayDataArray = y;
			string[] z = new string[_trailing11dayDataArray.Length + _trailing11dayDataArray_IDX.Length];
			_trailing11dayDataArray.CopyTo(z, 0);
			_trailing11dayDataArray_IDX.CopyTo(z, _trailing11dayDataArray.Length);
			_trailing11dayDataArray = z;
			for (int index = 0; index <= StocksBasedVolatility.symbolList.Count - 1; index++)
			{
				string symbolNow = StocksBasedVolatility.symbolList.ElementAt(index);
				double volatility = StocksBasedVolatility.get_Volatility(StocksBasedVolatility.get_11dayLTPforVolaCalc(_11dayDataArray.ElementAt(index)));
				volatility = ((volatility >= 100.0) ? (volatility / 5.0) : volatility);
				double volatility2 = StocksBasedVolatility.get_Volatility(StocksBasedVolatility.get_11dayLTPforVolaCalc(_trailing11dayDataArray.ElementAt(index)));
				volatility2 = ((volatility2 >= 100.0) ? (volatility2 / 5.0) : volatility2);
				if (volatility > volatility2 + volatility2 * 0.01)
				{
					if (symbolNow == "NIFTY")
					{
						StocksBasedVolatility.niftyVola = string.Empty;
						StocksBasedVolatility.niftyVola = "Volatility of NIFTY : " + volatility.ToString().Substring(0, 6) + " (Rise in Volatility)";
					}
					else if (symbolNow == "BANKNIFTY")
					{
						StocksBasedVolatility.bankniftyVola = string.Empty;
						StocksBasedVolatility.bankniftyVola = "Volatility of BANKNIFTY : " + volatility.ToString().Substring(0, 6) + " (Rise in Volatility)";
					}
					else if (symbolNow == "FINNIFTY")
					{
						StocksBasedVolatility.finniftyVola = string.Empty;
						StocksBasedVolatility.finniftyVola = "Volatility of FINNIFTY : " + volatility.ToString().Substring(0, 6) + " (Rise in Volatility)";
					}
					else
					{
						StocksBasedVolatility.volatility_Rise.Add(symbolNow, volatility);
					}
				}
				else if (volatility < volatility2 - volatility2 * 0.01)
				{
					if (symbolNow == "NIFTY")
					{
						StocksBasedVolatility.niftyVola = string.Empty;
						StocksBasedVolatility.niftyVola = "Volatility of NIFTY : " + volatility.ToString().Substring(0, 6) + " (Fall in Volatility)";
					}
					else if (symbolNow == "BANKNIFTY")
					{
						StocksBasedVolatility.bankniftyVola = string.Empty;
						StocksBasedVolatility.bankniftyVola = "Volatility of BANKNIFTY : " + volatility.ToString().Substring(0, 6) + " (Fall in Volatility)";
					}
					else if (symbolNow == "FINNIFTY")
					{
						StocksBasedVolatility.finniftyVola = string.Empty;
						StocksBasedVolatility.finniftyVola = "Volatility of FINNIFTY : " + volatility.ToString().Substring(0, 6) + " (Fall in Volatility)";
					}
					else
					{
						StocksBasedVolatility.volatility_Fall.Add(symbolNow, volatility);
					}
				}
				else if (symbolNow == "NIFTY")
				{
					StocksBasedVolatility.niftyVola = string.Empty;
					StocksBasedVolatility.niftyVola = "Volatility of NIFTY : " + volatility.ToString().Substring(0, 6) + " (No Change in Volatility)";
				}
				else if (symbolNow == "BANKNIFTY")
				{
					StocksBasedVolatility.bankniftyVola = string.Empty;
					StocksBasedVolatility.bankniftyVola = "Volatility of BANKNIFTY : " + volatility.ToString().Substring(0, 6) + " (No Change in Volatility)";
				}
				else if (symbolNow == "FINNIFTY")
				{
					StocksBasedVolatility.finniftyVola = string.Empty;
					StocksBasedVolatility.finniftyVola = "Volatility of FINNIFTY : " + volatility.ToString().Substring(0, 6) + " (No Change in Volatility)";
				}
				else
				{
					StocksBasedVolatility.volatility_NoChange.Add(symbolNow, volatility);
				}
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00014430 File Offset: 0x00012630
		public static string[] _11dayDataInArray(string _11daysLtpUrl)
		{
			List<string> _11dayDataList = new List<string>();
			List<string> DB11daysData = new List<string>();
			DB11daysData = StocksBasedVolatility.dataDownload("", _11daysLtpUrl);
			if (DB11daysData.Any<string>())
			{
				string text = string.Join("", DB11daysData.ToArray());
				_11dayDataList = StocksBasedVolatility.splitData(text.Remove(text.Length - 1), _11daysLtpUrl);
			}
			return _11dayDataList.ToArray();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0001448C File Offset: 0x0001268C
		public static double[] get_11dayLTPforVolaCalc(string _11daysLtpObjStr)
		{
			string[] array = _11daysLtpObjStr.Split(',', StringSplitOptions.None);
			List<double> _11daysLtpList_splitted = new List<double>();
			string[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				double _11daysLtpObjDouble = Convert.ToDouble(array2[j]);
				_11daysLtpList_splitted.Add(_11daysLtpObjDouble);
			}
			double[] _allLtpArray = new double[_11daysLtpList_splitted.Count<double>()];
			for (int i = 0; i < _allLtpArray.Length; i++)
			{
				_allLtpArray[i] = _11daysLtpList_splitted.ElementAt(i);
			}
			return _allLtpArray;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000144F4 File Offset: 0x000126F4
		public static double Volatility(List<double> _LTPlist)
		{
			int i = 1;
			double sumA = 0.0;
			double sumB = 0.0;
			int count = _LTPlist.Count;
			while (i < count)
			{
				double valueA = Math.Log(Convert.ToDouble(_LTPlist[i]) / Convert.ToDouble(_LTPlist[i - 1]));
				double valueB = Math.Pow(valueA, 2.0);
				sumA += valueA;
				sumB += valueB;
				i++;
			}
			double avgA = sumA / (double)(count - 1);
			return Math.Sqrt(sumB / (double)(count - 1) - Math.Pow(avgA, 2.0));
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000145AC File Offset: 0x000127AC
		public static double get_Volatility(double[] ltp)
		{
			double Sum = 0.0;
			double SumSQRT = 0.0;
			int NoD = ltp.Length - 1;
			for (int i = 0; i < NoD; i++)
			{
				double num = ltp[i + 1];
				double num2 = ltp[i];
				double ValS = Math.Log(ltp[i + 1] / ltp[i]);
				double valSQRT = ValS * ValS;
				Sum += ValS;
				SumSQRT += valSQRT;
			}
			return Math.Sqrt(SumSQRT / (double)NoD - Math.Pow(Sum / (double)NoD, 2.0)) * Math.Sqrt(365.0) * 100.0;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001465C File Offset: 0x0001285C
		public static List<string> dataDownload(string stockExpiry, string url)
		{
			List<string> downloadedSymbols = new List<string>();
			if (StocksBasedVolatility.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, stockExpiry))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					downloadedSymbols.Add(data);
				}
			}
			return downloadedSymbols;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0001469D File Offset: 0x0001289D
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000146AC File Offset: 0x000128AC
		public static List<string> splitData(string Data, string Surl)
		{
			string[] splitList;
			if (Surl == StocksBasedVolatility._leading11daysLtpUrl || Surl == StocksBasedVolatility._trailing11daysLtpUrl || Surl == StocksBasedVolatility._leading11daysLtpUrl_IDX || Surl == StocksBasedVolatility._trailing11daysLtpUrl_IDX)
			{
				splitList = Data.Split('!', StringSplitOptions.None);
			}
			else if (Surl == correlation._11daysLtpUrl)
			{
				splitList = Data.Split('!', StringSplitOptions.None);
			}
			else
			{
				splitList = Data.Split(',', StringSplitOptions.None);
			}
			return new List<string>(splitList);
		}

		// Token: 0x0400024D RID: 589
		public static string symbolsURL = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-symbol.php?expiry={0}";

		// Token: 0x0400024E RID: 590
		public static string _leading11daysLtpUrl = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-leading11day-from-eqSixtyData-for-stock.php?expiry={0}";

		// Token: 0x0400024F RID: 591
		public static string _trailing11daysLtpUrl = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-trailing11day-from-eqSixtyData-for-stock.php?expiry={0}";

		// Token: 0x04000250 RID: 592
		public static string _leading11daysLtpUrl_IDX = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-leading11day-from-indexSixtyData-for-index.php?expiry={0}";

		// Token: 0x04000251 RID: 593
		public static string _trailing11daysLtpUrl_IDX = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-trailing11day-from-indexSixtyData-for-index.php?expiry={0}";

		// Token: 0x04000252 RID: 594
		private static List<string> symbolList;

		// Token: 0x04000253 RID: 595
		public static List<double> volatilityList1 = new List<double>();

		// Token: 0x04000254 RID: 596
		public static List<double> volatilityList2 = new List<double>();

		// Token: 0x04000255 RID: 597
		public static Dictionary<string, double> volatility_Rise;

		// Token: 0x04000256 RID: 598
		public static Dictionary<string, double> volatility_Fall;

		// Token: 0x04000257 RID: 599
		public static Dictionary<string, double> volatility_NoChange;

		// Token: 0x04000258 RID: 600
		public static string niftyVola;

		// Token: 0x04000259 RID: 601
		public static string bankniftyVola;

		// Token: 0x0400025A RID: 602
		public static string finniftyVola;
	}
}
