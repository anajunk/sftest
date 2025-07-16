using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x0200001F RID: 31
	public partial class Volatality_Drift : UserControl
	{
		// Token: 0x0600016E RID: 366 RVA: 0x000148A2 File Offset: 0x00012AA2
		public Volatality_Drift()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000148C8 File Offset: 0x00012AC8
		public void Initialize_Variable()
		{
			Volatality_Drift.<Initialize_Variable>d__7 <Initialize_Variable>d__;
			<Initialize_Variable>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Initialize_Variable>d__.<>4__this = this;
			<Initialize_Variable>d__.<>1__state = -1;
			<Initialize_Variable>d__.<>t__builder.Start<Volatality_Drift.<Initialize_Variable>d__7>(ref <Initialize_Variable>d__);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00014900 File Offset: 0x00012B00
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
			this.DriftUpCycle_1_Target1.Inlines.Clear();
			this.DriftUpCycle_1_Target2.Inlines.Clear();
			this.DriftUpCycle_1_Target3.Inlines.Clear();
			this.DriftUpCycle_1_Target4.Inlines.Clear();
			this.DriftUpCycle_1_Target5.Inlines.Clear();
			this.DriftUpCycle_1_Target6.Inlines.Clear();
			this.DriftUpCycle_1_Target7.Inlines.Clear();
			this.DriftUpCycle_1_Target8.Inlines.Clear();
			this.DriftUpCycle_1_Target9.Inlines.Clear();
			this.DriftUpCycle_2_Target1.Inlines.Clear();
			this.DriftUpCycle_2_Target2.Inlines.Clear();
			this.DriftUpCycle_2_Target3.Inlines.Clear();
			this.DriftUpCycle_2_Target4.Inlines.Clear();
			this.DriftUpCycle_2_Target5.Inlines.Clear();
			this.DriftUpCycle_2_Target6.Inlines.Clear();
			this.DriftUpCycle_2_Target7.Inlines.Clear();
			this.DriftUpCycle_2_Target8.Inlines.Clear();
			this.DriftUpCycle_2_Target9.Inlines.Clear();
			this.DriftUpCycle_3_Target1.Inlines.Clear();
			this.DriftUpCycle_3_Target2.Inlines.Clear();
			this.DriftUpCycle_3_Target3.Inlines.Clear();
			this.DriftUpCycle_3_Target4.Inlines.Clear();
			this.DriftUpCycle_3_Target5.Inlines.Clear();
			this.DriftUpCycle_3_Target6.Inlines.Clear();
			this.DriftUpCycle_3_Target7.Inlines.Clear();
			this.DriftUpCycle_3_Target8.Inlines.Clear();
			this.DriftUpCycle_3_Target9.Inlines.Clear();
			this.DriftDownCycle_1_Target1.Inlines.Clear();
			this.DriftDownCycle_1_Target2.Inlines.Clear();
			this.DriftDownCycle_1_Target3.Inlines.Clear();
			this.DriftDownCycle_1_Target4.Inlines.Clear();
			this.DriftDownCycle_1_Target5.Inlines.Clear();
			this.DriftDownCycle_1_Target6.Inlines.Clear();
			this.DriftDownCycle_1_Target7.Inlines.Clear();
			this.DriftDownCycle_1_Target8.Inlines.Clear();
			this.DriftDownCycle_1_Target9.Inlines.Clear();
			this.DriftDownCycle_2_Target1.Inlines.Clear();
			this.DriftDownCycle_2_Target2.Inlines.Clear();
			this.DriftDownCycle_2_Target3.Inlines.Clear();
			this.DriftDownCycle_2_Target4.Inlines.Clear();
			this.DriftDownCycle_2_Target5.Inlines.Clear();
			this.DriftDownCycle_2_Target6.Inlines.Clear();
			this.DriftDownCycle_2_Target7.Inlines.Clear();
			this.DriftDownCycle_2_Target8.Inlines.Clear();
			this.DriftDownCycle_2_Target9.Inlines.Clear();
			this.DriftDownCycle_3_Target1.Inlines.Clear();
			this.DriftDownCycle_3_Target2.Inlines.Clear();
			this.DriftDownCycle_3_Target3.Inlines.Clear();
			this.DriftDownCycle_3_Target4.Inlines.Clear();
			this.DriftDownCycle_3_Target5.Inlines.Clear();
			this.DriftDownCycle_3_Target6.Inlines.Clear();
			this.DriftDownCycle_3_Target7.Inlines.Clear();
			this.DriftDownCycle_3_Target8.Inlines.Clear();
			this.DriftDownCycle_3_Target9.Inlines.Clear();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00014FD0 File Offset: 0x000131D0
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

		// Token: 0x06000172 RID: 370 RVA: 0x00015018 File Offset: 0x00013218
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

		// Token: 0x06000173 RID: 371 RVA: 0x00015074 File Offset: 0x00013274
		[NullableContext(1)]
		private void HigherDriftTab_Click(object sender, MouseButtonEventArgs e)
		{
			this.Clear1();
			List<double> DriftDegree = new List<double>
			{
				0.236,
				0.382,
				0.5,
				0.618,
				0.786,
				0.888,
				1.0,
				1.236,
				1.618
			};
			List<double> DriftCommon = new List<double>();
			for (int i = 0; i < DriftDegree.Count; i++)
			{
				DriftCommon.Add(this.FinalPriceRange2 * DriftDegree[i]);
			}
			double DriftUpTrendcycle = this.closeValues.Last<double>();
			List<double> DriftUpCycle = new List<double>();
			for (int j = 0; j < DriftCommon.Count; j++)
			{
				DriftUpCycle.Add(DriftCommon[j] + DriftUpTrendcycle);
			}
			double DriftUpTrendcycle2 = DriftUpCycle.Last<double>();
			List<double> DriftUpCycle2 = new List<double>();
			for (int k = 0; k < DriftCommon.Count; k++)
			{
				DriftUpCycle2.Add(DriftCommon[k] + DriftUpTrendcycle2);
			}
			double DriftUpTrendcycle3 = DriftUpCycle2.Last<double>();
			List<double> DriftUpCycle3 = new List<double>();
			for (int l = 0; l < DriftCommon.Count; l++)
			{
				DriftUpCycle3.Add(DriftCommon[l] + DriftUpTrendcycle3);
			}
			double DriftDownTrendcycle = this.closeValues.Last<double>();
			List<double> DriftDownCycle = new List<double>();
			for (int m = 0; m < DriftCommon.Count; m++)
			{
				DriftDownCycle.Add(DriftDownTrendcycle - DriftCommon[m]);
			}
			double DriftDownTrendcycle2 = DriftDownCycle.Last<double>();
			List<double> DriftDownCycle2 = new List<double>();
			for (int n = 0; n < DriftCommon.Count; n++)
			{
				DriftDownCycle2.Add(DriftDownTrendcycle2 - DriftCommon[n]);
			}
			double DriftDownTrendcycle3 = DriftDownCycle2.Last<double>();
			List<double> DriftDownCycle3 = new List<double>();
			for (int i2 = 0; i2 < DriftCommon.Count; i2++)
			{
				DriftDownCycle3.Add(DriftDownTrendcycle3 - DriftCommon[i2]);
			}
			this.DriftUpCycle_1_Target1.Inlines.Add(DriftUpCycle[0].ToString("0.00"));
			this.DriftUpCycle_1_Target2.Inlines.Add(DriftUpCycle[1].ToString("0.00"));
			this.DriftUpCycle_1_Target3.Inlines.Add(DriftUpCycle[2].ToString("0.00"));
			this.DriftUpCycle_1_Target4.Inlines.Add(DriftUpCycle[3].ToString("0.00"));
			this.DriftUpCycle_1_Target5.Inlines.Add(DriftUpCycle[4].ToString("0.00"));
			this.DriftUpCycle_1_Target6.Inlines.Add(DriftUpCycle[5].ToString("0.00"));
			this.DriftUpCycle_1_Target7.Inlines.Add(DriftUpCycle[6].ToString("0.00"));
			this.DriftUpCycle_1_Target8.Inlines.Add(DriftUpCycle[7].ToString("0.00"));
			this.DriftUpCycle_1_Target9.Inlines.Add(DriftUpCycle[8].ToString("0.00"));
			this.DriftUpCycle_2_Target1.Inlines.Add(DriftUpCycle2[0].ToString("0.00"));
			this.DriftUpCycle_2_Target2.Inlines.Add(DriftUpCycle2[1].ToString("0.00"));
			this.DriftUpCycle_2_Target3.Inlines.Add(DriftUpCycle2[2].ToString("0.00"));
			this.DriftUpCycle_2_Target4.Inlines.Add(DriftUpCycle2[3].ToString("0.00"));
			this.DriftUpCycle_2_Target5.Inlines.Add(DriftUpCycle2[4].ToString("0.00"));
			this.DriftUpCycle_2_Target6.Inlines.Add(DriftUpCycle2[5].ToString("0.00"));
			this.DriftUpCycle_2_Target7.Inlines.Add(DriftUpCycle2[6].ToString("0.00"));
			this.DriftUpCycle_2_Target8.Inlines.Add(DriftUpCycle2[7].ToString("0.00"));
			this.DriftUpCycle_2_Target9.Inlines.Add(DriftUpCycle2[8].ToString("0.00"));
			this.DriftUpCycle_3_Target1.Inlines.Add(DriftUpCycle3[0].ToString("0.00"));
			this.DriftUpCycle_3_Target2.Inlines.Add(DriftUpCycle3[1].ToString("0.00"));
			this.DriftUpCycle_3_Target3.Inlines.Add(DriftUpCycle3[2].ToString("0.00"));
			this.DriftUpCycle_3_Target4.Inlines.Add(DriftUpCycle3[3].ToString("0.00"));
			this.DriftUpCycle_3_Target5.Inlines.Add(DriftUpCycle3[4].ToString("0.00"));
			this.DriftUpCycle_3_Target6.Inlines.Add(DriftUpCycle3[5].ToString("0.00"));
			this.DriftUpCycle_3_Target7.Inlines.Add(DriftUpCycle3[6].ToString("0.00"));
			this.DriftUpCycle_3_Target8.Inlines.Add(DriftUpCycle3[7].ToString("0.00"));
			this.DriftUpCycle_3_Target9.Inlines.Add(DriftUpCycle3[8].ToString("0.00"));
			this.DriftDownCycle_1_Target1.Inlines.Add(DriftDownCycle[0].ToString("0.00"));
			this.DriftDownCycle_1_Target2.Inlines.Add(DriftDownCycle[1].ToString("0.00"));
			this.DriftDownCycle_1_Target3.Inlines.Add(DriftDownCycle[2].ToString("0.00"));
			this.DriftDownCycle_1_Target4.Inlines.Add(DriftDownCycle[3].ToString("0.00"));
			this.DriftDownCycle_1_Target5.Inlines.Add(DriftDownCycle[4].ToString("0.00"));
			this.DriftDownCycle_1_Target6.Inlines.Add(DriftDownCycle[5].ToString("0.00"));
			this.DriftDownCycle_1_Target7.Inlines.Add(DriftDownCycle[6].ToString("0.00"));
			this.DriftDownCycle_1_Target8.Inlines.Add(DriftDownCycle[7].ToString("0.00"));
			this.DriftDownCycle_1_Target9.Inlines.Add(DriftDownCycle[8].ToString("0.00"));
			this.DriftDownCycle_2_Target1.Inlines.Add(DriftDownCycle2[0].ToString("0.00"));
			this.DriftDownCycle_2_Target2.Inlines.Add(DriftDownCycle2[1].ToString("0.00"));
			this.DriftDownCycle_2_Target3.Inlines.Add(DriftDownCycle2[2].ToString("0.00"));
			this.DriftDownCycle_2_Target4.Inlines.Add(DriftDownCycle2[3].ToString("0.00"));
			this.DriftDownCycle_2_Target5.Inlines.Add(DriftDownCycle2[4].ToString("0.00"));
			this.DriftDownCycle_2_Target6.Inlines.Add(DriftDownCycle2[5].ToString("0.00"));
			this.DriftDownCycle_2_Target7.Inlines.Add(DriftDownCycle2[6].ToString("0.00"));
			this.DriftDownCycle_2_Target8.Inlines.Add(DriftDownCycle2[7].ToString("0.00"));
			this.DriftDownCycle_2_Target9.Inlines.Add(DriftDownCycle2[8].ToString("0.00"));
			this.DriftDownCycle_3_Target1.Inlines.Add(DriftDownCycle3[0].ToString("0.00"));
			this.DriftDownCycle_3_Target2.Inlines.Add(DriftDownCycle3[1].ToString("0.00"));
			this.DriftDownCycle_3_Target3.Inlines.Add(DriftDownCycle3[2].ToString("0.00"));
			this.DriftDownCycle_3_Target4.Inlines.Add(DriftDownCycle3[3].ToString("0.00"));
			this.DriftDownCycle_3_Target5.Inlines.Add(DriftDownCycle3[4].ToString("0.00"));
			this.DriftDownCycle_3_Target6.Inlines.Add(DriftDownCycle3[5].ToString("0.00"));
			this.DriftDownCycle_3_Target7.Inlines.Add(DriftDownCycle3[6].ToString("0.00"));
			this.DriftDownCycle_3_Target8.Inlines.Add(DriftDownCycle3[7].ToString("0.00"));
			this.DriftDownCycle_3_Target9.Inlines.Add(DriftDownCycle3[8].ToString("0.00"));
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00015A8C File Offset: 0x00013C8C
		[NullableContext(1)]
		private void LowerHigherDriftTab_Click(object sender, MouseButtonEventArgs e)
		{
			this.Clear1();
			List<double> Degree = new List<double>
			{
				0.236,
				0.382,
				0.5,
				0.618,
				0.786,
				0.888,
				1.0,
				1.236,
				1.618
			};
			List<double> Common = new List<double>();
			for (int i = 0; i < Degree.Count; i++)
			{
				Common.Add(this.FinalPriceRange1 * Degree[i]);
			}
			double UpTrendcycle = this.closeValues.Last<double>();
			List<double> UpCycle = new List<double>();
			for (int j = 0; j < Common.Count; j++)
			{
				UpCycle.Add(Common[j] + UpTrendcycle);
			}
			double UpTrendcycle2 = UpCycle.Last<double>();
			List<double> UpCycle2 = new List<double>();
			for (int k = 0; k < Common.Count; k++)
			{
				UpCycle2.Add(Common[k] + UpTrendcycle2);
			}
			double UpTrendcycle3 = UpCycle2.Last<double>();
			List<double> UpCycle3 = new List<double>();
			for (int l = 0; l < Common.Count; l++)
			{
				UpCycle3.Add(Common[l] + UpTrendcycle3);
			}
			double DownTrendcycle = this.closeValues.Last<double>();
			List<double> DownCycle = new List<double>();
			for (int m = 0; m < Common.Count; m++)
			{
				DownCycle.Add(DownTrendcycle - Common[m]);
			}
			double DownTrendcycle2 = DownCycle.Last<double>();
			List<double> DownCycle2 = new List<double>();
			for (int n = 0; n < Common.Count; n++)
			{
				DownCycle2.Add(DownTrendcycle2 - Common[n]);
			}
			double DownTrendcycle3 = DownCycle2.Last<double>();
			List<double> DownCycle3 = new List<double>();
			for (int i2 = 0; i2 < Common.Count; i2++)
			{
				DownCycle3.Add(DownTrendcycle3 - Common[i2]);
			}
			this.UpCycle_1_Target1.Inlines.Add(UpCycle[0].ToString("0.00"));
			this.UpCycle_1_Target2.Inlines.Add(UpCycle[1].ToString("0.00"));
			this.UpCycle_1_Target3.Inlines.Add(UpCycle[2].ToString("0.00"));
			this.UpCycle_1_Target4.Inlines.Add(UpCycle[3].ToString("0.00"));
			this.UpCycle_1_Target5.Inlines.Add(UpCycle[4].ToString("0.00"));
			this.UpCycle_1_Target6.Inlines.Add(UpCycle[5].ToString("0.00"));
			this.UpCycle_1_Target7.Inlines.Add(UpCycle[6].ToString("0.00"));
			this.UpCycle_1_Target8.Inlines.Add(UpCycle[7].ToString("0.00"));
			this.UpCycle_1_Target9.Inlines.Add(UpCycle[8].ToString("0.00"));
			this.UpCycle_2_Target1.Inlines.Add(UpCycle2[0].ToString("0.00"));
			this.UpCycle_2_Target2.Inlines.Add(UpCycle2[1].ToString("0.00"));
			this.UpCycle_2_Target3.Inlines.Add(UpCycle2[2].ToString("0.00"));
			this.UpCycle_2_Target4.Inlines.Add(UpCycle2[3].ToString("0.00"));
			this.UpCycle_2_Target5.Inlines.Add(UpCycle2[4].ToString("0.00"));
			this.UpCycle_2_Target6.Inlines.Add(UpCycle2[5].ToString("0.00"));
			this.UpCycle_2_Target7.Inlines.Add(UpCycle2[6].ToString("0.00"));
			this.UpCycle_2_Target8.Inlines.Add(UpCycle2[7].ToString("0.00"));
			this.UpCycle_2_Target9.Inlines.Add(UpCycle2[8].ToString("0.00"));
			this.UpCycle_3_Target1.Inlines.Add(UpCycle3[0].ToString("0.00"));
			this.UpCycle_3_Target2.Inlines.Add(UpCycle3[1].ToString("0.00"));
			this.UpCycle_3_Target3.Inlines.Add(UpCycle3[2].ToString("0.00"));
			this.UpCycle_3_Target4.Inlines.Add(UpCycle3[3].ToString("0.00"));
			this.UpCycle_3_Target5.Inlines.Add(UpCycle3[4].ToString("0.00"));
			this.UpCycle_3_Target6.Inlines.Add(UpCycle3[5].ToString("0.00"));
			this.UpCycle_3_Target7.Inlines.Add(UpCycle3[6].ToString("0.00"));
			this.UpCycle_3_Target8.Inlines.Add(UpCycle3[7].ToString("0.00"));
			this.UpCycle_3_Target9.Inlines.Add(UpCycle3[8].ToString("0.00"));
			this.DownCycle_1_Target1.Inlines.Add(DownCycle[0].ToString("0.00"));
			this.DownCycle_1_Target2.Inlines.Add(DownCycle[1].ToString("0.00"));
			this.DownCycle_1_Target3.Inlines.Add(DownCycle[2].ToString("0.00"));
			this.DownCycle_1_Target4.Inlines.Add(DownCycle[3].ToString("0.00"));
			this.DownCycle_1_Target5.Inlines.Add(DownCycle[4].ToString("0.00"));
			this.DownCycle_1_Target6.Inlines.Add(DownCycle[5].ToString("0.00"));
			this.DownCycle_1_Target7.Inlines.Add(DownCycle[6].ToString("0.00"));
			this.DownCycle_1_Target8.Inlines.Add(DownCycle[7].ToString("0.00"));
			this.DownCycle_1_Target9.Inlines.Add(DownCycle[8].ToString("0.00"));
			this.DownCycle_2_Target1.Inlines.Add(DownCycle2[0].ToString("0.00"));
			this.DownCycle_2_Target2.Inlines.Add(DownCycle2[1].ToString("0.00"));
			this.DownCycle_2_Target3.Inlines.Add(DownCycle2[2].ToString("0.00"));
			this.DownCycle_2_Target4.Inlines.Add(DownCycle2[3].ToString("0.00"));
			this.DownCycle_2_Target5.Inlines.Add(DownCycle2[4].ToString("0.00"));
			this.DownCycle_2_Target6.Inlines.Add(DownCycle2[5].ToString("0.00"));
			this.DownCycle_2_Target7.Inlines.Add(DownCycle2[6].ToString("0.00"));
			this.DownCycle_2_Target8.Inlines.Add(DownCycle2[7].ToString("0.00"));
			this.DownCycle_2_Target9.Inlines.Add(DownCycle2[8].ToString("0.00"));
			this.DownCycle_3_Target1.Inlines.Add(DownCycle3[0].ToString("0.00"));
			this.DownCycle_3_Target2.Inlines.Add(DownCycle3[1].ToString("0.00"));
			this.DownCycle_3_Target3.Inlines.Add(DownCycle3[2].ToString("0.00"));
			this.DownCycle_3_Target4.Inlines.Add(DownCycle3[3].ToString("0.00"));
			this.DownCycle_3_Target5.Inlines.Add(DownCycle3[4].ToString("0.00"));
			this.DownCycle_3_Target6.Inlines.Add(DownCycle3[5].ToString("0.00"));
			this.DownCycle_3_Target7.Inlines.Add(DownCycle3[6].ToString("0.00"));
			this.DownCycle_3_Target8.Inlines.Add(DownCycle3[7].ToString("0.00"));
			this.DownCycle_3_Target9.Inlines.Add(DownCycle3[8].ToString("0.00"));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000164A4 File Offset: 0x000146A4
		[NullableContext(1)]
		public string[] LoadExpiryDates(string url)
		{
			return new WebClient().DownloadString(url).Split('\n', StringSplitOptions.None);
		}

		// Token: 0x0400025B RID: 603
		[Nullable(1)]
		private string url;

		// Token: 0x0400025C RID: 604
		[Nullable(1)]
		private readonly string EXPIRYURLEQ = "https://smartfinance.in/workweb/links/ExpiryURLNifty.txt";

		// Token: 0x0400025D RID: 605
		[Nullable(1)]
		private readonly HttpClient httpClient = new HttpClient();

		// Token: 0x0400025E RID: 606
		[Nullable(1)]
		private List<double> closeValues;

		// Token: 0x0400025F RID: 607
		private double FinalPriceRange1;

		// Token: 0x04000260 RID: 608
		private double FinalPriceRange2;
	}
}
