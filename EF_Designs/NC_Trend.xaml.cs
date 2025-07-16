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
	// Token: 0x0200004A RID: 74
	public partial class NC_Trend : UserControl
	{
		// Token: 0x0600036C RID: 876 RVA: 0x00074CB6 File Offset: 0x00072EB6
		public NC_Trend()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00074CC4 File Offset: 0x00072EC4
		public void calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.all_calculatedTarget = new Dictionary<string, double>();
			if (Equtiy_Future.NoOfHoldDays >= 1)
			{
				this.DAYS2Hold = Equtiy_Future.NoOfHoldDays;
			}
			else if (Equtiy_Future.NoOfHoldDays < 1)
			{
				this.DAYS2Hold = 1;
			}
			if (this.ltp11days != null && this.ltp11days.Count == 11)
			{
				this.annualVola = this.get_Volatility(this.ltp11days);
				this.annualVola /= 100.0;
				this._refPrice = this.OPEN;
				this._1stCycle_1st_Intraday_Top = this._refPrice * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_2nd_Intraday_Top = this._refPrice * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_GoldenMean_Top = this._refPrice * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_MinorTop_Top = this._refPrice * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._1stCycleHyperTop = this._refPrice * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_1st_Intraday_Bottom = this._refPrice * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_2nd_Intraday_Bottom = this._refPrice * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_GoldenMean_Bottom = this._refPrice * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._1stCycle_MinorTop_Bottom = this._refPrice * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._1stCycleHyperBottom = this._refPrice * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_1st_Intraday_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_2nd_Intraday_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_GoldenMean_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_MinorTop_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._2ndCycleHyperTop = this._1stCycleHyperTop * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_1st_Intraday_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_2nd_Intraday_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_GoldenMean_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._2ndCycle_MinorTop_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._2ndCycleHyperBottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_1st_Intraday_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_2nd_Intraday_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_GoldenMean_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_MinorTop_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._3rdCycleHyperTop = this._2ndCycleHyperTop * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_1st_Intraday_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_2nd_Intraday_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_GoldenMean_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
				this._3rdCycle_MinorTop_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
				this._3rdCycleHyperBottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				if (this.LTP > this._3rdCycleHyperTop || this.LTP < this._3rdCycleHyperBottom)
				{
					this._refPrice = this.LTP;
					this._1stCycle_1st_Intraday_Top = this._refPrice * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_2nd_Intraday_Top = this._refPrice * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_GoldenMean_Top = this._refPrice * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_MinorTop_Top = this._refPrice * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._1stCycleHyperTop = this._refPrice * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_1st_Intraday_Bottom = this._refPrice * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_2nd_Intraday_Bottom = this._refPrice * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_GoldenMean_Bottom = this._refPrice * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._1stCycle_MinorTop_Bottom = this._refPrice * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._1stCycleHyperBottom = this._refPrice * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_1st_Intraday_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_2nd_Intraday_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_GoldenMean_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_MinorTop_Top = this._1stCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._2ndCycleHyperTop = this._1stCycleHyperTop * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_1st_Intraday_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_2nd_Intraday_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_GoldenMean_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._2ndCycle_MinorTop_Bottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._2ndCycleHyperBottom = this._1stCycleHyperBottom * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_1st_Intraday_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_2nd_Intraday_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_GoldenMean_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_MinorTop_Top = this._2ndCycleHyperTop * Math.Exp(this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._3rdCycleHyperTop = this._2ndCycleHyperTop * Math.Exp(this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_1st_Intraday_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_2nd_Intraday_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(2.0) * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_GoldenMean_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * 1.618 * (double)this.DAYS2Hold / 365.0);
					this._3rdCycle_MinorTop_Bottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * Math.Sqrt(10.0) * (double)this.DAYS2Hold / 365.0);
					this._3rdCycleHyperBottom = this._2ndCycleHyperBottom * Math.Exp(-this.annualVola * 2.0 * 3.141592653589793 * (double)this.DAYS2Hold / 365.0);
				}
			}
			this.UpCycle_1_BuyEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_1st_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, this._1stCycle_1st_Intraday_Top);
			this.UpCycle_1_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_2nd_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, this._1stCycle_2nd_Intraday_Top);
			this.UpCycle_1_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_GoldenMean_Top));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, this._1stCycle_GoldenMean_Top);
			this.UpCycle_1_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_MinorTop_Top));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, this._1stCycle_MinorTop_Top);
			this.UpCycle_1_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycleHyperTop));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, this._1stCycleHyperTop);
			this.UpCycle_2_BuyEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_1st_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, this._2ndCycle_1st_Intraday_Top);
			this.UpCycle_2_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_2nd_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, this._2ndCycle_2nd_Intraday_Top);
			this.UpCycle_2_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_GoldenMean_Top));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, this._2ndCycle_GoldenMean_Top);
			this.UpCycle_2_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_MinorTop_Top));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, this._2ndCycle_MinorTop_Top);
			this.UpCycle_2_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycleHyperTop));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, this._2ndCycleHyperTop);
			this.UpCycle_3_BuyEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_1st_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, this._3rdCycle_1st_Intraday_Top);
			this.UpCycle_3_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_2nd_Intraday_Top));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, this._3rdCycle_2nd_Intraday_Top);
			this.UpCycle_3_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_GoldenMean_Top));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, this._3rdCycle_GoldenMean_Top);
			this.UpCycle_3_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_MinorTop_Top));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, this._3rdCycle_MinorTop_Top);
			this.UpCycle_3_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycleHyperTop));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, this._3rdCycleHyperTop);
			this.DownCycle_1_SellEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_1st_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, this._1stCycle_1st_Intraday_Bottom);
			this.DownCycle_1_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_2nd_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, this._1stCycle_2nd_Intraday_Bottom);
			this.DownCycle_1_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_GoldenMean_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, this._1stCycle_GoldenMean_Bottom);
			this.DownCycle_1_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycle_MinorTop_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, this._1stCycle_MinorTop_Bottom);
			this.DownCycle_1_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._1stCycleHyperBottom));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, this._1stCycleHyperBottom);
			this.DownCycle_2_SellEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_1st_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, this._2ndCycle_1st_Intraday_Bottom);
			this.DownCycle_2_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_2nd_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, this._2ndCycle_2nd_Intraday_Bottom);
			this.DownCycle_2_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_GoldenMean_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, this._2ndCycle_GoldenMean_Bottom);
			this.DownCycle_2_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycle_MinorTop_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, this._2ndCycle_MinorTop_Bottom);
			this.DownCycle_2_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._2ndCycleHyperBottom));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, this._2ndCycleHyperBottom);
			this.DownCycle_3_SellEntry.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_1st_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, this._3rdCycle_1st_Intraday_Bottom);
			this.DownCycle_3_Target1.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_2nd_Intraday_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, this._3rdCycle_2nd_Intraday_Bottom);
			this.DownCycle_3_Target2.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_GoldenMean_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, this._3rdCycle_GoldenMean_Bottom);
			this.DownCycle_3_Target3.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycle_MinorTop_Bottom));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, this._3rdCycle_MinorTop_Bottom);
			this.DownCycle_3_Target4.Inlines.Add(NC_Trend.do_RoundOffAndReturnString(this._3rdCycleHyperBottom));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target4.Name, this._3rdCycleHyperBottom);
			string recommendation = string.Concat(new string[]
			{
				"Buy above 1st intraday top of 1st cycle, Stoploss is 2nd intraday bottom of 1st cycle. Final target Hyper cycle top.",
				Environment.NewLine,
				"Buy above 1st intraday top of 2nd cycle, Stoploss is  Hyper cyle top of 1st cycle. Final target 2nd  Hyper cycle top.",
				Environment.NewLine,
				"For Sell Entry, vice versa."
			});
			this.gbSummaryHeader.Content = recommendation;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00076108 File Offset: 0x00074308
		private void clear_TableValues()
		{
			this.UpCycle_1_BuyEntry.Inlines.Clear();
			this.UpCycle_1_Target1.Inlines.Clear();
			this.UpCycle_1_Target2.Inlines.Clear();
			this.UpCycle_1_Target3.Inlines.Clear();
			this.UpCycle_1_Target4.Inlines.Clear();
			this.UpCycle_2_BuyEntry.Inlines.Clear();
			this.UpCycle_2_Target1.Inlines.Clear();
			this.UpCycle_2_Target2.Inlines.Clear();
			this.UpCycle_2_Target3.Inlines.Clear();
			this.UpCycle_2_Target4.Inlines.Clear();
			this.UpCycle_3_BuyEntry.Inlines.Clear();
			this.UpCycle_3_Target1.Inlines.Clear();
			this.UpCycle_3_Target2.Inlines.Clear();
			this.UpCycle_3_Target3.Inlines.Clear();
			this.UpCycle_3_Target4.Inlines.Clear();
			this.DownCycle_1_SellEntry.Inlines.Clear();
			this.DownCycle_1_Target1.Inlines.Clear();
			this.DownCycle_1_Target2.Inlines.Clear();
			this.DownCycle_1_Target3.Inlines.Clear();
			this.DownCycle_1_Target4.Inlines.Clear();
			this.DownCycle_2_SellEntry.Inlines.Clear();
			this.DownCycle_2_Target1.Inlines.Clear();
			this.DownCycle_2_Target2.Inlines.Clear();
			this.DownCycle_2_Target3.Inlines.Clear();
			this.DownCycle_2_Target4.Inlines.Clear();
			this.DownCycle_3_SellEntry.Inlines.Clear();
			this.DownCycle_3_Target1.Inlines.Clear();
			this.DownCycle_3_Target2.Inlines.Clear();
			this.DownCycle_3_Target3.Inlines.Clear();
			this.DownCycle_3_Target4.Inlines.Clear();
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000762F8 File Offset: 0x000744F8
		[NullableContext(1)]
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

		// Token: 0x06000370 RID: 880 RVA: 0x000763B8 File Offset: 0x000745B8
		[NullableContext(1)]
		public static string do_RoundOffAndReturnString(double _value)
		{
			return Math.Round(_value, 3).ToString();
		}

		// Token: 0x06000371 RID: 881 RVA: 0x000763D4 File Offset: 0x000745D4
		private void Initialize_Variable()
		{
			try
			{
				if (Equtiy_Future.LTP_MONTH != null || Equtiy_Future.LTP_MONTH.Count > 10)
				{
					this.ltp11days = new List<double>();
					this.ltp11days = Equtiy_Future.LTP_MONTH.Skip(Equtiy_Future.LTP_MONTH.Count - 11).ToList<double>();
					if (Equtiy_Future.LIVE_DATA != null)
					{
						this.LOW = Equtiy_Future.LIVE_DATA.low;
						this.HIGH = Equtiy_Future.LIVE_DATA.high;
						this.LTP = Equtiy_Future.LIVE_DATA.ltp;
						this.OPEN = Equtiy_Future.LIVE_DATA.open;
						this.PREVCLOSE = Equtiy_Future.LIVE_DATA.preClose;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000DF7 RID: 3575
		private double LOW;

		// Token: 0x04000DF8 RID: 3576
		private double HIGH;

		// Token: 0x04000DF9 RID: 3577
		private double LTP;

		// Token: 0x04000DFA RID: 3578
		private double OPEN;

		// Token: 0x04000DFB RID: 3579
		private double PREVCLOSE;

		// Token: 0x04000DFC RID: 3580
		private double annualVola;

		// Token: 0x04000DFD RID: 3581
		private int DAYS2Hold;

		// Token: 0x04000DFE RID: 3582
		[Nullable(1)]
		private List<double> ltp11days;

		// Token: 0x04000DFF RID: 3583
		public static double midValue;

		// Token: 0x04000E00 RID: 3584
		public static double CFactY;

		// Token: 0x04000E01 RID: 3585
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x04000E02 RID: 3586
		private double _1stCycleHyperTop;

		// Token: 0x04000E03 RID: 3587
		private double _2ndCycleHyperTop;

		// Token: 0x04000E04 RID: 3588
		private double _3rdCycleHyperTop;

		// Token: 0x04000E05 RID: 3589
		private double _1stCycleHyperBottom;

		// Token: 0x04000E06 RID: 3590
		private double _2ndCycleHyperBottom;

		// Token: 0x04000E07 RID: 3591
		private double _3rdCycleHyperBottom;

		// Token: 0x04000E08 RID: 3592
		private double _refPrice;

		// Token: 0x04000E09 RID: 3593
		private double _1stCycle_1st_Intraday_Top;

		// Token: 0x04000E0A RID: 3594
		private double _2ndCycle_1st_Intraday_Top;

		// Token: 0x04000E0B RID: 3595
		private double _3rdCycle_1st_Intraday_Top;

		// Token: 0x04000E0C RID: 3596
		private double _1stCycle_1st_Intraday_Bottom;

		// Token: 0x04000E0D RID: 3597
		private double _2ndCycle_1st_Intraday_Bottom;

		// Token: 0x04000E0E RID: 3598
		private double _3rdCycle_1st_Intraday_Bottom;

		// Token: 0x04000E0F RID: 3599
		private double _1stCycle_2nd_Intraday_Top;

		// Token: 0x04000E10 RID: 3600
		private double _2ndCycle_2nd_Intraday_Top;

		// Token: 0x04000E11 RID: 3601
		private double _3rdCycle_2nd_Intraday_Top;

		// Token: 0x04000E12 RID: 3602
		private double _1stCycle_2nd_Intraday_Bottom;

		// Token: 0x04000E13 RID: 3603
		private double _2ndCycle_2nd_Intraday_Bottom;

		// Token: 0x04000E14 RID: 3604
		private double _3rdCycle_2nd_Intraday_Bottom;

		// Token: 0x04000E15 RID: 3605
		public double _1stCycle_GoldenMean_Top;

		// Token: 0x04000E16 RID: 3606
		public double _2ndCycle_GoldenMean_Top;

		// Token: 0x04000E17 RID: 3607
		public double _3rdCycle_GoldenMean_Top;

		// Token: 0x04000E18 RID: 3608
		public double _1stCycle_GoldenMean_Bottom;

		// Token: 0x04000E19 RID: 3609
		public double _2ndCycle_GoldenMean_Bottom;

		// Token: 0x04000E1A RID: 3610
		public double _3rdCycle_GoldenMean_Bottom;

		// Token: 0x04000E1B RID: 3611
		public double _1stCycle_MinorTop_Top;

		// Token: 0x04000E1C RID: 3612
		public double _2ndCycle_MinorTop_Top;

		// Token: 0x04000E1D RID: 3613
		public double _3rdCycle_MinorTop_Top;

		// Token: 0x04000E1E RID: 3614
		public double _1stCycle_MinorTop_Bottom;

		// Token: 0x04000E1F RID: 3615
		public double _2ndCycle_MinorTop_Bottom;

		// Token: 0x04000E20 RID: 3616
		public double _3rdCycle_MinorTop_Bottom;
	}
}
