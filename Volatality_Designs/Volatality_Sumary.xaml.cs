using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000022 RID: 34
	public partial class Volatality_Sumary : UserControl
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00018105 File Offset: 0x00016305
		// (set) Token: 0x06000189 RID: 393 RVA: 0x0001810C File Offset: 0x0001630C
		public static double BuyEntryValue1 { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00018114 File Offset: 0x00016314
		// (set) Token: 0x0600018B RID: 395 RVA: 0x0001811B File Offset: 0x0001631B
		public static double BuyEntryValue2 { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00018123 File Offset: 0x00016323
		// (set) Token: 0x0600018D RID: 397 RVA: 0x0001812A File Offset: 0x0001632A
		public static double BuyEntryValue3 { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00018132 File Offset: 0x00016332
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00018139 File Offset: 0x00016339
		public static double SellEntryValue1 { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00018141 File Offset: 0x00016341
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00018148 File Offset: 0x00016348
		public static double SellEntryValue2 { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00018150 File Offset: 0x00016350
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00018157 File Offset: 0x00016357
		public static double SellEntryValue3 { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0001815F File Offset: 0x0001635F
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00018166 File Offset: 0x00016366
		public static double OneSDBuyEntryValue1 { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0001816E File Offset: 0x0001636E
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00018175 File Offset: 0x00016375
		public static double OneSDBuyEntryValue2 { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0001817D File Offset: 0x0001637D
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00018184 File Offset: 0x00016384
		public static double OneSDBuyEntryValue3 { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0001818C File Offset: 0x0001638C
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00018193 File Offset: 0x00016393
		public static double OneSDSellEntryValue1 { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0001819B File Offset: 0x0001639B
		// (set) Token: 0x0600019D RID: 413 RVA: 0x000181A2 File Offset: 0x000163A2
		public static double OneSDSellEntryValue2 { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000181AA File Offset: 0x000163AA
		// (set) Token: 0x0600019F RID: 415 RVA: 0x000181B1 File Offset: 0x000163B1
		public static double OneSDSellEntryValue3 { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x000181B9 File Offset: 0x000163B9
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x000181C0 File Offset: 0x000163C0
		public static double LNBuyEntryValue1 { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x000181C8 File Offset: 0x000163C8
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x000181CF File Offset: 0x000163CF
		public static double LNBuyEntryValue2 { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000181D7 File Offset: 0x000163D7
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x000181DE File Offset: 0x000163DE
		public static double LNBuyEntryValue3 { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x000181E6 File Offset: 0x000163E6
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x000181ED File Offset: 0x000163ED
		public static double LNSellEntryValue1 { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000181F5 File Offset: 0x000163F5
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x000181FC File Offset: 0x000163FC
		public static double LNSellEntryValue2 { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00018204 File Offset: 0x00016404
		// (set) Token: 0x060001AB RID: 427 RVA: 0x0001820B File Offset: 0x0001640B
		public static double LNSellEntryValue3 { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00018213 File Offset: 0x00016413
		// (set) Token: 0x060001AD RID: 429 RVA: 0x0001821A File Offset: 0x0001641A
		public static double OHLCBuyEntryValue1 { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00018222 File Offset: 0x00016422
		// (set) Token: 0x060001AF RID: 431 RVA: 0x00018229 File Offset: 0x00016429
		public static double OHLCBuyEntryValue2 { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00018231 File Offset: 0x00016431
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x00018238 File Offset: 0x00016438
		public static double OHLCBuyEntryValue3 { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00018240 File Offset: 0x00016440
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00018247 File Offset: 0x00016447
		public static double OHLCSellEntryValue1 { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0001824F File Offset: 0x0001644F
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00018256 File Offset: 0x00016456
		public static double OHLCSellEntryValue2 { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0001825E File Offset: 0x0001645E
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00018265 File Offset: 0x00016465
		public static double OHLCSellEntryValue3 { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0001826D File Offset: 0x0001646D
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x00018274 File Offset: 0x00016474
		public static double DriftBuyEntryValue1 { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0001827C File Offset: 0x0001647C
		// (set) Token: 0x060001BB RID: 443 RVA: 0x00018283 File Offset: 0x00016483
		public static double DriftBuyEntryValue2 { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0001828B File Offset: 0x0001648B
		// (set) Token: 0x060001BD RID: 445 RVA: 0x00018292 File Offset: 0x00016492
		public static double DriftBuyEntryValue3 { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0001829A File Offset: 0x0001649A
		// (set) Token: 0x060001BF RID: 447 RVA: 0x000182A1 File Offset: 0x000164A1
		public static double DriftSellEntryValue1 { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x000182A9 File Offset: 0x000164A9
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x000182B0 File Offset: 0x000164B0
		public static double DriftSellEntryValue2 { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x000182B8 File Offset: 0x000164B8
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x000182BF File Offset: 0x000164BF
		public static double DriftSellEntryValue3 { get; set; }

		// Token: 0x060001C4 RID: 452 RVA: 0x000182C7 File Offset: 0x000164C7
		[NullableContext(1)]
		public Volatality_Sumary(double ltp, OneSD oneSD, Volatality_Scanner volatalityScanner, Volatality_LN volatalityLN, Volatality_OHLC volatalityOHLC, Volatality_Drift volatalityDrift)
		{
			this.InitializeComponent();
			this.OneSD_Sumary(oneSD, ltp);
			this.VolatalityScanner_Summary(volatalityScanner, ltp);
			this.VolatalityLN_Summar(volatalityLN, ltp);
			this.VolatalityOHLC_Summary(volatalityOHLC, ltp);
			this.VolatalityDrift_Summary(volatalityDrift, ltp);
			this.CreatePieChart();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00018308 File Offset: 0x00016508
		[NullableContext(1)]
		private void VolatalityDrift_Summary(Volatality_Drift volatalityDrift, double ltp)
		{
			if (ltp > Volatality_Sumary.DriftBuyEntryValue1)
			{
				this.Vol_Drift.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.DriftSellEntryValue1)
			{
				this.Vol_Drift.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.DriftBuyEntryValue2)
			{
				this.Vol_Drift.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.DriftSellEntryValue2)
			{
				this.Vol_Drift.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.DriftBuyEntryValue3)
			{
				this.Vol_Drift.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.DriftSellEntryValue3)
			{
				this.Vol_Drift.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.Vol_Drift.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00018420 File Offset: 0x00016620
		[NullableContext(1)]
		private void VolatalityOHLC_Summary(Volatality_OHLC volatalityOHLC, double ltp)
		{
			if (ltp > Volatality_Sumary.OHLCBuyEntryValue1)
			{
				this.Vol_OHLC.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OHLCSellEntryValue1)
			{
				this.Vol_OHLC.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.OHLCBuyEntryValue2)
			{
				this.Vol_OHLC.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OHLCSellEntryValue2)
			{
				this.Vol_OHLC.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.OHLCBuyEntryValue3)
			{
				this.Vol_OHLC.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OHLCSellEntryValue3)
			{
				this.Vol_OHLC.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.Vol_OHLC.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00018538 File Offset: 0x00016738
		[NullableContext(1)]
		private void VolatalityLN_Summar(Volatality_LN volatalityLN, double ltp)
		{
			if (ltp > Volatality_Sumary.LNBuyEntryValue1)
			{
				this.Vol_LN.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.LNSellEntryValue1)
			{
				this.Vol_LN.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.LNBuyEntryValue2)
			{
				this.Vol_LN.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.LNSellEntryValue2)
			{
				this.Vol_LN.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.LNBuyEntryValue3)
			{
				this.Vol_LN.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.LNSellEntryValue3)
			{
				this.Vol_LN.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.Vol_LN.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00018650 File Offset: 0x00016850
		[NullableContext(1)]
		private void VolatalityScanner_Summary(Volatality_Scanner volatalityScanner, double ltp)
		{
			if (ltp > Volatality_Sumary.BuyEntryValue1)
			{
				this.Vol_Analysis.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.SellEntryValue1)
			{
				this.Vol_Analysis.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.BuyEntryValue2)
			{
				this.Vol_Analysis.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.SellEntryValue2)
			{
				this.Vol_Analysis.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.BuyEntryValue3)
			{
				this.Vol_Analysis.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.SellEntryValue3)
			{
				this.Vol_Analysis.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.Vol_Analysis.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00018768 File Offset: 0x00016968
		[NullableContext(1)]
		private void OneSD_Sumary(OneSD oneSD, double ltp)
		{
			if (ltp > Volatality_Sumary.OneSDBuyEntryValue1)
			{
				this.OneSDSum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OneSDSellEntryValue1)
			{
				this.OneSDSum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.OneSDBuyEntryValue2)
			{
				this.OneSDSum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OneSDSellEntryValue2)
			{
				this.OneSDSum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > Volatality_Sumary.OneSDBuyEntryValue3)
			{
				this.OneSDSum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < Volatality_Sumary.OneSDSellEntryValue3)
			{
				this.OneSDSum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.OneSDSum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00018880 File Offset: 0x00016A80
		private void CreatePieChart()
		{
			PlotModel plotModel = new PlotModel
			{
				Title = "Buy/Sell/Neutral Pie Chart",
				TitlePadding = 20.0
			};
			PieSeries pieSeries = new PieSeries
			{
				StrokeThickness = 1.0,
				InsideLabelPosition = 0.3,
				AngleSpan = 360.0,
				StartAngle = 0.0,
				InsideLabelColor = OxyColors.Black,
				FontSize = 14.0
			};
			if (this.buy > 0)
			{
				pieSeries.Slices.Add(new PieSlice("Buy", (double)this.buy)
				{
					IsExploded = true,
					Fill = OxyColors.YellowGreen
				});
			}
			if (this.sell > 0)
			{
				pieSeries.Slices.Add(new PieSlice("Sell", (double)this.sell)
				{
					Fill = OxyColors.LightCoral
				});
			}
			if (this.neutral > 0)
			{
				pieSeries.Slices.Add(new PieSlice("Neutral", (double)this.neutral)
				{
					Fill = OxyColors.Gold
				});
			}
			plotModel.Series.Add(pieSeries);
			this.pieChartVol.Model = plotModel;
		}

		// Token: 0x0400037A RID: 890
		private int buy;

		// Token: 0x0400037B RID: 891
		private int sell;

		// Token: 0x0400037C RID: 892
		private int neutral;
	}
}
