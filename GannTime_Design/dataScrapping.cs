using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows;
using HtmlAgilityPack;

namespace New_SF_IT.GannTime_Design
{
	// Token: 0x02000031 RID: 49
	[NullableContext(1)]
	[Nullable(0)]
	internal class dataScrapping
	{
		// Token: 0x06000289 RID: 649 RVA: 0x00033748 File Offset: 0x00031948
		public static string downloadData(string url)
		{
			string responseString = string.Empty;
			using (HttpClient client = new HttpClient(new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
			}))
			{
				client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
				client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				responseString = client.GetStringAsync(url).Result;
			}
			return responseString;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000337E8 File Offset: 0x000319E8
		public static List<double> get_historicLTP(string downloadedData, List<double> _historicLTP)
		{
			if (downloadedData != null)
			{
				HtmlDocument _htmlDoc = new HtmlDocument();
				_htmlDoc.LoadHtml(downloadedData);
				string innerElement = _htmlDoc.GetElementbyId("totalNumberOfClosingPrice").InnerHtml;
				int loopEnd = Convert.ToInt32(innerElement);
				_historicLTP = new List<double>();
				for (int i = 0; i <= loopEnd - 1; i++)
				{
					innerElement = _htmlDoc.GetElementbyId("closingPrice" + i.ToString()).InnerHtml;
					if (innerElement != "")
					{
						double iValue = Convert.ToDouble(innerElement);
						_historicLTP.Add(iValue);
					}
				}
			}
			return _historicLTP;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00033870 File Offset: 0x00031A70
		public static void get_historicData_STKFUT(string _downloadedData)
		{
			HtmlDocument htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(_downloadedData);
			HtmlNodeCollection rows = htmlDocument.DocumentNode.SelectSingleNode("//table").SelectNodes(".//tr");
			List<string> _60DaysDateList = new List<string>();
			List<double> _60DaysHigh = new List<double>();
			for (int i = 1; i <= rows.Count - 1; i++)
			{
				HtmlNode htmlNode = rows.ElementAt(i);
				string date = htmlNode.SelectNodes("td").ElementAt(2).InnerText;
				string highest = htmlNode.SelectNodes("td").ElementAt(5).InnerText.Replace(",", "");
				_60DaysDateList.Add(date);
				_60DaysHigh.Add(Convert.ToDouble(highest));
			}
			dataScrapping.trailingAndPreviousMonthDataScarping(_60DaysDateList, _60DaysHigh);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00033924 File Offset: 0x00031B24
		public static void get_historicData_IDXFUT(string _downloadedData)
		{
			HtmlDocument htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(_downloadedData);
			HtmlNodeCollection rows = htmlDocument.DocumentNode.SelectSingleNode("//table").SelectNodes(".//tr");
			List<string> _60DaysDateList = new List<string>();
			List<double> _60DaysHigh = new List<double>();
			for (int i = 3; i <= rows.Count - 2; i++)
			{
				HtmlNode htmlNode = rows.ElementAt(i);
				string date = htmlNode.SelectNodes("td").ElementAt(0).InnerText;
				string highest = htmlNode.SelectNodes("td").ElementAt(2).InnerText.Replace(",", "");
				_60DaysDateList.Add(date);
				_60DaysHigh.Add(Convert.ToDouble(highest));
			}
			dataScrapping.trailingAndPreviousMonthDataScarping(_60DaysDateList, _60DaysHigh);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000339D8 File Offset: 0x00031BD8
		public static void trailingAndPreviousMonthDataScarping(List<string> _60DaysDateList, List<double> _60DaysHigh)
		{
			List<double> trailingMonthHighPrice = new List<double>();
			List<string> trailingMonthHighDate = new List<string>();
			List<double> previousMonthHighPrice = new List<double>();
			List<string> previousMonthHighDate = new List<string>();
			string systemDate = Convert.ToString(DateTime.Today.Date);
			string systemDatePlusOneDay = gannTimeAnalysis.addDaysToDate(1.0, systemDate);
			string lastMonthDate = gannTimeAnalysis.addDaysToDate(-31.0, systemDate);
			try
			{
				DateTime startDate = Convert.ToDateTime(lastMonthDate);
				DateTime endDate = Convert.ToDateTime(systemDatePlusOneDay);
				for (int i = 0; i <= _60DaysDateList.Count - 1; i++)
				{
					DateTime individualDate = Convert.ToDateTime(_60DaysDateList.ElementAt(i).Replace("-", ""));
					if (individualDate > startDate && individualDate < endDate)
					{
						trailingMonthHighDate.Add(_60DaysDateList.ElementAt(i));
						trailingMonthHighPrice.Add(_60DaysHigh.ElementAt(i));
					}
				}
			}
			catch
			{
			}
			dataScrapping.trailingHighDate = new List<string>(trailingMonthHighDate.Count);
			dataScrapping.trailingHighPrice = new List<double>(trailingMonthHighDate.Count);
			for (int j = 0; j <= trailingMonthHighDate.Count - 1; j++)
			{
				dataScrapping.trailingHighDate.Insert(j, trailingMonthHighDate.ElementAt(j));
				dataScrapping.trailingHighPrice.Insert(j, trailingMonthHighPrice.ElementAt(j));
			}
			List<string> months = new List<string>(new DateTimeFormatInfo().MonthNames);
			int previousMonth_Number = DateTime.Now.AddMonths(-1).Month;
			string previousMonthString = months[previousMonth_Number];
			try
			{
				for (int k = 0; k <= _60DaysDateList.Count - 1; k++)
				{
					int monthIndex = Convert.ToDateTime(_60DaysDateList.ElementAt(k).Replace("-", "")).Month;
					if (months[monthIndex].Equals(previousMonthString))
					{
						previousMonthHighDate.Add(_60DaysDateList.ElementAt(k));
						previousMonthHighPrice.Add(_60DaysHigh.ElementAt(k));
					}
				}
				dataScrapping.previousHighDate = new List<string>(previousMonthHighDate.Count);
				dataScrapping.previousHighPrice = new List<double>(previousMonthHighDate.Count);
				for (int l = 0; l <= previousMonthHighDate.Count - 1; l++)
				{
					dataScrapping.previousHighDate.Insert(l, previousMonthHighDate.ElementAt(l));
					dataScrapping.previousHighPrice.Insert(l, previousMonthHighPrice.ElementAt(l));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00033C40 File Offset: 0x00031E40
		public static int findLowerDateLoopIndex(string lowFormationDate, string highFormationDate, List<string> highDates)
		{
			new DateTimeFormatInfo();
			DateTime lowDate = Convert.ToDateTime(lowFormationDate).Date;
			DateTime highDate = Convert.ToDateTime(highFormationDate).Date;
			string lowestDate;
			if (lowDate < highDate)
			{
				lowestDate = lowFormationDate;
			}
			else
			{
				lowestDate = highFormationDate;
			}
			int lowerDateLoopIndex = 0;
			for (int i = 0; i <= highDates.Count - 1; i++)
			{
				if (highDates[i].Replace("-", "").Equals(lowestDate))
				{
					lowerDateLoopIndex = i + 1;
					break;
				}
			}
			return lowerDateLoopIndex;
		}

		// Token: 0x04000618 RID: 1560
		public static List<double> trailingHighPrice;

		// Token: 0x04000619 RID: 1561
		public static List<string> trailingHighDate;

		// Token: 0x0400061A RID: 1562
		public static List<double> previousHighPrice;

		// Token: 0x0400061B RID: 1563
		public static List<string> previousHighDate;
	}
}
