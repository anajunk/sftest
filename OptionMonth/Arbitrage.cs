using System;
using System.Runtime.CompilerServices;

namespace New_SF_IT.OptionMonth
{
	// Token: 0x02000029 RID: 41
	[NullableContext(1)]
	[Nullable(0)]
	public class Arbitrage
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00021193 File Offset: 0x0001F393
		// (set) Token: 0x0600021B RID: 539 RVA: 0x0002119B File Offset: 0x0001F39B
		public int Strike { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600021C RID: 540 RVA: 0x000211A4 File Offset: 0x0001F3A4
		// (set) Token: 0x0600021D RID: 541 RVA: 0x000211AC File Offset: 0x0001F3AC
		public string ActualPremium { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000211B5 File Offset: 0x0001F3B5
		// (set) Token: 0x0600021F RID: 543 RVA: 0x000211BD File Offset: 0x0001F3BD
		public string CalculatedPremium { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000220 RID: 544 RVA: 0x000211C6 File Offset: 0x0001F3C6
		// (set) Token: 0x06000221 RID: 545 RVA: 0x000211CE File Offset: 0x0001F3CE
		public string ArbitrageValue { get; set; }
	}
}
