using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
	// Token: 0x02000044 RID: 68
	public partial class Gann_Hexagonal : UserControl
	{
		// Token: 0x0600033E RID: 830 RVA: 0x00069077 File Offset: 0x00067277
		public Gann_Hexagonal()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00069085 File Offset: 0x00067285
		[NullableContext(1)]
		private void Support_Click(object sender, RoutedEventArgs e)
		{
			new GannHexChart("Support", this.Seed, this.Step).Show();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000690A2 File Offset: 0x000672A2
		[NullableContext(1)]
		private void Resistence_Click(object sender, RoutedEventArgs e)
		{
			new GannHexChart("Resistance", this.Seed, this.Step).Show();
		}

		// Token: 0x06000341 RID: 833 RVA: 0x000690C0 File Offset: 0x000672C0
		public void Display()
		{
			this.Clear();
			this.initialize_Variable();
			this.verticalValues = new List<string>
			{
				this.tetra1.ToString("0.00"),
				this.tetra2.ToString("0.00"),
				this.tetra99.ToString("0.00"),
				this.tetra42.ToString("0.00"),
				this.tetra9.ToString("0.00"),
				this.tetra15.ToString("0.00"),
				this.tetra54.ToString("0.00"),
				this.tetra117.ToString("0.00")
			};
			this.verticalValues.Sort();
			this.horizontalValues = new List<string>
			{
				this.tetra27.ToString("0.00"),
				this.tetra12.ToString("0.00"),
				this.tetra3.ToString("0.00"),
				this.tetra6.ToString("0.00"),
				this.tetra18.ToString("0.00"),
				this.tetra36.ToString("0.00")
			};
			this.horizontalValues.Sort();
			this.diagonalValues = new List<string>
			{
				this.tetra7.ToString("0.00"),
				this.tetra11.ToString("0.00"),
				this.tetra13.ToString("0.00"),
				this.tetra17.ToString("0.00"),
				this.tetra38.ToString("0.00"),
				this.tetra46.ToString("0.00")
			};
			this.diagonalValues.Sort();
			this.res_Left1.Inlines.Add(this.horizontalValues[0].ToString());
			this.res_Left2.Inlines.Add(this.horizontalValues[1].ToString());
			this.res_Left3.Inlines.Add(this.horizontalValues[2].ToString());
			this.res_Left4.Inlines.Add(this.horizontalValues[3].ToString());
			this.res_Left5.Inlines.Add(this.horizontalValues[4].ToString());
			this.res_Left6.Inlines.Add(this.horizontalValues[5].ToString());
			this.res_Center1.Inlines.Add(this.diagonalValues[0].ToString());
			this.res_Center2.Inlines.Add(this.diagonalValues[1].ToString());
			this.res_Center3.Inlines.Add(this.diagonalValues[2].ToString());
			this.res_Center4.Inlines.Add(this.diagonalValues[3].ToString());
			this.res_Center5.Inlines.Add(this.diagonalValues[4].ToString());
			this.res_Center6.Inlines.Add(this.diagonalValues[5].ToString());
			this.res_Right1.Inlines.Add(this.verticalValues[0].ToString());
			this.res_Right2.Inlines.Add(this.verticalValues[1].ToString());
			this.res_Right3.Inlines.Add(this.verticalValues[2].ToString());
			this.res_Right4.Inlines.Add(this.verticalValues[3].ToString());
			this.res_Right5.Inlines.Add(this.verticalValues[4].ToString());
			this.res_Right6.Inlines.Add(this.verticalValues[5].ToString());
			this.verticalValues1 = new List<string>
			{
				this.Sup_tetra1.ToString("0.00"),
				this.Sup_tetra2.ToString("0.00"),
				this.Sup_tetra99.ToString("0.00"),
				this.Sup_tetra42.ToString("0.00"),
				this.Sup_tetra9.ToString("0.00"),
				this.Sup_tetra15.ToString("0.00"),
				this.Sup_tetra54.ToString("0.00"),
				this.Sup_tetra117.ToString("0.00")
			};
			this.verticalValues1.Sort();
			this.verticalValues1.Reverse();
			this.horizontalValues1 = new List<string>
			{
				this.Sup_tetra27.ToString("0.00"),
				this.Sup_tetra12.ToString("0.00"),
				this.Sup_tetra3.ToString("0.00"),
				this.Sup_tetra6.ToString("0.00"),
				this.Sup_tetra18.ToString("0.00"),
				this.Sup_tetra36.ToString("0.00")
			};
			this.horizontalValues1.Sort();
			this.horizontalValues1.Reverse();
			this.diagonalValues1 = new List<string>
			{
				this.Sup_tetra7.ToString("0.00"),
				this.Sup_tetra11.ToString("0.00"),
				this.Sup_tetra13.ToString("0.00"),
				this.Sup_tetra17.ToString("0.00"),
				this.Sup_tetra38.ToString("0.00"),
				this.Sup_tetra46.ToString("0.00")
			};
			this.diagonalValues1.Sort();
			this.diagonalValues1.Reverse();
			this.sup_Left1.Inlines.Add(this.horizontalValues1[0].ToString());
			this.sup_Left2.Inlines.Add(this.horizontalValues1[1].ToString());
			this.sup_Left3.Inlines.Add(this.horizontalValues1[2].ToString());
			this.sup_Left4.Inlines.Add(this.horizontalValues1[3].ToString());
			this.sup_Left5.Inlines.Add(this.horizontalValues1[4].ToString());
			this.sup_Left6.Inlines.Add(this.horizontalValues1[5].ToString());
			this.sup_Center1.Inlines.Add(this.diagonalValues1[0].ToString());
			this.sup_Center2.Inlines.Add(this.diagonalValues1[1].ToString());
			this.sup_Center3.Inlines.Add(this.diagonalValues1[2].ToString());
			this.sup_Center4.Inlines.Add(this.diagonalValues1[3].ToString());
			this.sup_Center5.Inlines.Add(this.diagonalValues1[4].ToString());
			this.sup_Center6.Inlines.Add(this.diagonalValues1[5].ToString());
			this.sup_Right1.Inlines.Add(this.verticalValues1[0].ToString());
			this.sup_Right2.Inlines.Add(this.verticalValues1[1].ToString());
			this.sup_Right3.Inlines.Add(this.verticalValues1[2].ToString());
			this.sup_Right4.Inlines.Add(this.verticalValues1[3].ToString());
			this.sup_Right5.Inlines.Add(this.verticalValues1[4].ToString());
			this.sup_Right6.Inlines.Add(this.verticalValues1[5].ToString());
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00069994 File Offset: 0x00067B94
		public void initialize_Variable()
		{
			double Seed = Equtiy_Future.seed;
			double CF = Equtiy_Future.CF;
			this.Seed = Seed * CF;
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
			this.tetra101 = this.tetra100 + this.Step;
			this.tetra102 = this.tetra101 + this.Step;
			this.tetra103 = this.tetra102 + this.Step;
			this.tetra104 = this.tetra103 + this.Step;
			this.tetra105 = this.tetra104 + this.Step;
			this.tetra106 = this.tetra105 + this.Step;
			this.tetra107 = this.tetra106 + this.Step;
			this.tetra108 = this.tetra107 + this.Step;
			this.tetra109 = this.tetra108 + this.Step;
			this.tetra110 = this.tetra109 + this.Step;
			this.tetra111 = this.tetra110 + this.Step;
			this.tetra112 = this.tetra111 + this.Step;
			this.tetra113 = this.tetra112 + this.Step;
			this.tetra114 = this.tetra113 + this.Step;
			this.tetra115 = this.tetra114 + this.Step;
			this.tetra116 = this.tetra115 + this.Step;
			this.tetra117 = this.tetra116 + this.Step;
			this.tetra118 = this.tetra117 + this.Step;
			this.tetra119 = this.tetra118 + this.Step;
			this.tetra120 = this.tetra119 + this.Step;
			this.tetra121 = this.tetra120 + this.Step;
			this.tetra122 = this.tetra121 + this.Step;
			this.tetra123 = this.tetra122 + this.Step;
			this.tetra124 = this.tetra123 + this.Step;
			this.tetra125 = this.tetra124 + this.Step;
			this.tetra126 = this.tetra125 + this.Step;
			double Seed2 = Equtiy_Future.seed;
			double CF2 = Equtiy_Future.CF;
			this.Seed = Seed2 * CF2;
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
			this.Sup_tetra101 = this.Sup_tetra100 + this.Step;
			this.Sup_tetra102 = this.Sup_tetra101 + this.Step;
			this.Sup_tetra103 = this.Sup_tetra102 + this.Step;
			this.Sup_tetra104 = this.Sup_tetra103 + this.Step;
			this.Sup_tetra105 = this.Sup_tetra104 + this.Step;
			this.Sup_tetra106 = this.Sup_tetra105 + this.Step;
			this.Sup_tetra107 = this.Sup_tetra106 + this.Step;
			this.Sup_tetra108 = this.Sup_tetra107 + this.Step;
			this.Sup_tetra109 = this.Sup_tetra108 + this.Step;
			this.Sup_tetra110 = this.Sup_tetra109 + this.Step;
			this.Sup_tetra111 = this.Sup_tetra110 + this.Step;
			this.Sup_tetra112 = this.Sup_tetra111 + this.Step;
			this.Sup_tetra113 = this.Sup_tetra112 + this.Step;
			this.Sup_tetra114 = this.Sup_tetra113 + this.Step;
			this.Sup_tetra115 = this.Sup_tetra114 + this.Step;
			this.Sup_tetra116 = this.Sup_tetra115 + this.Step;
			this.Sup_tetra117 = this.Sup_tetra116 + this.Step;
			this.Sup_tetra118 = this.Sup_tetra117 + this.Step;
			this.Sup_tetra119 = this.Sup_tetra118 + this.Step;
			this.Sup_tetra120 = this.Sup_tetra119 + this.Step;
			this.Sup_tetra121 = this.Sup_tetra120 + this.Step;
			this.Sup_tetra122 = this.Sup_tetra121 + this.Step;
			this.Sup_tetra123 = this.Sup_tetra122 + this.Step;
			this.Sup_tetra124 = this.Sup_tetra123 + this.Step;
			this.Sup_tetra125 = this.Sup_tetra124 + this.Step;
			this.Sup_tetra126 = this.Sup_tetra125 + this.Step;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0006AC9C File Offset: 0x00068E9C
		private void Clear()
		{
			this.res_Left1.Inlines.Clear();
			this.res_Left2.Inlines.Clear();
			this.res_Left3.Inlines.Clear();
			this.res_Left4.Inlines.Clear();
			this.res_Left5.Inlines.Clear();
			this.res_Left6.Inlines.Clear();
			this.res_Center1.Inlines.Clear();
			this.res_Center2.Inlines.Clear();
			this.res_Center3.Inlines.Clear();
			this.res_Center4.Inlines.Clear();
			this.res_Center5.Inlines.Clear();
			this.res_Center6.Inlines.Clear();
			this.res_Right1.Inlines.Clear();
			this.res_Right2.Inlines.Clear();
			this.res_Right3.Inlines.Clear();
			this.res_Right4.Inlines.Clear();
			this.res_Right5.Inlines.Clear();
			this.res_Right6.Inlines.Clear();
			this.sup_Left1.Inlines.Clear();
			this.sup_Left2.Inlines.Clear();
			this.sup_Left3.Inlines.Clear();
			this.sup_Left4.Inlines.Clear();
			this.sup_Left5.Inlines.Clear();
			this.sup_Left6.Inlines.Clear();
			this.sup_Center1.Inlines.Clear();
			this.sup_Center2.Inlines.Clear();
			this.sup_Center3.Inlines.Clear();
			this.sup_Center4.Inlines.Clear();
			this.sup_Center5.Inlines.Clear();
			this.sup_Center6.Inlines.Clear();
			this.sup_Right1.Inlines.Clear();
			this.sup_Right2.Inlines.Clear();
			this.sup_Right3.Inlines.Clear();
			this.sup_Right4.Inlines.Clear();
			this.sup_Right5.Inlines.Clear();
			this.sup_Right6.Inlines.Clear();
		}

		// Token: 0x040009F9 RID: 2553
		public double Seed;

		// Token: 0x040009FA RID: 2554
		public double Step;

		// Token: 0x040009FB RID: 2555
		public double tetra1;

		// Token: 0x040009FC RID: 2556
		public double tetra2;

		// Token: 0x040009FD RID: 2557
		public double tetra3;

		// Token: 0x040009FE RID: 2558
		public double tetra4;

		// Token: 0x040009FF RID: 2559
		public double tetra5;

		// Token: 0x04000A00 RID: 2560
		public double tetra6;

		// Token: 0x04000A01 RID: 2561
		public double tetra7;

		// Token: 0x04000A02 RID: 2562
		public double tetra8;

		// Token: 0x04000A03 RID: 2563
		public double tetra9;

		// Token: 0x04000A04 RID: 2564
		public double tetra10;

		// Token: 0x04000A05 RID: 2565
		public double tetra11;

		// Token: 0x04000A06 RID: 2566
		public double tetra12;

		// Token: 0x04000A07 RID: 2567
		public double tetra13;

		// Token: 0x04000A08 RID: 2568
		public double tetra14;

		// Token: 0x04000A09 RID: 2569
		public double tetra15;

		// Token: 0x04000A0A RID: 2570
		public double tetra16;

		// Token: 0x04000A0B RID: 2571
		public double tetra17;

		// Token: 0x04000A0C RID: 2572
		public double tetra18;

		// Token: 0x04000A0D RID: 2573
		public double tetra19;

		// Token: 0x04000A0E RID: 2574
		public double tetra20;

		// Token: 0x04000A0F RID: 2575
		public double tetra21;

		// Token: 0x04000A10 RID: 2576
		public double tetra22;

		// Token: 0x04000A11 RID: 2577
		public double tetra23;

		// Token: 0x04000A12 RID: 2578
		public double tetra24;

		// Token: 0x04000A13 RID: 2579
		public double tetra25;

		// Token: 0x04000A14 RID: 2580
		public double tetra26;

		// Token: 0x04000A15 RID: 2581
		public double tetra27;

		// Token: 0x04000A16 RID: 2582
		public double tetra28;

		// Token: 0x04000A17 RID: 2583
		public double tetra29;

		// Token: 0x04000A18 RID: 2584
		public double tetra30;

		// Token: 0x04000A19 RID: 2585
		public double tetra31;

		// Token: 0x04000A1A RID: 2586
		public double tetra32;

		// Token: 0x04000A1B RID: 2587
		public double tetra33;

		// Token: 0x04000A1C RID: 2588
		public double tetra34;

		// Token: 0x04000A1D RID: 2589
		public double tetra35;

		// Token: 0x04000A1E RID: 2590
		public double tetra36;

		// Token: 0x04000A1F RID: 2591
		public double tetra37;

		// Token: 0x04000A20 RID: 2592
		public double tetra38;

		// Token: 0x04000A21 RID: 2593
		public double tetra39;

		// Token: 0x04000A22 RID: 2594
		public double tetra40;

		// Token: 0x04000A23 RID: 2595
		public double tetra41;

		// Token: 0x04000A24 RID: 2596
		public double tetra42;

		// Token: 0x04000A25 RID: 2597
		public double tetra43;

		// Token: 0x04000A26 RID: 2598
		public double tetra44;

		// Token: 0x04000A27 RID: 2599
		public double tetra45;

		// Token: 0x04000A28 RID: 2600
		public double tetra46;

		// Token: 0x04000A29 RID: 2601
		public double tetra47;

		// Token: 0x04000A2A RID: 2602
		public double tetra48;

		// Token: 0x04000A2B RID: 2603
		public double tetra49;

		// Token: 0x04000A2C RID: 2604
		public double tetra50;

		// Token: 0x04000A2D RID: 2605
		public double tetra51;

		// Token: 0x04000A2E RID: 2606
		public double tetra52;

		// Token: 0x04000A2F RID: 2607
		public double tetra53;

		// Token: 0x04000A30 RID: 2608
		public double tetra54;

		// Token: 0x04000A31 RID: 2609
		public double tetra55;

		// Token: 0x04000A32 RID: 2610
		public double tetra56;

		// Token: 0x04000A33 RID: 2611
		public double tetra57;

		// Token: 0x04000A34 RID: 2612
		public double tetra58;

		// Token: 0x04000A35 RID: 2613
		public double tetra59;

		// Token: 0x04000A36 RID: 2614
		public double tetra60;

		// Token: 0x04000A37 RID: 2615
		public double tetra61;

		// Token: 0x04000A38 RID: 2616
		public double tetra62;

		// Token: 0x04000A39 RID: 2617
		public double tetra63;

		// Token: 0x04000A3A RID: 2618
		public double tetra64;

		// Token: 0x04000A3B RID: 2619
		public double tetra65;

		// Token: 0x04000A3C RID: 2620
		public double tetra66;

		// Token: 0x04000A3D RID: 2621
		public double tetra67;

		// Token: 0x04000A3E RID: 2622
		public double tetra68;

		// Token: 0x04000A3F RID: 2623
		public double tetra69;

		// Token: 0x04000A40 RID: 2624
		public double tetra70;

		// Token: 0x04000A41 RID: 2625
		public double tetra71;

		// Token: 0x04000A42 RID: 2626
		public double tetra72;

		// Token: 0x04000A43 RID: 2627
		public double tetra73;

		// Token: 0x04000A44 RID: 2628
		public double tetra74;

		// Token: 0x04000A45 RID: 2629
		public double tetra75;

		// Token: 0x04000A46 RID: 2630
		public double tetra76;

		// Token: 0x04000A47 RID: 2631
		public double tetra77;

		// Token: 0x04000A48 RID: 2632
		public double tetra78;

		// Token: 0x04000A49 RID: 2633
		public double tetra79;

		// Token: 0x04000A4A RID: 2634
		public double tetra80;

		// Token: 0x04000A4B RID: 2635
		public double tetra81;

		// Token: 0x04000A4C RID: 2636
		public double tetra82;

		// Token: 0x04000A4D RID: 2637
		public double tetra83;

		// Token: 0x04000A4E RID: 2638
		public double tetra84;

		// Token: 0x04000A4F RID: 2639
		public double tetra85;

		// Token: 0x04000A50 RID: 2640
		public double tetra86;

		// Token: 0x04000A51 RID: 2641
		public double tetra87;

		// Token: 0x04000A52 RID: 2642
		public double tetra88;

		// Token: 0x04000A53 RID: 2643
		public double tetra89;

		// Token: 0x04000A54 RID: 2644
		public double tetra90;

		// Token: 0x04000A55 RID: 2645
		public double tetra91;

		// Token: 0x04000A56 RID: 2646
		public double tetra92;

		// Token: 0x04000A57 RID: 2647
		public double tetra93;

		// Token: 0x04000A58 RID: 2648
		public double tetra94;

		// Token: 0x04000A59 RID: 2649
		public double tetra95;

		// Token: 0x04000A5A RID: 2650
		public double tetra96;

		// Token: 0x04000A5B RID: 2651
		public double tetra97;

		// Token: 0x04000A5C RID: 2652
		public double tetra98;

		// Token: 0x04000A5D RID: 2653
		public double tetra99;

		// Token: 0x04000A5E RID: 2654
		public double tetra100;

		// Token: 0x04000A5F RID: 2655
		public double tetra101;

		// Token: 0x04000A60 RID: 2656
		public double tetra102;

		// Token: 0x04000A61 RID: 2657
		public double tetra103;

		// Token: 0x04000A62 RID: 2658
		public double tetra104;

		// Token: 0x04000A63 RID: 2659
		public double tetra105;

		// Token: 0x04000A64 RID: 2660
		public double tetra106;

		// Token: 0x04000A65 RID: 2661
		public double tetra107;

		// Token: 0x04000A66 RID: 2662
		public double tetra108;

		// Token: 0x04000A67 RID: 2663
		public double tetra109;

		// Token: 0x04000A68 RID: 2664
		public double tetra110;

		// Token: 0x04000A69 RID: 2665
		public double tetra111;

		// Token: 0x04000A6A RID: 2666
		public double tetra112;

		// Token: 0x04000A6B RID: 2667
		public double tetra113;

		// Token: 0x04000A6C RID: 2668
		public double tetra114;

		// Token: 0x04000A6D RID: 2669
		public double tetra115;

		// Token: 0x04000A6E RID: 2670
		public double tetra116;

		// Token: 0x04000A6F RID: 2671
		public double tetra117;

		// Token: 0x04000A70 RID: 2672
		public double tetra118;

		// Token: 0x04000A71 RID: 2673
		public double tetra119;

		// Token: 0x04000A72 RID: 2674
		public double tetra120;

		// Token: 0x04000A73 RID: 2675
		public double tetra121;

		// Token: 0x04000A74 RID: 2676
		public double tetra122;

		// Token: 0x04000A75 RID: 2677
		public double tetra123;

		// Token: 0x04000A76 RID: 2678
		public double tetra124;

		// Token: 0x04000A77 RID: 2679
		public double tetra125;

		// Token: 0x04000A78 RID: 2680
		public double tetra126;

		// Token: 0x04000A79 RID: 2681
		public double Sup_tetra1;

		// Token: 0x04000A7A RID: 2682
		public double Sup_tetra2;

		// Token: 0x04000A7B RID: 2683
		public double Sup_tetra3;

		// Token: 0x04000A7C RID: 2684
		public double Sup_tetra4;

		// Token: 0x04000A7D RID: 2685
		public double Sup_tetra5;

		// Token: 0x04000A7E RID: 2686
		public double Sup_tetra6;

		// Token: 0x04000A7F RID: 2687
		public double Sup_tetra7;

		// Token: 0x04000A80 RID: 2688
		public double Sup_tetra8;

		// Token: 0x04000A81 RID: 2689
		public double Sup_tetra9;

		// Token: 0x04000A82 RID: 2690
		public double Sup_tetra10;

		// Token: 0x04000A83 RID: 2691
		public double Sup_tetra11;

		// Token: 0x04000A84 RID: 2692
		public double Sup_tetra12;

		// Token: 0x04000A85 RID: 2693
		public double Sup_tetra13;

		// Token: 0x04000A86 RID: 2694
		public double Sup_tetra14;

		// Token: 0x04000A87 RID: 2695
		public double Sup_tetra15;

		// Token: 0x04000A88 RID: 2696
		public double Sup_tetra16;

		// Token: 0x04000A89 RID: 2697
		public double Sup_tetra17;

		// Token: 0x04000A8A RID: 2698
		public double Sup_tetra18;

		// Token: 0x04000A8B RID: 2699
		public double Sup_tetra19;

		// Token: 0x04000A8C RID: 2700
		public double Sup_tetra20;

		// Token: 0x04000A8D RID: 2701
		public double Sup_tetra21;

		// Token: 0x04000A8E RID: 2702
		public double Sup_tetra22;

		// Token: 0x04000A8F RID: 2703
		public double Sup_tetra23;

		// Token: 0x04000A90 RID: 2704
		public double Sup_tetra24;

		// Token: 0x04000A91 RID: 2705
		public double Sup_tetra25;

		// Token: 0x04000A92 RID: 2706
		public double Sup_tetra26;

		// Token: 0x04000A93 RID: 2707
		public double Sup_tetra27;

		// Token: 0x04000A94 RID: 2708
		public double Sup_tetra28;

		// Token: 0x04000A95 RID: 2709
		public double Sup_tetra29;

		// Token: 0x04000A96 RID: 2710
		public double Sup_tetra30;

		// Token: 0x04000A97 RID: 2711
		public double Sup_tetra31;

		// Token: 0x04000A98 RID: 2712
		public double Sup_tetra32;

		// Token: 0x04000A99 RID: 2713
		public double Sup_tetra33;

		// Token: 0x04000A9A RID: 2714
		public double Sup_tetra34;

		// Token: 0x04000A9B RID: 2715
		public double Sup_tetra35;

		// Token: 0x04000A9C RID: 2716
		public double Sup_tetra36;

		// Token: 0x04000A9D RID: 2717
		public double Sup_tetra37;

		// Token: 0x04000A9E RID: 2718
		public double Sup_tetra38;

		// Token: 0x04000A9F RID: 2719
		public double Sup_tetra39;

		// Token: 0x04000AA0 RID: 2720
		public double Sup_tetra40;

		// Token: 0x04000AA1 RID: 2721
		public double Sup_tetra41;

		// Token: 0x04000AA2 RID: 2722
		public double Sup_tetra42;

		// Token: 0x04000AA3 RID: 2723
		public double Sup_tetra43;

		// Token: 0x04000AA4 RID: 2724
		public double Sup_tetra44;

		// Token: 0x04000AA5 RID: 2725
		public double Sup_tetra45;

		// Token: 0x04000AA6 RID: 2726
		public double Sup_tetra46;

		// Token: 0x04000AA7 RID: 2727
		public double Sup_tetra47;

		// Token: 0x04000AA8 RID: 2728
		public double Sup_tetra48;

		// Token: 0x04000AA9 RID: 2729
		public double Sup_tetra49;

		// Token: 0x04000AAA RID: 2730
		public double Sup_tetra50;

		// Token: 0x04000AAB RID: 2731
		public double Sup_tetra51;

		// Token: 0x04000AAC RID: 2732
		public double Sup_tetra52;

		// Token: 0x04000AAD RID: 2733
		public double Sup_tetra53;

		// Token: 0x04000AAE RID: 2734
		public double Sup_tetra54;

		// Token: 0x04000AAF RID: 2735
		public double Sup_tetra55;

		// Token: 0x04000AB0 RID: 2736
		public double Sup_tetra56;

		// Token: 0x04000AB1 RID: 2737
		public double Sup_tetra57;

		// Token: 0x04000AB2 RID: 2738
		public double Sup_tetra58;

		// Token: 0x04000AB3 RID: 2739
		public double Sup_tetra59;

		// Token: 0x04000AB4 RID: 2740
		public double Sup_tetra60;

		// Token: 0x04000AB5 RID: 2741
		public double Sup_tetra61;

		// Token: 0x04000AB6 RID: 2742
		public double Sup_tetra62;

		// Token: 0x04000AB7 RID: 2743
		public double Sup_tetra63;

		// Token: 0x04000AB8 RID: 2744
		public double Sup_tetra64;

		// Token: 0x04000AB9 RID: 2745
		public double Sup_tetra65;

		// Token: 0x04000ABA RID: 2746
		public double Sup_tetra66;

		// Token: 0x04000ABB RID: 2747
		public double Sup_tetra67;

		// Token: 0x04000ABC RID: 2748
		public double Sup_tetra68;

		// Token: 0x04000ABD RID: 2749
		public double Sup_tetra69;

		// Token: 0x04000ABE RID: 2750
		public double Sup_tetra70;

		// Token: 0x04000ABF RID: 2751
		public double Sup_tetra71;

		// Token: 0x04000AC0 RID: 2752
		public double Sup_tetra72;

		// Token: 0x04000AC1 RID: 2753
		public double Sup_tetra73;

		// Token: 0x04000AC2 RID: 2754
		public double Sup_tetra74;

		// Token: 0x04000AC3 RID: 2755
		public double Sup_tetra75;

		// Token: 0x04000AC4 RID: 2756
		public double Sup_tetra76;

		// Token: 0x04000AC5 RID: 2757
		public double Sup_tetra77;

		// Token: 0x04000AC6 RID: 2758
		public double Sup_tetra78;

		// Token: 0x04000AC7 RID: 2759
		public double Sup_tetra79;

		// Token: 0x04000AC8 RID: 2760
		public double Sup_tetra80;

		// Token: 0x04000AC9 RID: 2761
		public double Sup_tetra81;

		// Token: 0x04000ACA RID: 2762
		public double Sup_tetra82;

		// Token: 0x04000ACB RID: 2763
		public double Sup_tetra83;

		// Token: 0x04000ACC RID: 2764
		public double Sup_tetra84;

		// Token: 0x04000ACD RID: 2765
		public double Sup_tetra85;

		// Token: 0x04000ACE RID: 2766
		public double Sup_tetra86;

		// Token: 0x04000ACF RID: 2767
		public double Sup_tetra87;

		// Token: 0x04000AD0 RID: 2768
		public double Sup_tetra88;

		// Token: 0x04000AD1 RID: 2769
		public double Sup_tetra89;

		// Token: 0x04000AD2 RID: 2770
		public double Sup_tetra90;

		// Token: 0x04000AD3 RID: 2771
		public double Sup_tetra91;

		// Token: 0x04000AD4 RID: 2772
		public double Sup_tetra92;

		// Token: 0x04000AD5 RID: 2773
		public double Sup_tetra93;

		// Token: 0x04000AD6 RID: 2774
		public double Sup_tetra94;

		// Token: 0x04000AD7 RID: 2775
		public double Sup_tetra95;

		// Token: 0x04000AD8 RID: 2776
		public double Sup_tetra96;

		// Token: 0x04000AD9 RID: 2777
		public double Sup_tetra97;

		// Token: 0x04000ADA RID: 2778
		public double Sup_tetra98;

		// Token: 0x04000ADB RID: 2779
		public double Sup_tetra99;

		// Token: 0x04000ADC RID: 2780
		public double Sup_tetra100;

		// Token: 0x04000ADD RID: 2781
		public double Sup_tetra101;

		// Token: 0x04000ADE RID: 2782
		public double Sup_tetra102;

		// Token: 0x04000ADF RID: 2783
		public double Sup_tetra103;

		// Token: 0x04000AE0 RID: 2784
		public double Sup_tetra104;

		// Token: 0x04000AE1 RID: 2785
		public double Sup_tetra105;

		// Token: 0x04000AE2 RID: 2786
		public double Sup_tetra106;

		// Token: 0x04000AE3 RID: 2787
		public double Sup_tetra107;

		// Token: 0x04000AE4 RID: 2788
		public double Sup_tetra108;

		// Token: 0x04000AE5 RID: 2789
		public double Sup_tetra109;

		// Token: 0x04000AE6 RID: 2790
		public double Sup_tetra110;

		// Token: 0x04000AE7 RID: 2791
		public double Sup_tetra111;

		// Token: 0x04000AE8 RID: 2792
		public double Sup_tetra112;

		// Token: 0x04000AE9 RID: 2793
		public double Sup_tetra113;

		// Token: 0x04000AEA RID: 2794
		public double Sup_tetra114;

		// Token: 0x04000AEB RID: 2795
		public double Sup_tetra115;

		// Token: 0x04000AEC RID: 2796
		public double Sup_tetra116;

		// Token: 0x04000AED RID: 2797
		public double Sup_tetra117;

		// Token: 0x04000AEE RID: 2798
		public double Sup_tetra118;

		// Token: 0x04000AEF RID: 2799
		public double Sup_tetra119;

		// Token: 0x04000AF0 RID: 2800
		public double Sup_tetra120;

		// Token: 0x04000AF1 RID: 2801
		public double Sup_tetra121;

		// Token: 0x04000AF2 RID: 2802
		public double Sup_tetra122;

		// Token: 0x04000AF3 RID: 2803
		public double Sup_tetra123;

		// Token: 0x04000AF4 RID: 2804
		public double Sup_tetra124;

		// Token: 0x04000AF5 RID: 2805
		public double Sup_tetra125;

		// Token: 0x04000AF6 RID: 2806
		public double Sup_tetra126;

		// Token: 0x04000AF7 RID: 2807
		[Nullable(1)]
		public List<string> verticalValues;

		// Token: 0x04000AF8 RID: 2808
		[Nullable(1)]
		public List<string> horizontalValues;

		// Token: 0x04000AF9 RID: 2809
		[Nullable(1)]
		public List<string> diagonalValues;

		// Token: 0x04000AFA RID: 2810
		[Nullable(1)]
		public List<string> verticalValues1;

		// Token: 0x04000AFB RID: 2811
		[Nullable(1)]
		public List<string> horizontalValues1;

		// Token: 0x04000AFC RID: 2812
		[Nullable(1)]
		public List<string> diagonalValues1;
	}
}
