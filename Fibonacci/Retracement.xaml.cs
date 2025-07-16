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
	// Token: 0x0200003E RID: 62
	public partial class Retracement : UserControl
	{
		// Token: 0x060002FB RID: 763 RVA: 0x00060E74 File Offset: 0x0005F074
		public Retracement()
		{
			this.InitializeComponent();
			this.calculate();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00060E88 File Offset: 0x0005F088
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
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00060F28 File Offset: 0x0005F128
		public void calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.all_calculatedTarget = new Dictionary<string, double>();
			double high = this.HIGH;
			double low = this.LOW;
			Retracement.midValue = (this.HIGH + this.LOW) / 2.0;
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
			double CFactX = this.days10volatility;
			Retracement.CFactY = Retracement.midValue * CFactX;
			double cfactY = Retracement.CFactY;
			double baseRatioBEorSL = 0.236;
			double T1ratio = 0.382;
			double T2ratio = 0.5;
			double T3ratio = 0.618;
			double T4ratio = 0.786;
			this.UpCycle_1_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue + baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue + T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
			this.UpCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue + T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
			this.UpCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue + T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
			this.UpCycle_1_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue + T4ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text));
			double Up1Target4 = Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text);
			this.UpCycle_2_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Up1Target4 + baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Up1Target4 + T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
			this.UpCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Up1Target4 + T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
			this.UpCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Up1Target4 + T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
			this.UpCycle_2_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Up1Target4 + T4ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text));
			double Up2Target4 = Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text);
			this.UpCycle_3_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Up2Target4 + baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text));
			this.UpCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Up2Target4 + T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
			this.UpCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Up2Target4 + T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
			this.UpCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Up2Target4 + T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
			this.UpCycle_3_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Up2Target4 + T4ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target4.Inlines.FirstInline).Text));
			this.DownCycle_1_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue - baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue - T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
			this.DownCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue - T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
			this.DownCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue - T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
			this.DownCycle_1_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Retracement.midValue - T4ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text));
			double Down1Target4 = Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text);
			this.DownCycle_2_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Down1Target4 - baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Down1Target4 - T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
			this.DownCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Down1Target4 - T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
			this.DownCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Down1Target4 - T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
			this.DownCycle_2_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Down1Target4 - T4ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text));
			double Down2Target4 = Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text);
			this.DownCycle_3_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(Down2Target4 - baseRatioBEorSL * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text));
			this.DownCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(Down2Target4 - T1ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
			this.DownCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(Down2Target4 - T2ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
			this.DownCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(Down2Target4 - T3ratio * Retracement.CFactY));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
			this.DownCycle_3_Target4.Inlines.Add(Comman.do_RoundOffAndReturnString(Down2Target4 - T4ratio * Retracement.CFactY));
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
							this.paintTheTarget(dpre);
							Equtiy_Future.sellCount.Add("-1");
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
			this.gbSummaryHeader.Header = "Fibonacci Retracement Summary";
			this.fibonacciSummary1.Content = recommendation;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00061D20 File Offset: 0x0005FF20
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

		// Token: 0x060002FF RID: 767 RVA: 0x00061D52 File Offset: 0x0005FF52
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00061D6C File Offset: 0x0005FF6C
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

		// Token: 0x040007FA RID: 2042
		private double LOW;

		// Token: 0x040007FB RID: 2043
		private double HIGH;

		// Token: 0x040007FC RID: 2044
		private double LTP;

		// Token: 0x040007FD RID: 2045
		private double days10volatility;

		// Token: 0x040007FE RID: 2046
		[Nullable(1)]
		private List<double> ltp11days;

		// Token: 0x040007FF RID: 2047
		public static double midValue;

		// Token: 0x04000800 RID: 2048
		public static double CFactY;

		// Token: 0x04000801 RID: 2049
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;
	}
}
