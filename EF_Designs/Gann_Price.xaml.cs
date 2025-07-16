using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000045 RID: 69
	public partial class Gann_Price : UserControl
	{
		// Token: 0x06000346 RID: 838 RVA: 0x0006B283 File Offset: 0x00069483
		public Gann_Price()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0006B294 File Offset: 0x00069494
		public void Initialize_Variable()
		{
			this.Clear();
			if (Equtiy_Future.Items == "Intraday")
			{
				if (Equtiy_Future.LIVE_DATA != null)
				{
					this.Open = Equtiy_Future.LIVE_DATA.open;
				}
				double degree = (Math.Sqrt(this.Open) * 180.0 - 225.0) % 360.0;
				if (degree < 90.0 && degree > 30.0)
				{
					this.Degree = degree / 2.0;
				}
				else if (degree > 90.0 && degree < 180.0)
				{
					this.Degree = degree / 3.0;
				}
				else if (degree > 180.0)
				{
					this.Degree = degree / 5.0;
				}
				else
				{
					this.Degree = degree;
				}
				this.InResistence1 = Math.Pow(Math.Sqrt(this.Open) + this.Degree / 180.0, 2.0);
				this.buyTarget1.Inlines.Add(this.InResistence1.ToString("0.00"));
				this.InResistence2 = Math.Pow(Math.Sqrt(this.InResistence1) + this.Degree / 180.0, 2.0);
				this.buyTarget2.Inlines.Add(this.InResistence2.ToString("0.00"));
				this.InResistence3 = Math.Pow(Math.Sqrt(this.InResistence2) + this.Degree / 180.0, 2.0);
				this.buyTarget3.Inlines.Add(this.InResistence3.ToString("0.00"));
				this.InResistence4 = Math.Pow(Math.Sqrt(this.InResistence3) + this.Degree / 180.0, 2.0);
				this.buyTarget4.Inlines.Add(this.InResistence4.ToString("0.00"));
				this.InResistence5 = Math.Pow(Math.Sqrt(this.InResistence4) + this.Degree / 180.0, 2.0);
				this.buyTarget5.Inlines.Add(this.InResistence5.ToString("0.00"));
				this.InResistence6 = Math.Pow(Math.Sqrt(this.InResistence5) + this.Degree / 180.0, 2.0);
				this.buyTarget6.Inlines.Add(this.InResistence6.ToString("0.00"));
				this.InSupport1 = Math.Pow(Math.Sqrt(this.Open) - this.Degree / 180.0, 2.0);
				this.sellTarget1.Inlines.Add(this.InSupport1.ToString("0.00"));
				this.InSupport2 = Math.Pow(Math.Sqrt(this.InSupport1) - this.Degree / 180.0, 2.0);
				this.sellTarget2.Inlines.Add(this.InSupport2.ToString("0.00"));
				this.InSupport3 = Math.Pow(Math.Sqrt(this.InSupport2) - this.Degree / 180.0, 2.0);
				this.sellTarget3.Inlines.Add(this.InSupport3.ToString("0.00"));
				this.InSupport4 = Math.Pow(Math.Sqrt(this.InSupport3) - this.Degree / 180.0, 2.0);
				this.sellTarget4.Inlines.Add(this.InSupport4.ToString("0.00"));
				this.InSupport5 = Math.Pow(Math.Sqrt(this.InSupport4) - this.Degree / 180.0, 2.0);
				this.sellTarget5.Inlines.Add(this.InSupport5.ToString("0.00"));
				this.InSupport6 = Math.Pow(Math.Sqrt(this.InSupport5) - this.Degree / 180.0, 2.0);
				this.sellTarget6.Inlines.Add(this.InSupport6.ToString("0.00"));
				return;
			}
			double Days = (double)Equtiy_Future.NoOfHoldDays;
			if (Days < 15.0)
			{
				this.No_Days = Days / 30.0;
			}
			else if (Days > 15.0 && Days < 45.0)
			{
				this.No_Days = Days / 60.0;
			}
			else if (Days > 45.0 && Days < 75.0)
			{
				this.No_Days = Days / 90.0;
			}
			else
			{
				this.No_Days = Days / 365.0;
			}
			if (Equtiy_Future.LIVE_DATA != null)
			{
				this.Open = Equtiy_Future.LIVE_DATA.open;
			}
			double degree2 = (Math.Sqrt(this.Open) * 180.0 - 225.0) % 360.0;
			if (degree2 < 90.0 && degree2 > 30.0)
			{
				this.Degree = degree2 / 2.0;
			}
			else if (degree2 > 90.0 && degree2 < 180.0)
			{
				this.Degree = degree2 / 3.0;
			}
			else if (degree2 > 180.0)
			{
				this.Degree = degree2 / 5.0;
			}
			this.Resistence1 = Math.Pow(Math.Sqrt(this.Open) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget1.Inlines.Add(this.Resistence1.ToString("0.00"));
			this.Resistence2 = Math.Pow(Math.Sqrt(this.Resistence1) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget2.Inlines.Add(this.Resistence2.ToString("0.00"));
			this.Resistence3 = Math.Pow(Math.Sqrt(this.Resistence2) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget3.Inlines.Add(this.Resistence3.ToString("0.00"));
			this.Resistence4 = Math.Pow(Math.Sqrt(this.Resistence3) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget4.Inlines.Add(this.Resistence4.ToString("0.00"));
			this.Resistence5 = Math.Pow(Math.Sqrt(this.Resistence4) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget5.Inlines.Add(this.Resistence5.ToString("0.00"));
			this.Resistence6 = Math.Pow(Math.Sqrt(this.Resistence5) + (this.Degree / 180.0 + this.No_Days), 2.0);
			this.buyTarget6.Inlines.Add(this.Resistence6.ToString("0.00"));
			this.Support1 = Math.Pow(Math.Sqrt(this.Open) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget1.Inlines.Add(this.Support1.ToString("0.00"));
			this.Support2 = Math.Pow(Math.Sqrt(this.Support1) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget2.Inlines.Add(this.Support2.ToString("0.00"));
			this.Support3 = Math.Pow(Math.Sqrt(this.Support2) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget3.Inlines.Add(this.Support3.ToString("0.00"));
			this.Support4 = Math.Pow(Math.Sqrt(this.Support3) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget4.Inlines.Add(this.Support4.ToString("0.00"));
			this.Support5 = Math.Pow(Math.Sqrt(this.Support4) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget5.Inlines.Add(this.Support5.ToString("0.00"));
			this.Support6 = Math.Pow(Math.Sqrt(this.Support5) - (this.Degree / 180.0 + this.No_Days), 2.0);
			this.sellTarget6.Inlines.Add(this.Support6.ToString("0.00"));
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0006BC90 File Offset: 0x00069E90
		private void Clear()
		{
			this.buyTarget1.Inlines.Clear();
			this.buyTarget2.Inlines.Clear();
			this.buyTarget3.Inlines.Clear();
			this.buyTarget4.Inlines.Clear();
			this.buyTarget5.Inlines.Clear();
			this.buyTarget6.Inlines.Clear();
			this.sellTarget1.Inlines.Clear();
			this.sellTarget2.Inlines.Clear();
			this.sellTarget3.Inlines.Clear();
			this.sellTarget4.Inlines.Clear();
			this.sellTarget5.Inlines.Clear();
			this.sellTarget6.Inlines.Clear();
		}

		// Token: 0x04000B2C RID: 2860
		public double Open;

		// Token: 0x04000B2D RID: 2861
		public double Degree;

		// Token: 0x04000B2E RID: 2862
		public double Resistence1;

		// Token: 0x04000B2F RID: 2863
		public double Resistence2;

		// Token: 0x04000B30 RID: 2864
		public double Resistence3;

		// Token: 0x04000B31 RID: 2865
		public double Resistence4;

		// Token: 0x04000B32 RID: 2866
		public double Resistence5;

		// Token: 0x04000B33 RID: 2867
		public double Resistence6;

		// Token: 0x04000B34 RID: 2868
		public double Support1;

		// Token: 0x04000B35 RID: 2869
		public double Support2;

		// Token: 0x04000B36 RID: 2870
		public double Support3;

		// Token: 0x04000B37 RID: 2871
		public double Support4;

		// Token: 0x04000B38 RID: 2872
		public double Support5;

		// Token: 0x04000B39 RID: 2873
		public double Support6;

		// Token: 0x04000B3A RID: 2874
		public double InResistence1;

		// Token: 0x04000B3B RID: 2875
		public double InResistence2;

		// Token: 0x04000B3C RID: 2876
		public double InResistence3;

		// Token: 0x04000B3D RID: 2877
		public double InResistence4;

		// Token: 0x04000B3E RID: 2878
		public double InResistence5;

		// Token: 0x04000B3F RID: 2879
		public double InResistence6;

		// Token: 0x04000B40 RID: 2880
		public double InSupport1;

		// Token: 0x04000B41 RID: 2881
		public double InSupport2;

		// Token: 0x04000B42 RID: 2882
		public double InSupport3;

		// Token: 0x04000B43 RID: 2883
		public double InSupport4;

		// Token: 0x04000B44 RID: 2884
		public double InSupport5;

		// Token: 0x04000B45 RID: 2885
		public double InSupport6;

		// Token: 0x04000B46 RID: 2886
		private double No_Days;
	}
}
