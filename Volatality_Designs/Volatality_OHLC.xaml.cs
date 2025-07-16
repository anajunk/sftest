using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000021 RID: 33
	public partial class Volatality_OHLC : UserControl
	{
		// Token: 0x06000180 RID: 384 RVA: 0x000177A9 File Offset: 0x000159A9
		public Volatality_OHLC()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000177D0 File Offset: 0x000159D0
		public void Initialize_Variable()
		{
			Volatality_OHLC.<Initialize_Variable>d__4 <Initialize_Variable>d__;
			<Initialize_Variable>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Initialize_Variable>d__.<>4__this = this;
			<Initialize_Variable>d__.<>1__state = -1;
			<Initialize_Variable>d__.<>t__builder.Start<Volatality_OHLC.<Initialize_Variable>d__4>(ref <Initialize_Variable>d__);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00017808 File Offset: 0x00015A08
		private void Clear1()
		{
			this.UpCycle_1_Target1.Inlines.Clear();
			this.UpCycle_1_Target2.Inlines.Clear();
			this.UpCycle_1_Target3.Inlines.Clear();
			this.UpCycle_1_Target4.Inlines.Clear();
			this.UpCycle_1_Target5.Inlines.Clear();
			this.UpCycle_1_Target6.Inlines.Clear();
			this.UpCycle_1_Target7.Inlines.Clear();
			this.UpCycle_1_Target8.Inlines.Clear();
			this.UpCycle_1_Target9.Inlines.Clear();
			this.UpCycle_2_Target1.Inlines.Clear();
			this.UpCycle_2_Target2.Inlines.Clear();
			this.UpCycle_2_Target3.Inlines.Clear();
			this.UpCycle_2_Target4.Inlines.Clear();
			this.UpCycle_2_Target5.Inlines.Clear();
			this.UpCycle_2_Target6.Inlines.Clear();
			this.UpCycle_2_Target7.Inlines.Clear();
			this.UpCycle_2_Target8.Inlines.Clear();
			this.UpCycle_2_Target9.Inlines.Clear();
			this.UpCycle_3_Target1.Inlines.Clear();
			this.UpCycle_3_Target2.Inlines.Clear();
			this.UpCycle_3_Target3.Inlines.Clear();
			this.UpCycle_3_Target4.Inlines.Clear();
			this.UpCycle_3_Target5.Inlines.Clear();
			this.UpCycle_3_Target6.Inlines.Clear();
			this.UpCycle_3_Target7.Inlines.Clear();
			this.UpCycle_3_Target8.Inlines.Clear();
			this.UpCycle_3_Target9.Inlines.Clear();
			this.DownCycle_1_Target1.Inlines.Clear();
			this.DownCycle_1_Target2.Inlines.Clear();
			this.DownCycle_1_Target3.Inlines.Clear();
			this.DownCycle_1_Target4.Inlines.Clear();
			this.DownCycle_1_Target5.Inlines.Clear();
			this.DownCycle_1_Target6.Inlines.Clear();
			this.DownCycle_1_Target7.Inlines.Clear();
			this.DownCycle_1_Target8.Inlines.Clear();
			this.DownCycle_1_Target9.Inlines.Clear();
			this.DownCycle_2_Target1.Inlines.Clear();
			this.DownCycle_2_Target2.Inlines.Clear();
			this.DownCycle_2_Target3.Inlines.Clear();
			this.DownCycle_2_Target4.Inlines.Clear();
			this.DownCycle_2_Target5.Inlines.Clear();
			this.DownCycle_2_Target6.Inlines.Clear();
			this.DownCycle_2_Target7.Inlines.Clear();
			this.DownCycle_2_Target8.Inlines.Clear();
			this.DownCycle_2_Target9.Inlines.Clear();
			this.DownCycle_3_Target1.Inlines.Clear();
			this.DownCycle_3_Target2.Inlines.Clear();
			this.DownCycle_3_Target3.Inlines.Clear();
			this.DownCycle_3_Target4.Inlines.Clear();
			this.DownCycle_3_Target5.Inlines.Clear();
			this.DownCycle_3_Target6.Inlines.Clear();
			this.DownCycle_3_Target7.Inlines.Clear();
			this.DownCycle_3_Target8.Inlines.Clear();
			this.DownCycle_3_Target9.Inlines.Clear();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00017B78 File Offset: 0x00015D78
		[NullableContext(1)]
		private static string ExtractSection(string response, string startTag, string endTag)
		{
			int startIndex = response.IndexOf(startTag) + startTag.Length;
			int endIndex = (endTag != null) ? response.IndexOf(endTag, startIndex) : response.Length;
			if (startIndex < 0 || endIndex < 0)
			{
				return string.Empty;
			}
			return response.Substring(startIndex, endIndex - startIndex);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00017BC0 File Offset: 0x00015DC0
		[NullableContext(1)]
		private static List<double> ParseValues(string section)
		{
			List<double> values = new List<double>();
			string[] array = section.Split(new string[]
			{
				"<br>"
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				double value;
				if (double.TryParse(array[i].Trim(), out value))
				{
					values.Add(value);
				}
				if (values.Count == 10)
				{
					break;
				}
			}
			return values;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00017C1A File Offset: 0x00015E1A
		[NullableContext(1)]
		public string[] LoadExpiryDates(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x04000332 RID: 818
		[Nullable(1)]
		private string url;

		// Token: 0x04000333 RID: 819
		[Nullable(1)]
		private readonly string EXPIRYURLEQ = "https://smartfinance.in/workweb/links/ExpiryURLNifty.txt";

		// Token: 0x04000334 RID: 820
		[Nullable(1)]
		private readonly HttpClient httpClient = new HttpClient();
	}
}
