using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace New_SF_IT.chartWindow
{
	// Token: 0x02000052 RID: 82
	public partial class GannHexChart : Window
	{
		// Token: 0x060003CD RID: 973 RVA: 0x00080E7F File Offset: 0x0007F07F
		[NullableContext(1)]
		public GannHexChart(string res_sup, double seed, double step)
		{
			this.InitializeComponent();
			this.initialize_Variable(res_sup);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00080E94 File Offset: 0x0007F094
		[NullableContext(1)]
		public void initialize_Variable(string symbol)
		{
			if (symbol == "Resistance")
			{
				this.Initialize_Variable();
				return;
			}
			if (symbol == "Support")
			{
				this.Initialize_Variable1();
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00080EC0 File Offset: 0x0007F0C0
		public void Initialize_Variable()
		{
			this.heading.Text = "Resistence Chart";
			double Seed = Equtiy_Future.seed;
			double CF = Equtiy_Future.CF;
			this.Seed = Seed * CF;
			this.Step = Equtiy_Future.step;
			this.tetra1 = this.Seed + this.Step;
			this.num1.Text = this.tetra1.ToString("0.00");
			this.tetra2 = this.tetra1 + this.Step;
			this.num2.Text = this.tetra2.ToString("0.00");
			this.tetra3 = this.tetra2 + this.Step;
			this.num3.Text = this.tetra3.ToString("0.00");
			this.tetra4 = this.tetra3 + this.Step;
			this.num4.Text = this.tetra4.ToString("0.00");
			this.tetra5 = this.tetra4 + this.Step;
			this.num5.Text = this.tetra5.ToString("0.00");
			this.tetra6 = this.tetra5 + this.Step;
			this.num6.Text = this.tetra6.ToString("0.00");
			this.tetra7 = this.tetra6 + this.Step;
			this.num7.Text = this.tetra7.ToString("0.00");
			this.tetra8 = this.tetra7 + this.Step;
			this.num8.Text = this.tetra8.ToString("0.00");
			this.tetra9 = this.tetra8 + this.Step;
			this.num9.Text = this.tetra9.ToString("0.00");
			this.tetra10 = this.tetra9 + this.Step;
			this.num10.Text = this.tetra10.ToString("0.00");
			this.tetra11 = this.tetra10 + this.Step;
			this.num11.Text = this.tetra11.ToString("0.00");
			this.tetra12 = this.tetra11 + this.Step;
			this.num12.Text = this.tetra12.ToString("0.00");
			this.tetra13 = this.tetra12 + this.Step;
			this.num13.Text = this.tetra13.ToString("0.00");
			this.tetra14 = this.tetra13 + this.Step;
			this.num14.Text = this.tetra14.ToString("0.00");
			this.tetra15 = this.tetra14 + this.Step;
			this.num15.Text = this.tetra15.ToString("0.00");
			this.tetra16 = this.tetra15 + this.Step;
			this.num16.Text = this.tetra16.ToString("0.00");
			this.tetra17 = this.tetra16 + this.Step;
			this.num17.Text = this.tetra17.ToString("0.00");
			this.tetra18 = this.tetra17 + this.Step;
			this.num18.Text = this.tetra18.ToString("0.00");
			this.tetra19 = this.tetra18 + this.Step;
			this.num19.Text = this.tetra19.ToString("0.00");
			this.tetra20 = this.tetra19 + this.Step;
			this.num20.Text = this.tetra20.ToString("0.00");
			this.tetra21 = this.tetra20 + this.Step;
			this.num21.Text = this.tetra21.ToString("0.00");
			this.tetra22 = this.tetra21 + this.Step;
			this.num22.Text = this.tetra22.ToString("0.00");
			this.tetra23 = this.tetra22 + this.Step;
			this.num23.Text = this.tetra23.ToString("0.00");
			this.tetra24 = this.tetra23 + this.Step;
			this.num24.Text = this.tetra24.ToString("0.00");
			this.tetra25 = this.tetra24 + this.Step;
			this.num25.Text = this.tetra25.ToString("0.00");
			this.tetra26 = this.tetra25 + this.Step;
			this.num26.Text = this.tetra26.ToString("0.00");
			this.tetra27 = this.tetra26 + this.Step;
			this.num27.Text = this.tetra27.ToString("0.00");
			this.tetra28 = this.tetra27 + this.Step;
			this.num28.Text = this.tetra28.ToString("0.00");
			this.tetra29 = this.tetra28 + this.Step;
			this.num29.Text = this.tetra29.ToString("0.00");
			this.tetra30 = this.tetra29 + this.Step;
			this.num30.Text = this.tetra30.ToString("0.00");
			this.tetra31 = this.tetra30 + this.Step;
			this.num31.Text = this.tetra31.ToString("0.00");
			this.tetra32 = this.tetra31 + this.Step;
			this.num32.Text = this.tetra32.ToString("0.00");
			this.tetra33 = this.tetra32 + this.Step;
			this.num33.Text = this.tetra33.ToString("0.00");
			this.tetra34 = this.tetra33 + this.Step;
			this.num34.Text = this.tetra34.ToString("0.00");
			this.tetra35 = this.tetra34 + this.Step;
			this.num35.Text = this.tetra35.ToString("0.00");
			this.tetra36 = this.tetra35 + this.Step;
			this.num36.Text = this.tetra36.ToString("0.00");
			this.tetra37 = this.tetra36 + this.Step;
			this.num37.Text = this.tetra37.ToString("0.00");
			this.tetra38 = this.tetra37 + this.Step;
			this.num38.Text = this.tetra38.ToString("0.00");
			this.tetra39 = this.tetra38 + this.Step;
			this.num39.Text = this.tetra39.ToString("0.00");
			this.tetra40 = this.tetra39 + this.Step;
			this.num40.Text = this.tetra40.ToString("0.00");
			this.tetra41 = this.tetra40 + this.Step;
			this.num41.Text = this.tetra41.ToString("0.00");
			this.tetra42 = this.tetra41 + this.Step;
			this.num42.Text = this.tetra42.ToString("0.00");
			this.tetra43 = this.tetra42 + this.Step;
			this.num43.Text = this.tetra43.ToString("0.00");
			this.tetra44 = this.tetra43 + this.Step;
			this.num44.Text = this.tetra44.ToString("0.00");
			this.tetra45 = this.tetra44 + this.Step;
			this.num45.Text = this.tetra45.ToString("0.00");
			this.tetra46 = this.tetra45 + this.Step;
			this.num46.Text = this.tetra46.ToString("0.00");
			this.tetra47 = this.tetra46 + this.Step;
			this.num47.Text = this.tetra47.ToString("0.00");
			this.tetra48 = this.tetra47 + this.Step;
			this.num48.Text = this.tetra48.ToString("0.00");
			this.tetra49 = this.tetra48 + this.Step;
			this.num49.Text = this.tetra49.ToString("0.00");
			this.tetra50 = this.tetra49 + this.Step;
			this.num50.Text = this.tetra50.ToString("0.00");
			this.tetra51 = this.tetra50 + this.Step;
			this.num51.Text = this.tetra51.ToString("0.00");
			this.tetra52 = this.tetra51 + this.Step;
			this.num52.Text = this.tetra52.ToString("0.00");
			this.tetra53 = this.tetra52 + this.Step;
			this.num53.Text = this.tetra53.ToString("0.00");
			this.tetra54 = this.tetra53 + this.Step;
			this.num54.Text = this.tetra54.ToString("0.00");
			this.tetra55 = this.tetra54 + this.Step;
			this.num55.Text = this.tetra55.ToString("0.00");
			this.tetra56 = this.tetra55 + this.Step;
			this.num56.Text = this.tetra56.ToString("0.00");
			this.tetra57 = this.tetra56 + this.Step;
			this.num57.Text = this.tetra57.ToString("0.00");
			this.tetra58 = this.tetra57 + this.Step;
			this.num58.Text = this.tetra58.ToString("0.00");
			this.tetra59 = this.tetra58 + this.Step;
			this.num59.Text = this.tetra59.ToString("0.00");
			this.tetra60 = this.tetra59 + this.Step;
			this.num60.Text = this.tetra60.ToString("0.00");
			this.tetra61 = this.tetra60 + this.Step;
			this.num61.Text = this.tetra61.ToString("0.00");
			this.tetra62 = this.tetra61 + this.Step;
			this.num62.Text = this.tetra62.ToString("0.00");
			this.tetra63 = this.tetra62 + this.Step;
			this.num63.Text = this.tetra63.ToString("0.00");
			this.tetra64 = this.tetra63 + this.Step;
			this.num64.Text = this.tetra64.ToString("0.00");
			this.tetra65 = this.tetra64 + this.Step;
			this.num65.Text = this.tetra65.ToString("0.00");
			this.tetra66 = this.tetra65 + this.Step;
			this.num66.Text = this.tetra66.ToString("0.00");
			this.tetra67 = this.tetra66 + this.Step;
			this.num67.Text = this.tetra67.ToString("0.00");
			this.tetra68 = this.tetra67 + this.Step;
			this.num68.Text = this.tetra68.ToString("0.00");
			this.tetra69 = this.tetra68 + this.Step;
			this.num69.Text = this.tetra69.ToString("0.00");
			this.tetra70 = this.tetra69 + this.Step;
			this.num70.Text = this.tetra70.ToString("0.00");
			this.tetra71 = this.tetra70 + this.Step;
			this.num71.Text = this.tetra71.ToString("0.00");
			this.tetra72 = this.tetra71 + this.Step;
			this.num72.Text = this.tetra72.ToString("0.00");
			this.tetra73 = this.tetra72 + this.Step;
			this.num73.Text = this.tetra73.ToString("0.00");
			this.tetra74 = this.tetra73 + this.Step;
			this.num74.Text = this.tetra74.ToString("0.00");
			this.tetra75 = this.tetra74 + this.Step;
			this.num75.Text = this.tetra75.ToString("0.00");
			this.tetra76 = this.tetra75 + this.Step;
			this.num76.Text = this.tetra76.ToString("0.00");
			this.tetra77 = this.tetra76 + this.Step;
			this.num77.Text = this.tetra77.ToString("0.00");
			this.tetra78 = this.tetra77 + this.Step;
			this.num78.Text = this.tetra78.ToString("0.00");
			this.tetra79 = this.tetra78 + this.Step;
			this.num79.Text = this.tetra79.ToString("0.00");
			this.tetra80 = this.tetra79 + this.Step;
			this.num80.Text = this.tetra80.ToString("0.00");
			this.tetra81 = this.tetra80 + this.Step;
			this.num81.Text = this.tetra81.ToString("0.00");
			this.tetra82 = this.tetra81 + this.Step;
			this.num82.Text = this.tetra82.ToString("0.00");
			this.tetra83 = this.tetra82 + this.Step;
			this.num83.Text = this.tetra83.ToString("0.00");
			this.tetra84 = this.tetra83 + this.Step;
			this.num84.Text = this.tetra84.ToString("0.00");
			this.tetra85 = this.tetra84 + this.Step;
			this.num85.Text = this.tetra85.ToString("0.00");
			this.tetra86 = this.tetra85 + this.Step;
			this.num86.Text = this.tetra86.ToString("0.00");
			this.tetra87 = this.tetra86 + this.Step;
			this.num87.Text = this.tetra87.ToString("0.00");
			this.tetra88 = this.tetra87 + this.Step;
			this.num88.Text = this.tetra88.ToString("0.00");
			this.tetra89 = this.tetra88 + this.Step;
			this.num89.Text = this.tetra89.ToString("0.00");
			this.tetra90 = this.tetra89 + this.Step;
			this.num90.Text = this.tetra90.ToString("0.00");
			this.tetra91 = this.tetra90 + this.Step;
			this.num91.Text = this.tetra91.ToString("0.00");
			this.tetra92 = this.tetra91 + this.Step;
			this.num92.Text = this.tetra92.ToString("0.00");
			this.tetra93 = this.tetra92 + this.Step;
			this.num93.Text = this.tetra93.ToString("0.00");
			this.tetra94 = this.tetra93 + this.Step;
			this.num94.Text = this.tetra94.ToString("0.00");
			this.tetra95 = this.tetra94 + this.Step;
			this.num95.Text = this.tetra95.ToString("0.00");
			this.tetra96 = this.tetra95 + this.Step;
			this.num96.Text = this.tetra96.ToString("0.00");
			this.tetra97 = this.tetra96 + this.Step;
			this.num97.Text = this.tetra97.ToString("0.00");
			this.tetra98 = this.tetra97 + this.Step;
			this.num98.Text = this.tetra98.ToString("0.00");
			this.tetra99 = this.tetra98 + this.Step;
			this.num99.Text = this.tetra99.ToString("0.00");
			this.tetra100 = this.tetra99 + this.Step;
			this.num100.Text = this.tetra100.ToString("0.00");
			this.tetra101 = this.tetra100 + this.Step;
			this.num101.Text = this.tetra101.ToString("0.00");
			this.tetra102 = this.tetra101 + this.Step;
			this.num102.Text = this.tetra102.ToString("0.00");
			this.tetra103 = this.tetra102 + this.Step;
			this.num103.Text = this.tetra103.ToString("0.00");
			this.tetra104 = this.tetra103 + this.Step;
			this.num104.Text = this.tetra104.ToString("0.00");
			this.tetra105 = this.tetra104 + this.Step;
			this.num105.Text = this.tetra105.ToString("0.00");
			this.tetra106 = this.tetra105 + this.Step;
			this.num106.Text = this.tetra106.ToString("0.00");
			this.tetra107 = this.tetra106 + this.Step;
			this.num107.Text = this.tetra107.ToString("0.00");
			this.tetra108 = this.tetra107 + this.Step;
			this.num108.Text = this.tetra108.ToString("0.00");
			this.tetra109 = this.tetra108 + this.Step;
			this.num109.Text = this.tetra109.ToString("0.00");
			this.tetra110 = this.tetra109 + this.Step;
			this.num110.Text = this.tetra110.ToString("0.00");
			this.tetra111 = this.tetra110 + this.Step;
			this.num111.Text = this.tetra111.ToString("0.00");
			this.tetra112 = this.tetra111 + this.Step;
			this.num112.Text = this.tetra112.ToString("0.00");
			this.tetra113 = this.tetra112 + this.Step;
			this.num113.Text = this.tetra113.ToString("0.00");
			this.tetra114 = this.tetra113 + this.Step;
			this.num114.Text = this.tetra114.ToString("0.00");
			this.tetra115 = this.tetra114 + this.Step;
			this.num115.Text = this.tetra115.ToString("0.00");
			this.tetra116 = this.tetra115 + this.Step;
			this.num116.Text = this.tetra116.ToString("0.00");
			this.tetra117 = this.tetra116 + this.Step;
			this.num117.Text = this.tetra117.ToString("0.00");
			this.tetra118 = this.tetra117 + this.Step;
			this.num118.Text = this.tetra118.ToString("0.00");
			this.tetra119 = this.tetra118 + this.Step;
			this.num119.Text = this.tetra119.ToString("0.00");
			this.tetra120 = this.tetra119 + this.Step;
			this.num120.Text = this.tetra120.ToString("0.00");
			this.tetra121 = this.tetra120 + this.Step;
			this.num121.Text = this.tetra121.ToString("0.00");
			this.tetra122 = this.tetra121 + this.Step;
			this.num122.Text = this.tetra122.ToString("0.00");
			this.tetra123 = this.tetra122 + this.Step;
			this.num123.Text = this.tetra123.ToString("0.00");
			this.tetra124 = this.tetra123 + this.Step;
			this.num124.Text = this.tetra124.ToString("0.00");
			this.tetra125 = this.tetra124 + this.Step;
			this.num125.Text = this.tetra125.ToString("0.00");
			this.tetra126 = this.tetra125 + this.Step;
			this.num126.Text = this.tetra126.ToString("0.00");
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000825A4 File Offset: 0x000807A4
		public void Initialize_Variable1()
		{
			this.heading.Text = "Support Chart";
			double Seed = Equtiy_Future.seed;
			double CF = Equtiy_Future.CF;
			this.Seed = Seed * CF;
			double step = Equtiy_Future.step;
			this.Step = -step;
			this.tetra1 = this.Seed + this.Step;
			this.num1.Text = this.tetra1.ToString("0.00");
			this.tetra2 = this.tetra1 + this.Step;
			this.num2.Text = this.tetra2.ToString("0.00");
			this.tetra3 = this.tetra2 + this.Step;
			this.num3.Text = this.tetra3.ToString("0.00");
			this.tetra4 = this.tetra3 + this.Step;
			this.num4.Text = this.tetra4.ToString("0.00");
			this.tetra5 = this.tetra4 + this.Step;
			this.num5.Text = this.tetra5.ToString("0.00");
			this.tetra6 = this.tetra5 + this.Step;
			this.num6.Text = this.tetra6.ToString("0.00");
			this.tetra7 = this.tetra6 + this.Step;
			this.num7.Text = this.tetra7.ToString("0.00");
			this.tetra8 = this.tetra7 + this.Step;
			this.num8.Text = this.tetra8.ToString("0.00");
			this.tetra9 = this.tetra8 + this.Step;
			this.num9.Text = this.tetra9.ToString("0.00");
			this.tetra10 = this.tetra9 + this.Step;
			this.num10.Text = this.tetra10.ToString("0.00");
			this.tetra11 = this.tetra10 + this.Step;
			this.num11.Text = this.tetra11.ToString("0.00");
			this.tetra12 = this.tetra11 + this.Step;
			this.num12.Text = this.tetra12.ToString("0.00");
			this.tetra13 = this.tetra12 + this.Step;
			this.num13.Text = this.tetra13.ToString("0.00");
			this.tetra14 = this.tetra13 + this.Step;
			this.num14.Text = this.tetra14.ToString("0.00");
			this.tetra15 = this.tetra14 + this.Step;
			this.num15.Text = this.tetra15.ToString("0.00");
			this.tetra16 = this.tetra15 + this.Step;
			this.num16.Text = this.tetra16.ToString("0.00");
			this.tetra17 = this.tetra16 + this.Step;
			this.num17.Text = this.tetra17.ToString("0.00");
			this.tetra18 = this.tetra17 + this.Step;
			this.num18.Text = this.tetra18.ToString("0.00");
			this.tetra19 = this.tetra18 + this.Step;
			this.num19.Text = this.tetra19.ToString("0.00");
			this.tetra20 = this.tetra19 + this.Step;
			this.num20.Text = this.tetra20.ToString("0.00");
			this.tetra21 = this.tetra20 + this.Step;
			this.num21.Text = this.tetra21.ToString("0.00");
			this.tetra22 = this.tetra21 + this.Step;
			this.num22.Text = this.tetra22.ToString("0.00");
			this.tetra23 = this.tetra22 + this.Step;
			this.num23.Text = this.tetra23.ToString("0.00");
			this.tetra24 = this.tetra23 + this.Step;
			this.num24.Text = this.tetra24.ToString("0.00");
			this.tetra25 = this.tetra24 + this.Step;
			this.num25.Text = this.tetra25.ToString("0.00");
			this.tetra26 = this.tetra25 + this.Step;
			this.num26.Text = this.tetra26.ToString("0.00");
			this.tetra27 = this.tetra26 + this.Step;
			this.num27.Text = this.tetra27.ToString("0.00");
			this.tetra28 = this.tetra27 + this.Step;
			this.num28.Text = this.tetra28.ToString("0.00");
			this.tetra29 = this.tetra28 + this.Step;
			this.num29.Text = this.tetra29.ToString("0.00");
			this.tetra30 = this.tetra29 + this.Step;
			this.num30.Text = this.tetra30.ToString("0.00");
			this.tetra31 = this.tetra30 + this.Step;
			this.num31.Text = this.tetra31.ToString("0.00");
			this.tetra32 = this.tetra31 + this.Step;
			this.num32.Text = this.tetra32.ToString("0.00");
			this.tetra33 = this.tetra32 + this.Step;
			this.num33.Text = this.tetra33.ToString("0.00");
			this.tetra34 = this.tetra33 + this.Step;
			this.num34.Text = this.tetra34.ToString("0.00");
			this.tetra35 = this.tetra34 + this.Step;
			this.num35.Text = this.tetra35.ToString("0.00");
			this.tetra36 = this.tetra35 + this.Step;
			this.num36.Text = this.tetra36.ToString("0.00");
			this.tetra37 = this.tetra36 + this.Step;
			this.num37.Text = this.tetra37.ToString("0.00");
			this.tetra38 = this.tetra37 + this.Step;
			this.num38.Text = this.tetra38.ToString("0.00");
			this.tetra39 = this.tetra38 + this.Step;
			this.num39.Text = this.tetra39.ToString("0.00");
			this.tetra40 = this.tetra39 + this.Step;
			this.num40.Text = this.tetra40.ToString("0.00");
			this.tetra41 = this.tetra40 + this.Step;
			this.num41.Text = this.tetra41.ToString("0.00");
			this.tetra42 = this.tetra41 + this.Step;
			this.num42.Text = this.tetra42.ToString("0.00");
			this.tetra43 = this.tetra42 + this.Step;
			this.num43.Text = this.tetra43.ToString("0.00");
			this.tetra44 = this.tetra43 + this.Step;
			this.num44.Text = this.tetra44.ToString("0.00");
			this.tetra45 = this.tetra44 + this.Step;
			this.num45.Text = this.tetra45.ToString("0.00");
			this.tetra46 = this.tetra45 + this.Step;
			this.num46.Text = this.tetra46.ToString("0.00");
			this.tetra47 = this.tetra46 + this.Step;
			this.num47.Text = this.tetra47.ToString("0.00");
			this.tetra48 = this.tetra47 + this.Step;
			this.num48.Text = this.tetra48.ToString("0.00");
			this.tetra49 = this.tetra48 + this.Step;
			this.num49.Text = this.tetra49.ToString("0.00");
			this.tetra50 = this.tetra49 + this.Step;
			this.num50.Text = this.tetra50.ToString("0.00");
			this.tetra51 = this.tetra50 + this.Step;
			this.num51.Text = this.tetra51.ToString("0.00");
			this.tetra52 = this.tetra51 + this.Step;
			this.num52.Text = this.tetra52.ToString("0.00");
			this.tetra53 = this.tetra52 + this.Step;
			this.num53.Text = this.tetra53.ToString("0.00");
			this.tetra54 = this.tetra53 + this.Step;
			this.num54.Text = this.tetra54.ToString("0.00");
			this.tetra55 = this.tetra54 + this.Step;
			this.num55.Text = this.tetra55.ToString("0.00");
			this.tetra56 = this.tetra55 + this.Step;
			this.num56.Text = this.tetra56.ToString("0.00");
			this.tetra57 = this.tetra56 + this.Step;
			this.num57.Text = this.tetra57.ToString("0.00");
			this.tetra58 = this.tetra57 + this.Step;
			this.num58.Text = this.tetra58.ToString("0.00");
			this.tetra59 = this.tetra58 + this.Step;
			this.num59.Text = this.tetra59.ToString("0.00");
			this.tetra60 = this.tetra59 + this.Step;
			this.num60.Text = this.tetra60.ToString("0.00");
			this.tetra61 = this.tetra60 + this.Step;
			this.num61.Text = this.tetra61.ToString("0.00");
			this.tetra62 = this.tetra61 + this.Step;
			this.num62.Text = this.tetra62.ToString("0.00");
			this.tetra63 = this.tetra62 + this.Step;
			this.num63.Text = this.tetra63.ToString("0.00");
			this.tetra64 = this.tetra63 + this.Step;
			this.num64.Text = this.tetra64.ToString("0.00");
			this.tetra65 = this.tetra64 + this.Step;
			this.num65.Text = this.tetra65.ToString("0.00");
			this.tetra66 = this.tetra65 + this.Step;
			this.num66.Text = this.tetra66.ToString("0.00");
			this.tetra67 = this.tetra66 + this.Step;
			this.num67.Text = this.tetra67.ToString("0.00");
			this.tetra68 = this.tetra67 + this.Step;
			this.num68.Text = this.tetra68.ToString("0.00");
			this.tetra69 = this.tetra68 + this.Step;
			this.num69.Text = this.tetra69.ToString("0.00");
			this.tetra70 = this.tetra69 + this.Step;
			this.num70.Text = this.tetra70.ToString("0.00");
			this.tetra71 = this.tetra70 + this.Step;
			this.num71.Text = this.tetra71.ToString("0.00");
			this.tetra72 = this.tetra71 + this.Step;
			this.num72.Text = this.tetra72.ToString("0.00");
			this.tetra73 = this.tetra72 + this.Step;
			this.num73.Text = this.tetra73.ToString("0.00");
			this.tetra74 = this.tetra73 + this.Step;
			this.num74.Text = this.tetra74.ToString("0.00");
			this.tetra75 = this.tetra74 + this.Step;
			this.num75.Text = this.tetra75.ToString("0.00");
			this.tetra76 = this.tetra75 + this.Step;
			this.num76.Text = this.tetra76.ToString("0.00");
			this.tetra77 = this.tetra76 + this.Step;
			this.num77.Text = this.tetra77.ToString("0.00");
			this.tetra78 = this.tetra77 + this.Step;
			this.num78.Text = this.tetra78.ToString("0.00");
			this.tetra79 = this.tetra78 + this.Step;
			this.num79.Text = this.tetra79.ToString("0.00");
			this.tetra80 = this.tetra79 + this.Step;
			this.num80.Text = this.tetra80.ToString("0.00");
			this.tetra81 = this.tetra80 + this.Step;
			this.num81.Text = this.tetra81.ToString("0.00");
			this.tetra82 = this.tetra81 + this.Step;
			this.num82.Text = this.tetra82.ToString("0.00");
			this.tetra83 = this.tetra82 + this.Step;
			this.num83.Text = this.tetra83.ToString("0.00");
			this.tetra84 = this.tetra83 + this.Step;
			this.num84.Text = this.tetra84.ToString("0.00");
			this.tetra85 = this.tetra84 + this.Step;
			this.num85.Text = this.tetra85.ToString("0.00");
			this.tetra86 = this.tetra85 + this.Step;
			this.num86.Text = this.tetra86.ToString("0.00");
			this.tetra87 = this.tetra86 + this.Step;
			this.num87.Text = this.tetra87.ToString("0.00");
			this.tetra88 = this.tetra87 + this.Step;
			this.num88.Text = this.tetra88.ToString("0.00");
			this.tetra89 = this.tetra88 + this.Step;
			this.num89.Text = this.tetra89.ToString("0.00");
			this.tetra90 = this.tetra89 + this.Step;
			this.num90.Text = this.tetra90.ToString("0.00");
			this.tetra91 = this.tetra90 + this.Step;
			this.num91.Text = this.tetra91.ToString("0.00");
			this.tetra92 = this.tetra91 + this.Step;
			this.num92.Text = this.tetra92.ToString("0.00");
			this.tetra93 = this.tetra92 + this.Step;
			this.num93.Text = this.tetra93.ToString("0.00");
			this.tetra94 = this.tetra93 + this.Step;
			this.num94.Text = this.tetra94.ToString("0.00");
			this.tetra95 = this.tetra94 + this.Step;
			this.num95.Text = this.tetra95.ToString("0.00");
			this.tetra96 = this.tetra95 + this.Step;
			this.num96.Text = this.tetra96.ToString("0.00");
			this.tetra97 = this.tetra96 + this.Step;
			this.num97.Text = this.tetra97.ToString("0.00");
			this.tetra98 = this.tetra97 + this.Step;
			this.num98.Text = this.tetra98.ToString("0.00");
			this.tetra99 = this.tetra98 + this.Step;
			this.num99.Text = this.tetra99.ToString("0.00");
			this.tetra100 = this.tetra99 + this.Step;
			this.num100.Text = this.tetra100.ToString("0.00");
			this.tetra101 = this.tetra100 + this.Step;
			this.num101.Text = this.tetra101.ToString("0.00");
			this.tetra102 = this.tetra101 + this.Step;
			this.num102.Text = this.tetra102.ToString("0.00");
			this.tetra103 = this.tetra102 + this.Step;
			this.num103.Text = this.tetra103.ToString("0.00");
			this.tetra104 = this.tetra103 + this.Step;
			this.num104.Text = this.tetra104.ToString("0.00");
			this.tetra105 = this.tetra104 + this.Step;
			this.num105.Text = this.tetra105.ToString("0.00");
			this.tetra106 = this.tetra105 + this.Step;
			this.num106.Text = this.tetra106.ToString("0.00");
			this.tetra107 = this.tetra106 + this.Step;
			this.num107.Text = this.tetra107.ToString("0.00");
			this.tetra108 = this.tetra107 + this.Step;
			this.num108.Text = this.tetra108.ToString("0.00");
			this.tetra109 = this.tetra108 + this.Step;
			this.num109.Text = this.tetra109.ToString("0.00");
			this.tetra110 = this.tetra109 + this.Step;
			this.num110.Text = this.tetra110.ToString("0.00");
			this.tetra111 = this.tetra110 + this.Step;
			this.num111.Text = this.tetra111.ToString("0.00");
			this.tetra112 = this.tetra111 + this.Step;
			this.num112.Text = this.tetra112.ToString("0.00");
			this.tetra113 = this.tetra112 + this.Step;
			this.num113.Text = this.tetra113.ToString("0.00");
			this.tetra114 = this.tetra113 + this.Step;
			this.num114.Text = this.tetra114.ToString("0.00");
			this.tetra115 = this.tetra114 + this.Step;
			this.num115.Text = this.tetra115.ToString("0.00");
			this.tetra116 = this.tetra115 + this.Step;
			this.num116.Text = this.tetra116.ToString("0.00");
			this.tetra117 = this.tetra116 + this.Step;
			this.num117.Text = this.tetra117.ToString("0.00");
			this.tetra118 = this.tetra117 + this.Step;
			this.num118.Text = this.tetra118.ToString("0.00");
			this.tetra119 = this.tetra118 + this.Step;
			this.num119.Text = this.tetra119.ToString("0.00");
			this.tetra120 = this.tetra119 + this.Step;
			this.num120.Text = this.tetra120.ToString("0.00");
			this.tetra121 = this.tetra120 + this.Step;
			this.num121.Text = this.tetra121.ToString("0.00");
			this.tetra122 = this.tetra121 + this.Step;
			this.num122.Text = this.tetra122.ToString("0.00");
			this.tetra123 = this.tetra122 + this.Step;
			this.num123.Text = this.tetra123.ToString("0.00");
			this.tetra124 = this.tetra123 + this.Step;
			this.num124.Text = this.tetra124.ToString("0.00");
			this.tetra125 = this.tetra124 + this.Step;
			this.num125.Text = this.tetra125.ToString("0.00");
			this.tetra126 = this.tetra125 + this.Step;
			this.num126.Text = this.tetra126.ToString("0.00");
		}

		// Token: 0x0400100D RID: 4109
		public double Seed;

		// Token: 0x0400100E RID: 4110
		public double Step;

		// Token: 0x0400100F RID: 4111
		[Nullable(1)]
		public string Tab;

		// Token: 0x04001010 RID: 4112
		public double tetra1;

		// Token: 0x04001011 RID: 4113
		public double tetra2;

		// Token: 0x04001012 RID: 4114
		public double tetra3;

		// Token: 0x04001013 RID: 4115
		public double tetra4;

		// Token: 0x04001014 RID: 4116
		public double tetra5;

		// Token: 0x04001015 RID: 4117
		public double tetra6;

		// Token: 0x04001016 RID: 4118
		public double tetra7;

		// Token: 0x04001017 RID: 4119
		public double tetra8;

		// Token: 0x04001018 RID: 4120
		public double tetra9;

		// Token: 0x04001019 RID: 4121
		public double tetra10;

		// Token: 0x0400101A RID: 4122
		public double tetra11;

		// Token: 0x0400101B RID: 4123
		public double tetra12;

		// Token: 0x0400101C RID: 4124
		public double tetra13;

		// Token: 0x0400101D RID: 4125
		public double tetra14;

		// Token: 0x0400101E RID: 4126
		public double tetra15;

		// Token: 0x0400101F RID: 4127
		public double tetra16;

		// Token: 0x04001020 RID: 4128
		public double tetra17;

		// Token: 0x04001021 RID: 4129
		public double tetra18;

		// Token: 0x04001022 RID: 4130
		public double tetra19;

		// Token: 0x04001023 RID: 4131
		public double tetra20;

		// Token: 0x04001024 RID: 4132
		public double tetra21;

		// Token: 0x04001025 RID: 4133
		public double tetra22;

		// Token: 0x04001026 RID: 4134
		public double tetra23;

		// Token: 0x04001027 RID: 4135
		public double tetra24;

		// Token: 0x04001028 RID: 4136
		public double tetra25;

		// Token: 0x04001029 RID: 4137
		public double tetra26;

		// Token: 0x0400102A RID: 4138
		public double tetra27;

		// Token: 0x0400102B RID: 4139
		public double tetra28;

		// Token: 0x0400102C RID: 4140
		public double tetra29;

		// Token: 0x0400102D RID: 4141
		public double tetra30;

		// Token: 0x0400102E RID: 4142
		public double tetra31;

		// Token: 0x0400102F RID: 4143
		public double tetra32;

		// Token: 0x04001030 RID: 4144
		public double tetra33;

		// Token: 0x04001031 RID: 4145
		public double tetra34;

		// Token: 0x04001032 RID: 4146
		public double tetra35;

		// Token: 0x04001033 RID: 4147
		public double tetra36;

		// Token: 0x04001034 RID: 4148
		public double tetra37;

		// Token: 0x04001035 RID: 4149
		public double tetra38;

		// Token: 0x04001036 RID: 4150
		public double tetra39;

		// Token: 0x04001037 RID: 4151
		public double tetra40;

		// Token: 0x04001038 RID: 4152
		public double tetra41;

		// Token: 0x04001039 RID: 4153
		public double tetra42;

		// Token: 0x0400103A RID: 4154
		public double tetra43;

		// Token: 0x0400103B RID: 4155
		public double tetra44;

		// Token: 0x0400103C RID: 4156
		public double tetra45;

		// Token: 0x0400103D RID: 4157
		public double tetra46;

		// Token: 0x0400103E RID: 4158
		public double tetra47;

		// Token: 0x0400103F RID: 4159
		public double tetra48;

		// Token: 0x04001040 RID: 4160
		public double tetra49;

		// Token: 0x04001041 RID: 4161
		public double tetra50;

		// Token: 0x04001042 RID: 4162
		public double tetra51;

		// Token: 0x04001043 RID: 4163
		public double tetra52;

		// Token: 0x04001044 RID: 4164
		public double tetra53;

		// Token: 0x04001045 RID: 4165
		public double tetra54;

		// Token: 0x04001046 RID: 4166
		public double tetra55;

		// Token: 0x04001047 RID: 4167
		public double tetra56;

		// Token: 0x04001048 RID: 4168
		public double tetra57;

		// Token: 0x04001049 RID: 4169
		public double tetra58;

		// Token: 0x0400104A RID: 4170
		public double tetra59;

		// Token: 0x0400104B RID: 4171
		public double tetra60;

		// Token: 0x0400104C RID: 4172
		public double tetra61;

		// Token: 0x0400104D RID: 4173
		public double tetra62;

		// Token: 0x0400104E RID: 4174
		public double tetra63;

		// Token: 0x0400104F RID: 4175
		public double tetra64;

		// Token: 0x04001050 RID: 4176
		public double tetra65;

		// Token: 0x04001051 RID: 4177
		public double tetra66;

		// Token: 0x04001052 RID: 4178
		public double tetra67;

		// Token: 0x04001053 RID: 4179
		public double tetra68;

		// Token: 0x04001054 RID: 4180
		public double tetra69;

		// Token: 0x04001055 RID: 4181
		public double tetra70;

		// Token: 0x04001056 RID: 4182
		public double tetra71;

		// Token: 0x04001057 RID: 4183
		public double tetra72;

		// Token: 0x04001058 RID: 4184
		public double tetra73;

		// Token: 0x04001059 RID: 4185
		public double tetra74;

		// Token: 0x0400105A RID: 4186
		public double tetra75;

		// Token: 0x0400105B RID: 4187
		public double tetra76;

		// Token: 0x0400105C RID: 4188
		public double tetra77;

		// Token: 0x0400105D RID: 4189
		public double tetra78;

		// Token: 0x0400105E RID: 4190
		public double tetra79;

		// Token: 0x0400105F RID: 4191
		public double tetra80;

		// Token: 0x04001060 RID: 4192
		public double tetra81;

		// Token: 0x04001061 RID: 4193
		public double tetra82;

		// Token: 0x04001062 RID: 4194
		public double tetra83;

		// Token: 0x04001063 RID: 4195
		public double tetra84;

		// Token: 0x04001064 RID: 4196
		public double tetra85;

		// Token: 0x04001065 RID: 4197
		public double tetra86;

		// Token: 0x04001066 RID: 4198
		public double tetra87;

		// Token: 0x04001067 RID: 4199
		public double tetra88;

		// Token: 0x04001068 RID: 4200
		public double tetra89;

		// Token: 0x04001069 RID: 4201
		public double tetra90;

		// Token: 0x0400106A RID: 4202
		public double tetra91;

		// Token: 0x0400106B RID: 4203
		public double tetra92;

		// Token: 0x0400106C RID: 4204
		public double tetra93;

		// Token: 0x0400106D RID: 4205
		public double tetra94;

		// Token: 0x0400106E RID: 4206
		public double tetra95;

		// Token: 0x0400106F RID: 4207
		public double tetra96;

		// Token: 0x04001070 RID: 4208
		public double tetra97;

		// Token: 0x04001071 RID: 4209
		public double tetra98;

		// Token: 0x04001072 RID: 4210
		public double tetra99;

		// Token: 0x04001073 RID: 4211
		public double tetra100;

		// Token: 0x04001074 RID: 4212
		public double tetra101;

		// Token: 0x04001075 RID: 4213
		public double tetra102;

		// Token: 0x04001076 RID: 4214
		public double tetra103;

		// Token: 0x04001077 RID: 4215
		public double tetra104;

		// Token: 0x04001078 RID: 4216
		public double tetra105;

		// Token: 0x04001079 RID: 4217
		public double tetra106;

		// Token: 0x0400107A RID: 4218
		public double tetra107;

		// Token: 0x0400107B RID: 4219
		public double tetra108;

		// Token: 0x0400107C RID: 4220
		public double tetra109;

		// Token: 0x0400107D RID: 4221
		public double tetra110;

		// Token: 0x0400107E RID: 4222
		public double tetra111;

		// Token: 0x0400107F RID: 4223
		public double tetra112;

		// Token: 0x04001080 RID: 4224
		public double tetra113;

		// Token: 0x04001081 RID: 4225
		public double tetra114;

		// Token: 0x04001082 RID: 4226
		public double tetra115;

		// Token: 0x04001083 RID: 4227
		public double tetra116;

		// Token: 0x04001084 RID: 4228
		public double tetra117;

		// Token: 0x04001085 RID: 4229
		public double tetra118;

		// Token: 0x04001086 RID: 4230
		public double tetra119;

		// Token: 0x04001087 RID: 4231
		public double tetra120;

		// Token: 0x04001088 RID: 4232
		public double tetra121;

		// Token: 0x04001089 RID: 4233
		public double tetra122;

		// Token: 0x0400108A RID: 4234
		public double tetra123;

		// Token: 0x0400108B RID: 4235
		public double tetra124;

		// Token: 0x0400108C RID: 4236
		public double tetra125;

		// Token: 0x0400108D RID: 4237
		public double tetra126;
	}
}
