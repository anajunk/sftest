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

namespace New_SF_IT.Average_and_Pivot_Principle
{
	// Token: 0x02000056 RID: 86
	public partial class Pivotpoint : UserControl
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x00088BAB File Offset: 0x00086DAB
		public Pivotpoint()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00088BBC File Offset: 0x00086DBC
		public void Calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.all_calculatedTarget = new Dictionary<string, double>();
			double pivot = this.get_pivotpoint(this.HIGH, this.LOW, this.PRECLOSE);
			double R = 2.0 * pivot - this.LOW;
			double S = 2.0 * pivot - this.HIGH;
			double R2 = pivot + (R - S);
			double R3 = this.HIGH + 2.0 * (pivot - this.LOW);
			double S2 = pivot - (R - S);
			double S3 = this.LOW - 2.0 * (this.HIGH - pivot);
			this.UpCycle_1_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot));
			this.UpCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(R));
			this.UpCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(R2));
			this.UpCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(R3));
			this.DownCycle_1_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot));
			this.DownCycle_1_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(S));
			this.DownCycle_1_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(S2));
			this.DownCycle_1_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(S3));
			double pivot2 = this.get_pivotpoint(R, R2, R3);
			double R1_cycle2 = 2.0 * pivot2 - R;
			double S1_cycle2 = 2.0 * pivot2 - R3;
			double R2_cycle2 = pivot2 + (R1_cycle2 - S1_cycle2);
			double R3_cycle2 = R3 + 2.0 * (pivot2 - R);
			double S2_cycle2 = pivot2 - (R1_cycle2 - S1_cycle2);
			double S3_cycle2 = R - 2.0 * (R3 - pivot2);
			this.UpCycle_2_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot2));
			this.UpCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(R1_cycle2));
			this.UpCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(R2_cycle2));
			this.UpCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(R3_cycle2));
			this.DownCycle_2_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot2));
			this.DownCycle_2_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(S1_cycle2));
			this.DownCycle_2_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(S2_cycle2));
			this.DownCycle_2_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(S3_cycle2));
			double pivot3 = this.get_pivotpoint(R1_cycle2, R2_cycle2, R3_cycle2);
			double R1_cycle3 = 2.0 * pivot3 - R1_cycle2;
			double S1_cycle3 = 2.0 * pivot3 - R3_cycle2;
			double R2_cycle3 = pivot3 + (R1_cycle3 - S1_cycle3);
			double R3_cycle3 = R3_cycle2 + 2.0 * (pivot3 - R1_cycle2);
			double S2_cycle3 = pivot3 - (R1_cycle3 - S1_cycle3);
			double S3_cycle3 = R1_cycle2 - 2.0 * (R3_cycle2 - pivot3);
			this.UpCycle_3_BuyEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot3));
			this.UpCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(R1_cycle3));
			this.UpCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(R2_cycle3));
			this.UpCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(R3_cycle3));
			this.DownCycle_3_SellEntry.Inlines.Add(Comman.do_RoundOffAndReturnString(pivot3));
			this.DownCycle_3_Target1.Inlines.Add(Comman.do_RoundOffAndReturnString(S1_cycle3));
			this.DownCycle_3_Target2.Inlines.Add(Comman.do_RoundOffAndReturnString(S2_cycle3));
			this.DownCycle_3_Target3.Inlines.Add(Comman.do_RoundOffAndReturnString(S3_cycle3));
			string recommendation = "Based on reference price, Refer the appropriate cycle to make trade entry.";
			this.gbSummaryHeader.Header = "Pivot Point Summary";
			this.pivotSummary1.Content = recommendation;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00088F80 File Offset: 0x00087180
		[NullableContext(1)]
		private string pivotRecommendation(Dictionary<string, double> nameOfControl, double LTP, string trend)
		{
			string recommendation = "";
			string target = nameOfControl.ElementAt(0).Key;
			string cycle;
			if (target == "NULL")
			{
				target = nameOfControl.ElementAt(1).Key;
				cycle = target.Substring(0, target.LastIndexOf("_"));
			}
			else
			{
				cycle = target.Substring(0, target.LastIndexOf("_"));
			}
			if (!(cycle == "UpCycle_1"))
			{
				if (!(cycle == "UpCycle_2"))
				{
					if (!(cycle == "UpCycle_3"))
					{
						if (!(cycle == "DownCycle_1"))
						{
							if (!(cycle == "DownCycle_2"))
							{
								if (cycle == "DownCycle_3")
								{
									this.supCycle3.Background = Brushes.BlueViolet;
									recommendation = "Price in Support Cycle 3, ##Recommendation Wait for Wait for Price to enter Fresh Cycle";
									Equtiy_Future.neutralCount.Add("0");
								}
							}
							else
							{
								this.supCycle2.Background = Brushes.BlueViolet;
								recommendation = "Price in Support Cycle 2, ##Recommendation Sell";
								Equtiy_Future.sellCount.Add("-1");
							}
						}
						else
						{
							this.supCycle1.Background = Brushes.BlueViolet;
							recommendation = "Price in Support Cycle 1, ##Recommendation Sell";
							Equtiy_Future.neutralCount.Add("-1");
						}
					}
					else
					{
						this.resCycle3.Background = Brushes.BlueViolet;
						recommendation = "Price in Restance Cycle 3, ##Recommendation Wait for Price to enter Fresh Cycle";
						Equtiy_Future.neutralCount.Add("0");
					}
				}
				else
				{
					this.resCycle2.Background = Brushes.BlueViolet;
					recommendation = "Price in Restance Cycle 2, ##Recommendation Buy";
					Equtiy_Future.buyCount.Add("1");
				}
			}
			else
			{
				this.resCycle1.Background = Brushes.BlueViolet;
				recommendation = "Price in Restance Cycle 1, ##Recommendation Buy";
				Equtiy_Future.buyCount.Add("1");
			}
			return recommendation;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0008913C File Offset: 0x0008733C
		private void Initialize_Variable()
		{
			try
			{
				if (Equtiy_Future.LIVE_DATA != null)
				{
					this.LOW = Equtiy_Future.LIVE_DATA.low;
					this.HIGH = Equtiy_Future.LIVE_DATA.high;
					this.LTP = Equtiy_Future.LIVE_DATA.ltp;
					this.PRECLOSE = Equtiy_Future.LIVE_DATA.preClose;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000891A8 File Offset: 0x000873A8
		private double get_pivotpoint(double HIGH, double LOW, double PRECLOSE)
		{
			return (HIGH + LOW + PRECLOSE) / 3.0;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000891BC File Offset: 0x000873BC
		private void clear_TableValues()
		{
			this.UpCycle_1_BuyEntry.Inlines.Clear();
			this.UpCycle_1_Target1.Inlines.Clear();
			this.UpCycle_1_Target2.Inlines.Clear();
			this.UpCycle_1_Target3.Inlines.Clear();
			this.UpCycle_2_BuyEntry.Inlines.Clear();
			this.UpCycle_2_Target1.Inlines.Clear();
			this.UpCycle_2_Target2.Inlines.Clear();
			this.UpCycle_2_Target3.Inlines.Clear();
			this.UpCycle_3_BuyEntry.Inlines.Clear();
			this.UpCycle_3_Target1.Inlines.Clear();
			this.UpCycle_3_Target2.Inlines.Clear();
			this.UpCycle_3_Target3.Inlines.Clear();
			this.DownCycle_1_SellEntry.Inlines.Clear();
			this.DownCycle_1_Target1.Inlines.Clear();
			this.DownCycle_1_Target2.Inlines.Clear();
			this.DownCycle_1_Target3.Inlines.Clear();
			this.DownCycle_2_SellEntry.Inlines.Clear();
			this.DownCycle_2_Target1.Inlines.Clear();
			this.DownCycle_2_Target2.Inlines.Clear();
			this.DownCycle_2_Target3.Inlines.Clear();
			this.DownCycle_3_SellEntry.Inlines.Clear();
			this.DownCycle_3_Target1.Inlines.Clear();
			this.DownCycle_3_Target2.Inlines.Clear();
			this.DownCycle_3_Target3.Inlines.Clear();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00089349 File Offset: 0x00087549
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

		// Token: 0x060003F0 RID: 1008 RVA: 0x0008937B File Offset: 0x0008757B
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x0400122D RID: 4653
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x0400122E RID: 4654
		[Nullable(1)]
		private Dictionary<string, double> PRE;

		// Token: 0x0400122F RID: 4655
		private double LOW;

		// Token: 0x04001230 RID: 4656
		private double HIGH;

		// Token: 0x04001231 RID: 4657
		private double LTP;

		// Token: 0x04001232 RID: 4658
		private double PRECLOSE;
	}
}
