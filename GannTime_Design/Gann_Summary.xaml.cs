using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace New_SF_IT.GannTime_Design
{
	// Token: 0x0200003C RID: 60
	public partial class Gann_Summary : UserControl
	{
		// Token: 0x060002ED RID: 749 RVA: 0x0005F5A7 File Offset: 0x0005D7A7
		public Gann_Summary()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0005F5B8 File Offset: 0x0005D7B8
		public void Initialize_Variable()
		{
			try
			{
				this.summaryCalendar();
			}
			catch
			{
				MessageBox.Show("Please Try again");
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0005F5EC File Offset: 0x0005D7EC
		private void summaryCalendar()
		{
			DateTime sDT = DateTime.Today;
			new DateTime(sDT.Year, sDT.Month, 1);
			int lastDayOftheMonth = DateTime.DaysInMonth(sDT.Year, sDT.Month);
			DateTimeFormatInfo dinfo = new DateTimeFormatInfo();
			this.dataGridLabel_summary.Content = dinfo.GetMonthName(sDT.Month) + " " + sDT.Year.ToString();
			this.dataGridLabel_summaryAnalysis.Content = "- Analysis for " + Equtiy_Future.selectedSymbol + " -";
			this.DaysGridLastMonth.Children.Clear();
			this.DaysGridLastMonth.RowDefinitions.Clear();
			int rowIndex = 0;
			for (int dayLastMonth = 1; dayLastMonth <= lastDayOftheMonth; dayLastMonth++)
			{
				List<string> angles = new List<string>();
				if (gannTimeAnalysis.lowDaysList.Contains(dayLastMonth))
				{
					angles.Add("Low Angle");
				}
				if (gannTimeAnalysis.highDaysList.Contains(dayLastMonth))
				{
					angles.Add("High Angle");
				}
				if (gannTimeAnalysis.staticDaysList.Contains(dayLastMonth))
				{
					angles.Add("Static Angle");
				}
				if (gannTimeAnalysis.gannDaysList.Contains(dayLastMonth))
				{
					angles.Add("Gann Angle");
				}
				if (gannTimeAnalysis.HLSDaysList.Contains(dayLastMonth))
				{
					angles.Add("High to Low Angle");
				}
				if (gannTimeAnalysis.HexaDaysList.Contains(dayLastMonth))
				{
					angles.Add("Hexagon Angle");
				}
				if (gannTimeAnalysis.priceDaysList.Contains(dayLastMonth))
				{
					angles.Add("Price Time");
				}
				if (gannTimeAnalysis.pricerangeDaysList.Contains(dayLastMonth))
				{
					angles.Add("Price Range");
				}
				if (angles.Any<string>())
				{
					this.DaysGridLastMonth.RowDefinitions.Add(new RowDefinition());
					TextBlock dayTextBlock = new TextBlock
					{
						Text = dayLastMonth.ToString(),
						FontWeight = FontWeights.Bold,
						HorizontalAlignment = HorizontalAlignment.Left,
						FontSize = 14.0,
						Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#27005D")),
						Margin = new Thickness(10.0, 4.0, 0.0, 0.0)
					};
					TextBlock anglesTextBlock = new TextBlock
					{
						Text = string.Join(", ", angles),
						FontWeight = FontWeights.Bold,
						HorizontalAlignment = HorizontalAlignment.Left,
						FontSize = 14.0,
						Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#27005D")),
						Margin = new Thickness(10.0, 4.0, 0.0, 0.0)
					};
					Grid.SetRow(dayTextBlock, rowIndex);
					Grid.SetColumn(dayTextBlock, 0);
					Grid.SetRow(anglesTextBlock, rowIndex);
					Grid.SetColumn(anglesTextBlock, 1);
					this.DaysGridLastMonth.Children.Add(dayTextBlock);
					this.DaysGridLastMonth.Children.Add(anglesTextBlock);
					rowIndex++;
				}
			}
		}
	}
}
