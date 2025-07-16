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
	// Token: 0x02000020 RID: 32
	public partial class Volatality_LN : UserControl
	{
		// Token: 0x06000178 RID: 376 RVA: 0x00016E4D File Offset: 0x0001504D
		public Volatality_LN()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00016E74 File Offset: 0x00015074
		public void Initialize_Variable()
		{
			Volatality_LN.<Initialize_Variable>d__4 <Initialize_Variable>d__;
			<Initialize_Variable>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Initialize_Variable>d__.<>4__this = this;
			<Initialize_Variable>d__.<>1__state = -1;
			<Initialize_Variable>d__.<>t__builder.Start<Volatality_LN.<Initialize_Variable>d__4>(ref <Initialize_Variable>d__);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00016EAC File Offset: 0x000150AC
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

		// Token: 0x0600017B RID: 379 RVA: 0x0001721C File Offset: 0x0001541C
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

		// Token: 0x0600017C RID: 380 RVA: 0x00017264 File Offset: 0x00015464
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

		// Token: 0x0600017D RID: 381 RVA: 0x000172BE File Offset: 0x000154BE
		[NullableContext(1)]
		public string[] LoadExpiryDates(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x040002EA RID: 746
		[Nullable(1)]
		private string url;

		// Token: 0x040002EB RID: 747
		[Nullable(1)]
		private readonly string EXPIRYURLEQ = "https://smartfinance.in/workweb/links/ExpiryURLNifty.txt";

		// Token: 0x040002EC RID: 748
		[Nullable(1)]
		private readonly HttpClient httpClient = new HttpClient();
	}
}
