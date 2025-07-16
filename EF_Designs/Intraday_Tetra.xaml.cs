using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using New_SF_IT.chartWindow;

namespace New_SF_IT.EF_Designs
{
	// Token: 0x02000048 RID: 72
	public partial class Intraday_Tetra : UserControl
	{
		// Token: 0x0600035E RID: 862 RVA: 0x0006FDA5 File Offset: 0x0006DFA5
		public Intraday_Tetra()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0006FDB3 File Offset: 0x0006DFB3
		[NullableContext(1)]
		private void Support_Click(object sender, RoutedEventArgs e)
		{
			new IntraTetraChart("Support").Show();
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0006FDC4 File Offset: 0x0006DFC4
		[NullableContext(1)]
		private void Resistence_Click(object sender, RoutedEventArgs e)
		{
			new IntraTetraChart("Resistence").Show();
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0006FDD8 File Offset: 0x0006DFD8
		public void Display()
		{
			try
			{
				this.Clear();
				this.Initialize_variable();
				this.res_Center1.Inlines.Add(new Run(this.tetra1.ToString("0.00")));
				this.res_Left2.Inlines.Add(new Run(this.tetra2.ToString("0.00")));
				this.res_Center2.Inlines.Add(new Run(this.tetra3.ToString("0.00")));
				this.res_Right2.Inlines.Add(new Run(this.tetra4.ToString("0.00")));
				this.res_Left3.Inlines.Add(new Run(this.tetra5.ToString("0.00")));
				this.res_Center3.Inlines.Add(new Run(this.tetra7.ToString("0.00")));
				this.res_Right3.Inlines.Add(new Run(this.tetra9.ToString("0.00")));
				this.res_Left4.Inlines.Add(new Run(this.tetra10.ToString("0.00")));
				this.res_Center4.Inlines.Add(new Run(this.tetra13.ToString("0.00")));
				this.res_Right4.Inlines.Add(new Run(this.tetra16.ToString("0.00")));
				this.res_Left5.Inlines.Add(new Run(this.tetra17.ToString("0.00")));
				this.res_Center5.Inlines.Add(new Run(this.tetra21.ToString("0.00")));
				this.res_Right5.Inlines.Add(new Run(this.tetra25.ToString("0.00")));
				this.res_Left6.Inlines.Add(new Run(this.tetra26.ToString("0.00")));
				this.res_Center6.Inlines.Add(new Run(this.tetra31.ToString("0.00")));
				this.res_Right6.Inlines.Add(new Run(this.tetra36.ToString("0.00")));
				this.res_Left7.Inlines.Add(new Run(this.tetra37.ToString("0.00")));
				this.res_Center7.Inlines.Add(new Run(this.tetra43.ToString("0.00")));
				this.res_Right7.Inlines.Add(new Run(this.tetra49.ToString("0.00")));
				this.res_Left8.Inlines.Add(new Run(this.tetra50.ToString("0.00")));
				this.res_Center8.Inlines.Add(new Run(this.tetra57.ToString("0.00")));
				this.res_Right8.Inlines.Add(new Run(this.tetra64.ToString("0.00")));
				this.res_Left9.Inlines.Add(new Run(this.tetra65.ToString("0.00")));
				this.res_Center9.Inlines.Add(new Run(this.tetra73.ToString("0.00")));
				this.res_Right9.Inlines.Add(new Run(this.tetra81.ToString("0.00")));
				this.res_Left10.Inlines.Add(new Run(this.tetra82.ToString("0.00")));
				this.res_Center10.Inlines.Add(new Run(this.tetra91.ToString("0.00")));
				this.res_Right10.Inlines.Add(new Run(this.tetra100.ToString("0.00")));
				this.sup_Center1.Inlines.Add(new Run(this.Sup_tetra1.ToString("0.00")));
				this.sup_Left2.Inlines.Add(new Run(this.Sup_tetra2.ToString("0.00")));
				this.sup_Center2.Inlines.Add(new Run(this.Sup_tetra3.ToString("0.00")));
				this.sup_Right2.Inlines.Add(new Run(this.Sup_tetra4.ToString("0.00")));
				this.sup_Left3.Inlines.Add(new Run(this.Sup_tetra5.ToString("0.00")));
				this.sup_Center3.Inlines.Add(new Run(this.Sup_tetra7.ToString("0.00")));
				this.sup_Right3.Inlines.Add(new Run(this.Sup_tetra9.ToString("0.00")));
				this.sup_Left4.Inlines.Add(new Run(this.Sup_tetra10.ToString("0.00")));
				this.sup_Center4.Inlines.Add(new Run(this.Sup_tetra13.ToString("0.00")));
				this.sup_Right4.Inlines.Add(new Run(this.Sup_tetra16.ToString("0.00")));
				this.sup_Left5.Inlines.Add(new Run(this.Sup_tetra17.ToString("0.00")));
				this.sup_Center5.Inlines.Add(new Run(this.Sup_tetra21.ToString("0.00")));
				this.sup_Right5.Inlines.Add(new Run(this.Sup_tetra25.ToString("0.00")));
				this.sup_Left6.Inlines.Add(new Run(this.Sup_tetra26.ToString("0.00")));
				this.sup_Center6.Inlines.Add(new Run(this.Sup_tetra31.ToString("0.00")));
				this.sup_Right6.Inlines.Add(new Run(this.Sup_tetra36.ToString("0.00")));
				this.sup_Left7.Inlines.Add(new Run(this.Sup_tetra37.ToString("0.00")));
				this.sup_Center7.Inlines.Add(new Run(this.Sup_tetra43.ToString("0.00")));
				this.sup_Right7.Inlines.Add(new Run(this.Sup_tetra49.ToString("0.00")));
				this.sup_Left8.Inlines.Add(new Run(this.Sup_tetra50.ToString("0.00")));
				this.sup_Center8.Inlines.Add(new Run(this.Sup_tetra57.ToString("0.00")));
				this.sup_Right8.Inlines.Add(new Run(this.Sup_tetra64.ToString("0.00")));
				this.sup_Left9.Inlines.Add(new Run(this.Sup_tetra65.ToString("0.00")));
				this.sup_Center9.Inlines.Add(new Run(this.Sup_tetra73.ToString("0.00")));
				this.sup_Right9.Inlines.Add(new Run(this.Sup_tetra81.ToString("0.00")));
				this.sup_Left10.Inlines.Add(new Run(this.Sup_tetra82.ToString("0.00")));
				this.sup_Center10.Inlines.Add(new Run(this.Sup_tetra91.ToString("0.00")));
				this.sup_Right10.Inlines.Add(new Run(this.Sup_tetra100.ToString("0.00")));
			}
			catch
			{
				MessageBox.Show("Data Load First");
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00070638 File Offset: 0x0006E838
		private void Initialize_variable()
		{
			this.Seed = Equtiy_Future.seed;
			this.Step = Equtiy_Future.step;
			this.tetra1 = this.Seed + this.Step;
			this.tetra2 = this.tetra1 + this.Step;
			this.tetra3 = this.tetra2 + this.Step;
			this.tetra4 = this.tetra3 + this.Step;
			this.tetra5 = this.tetra4 + this.Step;
			this.tetra6 = this.tetra5 + this.Step;
			this.tetra7 = this.tetra6 + this.Step;
			this.tetra8 = this.tetra7 + this.Step;
			this.tetra9 = this.tetra8 + this.Step;
			this.tetra10 = this.tetra9 + this.Step;
			this.tetra11 = this.tetra10 + this.Step;
			this.tetra12 = this.tetra11 + this.Step;
			this.tetra13 = this.tetra12 + this.Step;
			this.tetra14 = this.tetra13 + this.Step;
			this.tetra15 = this.tetra14 + this.Step;
			this.tetra16 = this.tetra15 + this.Step;
			this.tetra17 = this.tetra16 + this.Step;
			this.tetra18 = this.tetra17 + this.Step;
			this.tetra19 = this.tetra18 + this.Step;
			this.tetra20 = this.tetra19 + this.Step;
			this.tetra21 = this.tetra20 + this.Step;
			this.tetra22 = this.tetra21 + this.Step;
			this.tetra23 = this.tetra22 + this.Step;
			this.tetra24 = this.tetra23 + this.Step;
			this.tetra25 = this.tetra24 + this.Step;
			this.tetra26 = this.tetra25 + this.Step;
			this.tetra27 = this.tetra26 + this.Step;
			this.tetra28 = this.tetra27 + this.Step;
			this.tetra29 = this.tetra28 + this.Step;
			this.tetra30 = this.tetra29 + this.Step;
			this.tetra31 = this.tetra30 + this.Step;
			this.tetra32 = this.tetra31 + this.Step;
			this.tetra33 = this.tetra32 + this.Step;
			this.tetra34 = this.tetra33 + this.Step;
			this.tetra35 = this.tetra34 + this.Step;
			this.tetra36 = this.tetra35 + this.Step;
			this.tetra37 = this.tetra36 + this.Step;
			this.tetra38 = this.tetra37 + this.Step;
			this.tetra39 = this.tetra38 + this.Step;
			this.tetra40 = this.tetra39 + this.Step;
			this.tetra41 = this.tetra40 + this.Step;
			this.tetra42 = this.tetra41 + this.Step;
			this.tetra43 = this.tetra42 + this.Step;
			this.tetra44 = this.tetra43 + this.Step;
			this.tetra45 = this.tetra44 + this.Step;
			this.tetra46 = this.tetra45 + this.Step;
			this.tetra47 = this.tetra46 + this.Step;
			this.tetra48 = this.tetra47 + this.Step;
			this.tetra49 = this.tetra48 + this.Step;
			this.tetra50 = this.tetra49 + this.Step;
			this.tetra51 = this.tetra50 + this.Step;
			this.tetra52 = this.tetra51 + this.Step;
			this.tetra53 = this.tetra52 + this.Step;
			this.tetra54 = this.tetra53 + this.Step;
			this.tetra55 = this.tetra54 + this.Step;
			this.tetra56 = this.tetra55 + this.Step;
			this.tetra57 = this.tetra56 + this.Step;
			this.tetra58 = this.tetra57 + this.Step;
			this.tetra59 = this.tetra58 + this.Step;
			this.tetra60 = this.tetra59 + this.Step;
			this.tetra61 = this.tetra60 + this.Step;
			this.tetra62 = this.tetra61 + this.Step;
			this.tetra63 = this.tetra62 + this.Step;
			this.tetra64 = this.tetra63 + this.Step;
			this.tetra65 = this.tetra64 + this.Step;
			this.tetra66 = this.tetra65 + this.Step;
			this.tetra67 = this.tetra66 + this.Step;
			this.tetra68 = this.tetra67 + this.Step;
			this.tetra69 = this.tetra68 + this.Step;
			this.tetra70 = this.tetra69 + this.Step;
			this.tetra71 = this.tetra70 + this.Step;
			this.tetra72 = this.tetra71 + this.Step;
			this.tetra73 = this.tetra72 + this.Step;
			this.tetra74 = this.tetra73 + this.Step;
			this.tetra75 = this.tetra74 + this.Step;
			this.tetra76 = this.tetra75 + this.Step;
			this.tetra77 = this.tetra76 + this.Step;
			this.tetra78 = this.tetra77 + this.Step;
			this.tetra79 = this.tetra78 + this.Step;
			this.tetra80 = this.tetra79 + this.Step;
			this.tetra81 = this.tetra80 + this.Step;
			this.tetra82 = this.tetra81 + this.Step;
			this.tetra83 = this.tetra82 + this.Step;
			this.tetra84 = this.tetra83 + this.Step;
			this.tetra85 = this.tetra84 + this.Step;
			this.tetra86 = this.tetra85 + this.Step;
			this.tetra87 = this.tetra86 + this.Step;
			this.tetra88 = this.tetra87 + this.Step;
			this.tetra89 = this.tetra88 + this.Step;
			this.tetra90 = this.tetra89 + this.Step;
			this.tetra91 = this.tetra90 + this.Step;
			this.tetra92 = this.tetra91 + this.Step;
			this.tetra93 = this.tetra92 + this.Step;
			this.tetra94 = this.tetra93 + this.Step;
			this.tetra95 = this.tetra94 + this.Step;
			this.tetra96 = this.tetra95 + this.Step;
			this.tetra97 = this.tetra96 + this.Step;
			this.tetra98 = this.tetra97 + this.Step;
			this.tetra99 = this.tetra98 + this.Step;
			this.tetra100 = this.tetra99 + this.Step;
			this.Seed = Equtiy_Future.seed;
			double step = Equtiy_Future.step;
			this.Step = -step;
			this.Sup_tetra1 = this.Seed + this.Step;
			this.Sup_tetra2 = this.Sup_tetra1 + this.Step;
			this.Sup_tetra3 = this.Sup_tetra2 + this.Step;
			this.Sup_tetra4 = this.Sup_tetra3 + this.Step;
			this.Sup_tetra5 = this.Sup_tetra4 + this.Step;
			this.Sup_tetra6 = this.Sup_tetra5 + this.Step;
			this.Sup_tetra7 = this.Sup_tetra6 + this.Step;
			this.Sup_tetra8 = this.Sup_tetra7 + this.Step;
			this.Sup_tetra9 = this.Sup_tetra8 + this.Step;
			this.Sup_tetra10 = this.Sup_tetra9 + this.Step;
			this.Sup_tetra11 = this.Sup_tetra10 + this.Step;
			this.Sup_tetra12 = this.Sup_tetra11 + this.Step;
			this.Sup_tetra13 = this.Sup_tetra12 + this.Step;
			this.Sup_tetra14 = this.Sup_tetra13 + this.Step;
			this.Sup_tetra15 = this.Sup_tetra14 + this.Step;
			this.Sup_tetra16 = this.Sup_tetra15 + this.Step;
			this.Sup_tetra17 = this.Sup_tetra16 + this.Step;
			this.Sup_tetra18 = this.Sup_tetra17 + this.Step;
			this.Sup_tetra19 = this.Sup_tetra18 + this.Step;
			this.Sup_tetra20 = this.Sup_tetra19 + this.Step;
			this.Sup_tetra21 = this.Sup_tetra20 + this.Step;
			this.Sup_tetra22 = this.Sup_tetra21 + this.Step;
			this.Sup_tetra23 = this.Sup_tetra22 + this.Step;
			this.Sup_tetra24 = this.Sup_tetra23 + this.Step;
			this.Sup_tetra25 = this.Sup_tetra24 + this.Step;
			this.Sup_tetra26 = this.Sup_tetra25 + this.Step;
			this.Sup_tetra27 = this.Sup_tetra26 + this.Step;
			this.Sup_tetra28 = this.Sup_tetra27 + this.Step;
			this.Sup_tetra29 = this.Sup_tetra28 + this.Step;
			this.Sup_tetra30 = this.Sup_tetra29 + this.Step;
			this.Sup_tetra31 = this.Sup_tetra30 + this.Step;
			this.Sup_tetra32 = this.Sup_tetra31 + this.Step;
			this.Sup_tetra33 = this.Sup_tetra32 + this.Step;
			this.Sup_tetra34 = this.Sup_tetra33 + this.Step;
			this.Sup_tetra35 = this.Sup_tetra34 + this.Step;
			this.Sup_tetra36 = this.Sup_tetra35 + this.Step;
			this.Sup_tetra37 = this.Sup_tetra36 + this.Step;
			this.Sup_tetra38 = this.Sup_tetra37 + this.Step;
			this.Sup_tetra39 = this.Sup_tetra38 + this.Step;
			this.Sup_tetra40 = this.Sup_tetra39 + this.Step;
			this.Sup_tetra41 = this.Sup_tetra40 + this.Step;
			this.Sup_tetra42 = this.Sup_tetra41 + this.Step;
			this.Sup_tetra43 = this.Sup_tetra42 + this.Step;
			this.Sup_tetra44 = this.Sup_tetra43 + this.Step;
			this.Sup_tetra45 = this.Sup_tetra44 + this.Step;
			this.Sup_tetra46 = this.Sup_tetra45 + this.Step;
			this.Sup_tetra47 = this.Sup_tetra46 + this.Step;
			this.Sup_tetra48 = this.Sup_tetra47 + this.Step;
			this.Sup_tetra49 = this.Sup_tetra48 + this.Step;
			this.Sup_tetra50 = this.Sup_tetra49 + this.Step;
			this.Sup_tetra51 = this.Sup_tetra50 + this.Step;
			this.Sup_tetra52 = this.Sup_tetra51 + this.Step;
			this.Sup_tetra53 = this.Sup_tetra52 + this.Step;
			this.Sup_tetra54 = this.Sup_tetra53 + this.Step;
			this.Sup_tetra55 = this.Sup_tetra54 + this.Step;
			this.Sup_tetra56 = this.Sup_tetra55 + this.Step;
			this.Sup_tetra57 = this.Sup_tetra56 + this.Step;
			this.Sup_tetra58 = this.Sup_tetra57 + this.Step;
			this.Sup_tetra59 = this.Sup_tetra58 + this.Step;
			this.Sup_tetra60 = this.Sup_tetra59 + this.Step;
			this.Sup_tetra61 = this.Sup_tetra60 + this.Step;
			this.Sup_tetra62 = this.Sup_tetra61 + this.Step;
			this.Sup_tetra63 = this.Sup_tetra62 + this.Step;
			this.Sup_tetra64 = this.Sup_tetra63 + this.Step;
			this.Sup_tetra65 = this.Sup_tetra64 + this.Step;
			this.Sup_tetra66 = this.Sup_tetra65 + this.Step;
			this.Sup_tetra67 = this.Sup_tetra66 + this.Step;
			this.Sup_tetra68 = this.Sup_tetra67 + this.Step;
			this.Sup_tetra69 = this.Sup_tetra68 + this.Step;
			this.Sup_tetra70 = this.Sup_tetra69 + this.Step;
			this.Sup_tetra71 = this.Sup_tetra70 + this.Step;
			this.Sup_tetra72 = this.Sup_tetra71 + this.Step;
			this.Sup_tetra73 = this.Sup_tetra72 + this.Step;
			this.Sup_tetra74 = this.Sup_tetra73 + this.Step;
			this.Sup_tetra75 = this.Sup_tetra74 + this.Step;
			this.Sup_tetra76 = this.Sup_tetra75 + this.Step;
			this.Sup_tetra77 = this.Sup_tetra76 + this.Step;
			this.Sup_tetra78 = this.Sup_tetra77 + this.Step;
			this.Sup_tetra79 = this.Sup_tetra78 + this.Step;
			this.Sup_tetra80 = this.Sup_tetra79 + this.Step;
			this.Sup_tetra81 = this.Sup_tetra80 + this.Step;
			this.Sup_tetra82 = this.Sup_tetra81 + this.Step;
			this.Sup_tetra83 = this.Sup_tetra82 + this.Step;
			this.Sup_tetra84 = this.Sup_tetra83 + this.Step;
			this.Sup_tetra85 = this.Sup_tetra84 + this.Step;
			this.Sup_tetra86 = this.Sup_tetra85 + this.Step;
			this.Sup_tetra87 = this.Sup_tetra86 + this.Step;
			this.Sup_tetra88 = this.Sup_tetra87 + this.Step;
			this.Sup_tetra89 = this.Sup_tetra88 + this.Step;
			this.Sup_tetra90 = this.Sup_tetra89 + this.Step;
			this.Sup_tetra91 = this.Sup_tetra90 + this.Step;
			this.Sup_tetra92 = this.Sup_tetra91 + this.Step;
			this.Sup_tetra93 = this.Sup_tetra92 + this.Step;
			this.Sup_tetra94 = this.Sup_tetra93 + this.Step;
			this.Sup_tetra95 = this.Sup_tetra94 + this.Step;
			this.Sup_tetra96 = this.Sup_tetra95 + this.Step;
			this.Sup_tetra97 = this.Sup_tetra96 + this.Step;
			this.Sup_tetra98 = this.Sup_tetra97 + this.Step;
			this.Sup_tetra99 = this.Sup_tetra98 + this.Step;
			this.Sup_tetra100 = this.Sup_tetra99 + this.Step;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0007154C File Offset: 0x0006F74C
		private void Clear()
		{
			this.res_Left1.Inlines.Clear();
			this.res_Left2.Inlines.Clear();
			this.res_Left3.Inlines.Clear();
			this.res_Left4.Inlines.Clear();
			this.res_Left5.Inlines.Clear();
			this.res_Left6.Inlines.Clear();
			this.res_Left7.Inlines.Clear();
			this.res_Left8.Inlines.Clear();
			this.res_Left9.Inlines.Clear();
			this.res_Left10.Inlines.Clear();
			this.res_Center1.Inlines.Clear();
			this.res_Center2.Inlines.Clear();
			this.res_Center3.Inlines.Clear();
			this.res_Center4.Inlines.Clear();
			this.res_Center5.Inlines.Clear();
			this.res_Center6.Inlines.Clear();
			this.res_Center7.Inlines.Clear();
			this.res_Center8.Inlines.Clear();
			this.res_Center9.Inlines.Clear();
			this.res_Center10.Inlines.Clear();
			this.res_Right1.Inlines.Clear();
			this.res_Right2.Inlines.Clear();
			this.res_Right3.Inlines.Clear();
			this.res_Right4.Inlines.Clear();
			this.res_Right5.Inlines.Clear();
			this.res_Right6.Inlines.Clear();
			this.res_Right7.Inlines.Clear();
			this.res_Right8.Inlines.Clear();
			this.res_Right9.Inlines.Clear();
			this.res_Right10.Inlines.Clear();
			this.sup_Left1.Inlines.Clear();
			this.sup_Left2.Inlines.Clear();
			this.sup_Left3.Inlines.Clear();
			this.sup_Left4.Inlines.Clear();
			this.sup_Left5.Inlines.Clear();
			this.sup_Left6.Inlines.Clear();
			this.sup_Left7.Inlines.Clear();
			this.sup_Left8.Inlines.Clear();
			this.sup_Left9.Inlines.Clear();
			this.sup_Left10.Inlines.Clear();
			this.sup_Center1.Inlines.Clear();
			this.sup_Center2.Inlines.Clear();
			this.sup_Center3.Inlines.Clear();
			this.sup_Center4.Inlines.Clear();
			this.sup_Center5.Inlines.Clear();
			this.sup_Center6.Inlines.Clear();
			this.sup_Center7.Inlines.Clear();
			this.sup_Center8.Inlines.Clear();
			this.sup_Center9.Inlines.Clear();
			this.sup_Center10.Inlines.Clear();
			this.sup_Right1.Inlines.Clear();
			this.sup_Right2.Inlines.Clear();
			this.sup_Right3.Inlines.Clear();
			this.sup_Right4.Inlines.Clear();
			this.sup_Right5.Inlines.Clear();
			this.sup_Right6.Inlines.Clear();
			this.sup_Right7.Inlines.Clear();
			this.sup_Right8.Inlines.Clear();
			this.sup_Right9.Inlines.Clear();
			this.sup_Right10.Inlines.Clear();
		}

		// Token: 0x04000C36 RID: 3126
		public double Seed;

		// Token: 0x04000C37 RID: 3127
		public double Step;

		// Token: 0x04000C38 RID: 3128
		public double Sup_tetra1;

		// Token: 0x04000C39 RID: 3129
		public double Sup_tetra2;

		// Token: 0x04000C3A RID: 3130
		public double Sup_tetra3;

		// Token: 0x04000C3B RID: 3131
		public double Sup_tetra4;

		// Token: 0x04000C3C RID: 3132
		public double Sup_tetra5;

		// Token: 0x04000C3D RID: 3133
		public double Sup_tetra6;

		// Token: 0x04000C3E RID: 3134
		public double Sup_tetra7;

		// Token: 0x04000C3F RID: 3135
		public double Sup_tetra8;

		// Token: 0x04000C40 RID: 3136
		public double Sup_tetra9;

		// Token: 0x04000C41 RID: 3137
		public double Sup_tetra10;

		// Token: 0x04000C42 RID: 3138
		public double Sup_tetra11;

		// Token: 0x04000C43 RID: 3139
		public double Sup_tetra12;

		// Token: 0x04000C44 RID: 3140
		public double Sup_tetra13;

		// Token: 0x04000C45 RID: 3141
		public double Sup_tetra14;

		// Token: 0x04000C46 RID: 3142
		public double Sup_tetra15;

		// Token: 0x04000C47 RID: 3143
		public double Sup_tetra16;

		// Token: 0x04000C48 RID: 3144
		public double Sup_tetra17;

		// Token: 0x04000C49 RID: 3145
		public double Sup_tetra18;

		// Token: 0x04000C4A RID: 3146
		public double Sup_tetra19;

		// Token: 0x04000C4B RID: 3147
		public double Sup_tetra20;

		// Token: 0x04000C4C RID: 3148
		public double Sup_tetra21;

		// Token: 0x04000C4D RID: 3149
		public double Sup_tetra22;

		// Token: 0x04000C4E RID: 3150
		public double Sup_tetra23;

		// Token: 0x04000C4F RID: 3151
		public double Sup_tetra24;

		// Token: 0x04000C50 RID: 3152
		public double Sup_tetra25;

		// Token: 0x04000C51 RID: 3153
		public double Sup_tetra26;

		// Token: 0x04000C52 RID: 3154
		public double Sup_tetra27;

		// Token: 0x04000C53 RID: 3155
		public double Sup_tetra28;

		// Token: 0x04000C54 RID: 3156
		public double Sup_tetra29;

		// Token: 0x04000C55 RID: 3157
		public double Sup_tetra30;

		// Token: 0x04000C56 RID: 3158
		public double Sup_tetra31;

		// Token: 0x04000C57 RID: 3159
		public double Sup_tetra32;

		// Token: 0x04000C58 RID: 3160
		public double Sup_tetra33;

		// Token: 0x04000C59 RID: 3161
		public double Sup_tetra34;

		// Token: 0x04000C5A RID: 3162
		public double Sup_tetra35;

		// Token: 0x04000C5B RID: 3163
		public double Sup_tetra36;

		// Token: 0x04000C5C RID: 3164
		public double Sup_tetra37;

		// Token: 0x04000C5D RID: 3165
		public double Sup_tetra38;

		// Token: 0x04000C5E RID: 3166
		public double Sup_tetra39;

		// Token: 0x04000C5F RID: 3167
		public double Sup_tetra40;

		// Token: 0x04000C60 RID: 3168
		public double Sup_tetra41;

		// Token: 0x04000C61 RID: 3169
		public double Sup_tetra42;

		// Token: 0x04000C62 RID: 3170
		public double Sup_tetra43;

		// Token: 0x04000C63 RID: 3171
		public double Sup_tetra44;

		// Token: 0x04000C64 RID: 3172
		public double Sup_tetra45;

		// Token: 0x04000C65 RID: 3173
		public double Sup_tetra46;

		// Token: 0x04000C66 RID: 3174
		public double Sup_tetra47;

		// Token: 0x04000C67 RID: 3175
		public double Sup_tetra48;

		// Token: 0x04000C68 RID: 3176
		public double Sup_tetra49;

		// Token: 0x04000C69 RID: 3177
		public double Sup_tetra50;

		// Token: 0x04000C6A RID: 3178
		public double Sup_tetra51;

		// Token: 0x04000C6B RID: 3179
		public double Sup_tetra52;

		// Token: 0x04000C6C RID: 3180
		public double Sup_tetra53;

		// Token: 0x04000C6D RID: 3181
		public double Sup_tetra54;

		// Token: 0x04000C6E RID: 3182
		public double Sup_tetra55;

		// Token: 0x04000C6F RID: 3183
		public double Sup_tetra56;

		// Token: 0x04000C70 RID: 3184
		public double Sup_tetra57;

		// Token: 0x04000C71 RID: 3185
		public double Sup_tetra58;

		// Token: 0x04000C72 RID: 3186
		public double Sup_tetra59;

		// Token: 0x04000C73 RID: 3187
		public double Sup_tetra60;

		// Token: 0x04000C74 RID: 3188
		public double Sup_tetra61;

		// Token: 0x04000C75 RID: 3189
		public double Sup_tetra62;

		// Token: 0x04000C76 RID: 3190
		public double Sup_tetra63;

		// Token: 0x04000C77 RID: 3191
		public double Sup_tetra64;

		// Token: 0x04000C78 RID: 3192
		public double Sup_tetra65;

		// Token: 0x04000C79 RID: 3193
		public double Sup_tetra66;

		// Token: 0x04000C7A RID: 3194
		public double Sup_tetra67;

		// Token: 0x04000C7B RID: 3195
		public double Sup_tetra68;

		// Token: 0x04000C7C RID: 3196
		public double Sup_tetra69;

		// Token: 0x04000C7D RID: 3197
		public double Sup_tetra70;

		// Token: 0x04000C7E RID: 3198
		public double Sup_tetra71;

		// Token: 0x04000C7F RID: 3199
		public double Sup_tetra72;

		// Token: 0x04000C80 RID: 3200
		public double Sup_tetra73;

		// Token: 0x04000C81 RID: 3201
		public double Sup_tetra74;

		// Token: 0x04000C82 RID: 3202
		public double Sup_tetra75;

		// Token: 0x04000C83 RID: 3203
		public double Sup_tetra76;

		// Token: 0x04000C84 RID: 3204
		public double Sup_tetra77;

		// Token: 0x04000C85 RID: 3205
		public double Sup_tetra78;

		// Token: 0x04000C86 RID: 3206
		public double Sup_tetra79;

		// Token: 0x04000C87 RID: 3207
		public double Sup_tetra80;

		// Token: 0x04000C88 RID: 3208
		public double Sup_tetra81;

		// Token: 0x04000C89 RID: 3209
		public double Sup_tetra82;

		// Token: 0x04000C8A RID: 3210
		public double Sup_tetra83;

		// Token: 0x04000C8B RID: 3211
		public double Sup_tetra84;

		// Token: 0x04000C8C RID: 3212
		public double Sup_tetra85;

		// Token: 0x04000C8D RID: 3213
		public double Sup_tetra86;

		// Token: 0x04000C8E RID: 3214
		public double Sup_tetra87;

		// Token: 0x04000C8F RID: 3215
		public double Sup_tetra88;

		// Token: 0x04000C90 RID: 3216
		public double Sup_tetra89;

		// Token: 0x04000C91 RID: 3217
		public double Sup_tetra90;

		// Token: 0x04000C92 RID: 3218
		public double Sup_tetra91;

		// Token: 0x04000C93 RID: 3219
		public double Sup_tetra92;

		// Token: 0x04000C94 RID: 3220
		public double Sup_tetra93;

		// Token: 0x04000C95 RID: 3221
		public double Sup_tetra94;

		// Token: 0x04000C96 RID: 3222
		public double Sup_tetra95;

		// Token: 0x04000C97 RID: 3223
		public double Sup_tetra96;

		// Token: 0x04000C98 RID: 3224
		public double Sup_tetra97;

		// Token: 0x04000C99 RID: 3225
		public double Sup_tetra98;

		// Token: 0x04000C9A RID: 3226
		public double Sup_tetra99;

		// Token: 0x04000C9B RID: 3227
		public double Sup_tetra100;

		// Token: 0x04000C9C RID: 3228
		public double Sup_tetra101;

		// Token: 0x04000C9D RID: 3229
		public double Sup_tetra102;

		// Token: 0x04000C9E RID: 3230
		public double Sup_tetra103;

		// Token: 0x04000C9F RID: 3231
		public double Sup_tetra104;

		// Token: 0x04000CA0 RID: 3232
		public double Sup_tetra105;

		// Token: 0x04000CA1 RID: 3233
		public double Sup_tetra106;

		// Token: 0x04000CA2 RID: 3234
		public double Sup_tetra107;

		// Token: 0x04000CA3 RID: 3235
		public double Sup_tetra108;

		// Token: 0x04000CA4 RID: 3236
		public double Sup_tetra109;

		// Token: 0x04000CA5 RID: 3237
		public double Sup_tetra110;

		// Token: 0x04000CA6 RID: 3238
		public double Sup_tetra111;

		// Token: 0x04000CA7 RID: 3239
		public double Sup_tetra112;

		// Token: 0x04000CA8 RID: 3240
		public double Sup_tetra113;

		// Token: 0x04000CA9 RID: 3241
		public double Sup_tetra114;

		// Token: 0x04000CAA RID: 3242
		public double Sup_tetra115;

		// Token: 0x04000CAB RID: 3243
		public double Sup_tetra116;

		// Token: 0x04000CAC RID: 3244
		public double Sup_tetra117;

		// Token: 0x04000CAD RID: 3245
		public double Sup_tetra118;

		// Token: 0x04000CAE RID: 3246
		public double Sup_tetra119;

		// Token: 0x04000CAF RID: 3247
		public double Sup_tetra120;

		// Token: 0x04000CB0 RID: 3248
		public double Sup_tetra121;

		// Token: 0x04000CB1 RID: 3249
		public double Sup_tetra122;

		// Token: 0x04000CB2 RID: 3250
		public double Sup_tetra123;

		// Token: 0x04000CB3 RID: 3251
		public double Sup_tetra124;

		// Token: 0x04000CB4 RID: 3252
		public double Sup_tetra125;

		// Token: 0x04000CB5 RID: 3253
		public double Sup_tetra126;

		// Token: 0x04000CB6 RID: 3254
		public double tetra1;

		// Token: 0x04000CB7 RID: 3255
		public double tetra2;

		// Token: 0x04000CB8 RID: 3256
		public double tetra3;

		// Token: 0x04000CB9 RID: 3257
		public double tetra4;

		// Token: 0x04000CBA RID: 3258
		public double tetra5;

		// Token: 0x04000CBB RID: 3259
		public double tetra6;

		// Token: 0x04000CBC RID: 3260
		public double tetra7;

		// Token: 0x04000CBD RID: 3261
		public double tetra8;

		// Token: 0x04000CBE RID: 3262
		public double tetra9;

		// Token: 0x04000CBF RID: 3263
		public double tetra10;

		// Token: 0x04000CC0 RID: 3264
		public double tetra11;

		// Token: 0x04000CC1 RID: 3265
		public double tetra12;

		// Token: 0x04000CC2 RID: 3266
		public double tetra13;

		// Token: 0x04000CC3 RID: 3267
		public double tetra14;

		// Token: 0x04000CC4 RID: 3268
		public double tetra15;

		// Token: 0x04000CC5 RID: 3269
		public double tetra16;

		// Token: 0x04000CC6 RID: 3270
		public double tetra17;

		// Token: 0x04000CC7 RID: 3271
		public double tetra18;

		// Token: 0x04000CC8 RID: 3272
		public double tetra19;

		// Token: 0x04000CC9 RID: 3273
		public double tetra20;

		// Token: 0x04000CCA RID: 3274
		public double tetra21;

		// Token: 0x04000CCB RID: 3275
		public double tetra22;

		// Token: 0x04000CCC RID: 3276
		public double tetra23;

		// Token: 0x04000CCD RID: 3277
		public double tetra24;

		// Token: 0x04000CCE RID: 3278
		public double tetra25;

		// Token: 0x04000CCF RID: 3279
		public double tetra26;

		// Token: 0x04000CD0 RID: 3280
		public double tetra27;

		// Token: 0x04000CD1 RID: 3281
		public double tetra28;

		// Token: 0x04000CD2 RID: 3282
		public double tetra29;

		// Token: 0x04000CD3 RID: 3283
		public double tetra30;

		// Token: 0x04000CD4 RID: 3284
		public double tetra31;

		// Token: 0x04000CD5 RID: 3285
		public double tetra32;

		// Token: 0x04000CD6 RID: 3286
		public double tetra33;

		// Token: 0x04000CD7 RID: 3287
		public double tetra34;

		// Token: 0x04000CD8 RID: 3288
		public double tetra35;

		// Token: 0x04000CD9 RID: 3289
		public double tetra36;

		// Token: 0x04000CDA RID: 3290
		public double tetra37;

		// Token: 0x04000CDB RID: 3291
		public double tetra38;

		// Token: 0x04000CDC RID: 3292
		public double tetra39;

		// Token: 0x04000CDD RID: 3293
		public double tetra40;

		// Token: 0x04000CDE RID: 3294
		public double tetra41;

		// Token: 0x04000CDF RID: 3295
		public double tetra42;

		// Token: 0x04000CE0 RID: 3296
		public double tetra43;

		// Token: 0x04000CE1 RID: 3297
		public double tetra44;

		// Token: 0x04000CE2 RID: 3298
		public double tetra45;

		// Token: 0x04000CE3 RID: 3299
		public double tetra46;

		// Token: 0x04000CE4 RID: 3300
		public double tetra47;

		// Token: 0x04000CE5 RID: 3301
		public double tetra48;

		// Token: 0x04000CE6 RID: 3302
		public double tetra49;

		// Token: 0x04000CE7 RID: 3303
		public double tetra50;

		// Token: 0x04000CE8 RID: 3304
		public double tetra51;

		// Token: 0x04000CE9 RID: 3305
		public double tetra52;

		// Token: 0x04000CEA RID: 3306
		public double tetra53;

		// Token: 0x04000CEB RID: 3307
		public double tetra54;

		// Token: 0x04000CEC RID: 3308
		public double tetra55;

		// Token: 0x04000CED RID: 3309
		public double tetra56;

		// Token: 0x04000CEE RID: 3310
		public double tetra57;

		// Token: 0x04000CEF RID: 3311
		public double tetra58;

		// Token: 0x04000CF0 RID: 3312
		public double tetra59;

		// Token: 0x04000CF1 RID: 3313
		public double tetra60;

		// Token: 0x04000CF2 RID: 3314
		public double tetra61;

		// Token: 0x04000CF3 RID: 3315
		public double tetra62;

		// Token: 0x04000CF4 RID: 3316
		public double tetra63;

		// Token: 0x04000CF5 RID: 3317
		public double tetra64;

		// Token: 0x04000CF6 RID: 3318
		public double tetra65;

		// Token: 0x04000CF7 RID: 3319
		public double tetra66;

		// Token: 0x04000CF8 RID: 3320
		public double tetra67;

		// Token: 0x04000CF9 RID: 3321
		public double tetra68;

		// Token: 0x04000CFA RID: 3322
		public double tetra69;

		// Token: 0x04000CFB RID: 3323
		public double tetra70;

		// Token: 0x04000CFC RID: 3324
		public double tetra71;

		// Token: 0x04000CFD RID: 3325
		public double tetra72;

		// Token: 0x04000CFE RID: 3326
		public double tetra73;

		// Token: 0x04000CFF RID: 3327
		public double tetra74;

		// Token: 0x04000D00 RID: 3328
		public double tetra75;

		// Token: 0x04000D01 RID: 3329
		public double tetra76;

		// Token: 0x04000D02 RID: 3330
		public double tetra77;

		// Token: 0x04000D03 RID: 3331
		public double tetra78;

		// Token: 0x04000D04 RID: 3332
		public double tetra79;

		// Token: 0x04000D05 RID: 3333
		public double tetra80;

		// Token: 0x04000D06 RID: 3334
		public double tetra81;

		// Token: 0x04000D07 RID: 3335
		public double tetra82;

		// Token: 0x04000D08 RID: 3336
		public double tetra83;

		// Token: 0x04000D09 RID: 3337
		public double tetra84;

		// Token: 0x04000D0A RID: 3338
		public double tetra85;

		// Token: 0x04000D0B RID: 3339
		public double tetra86;

		// Token: 0x04000D0C RID: 3340
		public double tetra87;

		// Token: 0x04000D0D RID: 3341
		public double tetra88;

		// Token: 0x04000D0E RID: 3342
		public double tetra89;

		// Token: 0x04000D0F RID: 3343
		public double tetra90;

		// Token: 0x04000D10 RID: 3344
		public double tetra91;

		// Token: 0x04000D11 RID: 3345
		public double tetra92;

		// Token: 0x04000D12 RID: 3346
		public double tetra93;

		// Token: 0x04000D13 RID: 3347
		public double tetra94;

		// Token: 0x04000D14 RID: 3348
		public double tetra95;

		// Token: 0x04000D15 RID: 3349
		public double tetra96;

		// Token: 0x04000D16 RID: 3350
		public double tetra97;

		// Token: 0x04000D17 RID: 3351
		public double tetra98;

		// Token: 0x04000D18 RID: 3352
		public double tetra99;

		// Token: 0x04000D19 RID: 3353
		public double tetra100;
	}
}
