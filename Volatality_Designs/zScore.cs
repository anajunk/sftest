using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using SFHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000025 RID: 37
	[NullableContext(1)]
	[Nullable(0)]
	internal class zScore
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0001FA14 File Offset: 0x0001DC14
		public static double zScore_Calc(double[] x_nifty, double[] y)
		{
			List<double> spreadlist = new List<double>();
			for (int i = 0; i <= x_nifty.Length - 1; i++)
			{
				double spread = Math.Log(x_nifty[i]) - y[i] / x_nifty[i] * Math.Log(y[i]);
				spreadlist.Add(spread);
			}
			double result = 0.0;
			if (spreadlist != null)
			{
				double[] spreadArray = spreadlist.ToArray();
				double avgSpread = spreadArray.Average();
				double sum = spreadlist.Sum((double v) => (v - avgSpread) * (v - avgSpread));
				double denominator = (double)(spreadlist.Count - 1);
				double stddevspread = (denominator > 0.0) ? Math.Sqrt(sum / denominator) : -1.0;
				result = (spreadlist[10] - avgSpread) / stddevspread;
			}
			return result;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0001FADC File Offset: 0x0001DCDC
		public static double getzScoreForCurrentPrice(string _symbol)
		{
			correlation.loadExpiry();
			List<string> DB11daysLTP = techAnalysisHelper._11daysLTPfromDB((_symbol == "BANKNIFTY") ? "INDEX FUTURE" : "STOCK FUTURE", _symbol, correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> _10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] _last11Days = _10daysLTP_DB.ToArray();
			List<string> NIFTY_DB11daysLTP = techAnalysisHelper._11daysLTPfromDB("INDEX FUTURE", "NIFTY", correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> NIFTY_10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", NIFTY_DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] nifty_last11Days = NIFTY_10daysLTP_DB.ToArray();
			double BANKNIFTY_liveLTP = 0.0;
			double symbol1_liveLTP = 0.0;
			double NIFTY_liveLTP = 0.0;
			if (_symbol == "BANKNIFTY")
			{
				LiveMarketQuoteDataCls BANKNIFTY_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "BANKNIFTY", correlation._currentMonthExpiry);
				if (BANKNIFTY_allLivePrices.ltp != 0.0)
				{
					BANKNIFTY_liveLTP = Convert.ToDouble(BANKNIFTY_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for BANKNIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			else
			{
				string selectedSymbol = _symbol;
				if (selectedSymbol == "MANDM" || selectedSymbol == "MANDMFIN" || selectedSymbol == "LANDTFH")
				{
					selectedSymbol = _symbol.Replace("AND", "%26");
				}
				LiveMarketQuoteDataCls symbol1_allLivePrices = zScore.liveData.get_Quote("STOCK FUTURE", selectedSymbol, correlation._currentMonthExpiry);
				if (symbol1_allLivePrices.ltp != 0.0)
				{
					symbol1_liveLTP = Convert.ToDouble(symbol1_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for " + _symbol, "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			LiveMarketQuoteDataCls NIFTY_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "NIFTY", correlation._currentMonthExpiry);
			if (NIFTY_allLivePrices.ltp != 0.0)
			{
				NIFTY_liveLTP = Convert.ToDouble(NIFTY_allLivePrices.ltp);
			}
			else
			{
				MessageBox.Show("Live data is not available for NIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			if (_symbol == "BANKNIFTY")
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = BANKNIFTY_liveLTP;
			}
			else
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = symbol1_liveLTP;
			}
			nifty_last11Days = (from val in nifty_last11Days
			where val != nifty_last11Days[0]
			select val).ToArray<double>();
			Array.Resize<double>(ref nifty_last11Days, nifty_last11Days.Length + 1);
			nifty_last11Days[10] = NIFTY_liveLTP;
			return Math.Round(zScore.zScore_Calc(nifty_last11Days, _last11Days), 4);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001FE30 File Offset: 0x0001E030
		public static double getzScoreForCurrentPrice_banknifty(string _symbol)
		{
			correlation.loadExpiry();
			List<string> DB11daysLTP = techAnalysisHelper._11daysLTPfromDB((_symbol == "BANKNIFTY") ? "INDEX FUTURE" : "STOCK FUTURE", _symbol, correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> _10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] _last11Days = _10daysLTP_DB.ToArray();
			List<string> BANKNIFTY_DB11daysLTP = techAnalysisHelper._11daysLTPfromDB("INDEX FUTURE", "BANKNIFTY", correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> BANKNIFTY_10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", BANKNIFTY_DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] banknifty_last11Days = BANKNIFTY_10daysLTP_DB.ToArray();
			double BANKNIFTY_liveLTP = 0.0;
			double symbol1_liveLTP = 0.0;
			if (_symbol == "BANKNIFTY")
			{
				LiveMarketQuoteDataCls BANKNIFTY2_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "BANKNIFTY", correlation._currentMonthExpiry);
				if (BANKNIFTY2_allLivePrices.ltp != 0.0)
				{
					BANKNIFTY_liveLTP = Convert.ToDouble(BANKNIFTY2_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for BANKNIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			else
			{
				string selectedSymbol = _symbol;
				if (selectedSymbol == "MANDM" || selectedSymbol == "MANDMFIN" || selectedSymbol == "LANDTFH")
				{
					selectedSymbol = _symbol.Replace("AND", "%26");
				}
				LiveMarketQuoteDataCls symbol1_allLivePrices = zScore.liveData.get_Quote("STOCK FUTURE", selectedSymbol, correlation._currentMonthExpiry);
				if (symbol1_allLivePrices.ltp != 0.0)
				{
					symbol1_liveLTP = Convert.ToDouble(symbol1_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for " + _symbol, "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			LiveMarketQuoteDataCls BANKNIFTY_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "BANKNIFTY", correlation._currentMonthExpiry);
			if (BANKNIFTY_allLivePrices.ltp != 0.0)
			{
				BANKNIFTY_liveLTP = Convert.ToDouble(BANKNIFTY_allLivePrices.ltp);
			}
			else
			{
				MessageBox.Show("Live data is not available for NIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			if (_symbol == "BANKNIFTY")
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = BANKNIFTY_liveLTP;
			}
			else
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = symbol1_liveLTP;
			}
			banknifty_last11Days = (from val in banknifty_last11Days
			where val != banknifty_last11Days[0]
			select val).ToArray<double>();
			Array.Resize<double>(ref banknifty_last11Days, banknifty_last11Days.Length + 1);
			banknifty_last11Days[10] = BANKNIFTY_liveLTP;
			return Math.Round(zScore.zScore_Calc(banknifty_last11Days, _last11Days), 4);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00020178 File Offset: 0x0001E378
		public static double getzScoreForCurrentPrice_finnifty(string _symbol)
		{
			correlation.loadExpiry();
			List<string> DB11daysLTP = techAnalysisHelper._11daysLTPfromDB((_symbol == "BANKNIFTY") ? "INDEX FUTURE" : "STOCK FUTURE", _symbol, correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> _10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] _last11Days = _10daysLTP_DB.ToArray();
			List<string> FINNIFTY_DB11daysLTP = techAnalysisHelper._11daysLTPfromDB("INDEX FUTURE", "FINNIFTY", correlation._currentMonthExpiry, zScore.historicDBUrl);
			List<double> FINNIFTY_10daysLTP_DB = (from x in techAnalysisHelper.splitData(string.Join("", FINNIFTY_DB11daysLTP.ToArray()), zScore.historicDBUrl)
			select double.Parse(x)).ToList<double>();
			double[] finnifty_last11Days = FINNIFTY_10daysLTP_DB.ToArray();
			double BANKNIFTY_liveLTP = 0.0;
			double symbol1_liveLTP = 0.0;
			double FINNIFTY_liveLTP = 0.0;
			if (_symbol == "BANKNIFTY")
			{
				LiveMarketQuoteDataCls BANKNIFTY2_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "BANKNIFTY", correlation._currentMonthExpiry);
				if (BANKNIFTY2_allLivePrices.ltp != 0.0)
				{
					BANKNIFTY_liveLTP = Convert.ToDouble(BANKNIFTY2_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for BANKNIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			else
			{
				string selectedSymbol = _symbol;
				if (selectedSymbol == "MANDM" || selectedSymbol == "MANDMFIN" || selectedSymbol == "LANDTFH")
				{
					selectedSymbol = _symbol.Replace("AND", "%26");
				}
				LiveMarketQuoteDataCls symbol1_allLivePrices = zScore.liveData.get_Quote("STOCK FUTURE", selectedSymbol, correlation._currentMonthExpiry);
				if (symbol1_allLivePrices.ltp != 0.0)
				{
					symbol1_liveLTP = Convert.ToDouble(symbol1_allLivePrices.ltp);
				}
				else
				{
					MessageBox.Show("Live data is not available for " + _symbol, "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			LiveMarketQuoteDataCls FINNIFTY_allLivePrices = zScore.liveData.get_Quote("INDEX FUTURE", "FINNIFTY", correlation._currentMonthExpiry);
			if (FINNIFTY_allLivePrices.ltp != 0.0)
			{
				FINNIFTY_liveLTP = Convert.ToDouble(FINNIFTY_allLivePrices.ltp);
			}
			else
			{
				MessageBox.Show("Live data is not available for NIFTY", "Pls try later", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			if (_symbol == "BANKNIFTY")
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = BANKNIFTY_liveLTP;
			}
			else
			{
				_last11Days = (from val in _last11Days
				where val != _last11Days[0]
				select val).ToArray<double>();
				Array.Resize<double>(ref _last11Days, _last11Days.Length + 1);
				_last11Days[10] = symbol1_liveLTP;
			}
			finnifty_last11Days = (from val in finnifty_last11Days
			where val != finnifty_last11Days[0]
			select val).ToArray<double>();
			Array.Resize<double>(ref finnifty_last11Days, finnifty_last11Days.Length + 1);
			finnifty_last11Days[10] = FINNIFTY_liveLTP;
			return Math.Round(zScore.zScore_Calc(finnifty_last11Days, _last11Days), 4);
		}

		// Token: 0x04000424 RID: 1060
		public static LiveMarketQuoteCls liveData = new LiveMarketQuoteCls();

		// Token: 0x04000425 RID: 1061
		private List<double> _allLTP = new List<double>();

		// Token: 0x04000426 RID: 1062
		public static string historicDBUrl = "https://smartfinance.in/PHPusedForSoftwares/fetch-historic-data-desktop.php?instrument={0}&script={1}&expiry={2}";
	}
}
