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
using System.Windows.Media;
using New_SF_IT.classes;

namespace New_SF_IT.Fibonacci
{
	// Token: 0x0200003D RID: 61
	public partial class ParallelProjection : UserControl
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0005F99F File Offset: 0x0005DB9F
		public ParallelProjection()
		{
			this.InitializeComponent();
			this.Calculate();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0005F9B4 File Offset: 0x0005DBB4
		public void Initialize_Variable()
		{
			try
			{
				if (Equtiy_Future.LTP_MONTH != null || Equtiy_Future.LTP_MONTH.Count > 10)
				{
					this.ltp11days = new List<double>();
					this.ltp11days = Equtiy_Future.LTP_MONTH.Skip(Equtiy_Future.LTP_MONTH.Count - 11).ToList<double>();
				}
				if (Equtiy_Future.LIVE_DATA != null)
				{
					this.LOW = Equtiy_Future.LIVE_DATA.low;
					this.HIGH = Equtiy_Future.LIVE_DATA.high;
					this.LTP = Equtiy_Future.LIVE_DATA.ltp;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0005FA50 File Offset: 0x0005DC50
		public void Calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.all_calculatedTarget = new Dictionary<string, double>();
			if (this.ltp11days != null)
			{
				if (this.ltp11days.Count == 11)
				{
					this.days10volatility = volatilityHelp.get_Volatility(this.ltp11days, 1);
				}
				else
				{
					this.days10volatility = (this.HIGH - this.LOW) / this.HIGH;
				}
			}
			this.midValue = (this.HIGH + this.LOW) / 2.0;
			ParallelProjection.range = this.days10volatility * this.LTP;
			double CFactX = this.days10volatility;
			double num = this.midValue * CFactX;
			double BEandSL_ratio = 0.618;
			double T1ratio = 0.786;
			double T2ratio = 0.888;
			double T3ratio = 1.236;
			double T4ratio = 1.618;
			double ratioA = 1.236;
			double ratioB = 1.618;
			if (Equtiy_Future.NoOfHoldDays > 0)
			{
				this.DAYS2Hold = Equtiy_Future.NoOfHoldDays;
			}
			if (this.DAYS2Hold > 0)
			{
				double num2 = this.midValue;
				Math.Sqrt((double)this.DAYS2Hold);
				BEandSL_ratio = 0.236;
				T1ratio = 0.382;
				T2ratio = 0.5;
				T3ratio = 0.618;
				T4ratio = 0.786;
				ratioA = 0.5;
				ratioB = 0.618;
			}
			this.UpCycle_1_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW + BEandSL_ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW + T1ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
			this.UpCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW + T2ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
			this.UpCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW + T3ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
			this.UpCycle_1_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW + T4ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text));
			double secondCycleStart = Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text);
			double ParaX = secondCycleStart + ratioB * ParallelProjection.range - (secondCycleStart + ratioA * ParallelProjection.range);
			this.UpCycle_2_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(secondCycleStart + ParaX * BEandSL_ratio));
			this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(secondCycleStart + ParaX * T1ratio));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
			this.UpCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(secondCycleStart + ParaX * T2ratio));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
			this.UpCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(secondCycleStart + ParaX * T3ratio));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
			this.UpCycle_2_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(secondCycleStart + ParaX * T4ratio));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text));
			double thirdCycleStart = Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text);
			double ParaY = thirdCycleStart + ratioB * ParallelProjection.range - (thirdCycleStart + ratioA * ParallelProjection.range);
			this.UpCycle_3_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdCycleStart + ParaY * BEandSL_ratio));
			this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdCycleStart + ParaY * T1ratio));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
			this.UpCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdCycleStart + ParaY * T2ratio));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
			this.UpCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdCycleStart + ParaY * T3ratio));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
			this.UpCycle_3_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdCycleStart + ParaY * T4ratio));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target4.Inlines.FirstInline).Text));
			this.DownCycle_1_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH - BEandSL_ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH - T1ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
			this.DownCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH - T2ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
			this.DownCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH - T3ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
			this.DownCycle_1_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH - T4ratio * ParallelProjection.range));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text));
			double secondDownCycle = Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text);
			double DecayParaX = secondDownCycle - ratioA * ParallelProjection.range - (secondDownCycle - ratioB * ParallelProjection.range);
			this.DownCycle_2_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(secondDownCycle - BEandSL_ratio * DecayParaX));
			this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(secondDownCycle - T1ratio * DecayParaX));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
			this.DownCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(secondDownCycle - T2ratio * DecayParaX));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
			this.DownCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(secondDownCycle - T3ratio * DecayParaX));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
			this.DownCycle_2_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(secondDownCycle - T4ratio * DecayParaX));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text));
			double thirdDownCycle = Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text);
			double DecayParaY = thirdDownCycle - ratioA * ParallelProjection.range - (thirdDownCycle - ratioB * ParallelProjection.range);
			this.DownCycle_3_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdDownCycle - BEandSL_ratio * DecayParaY));
			this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdDownCycle - T1ratio * DecayParaY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
			this.DownCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdDownCycle - T2ratio * DecayParaY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
			this.DownCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdDownCycle - T3ratio * DecayParaY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
			this.DownCycle_3_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(thirdDownCycle - T4ratio * DecayParaY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target4.Inlines.FirstInline).Text));
			string recommendation = "";
			try
			{
				Dictionary<string, double> nameOfControl = Comman.find_Nearest2LTP2Value(this.all_calculatedTarget, this.LTP);
				if (nameOfControl.Count > 0)
				{
					DependencyObject up = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject upre = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(1).Key);
					DependencyObject down = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject dpre = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(1).Key);
					if (up != null || upre != null)
					{
						string trend = "GROWTH Retracement";
						if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
						{
							trend = "Non of Cycle";
							recommendation = string.Concat(new string[]
							{
								"Ref Price : ",
								this.LTP.ToString(),
								", is in ",
								trend,
								", wait for clear Trend,",
								Environment.NewLine,
								" Enter Trade when Price touches any of the Entry Price."
							});
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = Comman.up_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(up, upre);
						}
						this.gbSummaryHeader.Content = recommendation;
						return;
					}
					if (down != null || dpre != null)
					{
						string trend = "DECAY Retracement";
						if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
						{
							trend = "Non of Cycle";
							recommendation = string.Concat(new string[]
							{
								"Ref Price : ",
								this.LTP.ToString(),
								"is in ",
								trend,
								", wait for clear Trend,",
								Environment.NewLine,
								" Enter Trade when Price touches any of the Entry Price."
							});
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = Comman.down_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(down, dpre);
						}
						this.gbSummaryHeader.Content = recommendation;
						return;
					}
				}
			}
			catch (Exception)
			{
			}
			this.gbSummaryHeader.Header = "Fibonacci Parallel Summary";
			this.fibonacciSummary1.Content = recommendation;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00060908 File Offset: 0x0005EB08
		[NullableContext(1)]
		private void fiboParallel_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0006090A File Offset: 0x0005EB0A
		[NullableContext(1)]
		private void paintTheTarget(object a, object b)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
			if (b != null)
			{
				(b as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0006093C File Offset: 0x0005EB3C
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00060958 File Offset: 0x0005EB58
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

		// Token: 0x040007C5 RID: 1989
		private double midValue;

		// Token: 0x040007C6 RID: 1990
		public static double range;

		// Token: 0x040007C7 RID: 1991
		private double LOW;

		// Token: 0x040007C8 RID: 1992
		private double HIGH;

		// Token: 0x040007C9 RID: 1993
		private double LTP;

		// Token: 0x040007CA RID: 1994
		private int DAYS2Hold;

		// Token: 0x040007CB RID: 1995
		[Nullable(1)]
		private List<double> ltp11days;

		// Token: 0x040007CC RID: 1996
		private double days10volatility;

		// Token: 0x040007CD RID: 1997
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;
	}
}
