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
using HtmlAgilityPack;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001C RID: 28
	public partial class OneSD : UserControl
	{
		// Token: 0x0600014E RID: 334 RVA: 0x0001128A File Offset: 0x0000F48A
		public OneSD()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00011298 File Offset: 0x0000F498
		private void Initialize_Variable()
		{
			try
			{
				if (Equtiy_Future.LTP_MONTH != null || Equtiy_Future.LTP_MONTH.Count > 10)
				{
					this.ltp11days = new List<double>();
					this.ltp11days = Equtiy_Future.LTP_MONTH.Skip(Equtiy_Future.LTP_MONTH.Count - 11).ToList<double>();
					this.preLTP = this.ltp11days[this.ltp11days.Count - 1];
					if (Equtiy_Future.LIVE_DATA != null)
					{
						this.LOW = Equtiy_Future.LIVE_DATA.low;
						this.HIGH = Equtiy_Future.LIVE_DATA.high;
						this.LTP = Equtiy_Future.LIVE_DATA.ltp;
						this.OPEN = Equtiy_Future.LIVE_DATA.open;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace, "Error-83");
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00011374 File Offset: 0x0000F574
		public void Display()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			this.all_calculatedTarget = new Dictionary<string, double>();
			double baseRatioBEorSL = 0.236;
			double T1ratio = 0.382;
			double T2ratio = 0.5;
			double T3ratio = 0.618;
			double T4ratio = 0.786;
			double T5ratio = 0.888;
			double T6ratio = 1.236;
			double T7ratio = 1.618;
			if (Equtiy_Future.NoOfHoldDays >= 1)
			{
				this.DAYS2Hold = Equtiy_Future.NoOfHoldDays;
			}
			else if (Equtiy_Future.NoOfHoldDays < 1)
			{
				this.DAYS2Hold = 1;
			}
			if (this.ltp11days != null)
			{
				if (this.ltp11days.Count == 11)
				{
					OneSD.days10volatility = OneSD.get_Volatility(this.ltp11days);
					if (OneSD.days10volatility >= 25.0 && OneSD.days10volatility < 75.0)
					{
						OneSD.days10volatility /= 2.0;
					}
					else if (OneSD.days10volatility >= 75.0 && OneSD.days10volatility < 100.0)
					{
						OneSD.days10volatility /= 3.0;
					}
					else if (OneSD.days10volatility >= 100.0)
					{
						OneSD.days10volatility /= 5.0;
					}
					OneSD.refPrice = this.ltp11days[this.ltp11days.Count - 1];
				}
				else
				{
					OneSD.days10volatility = (this.HIGH - this.LOW) / this.HIGH;
					if (OneSD.days10volatility >= 25.0 && OneSD.days10volatility < 75.0)
					{
						OneSD.days10volatility /= 2.0;
					}
					else if (OneSD.days10volatility >= 75.0 && OneSD.days10volatility < 100.0)
					{
						OneSD.days10volatility /= 3.0;
					}
					else if (OneSD.days10volatility >= 100.0)
					{
						OneSD.days10volatility /= 5.0;
					}
					OneSD.refPrice = this.HIGH + this.LOW / 2.0;
				}
			}
			if (Equtiy_Future.NoOfHoldDays < 1)
			{
				OneSD.Range = OneSD.get_1SDPriceRange(this.DAYS2Hold, OneSD.days10volatility, OneSD.refPrice);
				double X = OneSD.refPrice + baseRatioBEorSL * OneSD.Range;
				double Y = OneSD.refPrice - baseRatioBEorSL * OneSD.Range;
				if (this.OPEN > X || this.OPEN < Y)
				{
					OneSD.refPrice = this.OPEN;
					this.ltp11days.RemoveAt(0);
					this.ltp11days.Add(OneSD.refPrice);
					OneSD.days10volatility = OneSD.get_Volatility(this.ltp11days);
					if (OneSD.days10volatility >= 25.0 && OneSD.days10volatility < 75.0)
					{
						OneSD.days10volatility /= 2.0;
					}
					else if (OneSD.days10volatility >= 75.0 && OneSD.days10volatility < 100.0)
					{
						OneSD.days10volatility /= 3.0;
					}
					else if (OneSD.days10volatility >= 100.0)
					{
						OneSD.days10volatility /= 5.0;
					}
					OneSD.Range = OneSD.get_1SDPriceRange(this.DAYS2Hold, OneSD.days10volatility, OneSD.refPrice);
				}
				double X2 = OneSD.refPrice + T3ratio * OneSD.Range;
				double Y2 = OneSD.refPrice - T3ratio * OneSD.Range;
				if (this.LTP > X2 || this.LTP < Y2)
				{
					OneSD.refPrice = this.LTP;
					this.ltp11days.RemoveAt(0);
					this.ltp11days.Add(OneSD.refPrice);
					OneSD.days10volatility = OneSD.get_Volatility(this.ltp11days);
					if (OneSD.days10volatility >= 25.0 && OneSD.days10volatility < 75.0)
					{
						OneSD.days10volatility /= 2.0;
					}
					else if (OneSD.days10volatility >= 75.0 && OneSD.days10volatility < 100.0)
					{
						OneSD.days10volatility /= 3.0;
					}
					else if (OneSD.days10volatility >= 100.0)
					{
						OneSD.days10volatility /= 5.0;
					}
					OneSD.Range = OneSD.get_1SDPriceRange(this.DAYS2Hold, OneSD.days10volatility, OneSD.refPrice);
				}
			}
			else
			{
				OneSD.refPrice = this.LTP;
				if (this.Check_VolaTable())
				{
					OneSD.days10volatility = this.getDatabaseTableVolatility();
				}
			}
			this.UpCycle_1_BuyEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, 1)));
			double onesdbuyEntryValue = Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, onesdbuyEntryValue);
			Volatality_Sumary.OneSDBuyEntryValue1 = onesdbuyEntryValue;
			this.UpCycle_1_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T1ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
			this.UpCycle_1_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T2ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
			this.UpCycle_1_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
			this.UpCycle_1_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text));
			this.UpCycle_1_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T5ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target5.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target5.Inlines.FirstInline).Text));
			this.UpCycle_1_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T6ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target6.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target6.Inlines.FirstInline).Text));
			this.UpCycle_1_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T7ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_1_Target7.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target7.Inlines.FirstInline).Text));
			double upCycle1Clusture = (OneSD.CalcTargets(OneSD.refPrice, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1) + OneSD.CalcTargets(OneSD.refPrice, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)) / 2.0;
			this.UpCycle_1_Growth_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(upCycle1Clusture));
			double upCycle2Start = Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text);
			this.UpCycle_2_BuyEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, 1)));
			double onesdbuyEntryValue2 = Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, onesdbuyEntryValue2);
			Volatality_Sumary.OneSDBuyEntryValue2 = onesdbuyEntryValue2;
			this.UpCycle_2_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T1ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
			this.UpCycle_2_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T2ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
			this.UpCycle_2_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
			this.UpCycle_2_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text));
			this.UpCycle_2_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T5ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target5.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target5.Inlines.FirstInline).Text));
			this.UpCycle_2_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T6ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target6.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target6.Inlines.FirstInline).Text));
			this.UpCycle_2_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle2Start, T7ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_2_Target7.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target7.Inlines.FirstInline).Text));
			double upCycle3Clusture = (OneSD.CalcTargets(upCycle2Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1) + OneSD.CalcTargets(upCycle2Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)) / 2.0;
			this.UpCycle_2_Growth_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(upCycle3Clusture));
			double upCycle3Start = Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text);
			this.UpCycle_3_BuyEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, 1)));
			double onesdbuyEntryValue3 = Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, onesdbuyEntryValue3);
			Volatality_Sumary.OneSDBuyEntryValue3 = onesdbuyEntryValue3;
			this.UpCycle_3_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T1ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
			this.UpCycle_3_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T2ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
			this.UpCycle_3_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
			this.UpCycle_3_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target4.Inlines.FirstInline).Text));
			this.UpCycle_3_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T5ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target5.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target5.Inlines.FirstInline).Text));
			this.UpCycle_3_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T6ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target6.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target6.Inlines.FirstInline).Text));
			this.UpCycle_3_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(upCycle3Start, T7ratio, OneSD.days10volatility, this.DAYS2Hold, 1)));
			this.all_calculatedTarget.Add(this.UpCycle_3_Target7.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target7.Inlines.FirstInline).Text));
			double upCycle4Start = (OneSD.CalcTargets(upCycle3Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, 1) + OneSD.CalcTargets(upCycle3Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, 1)) / 2.0;
			this.UpCycle_3_Growth_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(upCycle4Start));
			this.DownCycle_1_SellEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, -1)));
			double sellEntryValue = Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, sellEntryValue);
			Volatality_Sumary.OneSDSellEntryValue1 = sellEntryValue;
			this.DownCycle_1_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T1ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
			this.DownCycle_1_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T2ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
			this.DownCycle_1_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
			this.DownCycle_1_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text));
			this.DownCycle_1_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T5ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target5.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target5.Inlines.FirstInline).Text));
			this.DownCycle_1_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T6ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target6.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target6.Inlines.FirstInline).Text));
			this.DownCycle_1_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(OneSD.refPrice, T7ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_1_Target7.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target7.Inlines.FirstInline).Text));
			double downCycle1Clusture = (OneSD.CalcTargets(OneSD.refPrice, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1) + OneSD.CalcTargets(OneSD.refPrice, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)) / 2.0;
			this.DownCycle_1_Decay_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(downCycle1Clusture));
			double downCycle2Start = Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text);
			this.DownCycle_2_SellEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, -1)));
			double onesdsellEntryValue2 = Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, onesdsellEntryValue2);
			Volatality_Sumary.OneSDSellEntryValue2 = onesdsellEntryValue2;
			this.DownCycle_2_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T1ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
			this.DownCycle_2_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T2ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
			this.DownCycle_2_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
			this.DownCycle_2_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text));
			this.DownCycle_2_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T5ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target5.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target5.Inlines.FirstInline).Text));
			this.DownCycle_2_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T6ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target6.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target6.Inlines.FirstInline).Text));
			this.DownCycle_2_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle2Start, T7ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_2_Target7.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target7.Inlines.FirstInline).Text));
			double downCycle2Clusture = (OneSD.CalcTargets(downCycle2Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1) + OneSD.CalcTargets(downCycle2Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)) / 2.0;
			this.DownCycle_2_Decay_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(downCycle2Clusture));
			double downCycle3Start = Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text);
			this.DownCycle_3_SellEntry.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, baseRatioBEorSL, OneSD.days10volatility, this.DAYS2Hold, -1)));
			double onesdsellEntryValue3 = Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text);
			this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, onesdsellEntryValue3);
			Volatality_Sumary.OneSDSellEntryValue3 = onesdsellEntryValue3;
			this.DownCycle_3_Target1.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T1ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
			this.DownCycle_3_Target2.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T2ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
			this.DownCycle_3_Target3.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
			this.DownCycle_3_Target4.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target4.Inlines.FirstInline).Text));
			this.DownCycle_3_Target5.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T5ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target5.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target5.Inlines.FirstInline).Text));
			this.DownCycle_3_Target6.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T6ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target6.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target6.Inlines.FirstInline).Text));
			this.DownCycle_3_Target7.Inlines.Add(OneSD.do_RoundOffAndReturnString(OneSD.CalcTargets(downCycle3Start, T7ratio, OneSD.days10volatility, this.DAYS2Hold, -1)));
			this.all_calculatedTarget.Add(this.DownCycle_3_Target7.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target7.Inlines.FirstInline).Text));
			double downCycle4Start = (OneSD.CalcTargets(downCycle3Start, T3ratio, OneSD.days10volatility, this.DAYS2Hold, -1) + OneSD.CalcTargets(downCycle3Start, T4ratio, OneSD.days10volatility, this.DAYS2Hold, -1)) / 2.0;
			this.DownCycle_3_Decay_Clusture.Inlines.Add(OneSD.do_RoundOffAndReturnString(downCycle4Start));
			string recommendation = "";
			try
			{
				Dictionary<string, double> nameOfControl = OneSD.find_Nearest2LTP2Value(this.all_calculatedTarget, this.LTP);
				if (nameOfControl.Count > 0)
				{
					DependencyObject up = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject upre = LogicalTreeHelper.FindLogicalNode(this.gridfUpCycle, nameOfControl.ElementAt(1).Key);
					DependencyObject down = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(0).Key);
					DependencyObject dpre = LogicalTreeHelper.FindLogicalNode(this.gridfDownCycle, nameOfControl.ElementAt(1).Key);
					if (up != null || upre != null)
					{
						string trend = "GROWTH Trends";
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
						}
						else
						{
							recommendation = OneSD.up_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(up, upre);
						}
						this.gbSummaryHeader.Content = recommendation;
						return;
					}
					if (down != null || dpre != null)
					{
						string trend = "DECAY Trend";
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
						}
						else
						{
							recommendation = OneSD.down_Recommendation(nameOfControl, this.LTP, trend);
							this.paintTheTarget(down, dpre);
						}
						this.gbSummaryHeader.Content = recommendation;
						return;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error-435");
			}
			this.gbSummaryHeader.Header = "1SD Trend Identification Summary";
			this.volatilitySummary1.Content = recommendation;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00012F30 File Offset: 0x00011130
		public static double CalcTargets(double _refPrice, double _ratio, double _annualVolatility, int days2Hold, int _BorSFlag)
		{
			double _priceRange = OneSD.get_1SDPriceRange(days2Hold, _annualVolatility, _refPrice);
			double denominator = 1.0;
			if (_refPrice < 1000.0)
			{
				if (_refPrice < 100.0)
				{
					if (_refPrice < 10.0)
					{
						denominator = 1000.0;
						_priceRange *= denominator;
						_refPrice *= denominator;
					}
					else
					{
						denominator = 100.0;
						_priceRange *= denominator;
						_refPrice *= denominator;
					}
				}
				else
				{
					denominator = 10.0;
					_priceRange *= denominator;
					_refPrice *= denominator;
				}
			}
			return Math.Round((_refPrice + _ratio * (double)_BorSFlag * _priceRange) / denominator, 3);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00012FC2 File Offset: 0x000111C2
		public static double get_1SDPriceRange(int _noOfDaysToHold, double _annualVolatility, double _referencePrice)
		{
			return _referencePrice * (_annualVolatility / 100.0) * Math.Sqrt((double)_noOfDaysToHold) / Math.Sqrt(365.0);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00012FE8 File Offset: 0x000111E8
		[NullableContext(1)]
		public static string do_RoundOffAndReturnString(double _value)
		{
			return Math.Round(_value, 3).ToString();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00013004 File Offset: 0x00011204
		[NullableContext(1)]
		public static string down_Recommendation(Dictionary<string, double> nameOfControl, double LTP, string downcycle)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			string Target = "";
			try
			{
				if (str.Contains("UpCycle"))
				{
					return OneSD.up_Recommendation(nameOfControl, LTP, downcycle);
				}
				if (str != null && str != "NULL")
				{
					if (str.Contains("Target"))
					{
						Target = str.Substring(str.IndexOf("T"));
					}
					else
					{
						Target = str.Substring(str.IndexOf("S"));
					}
				}
				else
				{
					Target = "SellEntry";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Down-Error 568");
			}
			if (!(Target == "SellEntry"))
			{
				if (!(Target == "Target1") && !(Target == "Target2") && !(Target == "Target3"))
				{
					if (!(Target == "Target4"))
					{
						if (!(Target == "Target5"))
						{
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = "Wait till it enter fresh cycle.";
							Equtiy_Future.neutralCount.Add("0");
						}
					}
					else
					{
						recommendation = "Wait till it enter fresh cycle.";
						Equtiy_Future.neutralCount.Add("0");
					}
				}
				else
				{
					recommendation = "SELL";
					Equtiy_Future.sellCount.Add("-1");
				}
			}
			else
			{
				recommendation = string.Format("SELL when it touches {0}", nameOfControl.ElementAt(0).Value);
				Equtiy_Future.neutralCount.Add("0");
			}
			return string.Format("As Ref price {0}, is in {1}, with price {2}. ##Recommendation {3}", new object[]
			{
				LTP,
				downcycle,
				nameOfControl.ElementAt(1).Value,
				recommendation
			});
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000131C8 File Offset: 0x000113C8
		[NullableContext(1)]
		public static string up_Recommendation(Dictionary<string, double> nameOfControl, double LTP, string upCycle)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			if (str.Contains("Down"))
			{
				return OneSD.down_Recommendation(nameOfControl, LTP, upCycle);
			}
			string Target;
			if (str != null && str != "NULL")
			{
				if (str.Contains("Target"))
				{
					Target = str.Substring(str.IndexOf("T"));
				}
				else
				{
					Target = str.Substring(str.IndexOf("B"));
				}
			}
			else
			{
				Target = "BuyEntry";
			}
			if (!(Target == "BuyEntry"))
			{
				if (!(Target == "Target1") && !(Target == "Target2") && !(Target == "Target3"))
				{
					if (!(Target == "Target4"))
					{
						if (!(Target == "Target5"))
						{
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = "Wait till it enter FRESH cycle.";
							Equtiy_Future.neutralCount.Add("0");
						}
					}
					else
					{
						recommendation = "Wait till it enter FRESH cycle.";
						Equtiy_Future.neutralCount.Add("0");
					}
				}
				else
				{
					recommendation = "BUY";
					Equtiy_Future.buyCount.Add("1");
				}
			}
			else
			{
				recommendation = string.Format("BUY when it touches {0}", nameOfControl.ElementAt(0).Value);
				Equtiy_Future.neutralCount.Add("0");
			}
			return string.Format("As Ref price {0}, is in {1}, and moving towards {2}. ##Recommendation {3}", new object[]
			{
				LTP,
				upCycle,
				nameOfControl.ElementAt(1).Value,
				recommendation
			});
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00013360 File Offset: 0x00011560
		[NullableContext(1)]
		public static Dictionary<string, double> find_Nearest2LTP2Value(Dictionary<string, double> all_calculatedTarget, double LTP)
		{
			Dictionary<string, double> bestMatchTarget = new Dictionary<string, double>();
			Dictionary<string, double> result;
			try
			{
				all_calculatedTarget = (from x in all_calculatedTarget
				orderby x.Value
				select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				int i;
				for (i = 0; i < all_calculatedTarget.Count; i++)
				{
					if (LTP <= all_calculatedTarget.ElementAt(i).Value)
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
				else if (bestMatchTarget.Count != 0)
				{
					bool sellEntry = all_calculatedTarget.ElementAt(i).Key.Contains("_SellEntry");
					bool flag = all_calculatedTarget.ElementAt(i).Key.Contains("_BuyEntry");
					bool downCycle = all_calculatedTarget.ElementAt(i).Key.Contains("Down");
					if (flag || sellEntry)
					{
						if (!downCycle)
						{
							bestMatchTarget.Add("NULL", 0.0);
						}
						else if (i != 0)
						{
							bestMatchTarget.Add(all_calculatedTarget.ElementAt(i - 1).Key, all_calculatedTarget.ElementAt(i - 1).Value);
						}
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace, "Error-451");
				result = bestMatchTarget;
			}
			return result;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000135E8 File Offset: 0x000117E8
		[NullableContext(1)]
		public static double get_Volatility(List<double> ltp)
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

		// Token: 0x06000158 RID: 344 RVA: 0x000136A8 File Offset: 0x000118A8
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

		// Token: 0x06000159 RID: 345 RVA: 0x000136DC File Offset: 0x000118DC
		private void clear_TableValues()
		{
			this.UpCycle_1_Growth_Clusture.Inlines.Clear();
			this.UpCycle_2_Growth_Clusture.Inlines.Clear();
			this.UpCycle_3_Growth_Clusture.Inlines.Clear();
			this.DownCycle_1_Decay_Clusture.Inlines.Clear();
			this.DownCycle_2_Decay_Clusture.Inlines.Clear();
			this.DownCycle_3_Decay_Clusture.Inlines.Clear();
			this.UpCycle_1_BuyEntry.Inlines.Clear();
			this.UpCycle_1_Target1.Inlines.Clear();
			this.UpCycle_1_Target2.Inlines.Clear();
			this.UpCycle_1_Target3.Inlines.Clear();
			this.UpCycle_1_Target4.Inlines.Clear();
			this.UpCycle_1_Target5.Inlines.Clear();
			this.UpCycle_2_BuyEntry.Inlines.Clear();
			this.UpCycle_2_Target1.Inlines.Clear();
			this.UpCycle_2_Target2.Inlines.Clear();
			this.UpCycle_2_Target3.Inlines.Clear();
			this.UpCycle_2_Target4.Inlines.Clear();
			this.UpCycle_2_Target5.Inlines.Clear();
			this.UpCycle_3_BuyEntry.Inlines.Clear();
			this.UpCycle_3_Target1.Inlines.Clear();
			this.UpCycle_3_Target2.Inlines.Clear();
			this.UpCycle_3_Target3.Inlines.Clear();
			this.UpCycle_3_Target4.Inlines.Clear();
			this.UpCycle_3_Target5.Inlines.Clear();
			this.DownCycle_1_SellEntry.Inlines.Clear();
			this.DownCycle_1_Target1.Inlines.Clear();
			this.DownCycle_1_Target2.Inlines.Clear();
			this.DownCycle_1_Target3.Inlines.Clear();
			this.DownCycle_1_Target4.Inlines.Clear();
			this.DownCycle_1_Target5.Inlines.Clear();
			this.DownCycle_2_SellEntry.Inlines.Clear();
			this.DownCycle_2_Target1.Inlines.Clear();
			this.DownCycle_2_Target2.Inlines.Clear();
			this.DownCycle_2_Target3.Inlines.Clear();
			this.DownCycle_2_Target4.Inlines.Clear();
			this.DownCycle_2_Target5.Inlines.Clear();
			this.DownCycle_3_SellEntry.Inlines.Clear();
			this.DownCycle_3_Target1.Inlines.Clear();
			this.DownCycle_3_Target2.Inlines.Clear();
			this.DownCycle_3_Target3.Inlines.Clear();
			this.DownCycle_3_Target4.Inlines.Clear();
			this.DownCycle_3_Target5.Inlines.Clear();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001398C File Offset: 0x00011B8C
		private bool Check_VolaTable()
		{
			string downloadedPage = string.Empty;
			string url = string.Format("https://smartfinance.in/vola/vola.php?instrument={0}&script={1}&expiry={2}", Equtiy_Future.selectedInstrument, Equtiy_Future.selectedSymbol, Equtiy_Future.selectedExpiry);
			try
			{
				downloadSiteCls dPageObj = new downloadSiteCls(new Uri(url));
				while (dPageObj.downloader.IsBusy)
				{
				}
				downloadedPage = dPageObj.getSite();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace, "Error-89 Positional");
				return false;
			}
			return !string.IsNullOrWhiteSpace(downloadedPage) && this.IsVolaAvailPage(downloadedPage);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00013A14 File Offset: 0x00011C14
		[NullableContext(1)]
		private bool IsVolaAvailPage(string Page)
		{
			this.doc = new HtmlDocument();
			this.doc.LoadHtml(Page);
			string volaFlag = string.Empty;
			try
			{
				if (Page.Contains("IsVolaPresent"))
				{
					volaFlag = this.doc.GetElementbyId("IsVolaPresent").InnerText;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error-78 Positional");
				return false;
			}
			return volaFlag == "1";
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00013A9C File Offset: 0x00011C9C
		private double getDatabaseTableVolatility()
		{
			double resultVola = 0.0;
			if (this.doc != null && this.doc.DocumentNode.InnerHtml.Contains("Vola"))
			{
				string tempVola = this.doc.GetElementbyId("Vola").InnerText;
				if (!string.IsNullOrWhiteSpace(tempVola))
				{
					resultVola = double.Parse(tempVola);
				}
			}
			return resultVola;
		}

		// Token: 0x040001FB RID: 507
		private double LOW;

		// Token: 0x040001FC RID: 508
		private double HIGH;

		// Token: 0x040001FD RID: 509
		private double LTP;

		// Token: 0x040001FE RID: 510
		private double OPEN;

		// Token: 0x040001FF RID: 511
		private double preLTP;

		// Token: 0x04000200 RID: 512
		private int DAYS2Hold;

		// Token: 0x04000201 RID: 513
		public static double days10volatility;

		// Token: 0x04000202 RID: 514
		[Nullable(1)]
		private HtmlDocument doc;

		// Token: 0x04000203 RID: 515
		[Nullable(1)]
		private List<double> ltp11days;

		// Token: 0x04000204 RID: 516
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x04000205 RID: 517
		[Nullable(1)]
		private string _instrument;

		// Token: 0x04000206 RID: 518
		[Nullable(1)]
		private string _script;

		// Token: 0x04000207 RID: 519
		public static double refPrice;

		// Token: 0x04000208 RID: 520
		public static double Range;
	}
}
