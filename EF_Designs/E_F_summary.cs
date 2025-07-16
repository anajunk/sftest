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

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000041 RID: 65
	public class E_F_summary : UserControl, IComponentConnector
	{
		// Token: 0x0600031F RID: 799 RVA: 0x00066518 File Offset: 0x00064718
		[NullableContext(1)]
		public E_F_summary(double ltp, GAV gav, NC_Trend nc_trend, Gann9 gann9, Gann12 gann12, Gann_Hexagonal gannHex, Intraday_Tetra intraday_Tetra, Gann_Price gann_Price)
		{
			this.InitializeComponent();
			this.Gav_Summary(gav, ltp);
			this.NC_Trend_Summary(nc_trend, ltp);
			this.Gann9_Summary(gann9, ltp);
			this.Gann12_Summary(gann12, ltp);
			this.GannHex_Summary(gannHex, ltp);
			this.Intra_Tetra_Summary(intraday_Tetra, ltp);
			this.Gann_Price_Summary(gann_Price, ltp);
			this.CreatePieChart();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00066574 File Offset: 0x00064774
		[NullableContext(1)]
		private void Gann_Price_Summary(Gann_Price gann_Price, double ltp)
		{
			double buyEntry = gann_Price.InResistence1;
			double sellEntry = gann_Price.InSupport1;
			if (ltp > buyEntry)
			{
				this.gannPrice_Sum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.gannPrice_Sum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.gannPrice_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000665F8 File Offset: 0x000647F8
		[NullableContext(1)]
		private void Intra_Tetra_Summary(Intraday_Tetra intraday_Tetra, double ltp)
		{
			double buyEntry = intraday_Tetra.tetra1;
			double sellEntry = intraday_Tetra.Sup_tetra1;
			if (ltp > buyEntry)
			{
				this.intraTetra_Sum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.intraTetra_Sum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.intraTetra_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0006667C File Offset: 0x0006487C
		[NullableContext(1)]
		private void GannHex_Summary(Gann_Hexagonal gannHex, double ltp)
		{
			double buyEntry = double.Parse(gannHex.horizontalValues[0]);
			double buyEntry2 = double.Parse(gannHex.diagonalValues[0]);
			double buyEntry3 = double.Parse(gannHex.verticalValues[0]);
			double sellEntry = double.Parse(gannHex.horizontalValues1[0]);
			double sellEntry2 = double.Parse(gannHex.diagonalValues1[0]);
			double sellEntry3 = double.Parse(gannHex.diagonalValues1[0]);
			if (ltp > buyEntry)
			{
				this.GannHex_Sum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.GannHex_Sum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry2)
			{
				this.GannHex_Sum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry2)
			{
				this.GannHex_Sum.Text = "CSupport: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry3)
			{
				this.GannHex_Sum.Text = "Resistance: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry3)
			{
				this.GannHex_Sum.Text = "Support: Suggested Sell";
				this.sell++;
				return;
			}
			this.GannHex_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x000667F4 File Offset: 0x000649F4
		[NullableContext(1)]
		private void Gann12_Summary(Gann12 gann12, double ltp)
		{
			double buyEntry = gann12.C1_BuyEntryVal;
			double buyEntry2 = gann12.C2_BuyEntryVal;
			double buyEntry3 = gann12.C3_BuyEntryVal;
			double sellEntry = gann12.C1_SellEntryVal;
			double sellEntry2 = gann12.C2_SellEntryVal;
			double sellEntry3 = gann12.C3_SellEntryVal;
			if (ltp > buyEntry)
			{
				this.Gann12_Sum.Text = "Cycle 1: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.Gann12_Sum.Text = "Cycle 1: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry2)
			{
				this.Gann12_Sum.Text = "Cycle 2: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry2)
			{
				this.Gann12_Sum.Text = "Cycle 2: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry3)
			{
				this.Gann12_Sum.Text = "Cycle 3: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry3)
			{
				this.Gann12_Sum.Text = "Cycle 3: Suggested Sell";
				this.sell++;
				return;
			}
			this.Gann12_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00066928 File Offset: 0x00064B28
		[NullableContext(1)]
		private void Gann9_Summary(Gann9 gann9, double ltp)
		{
			double buyEntry = gann9.C1_BuyEntryVal;
			double buyEntry2 = gann9.C2_BuyEntryVal;
			double buyEntry3 = gann9.C3_BuyEntryVal;
			double sellEntry = gann9.C1_SellEntryVal;
			double sellEntry2 = gann9.C2_SellEntryVal;
			double sellEntry3 = gann9.C3_SellEntryVal;
			if (ltp > buyEntry)
			{
				this.Gann9_Sum.Text = "Cycle 1: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.Gann9_Sum.Text = "Cycle 1: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry2)
			{
				this.Gann9_Sum.Text = "Cycle 2: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry2)
			{
				this.Gann9_Sum.Text = "Cycle 2: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry3)
			{
				this.Gann9_Sum.Text = "Cycle 3: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry3)
			{
				this.Gann9_Sum.Text = "Cycle 3: Suggested Sell";
				this.sell++;
				return;
			}
			this.Gann9_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00066A5C File Offset: 0x00064C5C
		[NullableContext(1)]
		private void NC_Trend_Summary(NC_Trend nc_trend, double ltp)
		{
			double goldenMeanTop = nc_trend._1stCycle_GoldenMean_Top;
			double goldenMeanTop2 = nc_trend._2ndCycle_GoldenMean_Top;
			double goldenMeanTop3 = nc_trend._3rdCycle_GoldenMean_Top;
			double goldenMeanBottom = nc_trend._1stCycle_GoldenMean_Bottom;
			double goldenMeanBottom2 = nc_trend._2ndCycle_GoldenMean_Bottom;
			double goldenMeanBottom3 = nc_trend._3rdCycle_GoldenMean_Bottom;
			if (ltp > goldenMeanTop)
			{
				this.NC_Sum.Text = "Cycle 1: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < goldenMeanBottom)
			{
				this.NC_Sum.Text = "Cycle 1: Suggested Sell";
				this.buy++;
				return;
			}
			if (ltp > goldenMeanTop2)
			{
				this.NC_Sum.Text = "Cycle 2: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < goldenMeanBottom2)
			{
				this.NC_Sum.Text = "Cycle 2: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > goldenMeanTop3)
			{
				this.NC_Sum.Text = "Cycle 3: Suggested Buy";
				this.sell++;
				return;
			}
			if (ltp < goldenMeanBottom3)
			{
				this.NC_Sum.Text = "Cycle 3: Suggested Sell";
				this.sell++;
				return;
			}
			this.NC_Sum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00066B90 File Offset: 0x00064D90
		[NullableContext(1)]
		public void Gav_Summary(GAV gav, double ltp)
		{
			double buyEntry = gav.GAV_buy_C1;
			double buyEntry2 = gav.GAV_buy_C2;
			double buyEntry3 = gav.GAV_buy_C3;
			double sellEntry = gav.GAV_sell_C1;
			double sellEntry2 = gav.GAV_sell_C2;
			double sellEntry3 = gav.GAV_sell_C3;
			if (ltp > buyEntry)
			{
				this.GavSum.Text = "Cycle 1: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry)
			{
				this.GavSum.Text = "Cycle 1: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry2)
			{
				this.GavSum.Text = "Cycle 2: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry2)
			{
				this.GavSum.Text = "Cycle 2: Suggested Sell";
				this.sell++;
				return;
			}
			if (ltp > buyEntry3)
			{
				this.GavSum.Text = "Cycle 3: Suggested Buy";
				this.buy++;
				return;
			}
			if (ltp < sellEntry3)
			{
				this.GavSum.Text = "Cycle 3: Suggested Sell";
				this.sell++;
				return;
			}
			this.GavSum.Text = "Neutral";
			this.neutral++;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00066CC4 File Offset: 0x00064EC4
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
			this.pieChart.Model = plotModel;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00066DFC File Offset: 0x00064FFC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocater = new Uri("/New SF_IT;component/ef_designs/e&f_summary.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00066E2C File Offset: 0x0006502C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.13.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.GavSum = (TextBlock)target;
				return;
			case 2:
				this.NC_Sum = (TextBlock)target;
				return;
			case 3:
				this.Gann9_Sum = (TextBlock)target;
				return;
			case 4:
				this.Gann12_Sum = (TextBlock)target;
				return;
			case 5:
				this.GannHex_Sum = (TextBlock)target;
				return;
			case 6:
				this.intraTetra_Sum = (TextBlock)target;
				return;
			case 7:
				this.gannPrice_Sum = (TextBlock)target;
				return;
			case 8:
				this.pieChart = (PlotView)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000927 RID: 2343
		private int buy;

		// Token: 0x04000928 RID: 2344
		private int sell;

		// Token: 0x04000929 RID: 2345
		private int neutral;

		// Token: 0x0400092A RID: 2346
		internal TextBlock GavSum;

		// Token: 0x0400092B RID: 2347
		internal TextBlock NC_Sum;

		// Token: 0x0400092C RID: 2348
		internal TextBlock Gann9_Sum;

		// Token: 0x0400092D RID: 2349
		internal TextBlock Gann12_Sum;

		// Token: 0x0400092E RID: 2350
		internal TextBlock GannHex_Sum;

		// Token: 0x0400092F RID: 2351
		internal TextBlock intraTetra_Sum;

		// Token: 0x04000930 RID: 2352
		internal TextBlock gannPrice_Sum;

		// Token: 0x04000931 RID: 2353
		internal PlotView pieChart;

		// Token: 0x04000932 RID: 2354
		private bool _contentLoaded;
	}
}
