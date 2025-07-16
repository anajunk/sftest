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
using System.Windows.Shapes;
using New_SF_IT.classes;
using SFHelper;

namespace New_SF_IT.Average_and_Pivot_Principle
{
	// Token: 0x02000055 RID: 85
	public partial class Camarila : UserControl
	{
		// Token: 0x060003DD RID: 989 RVA: 0x00087A37 File Offset: 0x00085C37
		public Camarila()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00087A48 File Offset: 0x00085C48
		public void Calculate()
		{
			try
			{
				if (Equtiy_Future.LIVE_DATA != null)
				{
					double refLTP = Equtiy_Future.LIVE_DATA.ltp;
					LiveMarketQuoteDataCls completeLiveData = Equtiy_Future.LIVE_DATA;
					this.clear_TableValues();
					if (Equtiy_Future.NoOfHoldDays > 0)
					{
						this.DaysToHold = Equtiy_Future.NoOfHoldDays;
					}
					this.all_calculatedTarget = new Dictionary<string, double>();
					this.UpCycle_1_BuyEntry.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, 12).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text));
					this.UpCycle_1_Target1.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, 6).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
					this.UpCycle_1_Target2.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, 4).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
					this.UpCycle_1_Target3.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
					double H4 = Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text);
					this.UpCycle_2_BuyEntry.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, H4, 12).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text));
					this.UpCycle_2_Target1.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, H4, 6).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
					this.UpCycle_2_Target2.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, H4, 4).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
					this.UpCycle_2_Target3.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, H4, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
					double HSecond4 = Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text);
					this.UpCycle_3_BuyEntry.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, HSecond4, 12).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text));
					this.UpCycle_3_Target1.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, HSecond4, 6).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
					this.UpCycle_3_Target2.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, HSecond4, 4).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
					this.UpCycle_3_Target3.Inlines.Add(this.get_CamarilaHighLevels(completeLiveData, HSecond4, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
					this.DownCycle_1_SellEntry.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, 12).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text));
					this.DownCycle_1_Target1.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, 6).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
					this.DownCycle_1_Target2.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, 4).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
					this.DownCycle_1_Target3.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
					double L4 = Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text);
					this.DownCycle_2_SellEntry.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, L4, 12).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text));
					this.DownCycle_2_Target1.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, L4, 6).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
					this.DownCycle_2_Target2.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, L4, 4).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
					this.DownCycle_2_Target3.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, L4, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
					double LSecond4 = Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text);
					this.DownCycle_3_SellEntry.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, LSecond4, 12).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text));
					this.DownCycle_3_Target1.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, LSecond4, 6).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
					this.DownCycle_3_Target2.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, LSecond4, 4).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
					this.DownCycle_3_Target3.Inlines.Add(this.get_CamarilaLowLevels(completeLiveData, LSecond4, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
					string recommendation = "wait till price enter fresh cycle.";
					try
					{
						Dictionary<string, double> nameOfControl = Comman.find_Nearest2LTP2Value(this.all_calculatedTarget, refLTP);
						if (nameOfControl.Count > 0)
						{
							DependencyObject up = LogicalTreeHelper.FindLogicalNode(this.gridUpCycle, nameOfControl.ElementAt(0).Key);
							DependencyObject down = LogicalTreeHelper.FindLogicalNode(this.gridDownCycle, nameOfControl.ElementAt(0).Key);
							if (nameOfControl.Count > 1)
							{
								DependencyObject upre = LogicalTreeHelper.FindLogicalNode(this.gridUpCycle, nameOfControl.ElementAt(1).Key);
								DependencyObject dprevoius = LogicalTreeHelper.FindLogicalNode(this.gridDownCycle, nameOfControl.ElementAt(1).Key);
								if (up != null || upre != null)
								{
									string trend = "HIGH Levels";
									if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
									{
										trend = "Non of Cycle";
										recommendation = string.Concat(new string[]
										{
											"Ref Price : ",
											completeLiveData.ltp.ToString(),
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
										recommendation = Comman.up_Recommendation(nameOfControl, completeLiveData.ltp, trend);
										this.paintTheTarget(up, upre);
									}
									this.gbSummaryHeader.Content = recommendation;
									return;
								}
								if (down != null || dprevoius != null)
								{
									string trend = "LOW levels";
									if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
									{
										trend = "Non of Cycle";
										recommendation = string.Concat(new string[]
										{
											"Ref Price : ",
											completeLiveData.ltp.ToString(),
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
										recommendation = Comman.down_Recommendation(nameOfControl, completeLiveData.ltp, trend);
										this.paintTheTarget(down, dprevoius);
									}
									this.gbSummaryHeader.Content = recommendation;
									return;
								}
							}
						}
					}
					catch (Exception)
					{
					}
					this.CamirilaSummary1.Content = recommendation;
				}
				this.gbSummaryHeader.Header = "Camarila Summary";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0008861C File Offset: 0x0008681C
		[NullableContext(1)]
		private void camarila_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0008861E File Offset: 0x0008681E
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

		// Token: 0x060003E1 RID: 993 RVA: 0x00088650 File Offset: 0x00086850
		[NullableContext(1)]
		private void paintTheTarget(object a)
		{
			if (a != null)
			{
				(a as Paragraph).Background = new SolidColorBrush(Colors.BlueViolet);
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0008866C File Offset: 0x0008686C
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

		// Token: 0x060003E3 RID: 995 RVA: 0x000887FC File Offset: 0x000869FC
		[NullableContext(1)]
		private double get_CamarilaLowLevels(LiveMarketQuoteDataCls _liveData, int _divideByValue)
		{
			double high = _liveData.high;
			double low = _liveData.low;
			return Math.Round(_liveData.preClose - (high - low) * (1.1 / (double)_divideByValue), 2);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00088834 File Offset: 0x00086A34
		[NullableContext(1)]
		private double get_CamarilaLowLevels(LiveMarketQuoteDataCls _liveData, double _lastCycleCalculatedValue, int _divideByValue)
		{
			double high = _liveData.high;
			double low = _liveData.low;
			return Math.Round(_lastCycleCalculatedValue - (high - low) * (1.1 / (double)_divideByValue), 2);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00088868 File Offset: 0x00086A68
		[NullableContext(1)]
		private double get_CamarilaHighLevels(LiveMarketQuoteDataCls _liveData, int _divideByValue)
		{
			double high = _liveData.high;
			double low = _liveData.low;
			double preClose = _liveData.preClose;
			return Math.Round((high - low) * (1.1 / (double)_divideByValue) + preClose, 2);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000888A0 File Offset: 0x00086AA0
		[NullableContext(1)]
		private double get_CamarilaHighLevels(LiveMarketQuoteDataCls _liveData, double _lastCycleCalculatedValue, int _divideByValue)
		{
			double high = _liveData.high;
			double low = _liveData.low;
			return Math.Round((high - low) * (1.1 / (double)_divideByValue) + _lastCycleCalculatedValue, 2);
		}

		// Token: 0x04001201 RID: 4609
		private int DaysToHold;

		// Token: 0x04001202 RID: 4610
		private double LOW;

		// Token: 0x04001203 RID: 4611
		private double HIGH;

		// Token: 0x04001204 RID: 4612
		private double LTP;

		// Token: 0x04001205 RID: 4613
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;
	}
}
