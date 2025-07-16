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
	// Token: 0x0200003F RID: 63
	public partial class Corrective : UserControl
	{
		// Token: 0x06000303 RID: 771 RVA: 0x00062288 File Offset: 0x00060488
		public Corrective()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000622A4 File Offset: 0x000604A4
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

		// Token: 0x06000305 RID: 773 RVA: 0x00062300 File Offset: 0x00060500
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
			this.Calculate_CorrectiveCycle();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00062408 File Offset: 0x00060608
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

		// Token: 0x06000307 RID: 775 RVA: 0x00062680 File Offset: 0x00060880
		[NullableContext(1)]
		public static Dictionary<string, double> find_PivotNearest2LTP2Value(Dictionary<string, double> all_calculatedTarget, double LTP)
		{
			Dictionary<string, double> bestMatchTarget = new Dictionary<string, double>();
			Dictionary<string, double> result;
			try
			{
				all_calculatedTarget = (from x in all_calculatedTarget
				orderby x.Value descending
				select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				int i;
				for (i = 0; i < all_calculatedTarget.Count; i++)
				{
					if (i < all_calculatedTarget.Count - 1)
					{
						if (LTP <= all_calculatedTarget.ElementAt(i).Value && LTP >= all_calculatedTarget.ElementAt(i + 1).Value)
						{
							bestMatchTarget.Add(all_calculatedTarget.ElementAt(i).Key, all_calculatedTarget.ElementAt(i).Value);
							break;
						}
					}
					else if (LTP <= all_calculatedTarget.ElementAt(i).Value)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i).Key, all_calculatedTarget.ElementAt(i).Value);
						break;
					}
				}
				if (i == all_calculatedTarget.Count - 1 && bestMatchTarget.Count < 0)
				{
					bestMatchTarget.Add(all_calculatedTarget.ElementAt(0).Key, all_calculatedTarget.ElementAt(0).Value);
					bestMatchTarget.Add("NULL", 0.0);
				}
				else
				{
					bool sellEntry = all_calculatedTarget.ElementAt(i).Key.Contains("_SellEntry");
					if (all_calculatedTarget.ElementAt(i).Key.Contains("_BuyEntry") || sellEntry)
					{
						bestMatchTarget.Add("NULL", 0.0);
					}
					else if (i != 0)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i - 1).Key, all_calculatedTarget.ElementAt(i - 1).Value);
					}
					bestMatchTarget = (from x in bestMatchTarget
					orderby x.Value
					select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				}
				result = bestMatchTarget;
			}
			catch (Exception)
			{
				result = bestMatchTarget;
			}
			return result;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00062900 File Offset: 0x00060B00
		[NullableContext(1)]
		private void elliot_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00062904 File Offset: 0x00060B04
		private void Calculate_CorrectiveCycle()
		{
			this.CS = 0.618 * this.diffvalue;
			this.CorrectiveWaveA = this.LOW + this.CS;
			this.all_calculatedTarget = new Dictionary<string, double>();
			this.UpCycle_1_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_1_BuyEntry_Label.Inlines.Add("Wave A");
			this.UpCycle_1_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.LOW));
			this.UpCycle_1_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.CorrectiveWaveB = this.CorrectiveWaveA - 0.618 * this.CS;
			this.UpCycle_1_Target1_Label.Inlines.Clear();
			this.UpCycle_1_Target1_Label.Inlines.Add("Wave B");
			this.UpCycle_1_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.UpCycle_1_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.CorrectiveWaveC = this.CorrectiveWaveB + 1.236 * (0.618 * this.CS);
			this.CorrectiveWaveExpC = this.CorrectiveWaveB + 1.618 * (0.618 * this.CS);
			this.UpCycle_1_Target2_Label.Inlines.Clear();
			this.UpCycle_1_Target2_Label.Inlines.Add("Wave C");
			this.UpCycle_1_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.UpCycle_1_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveC));
			this.UpCycle_1_Target3_Label.Inlines.Clear();
			this.UpCycle_1_Target3_Label.Inlines.Add("Wave C Exp");
			this.UpCycle_1_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveExpC));
			this.CorrectiveWaveA = this.CorrectiveWaveExpC + this.CS;
			this.UpCycle_2_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_2_BuyEntry_Label.Inlines.Add("Wave A");
			this.UpCycle_2_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveExpC));
			this.UpCycle_2_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.CorrectiveWaveB = this.CorrectiveWaveA - 0.618 * this.CS;
			this.UpCycle_2_Target1_Label.Inlines.Clear();
			this.UpCycle_2_Target1_Label.Inlines.Add("Wave B");
			this.UpCycle_2_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.UpCycle_2_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.CorrectiveWaveC = this.CorrectiveWaveB + 1.236 * (0.618 * this.CS);
			this.CorrectiveWaveExpC = this.CorrectiveWaveB + 1.618 * (0.618 * this.CS);
			this.UpCycle_2_Target2_Label.Inlines.Clear();
			this.UpCycle_2_Target2_Label.Inlines.Add("Wave C");
			this.UpCycle_2_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.UpCycle_2_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveC));
			this.UpCycle_2_Target3_Label.Inlines.Clear();
			this.UpCycle_2_Target3_Label.Inlines.Add("Wave C Exp");
			this.UpCycle_2_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveExpC));
			this.CorrectiveWaveA = this.CorrectiveWaveExpC + this.CS;
			this.UpCycle_3_BuyEntry_Label.Inlines.Clear();
			this.UpCycle_3_BuyEntry_Label.Inlines.Add("Wave A");
			this.UpCycle_3_BuyEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveExpC));
			this.UpCycle_3_BuyEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.CorrectiveWaveB = this.CorrectiveWaveA - 0.618 * this.CS;
			this.UpCycle_3_Target1_Label.Inlines.Clear();
			this.UpCycle_3_Target1_Label.Inlines.Add("Wave B");
			this.UpCycle_3_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveA));
			this.UpCycle_3_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.CorrectiveWaveC = this.CorrectiveWaveB + 1.236 * (0.618 * this.CS);
			this.CorrectiveWaveExpC = this.CorrectiveWaveB + 1.618 * (0.618 * this.CS);
			this.UpCycle_3_Target2_Label.Inlines.Clear();
			this.UpCycle_3_Target2_Label.Inlines.Add("Wave C");
			this.UpCycle_3_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveB));
			this.UpCycle_3_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveC));
			this.UpCycle_3_Target3_Label.Inlines.Clear();
			this.UpCycle_3_Target3_Label.Inlines.Add("Wave C Exp");
			this.UpCycle_3_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.CorrectiveWaveExpC));
			this.FCorrectiveWaveA = this.HIGH - this.CS;
			this.DownCycle_1_SellEntry_Label.Inlines.Clear();
			this.DownCycle_1_SellEntry_Label.Inlines.Add("Wave A");
			this.DownCycle_1_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.HIGH));
			this.DownCycle_1_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.FCorrectiveWaveB = this.FCorrectiveWaveA + 0.618 * this.CS;
			this.DownCycle_1_Target1_Label.Inlines.Clear();
			this.DownCycle_1_Target1_Label.Inlines.Add("Wave B");
			this.DownCycle_1_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.DownCycle_1_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.FCorrectiveWaveC = this.FCorrectiveWaveB - 1.236 * (0.618 * this.CS);
			this.FCorrectiveWaveExpC = this.FCorrectiveWaveB - 1.618 * (0.618 * this.CS);
			this.DownCycle_1_Target2_Label.Inlines.Clear();
			this.DownCycle_1_Target2_Label.Inlines.Add("Wave C");
			this.DownCycle_1_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.DownCycle_1_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveC));
			this.DownCycle_1_Target3_Label.Inlines.Clear();
			this.DownCycle_1_Target3_Label.Inlines.Add("Wave C Exp");
			this.DownCycle_1_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveExpC));
			this.FCorrectiveWaveA = this.FCorrectiveWaveExpC - this.CS;
			this.DownCycle_2_SellEntry_Label.Inlines.Clear();
			this.DownCycle_2_SellEntry_Label.Inlines.Add("Wave A");
			this.DownCycle_2_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveExpC));
			this.DownCycle_2_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.FCorrectiveWaveB = this.FCorrectiveWaveA + 0.618 * this.CS;
			this.DownCycle_2_Target1_Label.Inlines.Clear();
			this.DownCycle_2_Target1_Label.Inlines.Add("Wave B");
			this.DownCycle_2_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.DownCycle_2_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.FCorrectiveWaveC = this.FCorrectiveWaveB - 1.236 * (0.618 * this.CS);
			this.FCorrectiveWaveExpC = this.FCorrectiveWaveB - 1.618 * (0.618 * this.CS);
			this.DownCycle_2_Target2_Label.Inlines.Clear();
			this.DownCycle_2_Target2_Label.Inlines.Add("Wave C");
			this.DownCycle_2_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.DownCycle_2_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveC));
			this.DownCycle_2_Target3_Label.Inlines.Clear();
			this.DownCycle_2_Target3_Label.Inlines.Add("Wave C Exp");
			this.DownCycle_2_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveExpC));
			this.FCorrectiveWaveA = this.FCorrectiveWaveExpC - this.CS;
			this.DownCycle_3_SellEntry_Label.Inlines.Clear();
			this.DownCycle_3_SellEntry_Label.Inlines.Add("Wave A");
			this.DownCycle_3_SellEntry_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveExpC));
			this.DownCycle_3_SellEntry_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.FCorrectiveWaveB = this.FCorrectiveWaveA + 0.618 * this.CS;
			this.DownCycle_3_Target1_Label.Inlines.Clear();
			this.DownCycle_3_Target1_Label.Inlines.Add("Wave B");
			this.DownCycle_3_Target1_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveA));
			this.DownCycle_3_Target1_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.FCorrectiveWaveC = this.FCorrectiveWaveB - 1.236 * (0.618 * this.CS);
			this.FCorrectiveWaveExpC = this.FCorrectiveWaveB - 1.618 * (0.618 * this.CS);
			this.DownCycle_3_Target2_Label.Inlines.Clear();
			this.DownCycle_3_Target2_Label.Inlines.Add("Wave C");
			this.DownCycle_3_Target2_s.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveB));
			this.DownCycle_3_Target2_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveC));
			this.DownCycle_3_Target3_Label.Inlines.Clear();
			this.DownCycle_3_Target3_Label.Inlines.Add("Wave C Exp");
			this.DownCycle_3_Target3_e.Inlines.Add(Comman.do_RoundOffAndReturnString(this.FCorrectiveWaveExpC));
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0006340C File Offset: 0x0006160C
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

		// Token: 0x0600030B RID: 779 RVA: 0x0006343E File Offset: 0x0006163E
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00063458 File Offset: 0x00061658
		private void clear_TableValues()
		{
			this.UpCycle_1_BuyEntry_s.Inlines.Clear();
			this.UpCycle_1_BuyEntry_e.Inlines.Clear();
			this.UpCycle_1_Target1_s.Inlines.Clear();
			this.UpCycle_1_Target1_e.Inlines.Clear();
			this.UpCycle_1_Target2_s.Inlines.Clear();
			this.UpCycle_1_Target2_e.Inlines.Clear();
			this.UpCycle_1_Target3_e.Inlines.Clear();
			this.UpCycle_2_BuyEntry_s.Inlines.Clear();
			this.UpCycle_2_BuyEntry_e.Inlines.Clear();
			this.UpCycle_2_Target1_s.Inlines.Clear();
			this.UpCycle_2_Target1_e.Inlines.Clear();
			this.UpCycle_2_Target2_s.Inlines.Clear();
			this.UpCycle_2_Target2_e.Inlines.Clear();
			this.UpCycle_2_Target3_e.Inlines.Clear();
			this.UpCycle_3_BuyEntry_s.Inlines.Clear();
			this.UpCycle_3_BuyEntry_e.Inlines.Clear();
			this.UpCycle_3_Target1_s.Inlines.Clear();
			this.UpCycle_3_Target1_e.Inlines.Clear();
			this.UpCycle_3_Target2_s.Inlines.Clear();
			this.UpCycle_3_Target2_e.Inlines.Clear();
			this.UpCycle_3_Target3_e.Inlines.Clear();
			this.DownCycle_1_SellEntry_s.Inlines.Clear();
			this.DownCycle_1_SellEntry_e.Inlines.Clear();
			this.DownCycle_1_Target1_s.Inlines.Clear();
			this.DownCycle_1_Target1_e.Inlines.Clear();
			this.DownCycle_1_Target2_s.Inlines.Clear();
			this.DownCycle_1_Target2_e.Inlines.Clear();
			this.DownCycle_1_Target3_e.Inlines.Clear();
			this.DownCycle_2_SellEntry_s.Inlines.Clear();
			this.DownCycle_2_SellEntry_e.Inlines.Clear();
			this.DownCycle_2_Target1_s.Inlines.Clear();
			this.DownCycle_2_Target1_e.Inlines.Clear();
			this.DownCycle_2_Target2_s.Inlines.Clear();
			this.DownCycle_2_Target2_e.Inlines.Clear();
			this.DownCycle_2_Target3_e.Inlines.Clear();
			this.DownCycle_3_SellEntry_s.Inlines.Clear();
			this.DownCycle_3_SellEntry_e.Inlines.Clear();
			this.DownCycle_3_Target1_s.Inlines.Clear();
			this.DownCycle_3_Target1_e.Inlines.Clear();
			this.DownCycle_3_Target2_s.Inlines.Clear();
			this.DownCycle_3_Target2_e.Inlines.Clear();
			this.DownCycle_3_Target3_e.Inlines.Clear();
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00063708 File Offset: 0x00061908
		private void remove_color()
		{
			this.UpCycle_1_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_1_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_2_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_BuyEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_BuyEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.UpCycle_3_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_1_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_2_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_SellEntry_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_SellEntry_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target1_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target1_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target2_s.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target2_e.Background = new SolidColorBrush(Colors.Transparent);
			this.DownCycle_3_Target3_e.Background = new SolidColorBrush(Colors.Transparent);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00063A87 File Offset: 0x00061C87
		[NullableContext(1)]
		private void cbCorrective_Checked(object sender, RoutedEventArgs e)
		{
			this.clear_TableValues();
			this.remove_color();
			this.Calculate_CorrectiveCycle();
			this.elliotSummary2.Content = this.recommendation;
		}

		// Token: 0x0400082E RID: 2094
		private double LOW;

		// Token: 0x0400082F RID: 2095
		private double HIGH;

		// Token: 0x04000830 RID: 2096
		private double LTP;

		// Token: 0x04000831 RID: 2097
		private int DAYS2Hold;

		// Token: 0x04000832 RID: 2098
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x04000833 RID: 2099
		[Nullable(1)]
		private string recommendation = "Based on reference price, Refer the appropriate cycle to make trade entry.";

		// Token: 0x04000834 RID: 2100
		private double Wave1;

		// Token: 0x04000835 RID: 2101
		private double Wave2;

		// Token: 0x04000836 RID: 2102
		private double Facto2;

		// Token: 0x04000837 RID: 2103
		private double Wave3;

		// Token: 0x04000838 RID: 2104
		private double Wave4;

		// Token: 0x04000839 RID: 2105
		private double Wave5;

		// Token: 0x0400083A RID: 2106
		private double WaveExp5;

		// Token: 0x0400083B RID: 2107
		private double CorrectiveWaveA;

		// Token: 0x0400083C RID: 2108
		private double CorrectiveWaveB;

		// Token: 0x0400083D RID: 2109
		private double CorrectiveWaveC;

		// Token: 0x0400083E RID: 2110
		private double CorrectiveWaveExpC;

		// Token: 0x0400083F RID: 2111
		private double FCorrectiveWaveA;

		// Token: 0x04000840 RID: 2112
		private double FCorrectiveWaveB;

		// Token: 0x04000841 RID: 2113
		private double FCorrectiveWaveC;

		// Token: 0x04000842 RID: 2114
		private double FCorrectiveWaveExpC;

		// Token: 0x04000843 RID: 2115
		private double midValue;

		// Token: 0x04000844 RID: 2116
		private double diffvalue;

		// Token: 0x04000845 RID: 2117
		private double Facto1;

		// Token: 0x04000846 RID: 2118
		private double temp_midValue;

		// Token: 0x04000847 RID: 2119
		private double CS;
	}
}
