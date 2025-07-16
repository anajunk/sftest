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

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000024 RID: 36
	public class Volatality_Scanner : UserControl, IComponentConnector
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0001C1F2 File Offset: 0x0001A3F2
		[Nullable(1)]
		public OneSD OneSD { [NullableContext(1)] get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x0001C1FA File Offset: 0x0001A3FA
		[Nullable(1)]
		public Volatality_Scanner VolatalityScanner { [NullableContext(1)] get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0001C202 File Offset: 0x0001A402
		[Nullable(1)]
		public Volatality_LN VolatalityLN { [NullableContext(1)] get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001DB RID: 475 RVA: 0x0001C20A File Offset: 0x0001A40A
		[Nullable(1)]
		public Volatality_OHLC VolatalityOHLC { [NullableContext(1)] get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0001C212 File Offset: 0x0001A412
		[Nullable(1)]
		public Volatality_Drift VolatalityDrift { [NullableContext(1)] get; }

		// Token: 0x060001DD RID: 477 RVA: 0x0001C21A File Offset: 0x0001A41A
		public Volatality_Scanner()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0001C228 File Offset: 0x0001A428
		private void Initialize_Variable()
		{
			try
			{
				if (Equtiy_Future.LIVE_DATA != null)
				{
					this.OPEN = Equtiy_Future.LIVE_DATA.open;
					this.LOW = Equtiy_Future.LIVE_DATA.low;
					this.HIGH = Equtiy_Future.LIVE_DATA.high;
					this.LTP = Equtiy_Future.LIVE_DATA.ltp;
				}
				if (Equtiy_Future.LTP_MONTH != null || Equtiy_Future.LTP_MONTH.Count > 10)
				{
					this.ltp11days = new List<double>();
					this.ltp11days = Equtiy_Future.LTP_MONTH.Skip(Equtiy_Future.LTP_MONTH.Count - 11).ToList<double>();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace, "Error-80");
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0001C2E4 File Offset: 0x0001A4E4
		public void Calculate()
		{
			this.Initialize_Variable();
			this.clear_TableValues();
			if (Equtiy_Future.NoOfHoldDays > 0)
			{
				this.DAYS2Hold = Equtiy_Future.NoOfHoldDays;
			}
			this.all_calculatedTarget = new Dictionary<string, double>();
			if (this.OPEN != 0.0 && this.LTP != 0.0)
			{
				if (this.ltp11days.Count == 11)
				{
					Volatality_Scanner._volatility = Volatality_Scanner.get_Volatility(this.ltp11days, 1);
				}
				else
				{
					Volatality_Scanner._volatility = (this.HIGH - this.LOW) / this.HIGH;
				}
				if (this.DAYS2Hold > 0)
				{
					Volatality_Scanner.buyEntry = Volatality_Scanner.get_buyEntryPostional(this.ltp11days, this.DAYS2Hold, Volatality_Scanner._volatility, this.LTP);
					Volatality_Scanner.sellEntry = Volatality_Scanner.get_sellEntryPositional(this.ltp11days, this.DAYS2Hold, Volatality_Scanner._volatility, this.LTP);
				}
				else
				{
					Volatality_Scanner.buyEntry = Volatality_Scanner.get_buyEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
					Volatality_Scanner.sellEntry = Volatality_Scanner.get_sellEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
				}
				if (this.OPEN > Volatality_Scanner.buyEntry || this.OPEN < Volatality_Scanner.sellEntry)
				{
					this.ltp11days.RemoveAt(this.ltp11days.Count - 1);
					this.ltp11days.Add(this.OPEN);
					Volatality_Scanner._volatility = Volatality_Scanner.get_Volatility(this.ltp11days, 1);
					Volatality_Scanner.buyEntry = Volatality_Scanner.get_buyEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
					Volatality_Scanner.sellEntry = Volatality_Scanner.get_sellEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
				}
				if (this.LTP > Volatality_Scanner.buyEntry || this.LTP < Volatality_Scanner.sellEntry)
				{
					this.ltp11days.RemoveAt(this.ltp11days.Count - 1);
					this.ltp11days.Add(this.LTP);
					Volatality_Scanner._volatility = Volatality_Scanner.get_Volatility(this.ltp11days, 1);
					Volatality_Scanner.buyEntry = Volatality_Scanner.get_buyEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
					Volatality_Scanner.sellEntry = Volatality_Scanner.get_sellEntry(this.ltp11days, 0.16666666666666666, Volatality_Scanner._volatility, this.LTP);
				}
				Volatality_Scanner.priceRange = 0.0;
				if (this.DAYS2Hold > 0)
				{
					Volatality_Scanner.priceRange = Volatality_Scanner.get_PositionalPriceRange(this.ltp11days, this.DAYS2Hold, Volatality_Scanner._volatility, this.LTP);
				}
				else
				{
					Volatality_Scanner.priceRange = Volatality_Scanner.get_IntradayPriceRange(this.ltp11days, Volatality_Scanner._volatility, this.LTP);
				}
				Volatality_Scanner.pdLTP = this.ltp11days[this.ltp11days.Count - 2];
				double ratioA;
				double ratioB;
				double ratioC;
				double ratioD;
				if (Volatality_Scanner._volatility > 40.0)
				{
					ratioA = 0.5;
					ratioB = 0.6666;
					ratioC = 0.83333;
					ratioD = 1.0;
				}
				else if (Volatality_Scanner._volatility > 25.0 && Volatality_Scanner._volatility < 40.0)
				{
					ratioA = 0.382;
					ratioB = 0.5;
					ratioC = 0.618;
					ratioD = 0.786;
				}
				else
				{
					ratioA = 0.25;
					ratioB = 0.382;
					ratioC = 0.618;
					ratioD = 0.786;
				}
				if (this.DAYS2Hold == 0)
				{
					this.UpCycle_1_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(Volatality_Scanner.buyEntry));
					double buyEntryValue = Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, buyEntryValue);
					Volatality_Sumary.BuyEntryValue1 = buyEntryValue;
					Volatality_Scanner.targetLTP = Volatality_Scanner.calculate_trigger(this.ltp11days, 0.08333, Volatality_Scanner._volatility, this.LTP);
					this.UpCycle_1_Target1.Inlines.Add(Volatality_Scanner.get_buyTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
					this.UpCycle_1_Target2.Inlines.Add(Volatality_Scanner.get_buyTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
					this.UpCycle_1_Target3.Inlines.Add(Volatality_Scanner.get_buyTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
					this.UpCycle_1_Target4.Inlines.Add(Volatality_Scanner.get_buyTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.UpCycle_1_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(Volatality_Scanner.buyEntry));
					double buyEntryValue2 = Convert.ToDouble(((Run)this.UpCycle_1_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_1_BuyEntry.Name, buyEntryValue2);
					Volatality_Sumary.BuyEntryValue1 = buyEntryValue2;
					this.UpCycle_1_Target1.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 40.0, Volatality_Scanner._volatility, Volatality_Scanner.buyEntry).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target1.Inlines.FirstInline).Text));
					this.UpCycle_1_Target2.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, Volatality_Scanner.buyEntry).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target2.Inlines.FirstInline).Text));
					this.UpCycle_1_Target3.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, Volatality_Scanner.buyEntry).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text));
					this.UpCycle_1_Target4.Inlines.Add(Math.Round(Volatality_Scanner.buyEntry + 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_1_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_1_Target4.Inlines.FirstInline).Text));
				}
				double secondCycleStart = Convert.ToDouble(((Run)this.UpCycle_1_Target3.Inlines.FirstInline).Text);
				if (this.DAYS2Hold == 0)
				{
					this.UpCycle_2_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(secondCycleStart));
					double buyEntryValue3 = Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, buyEntryValue3);
					Volatality_Sumary.BuyEntryValue2 = buyEntryValue3;
					this.UpCycle_2_Target1.Inlines.Add(Volatality_Scanner.get_buyTarget(secondCycleStart, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
					this.UpCycle_2_Target2.Inlines.Add(Volatality_Scanner.get_buyTarget(secondCycleStart, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
					this.UpCycle_2_Target3.Inlines.Add(Volatality_Scanner.get_buyTarget(secondCycleStart, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
					this.UpCycle_2_Target4.Inlines.Add(Volatality_Scanner.get_buyTarget(secondCycleStart, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.UpCycle_2_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(secondCycleStart));
					double buyEntryValue4 = Convert.ToDouble(((Run)this.UpCycle_2_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_2_BuyEntry.Name, buyEntryValue4);
					Volatality_Sumary.BuyEntryValue2 = buyEntryValue4;
					this.UpCycle_2_Target1.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, secondCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target1.Inlines.FirstInline).Text));
					this.UpCycle_2_Target2.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, secondCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target2.Inlines.FirstInline).Text));
					this.UpCycle_2_Target3.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 81.0, Volatality_Scanner._volatility, secondCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text));
					this.UpCycle_2_Target4.Inlines.Add(Math.Round(secondCycleStart + 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_2_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_2_Target4.Inlines.FirstInline).Text));
				}
				double thirdCycleStart = Convert.ToDouble(((Run)this.UpCycle_2_Target3.Inlines.FirstInline).Text);
				if (this.DAYS2Hold == 0)
				{
					this.UpCycle_3_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(thirdCycleStart));
					double buyEntryValue5 = Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, buyEntryValue5);
					Volatality_Sumary.BuyEntryValue3 = buyEntryValue5;
					this.UpCycle_3_Target1.Inlines.Add(Volatality_Scanner.get_buyTarget(thirdCycleStart, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
					this.UpCycle_3_Target2.Inlines.Add(Volatality_Scanner.get_buyTarget(thirdCycleStart, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
					this.UpCycle_3_Target3.Inlines.Add(Volatality_Scanner.get_buyTarget(thirdCycleStart, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
					this.UpCycle_3_Target4.Inlines.Add(Volatality_Scanner.get_buyTarget(thirdCycleStart, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.UpCycle_3_BuyEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(thirdCycleStart));
					double buyEntryValue6 = Convert.ToDouble(((Run)this.UpCycle_3_BuyEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.UpCycle_3_BuyEntry.Name, buyEntryValue6);
					Volatality_Sumary.BuyEntryValue3 = buyEntryValue6;
					this.UpCycle_3_Target1.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, thirdCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target1.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target1.Inlines.FirstInline).Text));
					this.UpCycle_3_Target2.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, thirdCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target2.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target2.Inlines.FirstInline).Text));
					this.UpCycle_3_Target3.Inlines.Add(Volatality_Scanner.get_BuyPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 81.0, Volatality_Scanner._volatility, thirdCycleStart).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target3.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target3.Inlines.FirstInline).Text));
					this.UpCycle_3_Target4.Inlines.Add(Math.Round(thirdCycleStart + 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.UpCycle_3_Target4.Name, Convert.ToDouble(((Run)this.UpCycle_3_Target4.Inlines.FirstInline).Text));
				}
				if (this.DAYS2Hold == 0)
				{
					this.DownCycle_1_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(Volatality_Scanner.sellEntry));
					double sellEntryValue = Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, sellEntryValue);
					Volatality_Sumary.SellEntryValue1 = sellEntryValue;
					this.DownCycle_1_Target1.Inlines.Add(Volatality_Scanner.get_sellTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
					this.DownCycle_1_Target2.Inlines.Add(Volatality_Scanner.get_sellTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
					this.DownCycle_1_Target3.Inlines.Add(Volatality_Scanner.get_sellTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
					this.DownCycle_1_Target4.Inlines.Add(Volatality_Scanner.get_sellTarget(Volatality_Scanner.targetLTP, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.DownCycle_1_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(Volatality_Scanner.sellEntry));
					double sellEntryValue2 = Convert.ToDouble(((Run)this.DownCycle_1_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_1_SellEntry.Name, sellEntryValue2);
					Volatality_Sumary.SellEntryValue1 = sellEntryValue2;
					this.DownCycle_1_Target1.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 40.0, Volatality_Scanner._volatility, Volatality_Scanner.sellEntry).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target1.Inlines.FirstInline).Text));
					this.DownCycle_1_Target2.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, Volatality_Scanner.sellEntry).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target2.Inlines.FirstInline).Text));
					this.DownCycle_1_Target3.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, Volatality_Scanner.sellEntry).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text));
					this.DownCycle_1_Target4.Inlines.Add(Math.Round(Volatality_Scanner.sellEntry - 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_1_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_1_Target4.Inlines.FirstInline).Text));
				}
				double secondDownStart = Convert.ToDouble(((Run)this.DownCycle_1_Target3.Inlines.FirstInline).Text);
				if (this.DAYS2Hold == 0)
				{
					this.DownCycle_2_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(secondDownStart));
					double sellEntryValue3 = Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, sellEntryValue3);
					Volatality_Sumary.SellEntryValue2 = sellEntryValue3;
					this.DownCycle_2_Target1.Inlines.Add(Volatality_Scanner.get_sellTarget(secondDownStart, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
					this.DownCycle_2_Target2.Inlines.Add(Volatality_Scanner.get_sellTarget(secondDownStart, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
					this.DownCycle_2_Target3.Inlines.Add(Volatality_Scanner.get_sellTarget(secondDownStart, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
					this.DownCycle_2_Target4.Inlines.Add(Volatality_Scanner.get_sellTarget(secondDownStart, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.DownCycle_2_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(secondDownStart));
					double sellEntryValue4 = Convert.ToDouble(((Run)this.DownCycle_2_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_2_SellEntry.Name, sellEntryValue4);
					Volatality_Sumary.SellEntryValue2 = sellEntryValue4;
					this.DownCycle_2_Target1.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, secondDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target1.Inlines.FirstInline).Text));
					this.DownCycle_2_Target2.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, secondDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target2.Inlines.FirstInline).Text));
					this.DownCycle_2_Target3.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 81.0, Volatality_Scanner._volatility, secondDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text));
					this.DownCycle_2_Target4.Inlines.Add(Math.Round(secondDownStart - 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_2_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_2_Target4.Inlines.FirstInline).Text));
				}
				double thirdDownStart = Convert.ToDouble(((Run)this.DownCycle_2_Target3.Inlines.FirstInline).Text);
				if (this.DAYS2Hold == 0)
				{
					this.DownCycle_3_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(thirdDownStart));
					double sellEntryValue5 = Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, sellEntryValue5);
					Volatality_Sumary.SellEntryValue3 = sellEntryValue5;
					this.DownCycle_3_Target1.Inlines.Add(Volatality_Scanner.get_sellTarget(thirdDownStart, Volatality_Scanner.priceRange, ratioA));
					this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
					this.DownCycle_3_Target2.Inlines.Add(Volatality_Scanner.get_sellTarget(thirdDownStart, Volatality_Scanner.priceRange, ratioB));
					this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
					this.DownCycle_3_Target3.Inlines.Add(Volatality_Scanner.get_sellTarget(thirdDownStart, Volatality_Scanner.priceRange, ratioC));
					this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
					this.DownCycle_3_Target4.Inlines.Add(Volatality_Scanner.get_sellTarget(thirdDownStart, Volatality_Scanner.priceRange, ratioD));
					this.all_calculatedTarget.Add(this.DownCycle_3_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target4.Inlines.FirstInline).Text));
				}
				else
				{
					this.DownCycle_3_SellEntry.Inlines.Add(Volatality_Scanner.do_RoundOffAndReturnString(thirdDownStart));
					double sellEntryValue6 = Convert.ToDouble(((Run)this.DownCycle_3_SellEntry.Inlines.FirstInline).Text);
					this.all_calculatedTarget.Add(this.DownCycle_3_SellEntry.Name, sellEntryValue6);
					Volatality_Sumary.SellEntryValue3 = sellEntryValue6;
					this.DownCycle_3_Target1.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 49.0, Volatality_Scanner._volatility, thirdDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target1.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target1.Inlines.FirstInline).Text));
					this.DownCycle_3_Target2.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 69.0, Volatality_Scanner._volatility, thirdDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target2.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target2.Inlines.FirstInline).Text));
					this.DownCycle_3_Target3.Inlines.Add(Volatality_Scanner.get_SellPositionaltarget(this.ltp11days, (double)this.DAYS2Hold, 81.0, Volatality_Scanner._volatility, thirdDownStart).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target3.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target3.Inlines.FirstInline).Text));
					this.DownCycle_3_Target4.Inlines.Add(Math.Round(thirdDownStart - 1.272 * Volatality_Scanner.priceRange, 2).ToString());
					this.all_calculatedTarget.Add(this.DownCycle_3_Target4.Name, Convert.ToDouble(((Run)this.DownCycle_3_Target4.Inlines.FirstInline).Text));
				}
				this.gbSummaryHeader.Header = "Volatility Summary";
				this.recommendation = "";
				try
				{
					Dictionary<string, double> nameOfControl = Volatality_Scanner.find_Nearest2LTP2Value(this.all_calculatedTarget, this.LTP);
					if (nameOfControl.Count > 0)
					{
						DependencyObject up = LogicalTreeHelper.FindLogicalNode(this.gridvUpCycle, nameOfControl.ElementAt(0).Key);
						DependencyObject upre = LogicalTreeHelper.FindLogicalNode(this.gridvUpCycle, nameOfControl.ElementAt(1).Key);
						DependencyObject down = LogicalTreeHelper.FindLogicalNode(this.gridvDownCycle, nameOfControl.ElementAt(0).Key);
						DependencyObject dpre = LogicalTreeHelper.FindLogicalNode(this.gridvDownCycle, nameOfControl.ElementAt(1).Key);
						if (up != null || upre != null)
						{
							string trend = "UP Trend";
							if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
							{
								trend = "Non of Cycle";
								this.recommendation = string.Concat(new string[]
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
								this.recommendation = Volatality_Scanner.up_Recommendation(nameOfControl, this.LTP, trend);
								this.paintTheTarget(up, upre);
							}
							this.gbSummaryHeader.Content = this.recommendation;
						}
						else if (down != null || dpre != null)
						{
							string trend = "DOWN Trend";
							if (nameOfControl.ElementAt(0).Key == "NULL" && nameOfControl.ElementAt(0).Value == 0.0)
							{
								trend = "Non of Cycle";
								this.recommendation = string.Concat(new string[]
								{
									"Ref Price : ",
									this.LTP.ToString(),
									"is in ",
									trend,
									", wait for clear Trend,",
									Environment.NewLine,
									" Enter Trade when Price touches any of the Entry Price."
								});
							}
							else
							{
								this.recommendation = Volatality_Scanner.down_Recommendation(nameOfControl, this.LTP, trend);
								this.paintTheTarget(down, dpre);
							}
							this.gbSummaryHeader.Content = this.recommendation;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error-413");
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0001E074 File Offset: 0x0001C274
		[NullableContext(1)]
		public static double get_buyEntry(List<double> _allLTP, double d, double _volatility, double LTP)
		{
			double valPriceRange;
			double tempPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility;
				tempPriceRange = Volatality_Scanner.get_tempPriceRange(valPriceRange, d);
				return LTP + tempPriceRange * d;
			}
			_volatility = Volatality_Scanner.get_Volatility(_allLTP, 2) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 2);
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2];
			double x = _allLTP[_allLTP.Count - 2] + d * valPriceRange;
			double y = _allLTP[_allLTP.Count - 2] - d * valPriceRange;
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				_volatility = Volatality_Scanner.get_Volatility(_allLTP, 1) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 1);
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1];
				tempPriceRange = Volatality_Scanner.get_tempPriceRange(valPriceRange, d);
				return _allLTP[_allLTP.Count - 1] + tempPriceRange * d;
			}
			tempPriceRange = Volatality_Scanner.get_tempPriceRange(valPriceRange, d);
			return _allLTP[_allLTP.Count - 2] + tempPriceRange * d;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0001E174 File Offset: 0x0001C374
		[NullableContext(1)]
		internal static double get_buyEntryPostional(List<double> _allLTP, int _HoldingDays, double _volatility, double _LTP)
		{
			double valPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = _LTP * _volatility * Math.Sqrt((double)_HoldingDays);
				return _LTP + 25.0 * (valPriceRange / 81.0);
			}
			double pastVolatility = Volatality_Scanner.get_Volatility(_allLTP, 2);
			double currentVolatility = Volatality_Scanner.get_Volatility(_allLTP, 1);
			if (pastVolatility > currentVolatility)
			{
				_volatility = pastVolatility + 0.0125 * pastVolatility;
			}
			else
			{
				_volatility = currentVolatility + 0.0125 * currentVolatility;
			}
			double x = _allLTP[_allLTP.Count - 2] + 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			double y = _allLTP[_allLTP.Count - 2] - 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1] * Math.Sqrt((double)_HoldingDays);
				return _allLTP[_allLTP.Count - 1] + 25.0 * (valPriceRange / 81.0);
			}
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2] * Math.Sqrt((double)_HoldingDays);
			return _allLTP[_allLTP.Count - 2] + 25.0 * (valPriceRange / 81.0);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0001E2D8 File Offset: 0x0001C4D8
		[NullableContext(1)]
		internal static double get_sellEntryPositional(List<double> _allLTP, int DAYS2Hold, double _volatility, double LTP)
		{
			double valPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility * Math.Sqrt((double)DAYS2Hold);
				return LTP - 25.0 * (valPriceRange / 81.0);
			}
			double pastVolatility = Volatality_Scanner.get_Volatility(_allLTP, 2);
			double currentVolatility = Volatality_Scanner.get_Volatility(_allLTP, 1);
			if (pastVolatility > currentVolatility)
			{
				_volatility = pastVolatility + 0.0125 * pastVolatility;
			}
			else
			{
				_volatility = currentVolatility + 0.0125 * currentVolatility;
			}
			double x = _allLTP[_allLTP.Count - 2] + 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			double y = _allLTP[_allLTP.Count - 2] - 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1] * Math.Sqrt((double)DAYS2Hold);
				return _allLTP[_allLTP.Count - 1] - 25.0 * (valPriceRange / 81.0);
			}
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2] * Math.Sqrt((double)DAYS2Hold);
			return _allLTP[_allLTP.Count - 2] - 25.0 * (valPriceRange / 81.0);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0001E43C File Offset: 0x0001C63C
		private static double get_tempPriceRange(double valPriceRange, double d)
		{
			return Math.Pow(Math.Sqrt(valPriceRange) + d, 2.0);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0001E454 File Offset: 0x0001C654
		[NullableContext(1)]
		public static double get_sellEntry(List<double> _allLTP, double d, double _volatility, double LTP)
		{
			double valPriceRange;
			double tempPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility;
				tempPriceRange = Volatality_Scanner.get_tempPriceRange(valPriceRange, d);
				return LTP - tempPriceRange * d;
			}
			_volatility = Volatality_Scanner.get_Volatility(_allLTP, 2) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 2);
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2];
			double x = _allLTP[_allLTP.Count - 2] + d * valPriceRange;
			double y = _allLTP[_allLTP.Count - 2] - d * valPriceRange;
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				_volatility = Volatality_Scanner.get_Volatility(_allLTP, 1) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 1);
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1];
				tempPriceRange = Math.Pow(Math.Sqrt(valPriceRange) - d, 2.0);
				return _allLTP[_allLTP.Count - 1] - d * tempPriceRange;
			}
			tempPriceRange = Math.Pow(Math.Sqrt(valPriceRange) - d, 2.0);
			return _allLTP[_allLTP.Count - 2] - d * tempPriceRange;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001E570 File Offset: 0x0001C770
		[NullableContext(1)]
		internal static double get_PositionalPriceRange(List<double> _allLTP, int DAYS2Hold, double _volatility, double _liveLTP)
		{
			int totalLTPCount = _allLTP.Count;
			double tempPriceRange;
			if (totalLTPCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				_volatility = Volatality_Scanner.get_Volatility(_allLTP, 2) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 2);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 2]) * Math.Sqrt((double)DAYS2Hold);
				double x = Convert.ToDouble(_allLTP[totalLTPCount - 2]) + 0.236 * tempPriceRange;
				double y = Convert.ToDouble(_allLTP[totalLTPCount - 2]) - 0.236 * tempPriceRange;
				if (Convert.ToDouble(_allLTP[totalLTPCount - 1]) > x || Convert.ToDouble(_allLTP[totalLTPCount - 1]) < y)
				{
					_volatility = Volatality_Scanner.get_Volatility(_allLTP, 1) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 1);
					tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 1]) * Math.Sqrt((double)DAYS2Hold);
				}
			}
			return tempPriceRange;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0001E660 File Offset: 0x0001C860
		[NullableContext(1)]
		public static double get_IntradayPriceRange(List<double> _allLTP, double _volatility, double _liveLTP)
		{
			int totalLTPCount = _allLTP.Count;
			double tempPriceRange;
			if (totalLTPCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				double num = Volatality_Scanner.get_Volatility(_allLTP, 1);
				_volatility = Volatality_Scanner.get_Volatility(_allLTP, 1) + 0.0125 * Volatality_Scanner.get_Volatility(_allLTP, 1);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 1]);
			}
			return tempPriceRange;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0001E6C0 File Offset: 0x0001C8C0
		[NullableContext(1)]
		public static double get_Volatility(List<double> ltp, int anumber)
		{
			double sumY = 0.0;
			double sumX = 0.0;
			int numberOfLtp = ltp.Count - anumber;
			for (int ltpindex = 0; ltpindex < numberOfLtp; ltpindex++)
			{
				double valueX = Math.Log(Convert.ToDouble(ltp[ltpindex + 1]) / Convert.ToDouble(ltp[ltpindex]));
				double valueY = valueX * valueX;
				sumX += valueX;
				sumY += valueY;
			}
			double avgX = sumX / (double)numberOfLtp;
			double SumSQRT = Math.Sqrt(sumY / (double)numberOfLtp - Math.Pow(avgX, 2.0));
			if (SumSQRT >= 75.0 && SumSQRT < 100.0)
			{
				SumSQRT /= 3.0;
			}
			else if (SumSQRT >= 100.0)
			{
				SumSQRT /= 5.0;
			}
			return SumSQRT;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0001E7A0 File Offset: 0x0001C9A0
		[NullableContext(1)]
		public static double calculate_trigger(List<double> _allLtp, double _d, double _volatility, double _LTP)
		{
			if (_allLtp.Count != 11)
			{
				return _LTP;
			}
			_volatility = Volatality_Scanner.get_Volatility(_allLtp, 2) + 0.0125 * Volatality_Scanner.get_Volatility(_allLtp, 2);
			double valPriceRange = _volatility * _allLtp[_allLtp.Count - 2];
			double x = _allLtp[_allLtp.Count - 2] + _d * valPriceRange;
			double y = _allLtp[_allLtp.Count - 2] - _d * valPriceRange;
			if (_allLtp[_allLtp.Count - 1] > x || _allLtp[_allLtp.Count - 1] < y)
			{
				return _allLtp[_allLtp.Count - 1];
			}
			return _allLtp[_allLtp.Count - 2];
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0001E84C File Offset: 0x0001CA4C
		[NullableContext(1)]
		public static double get_BuyPositionaltarget(List<double> _allLtp, double HoldingDays, double TargetCell, double _volatility, double _LTP)
		{
			if (_allLtp.Count == 11)
			{
				double priceRange = _LTP * _volatility * Math.Sqrt(HoldingDays);
				return Math.Round(_LTP + TargetCell * (priceRange / 81.0), 3);
			}
			return 0.0;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0001E89C File Offset: 0x0001CA9C
		[NullableContext(1)]
		public static string get_buyTarget(double openPrice, double priceRange, double ratio)
		{
			if (openPrice < 1000.0)
			{
				double denominator;
				if (openPrice < 100.0)
				{
					if (openPrice < 10.0)
					{
						openPrice *= 1000.0;
						priceRange *= 1000.0;
						denominator = 1000.0;
					}
					else
					{
						openPrice *= 100.0;
						priceRange *= 100.0;
						denominator = 100.0;
					}
				}
				else
				{
					openPrice *= 10.0;
					priceRange *= 10.0;
					denominator = 10.0;
				}
				return Math.Round(Volatality_Scanner.calculate_BuyTarget(openPrice, priceRange, ratio) / denominator, 2).ToString();
			}
			return Math.Round(Volatality_Scanner.calculate_BuyTarget(openPrice, priceRange, ratio), 2).ToString();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0001E96F File Offset: 0x0001CB6F
		private static double calculate_BuyTarget(double openPrice, double priceRange, double ratio)
		{
			Math.Pow(Math.Sqrt(priceRange) + ratio, 2.0);
			return openPrice + Math.Pow(Math.Sqrt(priceRange) + ratio, 2.0) * ratio;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		[NullableContext(1)]
		public static string get_sellTarget(double openPrice, double priceRange, double ratio)
		{
			if (openPrice < 1000.0)
			{
				double denominator;
				if (openPrice < 100.0)
				{
					if (openPrice < 10.0)
					{
						openPrice *= 1000.0;
						priceRange *= 1000.0;
						denominator = 1000.0;
					}
					else
					{
						openPrice *= 100.0;
						priceRange *= 100.0;
						denominator = 100.0;
					}
				}
				else
				{
					openPrice *= 10.0;
					priceRange *= 10.0;
					denominator = 10.0;
				}
				return Math.Round(Volatality_Scanner.calculate_SellTarget(openPrice, priceRange, ratio) / denominator, 2).ToString();
			}
			return Math.Round(Volatality_Scanner.calculate_SellTarget(openPrice, priceRange, ratio), 2).ToString();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0001EA77 File Offset: 0x0001CC77
		private static double calculate_SellTarget(double openPrice, double priceRange, double ratio)
		{
			return openPrice - Math.Pow(Math.Sqrt(priceRange) - ratio, 2.0) * ratio;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0001EA94 File Offset: 0x0001CC94
		[NullableContext(1)]
		public static double get_SellPositionaltarget(List<double> _allLtp, double HoldingDays, double TargetCell, double _volatility, double _LTP)
		{
			if (_allLtp.Count == 11)
			{
				double priceRange = _LTP * _volatility * Math.Sqrt(HoldingDays);
				return Math.Round(_LTP - TargetCell * (priceRange / 81.0), 3);
			}
			return 0.0;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0001EAE4 File Offset: 0x0001CCE4
		[NullableContext(1)]
		public static string do_RoundOffAndReturnString(double _value)
		{
			return Math.Round(_value, 3).ToString();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0001EB00 File Offset: 0x0001CD00
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
			catch (Exception)
			{
				result = bestMatchTarget;
			}
			return result;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0001ED78 File Offset: 0x0001CF78
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

		// Token: 0x060001F2 RID: 498 RVA: 0x0001EDAC File Offset: 0x0001CFAC
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

		// Token: 0x060001F3 RID: 499 RVA: 0x0001EF9C File Offset: 0x0001D19C
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
					return Volatality_Scanner.up_Recommendation(nameOfControl, LTP, downcycle);
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

		// Token: 0x060001F4 RID: 500 RVA: 0x0001F160 File Offset: 0x0001D360
		[NullableContext(1)]
		public static string up_Recommendation(Dictionary<string, double> nameOfControl, double LTP, string upCycle)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			if (str.Contains("Down"))
			{
				return Volatality_Scanner.down_Recommendation(nameOfControl, LTP, upCycle);
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

		// Token: 0x060001F5 RID: 501 RVA: 0x0001F2F8 File Offset: 0x0001D4F8
		[NullableContext(1)]
		public static string up_RecommendationWave(Dictionary<string, double> nameOfControl, double LTP, string upCycle, string WaveType)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			string Target;
			if (str != null)
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
				Target = "BuyEntry_s";
			}
			if (WaveType == "IMPULSIVE")
			{
				if (Target != null)
				{
					int length = Target.Length;
					if (length == 9)
					{
						switch (Target[6])
						{
						case '1':
							if (!(Target == "Target1_s") && !(Target == "Target1_e"))
							{
								goto IL_1E2;
							}
							goto IL_194;
						case '2':
							if (!(Target == "Target2_s") && !(Target == "Target2_e"))
							{
								goto IL_1E2;
							}
							break;
						case '3':
							if (!(Target == "Target3_s") && !(Target == "Target3_e"))
							{
								goto IL_1E2;
							}
							break;
						case '4':
							if (!(Target == "Target4_s") && !(Target == "Target4_e"))
							{
								goto IL_1E2;
							}
							goto IL_1C8;
						case '5':
							if (!(Target == "Target5_s") && !(Target == "Target5_e"))
							{
								goto IL_1E2;
							}
							goto IL_1C8;
						default:
							goto IL_1E2;
						}
						recommendation = "BUY";
						Equtiy_Future.buyCount.Add("1");
						goto IL_329;
						IL_1C8:
						recommendation = "Wait till it enter FRESH cycle.";
						Equtiy_Future.neutralCount.Add("0");
						goto IL_329;
					}
					if (length != 10)
					{
						goto IL_1E2;
					}
					char c = Target[9];
					if (c != 'e')
					{
						if (c != 's')
						{
							goto IL_1E2;
						}
						if (!(Target == "BuyEntry_s"))
						{
							goto IL_1E2;
						}
					}
					else if (!(Target == "BuyEntry_e"))
					{
						goto IL_1E2;
					}
					IL_194:
					recommendation = "Wait for Wave2 to Start, Than BUY";
					Equtiy_Future.buyCount.Add("1");
					goto IL_329;
				}
				IL_1E2:
				Equtiy_Future.neutralCount.Add("0");
			}
			else
			{
				if (Target != null)
				{
					int length = Target.Length;
					if (length != 9)
					{
						if (length == 10)
						{
							char c = Target[9];
							if (c != 'e')
							{
								if (c != 's')
								{
									goto IL_31A;
								}
								if (!(Target == "BuyEntry_s"))
								{
									goto IL_31A;
								}
							}
							else if (!(Target == "BuyEntry_e"))
							{
								goto IL_31A;
							}
							recommendation = "Wait for WaveB to Start, Than BUY";
							goto IL_329;
						}
					}
					else
					{
						switch (Target[6])
						{
						case '1':
							if (Target == "Target1_s" || Target == "Target1_e")
							{
								recommendation = "BUY";
								Equtiy_Future.buyCount.Add("1");
								goto IL_329;
							}
							break;
						case '2':
							if (Target == "Target2_s" || Target == "Target2_e")
							{
								recommendation = "Wait for fresh Cycle to start.";
								Equtiy_Future.neutralCount.Add("0");
								goto IL_329;
							}
							break;
						case '3':
							if (Target == "Target3_s" || Target == "Target3_e")
							{
								recommendation = "Wait for fresh Cycle to start.";
								Equtiy_Future.neutralCount.Add("0");
								goto IL_329;
							}
							break;
						}
					}
				}
				IL_31A:
				Equtiy_Future.neutralCount.Add("0");
			}
			IL_329:
			double start = nameOfControl.ElementAt(0).Value;
			double end = nameOfControl.ElementAt(1).Value;
			if (start > end)
			{
				double num = end;
				end = start;
				start = num;
			}
			if (nameOfControl.ElementAt(1).Key != "NULL")
			{
				return string.Format("As Ref price {0}, is in {1}, with price between {2} to {3}. ##Recommendation:: {4}", new object[]
				{
					LTP,
					upCycle,
					start,
					end,
					recommendation
				});
			}
			return string.Format("As Ref price {0}, is in {1}, and moving towards {2}. ##Recommendation {3}", new object[]
			{
				LTP,
				upCycle,
				nameOfControl.ElementAt(1).Value,
				recommendation
			});
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0001F6E8 File Offset: 0x0001D8E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocater = new Uri("/New SF_IT;component/volatality_designs/volatility_scanner.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0001F718 File Offset: 0x0001D918
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.groupBoxvUpTrend = (GroupBox)target;
				return;
			case 2:
				this.gridvUpCycle = (Grid)target;
				return;
			case 3:
				this.fDocUpCycle1 = (FlowDocument)target;
				return;
			case 4:
				this.UpCycle_1_BuyEntry = (Paragraph)target;
				return;
			case 5:
				this.UpCycle_1_Target1 = (Paragraph)target;
				return;
			case 6:
				this.UpCycle_1_Target2 = (Paragraph)target;
				return;
			case 7:
				this.UpCycle_1_Target3 = (Paragraph)target;
				return;
			case 8:
				this.UpCycle_1_Target4 = (Paragraph)target;
				return;
			case 9:
				this.fDocUpCycle2 = (FlowDocument)target;
				return;
			case 10:
				this.UpCycle_2_BuyEntry = (Paragraph)target;
				return;
			case 11:
				this.UpCycle_2_Target1 = (Paragraph)target;
				return;
			case 12:
				this.UpCycle_2_Target2 = (Paragraph)target;
				return;
			case 13:
				this.UpCycle_2_Target3 = (Paragraph)target;
				return;
			case 14:
				this.UpCycle_2_Target4 = (Paragraph)target;
				return;
			case 15:
				this.fDocUpCycle3 = (FlowDocument)target;
				return;
			case 16:
				this.UpCycle_3_BuyEntry = (Paragraph)target;
				return;
			case 17:
				this.UpCycle_3_Target1 = (Paragraph)target;
				return;
			case 18:
				this.UpCycle_3_Target2 = (Paragraph)target;
				return;
			case 19:
				this.UpCycle_3_Target3 = (Paragraph)target;
				return;
			case 20:
				this.UpCycle_3_Target4 = (Paragraph)target;
				return;
			case 21:
				this.groupBoxvDownTrend = (GroupBox)target;
				return;
			case 22:
				this.gridvDownCycle = (Grid)target;
				return;
			case 23:
				this.fDocDownCycle1 = (FlowDocument)target;
				return;
			case 24:
				this.DownCycle_1_SellEntry = (Paragraph)target;
				return;
			case 25:
				this.DownCycle_1_Target1 = (Paragraph)target;
				return;
			case 26:
				this.DownCycle_1_Target2 = (Paragraph)target;
				return;
			case 27:
				this.DownCycle_1_Target3 = (Paragraph)target;
				return;
			case 28:
				this.DownCycle_1_Target4 = (Paragraph)target;
				return;
			case 29:
				this.fDocDownCycle2 = (FlowDocument)target;
				return;
			case 30:
				this.DownCycle_2_SellEntry = (Paragraph)target;
				return;
			case 31:
				this.DownCycle_2_Target1 = (Paragraph)target;
				return;
			case 32:
				this.DownCycle_2_Target2 = (Paragraph)target;
				return;
			case 33:
				this.DownCycle_2_Target3 = (Paragraph)target;
				return;
			case 34:
				this.DownCycle_2_Target4 = (Paragraph)target;
				return;
			case 35:
				this.fDocDownCycle3 = (FlowDocument)target;
				return;
			case 36:
				this.DownCycle_3_SellEntry = (Paragraph)target;
				return;
			case 37:
				this.DownCycle_3_Target1 = (Paragraph)target;
				return;
			case 38:
				this.DownCycle_3_Target2 = (Paragraph)target;
				return;
			case 39:
				this.DownCycle_3_Target3 = (Paragraph)target;
				return;
			case 40:
				this.DownCycle_3_Target4 = (Paragraph)target;
				return;
			case 41:
				this.gbSummaryHeader = (GroupBox)target;
				return;
			case 42:
				this.gridvSummary = (Grid)target;
				return;
			case 43:
				this.volatilitySummary1 = (Label)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040003E5 RID: 997
		private double LOW;

		// Token: 0x040003E6 RID: 998
		private double HIGH;

		// Token: 0x040003E7 RID: 999
		private double LTP;

		// Token: 0x040003E8 RID: 1000
		private double OPEN;

		// Token: 0x040003E9 RID: 1001
		private int DAYS2Hold;

		// Token: 0x040003EA RID: 1002
		[Nullable(1)]
		private List<double> ltp11days;

		// Token: 0x040003EB RID: 1003
		public static double priceRange;

		// Token: 0x040003EC RID: 1004
		public static double pdLTP;

		// Token: 0x040003ED RID: 1005
		public static double _volatility;

		// Token: 0x040003EE RID: 1006
		public static double targetLTP;

		// Token: 0x040003EF RID: 1007
		[Nullable(1)]
		private Dictionary<string, double> all_calculatedTarget;

		// Token: 0x040003F0 RID: 1008
		public static double buyEntry;

		// Token: 0x040003F1 RID: 1009
		public static double sellEntry;

		// Token: 0x040003F2 RID: 1010
		[Nullable(1)]
		private string recommendation;

		// Token: 0x040003F8 RID: 1016
		internal GroupBox groupBoxvUpTrend;

		// Token: 0x040003F9 RID: 1017
		internal Grid gridvUpCycle;

		// Token: 0x040003FA RID: 1018
		internal FlowDocument fDocUpCycle1;

		// Token: 0x040003FB RID: 1019
		internal Paragraph UpCycle_1_BuyEntry;

		// Token: 0x040003FC RID: 1020
		internal Paragraph UpCycle_1_Target1;

		// Token: 0x040003FD RID: 1021
		internal Paragraph UpCycle_1_Target2;

		// Token: 0x040003FE RID: 1022
		internal Paragraph UpCycle_1_Target3;

		// Token: 0x040003FF RID: 1023
		internal Paragraph UpCycle_1_Target4;

		// Token: 0x04000400 RID: 1024
		internal FlowDocument fDocUpCycle2;

		// Token: 0x04000401 RID: 1025
		internal Paragraph UpCycle_2_BuyEntry;

		// Token: 0x04000402 RID: 1026
		internal Paragraph UpCycle_2_Target1;

		// Token: 0x04000403 RID: 1027
		internal Paragraph UpCycle_2_Target2;

		// Token: 0x04000404 RID: 1028
		internal Paragraph UpCycle_2_Target3;

		// Token: 0x04000405 RID: 1029
		internal Paragraph UpCycle_2_Target4;

		// Token: 0x04000406 RID: 1030
		internal FlowDocument fDocUpCycle3;

		// Token: 0x04000407 RID: 1031
		internal Paragraph UpCycle_3_BuyEntry;

		// Token: 0x04000408 RID: 1032
		internal Paragraph UpCycle_3_Target1;

		// Token: 0x04000409 RID: 1033
		internal Paragraph UpCycle_3_Target2;

		// Token: 0x0400040A RID: 1034
		internal Paragraph UpCycle_3_Target3;

		// Token: 0x0400040B RID: 1035
		internal Paragraph UpCycle_3_Target4;

		// Token: 0x0400040C RID: 1036
		internal GroupBox groupBoxvDownTrend;

		// Token: 0x0400040D RID: 1037
		internal Grid gridvDownCycle;

		// Token: 0x0400040E RID: 1038
		internal FlowDocument fDocDownCycle1;

		// Token: 0x0400040F RID: 1039
		internal Paragraph DownCycle_1_SellEntry;

		// Token: 0x04000410 RID: 1040
		internal Paragraph DownCycle_1_Target1;

		// Token: 0x04000411 RID: 1041
		internal Paragraph DownCycle_1_Target2;

		// Token: 0x04000412 RID: 1042
		internal Paragraph DownCycle_1_Target3;

		// Token: 0x04000413 RID: 1043
		internal Paragraph DownCycle_1_Target4;

		// Token: 0x04000414 RID: 1044
		internal FlowDocument fDocDownCycle2;

		// Token: 0x04000415 RID: 1045
		internal Paragraph DownCycle_2_SellEntry;

		// Token: 0x04000416 RID: 1046
		internal Paragraph DownCycle_2_Target1;

		// Token: 0x04000417 RID: 1047
		internal Paragraph DownCycle_2_Target2;

		// Token: 0x04000418 RID: 1048
		internal Paragraph DownCycle_2_Target3;

		// Token: 0x04000419 RID: 1049
		internal Paragraph DownCycle_2_Target4;

		// Token: 0x0400041A RID: 1050
		internal FlowDocument fDocDownCycle3;

		// Token: 0x0400041B RID: 1051
		internal Paragraph DownCycle_3_SellEntry;

		// Token: 0x0400041C RID: 1052
		internal Paragraph DownCycle_3_Target1;

		// Token: 0x0400041D RID: 1053
		internal Paragraph DownCycle_3_Target2;

		// Token: 0x0400041E RID: 1054
		internal Paragraph DownCycle_3_Target3;

		// Token: 0x0400041F RID: 1055
		internal Paragraph DownCycle_3_Target4;

		// Token: 0x04000420 RID: 1056
		internal GroupBox gbSummaryHeader;

		// Token: 0x04000421 RID: 1057
		internal Grid gridvSummary;

		// Token: 0x04000422 RID: 1058
		internal Label volatilitySummary1;

		// Token: 0x04000423 RID: 1059
		private bool _contentLoaded;
	}
}
