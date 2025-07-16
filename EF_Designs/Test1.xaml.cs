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
	// Token: 0x0200004C RID: 76
	public partial class Test1 : UserControl
	{
		// Token: 0x0600037C RID: 892 RVA: 0x00077675 File Offset: 0x00075875
		public Test1()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00077684 File Offset: 0x00075884
		public void InitializeVariable()
		{
			this.fact = (Equtiy_Future.LIVE_DATA.high - Equtiy_Future.LIVE_DATA.low) / Equtiy_Future.LIVE_DATA.high;
			this.diff = this.fact * Equtiy_Future.LIVE_DATA.high;
			Test1.step = this.diff / 144.0;
			this._10thCellValue = 0.0;
			Test1.seed1ValueBuy = 0.0;
			Test1.seed1ValueSell = 0.0;
			this.buyCalculation();
			this.sellCalculation();
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0007771C File Offset: 0x0007591C
		private void buyCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.low + Test1.step * 10.0;
			Test1.seed1ValueBuy = this.getSeed1Value(this._10thCellValue, "Buy");
			this.C1_BuyEntryVal = Test1.seed1ValueBuy + Test1.step * 27.0;
			this.C1_BuyTarget1Val = Test1.seed1ValueBuy + Test1.step * 53.0;
			this.C1_BuyTarget2Val = Test1.seed1ValueBuy + Test1.step * 56.0;
			this.C1_BuyTarget3Val = Test1.seed1ValueBuy + Test1.step * 66.0;
			this.C1_BuyTarget4Val = Test1.seed1ValueBuy + Test1.step * 67.0;
			this.C1_BuyStopLossVal = Test1.seed1ValueBuy;
			this.C2_BuyEntryVal = Test1.seed1ValueBuy + Test1.step * 78.0;
			this.C2_BuyTarget1Val = Test1.seed1ValueBuy + Test1.step * 79.0;
			this.C2_BuyTarget2Val = Test1.seed1ValueBuy + Test1.step * 89.0;
			this.C2_BuyTarget3Val = Test1.seed1ValueBuy + Test1.step * 92.0;
			this.C2_BuyTarget4Val = Test1.seed1ValueBuy + Test1.step * 100.0;
			this.C2_BuyStopLossVal = Test1.seed1ValueBuy + Test1.step * 66.0;
			this.C3_BuyEntryVal = Test1.seed1ValueBuy + Test1.step * 105.0;
			this.C3_BuyTarget1Val = Test1.seed1ValueBuy + Test1.step * 111.0;
			this.C3_BuyTarget2Val = Test1.seed1ValueBuy + Test1.step * 118.0;
			this.C3_BuyTarget3Val = Test1.seed1ValueBuy + Test1.step * 122.0;
			this.C3_BuyTarget4Val = Test1.seed1ValueBuy + Test1.step * 131.0;
			this.C3_BuyStopLossVal = Test1.seed1ValueBuy + Test1.step * 92.0;
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

		// Token: 0x0600037F RID: 895 RVA: 0x00077BC0 File Offset: 0x00075DC0
		private void sellCalculation()
		{
			this._10thCellValue = Equtiy_Future.LIVE_DATA.high - Test1.step * 10.0;
			Test1.seed1ValueSell = this.getSeed1Value(this._10thCellValue, "Sell");
			this.C1_SellEntryVal = Test1.seed1ValueSell - Test1.step * 27.0;
			this.C1_SellTarget1Val = Test1.seed1ValueSell - Test1.step * 53.0;
			this.C1_SellTarget2Val = Test1.seed1ValueSell - Test1.step * 56.0;
			this.C1_SellTarget3Val = Test1.seed1ValueSell - Test1.step * 66.0;
			this.C1_SellTarget4Val = Test1.seed1ValueSell - Test1.step * 67.0;
			this.C1_SellStopLossVal = Test1.seed1ValueSell;
			this.C2_SellEntryVal = Test1.seed1ValueSell - Test1.step * 40.0;
			this.C2_SellTarget1Val = Test1.seed1ValueSell - Test1.step * 43.0;
			this.C2_SellTarget2Val = Test1.seed1ValueSell - Test1.step * 89.0;
			this.C2_SellTarget3Val = Test1.seed1ValueSell - Test1.step * 92.0;
			this.C2_SellTarget4Val = Test1.seed1ValueSell - Test1.step * 100.0;
			this.C2_SellStopLossVal = Test1.seed1ValueSell - Test1.step * 66.0;
			this.C3_SellEntryVal = Test1.seed1ValueSell - Test1.step * 105.0;
			this.C3_SellTarget1Val = Test1.seed1ValueSell - Test1.step * 111.0;
			this.C3_SellTarget2Val = Test1.seed1ValueSell - Test1.step * 118.0;
			this.C3_SellTarget3Val = Test1.seed1ValueSell - Test1.step * 122.0;
			this.C3_SellTarget4Val = Test1.seed1ValueSell - Test1.step * 131.0;
			this.C3_SellStopLossVal = Test1.seed1ValueSell - Test1.step * 92.0;
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

		// Token: 0x06000380 RID: 896 RVA: 0x00078061 File Offset: 0x00076261
		[NullableContext(1)]
		private void buyDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann12_Chart("buy", Test1.seed1ValueBuy, Test1.step).Show();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0007807C File Offset: 0x0007627C
		[NullableContext(1)]
		private void sellDecisionBtn(object sender, RoutedEventArgs e)
		{
			new Gann12_Chart("sell", Test1.seed1ValueSell, Test1.step).Show();
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00078098 File Offset: 0x00076298
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

		// Token: 0x04000EB6 RID: 3766
		public static double High;

		// Token: 0x04000EB7 RID: 3767
		public static double Low;

		// Token: 0x04000EB8 RID: 3768
		public static double seed1ValueBuy;

		// Token: 0x04000EB9 RID: 3769
		public static double seed1ValueSell;

		// Token: 0x04000EBA RID: 3770
		public static double seed1Value_GS9;

		// Token: 0x04000EBB RID: 3771
		public static double seed1Value_mGS9;

		// Token: 0x04000EBC RID: 3772
		public static double seed1Value_GS12;

		// Token: 0x04000EBD RID: 3773
		public static double seed1Value_mGS12;

		// Token: 0x04000EBE RID: 3774
		public static double step;

		// Token: 0x04000EBF RID: 3775
		public double C1_BuyEntryVal;

		// Token: 0x04000EC0 RID: 3776
		public double C1_BuyTarget1Val;

		// Token: 0x04000EC1 RID: 3777
		public double C1_BuyTarget2Val;

		// Token: 0x04000EC2 RID: 3778
		public double C1_BuyTarget3Val;

		// Token: 0x04000EC3 RID: 3779
		public double C1_BuyTarget4Val;

		// Token: 0x04000EC4 RID: 3780
		public double C1_BuyStopLossVal;

		// Token: 0x04000EC5 RID: 3781
		public double C2_BuyEntryVal;

		// Token: 0x04000EC6 RID: 3782
		public double C2_BuyTarget1Val;

		// Token: 0x04000EC7 RID: 3783
		public double C2_BuyTarget2Val;

		// Token: 0x04000EC8 RID: 3784
		public double C2_BuyTarget3Val;

		// Token: 0x04000EC9 RID: 3785
		public double C2_BuyTarget4Val;

		// Token: 0x04000ECA RID: 3786
		public double C2_BuyStopLossVal;

		// Token: 0x04000ECB RID: 3787
		public double C3_BuyEntryVal;

		// Token: 0x04000ECC RID: 3788
		public double C3_BuyTarget1Val;

		// Token: 0x04000ECD RID: 3789
		public double C3_BuyTarget2Val;

		// Token: 0x04000ECE RID: 3790
		public double C3_BuyTarget3Val;

		// Token: 0x04000ECF RID: 3791
		public double C3_BuyTarget4Val;

		// Token: 0x04000ED0 RID: 3792
		public double C3_BuyStopLossVal;

		// Token: 0x04000ED1 RID: 3793
		public double C1_SellEntryVal;

		// Token: 0x04000ED2 RID: 3794
		public double C1_SellTarget1Val;

		// Token: 0x04000ED3 RID: 3795
		public double C1_SellTarget2Val;

		// Token: 0x04000ED4 RID: 3796
		public double C1_SellTarget3Val;

		// Token: 0x04000ED5 RID: 3797
		public double C1_SellTarget4Val;

		// Token: 0x04000ED6 RID: 3798
		public double C1_SellStopLossVal;

		// Token: 0x04000ED7 RID: 3799
		public double C2_SellEntryVal;

		// Token: 0x04000ED8 RID: 3800
		public double C2_SellTarget1Val;

		// Token: 0x04000ED9 RID: 3801
		public double C2_SellTarget2Val;

		// Token: 0x04000EDA RID: 3802
		public double C2_SellTarget3Val;

		// Token: 0x04000EDB RID: 3803
		public double C2_SellTarget4Val;

		// Token: 0x04000EDC RID: 3804
		public double C2_SellStopLossVal;

		// Token: 0x04000EDD RID: 3805
		public double C3_SellEntryVal;

		// Token: 0x04000EDE RID: 3806
		public double C3_SellTarget1Val;

		// Token: 0x04000EDF RID: 3807
		public double C3_SellTarget2Val;

		// Token: 0x04000EE0 RID: 3808
		public double C3_SellTarget3Val;

		// Token: 0x04000EE1 RID: 3809
		public double C3_SellTarget4Val;

		// Token: 0x04000EE2 RID: 3810
		public double C3_SellStopLossVal;

		// Token: 0x04000EE3 RID: 3811
		private double fact;

		// Token: 0x04000EE4 RID: 3812
		private double diff;

		// Token: 0x04000EE5 RID: 3813
		private double _10thCellValue;
	}
}
