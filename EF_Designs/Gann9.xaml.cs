using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using New_SF_IT.chartWindow;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000043 RID: 67
	public partial class Gann9 : UserControl
	{
		// Token: 0x06000334 RID: 820 RVA: 0x00067FA3 File Offset: 0x000661A3
		public Gann9()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00067FB4 File Offset: 0x000661B4
		public void InitializeVariable()
		{
			this.Clear();
			this.fact = (Equtiy_Future.LIVE_DATA.high - Equtiy_Future.LIVE_DATA.low) / Equtiy_Future.LIVE_DATA.high;
			this.diff = this.fact * Equtiy_Future.LIVE_DATA.high;
			Gann9.step = this.diff / 81.0;
			this._10thCellValue = 0.0;
			Gann9.seed1ValueBuy = 0.0;
			Gann9.seed1ValueSell = 0.0;
			this.buyCalculation();
			this.sellCalculation();
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00068050 File Offset: 0x00066250
		private void buyCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.low + Gann9.step * 10.0;
			Gann9.seed1ValueBuy = this.getSeed1Value(this._10thCellValue, "Buy");
			this.C1_BuyEntryVal = Gann9.seed1ValueBuy + Gann9.step * 25.0;
			this.C1_BuyTarget1Val = Gann9.seed1ValueBuy + Gann9.step * 28.0;
			this.C1_BuyTarget2Val = Gann9.seed1ValueBuy + Gann9.step * 31.0;
			this.C1_BuyTarget3Val = Gann9.seed1ValueBuy + Gann9.step * 34.0;
			this.C1_BuyTarget4Val = Gann9.seed1ValueBuy + Gann9.step * 37.0;
			this.C1_BuyStopLossVal = Gann9.seed1ValueBuy;
			this.C2_BuyEntryVal = Gann9.seed1ValueBuy + Gann9.step * 40.0;
			this.C2_BuyTarget1Val = Gann9.seed1ValueBuy + Gann9.step * 43.0;
			this.C2_BuyTarget2Val = Gann9.seed1ValueBuy + Gann9.step * 46.0;
			this.C2_BuyTarget3Val = Gann9.seed1ValueBuy + Gann9.step * 49.0;
			this.C2_BuyTarget4Val = Gann9.seed1ValueBuy + Gann9.step * 57.0;
			this.C2_BuyStopLossVal = Gann9.seed1ValueBuy + Gann9.step * 34.0;
			this.C3_BuyEntryVal = Gann9.seed1ValueBuy + Gann9.step * 61.0;
			this.C3_BuyTarget1Val = Gann9.seed1ValueBuy + Gann9.step * 65.0;
			this.C3_BuyTarget2Val = Gann9.seed1ValueBuy + Gann9.step * 73.0;
			this.C3_BuyTarget3Val = Gann9.seed1ValueBuy + Gann9.step * 77.0;
			this.C3_BuyTarget4Val = Gann9.seed1ValueBuy + Gann9.step * 81.0;
			this.C3_BuyStopLossVal = Gann9.seed1ValueBuy + Gann9.step * 49.0;
			this.C1_BuyEntry.Inlines.Add(Math.Round(this.C1_BuyEntryVal, 2).ToString());
			this.C1_BuyTarget1.Inlines.Add(Math.Round(this.C1_BuyTarget1Val, 2).ToString());
			this.C1_BuyTarget2.Inlines.Add(Math.Round(this.C1_BuyTarget2Val, 2).ToString());
			this.C1_BuyTarget3.Inlines.Add(Math.Round(this.C1_BuyTarget3Val, 2).ToString());
			this.C1_BuyTarget4.Inlines.Add(Math.Round(this.C1_BuyTarget4Val, 2).ToString());
			this.C1_BuyStoploss.Inlines.Add(Math.Round(this.C1_BuyStopLossVal, 2).ToString());
			this.C2_BuyEntry.Inlines.Add(Math.Round(this.C2_BuyEntryVal, 2).ToString());
			this.C2_BuyTarget1.Inlines.Add(Math.Round(this.C2_BuyTarget1Val, 2).ToString());
			this.C2_BuyTarget2.Inlines.Add(Math.Round(this.C2_BuyTarget2Val, 2).ToString());
			this.C2_BuyTarget3.Inlines.Add(Math.Round(this.C2_BuyTarget3Val, 2).ToString());
			this.C2_BuyTarget4.Inlines.Add(Math.Round(this.C2_BuyTarget4Val, 2).ToString());
			this.C2_BuyStoploss.Inlines.Add(Math.Round(this.C2_BuyStopLossVal, 2).ToString());
			this.C3_BuyEntry.Inlines.Add(Math.Round(this.C3_BuyEntryVal, 2).ToString());
			this.C3_BuyTarget1.Inlines.Add(Math.Round(this.C3_BuyTarget1Val, 2).ToString());
			this.C3_BuyTarget2.Inlines.Add(Math.Round(this.C3_BuyTarget2Val, 2).ToString());
			this.C3_BuyTarget3.Inlines.Add(Math.Round(this.C3_BuyTarget3Val, 2).ToString());
			this.C3_BuyTarget4.Inlines.Add(Math.Round(this.C3_BuyTarget4Val, 2).ToString());
			this.C3_BuyStoploss.Inlines.Add(Math.Round(this.C3_BuyStopLossVal, 2).ToString());
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000684F4 File Offset: 0x000666F4
		private void sellCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.high - Gann9.step * 10.0;
			Gann9.seed1ValueSell = this.getSeed1Value(this._10thCellValue, "Sell");
			this.C1_SellEntryVal = Gann9.seed1ValueSell - Gann9.step * 25.0;
			this.C1_SellTarget1Val = Gann9.seed1ValueSell - Gann9.step * 28.0;
			this.C1_SellTarget2Val = Gann9.seed1ValueSell - Gann9.step * 31.0;
			this.C1_SellTarget3Val = Gann9.seed1ValueSell - Gann9.step * 34.0;
			this.C1_SellTarget4Val = Gann9.seed1ValueSell - Gann9.step * 37.0;
			this.C1_SellStopLossVal = Gann9.seed1ValueSell;
			this.C2_SellEntryVal = Gann9.seed1ValueSell - Gann9.step * 40.0;
			this.C2_SellTarget1Val = Gann9.seed1ValueSell - Gann9.step * 43.0;
			this.C2_SellTarget2Val = Gann9.seed1ValueSell - Gann9.step * 46.0;
			this.C2_SellTarget3Val = Gann9.seed1ValueSell - Gann9.step * 49.0;
			this.C2_SellTarget4Val = Gann9.seed1ValueSell - Gann9.step * 57.0;
			this.C2_SellStopLossVal = Gann9.seed1ValueSell - Gann9.step * 34.0;
			this.C3_SellEntryVal = Gann9.seed1ValueSell - Gann9.step * 61.0;
			this.C3_SellTarget1Val = Gann9.seed1ValueSell - Gann9.step * 65.0;
			this.C3_SellTarget2Val = Gann9.seed1ValueSell - Gann9.step * 73.0;
			this.C3_SellTarget3Val = Gann9.seed1ValueSell - Gann9.step * 77.0;
			this.C3_SellTarget4Val = Gann9.seed1ValueSell - Gann9.step * 81.0;
			this.C3_SellStopLossVal = Gann9.seed1ValueSell - Gann9.step * 49.0;
			this.C1_SellEntry.Inlines.Add(Math.Round(this.C1_SellEntryVal, 2).ToString());
			this.C1_SellTarget1.Inlines.Add(Math.Round(this.C1_SellTarget1Val, 2).ToString());
			this.C1_SellTarget2.Inlines.Add(Math.Round(this.C1_SellTarget2Val, 2).ToString());
			this.C1_SellTarget3.Inlines.Add(Math.Round(this.C1_SellTarget3Val, 2).ToString());
			this.C1_SellTarget4.Inlines.Add(Math.Round(this.C1_SellTarget4Val, 2).ToString());
			this.C1_SellStoploss.Inlines.Add(Math.Round(this.C1_SellStopLossVal, 2).ToString());
			this.C2_SellEntry.Inlines.Add(Math.Round(this.C2_SellEntryVal, 2).ToString());
			this.C2_SellTarget1.Inlines.Add(Math.Round(this.C2_SellTarget1Val, 2).ToString());
			this.C2_SellTarget2.Inlines.Add(Math.Round(this.C2_SellTarget2Val, 2).ToString());
			this.C2_SellTarget3.Inlines.Add(Math.Round(this.C2_SellTarget3Val, 2).ToString());
			this.C2_SellTarget4.Inlines.Add(Math.Round(this.C2_SellTarget4Val, 2).ToString());
			this.C2_SellStoploss.Inlines.Add(Math.Round(this.C2_SellStopLossVal, 2).ToString());
			this.C3_SellEntry.Inlines.Add(Math.Round(this.C3_SellEntryVal, 2).ToString());
			this.C3_SellTarget1.Inlines.Add(Math.Round(this.C3_SellTarget1Val, 2).ToString());
			this.C3_SellTarget2.Inlines.Add(Math.Round(this.C3_SellTarget2Val, 2).ToString());
			this.C3_SellTarget3.Inlines.Add(Math.Round(this.C3_SellTarget3Val, 2).ToString());
			this.C3_SellTarget4.Inlines.Add(Math.Round(this.C3_SellTarget4Val, 2).ToString());
			this.C3_SellStoploss.Inlines.Add(Math.Round(this.C3_SellStopLossVal, 2).ToString());
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00068995 File Offset: 0x00066B95
		[NullableContext(1)]
		private void buyDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann9_Chart("buy", Gann9.seed1ValueBuy, Gann9.step).Show();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000689B0 File Offset: 0x00066BB0
		[NullableContext(1)]
		private void sellDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann9_Chart("sell", Gann9.seed1ValueSell, Gann9.step).Show();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000689CC File Offset: 0x00066BCC
		[NullableContext(1)]
		private double getSeed1Value(double cell_10_Value, string decision)
		{
			double seed = 0.0;
			if (decision == "Buy")
			{
				if (Equtiy_Future.LIVE_DATA.ltp > cell_10_Value)
				{
					seed = Equtiy_Future.LIVE_DATA.ltp;
				}
				else
				{
					seed = Equtiy_Future.LIVE_DATA.low;
				}
			}
			else if (decision == "Sell")
			{
				if (Equtiy_Future.LIVE_DATA.ltp < cell_10_Value)
				{
					seed = Equtiy_Future.LIVE_DATA.ltp;
				}
				else
				{
					seed = Equtiy_Future.LIVE_DATA.high;
				}
			}
			return seed;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00068A4C File Offset: 0x00066C4C
		private void Clear()
		{
			this.C1_BuyEntry.Inlines.Clear();
			this.C1_BuyTarget1.Inlines.Clear();
			this.C1_BuyTarget2.Inlines.Clear();
			this.C1_BuyTarget3.Inlines.Clear();
			this.C1_BuyTarget4.Inlines.Clear();
			this.C1_BuyStoploss.Inlines.Clear();
			this.C2_BuyEntry.Inlines.Clear();
			this.C2_BuyTarget1.Inlines.Clear();
			this.C2_BuyTarget2.Inlines.Clear();
			this.C2_BuyTarget3.Inlines.Clear();
			this.C2_BuyTarget4.Inlines.Clear();
			this.C2_BuyStoploss.Inlines.Clear();
			this.C3_BuyEntry.Inlines.Clear();
			this.C3_BuyTarget1.Inlines.Clear();
			this.C3_BuyTarget2.Inlines.Clear();
			this.C3_BuyTarget3.Inlines.Clear();
			this.C3_BuyTarget4.Inlines.Clear();
			this.C3_BuyStoploss.Inlines.Clear();
			this.C1_SellEntry.Inlines.Clear();
			this.C1_SellTarget1.Inlines.Clear();
			this.C1_SellTarget2.Inlines.Clear();
			this.C1_SellTarget3.Inlines.Clear();
			this.C1_SellTarget4.Inlines.Clear();
			this.C1_SellStoploss.Inlines.Clear();
			this.C2_SellEntry.Inlines.Clear();
			this.C2_SellTarget1.Inlines.Clear();
			this.C2_SellTarget2.Inlines.Clear();
			this.C2_SellTarget3.Inlines.Clear();
			this.C2_SellTarget4.Inlines.Clear();
			this.C2_SellStoploss.Inlines.Clear();
			this.C3_SellEntry.Inlines.Clear();
			this.C3_SellTarget1.Inlines.Clear();
			this.C3_SellTarget2.Inlines.Clear();
			this.C3_SellTarget3.Inlines.Clear();
			this.C3_SellTarget4.Inlines.Clear();
			this.C3_SellStoploss.Inlines.Clear();
		}

		// Token: 0x04000996 RID: 2454
		public static double High;

		// Token: 0x04000997 RID: 2455
		public static double Low;

		// Token: 0x04000998 RID: 2456
		public static double seed1ValueBuy;

		// Token: 0x04000999 RID: 2457
		public static double seed1ValueSell;

		// Token: 0x0400099A RID: 2458
		public static double seed1Value_GS9;

		// Token: 0x0400099B RID: 2459
		public static double seed1Value_mGS9;

		// Token: 0x0400099C RID: 2460
		public static double seed1Value_GS12;

		// Token: 0x0400099D RID: 2461
		public static double seed1Value_mGS12;

		// Token: 0x0400099E RID: 2462
		public static double step;

		// Token: 0x0400099F RID: 2463
		public double C1_BuyEntryVal;

		// Token: 0x040009A0 RID: 2464
		public double C1_BuyTarget1Val;

		// Token: 0x040009A1 RID: 2465
		public double C1_BuyTarget2Val;

		// Token: 0x040009A2 RID: 2466
		public double C1_BuyTarget3Val;

		// Token: 0x040009A3 RID: 2467
		public double C1_BuyTarget4Val;

		// Token: 0x040009A4 RID: 2468
		public double C1_BuyStopLossVal;

		// Token: 0x040009A5 RID: 2469
		public double C2_BuyEntryVal;

		// Token: 0x040009A6 RID: 2470
		public double C2_BuyTarget1Val;

		// Token: 0x040009A7 RID: 2471
		public double C2_BuyTarget2Val;

		// Token: 0x040009A8 RID: 2472
		public double C2_BuyTarget3Val;

		// Token: 0x040009A9 RID: 2473
		public double C2_BuyTarget4Val;

		// Token: 0x040009AA RID: 2474
		public double C2_BuyStopLossVal;

		// Token: 0x040009AB RID: 2475
		public double C3_BuyEntryVal;

		// Token: 0x040009AC RID: 2476
		public double C3_BuyTarget1Val;

		// Token: 0x040009AD RID: 2477
		public double C3_BuyTarget2Val;

		// Token: 0x040009AE RID: 2478
		public double C3_BuyTarget3Val;

		// Token: 0x040009AF RID: 2479
		public double C3_BuyTarget4Val;

		// Token: 0x040009B0 RID: 2480
		public double C3_BuyStopLossVal;

		// Token: 0x040009B1 RID: 2481
		public double C1_SellEntryVal;

		// Token: 0x040009B2 RID: 2482
		public double C1_SellTarget1Val;

		// Token: 0x040009B3 RID: 2483
		public double C1_SellTarget2Val;

		// Token: 0x040009B4 RID: 2484
		public double C1_SellTarget3Val;

		// Token: 0x040009B5 RID: 2485
		public double C1_SellTarget4Val;

		// Token: 0x040009B6 RID: 2486
		public double C1_SellStopLossVal;

		// Token: 0x040009B7 RID: 2487
		public double C2_SellEntryVal;

		// Token: 0x040009B8 RID: 2488
		public double C2_SellTarget1Val;

		// Token: 0x040009B9 RID: 2489
		public double C2_SellTarget2Val;

		// Token: 0x040009BA RID: 2490
		public double C2_SellTarget3Val;

		// Token: 0x040009BB RID: 2491
		public double C2_SellTarget4Val;

		// Token: 0x040009BC RID: 2492
		public double C2_SellStopLossVal;

		// Token: 0x040009BD RID: 2493
		public double C3_SellEntryVal;

		// Token: 0x040009BE RID: 2494
		public double C3_SellTarget1Val;

		// Token: 0x040009BF RID: 2495
		public double C3_SellTarget2Val;

		// Token: 0x040009C0 RID: 2496
		public double C3_SellTarget3Val;

		// Token: 0x040009C1 RID: 2497
		public double C3_SellTarget4Val;

		// Token: 0x040009C2 RID: 2498
		public double C3_SellStopLossVal;

		// Token: 0x040009C3 RID: 2499
		private double fact;

		// Token: 0x040009C4 RID: 2500
		private double diff;

		// Token: 0x040009C5 RID: 2501
		private double _10thCellValue;
	}
}
