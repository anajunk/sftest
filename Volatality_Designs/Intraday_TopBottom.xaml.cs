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

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001A RID: 26
	public partial class Intraday_TopBottom : UserControl
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0000E8C2 File Offset: 0x0000CAC2
		public Intraday_TopBottom()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000E8D0 File Offset: 0x0000CAD0
		public void Initialize_Variable()
		{
			this.clearData();
			int totalCount = Equtiy_Future.LTP_MONTH.Count;
			if (totalCount >= 11)
			{
				int skipCount = totalCount - 11;
				this._11LTP = Equtiy_Future.LTP_MONTH.Skip(skipCount).ToList<double>();
				this.intradayTopAndBottom(this._11LTP);
				this.symbolTop.Inlines.Add(Equtiy_Future.selectedSymbol + " Top");
				this.symbolBot.Inlines.Add(Equtiy_Future.selectedSymbol + " Bottom");
				this.Top1stC.Inlines.Add(this.Intraday_Top_List[0].ToString());
				this.Top3rdC.Inlines.Add(this.Intraday_Top_List[1].ToString());
				this.Top5thC.Inlines.Add(this.Intraday_Top_List[2].ToString());
				this.Top7thC.Inlines.Add(this.Intraday_Top_List[3].ToString());
				this.Top9thC.Inlines.Add(this.Intraday_Top_List[4].ToString());
				this.Top11thC.Inlines.Add(this.Intraday_Top_List[5].ToString());
				this.Top13thC.Inlines.Add(this.Intraday_Top_List[6].ToString());
				this.Top15thC.Inlines.Add(this.Intraday_Top_List[7].ToString());
				this.Top17thC.Inlines.Add(this.Intraday_Top_List[8].ToString());
				this.Bottom1stC.Inlines.Add(this.Intraday_Bottom_List[0].ToString());
				this.Bottom3rdC.Inlines.Add(this.Intraday_Bottom_List[1].ToString());
				this.Bottom5thC.Inlines.Add(this.Intraday_Bottom_List[2].ToString());
				this.Bottom7thC.Inlines.Add(this.Intraday_Bottom_List[3].ToString());
				this.Bottom9thC.Inlines.Add(this.Intraday_Bottom_List[4].ToString());
				this.Bottom11thC.Inlines.Add(this.Intraday_Bottom_List[5].ToString());
				this.Bottom13thC.Inlines.Add(this.Intraday_Bottom_List[6].ToString());
				this.Bottom15thC.Inlines.Add(this.Intraday_Bottom_List[7].ToString());
				this.Bottom17thC.Inlines.Add(this.Intraday_Bottom_List[8].ToString());
				return;
			}
			MessageBox.Show("Insufficient Data for Analysis." + Environment.NewLine + "Load Data first", "Data not present.");
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000EC04 File Offset: 0x0000CE04
		[NullableContext(1)]
		private void intradayTopAndBottom(List<double> _11daysPrice)
		{
			List<double> _10daysPrice = _11daysPrice.GetRange(1, 10);
			List<double> LN_list = new List<double>();
			for (int i = 0; i <= _10daysPrice.Count - 3; i++)
			{
				double _2daysLN = Math.Log(_10daysPrice[i + 1] / _10daysPrice[i]);
				LN_list.Add(_2daysLN);
			}
			double average = LN_list.Average();
			LN_list.Add(average);
			double dailyReturnAverage = LN_list.Average();
			double sum = LN_list.Sum((double v) => (v - dailyReturnAverage) * (v - dailyReturnAverage));
			double denominator = (double)LN_list.Count;
			double stdDevP = (denominator > 0.0) ? Math.Sqrt(sum / denominator) : -1.0;
			double sumOfStdDevPlusDailyReturn = stdDevP + dailyReturnAverage;
			if (sumOfStdDevPlusDailyReturn <= 0.001)
			{
				double temp = sumOfStdDevPlusDailyReturn * 10.0;
			}
			else if (sumOfStdDevPlusDailyReturn >= 0.01)
			{
				double temp = sumOfStdDevPlusDailyReturn / 3.0;
			}
			double basePrice = _10daysPrice[9];
			List<double> dailyReturnAverage_cycle_list = new List<double>();
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage);
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(3.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(5.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(7.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(9.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(11.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(13.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(15.0));
			dailyReturnAverage_cycle_list.Add(dailyReturnAverage * Math.Sqrt(17.0));
			List<double> stdDev_cycle_list = new List<double>();
			stdDev_cycle_list.Add(stdDevP);
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(3.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(5.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(7.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(9.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(11.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(13.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(15.0));
			stdDev_cycle_list.Add(stdDevP * Math.Sqrt(17.0));
			List<double> sumOfStdDevPlusDailyReturn_cycle_list = new List<double>();
			for (int j = 0; j <= dailyReturnAverage_cycle_list.Count - 1; j++)
			{
				double sumOfStdDevPlusDailyReturn_cycle = (dailyReturnAverage_cycle_list[j] + stdDev_cycle_list[j]) / 3.0;
				sumOfStdDevPlusDailyReturn_cycle_list.Add(sumOfStdDevPlusDailyReturn_cycle);
			}
			List<double> priceRange_cycle_list = new List<double>();
			for (int k = 0; k <= sumOfStdDevPlusDailyReturn_cycle_list.Count - 1; k++)
			{
				double priceRange_cycle = basePrice * sumOfStdDevPlusDailyReturn_cycle_list[k];
				priceRange_cycle_list.Add(priceRange_cycle);
			}
			this.Intraday_Top_List = new List<double>();
			this.Intraday_Bottom_List = new List<double>();
			for (int l = 0; l <= priceRange_cycle_list.Count - 1; l++)
			{
				double Intraday_Top_cycle = basePrice + priceRange_cycle_list[l];
				this.Intraday_Top_List.Add(Math.Round(Intraday_Top_cycle, 2));
			}
			for (int m = 0; m <= priceRange_cycle_list.Count - 1; m++)
			{
				double Intraday_Bottom_cycle = basePrice - priceRange_cycle_list[m];
				this.Intraday_Bottom_List.Add(Math.Round(Intraday_Bottom_cycle, 2));
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000EFF4 File Offset: 0x0000D1F4
		private void clearData()
		{
			this.symbolTop.Inlines.Clear();
			this.symbolBot.Inlines.Clear();
			this.Top1stC.Inlines.Clear();
			this.Bottom1stC.Inlines.Clear();
			this.Top3rdC.Inlines.Clear();
			this.Bottom3rdC.Inlines.Clear();
			this.Top5thC.Inlines.Clear();
			this.Bottom5thC.Inlines.Clear();
			this.Top7thC.Inlines.Clear();
			this.Bottom7thC.Inlines.Clear();
			this.Top9thC.Inlines.Clear();
			this.Bottom9thC.Inlines.Clear();
			this.Top11thC.Inlines.Clear();
			this.Bottom11thC.Inlines.Clear();
			this.Top13thC.Inlines.Clear();
			this.Bottom13thC.Inlines.Clear();
			this.Top15thC.Inlines.Clear();
			this.Bottom15thC.Inlines.Clear();
			this.Top17thC.Inlines.Clear();
			this.Bottom17thC.Inlines.Clear();
		}

		// Token: 0x040001BB RID: 443
		[Nullable(1)]
		private List<double> _11LTP;

		// Token: 0x040001BC RID: 444
		[Nullable(1)]
		private List<double> Intraday_Top_List;

		// Token: 0x040001BD RID: 445
		[Nullable(1)]
		private List<double> Intraday_Bottom_List;
	}
}
