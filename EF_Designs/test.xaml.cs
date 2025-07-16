using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x0200004B RID: 75
	public partial class test : UserControl
	{
		// Token: 0x06000374 RID: 884 RVA: 0x000767D4 File Offset: 0x000749D4
		public test()
		{
			this.InitializeComponent();
			this.fact = (Equtiy_Future.LIVE_DATA.high - Equtiy_Future.LIVE_DATA.low) / Equtiy_Future.LIVE_DATA.high;
			this.diff = this.fact * Equtiy_Future.LIVE_DATA.high;
			test.step = this.diff / 81.0;
			this._10thCellValue = 0.0;
			test.seed1Value = 0.0;
			this.buyCalculation();
			this.sellCalculation();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00076868 File Offset: 0x00074A68
		private void buyCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.low + test.step * 10.0;
			test.seed1Value = this.getSeed1Value(this._10thCellValue, "Buy");
			this.C1_BuyEntryVal = test.seed1Value + test.step * 25.0;
			this.C1_BuyTarget1Val = test.seed1Value + test.step * 28.0;
			this.C1_BuyTarget2Val = test.seed1Value + test.step * 31.0;
			this.C1_BuyTarget3Val = test.seed1Value + test.step * 34.0;
			this.C1_BuyTarget4Val = test.seed1Value + test.step * 37.0;
			this.C1_BuyStopLossVal = test.seed1Value;
			this.C2_BuyEntryVal = test.seed1Value + test.step * 40.0;
			this.C2_BuyTarget1Val = test.seed1Value + test.step * 43.0;
			this.C2_BuyTarget2Val = test.seed1Value + test.step * 46.0;
			this.C2_BuyTarget3Val = test.seed1Value + test.step * 49.0;
			this.C2_BuyTarget4Val = test.seed1Value + test.step * 57.0;
			this.C2_BuyStopLossVal = test.seed1Value + test.step * 34.0;
			this.C3_BuyEntryVal = test.seed1Value + test.step * 61.0;
			this.C3_BuyTarget1Val = test.seed1Value + test.step * 65.0;
			this.C3_BuyTarget2Val = test.seed1Value + test.step * 73.0;
			this.C3_BuyTarget3Val = test.seed1Value + test.step * 77.0;
			this.C3_BuyTarget4Val = test.seed1Value + test.step * 81.0;
			this.C3_BuyStopLossVal = test.seed1Value + test.step * 49.0;
			this.C1_BuyEntry.Inlines.Add(Math.Round(this.C1_BuyEntryVal, 2).ToString());
			this.C1_BuyTarget1.Inlines.Add(Math.Round(this.C1_BuyTarget1Val, 2).ToString());
			this.C1_BuyTarget2.Inlines.Add(Math.Round(this.C1_BuyTarget2Val, 2).ToString());
			this.C1_BuyTarget3.Inlines.Add(Math.Round(this.C1_BuyTarget3Val, 2).ToString());
			this.C1_BuyTarget3.Inlines.Add(Math.Round(this.C1_BuyTarget4Val, 2).ToString());
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

		// Token: 0x06000376 RID: 886 RVA: 0x00076D0C File Offset: 0x00074F0C
		private void sellCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.high - test.step * 10.0;
			test.seed1Value = this.getSeed1Value(this._10thCellValue, "Sell");
			this.C1_SellEntryVal = test.seed1Value - test.step * 25.0;
			this.C1_SellTarget1Val = test.seed1Value - test.step * 28.0;
			this.C1_SellTarget2Val = test.seed1Value - test.step * 31.0;
			this.C1_SellTarget3Val = test.seed1Value - test.step * 34.0;
			this.C1_SellTarget4Val = test.seed1Value - test.step * 37.0;
			this.C1_SellStopLossVal = test.seed1Value;
			this.C2_SellEntryVal = test.seed1Value - test.step * 40.0;
			this.C2_SellTarget1Val = test.seed1Value - test.step * 43.0;
			this.C2_SellTarget2Val = test.seed1Value - test.step * 46.0;
			this.C2_SellTarget3Val = test.seed1Value - test.step * 49.0;
			this.C2_SellTarget4Val = test.seed1Value - test.step * 57.0;
			this.C2_SellStopLossVal = test.seed1Value - test.step * 34.0;
			this.C3_SellEntryVal = test.seed1Value - test.step * 61.0;
			this.C3_SellTarget1Val = test.seed1Value - test.step * 65.0;
			this.C3_SellTarget2Val = test.seed1Value - test.step * 73.0;
			this.C3_SellTarget3Val = test.seed1Value - test.step * 77.0;
			this.C3_SellTarget4Val = test.seed1Value - test.step * 81.0;
			this.C3_SellStopLossVal = test.seed1Value - test.step * 49.0;
			this.C1_SellEntry.Inlines.Add(Math.Round(this.C1_SellEntryVal, 2).ToString());
			this.C1_SellTarget1.Inlines.Add(Math.Round(this.C1_SellTarget1Val, 2).ToString());
			this.C1_SellTarget2.Inlines.Add(Math.Round(this.C1_SellTarget2Val, 2).ToString());
			this.C1_SellTarget3.Inlines.Add(Math.Round(this.C1_SellTarget3Val, 2).ToString());
			this.C1_SellTarget3.Inlines.Add(Math.Round(this.C1_SellTarget4Val, 2).ToString());
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

		// Token: 0x06000377 RID: 887 RVA: 0x000771AD File Offset: 0x000753AD
		[NullableContext(1)]
		private void buyDecisionBtn(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000771AF File Offset: 0x000753AF
		[NullableContext(1)]
		private void sellDecisionBtn(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000771B4 File Offset: 0x000753B4
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

		// Token: 0x04000E4E RID: 3662
		public static double High;

		// Token: 0x04000E4F RID: 3663
		public static double Low;

		// Token: 0x04000E50 RID: 3664
		public static double seed1Value;

		// Token: 0x04000E51 RID: 3665
		public static double seed1Value_GS9;

		// Token: 0x04000E52 RID: 3666
		public static double seed1Value_mGS9;

		// Token: 0x04000E53 RID: 3667
		public static double seed1Value_GS12;

		// Token: 0x04000E54 RID: 3668
		public static double seed1Value_mGS12;

		// Token: 0x04000E55 RID: 3669
		public static double step;

		// Token: 0x04000E56 RID: 3670
		public double C1_BuyEntryVal;

		// Token: 0x04000E57 RID: 3671
		public double C1_BuyTarget1Val;

		// Token: 0x04000E58 RID: 3672
		public double C1_BuyTarget2Val;

		// Token: 0x04000E59 RID: 3673
		public double C1_BuyTarget3Val;

		// Token: 0x04000E5A RID: 3674
		public double C1_BuyTarget4Val;

		// Token: 0x04000E5B RID: 3675
		public double C1_BuyStopLossVal;

		// Token: 0x04000E5C RID: 3676
		public double C2_BuyEntryVal;

		// Token: 0x04000E5D RID: 3677
		public double C2_BuyTarget1Val;

		// Token: 0x04000E5E RID: 3678
		public double C2_BuyTarget2Val;

		// Token: 0x04000E5F RID: 3679
		public double C2_BuyTarget3Val;

		// Token: 0x04000E60 RID: 3680
		public double C2_BuyTarget4Val;

		// Token: 0x04000E61 RID: 3681
		public double C2_BuyStopLossVal;

		// Token: 0x04000E62 RID: 3682
		public double C3_BuyEntryVal;

		// Token: 0x04000E63 RID: 3683
		public double C3_BuyTarget1Val;

		// Token: 0x04000E64 RID: 3684
		public double C3_BuyTarget2Val;

		// Token: 0x04000E65 RID: 3685
		public double C3_BuyTarget3Val;

		// Token: 0x04000E66 RID: 3686
		public double C3_BuyTarget4Val;

		// Token: 0x04000E67 RID: 3687
		public double C3_BuyStopLossVal;

		// Token: 0x04000E68 RID: 3688
		public double C1_SellEntryVal;

		// Token: 0x04000E69 RID: 3689
		public double C1_SellTarget1Val;

		// Token: 0x04000E6A RID: 3690
		public double C1_SellTarget2Val;

		// Token: 0x04000E6B RID: 3691
		public double C1_SellTarget3Val;

		// Token: 0x04000E6C RID: 3692
		public double C1_SellTarget4Val;

		// Token: 0x04000E6D RID: 3693
		public double C1_SellStopLossVal;

		// Token: 0x04000E6E RID: 3694
		public double C2_SellEntryVal;

		// Token: 0x04000E6F RID: 3695
		public double C2_SellTarget1Val;

		// Token: 0x04000E70 RID: 3696
		public double C2_SellTarget2Val;

		// Token: 0x04000E71 RID: 3697
		public double C2_SellTarget3Val;

		// Token: 0x04000E72 RID: 3698
		public double C2_SellTarget4Val;

		// Token: 0x04000E73 RID: 3699
		public double C2_SellStopLossVal;

		// Token: 0x04000E74 RID: 3700
		public double C3_SellEntryVal;

		// Token: 0x04000E75 RID: 3701
		public double C3_SellTarget1Val;

		// Token: 0x04000E76 RID: 3702
		public double C3_SellTarget2Val;

		// Token: 0x04000E77 RID: 3703
		public double C3_SellTarget3Val;

		// Token: 0x04000E78 RID: 3704
		public double C3_SellTarget4Val;

		// Token: 0x04000E79 RID: 3705
		public double C3_SellStopLossVal;

		// Token: 0x04000E7A RID: 3706
		private double fact;

		// Token: 0x04000E7B RID: 3707
		private double diff;

		// Token: 0x04000E7C RID: 3708
		private double _10thCellValue;
	}
}
