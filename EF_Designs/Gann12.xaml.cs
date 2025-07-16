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
	// Token: 0x02000042 RID: 66
	public partial class Gann12 : UserControl
	{
		// Token: 0x0600032A RID: 810 RVA: 0x00066ED2 File Offset: 0x000650D2
		public Gann12()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00066EE0 File Offset: 0x000650E0
		public void InitializeVariable()
		{
			this.Clear();
			this.fact = (Equtiy_Future.LIVE_DATA.high - Equtiy_Future.LIVE_DATA.low) / Equtiy_Future.LIVE_DATA.high;
			this.diff = this.fact * Equtiy_Future.LIVE_DATA.high;
			Gann12.step = this.diff / 144.0;
			this._10thCellValue = 0.0;
			Gann12.seed1ValueBuy = 0.0;
			Gann12.seed1ValueSell = 0.0;
			this.buyCalculation();
			this.sellCalculation();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00066F7C File Offset: 0x0006517C
		private void buyCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.low + Gann12.step * 10.0;
			Gann12.seed1ValueBuy = this.getSeed1Value(this._10thCellValue, "Buy");
			this.C1_BuyEntryVal = Gann12.seed1ValueBuy + Gann12.step * 27.0;
			this.C1_BuyTarget1Val = Gann12.seed1ValueBuy + Gann12.step * 53.0;
			this.C1_BuyTarget2Val = Gann12.seed1ValueBuy + Gann12.step * 56.0;
			this.C1_BuyTarget3Val = Gann12.seed1ValueBuy + Gann12.step * 66.0;
			this.C1_BuyTarget4Val = Gann12.seed1ValueBuy + Gann12.step * 67.0;
			this.C1_BuyStopLossVal = Gann12.seed1ValueBuy;
			this.C2_BuyEntryVal = Gann12.seed1ValueBuy + Gann12.step * 78.0;
			this.C2_BuyTarget1Val = Gann12.seed1ValueBuy + Gann12.step * 79.0;
			this.C2_BuyTarget2Val = Gann12.seed1ValueBuy + Gann12.step * 89.0;
			this.C2_BuyTarget3Val = Gann12.seed1ValueBuy + Gann12.step * 92.0;
			this.C2_BuyTarget4Val = Gann12.seed1ValueBuy + Gann12.step * 100.0;
			this.C2_BuyStopLossVal = Gann12.seed1ValueBuy + Gann12.step * 66.0;
			this.C3_BuyEntryVal = Gann12.seed1ValueBuy + Gann12.step * 105.0;
			this.C3_BuyTarget1Val = Gann12.seed1ValueBuy + Gann12.step * 111.0;
			this.C3_BuyTarget2Val = Gann12.seed1ValueBuy + Gann12.step * 118.0;
			this.C3_BuyTarget3Val = Gann12.seed1ValueBuy + Gann12.step * 122.0;
			this.C3_BuyTarget4Val = Gann12.seed1ValueBuy + Gann12.step * 131.0;
			this.C3_BuyStopLossVal = Gann12.seed1ValueBuy + Gann12.step * 92.0;
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

		// Token: 0x0600032D RID: 813 RVA: 0x00067420 File Offset: 0x00065620
		private void sellCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.high - Gann12.step * 10.0;
			Gann12.seed1ValueSell = this.getSeed1Value(this._10thCellValue, "Sell");
			this.C1_SellEntryVal = Gann12.seed1ValueSell - Gann12.step * 27.0;
			this.C1_SellTarget1Val = Gann12.seed1ValueSell - Gann12.step * 53.0;
			this.C1_SellTarget2Val = Gann12.seed1ValueSell - Gann12.step * 56.0;
			this.C1_SellTarget3Val = Gann12.seed1ValueSell - Gann12.step * 66.0;
			this.C1_SellTarget4Val = Gann12.seed1ValueSell - Gann12.step * 67.0;
			this.C1_SellStopLossVal = Gann12.seed1ValueSell;
			this.C2_SellEntryVal = Gann12.seed1ValueSell - Gann12.step * 40.0;
			this.C2_SellTarget1Val = Gann12.seed1ValueSell - Gann12.step * 43.0;
			this.C2_SellTarget2Val = Gann12.seed1ValueSell - Gann12.step * 89.0;
			this.C2_SellTarget3Val = Gann12.seed1ValueSell - Gann12.step * 92.0;
			this.C2_SellTarget4Val = Gann12.seed1ValueSell - Gann12.step * 100.0;
			this.C2_SellStopLossVal = Gann12.seed1ValueSell - Gann12.step * 66.0;
			this.C3_SellEntryVal = Gann12.seed1ValueSell - Gann12.step * 105.0;
			this.C3_SellTarget1Val = Gann12.seed1ValueSell - Gann12.step * 111.0;
			this.C3_SellTarget2Val = Gann12.seed1ValueSell - Gann12.step * 118.0;
			this.C3_SellTarget3Val = Gann12.seed1ValueSell - Gann12.step * 122.0;
			this.C3_SellTarget4Val = Gann12.seed1ValueSell - Gann12.step * 131.0;
			this.C3_SellStopLossVal = Gann12.seed1ValueSell - Gann12.step * 92.0;
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

		// Token: 0x0600032E RID: 814 RVA: 0x000678C1 File Offset: 0x00065AC1
		[NullableContext(1)]
		private void buyDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann12_Chart("buy", Gann12.seed1ValueBuy, Gann12.step).Show();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x000678DC File Offset: 0x00065ADC
		[NullableContext(1)]
		private void sellDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann12_Chart("sell", Gann12.seed1ValueSell, Gann12.step).Show();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x000678F8 File Offset: 0x00065AF8
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

		// Token: 0x06000331 RID: 817 RVA: 0x00067978 File Offset: 0x00065B78
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

		// Token: 0x04000933 RID: 2355
		public static double High;

		// Token: 0x04000934 RID: 2356
		public static double Low;

		// Token: 0x04000935 RID: 2357
		public static double seed1ValueBuy;

		// Token: 0x04000936 RID: 2358
		public static double seed1ValueSell;

		// Token: 0x04000937 RID: 2359
		public static double seed1Value_GS9;

		// Token: 0x04000938 RID: 2360
		public static double seed1Value_mGS9;

		// Token: 0x04000939 RID: 2361
		public static double seed1Value_GS12;

		// Token: 0x0400093A RID: 2362
		public static double seed1Value_mGS12;

		// Token: 0x0400093B RID: 2363
		public static double step;

		// Token: 0x0400093C RID: 2364
		public double C1_BuyEntryVal;

		// Token: 0x0400093D RID: 2365
		public double C1_BuyTarget1Val;

		// Token: 0x0400093E RID: 2366
		public double C1_BuyTarget2Val;

		// Token: 0x0400093F RID: 2367
		public double C1_BuyTarget3Val;

		// Token: 0x04000940 RID: 2368
		public double C1_BuyTarget4Val;

		// Token: 0x04000941 RID: 2369
		public double C1_BuyStopLossVal;

		// Token: 0x04000942 RID: 2370
		public double C2_BuyEntryVal;

		// Token: 0x04000943 RID: 2371
		public double C2_BuyTarget1Val;

		// Token: 0x04000944 RID: 2372
		public double C2_BuyTarget2Val;

		// Token: 0x04000945 RID: 2373
		public double C2_BuyTarget3Val;

		// Token: 0x04000946 RID: 2374
		public double C2_BuyTarget4Val;

		// Token: 0x04000947 RID: 2375
		public double C2_BuyStopLossVal;

		// Token: 0x04000948 RID: 2376
		public double C3_BuyEntryVal;

		// Token: 0x04000949 RID: 2377
		public double C3_BuyTarget1Val;

		// Token: 0x0400094A RID: 2378
		public double C3_BuyTarget2Val;

		// Token: 0x0400094B RID: 2379
		public double C3_BuyTarget3Val;

		// Token: 0x0400094C RID: 2380
		public double C3_BuyTarget4Val;

		// Token: 0x0400094D RID: 2381
		public double C3_BuyStopLossVal;

		// Token: 0x0400094E RID: 2382
		public double C1_SellEntryVal;

		// Token: 0x0400094F RID: 2383
		public double C1_SellTarget1Val;

		// Token: 0x04000950 RID: 2384
		public double C1_SellTarget2Val;

		// Token: 0x04000951 RID: 2385
		public double C1_SellTarget3Val;

		// Token: 0x04000952 RID: 2386
		public double C1_SellTarget4Val;

		// Token: 0x04000953 RID: 2387
		public double C1_SellStopLossVal;

		// Token: 0x04000954 RID: 2388
		public double C2_SellEntryVal;

		// Token: 0x04000955 RID: 2389
		public double C2_SellTarget1Val;

		// Token: 0x04000956 RID: 2390
		public double C2_SellTarget2Val;

		// Token: 0x04000957 RID: 2391
		public double C2_SellTarget3Val;

		// Token: 0x04000958 RID: 2392
		public double C2_SellTarget4Val;

		// Token: 0x04000959 RID: 2393
		public double C2_SellStopLossVal;

		// Token: 0x0400095A RID: 2394
		public double C3_SellEntryVal;

		// Token: 0x0400095B RID: 2395
		public double C3_SellTarget1Val;

		// Token: 0x0400095C RID: 2396
		public double C3_SellTarget2Val;

		// Token: 0x0400095D RID: 2397
		public double C3_SellTarget3Val;

		// Token: 0x0400095E RID: 2398
		public double C3_SellTarget4Val;

		// Token: 0x0400095F RID: 2399
		public double C3_SellStopLossVal;

		// Token: 0x04000960 RID: 2400
		private double fact;

		// Token: 0x04000961 RID: 2401
		private double diff;

		// Token: 0x04000962 RID: 2402
		private double _10thCellValue;
	}
}
