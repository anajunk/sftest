using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001E RID: 30
	[NullableContext(1)]
	[Nullable(0)]
	internal class techAnalysisHelper
	{
		// Token: 0x06000169 RID: 361 RVA: 0x00014780 File Offset: 0x00012980
		public static List<string> _60daysLTPfromDB(string Symbol, string url)
		{
			List<string> downloadedData = new List<string>();
			if (techAnalysisHelper.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(string.Format(url, Symbol))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					downloadedData.Add(data);
				}
			}
			return downloadedData;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000147C1 File Offset: 0x000129C1
		public static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000147D0 File Offset: 0x000129D0
		public static List<string> _11daysLTPfromDB(string Instrument, string Symbol, string Expiry, string url)
		{
			List<string> downloadedData = new List<string>();
			if (techAnalysisHelper.IsInternetAvailable())
			{
				if (Instrument == "EQUITY")
				{
					Instrument = "EQ";
				}
				else if (Instrument == "STOCK FUTURE")
				{
					Instrument = "FUTSTK";
				}
				else if (Instrument == "INDEX FUTURE")
				{
					Instrument = "FUTIDX";
				}
				string data = new downloadSiteCls(new Uri(string.Format(url, Instrument, Symbol, Expiry))).getSite();
				if (!string.IsNullOrWhiteSpace(data))
				{
					if (!(Instrument == "EQ"))
					{
						int startIndex = data.IndexOf("'>");
						int lenthToExtract = data.LastIndexOf("</div>") - startIndex;
						data = data.Substring(startIndex + 2, lenthToExtract - 2);
					}
					downloadedData.Add(data);
				}
			}
			return downloadedData;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0001488A File Offset: 0x00012A8A
		public static List<string> splitData(string Data, string Surl)
		{
			return new List<string>(Data.Split(',', StringSplitOptions.None));
		}
	}
}
