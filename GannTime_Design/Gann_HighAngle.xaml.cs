using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace New_SF_IT.GannTime_Design
{
	// Token: 0x02000036 RID: 54
	public partial class Gann_HighAngle : UserControl
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x00040DFF File Offset: 0x0003EFFF
		public Gann_HighAngle()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00040E10 File Offset: 0x0003F010
		public void Initialize_Variable()
		{
			try
			{
				gannTimeAnalysis.highAngle();
				if (gannTimeAnalysis.getFilteredDaylist.Count == 0)
				{
					string messageBoxText = "No days fall on this principle for " + Equtiy_Future.selectedTime + " Time";
					object content = this.dataGridLabel_highAngle.Content;
					MessageBox.Show(messageBoxText, ((content != null) ? content.ToString() : null) ?? "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				else
				{
					this.highAngleCalendar();
				}
			}
			catch
			{
				MessageBox.Show("Please Try Again");
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00040E94 File Offset: 0x0003F094
		private void clearTableValues_HA()
		{
			this.HA_week1_cell1.Inlines.Clear();
			this.HA_week1_cell2.Inlines.Clear();
			this.HA_week1_cell3.Inlines.Clear();
			this.HA_week1_cell4.Inlines.Clear();
			this.HA_week1_cell5.Inlines.Clear();
			this.HA_week1_cell6.Inlines.Clear();
			this.HA_week1_cell7.Inlines.Clear();
			this.HA_week2_cell1.Inlines.Clear();
			this.HA_week2_cell2.Inlines.Clear();
			this.HA_week2_cell3.Inlines.Clear();
			this.HA_week2_cell4.Inlines.Clear();
			this.HA_week2_cell5.Inlines.Clear();
			this.HA_week2_cell6.Inlines.Clear();
			this.HA_week2_cell7.Inlines.Clear();
			this.HA_week3_cell1.Inlines.Clear();
			this.HA_week3_cell2.Inlines.Clear();
			this.HA_week3_cell3.Inlines.Clear();
			this.HA_week3_cell4.Inlines.Clear();
			this.HA_week3_cell5.Inlines.Clear();
			this.HA_week3_cell6.Inlines.Clear();
			this.HA_week3_cell7.Inlines.Clear();
			this.HA_week4_cell1.Inlines.Clear();
			this.HA_week4_cell2.Inlines.Clear();
			this.HA_week4_cell3.Inlines.Clear();
			this.HA_week4_cell4.Inlines.Clear();
			this.HA_week4_cell5.Inlines.Clear();
			this.HA_week4_cell6.Inlines.Clear();
			this.HA_week4_cell7.Inlines.Clear();
			this.HA_week5_cell1.Inlines.Clear();
			this.HA_week5_cell2.Inlines.Clear();
			this.HA_week5_cell3.Inlines.Clear();
			this.HA_week5_cell4.Inlines.Clear();
			this.HA_week5_cell5.Inlines.Clear();
			this.HA_week5_cell6.Inlines.Clear();
			this.HA_week5_cell7.Inlines.Clear();
			this.HA_week6_cell1.Inlines.Clear();
			this.HA_week6_cell2.Inlines.Clear();
			this.HA_week6_cell3.Inlines.Clear();
			this.HA_week6_cell4.Inlines.Clear();
			this.HA_week6_cell5.Inlines.Clear();
			this.HA_week6_cell6.Inlines.Clear();
			this.HA_week6_cell7.Inlines.Clear();
			this.HA_week1_cell1.Background = Brushes.White;
			this.HA_week1_cell2.Background = Brushes.White;
			this.HA_week1_cell3.Background = Brushes.White;
			this.HA_week1_cell4.Background = Brushes.White;
			this.HA_week1_cell5.Background = Brushes.White;
			this.HA_week1_cell6.Background = Brushes.White;
			this.HA_week1_cell7.Background = Brushes.White;
			this.HA_week2_cell1.Background = Brushes.White;
			this.HA_week2_cell2.Background = Brushes.White;
			this.HA_week2_cell3.Background = Brushes.White;
			this.HA_week2_cell4.Background = Brushes.White;
			this.HA_week2_cell5.Background = Brushes.White;
			this.HA_week2_cell6.Background = Brushes.White;
			this.HA_week2_cell7.Background = Brushes.White;
			this.HA_week3_cell1.Background = Brushes.White;
			this.HA_week3_cell2.Background = Brushes.White;
			this.HA_week3_cell3.Background = Brushes.White;
			this.HA_week3_cell4.Background = Brushes.White;
			this.HA_week3_cell5.Background = Brushes.White;
			this.HA_week3_cell6.Background = Brushes.White;
			this.HA_week3_cell7.Background = Brushes.White;
			this.HA_week4_cell1.Background = Brushes.White;
			this.HA_week4_cell2.Background = Brushes.White;
			this.HA_week4_cell3.Background = Brushes.White;
			this.HA_week4_cell4.Background = Brushes.White;
			this.HA_week4_cell5.Background = Brushes.White;
			this.HA_week4_cell6.Background = Brushes.White;
			this.HA_week4_cell7.Background = Brushes.White;
			this.HA_week5_cell1.Background = Brushes.White;
			this.HA_week5_cell2.Background = Brushes.White;
			this.HA_week5_cell3.Background = Brushes.White;
			this.HA_week5_cell4.Background = Brushes.White;
			this.HA_week5_cell5.Background = Brushes.White;
			this.HA_week5_cell6.Background = Brushes.White;
			this.HA_week5_cell7.Background = Brushes.White;
			this.HA_week6_cell1.Background = Brushes.White;
			this.HA_week6_cell2.Background = Brushes.White;
			this.HA_week6_cell3.Background = Brushes.White;
			this.HA_week6_cell4.Background = Brushes.White;
			this.HA_week6_cell5.Background = Brushes.White;
			this.HA_week6_cell6.Background = Brushes.White;
			this.HA_week6_cell7.Background = Brushes.White;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000413E4 File Offset: 0x0003F5E4
		private void highAngleCalendar()
		{
			this.calender_highAngle_Grid.Visibility = Visibility.Visible;
			this.clearTableValues_HA();
			DateTime sDT = DateTime.Today;
			DateTime firstDayOfMonthWithTime = new DateTime(sDT.Year, sDT.Month, 1);
			string firstDayName = DateTime.Parse(firstDayOfMonthWithTime.ToString()).DayOfWeek.ToString();
			Convert.ToInt32(firstDayOfMonthWithTime.Day);
			int lastDayOftheMonth = DateTime.DaysInMonth(sDT.Year, sDT.Month);
			if (firstDayName == "Sunday")
			{
				this.HA_week1_cell1.Inlines.Add("1");
				this.HA_week1_cell2.Inlines.Add("2");
				this.HA_week1_cell3.Inlines.Add("3");
				this.HA_week1_cell4.Inlines.Add("4");
				this.HA_week1_cell5.Inlines.Add("5");
				this.HA_week1_cell6.Inlines.Add("6");
				this.HA_week1_cell7.Inlines.Add("7");
				this.HA_week2_cell1.Inlines.Add("8");
				this.HA_week2_cell2.Inlines.Add("9");
				this.HA_week2_cell3.Inlines.Add("10");
				this.HA_week2_cell4.Inlines.Add("11");
				this.HA_week2_cell5.Inlines.Add("12");
				this.HA_week2_cell6.Inlines.Add("13");
				this.HA_week2_cell7.Inlines.Add("14");
				this.HA_week3_cell1.Inlines.Add("15");
				this.HA_week3_cell2.Inlines.Add("16");
				this.HA_week3_cell3.Inlines.Add("17");
				this.HA_week3_cell4.Inlines.Add("18");
				this.HA_week3_cell5.Inlines.Add("19");
				this.HA_week3_cell6.Inlines.Add("20");
				this.HA_week3_cell7.Inlines.Add("21");
				this.HA_week4_cell1.Inlines.Add("22");
				this.HA_week4_cell2.Inlines.Add("23");
				this.HA_week4_cell3.Inlines.Add("24");
				this.HA_week4_cell4.Inlines.Add("25");
				this.HA_week4_cell5.Inlines.Add("26");
				this.HA_week4_cell6.Inlines.Add("27");
				this.HA_week4_cell7.Inlines.Add("28");
				string _29th = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell1.Inlines.Add(_29th);
				this.HA_week5_cell2.Inlines.Add(_30th);
				this.HA_week5_cell3.Inlines.Add(_31st);
				for (int i = 0; i <= gannTimeAnalysis.getFilteredDaylist.Count - 1; i++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 1)
					{
						this.HA_week1_cell1.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 2)
					{
						this.HA_week1_cell2.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 3)
					{
						this.HA_week1_cell3.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 4)
					{
						this.HA_week1_cell4.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 5)
					{
						this.HA_week1_cell5.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 6)
					{
						this.HA_week1_cell6.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 7)
					{
						this.HA_week1_cell7.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 8)
					{
						this.HA_week2_cell1.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 9)
					{
						this.HA_week2_cell2.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 10)
					{
						this.HA_week2_cell3.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 11)
					{
						this.HA_week2_cell4.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 12)
					{
						this.HA_week2_cell5.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 13)
					{
						this.HA_week2_cell6.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 14)
					{
						this.HA_week2_cell7.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 15)
					{
						this.HA_week3_cell1.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 16)
					{
						this.HA_week3_cell2.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 17)
					{
						this.HA_week3_cell3.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 18)
					{
						this.HA_week3_cell4.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 19)
					{
						this.HA_week3_cell5.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 20)
					{
						this.HA_week3_cell6.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 21)
					{
						this.HA_week3_cell7.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 22)
					{
						this.HA_week4_cell1.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 23)
					{
						this.HA_week4_cell2.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 24)
					{
						this.HA_week4_cell3.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 25)
					{
						this.HA_week4_cell4.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 26)
					{
						this.HA_week4_cell5.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 27)
					{
						this.HA_week4_cell6.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 28)
					{
						this.HA_week4_cell7.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 29)
					{
						this.HA_week5_cell1.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 30)
					{
						this.HA_week5_cell2.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i) == 31)
					{
						this.HA_week5_cell3.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Monday")
			{
				this.HA_week1_cell2.Inlines.Add("1");
				this.HA_week1_cell3.Inlines.Add("2");
				this.HA_week1_cell4.Inlines.Add("3");
				this.HA_week1_cell5.Inlines.Add("4");
				this.HA_week1_cell6.Inlines.Add("5");
				this.HA_week1_cell7.Inlines.Add("6");
				this.HA_week2_cell1.Inlines.Add("7");
				this.HA_week2_cell2.Inlines.Add("8");
				this.HA_week2_cell3.Inlines.Add("9");
				this.HA_week2_cell4.Inlines.Add("10");
				this.HA_week2_cell5.Inlines.Add("11");
				this.HA_week2_cell6.Inlines.Add("12");
				this.HA_week2_cell7.Inlines.Add("13");
				this.HA_week3_cell1.Inlines.Add("14");
				this.HA_week3_cell2.Inlines.Add("15");
				this.HA_week3_cell3.Inlines.Add("16");
				this.HA_week3_cell4.Inlines.Add("17");
				this.HA_week3_cell5.Inlines.Add("18");
				this.HA_week3_cell6.Inlines.Add("19");
				this.HA_week3_cell7.Inlines.Add("20");
				this.HA_week4_cell1.Inlines.Add("21");
				this.HA_week4_cell2.Inlines.Add("22");
				this.HA_week4_cell3.Inlines.Add("23");
				this.HA_week4_cell4.Inlines.Add("24");
				this.HA_week4_cell5.Inlines.Add("25");
				this.HA_week4_cell6.Inlines.Add("26");
				this.HA_week4_cell7.Inlines.Add("27");
				this.HA_week5_cell1.Inlines.Add("28");
				string _29th2 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th2 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st2 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell2.Inlines.Add(_29th2);
				this.HA_week5_cell3.Inlines.Add(_30th2);
				this.HA_week5_cell4.Inlines.Add(_31st2);
				for (int j = 0; j <= gannTimeAnalysis.getFilteredDaylist.Count - 1; j++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 1)
					{
						this.HA_week1_cell2.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 2)
					{
						this.HA_week1_cell3.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 3)
					{
						this.HA_week1_cell4.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 4)
					{
						this.HA_week1_cell5.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 5)
					{
						this.HA_week1_cell6.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 6)
					{
						this.HA_week1_cell7.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 7)
					{
						this.HA_week2_cell1.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 8)
					{
						this.HA_week2_cell2.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 9)
					{
						this.HA_week2_cell3.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 10)
					{
						this.HA_week2_cell4.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 11)
					{
						this.HA_week2_cell5.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 12)
					{
						this.HA_week2_cell6.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 13)
					{
						this.HA_week2_cell7.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 14)
					{
						this.HA_week3_cell1.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 15)
					{
						this.HA_week3_cell2.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 16)
					{
						this.HA_week3_cell3.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 17)
					{
						this.HA_week3_cell4.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 18)
					{
						this.HA_week3_cell5.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 19)
					{
						this.HA_week3_cell6.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 20)
					{
						this.HA_week3_cell7.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 21)
					{
						this.HA_week4_cell1.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 22)
					{
						this.HA_week4_cell2.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 23)
					{
						this.HA_week4_cell3.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 24)
					{
						this.HA_week4_cell4.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 25)
					{
						this.HA_week4_cell5.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 26)
					{
						this.HA_week4_cell6.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 27)
					{
						this.HA_week4_cell7.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 28)
					{
						this.HA_week5_cell1.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 29)
					{
						this.HA_week5_cell2.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 30)
					{
						this.HA_week5_cell3.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(j) == 31)
					{
						this.HA_week5_cell4.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(j)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Tuesday")
			{
				this.HA_week1_cell3.Inlines.Add("1");
				this.HA_week1_cell4.Inlines.Add("2");
				this.HA_week1_cell5.Inlines.Add("3");
				this.HA_week1_cell6.Inlines.Add("4");
				this.HA_week1_cell7.Inlines.Add("5");
				this.HA_week2_cell1.Inlines.Add("6");
				this.HA_week2_cell2.Inlines.Add("7");
				this.HA_week2_cell3.Inlines.Add("8");
				this.HA_week2_cell4.Inlines.Add("9");
				this.HA_week2_cell5.Inlines.Add("10");
				this.HA_week2_cell6.Inlines.Add("11");
				this.HA_week2_cell7.Inlines.Add("12");
				this.HA_week3_cell1.Inlines.Add("13");
				this.HA_week3_cell2.Inlines.Add("14");
				this.HA_week3_cell3.Inlines.Add("15");
				this.HA_week3_cell4.Inlines.Add("16");
				this.HA_week3_cell5.Inlines.Add("17");
				this.HA_week3_cell6.Inlines.Add("18");
				this.HA_week3_cell7.Inlines.Add("19");
				this.HA_week4_cell1.Inlines.Add("20");
				this.HA_week4_cell2.Inlines.Add("21");
				this.HA_week4_cell3.Inlines.Add("22");
				this.HA_week4_cell4.Inlines.Add("23");
				this.HA_week4_cell5.Inlines.Add("24");
				this.HA_week4_cell6.Inlines.Add("25");
				this.HA_week4_cell7.Inlines.Add("26");
				this.HA_week5_cell1.Inlines.Add("27");
				this.HA_week5_cell2.Inlines.Add("28");
				string _29th3 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th3 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st3 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell3.Inlines.Add(_29th3);
				this.HA_week5_cell4.Inlines.Add(_30th3);
				this.HA_week5_cell5.Inlines.Add(_31st3);
				for (int k = 0; k <= gannTimeAnalysis.getFilteredDaylist.Count - 1; k++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 1)
					{
						this.HA_week1_cell3.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 2)
					{
						this.HA_week1_cell4.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 3)
					{
						this.HA_week1_cell5.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 4)
					{
						this.HA_week1_cell6.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 5)
					{
						this.HA_week1_cell7.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 6)
					{
						this.HA_week2_cell1.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 7)
					{
						this.HA_week2_cell2.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 8)
					{
						this.HA_week2_cell3.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 9)
					{
						this.HA_week2_cell4.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 10)
					{
						this.HA_week2_cell5.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 11)
					{
						this.HA_week2_cell6.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 12)
					{
						this.HA_week2_cell7.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 13)
					{
						this.HA_week3_cell1.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 14)
					{
						this.HA_week3_cell2.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 15)
					{
						this.HA_week3_cell3.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 16)
					{
						this.HA_week3_cell4.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 17)
					{
						this.HA_week3_cell5.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 18)
					{
						this.HA_week3_cell6.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 19)
					{
						this.HA_week3_cell7.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 20)
					{
						this.HA_week4_cell1.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 21)
					{
						this.HA_week4_cell2.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 22)
					{
						this.HA_week4_cell3.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 23)
					{
						this.HA_week4_cell4.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 24)
					{
						this.HA_week4_cell5.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 25)
					{
						this.HA_week4_cell6.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 26)
					{
						this.HA_week4_cell7.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 27)
					{
						this.HA_week4_cell1.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 28)
					{
						this.HA_week5_cell2.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 29)
					{
						this.HA_week5_cell3.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 30)
					{
						this.HA_week5_cell4.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(k) == 31)
					{
						this.HA_week5_cell5.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(k)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Wednesday")
			{
				this.HA_week1_cell4.Inlines.Add("1");
				this.HA_week1_cell5.Inlines.Add("2");
				this.HA_week1_cell6.Inlines.Add("3");
				this.HA_week1_cell7.Inlines.Add("4");
				this.HA_week2_cell1.Inlines.Add("5");
				this.HA_week2_cell2.Inlines.Add("6");
				this.HA_week2_cell3.Inlines.Add("7");
				this.HA_week2_cell4.Inlines.Add("8");
				this.HA_week2_cell5.Inlines.Add("9");
				this.HA_week2_cell6.Inlines.Add("10");
				this.HA_week2_cell7.Inlines.Add("11");
				this.HA_week3_cell1.Inlines.Add("12");
				this.HA_week3_cell2.Inlines.Add("13");
				this.HA_week3_cell3.Inlines.Add("14");
				this.HA_week3_cell4.Inlines.Add("15");
				this.HA_week3_cell5.Inlines.Add("16");
				this.HA_week3_cell6.Inlines.Add("17");
				this.HA_week3_cell7.Inlines.Add("18");
				this.HA_week4_cell1.Inlines.Add("19");
				this.HA_week4_cell2.Inlines.Add("20");
				this.HA_week4_cell3.Inlines.Add("21");
				this.HA_week4_cell4.Inlines.Add("22");
				this.HA_week4_cell5.Inlines.Add("23");
				this.HA_week4_cell6.Inlines.Add("24");
				this.HA_week4_cell7.Inlines.Add("25");
				this.HA_week5_cell1.Inlines.Add("26");
				this.HA_week5_cell2.Inlines.Add("27");
				this.HA_week5_cell3.Inlines.Add("28");
				string _29th4 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th4 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st4 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell4.Inlines.Add(_29th4);
				this.HA_week5_cell5.Inlines.Add(_30th4);
				this.HA_week5_cell6.Inlines.Add(_31st4);
				for (int l = 0; l <= gannTimeAnalysis.getFilteredDaylist.Count - 1; l++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 1)
					{
						this.HA_week1_cell4.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 2)
					{
						this.HA_week1_cell5.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 3)
					{
						this.HA_week1_cell6.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 4)
					{
						this.HA_week1_cell7.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 5)
					{
						this.HA_week2_cell1.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 6)
					{
						this.HA_week2_cell2.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 7)
					{
						this.HA_week2_cell3.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 8)
					{
						this.HA_week2_cell4.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 9)
					{
						this.HA_week2_cell5.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 10)
					{
						this.HA_week2_cell6.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 11)
					{
						this.HA_week2_cell7.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 12)
					{
						this.HA_week3_cell1.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 13)
					{
						this.HA_week3_cell2.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 14)
					{
						this.HA_week3_cell3.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 15)
					{
						this.HA_week3_cell4.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 16)
					{
						this.HA_week3_cell5.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 17)
					{
						this.HA_week3_cell6.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 18)
					{
						this.HA_week3_cell7.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 19)
					{
						this.HA_week4_cell1.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 20)
					{
						this.HA_week4_cell2.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 21)
					{
						this.HA_week4_cell3.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 22)
					{
						this.HA_week4_cell4.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 23)
					{
						this.HA_week4_cell5.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 24)
					{
						this.HA_week4_cell6.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 25)
					{
						this.HA_week4_cell7.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 26)
					{
						this.HA_week5_cell1.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 27)
					{
						this.HA_week5_cell2.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 28)
					{
						this.HA_week5_cell3.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 29)
					{
						this.HA_week5_cell4.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 30)
					{
						this.HA_week5_cell5.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(l) == 31)
					{
						this.HA_week5_cell6.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(l)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Thursday")
			{
				this.HA_week1_cell5.Inlines.Add("1");
				this.HA_week1_cell6.Inlines.Add("2");
				this.HA_week1_cell7.Inlines.Add("3");
				this.HA_week2_cell1.Inlines.Add("4");
				this.HA_week2_cell2.Inlines.Add("5");
				this.HA_week2_cell3.Inlines.Add("6");
				this.HA_week2_cell4.Inlines.Add("7");
				this.HA_week2_cell5.Inlines.Add("8");
				this.HA_week2_cell6.Inlines.Add("9");
				this.HA_week2_cell7.Inlines.Add("10");
				this.HA_week3_cell1.Inlines.Add("11");
				this.HA_week3_cell2.Inlines.Add("12");
				this.HA_week3_cell3.Inlines.Add("13");
				this.HA_week3_cell4.Inlines.Add("14");
				this.HA_week3_cell5.Inlines.Add("15");
				this.HA_week3_cell6.Inlines.Add("16");
				this.HA_week3_cell7.Inlines.Add("17");
				this.HA_week4_cell1.Inlines.Add("18");
				this.HA_week4_cell2.Inlines.Add("19");
				this.HA_week4_cell3.Inlines.Add("20");
				this.HA_week4_cell4.Inlines.Add("21");
				this.HA_week4_cell5.Inlines.Add("22");
				this.HA_week4_cell6.Inlines.Add("23");
				this.HA_week4_cell7.Inlines.Add("24");
				this.HA_week5_cell1.Inlines.Add("25");
				this.HA_week5_cell2.Inlines.Add("26");
				this.HA_week5_cell3.Inlines.Add("27");
				this.HA_week5_cell4.Inlines.Add("28");
				string _29th5 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th5 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st5 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell5.Inlines.Add(_29th5);
				this.HA_week5_cell6.Inlines.Add(_30th5);
				this.HA_week5_cell7.Inlines.Add(_31st5);
				for (int m = 0; m <= gannTimeAnalysis.getFilteredDaylist.Count - 1; m++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 1)
					{
						this.HA_week1_cell5.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 2)
					{
						this.HA_week1_cell6.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 3)
					{
						this.HA_week1_cell7.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 4)
					{
						this.HA_week2_cell1.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 5)
					{
						this.HA_week2_cell2.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 6)
					{
						this.HA_week2_cell3.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 7)
					{
						this.HA_week2_cell4.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 8)
					{
						this.HA_week2_cell5.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 9)
					{
						this.HA_week2_cell6.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 10)
					{
						this.HA_week2_cell7.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 11)
					{
						this.HA_week3_cell1.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 12)
					{
						this.HA_week3_cell2.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 13)
					{
						this.HA_week3_cell3.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 14)
					{
						this.HA_week3_cell4.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 15)
					{
						this.HA_week3_cell5.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 16)
					{
						this.HA_week3_cell6.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 17)
					{
						this.HA_week3_cell7.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 18)
					{
						this.HA_week4_cell1.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 19)
					{
						this.HA_week4_cell2.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 20)
					{
						this.HA_week4_cell3.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 21)
					{
						this.HA_week4_cell4.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 22)
					{
						this.HA_week4_cell5.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 23)
					{
						this.HA_week4_cell6.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 24)
					{
						this.HA_week4_cell7.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 25)
					{
						this.HA_week5_cell1.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 26)
					{
						this.HA_week5_cell2.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 27)
					{
						this.HA_week5_cell3.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 28)
					{
						this.HA_week5_cell4.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 29)
					{
						this.HA_week5_cell5.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 30)
					{
						this.HA_week5_cell6.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(m) == 31)
					{
						this.HA_week5_cell7.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(m)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Friday")
			{
				this.HA_week1_cell6.Inlines.Add("1");
				this.HA_week1_cell7.Inlines.Add("2");
				this.HA_week2_cell1.Inlines.Add("3");
				this.HA_week2_cell2.Inlines.Add("4");
				this.HA_week2_cell3.Inlines.Add("5");
				this.HA_week2_cell4.Inlines.Add("6");
				this.HA_week2_cell5.Inlines.Add("7");
				this.HA_week2_cell6.Inlines.Add("8");
				this.HA_week2_cell7.Inlines.Add("9");
				this.HA_week3_cell1.Inlines.Add("10");
				this.HA_week3_cell2.Inlines.Add("11");
				this.HA_week3_cell3.Inlines.Add("12");
				this.HA_week3_cell4.Inlines.Add("13");
				this.HA_week3_cell5.Inlines.Add("14");
				this.HA_week3_cell6.Inlines.Add("15");
				this.HA_week3_cell7.Inlines.Add("16");
				this.HA_week4_cell1.Inlines.Add("17");
				this.HA_week4_cell2.Inlines.Add("18");
				this.HA_week4_cell3.Inlines.Add("19");
				this.HA_week4_cell4.Inlines.Add("20");
				this.HA_week4_cell5.Inlines.Add("21");
				this.HA_week4_cell6.Inlines.Add("22");
				this.HA_week4_cell7.Inlines.Add("23");
				this.HA_week5_cell1.Inlines.Add("24");
				this.HA_week5_cell2.Inlines.Add("25");
				this.HA_week5_cell3.Inlines.Add("26");
				this.HA_week5_cell4.Inlines.Add("27");
				this.HA_week5_cell5.Inlines.Add("28");
				string _29th6 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th6 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st6 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell6.Inlines.Add(_29th6);
				this.HA_week5_cell7.Inlines.Add(_30th6);
				this.HA_week6_cell1.Inlines.Add(_31st6);
				for (int n = 0; n <= gannTimeAnalysis.getFilteredDaylist.Count - 1; n++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 1)
					{
						this.HA_week1_cell6.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 2)
					{
						this.HA_week1_cell7.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 3)
					{
						this.HA_week2_cell1.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 4)
					{
						this.HA_week2_cell2.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 5)
					{
						this.HA_week2_cell3.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 6)
					{
						this.HA_week2_cell4.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 7)
					{
						this.HA_week2_cell5.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 8)
					{
						this.HA_week2_cell6.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 9)
					{
						this.HA_week2_cell7.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 10)
					{
						this.HA_week3_cell1.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 11)
					{
						this.HA_week3_cell2.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 12)
					{
						this.HA_week3_cell3.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 13)
					{
						this.HA_week3_cell4.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 14)
					{
						this.HA_week3_cell5.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 15)
					{
						this.HA_week3_cell6.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 16)
					{
						this.HA_week3_cell7.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 17)
					{
						this.HA_week4_cell1.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 18)
					{
						this.HA_week4_cell2.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 19)
					{
						this.HA_week4_cell3.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 20)
					{
						this.HA_week4_cell4.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 21)
					{
						this.HA_week4_cell5.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 22)
					{
						this.HA_week4_cell6.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 23)
					{
						this.HA_week4_cell7.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 24)
					{
						this.HA_week5_cell1.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 25)
					{
						this.HA_week5_cell2.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 26)
					{
						this.HA_week5_cell3.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 27)
					{
						this.HA_week5_cell4.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 28)
					{
						this.HA_week5_cell5.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 29)
					{
						this.HA_week5_cell6.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 30)
					{
						this.HA_week5_cell7.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(n) == 31)
					{
						this.HA_week6_cell1.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(n)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			else if (firstDayName == "Saturday")
			{
				this.HA_week1_cell7.Inlines.Add("1");
				this.HA_week2_cell1.Inlines.Add("2");
				this.HA_week2_cell2.Inlines.Add("3");
				this.HA_week2_cell3.Inlines.Add("4");
				this.HA_week2_cell4.Inlines.Add("5");
				this.HA_week2_cell5.Inlines.Add("6");
				this.HA_week2_cell6.Inlines.Add("7");
				this.HA_week2_cell7.Inlines.Add("8");
				this.HA_week3_cell1.Inlines.Add("9");
				this.HA_week3_cell2.Inlines.Add("10");
				this.HA_week3_cell3.Inlines.Add("11");
				this.HA_week3_cell4.Inlines.Add("12");
				this.HA_week3_cell5.Inlines.Add("13");
				this.HA_week3_cell6.Inlines.Add("14");
				this.HA_week3_cell7.Inlines.Add("15");
				this.HA_week4_cell1.Inlines.Add("16");
				this.HA_week4_cell2.Inlines.Add("17");
				this.HA_week4_cell3.Inlines.Add("18");
				this.HA_week4_cell4.Inlines.Add("19");
				this.HA_week4_cell5.Inlines.Add("20");
				this.HA_week4_cell6.Inlines.Add("21");
				this.HA_week4_cell7.Inlines.Add("22");
				this.HA_week5_cell1.Inlines.Add("23");
				this.HA_week5_cell2.Inlines.Add("24");
				this.HA_week5_cell3.Inlines.Add("25");
				this.HA_week5_cell4.Inlines.Add("26");
				this.HA_week5_cell5.Inlines.Add("27");
				this.HA_week5_cell6.Inlines.Add("28");
				string _29th7 = (lastDayOftheMonth >= 29) ? "29" : Convert.ToString("");
				string _30th7 = (lastDayOftheMonth >= 30) ? "30" : Convert.ToString("");
				string _31st7 = (lastDayOftheMonth == 31) ? "31" : Convert.ToString("");
				this.HA_week5_cell7.Inlines.Add(_29th7);
				this.HA_week6_cell1.Inlines.Add(_30th7);
				this.HA_week6_cell2.Inlines.Add(_31st7);
				for (int i2 = 0; i2 <= gannTimeAnalysis.getFilteredDaylist.Count - 1; i2++)
				{
					if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 1)
					{
						this.HA_week1_cell7.Background = ((1 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 2)
					{
						this.HA_week2_cell1.Background = ((2 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 3)
					{
						this.HA_week2_cell2.Background = ((3 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 4)
					{
						this.HA_week2_cell3.Background = ((4 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 5)
					{
						this.HA_week2_cell4.Background = ((5 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 6)
					{
						this.HA_week2_cell5.Background = ((6 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 7)
					{
						this.HA_week2_cell6.Background = ((7 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 8)
					{
						this.HA_week2_cell7.Background = ((8 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 9)
					{
						this.HA_week3_cell1.Background = ((9 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 10)
					{
						this.HA_week3_cell2.Background = ((10 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 11)
					{
						this.HA_week3_cell3.Background = ((11 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 12)
					{
						this.HA_week3_cell4.Background = ((12 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 13)
					{
						this.HA_week3_cell5.Background = ((13 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 14)
					{
						this.HA_week3_cell6.Background = ((14 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 15)
					{
						this.HA_week3_cell7.Background = ((15 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 16)
					{
						this.HA_week4_cell1.Background = ((16 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 17)
					{
						this.HA_week4_cell2.Background = ((17 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 18)
					{
						this.HA_week4_cell3.Background = ((18 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 19)
					{
						this.HA_week4_cell4.Background = ((19 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 20)
					{
						this.HA_week4_cell5.Background = ((20 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 21)
					{
						this.HA_week4_cell6.Background = ((21 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 22)
					{
						this.HA_week4_cell7.Background = ((22 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 23)
					{
						this.HA_week5_cell1.Background = ((23 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 24)
					{
						this.HA_week5_cell2.Background = ((24 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 25)
					{
						this.HA_week5_cell3.Background = ((25 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 26)
					{
						this.HA_week5_cell4.Background = ((26 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 27)
					{
						this.HA_week5_cell5.Background = ((27 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 28)
					{
						this.HA_week5_cell6.Background = ((28 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 29)
					{
						this.HA_week5_cell7.Background = ((29 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 30)
					{
						this.HA_week6_cell1.Background = ((30 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
					else if (gannTimeAnalysis.getFilteredDaylist.ElementAt(i2) == 31)
					{
						this.HA_week6_cell2.Background = ((31 == gannTimeAnalysis.getFilteredDaylist.ElementAt(i2)) ? Brushes.DeepSkyBlue : Brushes.White);
					}
				}
			}
			DateTimeFormatInfo dinfo = new DateTimeFormatInfo();
			this.dataGridLabel_highAngle.Content = dinfo.GetMonthName(sDT.Month) + " " + sDT.Year.ToString();
			this.dataGridLabel_highAngleAnalysis.Content = "- Analysis for " + Equtiy_Future.selectedSymbol + " -";
		}
	}
}
