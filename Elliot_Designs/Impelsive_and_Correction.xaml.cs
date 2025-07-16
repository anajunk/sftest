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

namespace New_SF_IT.Elliot_Designs
{
	// Token: 0x02000040 RID: 64
	public partial class Impelsive_and_Correction : UserControl
	{
		// Token: 0x06000311 RID: 785 RVA: 0x0006404D File Offset: 0x0006224D
		public Impelsive_and_Correction()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00064068 File Offset: 0x00062268
		public void Initialize_Variable()
		{
			try
			{
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

		// Token: 0x06000313 RID: 787 RVA: 0x000640C4 File Offset: 0x000622C4
		internal void Calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.midValue = Comman.get_MidValue(this.HIGH, this.LOW);
			this.diffvalue = Comman.get_Diff2Number(this.HIGH, this.LOW);
			this.Facto1 = 0.382 * this.diffvalue;
			this.temp_midValue = this.midValue;
			if (Equtiy_Future.NoOfHoldDays > 0)
			{
				this.DAYS2Hold = Equtiy_Future.NoOfHoldDays;
			}
			if (this.DAYS2Hold > 0)
			{
				this.diffvalue = (this.HIGH - this.LOW) / this.HIGH;
				this.diffvalue = this.midValue * this.diffvalue;
				this.diffvalue *= Math.Sqrt((double)this.DAYS2Hold);
				this.Facto1 = 0.382 * this.diffvalue;
			}
			this.gbSummaryHeader.Header = "Elliot Summary";
			this.elliotSummary2.Content = this.recommendation;
			this.Calculate_impulsiveCycle();
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000641CC File Offset: 0x000623CC
		[NullableContext(1)]
		private void display_Recommendation(string WaveType)
		{
			try
			{
				Dictionary<string, double> nameOfControl = Comman.find_PivotNearest2LTP2Value(this.all_calculatedTarget, this.LTP);
				if (nameOfControl.Count > 0)
				{
					DependencyObject up = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject upre = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(1).Key);
					DependencyObject down = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject dprevoius = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(1).Key);
					if (up != null || upre != null)
					{
						string trend = "RISING wave";
						if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
						{
							trend = "Non of wave";
							this.recommendation = string.Concat(new string[]
							{
								"Ref Price : ",
								this.LTP.ToString(),
								", is in ",
								trend,
								", wait for clear wave,",
								Environment.NewLine,
								" Enter Trade when Price touches any of the Entry Price."
							});
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							this.recommendation = Comman.up_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(up, upre);
						}
						this.gbSummaryHeader.Content = this.recommendation;
					}
					else if (down != null || dprevoius != null)
					{
						string trend = "FALLING Waves";
						if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
						{
							trend = "Non of wave";
							this.recommendation = string.Concat(new string[]
							{
								"Ref Price : ",
								this.LTP.ToString(),
								"is in ",
								trend,
								", wait for clear wave,",
								Environment.NewLine,
								" Enter Trade when Price touches any of the Entry Price."
							});
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							this.recommendation = Comman.down_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(down, dprevoius);
						}
						this.gbSummaryHeader.Content = this.recommendation;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00064444 File Offset: 0x00062644
		[NullableContext(1)]
		private void elliot_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00064448 File Offset: 0x00062648
		private void Calculate_impulsiveCycle()
		{
			this.all_calculatedTarget = new Dictionary<string, double>();
			this.Wave1 = this.LOW + this.Facto1;
			this.UpCycle_1_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_1_BuyEntry_Label.Inlines.Add("Wave 1");
			this.UpCycle_1_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW));
			this.UpCycle_1_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave1));
			this.Wave2 = this.Wave1 - this.Facto1 * 0.618;
			this.UpCycle_1_Target1_Label.Inlines.Clear();
			this.UpCycle_1_Target1_Label.Inlines.Add("Wave 2");
			this.UpCycle_1_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave1));
			this.UpCycle_1_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave2));
			this.Facto2 = 1.272 * this.Facto1;
			this.Wave3 = this.Wave2 + this.Facto2;
			this.UpCycle_1_Target2_Label.Inlines.Clear();
			this.UpCycle_1_Target2_Label.Inlines.Add("Wave 3");
			this.UpCycle_1_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave2));
			this.UpCycle_1_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave3));
			this.Wave4 = this.Wave3 - 0.618 * this.Facto2;
			this.UpCycle_1_Target3_Label.Inlines.Clear();
			this.UpCycle_1_Target3_Label.Inlines.Add("Wave 4");
			this.UpCycle_1_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave3));
			this.UpCycle_1_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave4));
			this.Wave5 = this.Wave4 + 1.618 * this.Facto1;
			this.WaveExp5 = this.Wave4 + 1.618 * this.Facto2;
			this.UpCycle_1_Target4_Label.Inlines.Clear();
			this.UpCycle_1_Target4_Label.Inlines.Add("Wave 5");
			this.UpCycle_1_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave4));
			this.UpCycle_1_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave5));
			this.UpCycle_1_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.WaveExp5));
			double cycle2Wave = this.WaveExp5 + this.Facto2;
			this.UpCycle_2_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_2_BuyEntry_Label.Inlines.Add("Wave 1");
			this.UpCycle_2_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.WaveExp5));
			this.UpCycle_2_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave));
			double cycle2Wave2 = cycle2Wave - this.Facto2 * 0.618;
			this.UpCycle_2_Target1_Label.Inlines.Clear();
			this.UpCycle_2_Target1_Label.Inlines.Add("Wave 2");
			this.UpCycle_2_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave));
			this.UpCycle_2_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave2));
			double cycle2Facto2 = 1.272 * this.Facto2;
			double cycle2Wave3 = cycle2Wave2 + cycle2Facto2;
			this.UpCycle_2_Target2_Label.Inlines.Clear();
			this.UpCycle_2_Target2_Label.Inlines.Add("Wave 3");
			this.UpCycle_2_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave2));
			this.UpCycle_2_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave3));
			double cycle2Wave4 = cycle2Wave3 - 0.618 * cycle2Facto2;
			this.UpCycle_2_Target3_Label.Inlines.Clear();
			this.UpCycle_2_Target3_Label.Inlines.Add("Wave 4");
			this.UpCycle_2_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave3));
			this.UpCycle_2_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave4));
			double cycle2Wave5 = cycle2Wave4 + 1.618 * this.Facto2;
			double cycle2WaveExp5 = cycle2Wave4 + 1.618 * cycle2Facto2;
			this.UpCycle_2_Target4_Label.Inlines.Clear();
			this.UpCycle_2_Target4_Label.Inlines.Add("Wave 5");
			this.UpCycle_2_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave4));
			this.UpCycle_2_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2Wave5));
			this.UpCycle_2_Target5_Label.Inlines.Clear();
			this.UpCycle_2_Target5_Label.Inlines.Add("Wave 5 Exp");
			this.UpCycle_2_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2WaveExp5));
			double cycle3Wave = cycle2WaveExp5 + cycle2Facto2;
			this.UpCycle_3_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_3_BuyEntry_Label.Inlines.Add("Wave 1");
			this.UpCycle_3_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle2WaveExp5));
			this.UpCycle_3_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave));
			double cycle3Wave2 = cycle3Wave - cycle2Facto2 * 0.618;
			this.UpCycle_3_Target1_Label.Inlines.Clear();
			this.UpCycle_3_Target1_Label.Inlines.Add("Wave 2");
			this.UpCycle_3_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave));
			this.UpCycle_3_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave2));
			double cycle3Facto2 = 1.272 * cycle2Facto2;
			double cycle3Wave3 = cycle3Wave2 + cycle3Facto2;
			this.UpCycle_3_Target2_Label.Inlines.Clear();
			this.UpCycle_3_Target2_Label.Inlines.Add("Wave 3");
			this.UpCycle_3_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave2));
			this.UpCycle_3_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave3));
			double cycle3Wave4 = cycle3Wave3 - 0.618 * cycle3Facto2;
			this.UpCycle_3_Target3_Label.Inlines.Clear();
			this.UpCycle_3_Target3_Label.Inlines.Add("Wave 4");
			this.UpCycle_3_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave3));
			this.UpCycle_3_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave4));
			double cycle3Wave5 = cycle3Wave4 + 1.618 * this.Facto2;
			double cycle3WaveExp5 = cycle3Wave4 + 1.618 * cycle3Facto2;
			this.UpCycle_3_Target4_Label.Inlines.Clear();
			this.UpCycle_3_Target4_Label.Inlines.Add("Wave 5");
			this.UpCycle_3_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave4));
			this.UpCycle_3_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3Wave5));
			this.UpCycle_3_Target5_Label.Inlines.Clear();
			this.UpCycle_3_Target5_Label.Inlines.Add("Wave 5 Exp");
			this.UpCycle_3_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(cycle3WaveExp5));
			this.Wave1 = this.HIGH - this.Facto1;
			this.DownCycle_1_SellEntry_Label.Inlines.Clear();
			this.DownCycle_1_SellEntry_Label.Inlines.Add("Wave 1");
			this.DownCycle_1_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH));
			this.DownCycle_1_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave1));
			this.Wave2 = this.Wave1 + this.Facto1 * 0.618;
			this.DownCycle_1_Target1_Label.Inlines.Clear();
			this.DownCycle_1_Target1_Label.Inlines.Add("Wave 2");
			this.DownCycle_1_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave1));
			this.DownCycle_1_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave2));
			this.Facto2 = 1.236 * this.Facto1;
			this.Wave3 = this.Wave2 - this.Facto2;
			this.DownCycle_1_Target2_Label.Inlines.Clear();
			this.DownCycle_1_Target2_Label.Inlines.Add("Wave 3");
			this.DownCycle_1_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave2));
			this.DownCycle_1_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave3));
			this.Wave4 = this.Wave3 + 0.618 * this.Facto2;
			this.DownCycle_1_Target3_Label.Inlines.Clear();
			this.DownCycle_1_Target3_Label.Inlines.Add("Wave 4");
			this.DownCycle_1_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave3));
			this.DownCycle_1_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave4));
			this.Wave5 = this.Wave4 - 1.618 * this.Facto1;
			this.WaveExp5 = this.Wave4 - 1.618 * this.Facto2;
			this.DownCycle_1_Target4_Label.Inlines.Clear();
			this.DownCycle_1_Target4_Label.Inlines.Add("Wave 5");
			this.DownCycle_1_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave4));
			this.DownCycle_1_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.Wave5));
			this.DownCycle_1_Target5_Label.Inlines.Clear();
			this.DownCycle_1_Target5_Label.Inlines.Add("Wave 5 Exp");
			this.DownCycle_1_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.WaveExp5));
			double dcycle2Wave = this.WaveExp5 - this.Facto1;
			this.DownCycle_2_SellEntry_Label.Inlines.Clear();
			this.DownCycle_2_SellEntry_Label.Inlines.Add("Wave 1");
			this.DownCycle_2_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.WaveExp5));
			this.DownCycle_2_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave));
			double dcycle2Wave2 = dcycle2Wave + this.Facto1 * 0.618;
			this.DownCycle_2_Target1_Label.Inlines.Clear();
			this.DownCycle_2_Target1_Label.Inlines.Add("Wave 2");
			this.DownCycle_2_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave));
			this.DownCycle_2_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave2));
			double dcycle2Facto = 1.236 * this.Facto1;
			double dcycle2Wave3 = dcycle2Wave2 - dcycle2Facto;
			this.DownCycle_2_Target2_Label.Inlines.Clear();
			this.DownCycle_2_Target2_Label.Inlines.Add("Wave 3");
			this.DownCycle_2_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave2));
			this.DownCycle_2_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave3));
			double dcycle2Wave4 = dcycle2Wave3 + 0.618 * dcycle2Facto;
			this.DownCycle_2_Target3_Label.Inlines.Clear();
			this.DownCycle_2_Target3_Label.Inlines.Add("Wave 4");
			this.DownCycle_2_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave3));
			this.DownCycle_2_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave4));
			double dcycleWave5 = dcycle2Wave4 - 1.618 * this.Facto1;
			double dcycleWaveExp5 = dcycle2Wave4 - 1.618 * dcycle2Facto;
			this.DownCycle_2_Target4_Label.Inlines.Clear();
			this.DownCycle_2_Target4_Label.Inlines.Add("Wave 5");
			this.DownCycle_2_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle2Wave4));
			this.DownCycle_2_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycleWave5));
			this.DownCycle_2_Target5_Label.Inlines.Clear();
			this.DownCycle_2_Target5_Label.Inlines.Add("Wave 5 Exp");
			this.DownCycle_2_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycleWaveExp5));
			double dcycle3Wave = dcycleWaveExp5 - this.Facto1;
			this.DownCycle_3_SellEntry_Label.Inlines.Clear();
			this.DownCycle_3_SellEntry_Label.Inlines.Add("Wave 1");
			this.DownCycle_3_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycleWaveExp5));
			this.DownCycle_3_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave));
			double dcycle3Wave2 = dcycle3Wave + this.Facto1 * 0.618;
			this.DownCycle_3_Target1_Label.Inlines.Clear();
			this.DownCycle_3_Target1_Label.Inlines.Add("Wave 2");
			this.DownCycle_3_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave));
			this.DownCycle_3_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave2));
			double dcycle3Factorial = 1.236 * this.Facto1;
			double dcycle3Wave3 = dcycle3Wave2 - dcycle3Factorial;
			this.DownCycle_3_Target2_Label.Inlines.Clear();
			this.DownCycle_3_Target2_Label.Inlines.Add("Wave 3");
			this.DownCycle_3_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave2));
			this.DownCycle_3_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave3));
			double dcycle3Wave4 = dcycle3Wave3 + 0.618 * dcycle3Factorial;
			this.DownCycle_3_Target3_Label.Inlines.Clear();
			this.DownCycle_3_Target3_Label.Inlines.Add("Wave 4");
			this.DownCycle_3_Target3_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave3));
			this.DownCycle_3_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave4));
			double dcycle3Wave5 = dcycle3Wave4 - 1.618 * this.Facto1;
			double dcycle3WaveExp5 = dcycle3Wave4 - 1.618 * dcycle3Factorial;
			this.DownCycle_3_Target4_Label.Inlines.Clear();
			this.DownCycle_3_Target4_Label.Inlines.Add("Wave 5");
			this.DownCycle_3_Target4_s.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave4));
			this.DownCycle_3_Target4_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3Wave5));
			this.DownCycle_3_Target5_Label.Inlines.Clear();
			this.DownCycle_3_Target5_Label.Inlines.Add("Wave 5 Exp");
			this.DownCycle_3_Target5_e.Inlines.Add(Comman.do_RoundOffAndReturnString(dcycle3WaveExp5));
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000652C6 File Offset: 0x000634C6
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

		// Token: 0x06000318 RID: 792 RVA: 0x000652F8 File Offset: 0x000634F8
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00065314 File Offset: 0x00063514
		private void clear_TableValues()
		{
			this.UpCycle_1_BuyEntry_s.Inlines.Clear();
			this.UpCycle_1_BuyEntry_e.Inlines.Clear();
			this.UpCycle_1_Target1_s.Inlines.Clear();
			this.UpCycle_1_Target1_e.Inlines.Clear();
			this.UpCycle_1_Target2_s.Inlines.Clear();
			this.UpCycle_1_Target2_e.Inlines.Clear();
			this.UpCycle_1_Target3_s.Inlines.Clear();
			this.UpCycle_1_Target3_e.Inlines.Clear();
			this.UpCycle_1_Target4_s.Inlines.Clear();
			this.UpCycle_1_Target4_e.Inlines.Clear();
			this.UpCycle_1_Target5_e.Inlines.Clear();
			this.UpCycle_2_BuyEntry_s.Inlines.Clear();
			this.UpCycle_2_BuyEntry_e.Inlines.Clear();
			this.UpCycle_2_Target1_s.Inlines.Clear();
			this.UpCycle_2_Target1_e.Inlines.Clear();
			this.UpCycle_2_Target2_s.Inlines.Clear();
			this.UpCycle_2_Target2_e.Inlines.Clear();
			this.UpCycle_2_Target3_s.Inlines.Clear();
			this.UpCycle_2_Target3_e.Inlines.Clear();
			this.UpCycle_2_Target4_s.Inlines.Clear();
			this.UpCycle_2_Target4_e.Inlines.Clear();
			this.UpCycle_2_Target5_e.Inlines.Clear();
			this.UpCycle_3_BuyEntry_s.Inlines.Clear();
			this.UpCycle_3_BuyEntry_e.Inlines.Clear();
			this.UpCycle_3_Target1_s.Inlines.Clear();
			this.UpCycle_3_Target1_e.Inlines.Clear();
			this.UpCycle_3_Target2_s.Inlines.Clear();
			this.UpCycle_3_Target2_e.Inlines.Clear();
			this.UpCycle_3_Target3_s.Inlines.Clear();
			this.UpCycle_3_Target3_e.Inlines.Clear();
			this.UpCycle_3_Target4_s.Inlines.Clear();
			this.UpCycle_3_Target4_e.Inlines.Clear();
			this.UpCycle_3_Target5_e.Inlines.Clear();
			this.DownCycle_1_SellEntry_s.Inlines.Clear();
			this.DownCycle_1_SellEntry_e.Inlines.Clear();
			this.DownCycle_1_Target1_s.Inlines.Clear();
			this.DownCycle_1_Target1_e.Inlines.Clear();
			this.DownCycle_1_Target2_s.Inlines.Clear();
			this.DownCycle_1_Target2_e.Inlines.Clear();
			this.DownCycle_1_Target3_s.Inlines.Clear();
			this.DownCycle_1_Target3_e.Inlines.Clear();
			this.DownCycle_1_Target4_s.Inlines.Clear();
			this.DownCycle_1_Target4_e.Inlines.Clear();
			this.DownCycle_1_Target5_e.Inlines.Clear();
			this.DownCycle_2_SellEntry_s.Inlines.Clear();
			this.DownCycle_2_SellEntry_e.Inlines.Clear();
			this.DownCycle_2_Target1_s.Inlines.Clear();
			this.DownCycle_2_Target1_e.Inlines.Clear();
			this.DownCycle_2_Target2_s.Inlines.Clear();
			this.DownCycle_2_Target2_e.Inlines.Clear();
			this.DownCycle_2_Target3_s.Inlines.Clear();
			this.DownCycle_2_Target3_e.Inlines.Clear();
			this.DownCycle_2_Target4_s.Inlines.Clear();
			this.DownCycle_2_Target4_e.Inlines.Clear();
			this.DownCycle_2_Target5_e.Inlines.Clear();
			this.DownCycle_3_SellEntry_s.Inlines.Clear();
			this.DownCycle_3_SellEntry_e.Inlines.Clear();
			this.DownCycle_3_Target1_s.Inlines.Clear();
			this.DownCycle_3_Target1_e.Inlines.Clear();
			this.DownCycle_3_Target2_s.Inlines.Clear();
			this.DownCycle_3_Target2_e.Inlines.Clear();
			this.DownCycle_3_Target3_s.Inlines.Clear();
			this.DownCycle_3_Target3_e.Inlines.Clear();
			this.DownCycle_3_Target4_s.Inlines.Clear();
			this.DownCycle_3_Target4_e.Inlines.Clear();
			this.DownCycle_3_Target5_e.Inlines.Clear();
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00065744 File Offset: 0x00063944
		private void remove_color()
		{
			this.UpCycle_1_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target3_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target4_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target4_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target5_e.Background = new SolidColorBrush(Colors.Transparent);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00065CBB File Offset: 0x00063EBB
		[NullableContext(1)]
		private void cbImpulsive_Checked(object sender, RoutedEventArgs e)
		{
			if (base.IsLoaded)
			{
				this.clear_TableValues();
				this.remove_color();
				this.Calculate_impulsiveCycle();
				this.elliotSummary2.Content = this.recommendation;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00065CE8 File Offset: 0x00063EE8
		[NullableContext(1)]
		private void cbCorrective_Checked(object sender, RoutedEventArgs e)
		{
			this.clear_TableValues();
			this.remove_color();
			this.elliotSummary2.Content = this.recommendation;
		}

		// Token: 0x04000899 RID: 2201
		private double LOW;

		// Token: 0x0400089A RID: 2202
		private double HIGH;

		// Token: 0x0400089B RID: 2203
		private double LTP;

		// Token: 0x0400089C RID: 2204
		private int DAYS2Hold;

		// Token: 0x0400089D RID: 2205
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x0400089E RID: 2206
		[Nullable(1)]
		private string recommendation = "Based on reference price, Refer the appropriate cycle to make trade entry.";

		// Token: 0x0400089F RID: 2207
		private double Wave1;

		// Token: 0x040008A0 RID: 2208
		private double Wave2;

		// Token: 0x040008A1 RID: 2209
		private double Facto2;

		// Token: 0x040008A2 RID: 2210
		private double Wave3;

		// Token: 0x040008A3 RID: 2211
		private double Wave4;

		// Token: 0x040008A4 RID: 2212
		private double Wave5;

		// Token: 0x040008A5 RID: 2213
		private double WaveExp5;

		// Token: 0x040008A6 RID: 2214
		private double CorrectiveWaveA;

		// Token: 0x040008A7 RID: 2215
		private double CorrectiveWaveB;

		// Token: 0x040008A8 RID: 2216
		private double CorrectiveWaveC;

		// Token: 0x040008A9 RID: 2217
		private double CorrectiveWaveExpC;

		// Token: 0x040008AA RID: 2218
		private double FCorrectiveWaveA;

		// Token: 0x040008AB RID: 2219
		private double FCorrectiveWaveB;

		// Token: 0x040008AC RID: 2220
		private double FCorrectiveWaveC;

		// Token: 0x040008AD RID: 2221
		private double FCorrectiveWaveExpC;

		// Token: 0x040008AE RID: 2222
		private double midValue;

		// Token: 0x040008AF RID: 2223
		private double diffvalue;

		// Token: 0x040008B0 RID: 2224
		private double Facto1;

		// Token: 0x040008B1 RID: 2225
		private double temp_midValue;

		// Token: 0x040008B2 RID: 2226
		private double CS;
	}
}
