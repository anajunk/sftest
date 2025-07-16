using System;

namespace New_SF_IT.OptionMonth
{
	// Token: 0x02000028 RID: 40
	public class premiumDataCls
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00021158 File Offset: 0x0001F358
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00021160 File Offset: 0x0001F360
		public int strike { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00021169 File Offset: 0x0001F369
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00021171 File Offset: 0x0001F371
		public double IV { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0002117A File Offset: 0x0001F37A
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00021182 File Offset: 0x0001F382
		public double premium { get; set; }
	}
}
