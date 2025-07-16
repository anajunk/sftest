using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace New_SF_IT.GannTime_Design
{
	// Token: 0x02000033 RID: 51
	[NullableContext(1)]
	[Nullable(0)]
	internal class gannTimeAnalysis
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00034150 File Offset: 0x00032350
		public static void lowAngle()
		{
			double high = Equtiy_Future.High;
			if (Equtiy_Future.High != 0.0)
			{
				double priceRange_degree = gannTimeAnalysis.degreeConversion(Equtiy_Future.High - Equtiy_Future.Low);
				double tradingDays_degree = gannTimeAnalysis.degreeConversion(Convert.ToDouble(Equtiy_Future.tradingDays));
				double calenderDays_degree = gannTimeAnalysis.degreeConversion(Convert.ToDouble(Equtiy_Future.calenderDays));
				double lowestDegree = new List<double>
				{
					priceRange_degree,
					tradingDays_degree,
					calenderDays_degree
				}.Min();
				List<string> filteredDates = new List<string>();
				gannTimeAnalysis.dateFilteration(1, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
				gannTimeAnalysis.dateFilteration(2, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
				gannTimeAnalysis.dateFilteration(3, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
				gannTimeAnalysis.dateFilteration(4, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
				gannTimeAnalysis.dateFilteration(5, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
				gannTimeAnalysis.lowDaysFiltering = true;
				gannTimeAnalysis.scrapeCalender(filteredDates);
				gannTimeAnalysis.lowDaysFiltering = false;
				List<string> filteredDates_NM = new List<string>();
				gannTimeAnalysis.dateFilteration_nextMonth(1, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
				gannTimeAnalysis.dateFilteration_nextMonth(2, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
				gannTimeAnalysis.dateFilteration_nextMonth(3, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
				gannTimeAnalysis.dateFilteration_nextMonth(4, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
				gannTimeAnalysis.dateFilteration_nextMonth(5, lowestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
				gannTimeAnalysis.lowDays_nextMonthFiltering = true;
				gannTimeAnalysis.compareMonthlyList_nextMonth(filteredDates_NM);
				gannTimeAnalysis.lowDays_nextMonthFiltering = false;
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000342BC File Offset: 0x000324BC
		public static void highAngle()
		{
			double priceRange_degree = gannTimeAnalysis.degreeConversion(Equtiy_Future.High - Equtiy_Future.Low);
			double tradingDays_degree = gannTimeAnalysis.degreeConversion(Convert.ToDouble(Equtiy_Future.tradingDays));
			double calenderDays_degree = gannTimeAnalysis.degreeConversion(Convert.ToDouble(Equtiy_Future.calenderDays));
			double highestDegree = new List<double>
			{
				priceRange_degree,
				tradingDays_degree,
				calenderDays_degree
			}.Max();
			List<string> filteredDates = new List<string>();
			gannTimeAnalysis.dateFilteration(1, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(2, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(3, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(4, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(5, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.highDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDates);
			gannTimeAnalysis.highDaysFiltering = false;
			List<string> filteredDates_NM = new List<string>();
			gannTimeAnalysis.dateFilteration_nextMonth(1, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(2, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(3, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(4, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(5, highestDegree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.highDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(filteredDates_NM);
			gannTimeAnalysis.highDays_nextMonthFiltering = false;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0003440C File Offset: 0x0003260C
		public static void staticAngle()
		{
			List<string> filteredDates = new List<string>();
			gannTimeAnalysis.N1to5(45.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(90.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(180.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(270.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(360.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.staticDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDates);
			gannTimeAnalysis.staticDaysFiltering = false;
			List<string> filteredDates_NM = new List<string>();
			gannTimeAnalysis.N1to5_NextMonth(45.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(90.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(180.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(270.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(360.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.staticDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(filteredDates_NM);
			gannTimeAnalysis.staticDays_nextMonthFiltering = false;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00034544 File Offset: 0x00032744
		public static void gannAngle()
		{
			List<string> filteredDates = new List<string>();
			gannTimeAnalysis.N1to5(15.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(45.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(75.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.N1to5(86.25, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.gannDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDates);
			gannTimeAnalysis.gannDaysFiltering = false;
			List<string> filteredDates_NM = new List<string>();
			gannTimeAnalysis.N1to5_NextMonth(15.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(45.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(75.0, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.N1to5_NextMonth(86.25, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.gannDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(filteredDates_NM);
			gannTimeAnalysis.gannDays_nextMonthFiltering = false;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0003464C File Offset: 0x0003284C
		public static void pricetime()
		{
			double high = Equtiy_Future.High;
			double priceRange = Equtiy_Future.Low;
			double Pdegree = gannTimeAnalysis.degre(high);
			double Pdegree2 = gannTimeAnalysis.degre(priceRange);
			double TDdegree = gannTimeAnalysis.degre(Convert.ToDouble(Equtiy_Future.tradingDays));
			double CDdegree = gannTimeAnalysis.degre(Convert.ToDouble(Equtiy_Future.calenderDays));
			List<double> list = new List<double>();
			list.Add(TDdegree);
			list.Add(CDdegree);
			double lowestDegree = new List<double>
			{
				Pdegree,
				Pdegree2
			}.Min();
			double lowestDegree2 = list.Min();
			double degree0 = 2.0 + 2.0 * (lowestDegree / 365.0) + 1.25;
			degree0 = Math.Pow(degree0, 2.0);
			double degree = 4.0 + 2.0 * (lowestDegree / 365.0) + 1.25;
			degree = Math.Pow(degree, 2.0);
			double degree2 = 6.0 + 2.0 * (lowestDegree / 365.0) + 1.25;
			degree2 = Math.Pow(degree2, 2.0);
			double degree3 = 8.0 + 2.0 * (lowestDegree / 365.0) + 1.25;
			degree3 = Math.Pow(degree3, 2.0);
			double degree4 = 2.0 + 2.0 * (lowestDegree2 / 365.0) + 1.25;
			degree4 = Math.Pow(degree4, 2.0);
			double degree5 = 4.0 + 2.0 * (lowestDegree2 / 365.0) + 1.25;
			degree5 = Math.Pow(degree5, 2.0);
			double degree6 = 6.0 + 2.0 * (lowestDegree2 / 365.0) + 1.25;
			degree6 = Math.Pow(degree6, 2.0);
			double degree7 = 8.0 + 2.0 * (lowestDegree2 / 365.0) + 1.25;
			degree7 = Math.Pow(degree7, 2.0);
			List<double> list2 = new List<double>();
			list2.Add(degree0);
			list2.Add(degree);
			list2.Add(degree2);
			list2.Add(degree3);
			list2.Add(degree4);
			list2.Add(degree5);
			list2.Add(degree6);
			list2.Add(degree7);
			double fun = list2[0];
			double fun2 = list2[1];
			double fun3 = list2[2];
			double fun4 = list2[3];
			double fun5 = list2[4];
			double fun6 = list2[5];
			double fun7 = list2[6];
			double degrees = list2[7];
			List<string> filteredDat = new List<string>();
			gannTimeAnalysis.filterdat(fun, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(fun7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.filterdat(degrees, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDat);
			gannTimeAnalysis.PriceDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDat);
			gannTimeAnalysis.PriceDaysFiltering = false;
			List<string> _filteredDat_NM = new List<string>();
			gannTimeAnalysis.filterdat1(fun, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(fun7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.filterdat1(degrees, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDat_NM);
			gannTimeAnalysis.PriceDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(_filteredDat_NM);
			gannTimeAnalysis.PriceDays_nextMonthFiltering = false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00034AA4 File Offset: 0x00032CA4
		public static void pricerange()
		{
			double PRdegree = gannTimeAnalysis.degre(Equtiy_Future.High - Equtiy_Future.Low);
			double TDdegree = gannTimeAnalysis.degre(Convert.ToDouble(Equtiy_Future.tradingDays));
			double CDdegree = gannTimeAnalysis.degre(Convert.ToDouble(Equtiy_Future.calenderDays));
			List<double> list = new List<double>();
			list.Add(PRdegree);
			list.Add(TDdegree);
			list.Add(CDdegree);
			double lowestDegre = list.Min();
			double highestDegre = list.Max();
			double degree0 = 2.0 + 2.0 * (highestDegre / 365.0) + 1.25;
			degree0 = Math.Pow(degree0, 2.0);
			double degree = 4.0 + 2.0 * (highestDegre / 365.0) + 1.25;
			degree = Math.Pow(degree, 2.0);
			double degree2 = 6.0 + 2.0 * (highestDegre / 365.0) + 1.25;
			degree2 = Math.Pow(degree2, 2.0);
			double degree3 = 8.0 + 2.0 * (highestDegre / 365.0) + 1.25;
			degree3 = Math.Pow(degree3, 2.0);
			double degree4 = 2.0 + 2.0 * (lowestDegre / 365.0) + 1.25;
			degree4 = Math.Pow(degree4, 2.0);
			double degree5 = 4.0 + 2.0 * (lowestDegre / 365.0) + 1.25;
			degree5 = Math.Pow(degree5, 2.0);
			double degree6 = 6.0 + 2.0 * (lowestDegre / 365.0) + 1.25;
			degree6 = Math.Pow(degree6, 2.0);
			double degree7 = 8.0 + 2.0 * (lowestDegre / 365.0) + 1.25;
			degree7 = Math.Pow(degree7, 2.0);
			List<double> list2 = new List<double>();
			list2.Add(degree0);
			list2.Add(degree);
			list2.Add(degree2);
			list2.Add(degree3);
			list2.Add(degree4);
			list2.Add(degree5);
			list2.Add(degree6);
			list2.Add(degree7);
			double deg = list2[0];
			double deg2 = list2[1];
			double deg3 = list2[2];
			double deg4 = list2[3];
			double deg5 = list2[4];
			double deg6 = list2[5];
			double deg7 = list2[6];
			double deg8 = list2[7];
			List<string> filtered = new List<string>();
			gannTimeAnalysis.filterd(deg, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.filterd(deg7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filtered);
			gannTimeAnalysis.PricerangeDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filtered);
			gannTimeAnalysis.PricerangeDaysFiltering = false;
			List<string> _filtered_NM = new List<string>();
			gannTimeAnalysis.filterd1(deg, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.filterd1(deg8, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filtered_NM);
			gannTimeAnalysis.PricerangeDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(_filtered_NM);
			gannTimeAnalysis.PricerangeDays_nextMonthFiltering = false;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00034EE4 File Offset: 0x000330E4
		public static void HexaAngle()
		{
			double priceRange_degree = gannTimeAnalysis.degree(Equtiy_Future.High - Equtiy_Future.Low);
			double tradingDays_degree = gannTimeAnalysis.degree(Convert.ToDouble(Equtiy_Future.tradingDays));
			double calenderDays_degree = gannTimeAnalysis.degree(Convert.ToDouble(Equtiy_Future.calenderDays));
			List<double> list = new List<double>();
			list.Add(priceRange_degree);
			list.Add(tradingDays_degree);
			list.Add(calenderDays_degree);
			double PRdegree0 = (priceRange_degree + 0.0 + 180.0) / 210.0;
			PRdegree0 = Math.Pow(PRdegree0, 2.0);
			double PRdegree = (priceRange_degree + 360.0 + 180.0) / 210.0;
			PRdegree = Math.Pow(PRdegree, 2.0);
			double PRdegree2 = (priceRange_degree + 720.0 + 180.0) / 210.0;
			PRdegree2 = Math.Pow(PRdegree2, 2.0);
			double PRdegree3 = (priceRange_degree + 1080.0 + 180.0) / 210.0;
			PRdegree3 = Math.Pow(PRdegree3, 2.0);
			double PRdegree4 = (priceRange_degree + 1440.0 + 180.0) / 210.0;
			PRdegree4 = Math.Pow(PRdegree4, 2.0);
			double PRdegree5 = (priceRange_degree + 1800.0 + 180.0) / 210.0;
			PRdegree5 = Math.Pow(PRdegree5, 2.0);
			double PRdegree6 = (priceRange_degree + 2160.0 + 180.0) / 210.0;
			PRdegree6 = Math.Pow(PRdegree6, 2.0);
			double PRdegree7 = (priceRange_degree + 2520.0 + 180.0) / 210.0;
			PRdegree7 = Math.Pow(PRdegree7, 2.0);
			double PRdegree8 = (priceRange_degree + 2880.0 + 180.0) / 210.0;
			PRdegree8 = Math.Pow(PRdegree8, 2.0);
			double CDdegree0 = (calenderDays_degree + 0.0 + 180.0) / 210.0;
			CDdegree0 = Math.Pow(CDdegree0, 2.0);
			double CDdegree = (calenderDays_degree + 360.0 + 180.0) / 210.0;
			CDdegree = Math.Pow(CDdegree, 2.0);
			double CDdegree2 = (calenderDays_degree + 720.0 + 180.0) / 210.0;
			CDdegree2 = Math.Pow(CDdegree2, 2.0);
			double CDdegree3 = (calenderDays_degree + 1080.0 + 180.0) / 210.0;
			CDdegree3 = Math.Pow(CDdegree3, 2.0);
			double CDdegree4 = (calenderDays_degree + 1440.0 + 180.0) / 210.0;
			CDdegree4 = Math.Pow(CDdegree4, 2.0);
			double CDdegree5 = (calenderDays_degree + 1800.0 + 180.0) / 210.0;
			CDdegree5 = Math.Pow(CDdegree5, 2.0);
			double CDdegree6 = (calenderDays_degree + 2160.0 + 180.0) / 210.0;
			CDdegree6 = Math.Pow(CDdegree6, 2.0);
			double CDdegree7 = (calenderDays_degree + 2520.0 + 180.0) / 210.0;
			CDdegree7 = Math.Pow(CDdegree7, 2.0);
			double CDdegree8 = (calenderDays_degree + 2880.0 + 180.0) / 210.0;
			CDdegree8 = Math.Pow(CDdegree8, 2.0);
			double TDdegree0 = (tradingDays_degree + 0.0 + 180.0) / 210.0;
			TDdegree0 = Math.Pow(TDdegree0, 2.0);
			double TDdegree = (tradingDays_degree + 360.0 + 180.0) / 210.0;
			TDdegree = Math.Pow(TDdegree, 2.0);
			double TDdegree2 = (tradingDays_degree + 720.0 + 180.0) / 210.0;
			TDdegree2 = Math.Pow(TDdegree2, 2.0);
			double TDdegree3 = (tradingDays_degree + 1080.0 + 180.0) / 210.0;
			TDdegree3 = Math.Pow(TDdegree3, 2.0);
			double TDdegree4 = (tradingDays_degree + 1440.0 + 180.0) / 210.0;
			TDdegree4 = Math.Pow(TDdegree4, 2.0);
			double TDdegree5 = (tradingDays_degree + 1800.0 + 180.0) / 210.0;
			TDdegree5 = Math.Pow(TDdegree5, 2.0);
			double TDdegree6 = (tradingDays_degree + 2160.0 + 180.0) / 210.0;
			TDdegree6 = Math.Pow(TDdegree6, 2.0);
			double TDdegree7 = (tradingDays_degree + 2520.0 + 180.0) / 210.0;
			TDdegree7 = Math.Pow(TDdegree7, 2.0);
			double TDdegree8 = (tradingDays_degree + 2880.0 + 180.0) / 210.0;
			TDdegree8 = Math.Pow(TDdegree8, 2.0);
			List<double> list2 = new List<double>();
			list2.Add(PRdegree0);
			list2.Add(PRdegree);
			list2.Add(PRdegree2);
			list2.Add(PRdegree3);
			list2.Add(PRdegree4);
			list2.Add(PRdegree5);
			list2.Add(PRdegree6);
			list2.Add(PRdegree7);
			list2.Add(PRdegree8);
			list2.Add(TDdegree0);
			list2.Add(TDdegree);
			list2.Add(TDdegree2);
			list2.Add(TDdegree3);
			list2.Add(TDdegree4);
			list2.Add(TDdegree5);
			list2.Add(TDdegree6);
			list2.Add(TDdegree7);
			list2.Add(TDdegree8);
			list2.Add(CDdegree0);
			list2.Add(CDdegree);
			list2.Add(CDdegree2);
			list2.Add(CDdegree3);
			list2.Add(CDdegree4);
			list2.Add(CDdegree5);
			list2.Add(CDdegree6);
			list2.Add(CDdegree7);
			list2.Add(CDdegree8);
			double degree = list2[0];
			double degree2 = list2[1];
			double degree3 = list2[2];
			double degree4 = list2[3];
			double degree5 = list2[4];
			double degree6 = list2[5];
			double degree7 = list2[6];
			double degree8 = list2[7];
			double degree9 = list2[8];
			double degree10 = list2[9];
			double degree11 = list2[10];
			double degree12 = list2[11];
			double degree13 = list2[12];
			double degree14 = list2[13];
			double degree15 = list2[14];
			double degree16 = list2[15];
			double degree17 = list2[16];
			double degree18 = list2[17];
			double degree19 = list2[18];
			double degree20 = list2[19];
			double degree21 = list2[20];
			double degree22 = list2[21];
			double degree23 = list2[22];
			double degree24 = list2[23];
			double degree25 = list2[24];
			double degree26 = list2[25];
			double degrees = list2[26];
			List<string> filteredDate = new List<string>();
			gannTimeAnalysis.filterdates(degree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree8, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree9, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree10, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree11, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree12, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree13, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree14, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree10, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree11, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree12, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree13, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree14, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree15, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree16, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree17, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree18, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree19, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree20, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree21, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree22, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree23, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree24, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree25, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degree26, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.filterdates(degrees, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDate);
			gannTimeAnalysis.HexaDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDate);
			gannTimeAnalysis.HexaDaysFiltering = false;
			List<string> _filteredDates_NM = new List<string>();
			gannTimeAnalysis.filterdates1(degree, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree2, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree3, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree4, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree5, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree6, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree7, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree8, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree9, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree10, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree11, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree12, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree13, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree14, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree10, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree11, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree12, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree13, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree14, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree15, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree16, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree17, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree18, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree19, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree20, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree21, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree22, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree23, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree24, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree25, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degree26, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.filterdates1(degrees, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, _filteredDates_NM);
			gannTimeAnalysis.HexaDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(_filteredDates_NM);
			gannTimeAnalysis.HexaDays_nextMonthFiltering = false;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00035B68 File Offset: 0x00033D68
		public static void HLSquaring()
		{
			double angle = Equtiy_Future.High / Equtiy_Future.Low * 180.0;
			if (angle > 180.0)
			{
				angle -= 180.0;
			}
			List<string> filteredDates = new List<string>();
			gannTimeAnalysis.dateFilteration(1, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(2, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(3, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(4, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.dateFilteration(5, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates);
			gannTimeAnalysis.HLSDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDates);
			gannTimeAnalysis.HLSDaysFiltering = false;
			List<string> filteredDates_NM = new List<string>();
			gannTimeAnalysis.dateFilteration_nextMonth(1, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(2, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(3, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(4, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.dateFilteration_nextMonth(5, angle, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, filteredDates_NM);
			gannTimeAnalysis.HLSDays_nextMonthFiltering = true;
			gannTimeAnalysis.compareMonthlyList_nextMonth(filteredDates_NM);
			gannTimeAnalysis.HLSDays_nextMonthFiltering = false;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00035C88 File Offset: 0x00033E88
		public static void fibonacci()
		{
			List<double> historicLTP = new List<double>();
			string constructURL = string.Empty;
			if (Equtiy_Future.selectedInstrument == "STOCK FUTURE")
			{
				constructURL = string.Format(gannTimeAnalysis.futureClosingPriceUrl, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, Equtiy_Future.selectedSymbol);
			}
			else if (Equtiy_Future.selectedInstrument == "INDEX FUTURE")
			{
				constructURL = string.Format(gannTimeAnalysis.indexClosingPriceUrl, Equtiy_Future.HighFormationDate, Equtiy_Future.LowFormationDate, Equtiy_Future.selectedSymbol);
			}
			historicLTP = dataScrapping.get_historicLTP(dataScrapping.downloadData(constructURL), historicLTP);
			double priceRange = gannHelper.Volatility(historicLTP) * Math.Sqrt(7.0) * Equtiy_Future.Low;
			double newPriceRange_refLow = priceRange + Equtiy_Future.Low;
			double newPriceRange_refHigh = Equtiy_Future.High - priceRange;
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (Equtiy_Future.selectedInstrument == "STOCK FUTURE")
			{
				string _selectedSymbol = Equtiy_Future.selectedSymbol.Replace("&", "%26");
				dataScrapping.get_historicData_STKFUT(dataScrapping.downloadData(string.Format(gannTimeAnalysis.futureEqHistoricUrl, _selectedSymbol)));
			}
			else if (Equtiy_Future.selectedInstrument == "INDEX FUTURE")
			{
				string indexSymbol = string.Empty;
				if (Equtiy_Future.selectedSymbol.Equals("NIFTY"))
				{
					indexSymbol = "NIFTY%2050";
				}
				else if (Equtiy_Future.selectedSymbol.Equals("BANKNIFTY"))
				{
					indexSymbol = "NIFTY%20BANK";
				}
				string toDate = DateTime.Now.ToString("dd-MM-yyyy");
				string fromDate = Convert.ToDateTime(gannTimeAnalysis.addDaysToDate(-90.0, toDate)).ToString("dd-MM-yyyy");
				dataScrapping.get_historicData_IDXFUT(dataScrapping.downloadData(string.Format(gannTimeAnalysis.indexEqHistoricUrl, indexSymbol, fromDate, toDate)));
			}
			List<double> highPrices = new List<double>();
			List<string> highDates = new List<string>();
			if (Equtiy_Future.selectedTime == "Trailing One Month")
			{
				highPrices = dataScrapping.trailingHighPrice;
				highDates = dataScrapping.trailingHighDate;
			}
			else if (Equtiy_Future.selectedTime == "Previous Month")
			{
				highPrices = dataScrapping.previousHighPrice;
				highDates = dataScrapping.previousHighDate;
			}
			int lowerDateLoopIndex = dataScrapping.findLowerDateLoopIndex(Equtiy_Future.LowFormationDate, Equtiy_Future.HighFormationDate, highDates);
			double noOfDays = 0.0;
			string newHighFormationDate = null;
			for (int i = lowerDateLoopIndex; i <= highPrices.Count - 1; i++)
			{
				if (highPrices[i] > newPriceRange_refLow)
				{
					noOfDays = (double)(i + 1);
					newHighFormationDate = highDates[i];
					newHighFormationDate = newHighFormationDate.Replace("-", "");
					break;
				}
			}
			if (noOfDays == 0.0)
			{
				for (int j = lowerDateLoopIndex; j <= highPrices.Count - 1; j++)
				{
					if (highPrices[j] > newPriceRange_refHigh)
					{
						noOfDays = (double)(j + 1);
						newHighFormationDate = highDates[j];
						newHighFormationDate = newHighFormationDate.Replace("-", "");
						break;
					}
				}
			}
			double day = 0.618 * noOfDays;
			double ratio2Value = 1.0 * noOfDays;
			double ratio3Value = 1.236 * noOfDays;
			double ratio4Value = 1.618 * noOfDays;
			List<string> filteredDateList = new List<string>();
			gannTimeAnalysis.filterDatesForFibonacci(day, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList);
			gannTimeAnalysis.filterDatesForFibonacci(ratio2Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList);
			gannTimeAnalysis.filterDatesForFibonacci(ratio3Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList);
			gannTimeAnalysis.filterDatesForFibonacci(ratio4Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList);
			gannTimeAnalysis.fiboDaysFiltering = true;
			gannTimeAnalysis.scrapeCalender(filteredDateList);
			gannTimeAnalysis.fiboDaysFiltering = false;
			List<string> filteredDateList_NM = new List<string>();
			gannTimeAnalysis.filterDatesForFibonacci_nextMonth(day, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList_NM);
			gannTimeAnalysis.filterDatesForFibonacci_nextMonth(ratio2Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList_NM);
			gannTimeAnalysis.filterDatesForFibonacci_nextMonth(ratio3Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList_NM);
			gannTimeAnalysis.filterDatesForFibonacci_nextMonth(ratio4Value, newHighFormationDate, Equtiy_Future.LowFormationDate, filteredDateList_NM);
			gannTimeAnalysis.fiboDays_nextMonthFiltering = true;
			gannTimeAnalysis.scrapeCalender_nextMonth(filteredDateList_NM);
			gannTimeAnalysis.fiboDays_nextMonthFiltering = false;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0003601E File Offset: 0x0003421E
		public static double degreeConversion(double getValue)
		{
			return (Math.Sqrt(getValue) * 180.0 - 225.0) % 360.0;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00036044 File Offset: 0x00034244
		public static double degree(double getValue)
		{
			return (210.0 * Math.Sqrt(getValue) - 180.0) % 360.0;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0003606A File Offset: 0x0003426A
		public static double degre(double getValue)
		{
			return (Math.Sqrt(getValue) * 180.0 - 225.0) % 360.0;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00036090 File Offset: 0x00034290
		public static void filterd(double deg1, string highFormationDate, string lowFormationDate, List<string> filteredDate1)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(deg1, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(deg1, lowFormationDate);
			string date = gannTimeAnalysis.currentMonthDateFilteration(getDate);
			if (date != null)
			{
				filteredDate1.Add(date);
			}
			string date2 = gannTimeAnalysis.currentMonthDateFilteration(lowDate);
			if (date2 != null)
			{
				filteredDate1.Add(date2);
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000360D0 File Offset: 0x000342D0
		public static void filterd1(double deg1, string highFormationDate, string lowFormationDate, List<string> _filteredDates1_NM)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(deg1, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(deg1, lowFormationDate);
			string date1_NM = gannTimeAnalysis.nextMonthDateFilteration(getDate);
			if (date1_NM != null)
			{
				_filteredDates1_NM.Add(date1_NM);
			}
			string date2_NM = gannTimeAnalysis.nextMonthDateFilteration(lowDate);
			if (date2_NM != null)
			{
				_filteredDates1_NM.Add(date2_NM);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00036110 File Offset: 0x00034310
		public static void filterdat(double degrees1, string highFormationDate, string lowFormationDate, List<string> filteredDate1)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(degrees1, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(degrees1, lowFormationDate);
			string date = gannTimeAnalysis.currentMonthDateFilteration(getDate);
			if (date != null)
			{
				filteredDate1.Add(date);
			}
			string date2 = gannTimeAnalysis.currentMonthDateFilteration(lowDate);
			if (date2 != null)
			{
				filteredDate1.Add(date2);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00036150 File Offset: 0x00034350
		public static void filterdat1(double degrees1, string highFormationDate, string lowFormationDate, List<string> _filteredDates1_NM)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(degrees1, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(degrees1, lowFormationDate);
			string date1_NM = gannTimeAnalysis.nextMonthDateFilteration(getDate);
			if (date1_NM != null)
			{
				_filteredDates1_NM.Add(date1_NM);
			}
			string date2_NM = gannTimeAnalysis.nextMonthDateFilteration(lowDate);
			if (date2_NM != null)
			{
				_filteredDates1_NM.Add(date2_NM);
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00036190 File Offset: 0x00034390
		public static void filterdates(double degrees, string highFormationDate, string lowFormationDate, List<string> filteredDate)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(degrees, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(degrees, lowFormationDate);
			string date = gannTimeAnalysis.currentMonthDateFilteration(getDate);
			if (date != null)
			{
				filteredDate.Add(date);
			}
			string date2 = gannTimeAnalysis.currentMonthDateFilteration(lowDate);
			if (date2 != null)
			{
				filteredDate.Add(date2);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000361D0 File Offset: 0x000343D0
		public static void filterdates1(double degrees, string highFormationDate, string lowFormationDate, List<string> _filteredDates_NM)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(degrees, highFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(degrees, lowFormationDate);
			string date1_NM = gannTimeAnalysis.nextMonthDateFilteration(getDate);
			if (date1_NM != null)
			{
				_filteredDates_NM.Add(date1_NM);
			}
			string date2_NM = gannTimeAnalysis.nextMonthDateFilteration(lowDate);
			if (date2_NM != null)
			{
				_filteredDates_NM.Add(date2_NM);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00036210 File Offset: 0x00034410
		public static void dateFilteration(int N, double _Degree, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates)
		{
			double days = gannTimeAnalysis.timeAnalysis(N, _Degree);
			string highDate = gannTimeAnalysis.addDaysToDate(days, _HighFormationDate);
			string getDate = gannTimeAnalysis.addDaysToDate(days, _LowFormationDate);
			string date = gannTimeAnalysis.currentMonthDateFilteration(highDate);
			if (date != null)
			{
				_filteredDates.Add(date);
			}
			string date2 = gannTimeAnalysis.currentMonthDateFilteration(getDate);
			if (date2 != null)
			{
				_filteredDates.Add(date2);
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00036258 File Offset: 0x00034458
		public static void dateFilteration_nextMonth(int N, double _Degree, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates_NM)
		{
			double days = gannTimeAnalysis.timeAnalysis(N, _Degree);
			string highDate = gannTimeAnalysis.addDaysToDate(days, _HighFormationDate);
			string getDate = gannTimeAnalysis.addDaysToDate(days, _LowFormationDate);
			string date1_NM = gannTimeAnalysis.nextMonthDateFilteration(highDate);
			if (date1_NM != null)
			{
				_filteredDates_NM.Add(date1_NM);
			}
			string date2_NM = gannTimeAnalysis.nextMonthDateFilteration(getDate);
			if (date2_NM != null)
			{
				_filteredDates_NM.Add(date2_NM);
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000362A0 File Offset: 0x000344A0
		public static void filterDatesForFibonacci(double day, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(day, _HighFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(day, _LowFormationDate);
			string date = gannTimeAnalysis.currentMonthDateFilteration(getDate);
			if (date != null)
			{
				_filteredDates.Add(date);
			}
			string date2 = gannTimeAnalysis.currentMonthDateFilteration(lowDate);
			if (date2 != null)
			{
				_filteredDates.Add(date2);
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000362E0 File Offset: 0x000344E0
		public static void filterDatesForFibonacci_nextMonth(double day, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates)
		{
			string getDate = gannTimeAnalysis.addDaysToDate(day, _HighFormationDate);
			string lowDate = gannTimeAnalysis.addDaysToDate(day, _LowFormationDate);
			string date = gannTimeAnalysis.nextMonthDateFilteration(getDate);
			if (date != null)
			{
				_filteredDates.Add(date);
			}
			string date2 = gannTimeAnalysis.nextMonthDateFilteration(lowDate);
			if (date2 != null)
			{
				_filteredDates.Add(date2);
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0003631D File Offset: 0x0003451D
		public static double timeAnalysis(int day, double angle)
		{
			return Math.Pow((double)day * 2.0 + 2.0 * (angle / 360.0) + 1.25, 2.0);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0003635C File Offset: 0x0003455C
		public static string addDaysToDate(double days, string _FormationDate)
		{
			DateTime FormationDate = DateTime.Parse(_FormationDate).AddDays(days);
			return Convert.ToString(FormationDate);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00036380 File Offset: 0x00034580
		public static string currentMonthDateFilteration(string getDate)
		{
			DateTime systemDT = DateTime.Now;
			int month = systemDT.Month;
			int systemYear = systemDT.Year;
			DateTime DB_DT = DateTime.Parse(getDate);
			int DBmonth = DB_DT.Month;
			int DByear = DB_DT.Year;
			if (month == DBmonth && systemYear == DByear)
			{
				return getDate;
			}
			return null;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x000363C8 File Offset: 0x000345C8
		public static string nextMonthDateFilteration(string getDate)
		{
			DateTime nextM_sDT = DateTime.Today.AddMonths(1);
			int month = nextM_sDT.Month;
			int systemYear = nextM_sDT.Year;
			DateTime DB_DT = DateTime.Parse(getDate);
			int DBmonth = DB_DT.Month;
			int DByear = DB_DT.Year;
			if (month == DBmonth && systemYear == DByear)
			{
				return getDate;
			}
			return null;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00036418 File Offset: 0x00034618
		public static void scrapeCalender(List<string> _filteredDates)
		{
			int monthIndex = 0;
			string empty = string.Empty;
			List<int> dayList = new List<int>();
			DateTime now = DateTime.Now;
			DateTimeFormatInfo getMonthName = new DateTimeFormatInfo();
			if (_filteredDates != null)
			{
				for (int i = 0; i <= _filteredDates.Count - 1; i++)
				{
					DateTime iDT = DateTime.Parse(_filteredDates.ElementAt(i));
					int iDay = iDT.Day;
					monthIndex = iDT.Month;
					int yearIndex = iDT.Year;
					dayList.Add(iDay);
				}
				if (_filteredDates.Count != 0)
				{
					getMonthName.GetAbbreviatedMonthName(monthIndex);
				}
			}
			else
			{
				new List<int>();
				List<int> list = gannTimeAnalysis.returnCalenderDateToDisplay();
				monthIndex = list[0];
				int yearIndex = list[1];
				getMonthName.GetAbbreviatedMonthName(monthIndex);
			}
			gannTimeAnalysis.compareMonthlyList(_filteredDates);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000364C8 File Offset: 0x000346C8
		public static void scrapeCalender_nextMonth(List<string> _filteredDates_NM)
		{
			int monthIndex = 0;
			string empty = string.Empty;
			List<int> dayList = new List<int>();
			DateTime now = DateTime.Now;
			DateTimeFormatInfo getMonthName = new DateTimeFormatInfo();
			if (_filteredDates_NM != null)
			{
				for (int i = 0; i <= _filteredDates_NM.Count - 1; i++)
				{
					DateTime iDT = DateTime.Parse(_filteredDates_NM.ElementAt(i));
					int iDay = iDT.Day;
					monthIndex = iDT.Month;
					int yearIndex = iDT.Year;
					dayList.Add(iDay);
				}
				if (_filteredDates_NM.Count != 0)
				{
					getMonthName.GetAbbreviatedMonthName(monthIndex);
				}
			}
			else
			{
				new List<int>();
				List<int> list = gannTimeAnalysis.returnCalenderDateToDisplay();
				monthIndex = list[0];
				int yearIndex = list[1];
				getMonthName.GetAbbreviatedMonthName(monthIndex);
			}
			gannTimeAnalysis.compareMonthlyList_nextMonth(_filteredDates_NM);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00036578 File Offset: 0x00034778
		public static List<int> returnCalenderDateToDisplay()
		{
			DateTime systemDate = DateTime.Now;
			List<int> list = new List<int>();
			list[0] = Convert.ToInt32(systemDate.Month);
			list[1] = Convert.ToInt32(systemDate.Year);
			return list;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000365B8 File Offset: 0x000347B8
		private static void compareMonthlyList(List<string> _dayList)
		{
			gannTimeAnalysis.getFilteredDaylist = new List<int>();
			new List<string>();
			List<string> comparedList = new List<string>();
			for (int i = 0; i <= _dayList.Count - 1; i++)
			{
				string dayOnly = Convert.ToString(Convert.ToDateTime(_dayList.ElementAt(i)).Day);
				comparedList.Add(dayOnly);
			}
			var res = (from a in Equtiy_Future.monthlyDaysList
			join b in comparedList on a equals b
			select new
			{
				Matched = a,
				Index = Equtiy_Future.monthlyDaysList.IndexOf(a)
			}).ToList();
			for (int j = 0; j <= res.Count - 1; j++)
			{
				string a2 = res.ElementAt(j).Matched.ToString();
				gannTimeAnalysis.getFilteredDaylist.Add(Convert.ToInt32(a2));
				if (gannTimeAnalysis.lowDaysFiltering)
				{
					gannTimeAnalysis.lowDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.highDaysFiltering)
				{
					gannTimeAnalysis.highDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.staticDaysFiltering)
				{
					gannTimeAnalysis.staticDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.gannDaysFiltering)
				{
					gannTimeAnalysis.gannDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.fiboDaysFiltering)
				{
					gannTimeAnalysis.fiboDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.HLSDaysFiltering)
				{
					gannTimeAnalysis.HLSDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.HexaDaysFiltering)
				{
					gannTimeAnalysis.HexaDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.PriceDaysFiltering)
				{
					gannTimeAnalysis.priceDaysList.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.PricerangeDaysFiltering)
				{
					gannTimeAnalysis.pricerangeDaysList.Add(Convert.ToInt32(a2));
				}
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000367B8 File Offset: 0x000349B8
		private static void compareMonthlyList_nextMonth(List<string> _dayList)
		{
			gannTimeAnalysis.getFilteredDaylist_nextMonth = new List<int>();
			new List<string>();
			List<string> comparedList = new List<string>();
			for (int i = 0; i <= _dayList.Count - 1; i++)
			{
				string dayOnly = Convert.ToString(Convert.ToDateTime(_dayList.ElementAt(i)).Day);
				comparedList.Add(dayOnly);
			}
			var res = (from a in Equtiy_Future.monthlyDaysList
			join b in comparedList on a equals b
			select new
			{
				Matched = a,
				Index = Equtiy_Future.monthlyDaysList.IndexOf(a)
			}).ToList();
			for (int j = 0; j <= res.Count - 1; j++)
			{
				string a2 = res.ElementAt(j).Matched.ToString();
				gannTimeAnalysis.getFilteredDaylist_nextMonth.Add(Convert.ToInt32(a2));
				if (gannTimeAnalysis.lowDays_nextMonthFiltering)
				{
					gannTimeAnalysis.lowDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.highDays_nextMonthFiltering)
				{
					gannTimeAnalysis.highDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.staticDays_nextMonthFiltering)
				{
					gannTimeAnalysis.staticDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.gannDays_nextMonthFiltering)
				{
					gannTimeAnalysis.gannDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.fiboDays_nextMonthFiltering)
				{
					gannTimeAnalysis.fiboDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.HLSDays_nextMonthFiltering)
				{
					gannTimeAnalysis.HLSDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.HexaDays_nextMonthFiltering)
				{
					gannTimeAnalysis.HexaDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.PriceDays_nextMonthFiltering)
				{
					gannTimeAnalysis.priceDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
				else if (gannTimeAnalysis.PricerangeDays_nextMonthFiltering)
				{
					gannTimeAnalysis.pricerangeDaysList_nextMonth.Add(Convert.ToInt32(a2));
				}
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000369B5 File Offset: 0x00034BB5
		private static void N1to5(double _degree, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates)
		{
			gannTimeAnalysis.dateFilteration(1, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration(2, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration(3, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration(4, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration(5, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000369E9 File Offset: 0x00034BE9
		private static void N1to5_NextMonth(double _degree, string _HighFormationDate, string _LowFormationDate, List<string> _filteredDates)
		{
			gannTimeAnalysis.dateFilteration_nextMonth(1, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration_nextMonth(2, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration_nextMonth(3, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration_nextMonth(4, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
			gannTimeAnalysis.dateFilteration_nextMonth(5, _degree, _HighFormationDate, _LowFormationDate, _filteredDates);
		}

		// Token: 0x0400061C RID: 1564
		public static List<int> getFilteredDaylist;

		// Token: 0x0400061D RID: 1565
		public static bool lowDaysFiltering = false;

		// Token: 0x0400061E RID: 1566
		public static bool highDaysFiltering = false;

		// Token: 0x0400061F RID: 1567
		public static bool staticDaysFiltering = false;

		// Token: 0x04000620 RID: 1568
		public static bool gannDaysFiltering = false;

		// Token: 0x04000621 RID: 1569
		public static bool HLSDaysFiltering = false;

		// Token: 0x04000622 RID: 1570
		public static bool fiboDaysFiltering = false;

		// Token: 0x04000623 RID: 1571
		public static bool HexaDaysFiltering = false;

		// Token: 0x04000624 RID: 1572
		public static bool PriceDaysFiltering = false;

		// Token: 0x04000625 RID: 1573
		public static bool PricerangeDaysFiltering = false;

		// Token: 0x04000626 RID: 1574
		public static bool lowDays_nextMonthFiltering = false;

		// Token: 0x04000627 RID: 1575
		public static bool highDays_nextMonthFiltering = false;

		// Token: 0x04000628 RID: 1576
		public static bool staticDays_nextMonthFiltering = false;

		// Token: 0x04000629 RID: 1577
		public static bool gannDays_nextMonthFiltering = false;

		// Token: 0x0400062A RID: 1578
		public static bool HLSDays_nextMonthFiltering = false;

		// Token: 0x0400062B RID: 1579
		public static bool fiboDays_nextMonthFiltering = false;

		// Token: 0x0400062C RID: 1580
		public static bool HexaDays_nextMonthFiltering = false;

		// Token: 0x0400062D RID: 1581
		public static bool PriceDays_nextMonthFiltering = false;

		// Token: 0x0400062E RID: 1582
		public static bool PricerangeDays_nextMonthFiltering = false;

		// Token: 0x0400062F RID: 1583
		public static List<int> lowDaysList = new List<int>();

		// Token: 0x04000630 RID: 1584
		public static List<int> highDaysList = new List<int>();

		// Token: 0x04000631 RID: 1585
		public static List<int> staticDaysList = new List<int>();

		// Token: 0x04000632 RID: 1586
		public static List<int> gannDaysList = new List<int>();

		// Token: 0x04000633 RID: 1587
		public static List<int> HLSDaysList = new List<int>();

		// Token: 0x04000634 RID: 1588
		public static List<int> HexaDaysList = new List<int>();

		// Token: 0x04000635 RID: 1589
		public static List<int> fiboDaysList = new List<int>();

		// Token: 0x04000636 RID: 1590
		public static List<int> priceDaysList = new List<int>();

		// Token: 0x04000637 RID: 1591
		public static List<int> pricerangeDaysList = new List<int>();

		// Token: 0x04000638 RID: 1592
		public static List<int> getFilteredDaylist_nextMonth;

		// Token: 0x04000639 RID: 1593
		public static List<int> lowDaysList_nextMonth = new List<int>();

		// Token: 0x0400063A RID: 1594
		public static List<int> highDaysList_nextMonth = new List<int>();

		// Token: 0x0400063B RID: 1595
		public static List<int> staticDaysList_nextMonth = new List<int>();

		// Token: 0x0400063C RID: 1596
		public static List<int> gannDaysList_nextMonth = new List<int>();

		// Token: 0x0400063D RID: 1597
		public static List<int> HLSDaysList_nextMonth = new List<int>();

		// Token: 0x0400063E RID: 1598
		public static List<int> HexaDaysList_nextMonth = new List<int>();

		// Token: 0x0400063F RID: 1599
		public static List<int> fiboDaysList_nextMonth = new List<int>();

		// Token: 0x04000640 RID: 1600
		public static List<int> priceDaysList_nextMonth = new List<int>();

		// Token: 0x04000641 RID: 1601
		public static List<int> pricerangeDaysList_nextMonth = new List<int>();

		// Token: 0x04000642 RID: 1602
		private static string[] KEYTODIVIDE = new string[]
		{
			"\",\""
		};

		// Token: 0x04000643 RID: 1603
		public static string futureClosingPriceUrl = "https://smartfinance.in/PHPusedForSoftwares/gann/fiboTimeAnalysis/futureClosingPriceDownload.php?highDate={0}&lowDate={1}&script={2}";

		// Token: 0x04000644 RID: 1604
		public static string indexClosingPriceUrl = "https://smartfinance.in/PHPusedForSoftwares/gann/fiboTimeAnalysis/indexClosingPriceDownload.php?highDate={0}&lowDate={1}&script={2}";

		// Token: 0x04000645 RID: 1605
		public static string futureEqHistoricUrl = "https://www.nseindia.com/products/dynaContent/common/productsSymbolMapping.jsp?symbol={0}&segmentLink=3&symbolCount=2&series=EQ&dateRange=3month&fromDate=&toDate=&dataType=PRICEVOLUMEDELIVERABLE";

		// Token: 0x04000646 RID: 1606
		public static string indexEqHistoricUrl = "https://www.nseindia.com/products/dynaContent/equities/indices/historicalindices.jsp?indexType={0}&fromDate={1}&toDate={2}";
	}
}
