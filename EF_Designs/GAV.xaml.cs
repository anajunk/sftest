using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000047 RID: 71
	public partial class GAV : UserControl
	{
		// Token: 0x06000352 RID: 850 RVA: 0x0006ED38 File Offset: 0x0006CF38
		public GAV()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0006ED90 File Offset: 0x0006CF90
		public void Initialize_Variable()
		{
			try
			{
				this.clearGAVtargets();
				List<double> _11LTP = new List<double>();
				double priceRange = 0.0;
				int AllLTPcount = Equtiy_Future.LTP_MONTH.Count;
				if (AllLTPcount >= 11)
				{
					int skipCount = AllLTPcount - 11;
					_11LTP = Equtiy_Future.LTP_MONTH.Skip(skipCount).ToList<double>();
					double prevDayLTP = _11LTP[_11LTP.Count - 1];
					double refPrice = prevDayLTP;
					double volatility = GAV.get_Volatility(_11LTP);
					volatility = this.volaCheck(volatility);
					double tempPriceRange = volatility * refPrice;
					if (Equtiy_Future.LIVE_DATA.open > prevDayLTP + 0.236 * tempPriceRange || Equtiy_Future.LIVE_DATA.open < prevDayLTP - 0.236 * tempPriceRange)
					{
						refPrice = Equtiy_Future.LIVE_DATA.open;
						new List<double>();
						List<double> list = _11LTP.ToList<double>();
						list.RemoveAt(0);
						list.Add(Equtiy_Future.LIVE_DATA.open);
						volatility = GAV.get_Volatility(list);
						volatility = this.volaCheck(volatility);
						priceRange = volatility * refPrice;
					}
					if (Equtiy_Future.LIVE_DATA.ltp > prevDayLTP + 0.236 * tempPriceRange || Equtiy_Future.LIVE_DATA.ltp < prevDayLTP - 0.236 * tempPriceRange)
					{
						refPrice = Equtiy_Future.LIVE_DATA.ltp;
						new List<double>();
						List<double> list2 = _11LTP.ToList<double>();
						list2.RemoveAt(0);
						list2.Add(Equtiy_Future.LIVE_DATA.ltp);
						volatility = GAV.get_Volatility(list2);
						volatility = this.volaCheck(volatility);
						priceRange = volatility * refPrice;
					}
					if (refPrice == prevDayLTP)
					{
						priceRange = tempPriceRange;
					}
					this.GAV_buy_C1 = this.get_buyTarget(refPrice, priceRange, this.degreeA);
					this.GAV_T1_C1 = this.get_buyTarget(refPrice, priceRange, this.degreeB);
					this.GAV_T2_C1 = this.get_buyTarget(refPrice, priceRange, this.degreeC);
					this.GAV_T3_C1 = this.get_buyTarget(refPrice, priceRange, this.degreeD);
					this.GAV_buy_C2 = this.get_buyTarget(this.GAV_T3_C1, priceRange, this.degreeA);
					this.GAV_T1_C2 = this.get_buyTarget(this.GAV_T3_C1, priceRange, this.degreeB);
					this.GAV_T2_C2 = this.get_buyTarget(this.GAV_T3_C1, priceRange, this.degreeC);
					this.GAV_T3_C2 = this.get_buyTarget(this.GAV_T3_C1, priceRange, this.degreeD);
					this.GAV_buy_C3 = this.get_buyTarget(this.GAV_T3_C2, priceRange, this.degreeA);
					this.GAV_T1_C3 = this.get_buyTarget(this.GAV_T3_C2, priceRange, this.degreeB);
					this.GAV_T2_C3 = this.get_buyTarget(this.GAV_T3_C2, priceRange, this.degreeC);
					this.GAV_T3_C3 = this.get_buyTarget(this.GAV_T3_C2, priceRange, this.degreeD);
					this.GAV_sell_C1 = this.get_sellTarget(refPrice, priceRange, this.degreeA);
					this.GAV_sellT1_C1 = this.get_sellTarget(refPrice, priceRange, this.degreeB);
					this.GAV_sellT2_C1 = this.get_sellTarget(refPrice, priceRange, this.degreeC);
					this.GAV_sellT3_C1 = this.get_sellTarget(refPrice, priceRange, this.degreeD);
					this.GAV_sell_C2 = this.get_sellTarget(this.GAV_sellT3_C1, priceRange, this.degreeA);
					this.GAV_sellT1_C2 = this.get_sellTarget(this.GAV_sellT3_C1, priceRange, this.degreeB);
					this.GAV_sellT2_C2 = this.get_sellTarget(this.GAV_sellT3_C1, priceRange, this.degreeC);
					this.GAV_sellT3_C2 = this.get_sellTarget(this.GAV_sellT3_C1, priceRange, this.degreeD);
					this.GAV_sell_C3 = this.get_sellTarget(this.GAV_sellT3_C2, priceRange, this.degreeA);
					this.GAV_sellT1_C3 = this.get_sellTarget(this.GAV_sellT3_C2, priceRange, this.degreeB);
					this.GAV_sellT2_C3 = this.get_sellTarget(this.GAV_sellT3_C2, priceRange, this.degreeC);
					this.GAV_sellT3_C3 = this.get_sellTarget(this.GAV_sellT3_C2, priceRange, this.degreeD);
				}
				this.display_GAV_buy_C1.Inlines.Add(Math.Round(this.GAV_buy_C1, 2).ToString());
				this.display_GAV_sell_C1.Inlines.Add(Math.Round(this.GAV_sell_C1, 2).ToString());
				this.display_GAV_buy_T1_C1.Inlines.Add(Math.Round(this.GAV_T1_C1, 2).ToString());
				this.display_GAV_buy_T2_C1.Inlines.Add(Math.Round(this.GAV_T2_C1, 2).ToString());
				this.display_GAV_buy_T3_C1.Inlines.Add(Math.Round(this.GAV_T3_C1, 2).ToString());
				this.display_GAV_buy_stopLoss_C1.Inlines.Add(((Run)this.display_GAV_sell_C1.Inlines.FirstInline).Text);
				this.display_GAV_buy_C2.Inlines.Add(Math.Round(this.GAV_buy_C2, 2).ToString());
				this.display_GAV_buy_T1_C2.Inlines.Add(Math.Round(this.GAV_T1_C2, 2).ToString());
				this.display_GAV_buy_T2_C2.Inlines.Add(Math.Round(this.GAV_T2_C2, 2).ToString());
				this.display_GAV_buy_T3_C2.Inlines.Add(Math.Round(this.GAV_T3_C2, 2).ToString());
				this.display_GAV_buy_stopLoss_C2.Inlines.Add(((Run)this.display_GAV_buy_T2_C1.Inlines.FirstInline).Text);
				this.display_GAV_buy_C3.Inlines.Add(Math.Round(this.GAV_buy_C3, 2).ToString());
				this.display_GAV_buy_T1_C3.Inlines.Add(Math.Round(this.GAV_T1_C3, 2).ToString());
				this.display_GAV_buy_T2_C3.Inlines.Add(Math.Round(this.GAV_T2_C3, 2).ToString());
				this.display_GAV_buy_T3_C3.Inlines.Add(Math.Round(this.GAV_T3_C3, 2).ToString());
				this.display_GAV_buy_stopLoss_C3.Inlines.Add(((Run)this.display_GAV_buy_T2_C2.Inlines.FirstInline).Text);
				this.display_GAV_sell_T1_C1.Inlines.Add(Math.Round(this.GAV_sellT1_C1, 2).ToString());
				this.display_GAV_sell_T2_C1.Inlines.Add(Math.Round(this.GAV_sellT2_C1, 2).ToString());
				this.display_GAV_sell_T3_C1.Inlines.Add(Math.Round(this.GAV_sellT3_C1, 2).ToString());
				this.display_GAV_sell_stopLoss_C1.Inlines.Add(((Run)this.display_GAV_buy_C1.Inlines.FirstInline).Text);
				this.display_GAV_sell_C2.Inlines.Add(Math.Round(this.GAV_sell_C2, 2).ToString());
				this.display_GAV_sell_T1_C2.Inlines.Add(Math.Round(this.GAV_sellT1_C2, 2).ToString());
				this.display_GAV_sell_T2_C2.Inlines.Add(Math.Round(this.GAV_sellT2_C2, 2).ToString());
				this.display_GAV_sell_T3_C2.Inlines.Add(Math.Round(this.GAV_sellT3_C2, 2).ToString());
				this.display_GAV_sell_stopLoss_C2.Inlines.Add(((Run)this.display_GAV_sell_T2_C1.Inlines.FirstInline).Text);
				this.display_GAV_sell_C3.Inlines.Add(Math.Round(this.GAV_sell_C3, 2).ToString());
				this.display_GAV_sell_T1_C3.Inlines.Add(Math.Round(this.GAV_sellT1_C3, 2).ToString());
				this.display_GAV_sell_T2_C3.Inlines.Add(Math.Round(this.GAV_sellT2_C3, 2).ToString());
				this.display_GAV_sell_T3_C3.Inlines.Add(Math.Round(this.GAV_sellT3_C3, 2).ToString());
				this.display_GAV_sell_stopLoss_C3.Inlines.Add(((Run)this.display_GAV_sell_T2_C2.Inlines.FirstInline).Text);
			}
			catch
			{
				MessageBox.Show("Pls load the data first", "SF GAV", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0006F5E8 File Offset: 0x0006D7E8
		private double volaCheck(double _vola)
		{
			if (_vola <= 0.01046847)
			{
				_vola += _vola * 0.068;
			}
			else if (_vola > 0.01046847 || _vola <= 0.01570272)
			{
				_vola -= _vola * 0.068;
			}
			else
			{
				_vola -= _vola * 0.136;
			}
			return _vola;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0006F64C File Offset: 0x0006D84C
		[NullableContext(1)]
		public static double get_Volatility(List<double> ltp)
		{
			double Sum = 0.0;
			double SumSQRT = 0.0;
			int NoD = ltp.Count - 1;
			for (int i = 0; i < NoD; i++)
			{
				double num = ltp[i + 1];
				double num2 = ltp[i];
				double ValS = Math.Log(ltp[i + 1] / ltp[i]);
				double valSQRT = ValS * ValS;
				Sum += ValS;
				SumSQRT += valSQRT;
			}
			return Math.Sqrt(SumSQRT / (double)NoD - Math.Pow(Sum / (double)NoD, 2.0));
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0006F6F4 File Offset: 0x0006D8F4
		private double get_sellTarget(double _refPrice, double priceRange, double ratio)
		{
			if (_refPrice < 1000.0)
			{
				double denominator;
				if (_refPrice < 100.0)
				{
					if (_refPrice < 10.0)
					{
						_refPrice *= 1000.0;
						priceRange *= 1000.0;
						denominator = 1000.0;
					}
					else
					{
						_refPrice *= 100.0;
						priceRange *= 100.0;
						denominator = 100.0;
					}
				}
				else
				{
					_refPrice *= 10.0;
					priceRange *= 10.0;
					denominator = 10.0;
				}
				return Math.Round(this.calculate_SellTarget(_refPrice, priceRange, ratio) / denominator, 2);
			}
			return Math.Round(this.calculate_SellTarget(_refPrice, priceRange, ratio), 2);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0006F7B9 File Offset: 0x0006D9B9
		private double calculate_SellTarget(double _refPrice, double priceRange, double ratio)
		{
			return _refPrice - Math.Pow(Math.Sqrt(priceRange) - ratio, 2.0) * ratio;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0006F7D8 File Offset: 0x0006D9D8
		private double get_buyTarget(double _refPrice, double priceRange, double ratio)
		{
			if (_refPrice < 1000.0)
			{
				double denominator;
				if (_refPrice < 100.0)
				{
					if (_refPrice < 10.0)
					{
						_refPrice *= 1000.0;
						priceRange *= 1000.0;
						denominator = 1000.0;
					}
					else
					{
						_refPrice *= 100.0;
						priceRange *= 100.0;
						denominator = 100.0;
					}
				}
				else
				{
					_refPrice *= 10.0;
					priceRange *= 10.0;
					denominator = 10.0;
				}
				return Math.Round(this.calculate_BuyTarget(_refPrice, priceRange, ratio) / denominator, 2);
			}
			return Math.Round(this.calculate_BuyTarget(_refPrice, priceRange, ratio), 2);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0006F89D File Offset: 0x0006DA9D
		private double calculate_BuyTarget(double _refPrice, double priceRange, double ratio)
		{
			return _refPrice + Math.Pow(Math.Sqrt(priceRange) + ratio, 2.0) * ratio;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0006F8BC File Offset: 0x0006DABC
		private void clearGAVtargets()
		{
			this.display_GAV_buy_C1.Inlines.Clear();
			this.display_GAV_sell_C1.Inlines.Clear();
			this.display_GAV_buy_T1_C1.Inlines.Clear();
			this.display_GAV_buy_T2_C1.Inlines.Clear();
			this.display_GAV_buy_T3_C1.Inlines.Clear();
			this.display_GAV_buy_stopLoss_C1.Inlines.Clear();
			this.display_GAV_buy_C2.Inlines.Clear();
			this.display_GAV_buy_T1_C2.Inlines.Clear();
			this.display_GAV_buy_T2_C2.Inlines.Clear();
			this.display_GAV_buy_T3_C2.Inlines.Clear();
			this.display_GAV_buy_stopLoss_C2.Inlines.Clear();
			this.display_GAV_buy_C3.Inlines.Clear();
			this.display_GAV_buy_T1_C3.Inlines.Clear();
			this.display_GAV_buy_T2_C3.Inlines.Clear();
			this.display_GAV_buy_T3_C3.Inlines.Clear();
			this.display_GAV_buy_stopLoss_C3.Inlines.Clear();
			this.display_GAV_sell_T1_C1.Inlines.Clear();
			this.display_GAV_sell_T2_C1.Inlines.Clear();
			this.display_GAV_sell_T3_C1.Inlines.Clear();
			this.display_GAV_sell_stopLoss_C1.Inlines.Clear();
			this.display_GAV_sell_C2.Inlines.Clear();
			this.display_GAV_sell_T1_C2.Inlines.Clear();
			this.display_GAV_sell_T2_C2.Inlines.Clear();
			this.display_GAV_sell_T3_C2.Inlines.Clear();
			this.display_GAV_sell_stopLoss_C2.Inlines.Clear();
			this.display_GAV_sell_C3.Inlines.Clear();
			this.display_GAV_sell_T1_C3.Inlines.Clear();
			this.display_GAV_sell_T2_C3.Inlines.Clear();
			this.display_GAV_sell_T3_C3.Inlines.Clear();
			this.display_GAV_sell_stopLoss_C3.Inlines.Clear();
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0006FAA9 File Offset: 0x0006DCA9
		[NullableContext(1)]
		private void gavCalc(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x04000BF1 RID: 3057
		public double degreeA = 0.08333333333333333;

		// Token: 0x04000BF2 RID: 3058
		private double degreeB = 0.25;

		// Token: 0x04000BF3 RID: 3059
		private double degreeC = 0.3958333333333333;

		// Token: 0x04000BF4 RID: 3060
		private double degreeD = 0.4791666666666667;

		// Token: 0x04000BF5 RID: 3061
		public double GAV_buy_C1;

		// Token: 0x04000BF6 RID: 3062
		public double GAV_T1_C1;

		// Token: 0x04000BF7 RID: 3063
		public double GAV_T2_C1;

		// Token: 0x04000BF8 RID: 3064
		public double GAV_T3_C1;

		// Token: 0x04000BF9 RID: 3065
		public double GAV_buy_C2;

		// Token: 0x04000BFA RID: 3066
		public double GAV_T1_C2;

		// Token: 0x04000BFB RID: 3067
		public double GAV_T2_C2;

		// Token: 0x04000BFC RID: 3068
		public double GAV_T3_C2;

		// Token: 0x04000BFD RID: 3069
		public double GAV_buy_C3;

		// Token: 0x04000BFE RID: 3070
		public double GAV_T1_C3;

		// Token: 0x04000BFF RID: 3071
		public double GAV_T2_C3;

		// Token: 0x04000C00 RID: 3072
		public double GAV_T3_C3;

		// Token: 0x04000C01 RID: 3073
		public double GAV_sell_C1;

		// Token: 0x04000C02 RID: 3074
		public double GAV_sellT1_C1;

		// Token: 0x04000C03 RID: 3075
		public double GAV_sellT2_C1;

		// Token: 0x04000C04 RID: 3076
		public double GAV_sellT3_C1;

		// Token: 0x04000C05 RID: 3077
		public double GAV_sell_C2;

		// Token: 0x04000C06 RID: 3078
		public double GAV_sellT1_C2;

		// Token: 0x04000C07 RID: 3079
		public double GAV_sellT2_C2;

		// Token: 0x04000C08 RID: 3080
		public double GAV_sellT3_C2;

		// Token: 0x04000C09 RID: 3081
		public double GAV_sell_C3;

		// Token: 0x04000C0A RID: 3082
		public double GAV_sellT1_C3;

		// Token: 0x04000C0B RID: 3083
		public double GAV_sellT2_C3;

		// Token: 0x04000C0C RID: 3084
		public double GAV_sellT3_C3;
	}
}
