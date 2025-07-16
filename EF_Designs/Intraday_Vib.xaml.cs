using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000049 RID: 73
	public partial class Intraday_Vib : UserControl
	{
		// Token: 0x06000366 RID: 870 RVA: 0x00071E4B File Offset: 0x0007004B
		public Intraday_Vib()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00071E5C File Offset: 0x0007005C
		public void Initialize_Variable()
		{
			this.Clear();
			try
			{
				FlowDocument yourFlowDocument = this.fDocUpCycle1;
				if (Equtiy_Future.LIVE_DATA != null)
				{
					this.lowPrice = Equtiy_Future.LIVE_DATA.low;
					this.highPrice = Equtiy_Future.LIVE_DATA.high;
					this.Inhigh.Content = this.highPrice.ToString();
					this.Inlow.Content = this.lowPrice.ToString();
				}
				Paragraph[] degreeParagraphs = new Paragraph[8];
				double[] results = new double[8];
				double[] vibno = new double[8];
				for (int i = 0; i < 8; i++)
				{
					degreeParagraphs[i] = (yourFlowDocument.FindName("Indegree" + (i + 1).ToString()) as Paragraph);
					if (degreeParagraphs[i] != null)
					{
						Run run = degreeParagraphs[i].Inlines.FirstInline as Run;
						double degreeValue;
						if (run != null && double.TryParse(run.Text, out degreeValue))
						{
							results[i] = Math.Round(Math.Pow(Math.Sqrt(this.highPrice) - degreeValue / 180.0, 2.0), 2);
							vibno[i] = this.macro(results[i]);
						}
					}
				}
				this.Inuptarget1.Inlines.Add(results[0].ToString());
				this.Inuptarget2.Inlines.Add(results[1].ToString());
				this.Inuptarget3.Inlines.Add(results[2].ToString());
				this.Inuptarget4.Inlines.Add(results[3].ToString());
				this.Inuptarget5.Inlines.Add(results[4].ToString());
				this.Inuptarget6.Inlines.Add(results[5].ToString());
				this.Inuptarget7.Inlines.Add(results[6].ToString());
				this.Inuptarget8.Inlines.Add(results[7].ToString());
				double[] results2 = new double[8];
				double[] vibno2 = new double[8];
				double upcycle2 = results[7];
				for (int j = 0; j < 8; j++)
				{
					degreeParagraphs[j] = (yourFlowDocument.FindName("Indegree" + (j + 1).ToString()) as Paragraph);
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
				this.Inuptarget9.Inlines.Add(results2[0].ToString());
				this.Inuptarget10.Inlines.Add(results2[1].ToString());
				this.Inuptarget11.Inlines.Add(results2[2].ToString());
				this.Inuptarget12.Inlines.Add(results2[3].ToString());
				this.Inuptarget13.Inlines.Add(results2[4].ToString());
				this.Inuptarget14.Inlines.Add(results2[5].ToString());
				this.Inuptarget15.Inlines.Add(results2[6].ToString());
				this.Inuptarget16.Inlines.Add(results2[7].ToString());
				double[] results3 = new double[8];
				double[] vibno3 = new double[8];
				double upcycle3 = results2[7];
				for (int k = 0; k < 8; k++)
				{
					degreeParagraphs[k] = (yourFlowDocument.FindName("Indegree" + (k + 1).ToString()) as Paragraph);
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
				this.Inuptarget17.Inlines.Add(results3[0].ToString());
				this.Inuptarget18.Inlines.Add(results3[1].ToString());
				this.Inuptarget19.Inlines.Add(results3[2].ToString());
				this.Inuptarget20.Inlines.Add(results3[3].ToString());
				this.Inuptarget21.Inlines.Add(results3[4].ToString());
				this.Inuptarget22.Inlines.Add(results3[5].ToString());
				this.Inuptarget23.Inlines.Add(results3[6].ToString());
				this.Inuptarget24.Inlines.Add(results3[7].ToString());
				double[] results4 = new double[8];
				double[] vibno4 = new double[8];
				for (int l = 0; l < 8; l++)
				{
					degreeParagraphs[l] = (yourFlowDocument.FindName("Indegree" + (l + 1).ToString()) as Paragraph);
					if (degreeParagraphs[l] != null)
					{
						Run run4 = degreeParagraphs[l].Inlines.FirstInline as Run;
						double degreeValue4;
						if (run4 != null && double.TryParse(run4.Text, out degreeValue4))
						{
							results4[l] = Math.Round(Math.Pow(Math.Sqrt(this.lowPrice) + degreeValue4 / 180.0, 2.0), 2);
							vibno4[l] = this.macro(results4[l]);
						}
					}
				}
				this.Indowntarget1.Inlines.Add(results4[0].ToString());
				this.Indowntarget2.Inlines.Add(results4[1].ToString());
				this.Indowntarget3.Inlines.Add(results4[2].ToString());
				this.Indowntarget4.Inlines.Add(results4[3].ToString());
				this.Indowntarget5.Inlines.Add(results4[4].ToString());
				this.Indowntarget6.Inlines.Add(results4[5].ToString());
				this.Indowntarget7.Inlines.Add(results4[6].ToString());
				this.Indowntarget8.Inlines.Add(results4[7].ToString());
				double[] results5 = new double[8];
				double[] vibno5 = new double[8];
				double downcycle2 = results4[7];
				for (int m = 0; m < 8; m++)
				{
					degreeParagraphs[m] = (yourFlowDocument.FindName("Indegree" + (m + 1).ToString()) as Paragraph);
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
				this.Indowntarget9.Inlines.Add(results5[0].ToString());
				this.Indowntarget10.Inlines.Add(results5[1].ToString());
				this.Indowntarget11.Inlines.Add(results5[2].ToString());
				this.Indowntarget12.Inlines.Add(results5[3].ToString());
				this.Indowntarget13.Inlines.Add(results5[4].ToString());
				this.Indowntarget14.Inlines.Add(results5[5].ToString());
				this.Indowntarget15.Inlines.Add(results5[6].ToString());
				this.Indowntarget16.Inlines.Add(results5[7].ToString());
				double[] results6 = new double[8];
				double[] vibno6 = new double[8];
				double downcycle3 = results5[7];
				for (int n = 0; n < 8; n++)
				{
					degreeParagraphs[n] = (yourFlowDocument.FindName("Indegree" + (n + 1).ToString()) as Paragraph);
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
				this.Indowntarget17.Inlines.Add(results6[0].ToString());
				this.Indowntarget18.Inlines.Add(results6[1].ToString());
				this.Indowntarget19.Inlines.Add(results6[2].ToString());
				this.Indowntarget20.Inlines.Add(results6[3].ToString());
				this.Indowntarget21.Inlines.Add(results6[4].ToString());
				this.Indowntarget22.Inlines.Add(results6[5].ToString());
				this.Indowntarget23.Inlines.Add(results6[6].ToString());
				this.Indowntarget24.Inlines.Add(results6[7].ToString());
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
				this.Inupvibno1.Inlines.Add(Finalupvibno[0].ToString());
				this.Inupvibno2.Inlines.Add(Finalupvibno[1].ToString());
				this.Inupvibno3.Inlines.Add(Finalupvibno[2].ToString());
				this.Inupvibno4.Inlines.Add(Finalupvibno[3].ToString());
				this.Inupvibno5.Inlines.Add(Finalupvibno[4].ToString());
				this.Inupvibno6.Inlines.Add(Finalupvibno[5].ToString());
				this.Inupvibno7.Inlines.Add(Finalupvibno[6].ToString());
				this.Inupvibno8.Inlines.Add(Finalupvibno[7].ToString());
				this.Inupvibno9.Inlines.Add(Finalupvibno[8].ToString());
				this.Inupvibno10.Inlines.Add(Finalupvibno[9].ToString());
				this.Inupvibno11.Inlines.Add(Finalupvibno[10].ToString());
				this.Inupvibno12.Inlines.Add(Finalupvibno[11].ToString());
				this.Inupvibno13.Inlines.Add(Finalupvibno[12].ToString());
				this.Inupvibno14.Inlines.Add(Finalupvibno[13].ToString());
				this.Inupvibno15.Inlines.Add(Finalupvibno[14].ToString());
				this.Inupvibno16.Inlines.Add(Finalupvibno[15].ToString());
				this.Inupvibno17.Inlines.Add(Finalupvibno[16].ToString());
				this.Inupvibno18.Inlines.Add(Finalupvibno[17].ToString());
				this.Inupvibno19.Inlines.Add(Finalupvibno[18].ToString());
				this.Inupvibno20.Inlines.Add(Finalupvibno[19].ToString());
				this.Inupvibno21.Inlines.Add(Finalupvibno[20].ToString());
				this.Inupvibno22.Inlines.Add(Finalupvibno[21].ToString());
				this.Inupvibno23.Inlines.Add(Finalupvibno[22].ToString());
				this.Inupvibno24.Inlines.Add(Finalupvibno[23].ToString());
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
				this.Indownvibno1.Inlines.Add(Finaldownvibno[0].ToString());
				this.Indownvibno2.Inlines.Add(Finaldownvibno[1].ToString());
				this.Indownvibno3.Inlines.Add(Finaldownvibno[2].ToString());
				this.Indownvibno4.Inlines.Add(Finaldownvibno[3].ToString());
				this.Indownvibno5.Inlines.Add(Finaldownvibno[4].ToString());
				this.Indownvibno6.Inlines.Add(Finaldownvibno[5].ToString());
				this.Indownvibno7.Inlines.Add(Finaldownvibno[6].ToString());
				this.Indownvibno8.Inlines.Add(Finaldownvibno[7].ToString());
				this.Indownvibno9.Inlines.Add(Finaldownvibno[8].ToString());
				this.Indownvibno10.Inlines.Add(Finaldownvibno[9].ToString());
				this.Indownvibno11.Inlines.Add(Finaldownvibno[10].ToString());
				this.Indownvibno12.Inlines.Add(Finaldownvibno[11].ToString());
				this.Indownvibno13.Inlines.Add(Finaldownvibno[12].ToString());
				this.Indownvibno14.Inlines.Add(Finaldownvibno[13].ToString());
				this.Indownvibno15.Inlines.Add(Finaldownvibno[14].ToString());
				this.Indownvibno16.Inlines.Add(Finaldownvibno[15].ToString());
				this.Indownvibno17.Inlines.Add(Finaldownvibno[16].ToString());
				this.Indownvibno18.Inlines.Add(Finaldownvibno[17].ToString());
				this.Indownvibno19.Inlines.Add(Finaldownvibno[18].ToString());
				this.Indownvibno20.Inlines.Add(Finaldownvibno[19].ToString());
				this.Indownvibno21.Inlines.Add(Finaldownvibno[20].ToString());
				this.Indownvibno22.Inlines.Add(Finaldownvibno[21].ToString());
				this.Indownvibno23.Inlines.Add(Finaldownvibno[22].ToString());
				this.Indownvibno24.Inlines.Add(Finaldownvibno[23].ToString());
				this.singlehigh = this.macro(this.highPrice);
				this.singlelow = this.macro(this.lowPrice);
				this.Insinglehigh1.Content = this.singlehigh.ToString();
				this.Insinglelow1.Content = this.singlelow.ToString();
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
					this.Inupvibno1,
					this.Inupvibno2,
					this.Inupvibno3,
					this.Inupvibno4,
					this.Inupvibno5,
					this.Inupvibno6,
					this.Inupvibno7,
					this.Inupvibno8,
					this.Inupvibno9,
					this.Inupvibno10,
					this.Inupvibno11,
					this.Inupvibno12,
					this.Inupvibno13,
					this.Inupvibno14,
					this.Inupvibno15,
					this.Inupvibno16,
					this.Inupvibno17,
					this.Inupvibno18,
					this.Inupvibno19,
					this.Inupvibno20,
					this.Inupvibno21,
					this.Inupvibno22,
					this.Inupvibno23,
					this.Inupvibno24
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
					this.Indownvibno1,
					this.Indownvibno2,
					this.Indownvibno3,
					this.Indownvibno4,
					this.Indownvibno5,
					this.Indownvibno6,
					this.Indownvibno7,
					this.Indownvibno8,
					this.Indownvibno9,
					this.Indownvibno10,
					this.Indownvibno11,
					this.Indownvibno12,
					this.Indownvibno13,
					this.Indownvibno14,
					this.Indownvibno15,
					this.Indownvibno16,
					this.Indownvibno17,
					this.Indownvibno18,
					this.Indownvibno19,
					this.Indownvibno20,
					this.Indownvibno21,
					this.Indownvibno22,
					this.Indownvibno23,
					this.Indownvibno24
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
				MessageBox.Show("Pls load the data first", "SF Intraday_Vib", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000739FC File Offset: 0x00071BFC
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

		// Token: 0x06000369 RID: 873 RVA: 0x00073AA0 File Offset: 0x00071CA0
		private void Clear()
		{
			this.Inuptarget1.Inlines.Clear();
			this.Inuptarget2.Inlines.Clear();
			this.Inuptarget3.Inlines.Clear();
			this.Inuptarget4.Inlines.Clear();
			this.Inuptarget5.Inlines.Clear();
			this.Inuptarget6.Inlines.Clear();
			this.Inuptarget7.Inlines.Clear();
			this.Inuptarget8.Inlines.Clear();
			this.Inuptarget9.Inlines.Clear();
			this.Inuptarget10.Inlines.Clear();
			this.Inuptarget11.Inlines.Clear();
			this.Inuptarget12.Inlines.Clear();
			this.Inuptarget13.Inlines.Clear();
			this.Inuptarget14.Inlines.Clear();
			this.Inuptarget15.Inlines.Clear();
			this.Inuptarget16.Inlines.Clear();
			this.Inuptarget17.Inlines.Clear();
			this.Inuptarget18.Inlines.Clear();
			this.Inuptarget19.Inlines.Clear();
			this.Inuptarget20.Inlines.Clear();
			this.Inuptarget21.Inlines.Clear();
			this.Inuptarget22.Inlines.Clear();
			this.Inuptarget23.Inlines.Clear();
			this.Inuptarget24.Inlines.Clear();
			this.Indowntarget1.Inlines.Clear();
			this.Indowntarget2.Inlines.Clear();
			this.Indowntarget3.Inlines.Clear();
			this.Indowntarget4.Inlines.Clear();
			this.Indowntarget5.Inlines.Clear();
			this.Indowntarget6.Inlines.Clear();
			this.Indowntarget7.Inlines.Clear();
			this.Indowntarget8.Inlines.Clear();
			this.Indowntarget9.Inlines.Clear();
			this.Indowntarget10.Inlines.Clear();
			this.Indowntarget11.Inlines.Clear();
			this.Indowntarget12.Inlines.Clear();
			this.Indowntarget13.Inlines.Clear();
			this.Indowntarget14.Inlines.Clear();
			this.Indowntarget15.Inlines.Clear();
			this.Indowntarget16.Inlines.Clear();
			this.Indowntarget17.Inlines.Clear();
			this.Indowntarget18.Inlines.Clear();
			this.Indowntarget19.Inlines.Clear();
			this.Indowntarget20.Inlines.Clear();
			this.Indowntarget21.Inlines.Clear();
			this.Indowntarget22.Inlines.Clear();
			this.Indowntarget23.Inlines.Clear();
			this.Indowntarget24.Inlines.Clear();
			this.Inupvibno1.Inlines.Clear();
			this.Inupvibno2.Inlines.Clear();
			this.Inupvibno3.Inlines.Clear();
			this.Inupvibno4.Inlines.Clear();
			this.Inupvibno5.Inlines.Clear();
			this.Inupvibno6.Inlines.Clear();
			this.Inupvibno7.Inlines.Clear();
			this.Inupvibno8.Inlines.Clear();
			this.Inupvibno9.Inlines.Clear();
			this.Inupvibno10.Inlines.Clear();
			this.Inupvibno11.Inlines.Clear();
			this.Inupvibno12.Inlines.Clear();
			this.Inupvibno13.Inlines.Clear();
			this.Inupvibno14.Inlines.Clear();
			this.Inupvibno15.Inlines.Clear();
			this.Inupvibno16.Inlines.Clear();
			this.Inupvibno17.Inlines.Clear();
			this.Inupvibno18.Inlines.Clear();
			this.Inupvibno19.Inlines.Clear();
			this.Inupvibno20.Inlines.Clear();
			this.Inupvibno21.Inlines.Clear();
			this.Inupvibno22.Inlines.Clear();
			this.Inupvibno23.Inlines.Clear();
			this.Inupvibno24.Inlines.Clear();
			this.Indownvibno1.Inlines.Clear();
			this.Indownvibno2.Inlines.Clear();
			this.Indownvibno3.Inlines.Clear();
			this.Indownvibno4.Inlines.Clear();
			this.Indownvibno5.Inlines.Clear();
			this.Indownvibno6.Inlines.Clear();
			this.Indownvibno7.Inlines.Clear();
			this.Indownvibno8.Inlines.Clear();
			this.Indownvibno9.Inlines.Clear();
			this.Indownvibno10.Inlines.Clear();
			this.Indownvibno11.Inlines.Clear();
			this.Indownvibno12.Inlines.Clear();
			this.Indownvibno13.Inlines.Clear();
			this.Indownvibno14.Inlines.Clear();
			this.Indownvibno15.Inlines.Clear();
			this.Indownvibno16.Inlines.Clear();
			this.Indownvibno17.Inlines.Clear();
			this.Indownvibno18.Inlines.Clear();
			this.Indownvibno19.Inlines.Clear();
			this.Indownvibno20.Inlines.Clear();
			this.Indownvibno21.Inlines.Clear();
			this.Indownvibno22.Inlines.Clear();
			this.Indownvibno23.Inlines.Clear();
			this.Indownvibno24.Inlines.Clear();
			Paragraph[] inuptargets = new Paragraph[]
			{
				this.Inupvibno1,
				this.Inupvibno2,
				this.Inupvibno3,
				this.Inupvibno4,
				this.Inupvibno5,
				this.Inupvibno6,
				this.Inupvibno7,
				this.Inupvibno8,
				this.Inupvibno9,
				this.Inupvibno10,
				this.Inupvibno11,
				this.Inupvibno12,
				this.Inupvibno13,
				this.Inupvibno14,
				this.Inupvibno15,
				this.Inupvibno16,
				this.Inupvibno17,
				this.Inupvibno18,
				this.Inupvibno19,
				this.Inupvibno20,
				this.Inupvibno21,
				this.Inupvibno22,
				this.Inupvibno23,
				this.Inupvibno24
			};
			Paragraph[] array = new Paragraph[]
			{
				this.Indownvibno1,
				this.Indownvibno2,
				this.Indownvibno3,
				this.Indownvibno4,
				this.Indownvibno5,
				this.Indownvibno6,
				this.Indownvibno7,
				this.Indownvibno8,
				this.Indownvibno9,
				this.Indownvibno10,
				this.Indownvibno11,
				this.Indownvibno12,
				this.Indownvibno13,
				this.Indownvibno14,
				this.Indownvibno15,
				this.Indownvibno16,
				this.Indownvibno17,
				this.Indownvibno18,
				this.Indownvibno19,
				this.Indownvibno20,
				this.Indownvibno21,
				this.Indownvibno22,
				this.Indownvibno23,
				this.Indownvibno24
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Background = Brushes.White;
			}
			array = inuptargets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Background = Brushes.White;
			}
		}

		// Token: 0x04000D61 RID: 3425
		private double lowPrice;

		// Token: 0x04000D62 RID: 3426
		private double highPrice;

		// Token: 0x04000D63 RID: 3427
		private double singlehigh;

		// Token: 0x04000D64 RID: 3428
		private double singlelow;
	}
}
