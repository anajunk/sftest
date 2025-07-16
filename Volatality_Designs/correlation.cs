using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000019 RID: 25
	[NullableContext(1)]
	[Nullable(0)]
	internal class correlation
	{
		// Token: 0x0600012E RID: 302 RVA: 0x0000E244 File Offset: 0x0000C444
		public static void getStocksBasedOnCorrelation()
		{
			correlation.stk_symbol_list = new List<string>();
			correlation._correlation = new Dictionary<string, double>();
			correlation._zScore = new Dictionary<string, double>();
			correlation.loadExpiry();
			List<string> DBsymbols = StocksBasedVolatility.dataDownload(correlation._currentMonthExpiry, correlation.stk_symbolsURL);
			if (DBsymbols.Any<string>())
			{
				string text = string.Join("", DBsymbols.ToArray());
				correlation.stk_symbol_list = StocksBasedVolatility.splitData(text.Remove(text.Length - 1), correlation.stk_symbolsURL);
			}
			string[] _11dayDataArray = correlation._11dayDataInArray(correlation._currentMonthExpiry, correlation._11daysLtpUrl);
			bool contains_NIFTY = false;
			foreach (string input in correlation.stk_symbol_list)
			{
				contains_NIFTY = Regex.IsMatch(input, "\\bNIFTY\\b");
				if (contains_NIFTY)
				{
					break;
				}
			}
			if (contains_NIFTY)
			{
				int nifty_index = correlation.stk_symbol_list.FindIndex((string a) => Regex.IsMatch(a, "\\bNIFTY\\b"));
				double[] nifty_last11Days = correlation.get_11dayLTP(_11dayDataArray.ElementAt(nifty_index));
				double nifty_day = nifty_last11Days.ElementAt(0);
				double nifty_day2 = nifty_last11Days.ElementAt(1);
				double nifty_day3 = nifty_last11Days.ElementAt(2);
				double nifty_day4 = nifty_last11Days.ElementAt(3);
				double nifty_day5 = nifty_last11Days.ElementAt(4);
				double nifty_day6 = nifty_last11Days.ElementAt(5);
				double nifty_day7 = nifty_last11Days.ElementAt(6);
				double nifty_day8 = nifty_last11Days.ElementAt(7);
				double nifty_day9 = nifty_last11Days.ElementAt(8);
				double nifty_day10 = nifty_last11Days.ElementAt(9);
				double nifty_day11 = nifty_last11Days.ElementAt(10);
				List<double> x_nifty = new List<double>();
				x_nifty.Add((nifty_day2 - nifty_day) / nifty_day2 * 100.0);
				x_nifty.Add((nifty_day3 - nifty_day2) / nifty_day3 * 100.0);
				x_nifty.Add((nifty_day4 - nifty_day3) / nifty_day4 * 100.0);
				x_nifty.Add((nifty_day5 - nifty_day4) / nifty_day5 * 100.0);
				x_nifty.Add((nifty_day6 - nifty_day5) / nifty_day6 * 100.0);
				x_nifty.Add((nifty_day7 - nifty_day6) / nifty_day7 * 100.0);
				x_nifty.Add((nifty_day8 - nifty_day7) / nifty_day8 * 100.0);
				x_nifty.Add((nifty_day9 - nifty_day8) / nifty_day9 * 100.0);
				x_nifty.Add((nifty_day10 - nifty_day9) / nifty_day10 * 100.0);
				x_nifty.Add((nifty_day11 - nifty_day10) / nifty_day11 * 100.0);
				for (int index = 0; index <= correlation.stk_symbol_list.Count - 2; index++)
				{
					string symbolNow = correlation.stk_symbol_list.ElementAt(index);
					if (symbolNow != "NIFTY")
					{
						double[] _last11Days = correlation.get_11dayLTP(_11dayDataArray.ElementAt(index));
						double day = _last11Days.ElementAt(0);
						double day2 = _last11Days.ElementAt(1);
						double day3 = _last11Days.ElementAt(2);
						double day4 = _last11Days.ElementAt(3);
						double day5 = _last11Days.ElementAt(4);
						double day6 = _last11Days.ElementAt(5);
						double day7 = _last11Days.ElementAt(6);
						double day8 = _last11Days.ElementAt(7);
						double day9 = _last11Days.ElementAt(8);
						double day10 = _last11Days.ElementAt(9);
						double day11 = _last11Days.ElementAt(10);
						List<double> y = new List<double>();
						y.Add((day2 - day) / day2 * 100.0);
						y.Add((day3 - day2) / day3 * 100.0);
						y.Add((day4 - day3) / day4 * 100.0);
						y.Add((day5 - day4) / day5 * 100.0);
						y.Add((day6 - day5) / day6 * 100.0);
						y.Add((day7 - day6) / day7 * 100.0);
						y.Add((day8 - day7) / day8 * 100.0);
						y.Add((day9 - day8) / day9 * 100.0);
						y.Add((day10 - day9) / day10 * 100.0);
						y.Add((day11 - day10) / day11 * 100.0);
						double correlationResult = correlation.CorrCoEff(x_nifty.ToArray(), y.ToArray());
						correlationResult *= 100.0;
						correlation._correlation.Add(symbolNow, correlationResult);
						double zScoreResult = zScore.zScore_Calc(nifty_last11Days, _last11Days);
						correlation._zScore.Add(symbolNow, zScoreResult);
					}
				}
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		public static double CorrCoEff(double[] values1, double[] values2)
		{
			double avg1 = values1.Average();
			double avg2 = values2.Average();
			double num = values1.Zip(values2, (double x1, double y1) => (x1 - avg1) * (y1 - avg2)).Sum();
			double sumSqr = values1.Sum((double x) => Math.Pow(x - avg1, 2.0));
			double sumSqr2 = values2.Sum((double y) => Math.Pow(y - avg2, 2.0));
			return num / Math.Sqrt(sumSqr * sumSqr2);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000E74C File Offset: 0x0000C94C
		public static double[] get_11dayLTP(string _11daysLtpObjStr)
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

		// Token: 0x06000131 RID: 305 RVA: 0x0000E7B4 File Offset: 0x0000C9B4
		public static string[] _11dayDataInArray(string currentMonthExpiry, string _11daysLtpUrl)
		{
			List<string> _11dayDataList = new List<string>();
			List<string> DB11daysData = new List<string>();
			DB11daysData = StocksBasedVolatility.dataDownload(currentMonthExpiry, _11daysLtpUrl);
			if (DB11daysData.Any<string>())
			{
				string text = string.Join("", DB11daysData.ToArray());
				_11dayDataList = StocksBasedVolatility.splitData(text.Remove(text.Length - 1), _11daysLtpUrl);
			}
			return _11dayDataList.ToArray();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000E80C File Offset: 0x0000CA0C
		public static void loadExpiry()
		{
			string data = new downloadSiteCls(new Uri(correlation.EXPIRYURL + "IDX-STKexpiry.txt")).getSite();
			if (data == null)
			{
				MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			data = data.Replace("\r", "");
			if (!string.IsNullOrWhiteSpace(data))
			{
				correlation._expiry = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
				correlation._currentMonthExpiry = correlation._expiry[0];
			}
		}

		// Token: 0x040001B3 RID: 435
		public static string stk_symbolsURL = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-stk-symbol.php?expiry={0}";

		// Token: 0x040001B4 RID: 436
		public static string _11daysLtpUrl = "https://smartfinance.in/PHPusedForSoftwares/technicalAnalysis/fetch-11day-for-stock.php?expiry={0}";

		// Token: 0x040001B5 RID: 437
		public static List<string> stk_symbol_list;

		// Token: 0x040001B6 RID: 438
		public static readonly string EXPIRYURL = "https://smartfinance.in/expiry/";

		// Token: 0x040001B7 RID: 439
		public static ObservableCollection<string> _expiry;

		// Token: 0x040001B8 RID: 440
		public static string _currentMonthExpiry = string.Empty;

		// Token: 0x040001B9 RID: 441
		public static Dictionary<string, double> _correlation;

		// Token: 0x040001BA RID: 442
		public static Dictionary<string, double> _zScore;
	}
}
