using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using New_SF_IT.classes;
using siteDownLoadHelper;

namespace New_SF_IT
{
	// Token: 0x0200000F RID: 15
	[NullableContext(1)]
	[Nullable(0)]
	internal class pairTradeHelper
	{
		// Token: 0x06000085 RID: 133 RVA: 0x0000631C File Offset: 0x0000451C
		public static List<string> _60daysLTPfromDB(string Symbol, string url)
		{
			List<string> downloadedData = new List<string>();
			if (Comman.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, Symbol))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					downloadedData.Add(data);
				}
			}
			return downloadedData;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000635D File Offset: 0x0000455D
		public static List<string> splitData(string Data, string Surl)
		{
			return new List<string>(Data.Split(',', StringSplitOptions.None));
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006370 File Offset: 0x00004570
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

		// Token: 0x06000088 RID: 136 RVA: 0x00006428 File Offset: 0x00004628
		public static double doErrorFCheck(double _vola)
		{
			double errorFactor = 0.0;
			if (_vola > 20.0)
			{
				if (_vola < 30.0)
				{
					errorFactor = _vola / 7.0;
				}
				if (_vola > 40.0)
				{
					errorFactor = _vola / 5.0;
				}
				return _vola - errorFactor;
			}
			return _vola;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006480 File Offset: 0x00004680
		public static bool Swaper(List<double> _sym1_PriceList, List<double> _sym2_PriceList, List<double> _sym3_PriceList, double _vola1, double _vola2, double _vola3, string symbol1, string symbol2, string symbol3, List<double> _List1, List<double> _List2, List<double> _List3, Label _label1, Label _label2, Label _label3)
		{
			_List1.Clear();
			_List2.Clear();
			_List3.Clear();
			if (_vola1 > _vola2 & _vola1 > _vola3)
			{
				pairTradeHelper.dataLoader(_sym1_PriceList, _List1, symbol1, _label1);
				if (_vola2 > _vola3)
				{
					pairTradeHelper.dataLoader(_sym2_PriceList, _List2, symbol2, _label2);
					pairTradeHelper.dataLoader(_sym3_PriceList, _List3, symbol3, _label3);
				}
				else
				{
					pairTradeHelper.dataLoader(_sym3_PriceList, _List2, symbol3, _label2);
					pairTradeHelper.dataLoader(_sym2_PriceList, _List3, symbol2, _label3);
				}
			}
			else if (_vola2 > _vola3)
			{
				pairTradeHelper.dataLoader(_sym2_PriceList, _List1, symbol2, _label1);
				if (_vola1 > _vola3)
				{
					pairTradeHelper.dataLoader(_sym1_PriceList, _List2, symbol1, _label2);
					pairTradeHelper.dataLoader(_sym3_PriceList, _List3, symbol3, _label3);
				}
				else
				{
					pairTradeHelper.dataLoader(_sym3_PriceList, _List2, symbol3, _label2);
					pairTradeHelper.dataLoader(_sym1_PriceList, _List3, symbol1, _label3);
				}
			}
			else
			{
				pairTradeHelper.dataLoader(_sym3_PriceList, _List1, symbol3, _label1);
				if (_vola1 > _vola2)
				{
					pairTradeHelper.dataLoader(_sym1_PriceList, _List2, symbol1, _label2);
					pairTradeHelper.dataLoader(_sym2_PriceList, _List3, symbol2, _label3);
				}
				else
				{
					pairTradeHelper.dataLoader(_sym2_PriceList, _List2, symbol2, _label2);
					pairTradeHelper.dataLoader(_sym1_PriceList, _List3, symbol1, _label3);
				}
			}
			return true;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000659C File Offset: 0x0000479C
		public static int dataLoader(List<double> _sym_PriceList, List<double> _List, string symbol, Label label)
		{
			_List.Clear();
			label.Content = symbol;
			int i = 0;
			int count = _sym_PriceList.Count;
			while (i < count)
			{
				_List.Add(_sym_PriceList[i]);
				i++;
			}
			return i;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000065D8 File Offset: 0x000047D8
		public static int Percentage(List<double> _List, List<double> _ListForCalc)
		{
			int i = 1;
			int count = _List.Count;
			_ListForCalc.Clear();
			while (i < count)
			{
				_ListForCalc.Add((_List[i] - _List[i - 1]) / _List[i - 1] * 100.0);
				i++;
			}
			return i;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006630 File Offset: 0x00004830
		public static double upTrend(double V, double CP)
		{
			double DVol = V * Math.Sqrt(3.0);
			double terms = 0.00821917808219178;
			DVol = (DVol + 0.125 * DVol) * 100.0;
			return CP * Math.Exp(DVol * terms);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000667C File Offset: 0x0000487C
		public static double downTrend(double V, double CP)
		{
			double DVol = V * Math.Sqrt(3.0);
			double terms = 0.00821917808219178;
			DVol = (DVol + 0.125 * DVol) * 100.0;
			return CP * Math.Exp(-DVol * terms);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000066C8 File Offset: 0x000048C8
		public static double Beta(List<double> lbArgsA, List<double> lbArgsB)
		{
			int NoD = lbArgsA.Count + 1;
			double num = pairTradeHelper.CoVariance(lbArgsA, lbArgsB);
			double var = pairTradeHelper.Variance(lbArgsA);
			return num / var * (double)(NoD / (NoD - 1));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000066F5 File Offset: 0x000048F5
		public static double Alpha(List<double> lbArgsA, List<double> lbArgsB)
		{
			return pairTradeHelper.Average(lbArgsB) - pairTradeHelper.Beta(lbArgsA, lbArgsB) * pairTradeHelper.Average(lbArgsA);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000670C File Offset: 0x0000490C
		public static double JensenAlpha(List<double> lbArgsA, List<double> lbArgsB)
		{
			return pairTradeHelper.Average(lbArgsA) - (0.035 + pairTradeHelper.Beta(lbArgsA, lbArgsB) * (pairTradeHelper.Average(lbArgsB) - 0.035));
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006737 File Offset: 0x00004937
		public static double SharpRatio(List<double> lbArgsA, List<double> lbArgsB)
		{
			return (pairTradeHelper.Average(lbArgsA) - 0.035) / (pairTradeHelper.Volatility(lbArgsB) * Math.Sqrt(365.0));
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006760 File Offset: 0x00004960
		public static double TreynorRatio(List<double> lbArgsA, List<double> lbArgsB)
		{
			double num = pairTradeHelper.Average(lbArgsA);
			double beta = pairTradeHelper.Beta(lbArgsA, lbArgsB);
			return (num - 0.035) / beta;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006788 File Offset: 0x00004988
		public static double CorRelations(List<double> lbArgsA, List<double> lbArgsB)
		{
			double functionReturnValue = 0.0;
			double Sum = 0.0;
			double SumX = 0.0;
			double SumY = 0.0;
			int i = 0;
			int NoD = lbArgsA.Count;
			double x = Convert.ToDouble(pairTradeHelper.Mean(lbArgsA));
			double y = Convert.ToDouble(pairTradeHelper.Mean(lbArgsB));
			try
			{
				while (i < NoD)
				{
					double difX = lbArgsA[i] - x;
					double difY = lbArgsB[i] - y;
					Sum += difX * difY;
					SumX += Math.Pow(difX, 2.0);
					SumY += Math.Pow(difY, 2.0);
					i++;
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				functionReturnValue = Sum / Math.Sqrt(SumX * SumY);
			}
			return functionReturnValue;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006880 File Offset: 0x00004A80
		public static double BetaDecoupling(List<double> lbArgsA, List<double> lbArgsB, List<double> lbArgs)
		{
			int i = 0;
			int j = 0;
			int pos = 9;
			List<double> tlbA = new List<double>();
			List<double> tlbB = new List<double>();
			lbArgs.Clear();
			tlbA.Clear();
			tlbB.Clear();
			int NoD = lbArgsA.Count;
			double result;
			try
			{
				while (i < NoD & pos < NoD)
				{
					int k = 0;
					while (j <= pos)
					{
						tlbA.Add(lbArgsA[j]);
						tlbB.Add(lbArgsB[j]);
						k++;
						j++;
					}
					k--;
					lbArgs.Add(tlbB[k] - pairTradeHelper.CoVariance(tlbA, tlbB) / pairTradeHelper.Variance(tlbA) * 1.0 * tlbA[k]);
					tlbA.Clear();
					tlbB.Clear();
					i++;
					j = i;
					pos++;
				}
				i = 0;
				double Sum = 0.0;
				int len = lbArgs.Count;
				while (i < len)
				{
					Sum += lbArgs[i];
					i++;
				}
				result = Sum;
			}
			catch (Exception)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000069A4 File Offset: 0x00004BA4
		public static double Average(List<double> lbArgs)
		{
			int NoD = lbArgs.Count;
			int i = 0;
			double Sum = 0.0;
			while (i < NoD)
			{
				Sum += lbArgs[i];
				i++;
			}
			return Sum / (double)NoD;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000069E0 File Offset: 0x00004BE0
		public static double Mean(List<double> lbArgs)
		{
			double sum = 0.0;
			int i = 0;
			int NoD = lbArgs.Count;
			while (i < NoD)
			{
				sum += lbArgs[i];
				i++;
			}
			return sum / (double)NoD;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006A1C File Offset: 0x00004C1C
		public static double Variance(List<double> lbArgs)
		{
			double varMean = pairTradeHelper.Mean(lbArgs);
			double Sum = 0.0;
			int i = 0;
			int NoD = lbArgs.Count;
			while (i < NoD)
			{
				Sum += Math.Pow(lbArgs[i] - varMean, 2.0);
				i++;
			}
			return Sum / (double)(NoD - 1);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006A70 File Offset: 0x00004C70
		public static double CoVariance(List<double> lbArgsA, List<double> lbArgsB)
		{
			double xMean = pairTradeHelper.Mean(lbArgsA);
			double yMean = pairTradeHelper.Mean(lbArgsB);
			double sum = 0.0;
			int NoD = lbArgsA.Count - 1;
			for (int i = 0; i < lbArgsA.Count; i++)
			{
				sum += (lbArgsA[i] - xMean) * (lbArgsB[i] - yMean);
			}
			return sum / (double)NoD;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006AD0 File Offset: 0x00004CD0
		public static double MaxMin(double m, double n, Label lblArgsA, Label lblArgsB, TextBox txtHigh, TextBox txtLow)
		{
			if (m > n)
			{
				txtHigh.Text = lblArgsA.Content.ToString();
				txtLow.Text = lblArgsB.Content.ToString();
			}
			else
			{
				txtHigh.Text = lblArgsB.Content.ToString();
				txtLow.Text = lblArgsA.Content.ToString();
			}
			return 0.0;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006B34 File Offset: 0x00004D34
		public static bool BDCVal4P(double bdc, Label lblArgsA, Label lblArgsB, TextBox txtHigh, TextBox txtLow)
		{
			bool functionReturnValue;
			if (bdc < -1.0 | bdc > 1.0)
			{
				if (bdc < -1.0)
				{
					txtLow.Text = lblArgsB.Content.ToString();
					txtHigh.Text = lblArgsA.Content.ToString();
				}
				if (bdc > 1.0)
				{
					txtLow.Text = lblArgsA.Content.ToString();
					txtHigh.Text = lblArgsB.Content.ToString();
				}
				functionReturnValue = true;
			}
			else
			{
				functionReturnValue = false;
			}
			return functionReturnValue;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006BC4 File Offset: 0x00004DC4
		public static bool BDCVal4I(List<double> lbArgs, Label lblArgsA, Label lblArgsB, TextBox txtHigh, TextBox txtLow)
		{
			int NoD = lbArgs.Count;
			double sumN = 0.0;
			double sumNCP = 0.0;
			int i;
			for (i = 0; i < NoD; i++)
			{
				sumNCP += Convert.ToDouble(lbArgs[i]);
			}
			i = 0;
			NoD--;
			while (i < NoD)
			{
				sumN += Convert.ToDouble(lbArgs[i]);
				i++;
			}
			bool functionReturnValue;
			if (sumN < sumNCP)
			{
				if (sumNCP < -1.0 | sumNCP > 1.0)
				{
					if (sumNCP < -1.0)
					{
						txtLow.Text = lblArgsB.Content.ToString();
						txtHigh.Text = lblArgsA.Content.ToString();
					}
					if (sumNCP > 1.0)
					{
						txtLow.Text = lblArgsA.Content.ToString();
						txtHigh.Text = lblArgsB.Content.ToString();
					}
					functionReturnValue = true;
				}
				else
				{
					functionReturnValue = false;
				}
			}
			else
			{
				functionReturnValue = false;
			}
			return functionReturnValue;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006CC0 File Offset: 0x00004EC0
		public static string CRVal(double cr)
		{
			pairTradeHelper.withOption = true;
			string result;
			if (cr >= 0.0)
			{
				if (cr > 0.0 & cr <= 0.5)
				{
					result = "NOT RECOMMENDED";
				}
				else if (cr > 0.5 & cr <= 0.6018)
				{
					result = "recommended WITH option hedging";
				}
				else if (cr > 0.6018 & cr <= 0.75)
				{
					result = "recommended WITHOUT option hedging";
					pairTradeHelper.withOption = false;
				}
				else
				{
					result = "recommended WITH option hedging";
				}
			}
			else if (cr < 0.0 & cr >= -0.5)
			{
				result = "NOT RECOMMENDED";
			}
			else if (cr < -0.5 & cr >= -0.6018)
			{
				result = "recommended WITH option hedging";
			}
			else if (cr < -0.6018 & cr >= -0.75)
			{
				result = "recommended WITHOUT option hedging";
				pairTradeHelper.withOption = false;
			}
			else
			{
				result = "recommended WITH option hedging";
			}
			return result;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006DF0 File Offset: 0x00004FF0
		public static string Spread(List<double> dataA, List<double> dataB)
		{
			List<double> lbx = new List<double>();
			List<double> _items = new List<double>();
			int i = 0;
			int j = 0;
			string result;
			try
			{
				while (j <= dataA.Count - 1)
				{
					while (i <= j)
					{
						double _dataAfterSubstration = dataA[j] - dataB[i];
						_items.Add(_dataAfterSubstration);
						i++;
					}
					j++;
				}
				for (int ii = 0; ii <= _items.Count - 1; ii++)
				{
					lbx.Add(_items[ii]);
				}
				int lbxlastindex = lbx.Count - 1;
				int lastitem = Convert.ToInt32(lbx[lbxlastindex]);
				int y = (int)pairTradeHelper.Mean(lbx) * 2 / 100;
				int q = (int)pairTradeHelper.Mean(lbx) + y;
				int r = (int)pairTradeHelper.Mean(lbx) - y;
				if (pairTradeHelper.ShowDecision(lastitem, q, r))
				{
					result = "Trade Recommended";
				}
				else
				{
					result = "Trade not Recommended";
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006EFC File Offset: 0x000050FC
		private static bool ShowDecision(int lastitem, int q, int r)
		{
			return lastitem > q || lastitem < r;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006F09 File Offset: 0x00005109
		public static double get1SDPriceRange(double _price, double _vola)
		{
			return _price * _vola * Math.Sqrt(1.0) / Math.Sqrt(365.0);
		}

		// Token: 0x040000E1 RID: 225
		public static bool withOption;
	}
}
