using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace New_SF_IT.chartWindow
{
	// Token: 0x02000051 RID: 81
	public partial class Gann9_Chart : Window
	{
		// Token: 0x060003C9 RID: 969 RVA: 0x0007E9DA File Offset: 0x0007CBDA
		[NullableContext(1)]
		public Gann9_Chart(string action, double seed, double stepvalue)
		{
			this.InitializeComponent();
			this.actionValue = action;
			this.seed1Value = seed;
			this.step = stepvalue;
			this.displayTable();
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0007EA04 File Offset: 0x0007CC04
		public void displayTable()
		{
			if (this.actionValue.Equals("buy"))
			{
				this.decision.Text = "Buy Decision Chart:";
				this.gs9T_1.Content = Math.Round(this.seed1Value + this.step * 1.0, 2).ToString();
				this.gs9T_2.Content = Math.Round(this.seed1Value + this.step * 2.0, 2).ToString();
				this.gs9T_3.Content = Math.Round(this.seed1Value + this.step * 3.0, 2).ToString();
				this.gs9T_4.Content = Math.Round(this.seed1Value + this.step * 4.0, 2).ToString();
				this.gs9T_5.Content = Math.Round(this.seed1Value + this.step * 5.0, 2).ToString();
				this.gs9T_6.Content = Math.Round(this.seed1Value + this.step * 6.0, 2).ToString();
				this.gs9T_7.Content = Math.Round(this.seed1Value + this.step * 7.0, 2).ToString();
				this.gs9T_8.Content = Math.Round(this.seed1Value + this.step * 8.0, 2).ToString();
				this.gs9T_9.Content = Math.Round(this.seed1Value + this.step * 9.0, 2).ToString();
				this.gs9T_10.Content = Math.Round(this.seed1Value + this.step * 10.0, 2).ToString();
				this.gs9T_11.Content = Math.Round(this.seed1Value + this.step * 11.0, 2).ToString();
				this.gs9T_12.Content = Math.Round(this.seed1Value + this.step * 12.0, 2).ToString();
				this.gs9T_13.Content = Math.Round(this.seed1Value + this.step * 13.0, 2).ToString();
				this.gs9T_14.Content = Math.Round(this.seed1Value + this.step * 14.0, 2).ToString();
				this.gs9T_15.Content = Math.Round(this.seed1Value + this.step * 15.0, 2).ToString();
				this.gs9T_16.Content = Math.Round(this.seed1Value + this.step * 16.0, 2).ToString();
				this.gs9T_17.Content = Math.Round(this.seed1Value + this.step * 17.0, 2).ToString();
				this.gs9T_18.Content = Math.Round(this.seed1Value + this.step * 18.0, 2).ToString();
				this.gs9T_19.Content = Math.Round(this.seed1Value + this.step * 19.0, 2).ToString();
				this.gs9T_20.Content = Math.Round(this.seed1Value + this.step * 20.0, 2).ToString();
				this.gs9T_21.Content = Math.Round(this.seed1Value + this.step * 21.0, 2).ToString();
				this.gs9T_22.Content = Math.Round(this.seed1Value + this.step * 22.0, 2).ToString();
				this.gs9T_23.Content = Math.Round(this.seed1Value + this.step * 23.0, 2).ToString();
				this.gs9T_24.Content = Math.Round(this.seed1Value + this.step * 24.0, 2).ToString();
				this.gs9T_25.Content = Math.Round(this.seed1Value + this.step * 25.0, 2).ToString();
				this.gs9T_26.Content = Math.Round(this.seed1Value + this.step * 26.0, 2).ToString();
				this.gs9T_27.Content = Math.Round(this.seed1Value + this.step * 27.0, 2).ToString();
				this.gs9T_28.Content = Math.Round(this.seed1Value + this.step * 28.0, 2).ToString();
				this.gs9T_29.Content = Math.Round(this.seed1Value + this.step * 29.0, 2).ToString();
				this.gs9T_30.Content = Math.Round(this.seed1Value + this.step * 30.0, 2).ToString();
				this.gs9T_31.Content = Math.Round(this.seed1Value + this.step * 31.0, 2).ToString();
				this.gs9T_32.Content = Math.Round(this.seed1Value + this.step * 32.0, 2).ToString();
				this.gs9T_33.Content = Math.Round(this.seed1Value + this.step * 33.0, 2).ToString();
				this.gs9T_34.Content = Math.Round(this.seed1Value + this.step * 34.0, 2).ToString();
				this.gs9T_35.Content = Math.Round(this.seed1Value + this.step * 35.0, 2).ToString();
				this.gs9T_36.Content = Math.Round(this.seed1Value + this.step * 36.0, 2).ToString();
				this.gs9T_37.Content = Math.Round(this.seed1Value + this.step * 37.0, 2).ToString();
				this.gs9T_38.Content = Math.Round(this.seed1Value + this.step * 38.0, 2).ToString();
				this.gs9T_39.Content = Math.Round(this.seed1Value + this.step * 39.0, 2).ToString();
				this.gs9T_40.Content = Math.Round(this.seed1Value + this.step * 40.0, 2).ToString();
				this.gs9T_41.Content = Math.Round(this.seed1Value + this.step * 41.0, 2).ToString();
				this.gs9T_42.Content = Math.Round(this.seed1Value + this.step * 42.0, 2).ToString();
				this.gs9T_43.Content = Math.Round(this.seed1Value + this.step * 43.0, 2).ToString();
				this.gs9T_44.Content = Math.Round(this.seed1Value + this.step * 44.0, 2).ToString();
				this.gs9T_45.Content = Math.Round(this.seed1Value + this.step * 45.0, 2).ToString();
				this.gs9T_46.Content = Math.Round(this.seed1Value + this.step * 46.0, 2).ToString();
				this.gs9T_47.Content = Math.Round(this.seed1Value + this.step * 47.0, 2).ToString();
				this.gs9T_48.Content = Math.Round(this.seed1Value + this.step * 48.0, 2).ToString();
				this.gs9T_49.Content = Math.Round(this.seed1Value + this.step * 49.0, 2).ToString();
				this.gs9T_50.Content = Math.Round(this.seed1Value + this.step * 50.0, 2).ToString();
				this.gs9T_51.Content = Math.Round(this.seed1Value + this.step * 51.0, 2).ToString();
				this.gs9T_52.Content = Math.Round(this.seed1Value + this.step * 52.0, 2).ToString();
				this.gs9T_53.Content = Math.Round(this.seed1Value + this.step * 53.0, 2).ToString();
				this.gs9T_54.Content = Math.Round(this.seed1Value + this.step * 54.0, 2).ToString();
				this.gs9T_55.Content = Math.Round(this.seed1Value + this.step * 55.0, 2).ToString();
				this.gs9T_56.Content = Math.Round(this.seed1Value + this.step * 56.0, 2).ToString();
				this.gs9T_57.Content = Math.Round(this.seed1Value + this.step * 57.0, 2).ToString();
				this.gs9T_58.Content = Math.Round(this.seed1Value + this.step * 58.0, 2).ToString();
				this.gs9T_59.Content = Math.Round(this.seed1Value + this.step * 59.0, 2).ToString();
				this.gs9T_60.Content = Math.Round(this.seed1Value + this.step * 60.0, 2).ToString();
				this.gs9T_61.Content = Math.Round(this.seed1Value + this.step * 61.0, 2).ToString();
				this.gs9T_62.Content = Math.Round(this.seed1Value + this.step * 62.0, 2).ToString();
				this.gs9T_63.Content = Math.Round(this.seed1Value + this.step * 63.0, 2).ToString();
				this.gs9T_64.Content = Math.Round(this.seed1Value + this.step * 64.0, 2).ToString();
				this.gs9T_65.Content = Math.Round(this.seed1Value + this.step * 65.0, 2).ToString();
				this.gs9T_66.Content = Math.Round(this.seed1Value + this.step * 66.0, 2).ToString();
				this.gs9T_67.Content = Math.Round(this.seed1Value + this.step * 67.0, 2).ToString();
				this.gs9T_68.Content = Math.Round(this.seed1Value + this.step * 68.0, 2).ToString();
				this.gs9T_69.Content = Math.Round(this.seed1Value + this.step * 69.0, 2).ToString();
				this.gs9T_70.Content = Math.Round(this.seed1Value + this.step * 70.0, 2).ToString();
				this.gs9T_71.Content = Math.Round(this.seed1Value + this.step * 71.0, 2).ToString();
				this.gs9T_72.Content = Math.Round(this.seed1Value + this.step * 72.0, 2).ToString();
				this.gs9T_73.Content = Math.Round(this.seed1Value + this.step * 73.0, 2).ToString();
				this.gs9T_74.Content = Math.Round(this.seed1Value + this.step * 74.0, 2).ToString();
				this.gs9T_75.Content = Math.Round(this.seed1Value + this.step * 75.0, 2).ToString();
				this.gs9T_76.Content = Math.Round(this.seed1Value + this.step * 76.0, 2).ToString();
				this.gs9T_77.Content = Math.Round(this.seed1Value + this.step * 77.0, 2).ToString();
				this.gs9T_78.Content = Math.Round(this.seed1Value + this.step * 78.0, 2).ToString();
				this.gs9T_79.Content = Math.Round(this.seed1Value + this.step * 79.0, 2).ToString();
				this.gs9T_80.Content = Math.Round(this.seed1Value + this.step * 80.0, 2).ToString();
				this.gs9T_81.Content = Math.Round(this.seed1Value + this.step * 81.0, 2).ToString();
				return;
			}
			if (this.actionValue.Equals("sell"))
			{
				this.decision.Text = "Sell Decision Chart:";
				this.gs9T_1.Content = Math.Round(this.seed1Value - this.step * 1.0, 2).ToString();
				this.gs9T_2.Content = Math.Round(this.seed1Value - this.step * 2.0, 2).ToString();
				this.gs9T_3.Content = Math.Round(this.seed1Value - this.step * 3.0, 2).ToString();
				this.gs9T_4.Content = Math.Round(this.seed1Value - this.step * 4.0, 2).ToString();
				this.gs9T_5.Content = Math.Round(this.seed1Value - this.step * 5.0, 2).ToString();
				this.gs9T_6.Content = Math.Round(this.seed1Value - this.step * 6.0, 2).ToString();
				this.gs9T_7.Content = Math.Round(this.seed1Value - this.step * 7.0, 2).ToString();
				this.gs9T_8.Content = Math.Round(this.seed1Value - this.step * 8.0, 2).ToString();
				this.gs9T_9.Content = Math.Round(this.seed1Value - this.step * 9.0, 2).ToString();
				this.gs9T_10.Content = Math.Round(this.seed1Value - this.step * 10.0, 2).ToString();
				this.gs9T_11.Content = Math.Round(this.seed1Value - this.step * 11.0, 2).ToString();
				this.gs9T_12.Content = Math.Round(this.seed1Value - this.step * 12.0, 2).ToString();
				this.gs9T_13.Content = Math.Round(this.seed1Value - this.step * 13.0, 2).ToString();
				this.gs9T_14.Content = Math.Round(this.seed1Value - this.step * 14.0, 2).ToString();
				this.gs9T_15.Content = Math.Round(this.seed1Value - this.step * 15.0, 2).ToString();
				this.gs9T_16.Content = Math.Round(this.seed1Value - this.step * 16.0, 2).ToString();
				this.gs9T_17.Content = Math.Round(this.seed1Value - this.step * 17.0, 2).ToString();
				this.gs9T_18.Content = Math.Round(this.seed1Value - this.step * 18.0, 2).ToString();
				this.gs9T_19.Content = Math.Round(this.seed1Value - this.step * 19.0, 2).ToString();
				this.gs9T_20.Content = Math.Round(this.seed1Value - this.step * 20.0, 2).ToString();
				this.gs9T_21.Content = Math.Round(this.seed1Value - this.step * 21.0, 2).ToString();
				this.gs9T_22.Content = Math.Round(this.seed1Value - this.step * 22.0, 2).ToString();
				this.gs9T_23.Content = Math.Round(this.seed1Value - this.step * 23.0, 2).ToString();
				this.gs9T_24.Content = Math.Round(this.seed1Value - this.step * 24.0, 2).ToString();
				this.gs9T_25.Content = Math.Round(this.seed1Value - this.step * 25.0, 2).ToString();
				this.gs9T_26.Content = Math.Round(this.seed1Value - this.step * 26.0, 2).ToString();
				this.gs9T_27.Content = Math.Round(this.seed1Value - this.step * 27.0, 2).ToString();
				this.gs9T_28.Content = Math.Round(this.seed1Value - this.step * 28.0, 2).ToString();
				this.gs9T_29.Content = Math.Round(this.seed1Value - this.step * 29.0, 2).ToString();
				this.gs9T_30.Content = Math.Round(this.seed1Value - this.step * 30.0, 2).ToString();
				this.gs9T_31.Content = Math.Round(this.seed1Value - this.step * 31.0, 2).ToString();
				this.gs9T_32.Content = Math.Round(this.seed1Value - this.step * 32.0, 2).ToString();
				this.gs9T_33.Content = Math.Round(this.seed1Value - this.step * 33.0, 2).ToString();
				this.gs9T_34.Content = Math.Round(this.seed1Value - this.step * 34.0, 2).ToString();
				this.gs9T_35.Content = Math.Round(this.seed1Value - this.step * 35.0, 2).ToString();
				this.gs9T_36.Content = Math.Round(this.seed1Value - this.step * 36.0, 2).ToString();
				this.gs9T_37.Content = Math.Round(this.seed1Value - this.step * 37.0, 2).ToString();
				this.gs9T_38.Content = Math.Round(this.seed1Value - this.step * 38.0, 2).ToString();
				this.gs9T_39.Content = Math.Round(this.seed1Value - this.step * 39.0, 2).ToString();
				this.gs9T_40.Content = Math.Round(this.seed1Value - this.step * 40.0, 2).ToString();
				this.gs9T_41.Content = Math.Round(this.seed1Value - this.step * 41.0, 2).ToString();
				this.gs9T_42.Content = Math.Round(this.seed1Value - this.step * 42.0, 2).ToString();
				this.gs9T_43.Content = Math.Round(this.seed1Value - this.step * 43.0, 2).ToString();
				this.gs9T_44.Content = Math.Round(this.seed1Value - this.step * 44.0, 2).ToString();
				this.gs9T_45.Content = Math.Round(this.seed1Value - this.step * 45.0, 2).ToString();
				this.gs9T_46.Content = Math.Round(this.seed1Value - this.step * 46.0, 2).ToString();
				this.gs9T_47.Content = Math.Round(this.seed1Value - this.step * 47.0, 2).ToString();
				this.gs9T_48.Content = Math.Round(this.seed1Value - this.step * 48.0, 2).ToString();
				this.gs9T_49.Content = Math.Round(this.seed1Value - this.step * 49.0, 2).ToString();
				this.gs9T_50.Content = Math.Round(this.seed1Value - this.step * 50.0, 2).ToString();
				this.gs9T_51.Content = Math.Round(this.seed1Value - this.step * 51.0, 2).ToString();
				this.gs9T_52.Content = Math.Round(this.seed1Value - this.step * 52.0, 2).ToString();
				this.gs9T_53.Content = Math.Round(this.seed1Value - this.step * 53.0, 2).ToString();
				this.gs9T_54.Content = Math.Round(this.seed1Value - this.step * 54.0, 2).ToString();
				this.gs9T_55.Content = Math.Round(this.seed1Value - this.step * 55.0, 2).ToString();
				this.gs9T_56.Content = Math.Round(this.seed1Value - this.step * 56.0, 2).ToString();
				this.gs9T_57.Content = Math.Round(this.seed1Value - this.step * 57.0, 2).ToString();
				this.gs9T_58.Content = Math.Round(this.seed1Value - this.step * 58.0, 2).ToString();
				this.gs9T_59.Content = Math.Round(this.seed1Value - this.step * 59.0, 2).ToString();
				this.gs9T_60.Content = Math.Round(this.seed1Value - this.step * 60.0, 2).ToString();
				this.gs9T_61.Content = Math.Round(this.seed1Value - this.step * 61.0, 2).ToString();
				this.gs9T_62.Content = Math.Round(this.seed1Value - this.step * 62.0, 2).ToString();
				this.gs9T_63.Content = Math.Round(this.seed1Value - this.step * 63.0, 2).ToString();
				this.gs9T_64.Content = Math.Round(this.seed1Value - this.step * 64.0, 2).ToString();
				this.gs9T_65.Content = Math.Round(this.seed1Value - this.step * 65.0, 2).ToString();
				this.gs9T_66.Content = Math.Round(this.seed1Value - this.step * 66.0, 2).ToString();
				this.gs9T_67.Content = Math.Round(this.seed1Value - this.step * 67.0, 2).ToString();
				this.gs9T_68.Content = Math.Round(this.seed1Value - this.step * 68.0, 2).ToString();
				this.gs9T_69.Content = Math.Round(this.seed1Value - this.step * 69.0, 2).ToString();
				this.gs9T_70.Content = Math.Round(this.seed1Value - this.step * 70.0, 2).ToString();
				this.gs9T_71.Content = Math.Round(this.seed1Value - this.step * 71.0, 2).ToString();
				this.gs9T_72.Content = Math.Round(this.seed1Value - this.step * 72.0, 2).ToString();
				this.gs9T_73.Content = Math.Round(this.seed1Value - this.step * 73.0, 2).ToString();
				this.gs9T_74.Content = Math.Round(this.seed1Value - this.step * 74.0, 2).ToString();
				this.gs9T_75.Content = Math.Round(this.seed1Value - this.step * 75.0, 2).ToString();
				this.gs9T_76.Content = Math.Round(this.seed1Value - this.step * 76.0, 2).ToString();
				this.gs9T_77.Content = Math.Round(this.seed1Value - this.step * 77.0, 2).ToString();
				this.gs9T_78.Content = Math.Round(this.seed1Value - this.step * 78.0, 2).ToString();
				this.gs9T_79.Content = Math.Round(this.seed1Value - this.step * 79.0, 2).ToString();
				this.gs9T_80.Content = Math.Round(this.seed1Value - this.step * 80.0, 2).ToString();
				this.gs9T_81.Content = Math.Round(this.seed1Value - this.step * 81.0, 2).ToString();
			}
		}

		// Token: 0x04000FB7 RID: 4023
		[Nullable(1)]
		private string actionValue;

		// Token: 0x04000FB8 RID: 4024
		private double seed1Value;

		// Token: 0x04000FB9 RID: 4025
		private double step;
	}
}
