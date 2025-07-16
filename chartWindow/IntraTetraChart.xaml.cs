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
	// Token: 0x02000053 RID: 83
	public partial class IntraTetraChart : Window
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x00084548 File Offset: 0x00082748
		[NullableContext(1)]
		public IntraTetraChart(string res_sup)
		{
			this.InitializeComponent();
			this.initialize_Variable(res_sup);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00084560 File Offset: 0x00082760
		[NullableContext(1)]
		public void initialize_Variable(string symbol)
		{
			if (symbol == "Resistence")
			{
				this.name.Text = "Resistance Chart:";
				this.Initialize_Variable();
				return;
			}
			if (symbol == "Support")
			{
				this.name.Text = "Support Chart:";
				this.Initialize_Variable1();
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000845B4 File Offset: 0x000827B4
		private void Initialize_Variable1()
		{
			this.Seed = Equtiy_Future.seed;
			double step = Equtiy_Future.step;
			this.Step = -step;
			this.Clear();
			this.tetra1 = this.Seed + this.Step;
			this.Intra1.Content = this.tetra1.ToString("0.00");
			this.tetra2 = this.tetra1 + this.Step;
			this.Intra2.Content = this.tetra2.ToString("0.00");
			this.tetra3 = this.tetra2 + this.Step;
			this.Intra3.Content = this.tetra3.ToString("0.00");
			this.tetra4 = this.tetra3 + this.Step;
			this.Intra4.Content = this.tetra4.ToString("0.00");
			this.tetra5 = this.tetra4 + this.Step;
			this.Intra5.Content = this.tetra5.ToString("0.00");
			this.tetra6 = this.tetra5 + this.Step;
			this.Intra6.Content = this.tetra6.ToString("0.00");
			this.tetra7 = this.tetra6 + this.Step;
			this.Intra7.Content = this.tetra7.ToString("0.00");
			this.tetra8 = this.tetra7 + this.Step;
			this.Intra8.Content = this.tetra8.ToString("0.00");
			this.tetra9 = this.tetra8 + this.Step;
			this.Intra9.Content = this.tetra9.ToString("0.00");
			this.tetra10 = this.tetra9 + this.Step;
			this.Intra10.Content = this.tetra10.ToString("0.00");
			this.tetra11 = this.tetra10 + this.Step;
			this.Intra11.Content = this.tetra11.ToString("0.00");
			this.tetra12 = this.tetra11 + this.Step;
			this.Intra12.Content = this.tetra12.ToString("0.00");
			this.tetra13 = this.tetra12 + this.Step;
			this.Intra13.Content = this.tetra13.ToString("0.00");
			this.tetra14 = this.tetra13 + this.Step;
			this.Intra14.Content = this.tetra14.ToString("0.00");
			this.tetra15 = this.tetra14 + this.Step;
			this.Intra15.Content = this.tetra15.ToString("0.00");
			this.tetra16 = this.tetra15 + this.Step;
			this.Intra16.Content = this.tetra16.ToString("0.00");
			this.tetra17 = this.tetra16 + this.Step;
			this.Intra17.Content = this.tetra17.ToString("0.00");
			this.tetra18 = this.tetra17 + this.Step;
			this.Intra18.Content = this.tetra18.ToString("0.00");
			this.tetra19 = this.tetra18 + this.Step;
			this.Intra19.Content = this.tetra19.ToString("0.00");
			this.tetra20 = this.tetra19 + this.Step;
			this.Intra20.Content = this.tetra20.ToString("0.00");
			this.tetra21 = this.tetra20 + this.Step;
			this.Intra21.Content = this.tetra21.ToString("0.00");
			this.tetra22 = this.tetra21 + this.Step;
			this.Intra22.Content = this.tetra22.ToString("0.00");
			this.tetra23 = this.tetra22 + this.Step;
			this.Intra23.Content = this.tetra23.ToString("0.00");
			this.tetra24 = this.tetra23 + this.Step;
			this.Intra24.Content = this.tetra24.ToString("0.00");
			this.tetra25 = this.tetra24 + this.Step;
			this.Intra25.Content = this.tetra25.ToString("0.00");
			this.tetra26 = this.tetra25 + this.Step;
			this.Intra26.Content = this.tetra26.ToString("0.00");
			this.tetra27 = this.tetra26 + this.Step;
			this.Intra27.Content = this.tetra27.ToString("0.00");
			this.tetra28 = this.tetra27 + this.Step;
			this.Intra28.Content = this.tetra28.ToString("0.00");
			this.tetra29 = this.tetra28 + this.Step;
			this.Intra29.Content = this.tetra29.ToString("0.00");
			this.tetra30 = this.tetra29 + this.Step;
			this.Intra30.Content = this.tetra30.ToString("0.00");
			this.tetra31 = this.tetra30 + this.Step;
			this.Intra31.Content = this.tetra31.ToString("0.00");
			this.tetra32 = this.tetra31 + this.Step;
			this.Intra32.Content = this.tetra32.ToString("0.00");
			this.tetra33 = this.tetra32 + this.Step;
			this.Intra33.Content = this.tetra33.ToString("0.00");
			this.tetra34 = this.tetra33 + this.Step;
			this.Intra34.Content = this.tetra34.ToString("0.00");
			this.tetra35 = this.tetra34 + this.Step;
			this.Intra35.Content = this.tetra35.ToString("0.00");
			this.tetra36 = this.tetra35 + this.Step;
			this.Intra36.Content = this.tetra36.ToString("0.00");
			this.tetra37 = this.tetra36 + this.Step;
			this.Intra37.Content = this.tetra37.ToString("0.00");
			this.tetra38 = this.tetra37 + this.Step;
			this.Intra38.Content = this.tetra38.ToString("0.00");
			this.tetra39 = this.tetra38 + this.Step;
			this.Intra39.Content = this.tetra39.ToString("0.00");
			this.tetra40 = this.tetra39 + this.Step;
			this.Intra40.Content = this.tetra40.ToString("0.00");
			this.tetra41 = this.tetra40 + this.Step;
			this.Intra41.Content = this.tetra41.ToString("0.00");
			this.tetra42 = this.tetra41 + this.Step;
			this.Intra42.Content = this.tetra42.ToString("0.00");
			this.tetra43 = this.tetra42 + this.Step;
			this.Intra43.Content = this.tetra43.ToString("0.00");
			this.tetra44 = this.tetra43 + this.Step;
			this.Intra44.Content = this.tetra44.ToString("0.00");
			this.tetra45 = this.tetra44 + this.Step;
			this.Intra45.Content = this.tetra45.ToString("0.00");
			this.tetra46 = this.tetra45 + this.Step;
			this.Intra46.Content = this.tetra46.ToString("0.00");
			this.tetra47 = this.tetra46 + this.Step;
			this.Intra47.Content = this.tetra47.ToString("0.00");
			this.tetra48 = this.tetra47 + this.Step;
			this.Intra48.Content = this.tetra48.ToString("0.00");
			this.tetra49 = this.tetra48 + this.Step;
			this.Intra49.Content = this.tetra49.ToString("0.00");
			this.tetra50 = this.tetra49 + this.Step;
			this.Intra50.Content = this.tetra50.ToString("0.00");
			this.tetra51 = this.tetra50 + this.Step;
			this.Intra51.Content = this.tetra51.ToString("0.00");
			this.tetra52 = this.tetra51 + this.Step;
			this.Intra52.Content = this.tetra52.ToString("0.00");
			this.tetra53 = this.tetra52 + this.Step;
			this.Intra53.Content = this.tetra53.ToString("0.00");
			this.tetra54 = this.tetra53 + this.Step;
			this.Intra54.Content = this.tetra54.ToString("0.00");
			this.tetra55 = this.tetra54 + this.Step;
			this.Intra55.Content = this.tetra55.ToString("0.00");
			this.tetra56 = this.tetra55 + this.Step;
			this.Intra56.Content = this.tetra56.ToString("0.00");
			this.tetra57 = this.tetra56 + this.Step;
			this.Intra57.Content = this.tetra57.ToString("0.00");
			this.tetra58 = this.tetra57 + this.Step;
			this.Intra58.Content = this.tetra58.ToString("0.00");
			this.tetra59 = this.tetra58 + this.Step;
			this.Intra59.Content = this.tetra59.ToString("0.00");
			this.tetra60 = this.tetra59 + this.Step;
			this.Intra60.Content = this.tetra60.ToString("0.00");
			this.tetra61 = this.tetra60 + this.Step;
			this.Intra61.Content = this.tetra61.ToString("0.00");
			this.tetra62 = this.tetra61 + this.Step;
			this.Intra62.Content = this.tetra62.ToString("0.00");
			this.tetra63 = this.tetra62 + this.Step;
			this.Intra63.Content = this.tetra63.ToString("0.00");
			this.tetra64 = this.tetra63 + this.Step;
			this.Intra64.Content = this.tetra64.ToString("0.00");
			this.tetra65 = this.tetra64 + this.Step;
			this.Intra65.Content = this.tetra65.ToString("0.00");
			this.tetra66 = this.tetra65 + this.Step;
			this.Intra66.Content = this.tetra66.ToString("0.00");
			this.tetra67 = this.tetra66 + this.Step;
			this.Intra67.Content = this.tetra67.ToString("0.00");
			this.tetra68 = this.tetra67 + this.Step;
			this.Intra68.Content = this.tetra68.ToString("0.00");
			this.tetra69 = this.tetra68 + this.Step;
			this.Intra69.Content = this.tetra69.ToString("0.00");
			this.tetra70 = this.tetra69 + this.Step;
			this.Intra70.Content = this.tetra70.ToString("0.00");
			this.tetra71 = this.tetra70 + this.Step;
			this.Intra71.Content = this.tetra71.ToString("0.00");
			this.tetra72 = this.tetra71 + this.Step;
			this.Intra72.Content = this.tetra72.ToString("0.00");
			this.tetra73 = this.tetra72 + this.Step;
			this.Intra73.Content = this.tetra73.ToString("0.00");
			this.tetra74 = this.tetra73 + this.Step;
			this.Intra74.Content = this.tetra74.ToString("0.00");
			this.tetra75 = this.tetra74 + this.Step;
			this.Intra75.Content = this.tetra75.ToString("0.00");
			this.tetra76 = this.tetra75 + this.Step;
			this.Intra76.Content = this.tetra76.ToString("0.00");
			this.tetra77 = this.tetra76 + this.Step;
			this.Intra77.Content = this.tetra77.ToString("0.00");
			this.tetra78 = this.tetra77 + this.Step;
			this.Intra78.Content = this.tetra78.ToString("0.00");
			this.tetra79 = this.tetra78 + this.Step;
			this.Intra79.Content = this.tetra79.ToString("0.00");
			this.tetra80 = this.tetra79 + this.Step;
			this.Intra80.Content = this.tetra80.ToString("0.00");
			this.tetra81 = this.tetra80 + this.Step;
			this.Intra81.Content = this.tetra81.ToString("0.00");
			this.tetra82 = this.tetra81 + this.Step;
			this.Intra82.Content = this.tetra82.ToString("0.00");
			this.tetra83 = this.tetra82 + this.Step;
			this.Intra83.Content = this.tetra83.ToString("0.00");
			this.tetra84 = this.tetra83 + this.Step;
			this.Intra84.Content = this.tetra84.ToString("0.00");
			this.tetra85 = this.tetra84 + this.Step;
			this.Intra85.Content = this.tetra85.ToString("0.00");
			this.tetra86 = this.tetra85 + this.Step;
			this.Intra86.Content = this.tetra86.ToString("0.00");
			this.tetra87 = this.tetra86 + this.Step;
			this.Intra87.Content = this.tetra87.ToString("0.00");
			this.tetra88 = this.tetra87 + this.Step;
			this.Intra88.Content = this.tetra88.ToString("0.00");
			this.tetra89 = this.tetra88 + this.Step;
			this.Intra89.Content = this.tetra89.ToString("0.00");
			this.tetra90 = this.tetra89 + this.Step;
			this.Intra90.Content = this.tetra90.ToString("0.00");
			this.tetra91 = this.tetra90 + this.Step;
			this.Intra91.Content = this.tetra91.ToString("0.00");
			this.tetra92 = this.tetra91 + this.Step;
			this.Intra92.Content = this.tetra92.ToString("0.00");
			this.tetra93 = this.tetra92 + this.Step;
			this.Intra93.Content = this.tetra93.ToString("0.00");
			this.tetra94 = this.tetra93 + this.Step;
			this.Intra94.Content = this.tetra94.ToString("0.00");
			this.tetra95 = this.tetra94 + this.Step;
			this.Intra95.Content = this.tetra95.ToString("0.00");
			this.tetra96 = this.tetra95 + this.Step;
			this.Intra96.Content = this.tetra96.ToString("0.00");
			this.tetra97 = this.tetra96 + this.Step;
			this.Intra97.Content = this.tetra97.ToString("0.00");
			this.tetra98 = this.tetra97 + this.Step;
			this.Intra98.Content = this.tetra98.ToString("0.00");
			this.tetra99 = this.tetra98 + this.Step;
			this.Intra99.Content = this.tetra99.ToString("0.00");
			this.tetra100 = this.tetra99 + this.Step;
			this.Intra100.Content = this.tetra100.ToString("0.00");
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000857D8 File Offset: 0x000839D8
		private void Initialize_Variable()
		{
			this.Seed = Equtiy_Future.seed;
			this.Step = Equtiy_Future.step;
			this.Clear();
			this.tetra1 = this.Seed + this.Step;
			this.Intra1.Content = this.tetra1.ToString("0.00");
			this.tetra2 = this.tetra1 + this.Step;
			this.Intra2.Content = this.tetra2.ToString("0.00");
			this.tetra3 = this.tetra2 + this.Step;
			this.Intra3.Content = this.tetra3.ToString("0.00");
			this.tetra4 = this.tetra3 + this.Step;
			this.Intra4.Content = this.tetra4.ToString("0.00");
			this.tetra5 = this.tetra4 + this.Step;
			this.Intra5.Content = this.tetra5.ToString("0.00");
			this.tetra6 = this.tetra5 + this.Step;
			this.Intra6.Content = this.tetra6.ToString("0.00");
			this.tetra7 = this.tetra6 + this.Step;
			this.Intra7.Content = this.tetra7.ToString("0.00");
			this.tetra8 = this.tetra7 + this.Step;
			this.Intra8.Content = this.tetra8.ToString("0.00");
			this.tetra9 = this.tetra8 + this.Step;
			this.Intra9.Content = this.tetra9.ToString("0.00");
			this.tetra10 = this.tetra9 + this.Step;
			this.Intra10.Content = this.tetra10.ToString("0.00");
			this.tetra11 = this.tetra10 + this.Step;
			this.Intra11.Content = this.tetra11.ToString("0.00");
			this.tetra12 = this.tetra11 + this.Step;
			this.Intra12.Content = this.tetra12.ToString("0.00");
			this.tetra13 = this.tetra12 + this.Step;
			this.Intra13.Content = this.tetra13.ToString("0.00");
			this.tetra14 = this.tetra13 + this.Step;
			this.Intra14.Content = this.tetra14.ToString("0.00");
			this.tetra15 = this.tetra14 + this.Step;
			this.Intra15.Content = this.tetra15.ToString("0.00");
			this.tetra16 = this.tetra15 + this.Step;
			this.Intra16.Content = this.tetra16.ToString("0.00");
			this.tetra17 = this.tetra16 + this.Step;
			this.Intra17.Content = this.tetra17.ToString("0.00");
			this.tetra18 = this.tetra17 + this.Step;
			this.Intra18.Content = this.tetra18.ToString("0.00");
			this.tetra19 = this.tetra18 + this.Step;
			this.Intra19.Content = this.tetra19.ToString("0.00");
			this.tetra20 = this.tetra19 + this.Step;
			this.Intra20.Content = this.tetra20.ToString("0.00");
			this.tetra21 = this.tetra20 + this.Step;
			this.Intra21.Content = this.tetra21.ToString("0.00");
			this.tetra22 = this.tetra21 + this.Step;
			this.Intra22.Content = this.tetra22.ToString("0.00");
			this.tetra23 = this.tetra22 + this.Step;
			this.Intra23.Content = this.tetra23.ToString("0.00");
			this.tetra24 = this.tetra23 + this.Step;
			this.Intra24.Content = this.tetra24.ToString("0.00");
			this.tetra25 = this.tetra24 + this.Step;
			this.Intra25.Content = this.tetra25.ToString("0.00");
			this.tetra26 = this.tetra25 + this.Step;
			this.Intra26.Content = this.tetra26.ToString("0.00");
			this.tetra27 = this.tetra26 + this.Step;
			this.Intra27.Content = this.tetra27.ToString("0.00");
			this.tetra28 = this.tetra27 + this.Step;
			this.Intra28.Content = this.tetra28.ToString("0.00");
			this.tetra29 = this.tetra28 + this.Step;
			this.Intra29.Content = this.tetra29.ToString("0.00");
			this.tetra30 = this.tetra29 + this.Step;
			this.Intra30.Content = this.tetra30.ToString("0.00");
			this.tetra31 = this.tetra30 + this.Step;
			this.Intra31.Content = this.tetra31.ToString("0.00");
			this.tetra32 = this.tetra31 + this.Step;
			this.Intra32.Content = this.tetra32.ToString("0.00");
			this.tetra33 = this.tetra32 + this.Step;
			this.Intra33.Content = this.tetra33.ToString("0.00");
			this.tetra34 = this.tetra33 + this.Step;
			this.Intra34.Content = this.tetra34.ToString("0.00");
			this.tetra35 = this.tetra34 + this.Step;
			this.Intra35.Content = this.tetra35.ToString("0.00");
			this.tetra36 = this.tetra35 + this.Step;
			this.Intra36.Content = this.tetra36.ToString("0.00");
			this.tetra37 = this.tetra36 + this.Step;
			this.Intra37.Content = this.tetra37.ToString("0.00");
			this.tetra38 = this.tetra37 + this.Step;
			this.Intra38.Content = this.tetra38.ToString("0.00");
			this.tetra39 = this.tetra38 + this.Step;
			this.Intra39.Content = this.tetra39.ToString("0.00");
			this.tetra40 = this.tetra39 + this.Step;
			this.Intra40.Content = this.tetra40.ToString("0.00");
			this.tetra41 = this.tetra40 + this.Step;
			this.Intra41.Content = this.tetra41.ToString("0.00");
			this.tetra42 = this.tetra41 + this.Step;
			this.Intra42.Content = this.tetra42.ToString("0.00");
			this.tetra43 = this.tetra42 + this.Step;
			this.Intra43.Content = this.tetra43.ToString("0.00");
			this.tetra44 = this.tetra43 + this.Step;
			this.Intra44.Content = this.tetra44.ToString("0.00");
			this.tetra45 = this.tetra44 + this.Step;
			this.Intra45.Content = this.tetra45.ToString("0.00");
			this.tetra46 = this.tetra45 + this.Step;
			this.Intra46.Content = this.tetra46.ToString("0.00");
			this.tetra47 = this.tetra46 + this.Step;
			this.Intra47.Content = this.tetra47.ToString("0.00");
			this.tetra48 = this.tetra47 + this.Step;
			this.Intra48.Content = this.tetra48.ToString("0.00");
			this.tetra49 = this.tetra48 + this.Step;
			this.Intra49.Content = this.tetra49.ToString("0.00");
			this.tetra50 = this.tetra49 + this.Step;
			this.Intra50.Content = this.tetra50.ToString("0.00");
			this.tetra51 = this.tetra50 + this.Step;
			this.Intra51.Content = this.tetra51.ToString("0.00");
			this.tetra52 = this.tetra51 + this.Step;
			this.Intra52.Content = this.tetra52.ToString("0.00");
			this.tetra53 = this.tetra52 + this.Step;
			this.Intra53.Content = this.tetra53.ToString("0.00");
			this.tetra54 = this.tetra53 + this.Step;
			this.Intra54.Content = this.tetra54.ToString("0.00");
			this.tetra55 = this.tetra54 + this.Step;
			this.Intra55.Content = this.tetra55.ToString("0.00");
			this.tetra56 = this.tetra55 + this.Step;
			this.Intra56.Content = this.tetra56.ToString("0.00");
			this.tetra57 = this.tetra56 + this.Step;
			this.Intra57.Content = this.tetra57.ToString("0.00");
			this.tetra58 = this.tetra57 + this.Step;
			this.Intra58.Content = this.tetra58.ToString("0.00");
			this.tetra59 = this.tetra58 + this.Step;
			this.Intra59.Content = this.tetra59.ToString("0.00");
			this.tetra60 = this.tetra59 + this.Step;
			this.Intra60.Content = this.tetra60.ToString("0.00");
			this.tetra61 = this.tetra60 + this.Step;
			this.Intra61.Content = this.tetra61.ToString("0.00");
			this.tetra62 = this.tetra61 + this.Step;
			this.Intra62.Content = this.tetra62.ToString("0.00");
			this.tetra63 = this.tetra62 + this.Step;
			this.Intra63.Content = this.tetra63.ToString("0.00");
			this.tetra64 = this.tetra63 + this.Step;
			this.Intra64.Content = this.tetra64.ToString("0.00");
			this.tetra65 = this.tetra64 + this.Step;
			this.Intra65.Content = this.tetra65.ToString("0.00");
			this.tetra66 = this.tetra65 + this.Step;
			this.Intra66.Content = this.tetra66.ToString("0.00");
			this.tetra67 = this.tetra66 + this.Step;
			this.Intra67.Content = this.tetra67.ToString("0.00");
			this.tetra68 = this.tetra67 + this.Step;
			this.Intra68.Content = this.tetra68.ToString("0.00");
			this.tetra69 = this.tetra68 + this.Step;
			this.Intra69.Content = this.tetra69.ToString("0.00");
			this.tetra70 = this.tetra69 + this.Step;
			this.Intra70.Content = this.tetra70.ToString("0.00");
			this.tetra71 = this.tetra70 + this.Step;
			this.Intra71.Content = this.tetra71.ToString("0.00");
			this.tetra72 = this.tetra71 + this.Step;
			this.Intra72.Content = this.tetra72.ToString("0.00");
			this.tetra73 = this.tetra72 + this.Step;
			this.Intra73.Content = this.tetra73.ToString("0.00");
			this.tetra74 = this.tetra73 + this.Step;
			this.Intra74.Content = this.tetra74.ToString("0.00");
			this.tetra75 = this.tetra74 + this.Step;
			this.Intra75.Content = this.tetra75.ToString("0.00");
			this.tetra76 = this.tetra75 + this.Step;
			this.Intra76.Content = this.tetra76.ToString("0.00");
			this.tetra77 = this.tetra76 + this.Step;
			this.Intra77.Content = this.tetra77.ToString("0.00");
			this.tetra78 = this.tetra77 + this.Step;
			this.Intra78.Content = this.tetra78.ToString("0.00");
			this.tetra79 = this.tetra78 + this.Step;
			this.Intra79.Content = this.tetra79.ToString("0.00");
			this.tetra80 = this.tetra79 + this.Step;
			this.Intra80.Content = this.tetra80.ToString("0.00");
			this.tetra81 = this.tetra80 + this.Step;
			this.Intra81.Content = this.tetra81.ToString("0.00");
			this.tetra82 = this.tetra81 + this.Step;
			this.Intra82.Content = this.tetra82.ToString("0.00");
			this.tetra83 = this.tetra82 + this.Step;
			this.Intra83.Content = this.tetra83.ToString("0.00");
			this.tetra84 = this.tetra83 + this.Step;
			this.Intra84.Content = this.tetra84.ToString("0.00");
			this.tetra85 = this.tetra84 + this.Step;
			this.Intra85.Content = this.tetra85.ToString("0.00");
			this.tetra86 = this.tetra85 + this.Step;
			this.Intra86.Content = this.tetra86.ToString("0.00");
			this.tetra87 = this.tetra86 + this.Step;
			this.Intra87.Content = this.tetra87.ToString("0.00");
			this.tetra88 = this.tetra87 + this.Step;
			this.Intra88.Content = this.tetra88.ToString("0.00");
			this.tetra89 = this.tetra88 + this.Step;
			this.Intra89.Content = this.tetra89.ToString("0.00");
			this.tetra90 = this.tetra89 + this.Step;
			this.Intra90.Content = this.tetra90.ToString("0.00");
			this.tetra91 = this.tetra90 + this.Step;
			this.Intra91.Content = this.tetra91.ToString("0.00");
			this.tetra92 = this.tetra91 + this.Step;
			this.Intra92.Content = this.tetra92.ToString("0.00");
			this.tetra93 = this.tetra92 + this.Step;
			this.Intra93.Content = this.tetra93.ToString("0.00");
			this.tetra94 = this.tetra93 + this.Step;
			this.Intra94.Content = this.tetra94.ToString("0.00");
			this.tetra95 = this.tetra94 + this.Step;
			this.Intra95.Content = this.tetra95.ToString("0.00");
			this.tetra96 = this.tetra95 + this.Step;
			this.Intra96.Content = this.tetra96.ToString("0.00");
			this.tetra97 = this.tetra96 + this.Step;
			this.Intra97.Content = this.tetra97.ToString("0.00");
			this.tetra98 = this.tetra97 + this.Step;
			this.Intra98.Content = this.tetra98.ToString("0.00");
			this.tetra99 = this.tetra98 + this.Step;
			this.Intra99.Content = this.tetra99.ToString("0.00");
			this.tetra100 = this.tetra99 + this.Step;
			this.Intra100.Content = this.tetra100.ToString("0.00");
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000869FC File Offset: 0x00084BFC
		private void Clear()
		{
			this.Intra1.Content = string.Empty;
			this.Intra2.Content = string.Empty;
			this.Intra3.Content = string.Empty;
			this.Intra4.Content = string.Empty;
			this.Intra5.Content = string.Empty;
			this.Intra6.Content = string.Empty;
			this.Intra7.Content = string.Empty;
			this.Intra8.Content = string.Empty;
			this.Intra9.Content = string.Empty;
			this.Intra10.Content = string.Empty;
			this.Intra11.Content = string.Empty;
			this.Intra12.Content = string.Empty;
			this.Intra13.Content = string.Empty;
			this.Intra14.Content = string.Empty;
			this.Intra15.Content = string.Empty;
			this.Intra16.Content = string.Empty;
			this.Intra17.Content = string.Empty;
			this.Intra18.Content = string.Empty;
			this.Intra19.Content = string.Empty;
			this.Intra20.Content = string.Empty;
			this.Intra21.Content = string.Empty;
			this.Intra22.Content = string.Empty;
			this.Intra23.Content = string.Empty;
			this.Intra24.Content = string.Empty;
			this.Intra25.Content = string.Empty;
			this.Intra26.Content = string.Empty;
			this.Intra27.Content = string.Empty;
			this.Intra28.Content = string.Empty;
			this.Intra29.Content = string.Empty;
			this.Intra30.Content = string.Empty;
			this.Intra31.Content = string.Empty;
			this.Intra32.Content = string.Empty;
			this.Intra33.Content = string.Empty;
			this.Intra34.Content = string.Empty;
			this.Intra35.Content = string.Empty;
			this.Intra36.Content = string.Empty;
			this.Intra37.Content = string.Empty;
			this.Intra38.Content = string.Empty;
			this.Intra39.Content = string.Empty;
			this.Intra40.Content = string.Empty;
			this.Intra41.Content = string.Empty;
			this.Intra42.Content = string.Empty;
			this.Intra43.Content = string.Empty;
			this.Intra44.Content = string.Empty;
			this.Intra45.Content = string.Empty;
			this.Intra46.Content = string.Empty;
			this.Intra47.Content = string.Empty;
			this.Intra48.Content = string.Empty;
			this.Intra49.Content = string.Empty;
			this.Intra50.Content = string.Empty;
			this.Intra51.Content = string.Empty;
			this.Intra52.Content = string.Empty;
			this.Intra53.Content = string.Empty;
			this.Intra54.Content = string.Empty;
			this.Intra55.Content = string.Empty;
			this.Intra56.Content = string.Empty;
			this.Intra57.Content = string.Empty;
			this.Intra58.Content = string.Empty;
			this.Intra59.Content = string.Empty;
			this.Intra60.Content = string.Empty;
			this.Intra61.Content = string.Empty;
			this.Intra62.Content = string.Empty;
			this.Intra63.Content = string.Empty;
			this.Intra64.Content = string.Empty;
			this.Intra65.Content = string.Empty;
			this.Intra66.Content = string.Empty;
			this.Intra67.Content = string.Empty;
			this.Intra68.Content = string.Empty;
			this.Intra69.Content = string.Empty;
			this.Intra70.Content = string.Empty;
			this.Intra71.Content = string.Empty;
			this.Intra72.Content = string.Empty;
			this.Intra73.Content = string.Empty;
			this.Intra74.Content = string.Empty;
			this.Intra75.Content = string.Empty;
			this.Intra76.Content = string.Empty;
			this.Intra77.Content = string.Empty;
			this.Intra78.Content = string.Empty;
			this.Intra79.Content = string.Empty;
			this.Intra80.Content = string.Empty;
			this.Intra81.Content = string.Empty;
			this.Intra82.Content = string.Empty;
			this.Intra83.Content = string.Empty;
			this.Intra84.Content = string.Empty;
			this.Intra85.Content = string.Empty;
			this.Intra86.Content = string.Empty;
			this.Intra87.Content = string.Empty;
			this.Intra88.Content = string.Empty;
			this.Intra89.Content = string.Empty;
			this.Intra90.Content = string.Empty;
			this.Intra91.Content = string.Empty;
			this.Intra92.Content = string.Empty;
			this.Intra93.Content = string.Empty;
			this.Intra94.Content = string.Empty;
			this.Intra95.Content = string.Empty;
			this.Intra96.Content = string.Empty;
			this.Intra97.Content = string.Empty;
			this.Intra98.Content = string.Empty;
			this.Intra99.Content = string.Empty;
			this.Intra100.Content = string.Empty;
		}

		// Token: 0x0400110E RID: 4366
		public double tetra1;

		// Token: 0x0400110F RID: 4367
		public double tetra2;

		// Token: 0x04001110 RID: 4368
		public double tetra3;

		// Token: 0x04001111 RID: 4369
		public double tetra4;

		// Token: 0x04001112 RID: 4370
		public double tetra5;

		// Token: 0x04001113 RID: 4371
		public double tetra6;

		// Token: 0x04001114 RID: 4372
		public double tetra7;

		// Token: 0x04001115 RID: 4373
		public double tetra8;

		// Token: 0x04001116 RID: 4374
		public double tetra9;

		// Token: 0x04001117 RID: 4375
		public double tetra10;

		// Token: 0x04001118 RID: 4376
		public double tetra11;

		// Token: 0x04001119 RID: 4377
		public double tetra12;

		// Token: 0x0400111A RID: 4378
		public double tetra13;

		// Token: 0x0400111B RID: 4379
		public double tetra14;

		// Token: 0x0400111C RID: 4380
		public double tetra15;

		// Token: 0x0400111D RID: 4381
		public double tetra16;

		// Token: 0x0400111E RID: 4382
		public double tetra17;

		// Token: 0x0400111F RID: 4383
		public double tetra18;

		// Token: 0x04001120 RID: 4384
		public double tetra19;

		// Token: 0x04001121 RID: 4385
		public double tetra20;

		// Token: 0x04001122 RID: 4386
		public double tetra21;

		// Token: 0x04001123 RID: 4387
		public double tetra22;

		// Token: 0x04001124 RID: 4388
		public double tetra23;

		// Token: 0x04001125 RID: 4389
		public double tetra24;

		// Token: 0x04001126 RID: 4390
		public double tetra25;

		// Token: 0x04001127 RID: 4391
		public double tetra26;

		// Token: 0x04001128 RID: 4392
		public double tetra27;

		// Token: 0x04001129 RID: 4393
		public double tetra28;

		// Token: 0x0400112A RID: 4394
		public double tetra29;

		// Token: 0x0400112B RID: 4395
		public double tetra30;

		// Token: 0x0400112C RID: 4396
		public double tetra31;

		// Token: 0x0400112D RID: 4397
		public double tetra32;

		// Token: 0x0400112E RID: 4398
		public double tetra33;

		// Token: 0x0400112F RID: 4399
		public double tetra34;

		// Token: 0x04001130 RID: 4400
		public double tetra35;

		// Token: 0x04001131 RID: 4401
		public double tetra36;

		// Token: 0x04001132 RID: 4402
		public double tetra37;

		// Token: 0x04001133 RID: 4403
		public double tetra38;

		// Token: 0x04001134 RID: 4404
		public double tetra39;

		// Token: 0x04001135 RID: 4405
		public double tetra40;

		// Token: 0x04001136 RID: 4406
		public double tetra41;

		// Token: 0x04001137 RID: 4407
		public double tetra42;

		// Token: 0x04001138 RID: 4408
		public double tetra43;

		// Token: 0x04001139 RID: 4409
		public double tetra44;

		// Token: 0x0400113A RID: 4410
		public double tetra45;

		// Token: 0x0400113B RID: 4411
		public double tetra46;

		// Token: 0x0400113C RID: 4412
		public double tetra47;

		// Token: 0x0400113D RID: 4413
		public double tetra48;

		// Token: 0x0400113E RID: 4414
		public double tetra49;

		// Token: 0x0400113F RID: 4415
		public double tetra50;

		// Token: 0x04001140 RID: 4416
		public double tetra51;

		// Token: 0x04001141 RID: 4417
		public double tetra52;

		// Token: 0x04001142 RID: 4418
		public double tetra53;

		// Token: 0x04001143 RID: 4419
		public double tetra54;

		// Token: 0x04001144 RID: 4420
		public double tetra55;

		// Token: 0x04001145 RID: 4421
		public double tetra56;

		// Token: 0x04001146 RID: 4422
		public double tetra57;

		// Token: 0x04001147 RID: 4423
		public double tetra58;

		// Token: 0x04001148 RID: 4424
		public double tetra59;

		// Token: 0x04001149 RID: 4425
		public double tetra60;

		// Token: 0x0400114A RID: 4426
		public double tetra61;

		// Token: 0x0400114B RID: 4427
		public double tetra62;

		// Token: 0x0400114C RID: 4428
		public double tetra63;

		// Token: 0x0400114D RID: 4429
		public double tetra64;

		// Token: 0x0400114E RID: 4430
		public double tetra65;

		// Token: 0x0400114F RID: 4431
		public double tetra66;

		// Token: 0x04001150 RID: 4432
		public double tetra67;

		// Token: 0x04001151 RID: 4433
		public double tetra68;

		// Token: 0x04001152 RID: 4434
		public double tetra69;

		// Token: 0x04001153 RID: 4435
		public double tetra70;

		// Token: 0x04001154 RID: 4436
		public double tetra71;

		// Token: 0x04001155 RID: 4437
		public double tetra72;

		// Token: 0x04001156 RID: 4438
		public double tetra73;

		// Token: 0x04001157 RID: 4439
		public double tetra74;

		// Token: 0x04001158 RID: 4440
		public double tetra75;

		// Token: 0x04001159 RID: 4441
		public double tetra76;

		// Token: 0x0400115A RID: 4442
		public double tetra77;

		// Token: 0x0400115B RID: 4443
		public double tetra78;

		// Token: 0x0400115C RID: 4444
		public double tetra79;

		// Token: 0x0400115D RID: 4445
		public double tetra80;

		// Token: 0x0400115E RID: 4446
		public double tetra81;

		// Token: 0x0400115F RID: 4447
		public double tetra82;

		// Token: 0x04001160 RID: 4448
		public double tetra83;

		// Token: 0x04001161 RID: 4449
		public double tetra84;

		// Token: 0x04001162 RID: 4450
		public double tetra85;

		// Token: 0x04001163 RID: 4451
		public double tetra86;

		// Token: 0x04001164 RID: 4452
		public double tetra87;

		// Token: 0x04001165 RID: 4453
		public double tetra88;

		// Token: 0x04001166 RID: 4454
		public double tetra89;

		// Token: 0x04001167 RID: 4455
		public double tetra90;

		// Token: 0x04001168 RID: 4456
		public double tetra91;

		// Token: 0x04001169 RID: 4457
		public double tetra92;

		// Token: 0x0400116A RID: 4458
		public double tetra93;

		// Token: 0x0400116B RID: 4459
		public double tetra94;

		// Token: 0x0400116C RID: 4460
		public double tetra95;

		// Token: 0x0400116D RID: 4461
		public double tetra96;

		// Token: 0x0400116E RID: 4462
		public double tetra97;

		// Token: 0x0400116F RID: 4463
		public double tetra98;

		// Token: 0x04001170 RID: 4464
		public double tetra99;

		// Token: 0x04001171 RID: 4465
		public double tetra100;

		// Token: 0x04001172 RID: 4466
		public double Seed;

		// Token: 0x04001173 RID: 4467
		public double Step;
	}
}
