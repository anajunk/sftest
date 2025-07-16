using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000046 RID: 70
	public partial class Gann_Vib : UserControl
	{
		// Token: 0x0600034B RID: 843 RVA: 0x0006BED2 File Offset: 0x0006A0D2
		public Gann_Vib()
		{
			this.InitializeComponent();
			this.clearAll();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0006BEE8 File Offset: 0x0006A0E8
		private void clearAll()
		{
			this.uptarget1.Inlines.Clear();
			this.uptarget2.Inlines.Clear();
			this.uptarget3.Inlines.Clear();
			this.uptarget4.Inlines.Clear();
			this.uptarget5.Inlines.Clear();
			this.uptarget6.Inlines.Clear();
			this.uptarget7.Inlines.Clear();
			this.uptarget8.Inlines.Clear();
			this.uptarget9.Inlines.Clear();
			this.uptarget10.Inlines.Clear();
			this.uptarget11.Inlines.Clear();
			this.uptarget12.Inlines.Clear();
			this.uptarget13.Inlines.Clear();
			this.uptarget14.Inlines.Clear();
			this.uptarget15.Inlines.Clear();
			this.uptarget16.Inlines.Clear();
			this.uptarget17.Inlines.Clear();
			this.uptarget18.Inlines.Clear();
			this.uptarget19.Inlines.Clear();
			this.uptarget20.Inlines.Clear();
			this.uptarget21.Inlines.Clear();
			this.uptarget22.Inlines.Clear();
			this.uptarget23.Inlines.Clear();
			this.uptarget24.Inlines.Clear();
			this.downtarget1.Inlines.Clear();
			this.downtarget2.Inlines.Clear();
			this.downtarget3.Inlines.Clear();
			this.downtarget4.Inlines.Clear();
			this.downtarget5.Inlines.Clear();
			this.downtarget6.Inlines.Clear();
			this.downtarget7.Inlines.Clear();
			this.downtarget8.Inlines.Clear();
			this.downtarget9.Inlines.Clear();
			this.downtarget10.Inlines.Clear();
			this.downtarget11.Inlines.Clear();
			this.downtarget12.Inlines.Clear();
			this.downtarget13.Inlines.Clear();
			this.downtarget14.Inlines.Clear();
			this.downtarget15.Inlines.Clear();
			this.downtarget16.Inlines.Clear();
			this.downtarget17.Inlines.Clear();
			this.downtarget18.Inlines.Clear();
			this.downtarget19.Inlines.Clear();
			this.downtarget20.Inlines.Clear();
			this.downtarget21.Inlines.Clear();
			this.downtarget22.Inlines.Clear();
			this.downtarget23.Inlines.Clear();
			this.downtarget24.Inlines.Clear();
			this.downvibno1.Inlines.Clear();
			this.downvibno2.Inlines.Clear();
			this.downvibno3.Inlines.Clear();
			this.downvibno4.Inlines.Clear();
			this.downvibno5.Inlines.Clear();
			this.downvibno6.Inlines.Clear();
			this.downvibno7.Inlines.Clear();
			this.downvibno8.Inlines.Clear();
			this.downvibno9.Inlines.Clear();
			this.downvibno10.Inlines.Clear();
			this.downvibno11.Inlines.Clear();
			this.downvibno12.Inlines.Clear();
			this.downvibno13.Inlines.Clear();
			this.downvibno14.Inlines.Clear();
			this.downvibno15.Inlines.Clear();
			this.downvibno16.Inlines.Clear();
			this.downvibno17.Inlines.Clear();
			this.downvibno18.Inlines.Clear();
			this.downvibno19.Inlines.Clear();
			this.downvibno20.Inlines.Clear();
			this.downvibno21.Inlines.Clear();
			this.downvibno22.Inlines.Clear();
			this.downvibno23.Inlines.Clear();
			this.downvibno24.Inlines.Clear();
			this.upvibno1.Inlines.Clear();
			this.upvibno2.Inlines.Clear();
			this.upvibno3.Inlines.Clear();
			this.upvibno4.Inlines.Clear();
			this.upvibno5.Inlines.Clear();
			this.upvibno6.Inlines.Clear();
			this.upvibno7.Inlines.Clear();
			this.upvibno8.Inlines.Clear();
			this.upvibno9.Inlines.Clear();
			this.upvibno10.Inlines.Clear();
			this.upvibno11.Inlines.Clear();
			this.upvibno12.Inlines.Clear();
			this.upvibno13.Inlines.Clear();
			this.upvibno14.Inlines.Clear();
			this.upvibno15.Inlines.Clear();
			this.upvibno16.Inlines.Clear();
			this.upvibno17.Inlines.Clear();
			this.upvibno18.Inlines.Clear();
			this.upvibno19.Inlines.Clear();
			this.upvibno20.Inlines.Clear();
			this.upvibno21.Inlines.Clear();
			this.upvibno22.Inlines.Clear();
			this.upvibno23.Inlines.Clear();
			this.upvibno24.Inlines.Clear();
			Paragraph[] upvibnos = new Paragraph[]
			{
				this.upvibno1,
				this.upvibno2,
				this.upvibno3,
				this.upvibno4,
				this.upvibno5,
				this.upvibno6,
				this.upvibno7,
				this.upvibno8,
				this.upvibno9,
				this.upvibno10,
				this.upvibno11,
				this.upvibno12,
				this.upvibno13,
				this.upvibno14,
				this.upvibno15,
				this.upvibno16,
				this.upvibno17,
				this.upvibno18,
				this.upvibno19,
				this.upvibno20,
				this.upvibno21,
				this.upvibno22,
				this.upvibno23,
				this.upvibno24
			};
			Paragraph[] downvibnos = new Paragraph[]
			{
				this.downvibno1,
				this.downvibno2,
				this.downvibno3,
				this.downvibno4,
				this.downvibno5,
				this.downvibno6,
				this.downvibno7,
				this.downvibno8,
				this.downvibno9,
				this.downvibno10,
				this.downvibno11,
				this.downvibno12,
				this.downvibno13,
				this.downvibno14,
				this.downvibno15,
				this.downvibno16,
				this.downvibno17,
				this.downvibno18,
				this.downvibno19,
				this.downvibno20,
				this.downvibno21,
				this.downvibno22,
				this.downvibno23,
				this.downvibno24
			};
			Paragraph[] array = upvibnos;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Background = Brushes.White;
			}
			array = downvibnos;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Background = Brushes.White;
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0006C710 File Offset: 0x0006A910
		public void Initialize_Variable()
		{
			this.clearAll();
			try
			{
				this.High1 = Equtiy_Future.PrevHigh;
				this.Low1 = Equtiy_Future.PrevLow;
				this.high.Content = this.High1.ToString();
				this.low.Content = this.Low1.ToString();
				Paragraph[] degreeParagraphs = new Paragraph[8];
				double[] results = new double[8];
				double[] vibno = new double[8];
				for (int i = 0; i < 8; i++)
				{
					degreeParagraphs[i] = (base.FindName("degree" + (i + 1).ToString()) as Paragraph);
					if (degreeParagraphs[i] != null)
					{
						Run run = degreeParagraphs[i].Inlines.FirstInline as Run;
						double degreeValue;
						if (run != null && double.TryParse(run.Text, out degreeValue))
						{
							results[i] = Math.Round(Math.Pow(Math.Sqrt(this.High1) - degreeValue / 180.0, 2.0), 2);
							vibno[i] = this.macro(results[i]);
						}
					}
				}
				this.uptarget1.Inlines.Add(results[0].ToString());
				this.uptarget2.Inlines.Add(results[1].ToString());
				this.uptarget3.Inlines.Add(results[2].ToString());
				this.uptarget4.Inlines.Add(results[3].ToString());
				this.uptarget5.Inlines.Add(results[4].ToString());
				this.uptarget6.Inlines.Add(results[5].ToString());
				this.uptarget7.Inlines.Add(results[6].ToString());
				this.uptarget8.Inlines.Add(results[7].ToString());
				double[] results2 = new double[8];
				double[] vibno2 = new double[8];
				double upcycle2 = results[7];
				for (int j = 0; j < 8; j++)
				{
					degreeParagraphs[j] = (base.FindName("degree" + (j + 1).ToString()) as Paragraph);
					if (degreeParagraphs[j] != null)
					{
						Run run2 = degreeParagraphs[j].Inlines.FirstInline as Run;
						double degreeValue2;
						if (run2 != null && double.TryParse(run2.Text, out degreeValue2))
						{
							results2[j] = Math.Round(Math.Pow(Math.Sqrt(upcycle2) - degreeValue2 / 180.0, 2.0), 2);
							vibno2[j] = this.macro(results2[j]);
						}
					}
				}
				this.uptarget9.Inlines.Add(results2[0].ToString());
				this.uptarget10.Inlines.Add(results2[1].ToString());
				this.uptarget11.Inlines.Add(results2[2].ToString());
				this.uptarget12.Inlines.Add(results2[3].ToString());
				this.uptarget13.Inlines.Add(results2[4].ToString());
				this.uptarget14.Inlines.Add(results2[5].ToString());
				this.uptarget15.Inlines.Add(results2[6].ToString());
				this.uptarget16.Inlines.Add(results2[7].ToString());
				double[] results3 = new double[8];
				double[] vibno3 = new double[8];
				double upcycle3 = results2[7];
				for (int k = 0; k < 8; k++)
				{
					degreeParagraphs[k] = (base.FindName("degree" + (k + 1).ToString()) as Paragraph);
					if (degreeParagraphs[k] != null)
					{
						Run run3 = degreeParagraphs[k].Inlines.FirstInline as Run;
						double degreeValue3;
						if (run3 != null && double.TryParse(run3.Text, out degreeValue3))
						{
							results3[k] = Math.Round(Math.Pow(Math.Sqrt(upcycle3) - degreeValue3 / 180.0, 2.0), 2);
							vibno3[k] = this.macro(results3[k]);
						}
					}
				}
				this.uptarget17.Inlines.Add(results3[0].ToString());
				this.uptarget18.Inlines.Add(results3[1].ToString());
				this.uptarget19.Inlines.Add(results3[2].ToString());
				this.uptarget20.Inlines.Add(results3[3].ToString());
				this.uptarget21.Inlines.Add(results3[4].ToString());
				this.uptarget22.Inlines.Add(results3[5].ToString());
				this.uptarget23.Inlines.Add(results3[6].ToString());
				this.uptarget24.Inlines.Add(results3[7].ToString());
				double[] results4 = new double[8];
				double[] vibno4 = new double[8];
				for (int l = 0; l < 8; l++)
				{
					degreeParagraphs[l] = (base.FindName("degree" + (l + 1).ToString()) as Paragraph);
					if (degreeParagraphs[l] != null)
					{
						Run run4 = degreeParagraphs[l].Inlines.FirstInline as Run;
						double degreeValue4;
						if (run4 != null && double.TryParse(run4.Text, out degreeValue4))
						{
							results4[l] = Math.Round(Math.Pow(Math.Sqrt(this.Low1) + degreeValue4 / 180.0, 2.0), 2);
							vibno4[l] = this.macro(results4[l]);
						}
					}
				}
				this.downtarget1.Inlines.Add(results4[0].ToString());
				this.downtarget2.Inlines.Add(results4[1].ToString());
				this.downtarget3.Inlines.Add(results4[2].ToString());
				this.downtarget4.Inlines.Add(results4[3].ToString());
				this.downtarget5.Inlines.Add(results4[4].ToString());
				this.downtarget6.Inlines.Add(results4[5].ToString());
				this.downtarget7.Inlines.Add(results4[6].ToString());
				this.downtarget8.Inlines.Add(results4[7].ToString());
				double[] results5 = new double[8];
				double[] vibno5 = new double[8];
				double downcycle2 = results4[7];
				for (int m = 0; m < 8; m++)
				{
					degreeParagraphs[m] = (base.FindName("degree" + (m + 1).ToString()) as Paragraph);
					if (degreeParagraphs[m] != null)
					{
						Run run5 = degreeParagraphs[m].Inlines.FirstInline as Run;
						double degreeValue5;
						if (run5 != null && double.TryParse(run5.Text, out degreeValue5))
						{
							results5[m] = Math.Round(Math.Pow(Math.Sqrt(downcycle2) + degreeValue5 / 180.0, 2.0), 2);
							vibno5[m] = this.macro(results5[m]);
						}
					}
				}
				this.downtarget9.Inlines.Add(results5[0].ToString());
				this.downtarget10.Inlines.Add(results5[1].ToString());
				this.downtarget11.Inlines.Add(results5[2].ToString());
				this.downtarget12.Inlines.Add(results5[3].ToString());
				this.downtarget13.Inlines.Add(results5[4].ToString());
				this.downtarget14.Inlines.Add(results5[5].ToString());
				this.downtarget15.Inlines.Add(results5[6].ToString());
				this.downtarget16.Inlines.Add(results5[7].ToString());
				double[] results6 = new double[8];
				double[] vibno6 = new double[8];
				double downcycle3 = results5[7];
				for (int n = 0; n < 8; n++)
				{
					degreeParagraphs[n] = (base.FindName("degree" + (n + 1).ToString()) as Paragraph);
					if (degreeParagraphs[n] != null)
					{
						Run run6 = degreeParagraphs[n].Inlines.FirstInline as Run;
						double degreeValue6;
						if (run6 != null && double.TryParse(run6.Text, out degreeValue6))
						{
							results6[n] = Math.Round(Math.Pow(Math.Sqrt(downcycle3) + degreeValue6 / 180.0, 2.0), 2);
							vibno6[n] = this.macro(results6[n]);
						}
					}
				}
				this.downtarget17.Inlines.Add(results6[0].ToString());
				this.downtarget18.Inlines.Add(results6[1].ToString());
				this.downtarget19.Inlines.Add(results6[2].ToString());
				this.downtarget20.Inlines.Add(results6[3].ToString());
				this.downtarget21.Inlines.Add(results6[4].ToString());
				this.downtarget22.Inlines.Add(results6[5].ToString());
				this.downtarget23.Inlines.Add(results6[6].ToString());
				this.downtarget24.Inlines.Add(results6[7].ToString());
				double[] Finalupvibno = new double[24];
				for (int i2 = 0; i2 < 8; i2++)
				{
					Finalupvibno[i2] = vibno[i2];
				}
				for (int i3 = 0; i3 < 8; i3++)
				{
					Finalupvibno[i3 + 8] = vibno2[i3];
				}
				for (int i4 = 0; i4 < 8; i4++)
				{
					Finalupvibno[i4 + 16] = vibno3[i4];
				}
				this.upvibno1.Inlines.Add(Finalupvibno[0].ToString());
				this.upvibno2.Inlines.Add(Finalupvibno[1].ToString());
				this.upvibno3.Inlines.Add(Finalupvibno[2].ToString());
				this.upvibno4.Inlines.Add(Finalupvibno[3].ToString());
				this.upvibno5.Inlines.Add(Finalupvibno[4].ToString());
				this.upvibno6.Inlines.Add(Finalupvibno[5].ToString());
				this.upvibno7.Inlines.Add(Finalupvibno[6].ToString());
				this.upvibno8.Inlines.Add(Finalupvibno[7].ToString());
				this.upvibno9.Inlines.Add(Finalupvibno[8].ToString());
				this.upvibno10.Inlines.Add(Finalupvibno[9].ToString());
				this.upvibno11.Inlines.Add(Finalupvibno[10].ToString());
				this.upvibno12.Inlines.Add(Finalupvibno[11].ToString());
				this.upvibno13.Inlines.Add(Finalupvibno[12].ToString());
				this.upvibno14.Inlines.Add(Finalupvibno[13].ToString());
				this.upvibno15.Inlines.Add(Finalupvibno[14].ToString());
				this.upvibno16.Inlines.Add(Finalupvibno[15].ToString());
				this.upvibno17.Inlines.Add(Finalupvibno[16].ToString());
				this.upvibno18.Inlines.Add(Finalupvibno[17].ToString());
				this.upvibno19.Inlines.Add(Finalupvibno[18].ToString());
				this.upvibno20.Inlines.Add(Finalupvibno[19].ToString());
				this.upvibno21.Inlines.Add(Finalupvibno[20].ToString());
				this.upvibno22.Inlines.Add(Finalupvibno[21].ToString());
				this.upvibno23.Inlines.Add(Finalupvibno[22].ToString());
				this.upvibno24.Inlines.Add(Finalupvibno[23].ToString());
				double[] Finaldownvibno = new double[24];
				for (int i5 = 0; i5 < 8; i5++)
				{
					Finaldownvibno[i5] = vibno4[i5];
				}
				for (int i6 = 0; i6 < 8; i6++)
				{
					Finaldownvibno[i6 + 8] = vibno5[i6];
				}
				for (int i7 = 0; i7 < 8; i7++)
				{
					Finaldownvibno[i7 + 16] = vibno6[i7];
				}
				this.downvibno1.Inlines.Add(Finaldownvibno[0].ToString());
				this.downvibno2.Inlines.Add(Finaldownvibno[1].ToString());
				this.downvibno3.Inlines.Add(Finaldownvibno[2].ToString());
				this.downvibno4.Inlines.Add(Finaldownvibno[3].ToString());
				this.downvibno5.Inlines.Add(Finaldownvibno[4].ToString());
				this.downvibno6.Inlines.Add(Finaldownvibno[5].ToString());
				this.downvibno7.Inlines.Add(Finaldownvibno[6].ToString());
				this.downvibno8.Inlines.Add(Finaldownvibno[7].ToString());
				this.downvibno9.Inlines.Add(Finaldownvibno[8].ToString());
				this.downvibno10.Inlines.Add(Finaldownvibno[9].ToString());
				this.downvibno11.Inlines.Add(Finaldownvibno[10].ToString());
				this.downvibno12.Inlines.Add(Finaldownvibno[11].ToString());
				this.downvibno13.Inlines.Add(Finaldownvibno[12].ToString());
				this.downvibno14.Inlines.Add(Finaldownvibno[13].ToString());
				this.downvibno15.Inlines.Add(Finaldownvibno[14].ToString());
				this.downvibno16.Inlines.Add(Finaldownvibno[15].ToString());
				this.downvibno17.Inlines.Add(Finaldownvibno[16].ToString());
				this.downvibno18.Inlines.Add(Finaldownvibno[17].ToString());
				this.downvibno19.Inlines.Add(Finaldownvibno[18].ToString());
				this.downvibno20.Inlines.Add(Finaldownvibno[19].ToString());
				this.downvibno21.Inlines.Add(Finaldownvibno[20].ToString());
				this.downvibno22.Inlines.Add(Finaldownvibno[21].ToString());
				this.downvibno23.Inlines.Add(Finaldownvibno[22].ToString());
				this.downvibno24.Inlines.Add(Finaldownvibno[23].ToString());
				this.singlehigh = this.macro(this.High1);
				this.singlelow = this.macro(this.Low1);
				this.singlehigh1.Content = this.singlehigh.ToString();
				this.singlelow1.Content = this.singlelow.ToString();
				List<double> val = new List<double>();
				List<double> val2 = new List<double>();
				List<double> val3 = new List<double>();
				List<double> val4 = new List<double>();
				List<double> val5 = new List<double>();
				List<double> val6 = new List<double>();
				List<double> val7 = new List<double>();
				List<double> val8 = new List<double>();
				List<double> val9 = new List<double>();
				if (this.singlehigh == 1.0)
				{
					val.Add(1.0);
				}
				else if (this.singlehigh == 2.0)
				{
					val2.Add(1.0);
					val2.Add(2.0);
					val2.Add(3.0);
					val2.Add(4.0);
					val2.Add(6.0);
					val2.Add(8.0);
				}
				else if (this.singlehigh == 3.0)
				{
					val3.Add(1.0);
					val3.Add(2.0);
					val3.Add(3.0);
					val3.Add(6.0);
					val3.Add(9.0);
				}
				else if (this.singlehigh == 4.0)
				{
					val4.Add(1.0);
					val4.Add(2.0);
					val4.Add(4.0);
					val4.Add(8.0);
				}
				else if (this.singlehigh == 5.0)
				{
					val5.Add(1.0);
					val5.Add(5.0);
				}
				else if (this.singlehigh == 6.0)
				{
					val6.Add(1.0);
					val6.Add(2.0);
					val6.Add(3.0);
					val6.Add(6.0);
				}
				else if (this.singlehigh == 7.0)
				{
					val7.Add(1.0);
					val7.Add(7.0);
				}
				else if (this.singlehigh == 8.0)
				{
					val8.Add(1.0);
					val8.Add(2.0);
					val8.Add(4.0);
					val8.Add(8.0);
				}
				else if (this.singlehigh == 9.0)
				{
					val9.Add(1.0);
					val9.Add(3.0);
					val9.Add(9.0);
				}
				List<double> lowval = new List<double>();
				List<double> lowval2 = new List<double>();
				List<double> lowval3 = new List<double>();
				List<double> lowval4 = new List<double>();
				List<double> lowval5 = new List<double>();
				List<double> lowval6 = new List<double>();
				List<double> lowval7 = new List<double>();
				List<double> lowval8 = new List<double>();
				List<double> lowval9 = new List<double>();
				if (this.singlelow == 1.0)
				{
					lowval.Add(1.0);
				}
				else if (this.singlelow == 2.0)
				{
					lowval2.Add(1.0);
					lowval2.Add(2.0);
					lowval2.Add(3.0);
					lowval2.Add(4.0);
					lowval2.Add(6.0);
					lowval2.Add(8.0);
				}
				else if (this.singlelow == 3.0)
				{
					lowval3.Add(1.0);
					lowval3.Add(2.0);
					lowval3.Add(3.0);
					lowval3.Add(6.0);
					lowval3.Add(9.0);
				}
				else if (this.singlelow == 4.0)
				{
					lowval4.Add(1.0);
					lowval4.Add(2.0);
					lowval4.Add(4.0);
					lowval4.Add(8.0);
				}
				else if (this.singlelow == 5.0)
				{
					lowval5.Add(1.0);
					lowval5.Add(5.0);
				}
				else if (this.singlelow == 6.0)
				{
					lowval6.Add(1.0);
					lowval6.Add(2.0);
					lowval6.Add(3.0);
					lowval6.Add(6.0);
				}
				else if (this.singlelow == 7.0)
				{
					lowval7.Add(1.0);
					lowval7.Add(7.0);
				}
				else if (this.singlelow == 8.0)
				{
					lowval8.Add(1.0);
					lowval8.Add(2.0);
					lowval8.Add(4.0);
					lowval8.Add(8.0);
				}
				else if (this.singlelow == 9.0)
				{
					lowval9.Add(1.0);
					lowval9.Add(3.0);
					lowval9.Add(9.0);
				}
				List<Paragraph> upvibno = new List<Paragraph>
				{
					this.upvibno1,
					this.upvibno2,
					this.upvibno3,
					this.upvibno4,
					this.upvibno5,
					this.upvibno6,
					this.upvibno7,
					this.upvibno8,
					this.upvibno9,
					this.upvibno10,
					this.upvibno11,
					this.upvibno12,
					this.upvibno13,
					this.upvibno14,
					this.upvibno15,
					this.upvibno16,
					this.upvibno17,
					this.upvibno18,
					this.upvibno19,
					this.upvibno20,
					this.upvibno21,
					this.upvibno22,
					this.upvibno23,
					this.upvibno24
				};
				for (int i8 = 0; i8 < 24; i8++)
				{
					int adjustedIndex = i8 + 1;
					double numberToRetrieve = Finalupvibno[i8];
					List<double> val10 = null;
					if (this.singlehigh == 1.0)
					{
						val10 = val;
					}
					else if (this.singlehigh == 2.0)
					{
						val10 = val2;
					}
					else if (this.singlehigh == 3.0)
					{
						val10 = val3;
					}
					else if (this.singlehigh == 4.0)
					{
						val10 = val4;
					}
					else if (this.singlehigh == 5.0)
					{
						val10 = val5;
					}
					else if (this.singlehigh == 6.0)
					{
						val10 = val6;
					}
					else if (this.singlehigh == 7.0)
					{
						val10 = val7;
					}
					else if (this.singlehigh == 8.0)
					{
						val10 = val8;
					}
					else if (this.singlehigh == 9.0)
					{
						val10 = val9;
					}
					if (val10 != null && val10.Contains(numberToRetrieve))
					{
						string color = "#B7BFFF";
						upvibno[adjustedIndex - 1].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
					}
				}
				List<Paragraph> downvibno = new List<Paragraph>
				{
					this.downvibno1,
					this.downvibno2,
					this.downvibno3,
					this.downvibno4,
					this.downvibno5,
					this.downvibno6,
					this.downvibno7,
					this.downvibno8,
					this.downvibno9,
					this.downvibno10,
					this.downvibno11,
					this.downvibno12,
					this.downvibno13,
					this.downvibno14,
					this.downvibno15,
					this.downvibno16,
					this.downvibno17,
					this.downvibno18,
					this.downvibno19,
					this.downvibno20,
					this.downvibno21,
					this.downvibno22,
					this.downvibno23,
					this.downvibno24
				};
				for (int i9 = 0; i9 < 24; i9++)
				{
					int adjustedIndex2 = i9 + 1;
					double numberToRetrieve2 = Finaldownvibno[i9];
					List<double> val11 = null;
					if (this.singlelow == 1.0)
					{
						val11 = lowval;
					}
					else if (this.singlelow == 2.0)
					{
						val11 = lowval2;
					}
					else if (this.singlelow == 3.0)
					{
						val11 = lowval3;
					}
					else if (this.singlelow == 4.0)
					{
						val11 = lowval4;
					}
					else if (this.singlelow == 5.0)
					{
						val11 = lowval5;
					}
					else if (this.singlelow == 6.0)
					{
						val11 = lowval6;
					}
					else if (this.singlelow == 7.0)
					{
						val11 = lowval7;
					}
					else if (this.singlelow == 8.0)
					{
						val11 = lowval8;
					}
					else if (this.singlelow == 9.0)
					{
						val11 = lowval9;
					}
					if (val11 != null && val11.Contains(numberToRetrieve2))
					{
						string color2 = "#B7BFFF";
						downvibno[adjustedIndex2 - 1].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color2));
					}
				}
			}
			catch
			{
				MessageBox.Show("Pls load the data first", "SF Gann_Vib", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0006E28C File Offset: 0x0006C48C
		private double macro(double vibno)
		{
			string text = vibno.ToString().Replace(".", "");
			int sumOfDigits = 0;
			foreach (char digit in text)
			{
				if (char.IsDigit(digit))
				{
					sumOfDigits += int.Parse(digit.ToString());
				}
			}
			double vib;
			if (sumOfDigits < 10)
			{
				vib = (double)sumOfDigits;
			}
			else
			{
				while (sumOfDigits >= 10)
				{
					int tempSum = 0;
					string text2 = sumOfDigits.ToString();
					for (int i = 0; i < text2.Length; i++)
					{
						tempSum += int.Parse(text2[i].ToString());
					}
					sumOfDigits = tempSum;
				}
				vib = (double)sumOfDigits;
			}
			return vib;
		}

		// Token: 0x04000B59 RID: 2905
		private double Low1;

		// Token: 0x04000B5A RID: 2906
		private double High1;

		// Token: 0x04000B5B RID: 2907
		private double singlehigh;

		// Token: 0x04000B5C RID: 2908
		private double singlelow;

		// Token: 0x04000B5D RID: 2909
		[Nullable(1)]
		public static string gannTimeFutureDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeFutureDataDownload.php?symbol={0}";

		// Token: 0x04000B5E RID: 2910
		[Nullable(1)]
		public static string gannTimeIndexDataDownload_URL = "https://smartfinance.in/PHPusedForSoftwares/gann/gannTimeIndexDataDownload.php?symbol={0}";
	}
}
