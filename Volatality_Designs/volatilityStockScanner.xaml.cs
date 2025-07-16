using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using siteDownLoadHelper;

namespace New_SF_IT.Volatality_Designs
{
	// Token: 0x02000023 RID: 35
	[NullableContext(1)]
	[Nullable(0)]
	public partial class volatilityStockScanner : UserControl
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00018A6C File Offset: 0x00016C6C
		public volatilityStockScanner()
		{
			this.InitializeComponent();
			this.loadSymbols("STOCK FUTURE");
			this.LabelVolaRise.Visibility = Visibility.Hidden;
			this.LabelVolaFall.Visibility = Visibility.Hidden;
			this.LabelVolaNoChange.Visibility = Visibility.Hidden;
			this.label1.Visibility = Visibility.Hidden;
			this.label2.Visibility = Visibility.Hidden;
			this.label3.Visibility = Visibility.Hidden;
			this.label4.Visibility = Visibility.Hidden;
			this.label5.Visibility = Visibility.Hidden;
			this.label6.Visibility = Visibility.Hidden;
			this.label7.Visibility = Visibility.Hidden;
			this.label8.Visibility = Visibility.Hidden;
			this.label9.Visibility = Visibility.Hidden;
			this.label10.Visibility = Visibility.Hidden;
			this.label11.Visibility = Visibility.Hidden;
			this.label12.Visibility = Visibility.Hidden;
			this.scrollViewer.Visibility = Visibility.Hidden;
			this.note.Visibility = Visibility.Hidden;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00018CA6 File Offset: 0x00016EA6
		private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
			{
				e.Handled = true;
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00018CD8 File Offset: 0x00016ED8
		public void loadSymbols(string _instrument)
		{
			if (_instrument == "STOCK FUTURE")
			{
				string data = new downloadSiteCls(new Uri(this.STOCKFUTUREPATH)).getSite();
				if (data == null)
				{
					MessageBox.Show("Please try after sometimes", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				data = data.Replace("\r", "");
				if (!string.IsNullOrWhiteSpace(data))
				{
					this._stockSymbols = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
				}
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00018D54 File Offset: 0x00016F54
		private void textBoxVolaRise_Symbols_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string selectedSymbol = this.textBoxVolaRise_Symbols.SelectedText;
			if (this._stockSymbols.FirstOrDefault((string i) => i == selectedSymbol) == null && selectedSymbol != "BANKNIFTY")
			{
				MessageBox.Show("Double click on the symbol properly", "Pls try again", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.index.SelectedIndex == 0)
			{
				double zScoreNow = zScore.getzScoreForCurrentPrice(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 1)
			{
				double zScoreNow2 = zScore.getzScoreForCurrentPrice_banknifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow2.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 2)
			{
				double zScoreNow3 = zScore.getzScoreForCurrentPrice_finnifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow3.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00018E78 File Offset: 0x00017078
		private void textBoxVolaFall_Symbols_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string selectedSymbol = this.textBoxVolaFall_Symbols.SelectedText;
			if (this._stockSymbols.FirstOrDefault((string i) => i == selectedSymbol) == null && selectedSymbol != "BANKNIFTY")
			{
				MessageBox.Show("Double click on the symbol properly", "Pls try again", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.index.SelectedIndex == 0)
			{
				double zScoreNow = zScore.getzScoreForCurrentPrice(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 1)
			{
				double zScoreNow2 = zScore.getzScoreForCurrentPrice_banknifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow2.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 2)
			{
				double zScoreNow3 = zScore.getzScoreForCurrentPrice_finnifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow3.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00018F9C File Offset: 0x0001719C
		private void textBoxVolaNoChange_Symbols_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string selectedSymbol = this.textBoxVolaNoChange_Symbols.SelectedText;
			if (this._stockSymbols.FirstOrDefault((string i) => i == selectedSymbol) == null && selectedSymbol != "BANKNIFTY")
			{
				MessageBox.Show("Double click on the symbol properly", "Pls try again", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.index.SelectedIndex == 0)
			{
				double zScoreNow = zScore.getzScoreForCurrentPrice(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 1)
			{
				double zScoreNow2 = zScore.getzScoreForCurrentPrice_banknifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow2.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				return;
			}
			if (this.index.SelectedIndex == 2)
			{
				double zScoreNow3 = zScore.getzScoreForCurrentPrice_finnifty(selectedSymbol);
				MessageBox.Show(selectedSymbol + ": " + zScoreNow3.ToString(), "Z-Score as per the Current Price", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000190BD File Offset: 0x000172BD
		private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			this.scrollViewer.ScrollToVerticalOffset(this.scrollViewer.VerticalOffset - (double)(e.Delta / 3));
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000190DF File Offset: 0x000172DF
		private void index_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.scanData(sender, e);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000190EC File Offset: 0x000172EC
		public void scanData(object sender, RoutedEventArgs e)
		{
			this.scanButton.Content = "Scanning...";
			StocksBasedVolatility.getStocksBasedOnVolatility();
			if (this.index.SelectedIndex == 0)
			{
				correlation.getStocksBasedOnCorrelation();
				var query_correlationForVolatility_Rise_Symbols = StocksBasedVolatility.volatility_Rise.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					string key = keyValuePair.Key;
					keyValuePair = y;
					return new
					{
						Value1 = key,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_Rise_Symbols = query_correlationForVolatility_Rise_Symbols.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<string, double> group) => group.Key, (IGrouping<string, double> group) => group.Last<double>());
				this.correlationForVolatility_Rise_Symbols = (from u in this.correlationForVolatility_Rise_Symbols
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> v) => v.Value);
				foreach (KeyValuePair<string, double> kvp28 in this.correlationForVolatility_Rise_Symbols)
				{
					this.corrForVol_Rise_Symbols[kvp28.Key] = kvp28.Value;
				}
				var query_correlationForVolatility_Rise = StocksBasedVolatility.volatility_Rise.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_Rise = query_correlationForVolatility_Rise.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<double, double> group) => group.Key, (IGrouping<double, double> group) => group.Last<double>());
				this.correlationForVolatility_Rise = (from u in this.correlationForVolatility_Rise
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value);
				foreach (KeyValuePair<double, double> kvp2 in this.correlationForVolatility_Rise)
				{
					this.corrForVol_Rise[kvp2.Key] = kvp2.Value;
				}
				var query_zScoreForVolatility_Rise = this.correlationForVolatility_Rise_Symbols.Join(correlation._zScore, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				});
				this.zScoreForVolatility_Rise = query_zScoreForVolatility_Rise.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<double, double> group) => group.Key, (IGrouping<double, double> group) => group.Last<double>());
				this.zScoreForVolatility_Rise = (from u in this.zScoreForVolatility_Rise
				orderby u.Key descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value);
				foreach (KeyValuePair<double, double> kvp3 in this.zScoreForVolatility_Rise)
				{
					this.zScoreForVol_Rise[kvp3.Key] = kvp3.Value;
				}
				var query_correlationForVolatility_Fall_Symbols = StocksBasedVolatility.volatility_Fall.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					string key = keyValuePair.Key;
					keyValuePair = y;
					return new
					{
						Value1 = key,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_Fall_Symbols = query_correlationForVolatility_Fall_Symbols.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<string, double> group) => group.Key, (IGrouping<string, double> group) => group.Last<double>());
				this.correlationForVolatility_Fall_Symbols = (from u in this.correlationForVolatility_Fall_Symbols
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> v) => v.Value);
				foreach (KeyValuePair<string, double> kvp4 in this.correlationForVolatility_Fall_Symbols)
				{
					this.corrForVol_Fall_Symbols[kvp4.Key] = kvp4.Value;
				}
				var query_correlationForVolatility_Fall = StocksBasedVolatility.volatility_Fall.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_Fall = query_correlationForVolatility_Fall.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<double, double> group) => group.Key, (IGrouping<double, double> group) => group.Last<double>());
				this.correlationForVolatility_Fall = (from u in this.correlationForVolatility_Fall
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value);
				foreach (KeyValuePair<double, double> kvp5 in this.correlationForVolatility_Fall)
				{
					this.corrForVol_Fall[kvp5.Key] = kvp5.Value;
				}
				var query_zScoreForVolatility_Fall = this.correlationForVolatility_Fall_Symbols.Join(correlation._zScore, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				});
				this.zScoreForVolatility_Fall = query_zScoreForVolatility_Fall.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<double, double> group) => group.Key, (IGrouping<double, double> group) => group.Last<double>());
				this.zScoreForVolatility_Fall = (from u in this.zScoreForVolatility_Fall
				orderby u.Key descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value);
				foreach (KeyValuePair<double, double> kvp6 in this.zScoreForVolatility_Fall)
				{
					this.zScoreForVol_Fall[kvp6.Key] = kvp6.Value;
				}
				var query_correlationForVolatility_NoChange_Symbols = StocksBasedVolatility.volatility_NoChange.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					string key = keyValuePair.Key;
					keyValuePair = y;
					return new
					{
						Value1 = key,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_NoChange_Symbols = query_correlationForVolatility_NoChange_Symbols.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<string, double> group) => group.Key, (IGrouping<string, double> group) => group.Last<double>());
				this.correlationForVolatility_NoChange_Symbols = (from u in this.correlationForVolatility_NoChange_Symbols
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> v) => v.Value);
				foreach (KeyValuePair<string, double> kvp7 in this.correlationForVolatility_NoChange_Symbols)
				{
					this.corrForVol_NoChange_Symbols[kvp7.Key] = kvp7.Value;
				}
				var query_correlationForVolatility_NoChange = StocksBasedVolatility.volatility_NoChange.Join(correlation._correlation, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				});
				this.correlationForVolatility_NoChange = query_correlationForVolatility_NoChange.ToLookup(item => item.Value1, item => item.Value2).ToDictionary((IGrouping<double, double> group) => group.Key, (IGrouping<double, double> group) => group.Last<double>());
				this.correlationForVolatility_NoChange = (from u in this.correlationForVolatility_NoChange
				orderby u.Value descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value);
				foreach (KeyValuePair<double, double> kvp8 in this.correlationForVolatility_NoChange)
				{
					this.corrForVol_NoChange[kvp8.Key] = kvp8.Value;
				}
				using (Dictionary<double, double>.Enumerator enumerator2 = (from u in (from item in this.correlationForVolatility_NoChange_Symbols.Join(correlation._zScore, delegate(KeyValuePair<string, double> x)
				{
					KeyValuePair<string, double> keyValuePair = x;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = y;
					return keyValuePair.Key;
				}, delegate(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
				{
					KeyValuePair<string, double> keyValuePair = x;
					double value = keyValuePair.Value;
					keyValuePair = y;
					return new
					{
						Value1 = value,
						Value2 = keyValuePair.Value
					};
				})
				group item by item.Value1).ToDictionary(@group => @group.Key, @group => @group.First().Value2)
				orderby u.Key descending
				select u).ToDictionary((KeyValuePair<double, double> x) => x.Key, (KeyValuePair<double, double> v) => v.Value).GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						KeyValuePair<double, double> kvp9 = enumerator2.Current;
						this.zScoreForVol_NoChange[kvp9.Key] = kvp9.Value;
					}
					goto IL_2486;
				}
			}
			if (this.index.SelectedIndex == 1)
			{
				correlation.stk_symbol_list = new List<string>();
				correlation._correlation = new Dictionary<string, double>();
				correlation._zScore = new Dictionary<string, double>();
				correlation.loadExpiry();
				List<string> DBsymbols = StocksBasedVolatility.dataDownload(correlation._currentMonthExpiry, correlation.stk_symbolsURL);
				if (DBsymbols.Any<string>())
				{
					string text = string.Join("", DBsymbols.ToArray());
					correlation.stk_symbol_list = StocksBasedVolatility.splitData(text.Remove(text.Length - 1), correlation.stk_symbolsURL);
				}
				string[] _11dayDataArray = correlation._11dayDataInArray(correlation._currentMonthExpiry, correlation._11daysLtpUrl);
				bool contains_BANKNIFTY = false;
				foreach (string input in correlation.stk_symbol_list)
				{
					contains_BANKNIFTY = Regex.IsMatch(input, "\\bBANKNIFTY\\b");
					if (contains_BANKNIFTY)
					{
						break;
					}
				}
				if (contains_BANKNIFTY)
				{
					int banknifty_index = correlation.stk_symbol_list.FindIndex((string a) => Regex.IsMatch(a, "\\bBANKNIFTY\\b"));
					double[] banknifty_last11Days = correlation.get_11dayLTP(_11dayDataArray.ElementAt(banknifty_index));
					double banknifty_day = banknifty_last11Days.ElementAt(0);
					double banknifty_day2 = banknifty_last11Days.ElementAt(1);
					double banknifty_day3 = banknifty_last11Days.ElementAt(2);
					double banknifty_day4 = banknifty_last11Days.ElementAt(3);
					double banknifty_day5 = banknifty_last11Days.ElementAt(4);
					double banknifty_day6 = banknifty_last11Days.ElementAt(5);
					double banknifty_day7 = banknifty_last11Days.ElementAt(6);
					double banknifty_day8 = banknifty_last11Days.ElementAt(7);
					double banknifty_day9 = banknifty_last11Days.ElementAt(8);
					double banknifty_day10 = banknifty_last11Days.ElementAt(9);
					double banknifty_day11 = banknifty_last11Days.ElementAt(10);
					List<double> x_banknifty = new List<double>();
					x_banknifty.Add((banknifty_day2 - banknifty_day) / banknifty_day2 * 100.0);
					x_banknifty.Add((banknifty_day3 - banknifty_day2) / banknifty_day3 * 100.0);
					x_banknifty.Add((banknifty_day4 - banknifty_day3) / banknifty_day4 * 100.0);
					x_banknifty.Add((banknifty_day5 - banknifty_day4) / banknifty_day5 * 100.0);
					x_banknifty.Add((banknifty_day6 - banknifty_day5) / banknifty_day6 * 100.0);
					x_banknifty.Add((banknifty_day7 - banknifty_day6) / banknifty_day7 * 100.0);
					x_banknifty.Add((banknifty_day8 - banknifty_day7) / banknifty_day8 * 100.0);
					x_banknifty.Add((banknifty_day9 - banknifty_day8) / banknifty_day9 * 100.0);
					x_banknifty.Add((banknifty_day10 - banknifty_day9) / banknifty_day10 * 100.0);
					x_banknifty.Add((banknifty_day11 - banknifty_day10) / banknifty_day11 * 100.0);
					for (int index = 0; index <= correlation.stk_symbol_list.Count - 2; index++)
					{
						string symbolNow = correlation.stk_symbol_list.ElementAt(index);
						if (symbolNow != "BANKNIFTY")
						{
							double[] _last11Days = correlation.get_11dayLTP(_11dayDataArray.ElementAt(index));
							double day = _last11Days.ElementAt(0);
							double day2 = _last11Days.ElementAt(1);
							double day3 = _last11Days.ElementAt(2);
							double day4 = _last11Days.ElementAt(3);
							double day5 = _last11Days.ElementAt(4);
							double day6 = _last11Days.ElementAt(5);
							double day7 = _last11Days.ElementAt(6);
							double day8 = _last11Days.ElementAt(7);
							double day9 = _last11Days.ElementAt(8);
							double day10 = _last11Days.ElementAt(9);
							double day11 = _last11Days.ElementAt(10);
							List<double> y3 = new List<double>();
							y3.Add((day2 - day) / day2 * 100.0);
							y3.Add((day3 - day2) / day3 * 100.0);
							y3.Add((day4 - day3) / day4 * 100.0);
							y3.Add((day5 - day4) / day5 * 100.0);
							y3.Add((day6 - day5) / day6 * 100.0);
							y3.Add((day7 - day6) / day7 * 100.0);
							y3.Add((day8 - day7) / day8 * 100.0);
							y3.Add((day9 - day8) / day9 * 100.0);
							y3.Add((day10 - day9) / day10 * 100.0);
							y3.Add((day11 - day10) / day11 * 100.0);
							double correlationResult = correlation.CorrCoEff(x_banknifty.ToArray(), y3.ToArray());
							correlationResult *= 100.0;
							correlation._correlation.Add(symbolNow, correlationResult);
							double zScoreResult = zScore.zScore_Calc(banknifty_last11Days, _last11Days);
							correlation._zScore.Add(symbolNow, zScoreResult);
						}
					}
				}
				this.corrForVol_Rise_Symbols.Clear();
				this.corrForVol_Rise.Clear();
				this.zScoreForVol_Rise.Clear();
				this.corrForVol_Fall_Symbols.Clear();
				this.corrForVol_Fall.Clear();
				this.zScoreForVol_Fall.Clear();
				this.corrForVol_NoChange_Symbols.Clear();
				this.corrForVol_NoChange.Clear();
				this.zScoreForVol_NoChange.Clear();
				string[] cnxbank_symbols = new downloadSiteCls(new Uri(this.Banknifty)).getSite().Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				foreach (string val in cnxbank_symbols)
				{
					foreach (KeyValuePair<string, double> kvp10 in this.correlationForVolatility_Rise_Symbols)
					{
						string symbol = kvp10.Key;
						double correlation = kvp10.Value;
						if (val == symbol)
						{
							string s = symbol;
							double c = correlation;
							this.corrForVol_Rise_Symbols.Add(s, c);
						}
					}
				}
				foreach (KeyValuePair<string, double> line in this.corrForVol_Rise_Symbols)
				{
					double corr = line.Value;
					foreach (KeyValuePair<double, double> kvp11 in this.correlationForVolatility_Rise)
					{
						double volatility = kvp11.Key;
						double correlation2 = kvp11.Value;
						if (corr == correlation2)
						{
							double s2 = volatility;
							double c2 = correlation2;
							this.corrForVol_Rise.Add(s2, c2);
						}
					}
				}
				foreach (KeyValuePair<double, double> line2 in this.corrForVol_Rise)
				{
					double corr2 = line2.Value;
					foreach (KeyValuePair<double, double> kvp12 in this.zScoreForVolatility_Rise)
					{
						double correlation3 = kvp12.Key;
						double z_score = kvp12.Value;
						if (corr2 == correlation3)
						{
							double s3 = correlation3;
							double c3 = z_score;
							this.zScoreForVol_Rise.Add(s3, c3);
						}
					}
				}
				foreach (string val2 in cnxbank_symbols)
				{
					foreach (KeyValuePair<string, double> kvp13 in this.correlationForVolatility_Fall_Symbols)
					{
						string symbol2 = kvp13.Key;
						double correlation4 = kvp13.Value;
						if (val2 == symbol2)
						{
							string s4 = symbol2;
							double c4 = correlation4;
							this.corrForVol_Fall_Symbols.Add(s4, c4);
						}
					}
				}
				foreach (KeyValuePair<string, double> line3 in this.corrForVol_Fall_Symbols)
				{
					double corr3 = line3.Value;
					foreach (KeyValuePair<double, double> kvp14 in this.correlationForVolatility_Fall)
					{
						double volatility2 = kvp14.Key;
						double correlation5 = kvp14.Value;
						if (corr3 == correlation5)
						{
							double s5 = volatility2;
							double c5 = correlation5;
							this.corrForVol_Fall.Add(s5, c5);
						}
					}
				}
				foreach (KeyValuePair<double, double> line4 in this.corrForVol_Fall)
				{
					double corr4 = line4.Value;
					foreach (KeyValuePair<double, double> kvp15 in this.zScoreForVolatility_Fall)
					{
						double correlation6 = kvp15.Key;
						double z_score2 = kvp15.Value;
						if (corr4 == correlation6)
						{
							double s6 = correlation6;
							double c6 = z_score2;
							this.zScoreForVol_Fall.Add(s6, c6);
						}
					}
				}
				foreach (string val3 in cnxbank_symbols)
				{
					foreach (KeyValuePair<string, double> kvp16 in this.correlationForVolatility_NoChange_Symbols)
					{
						string symbol3 = kvp16.Key;
						double correlation7 = kvp16.Value;
						if (val3 == symbol3)
						{
							string s7 = symbol3;
							double c7 = correlation7;
							this.corrForVol_NoChange_Symbols.Add(s7, c7);
						}
					}
				}
				foreach (KeyValuePair<string, double> line5 in this.corrForVol_NoChange_Symbols)
				{
					double corr5 = line5.Value;
					foreach (KeyValuePair<double, double> kvp17 in this.correlationForVolatility_NoChange)
					{
						double volatility3 = kvp17.Key;
						double correlation8 = kvp17.Value;
						if (corr5 == correlation8)
						{
							double s8 = volatility3;
							double c8 = correlation8;
							this.corrForVol_NoChange.Add(s8, c8);
						}
					}
				}
				using (Dictionary<double, double>.Enumerator enumerator2 = this.corrForVol_NoChange.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						KeyValuePair<double, double> line6 = enumerator2.Current;
						double corr6 = line6.Value;
						foreach (KeyValuePair<double, double> kvp18 in this.zScoreForVolatility_NoChange)
						{
							double correlation9 = kvp18.Key;
							double z_score3 = kvp18.Value;
							if (corr6 == correlation9)
							{
								double s9 = correlation9;
								double c9 = z_score3;
								this.zScoreForVol_NoChange.Add(s9, c9);
							}
						}
					}
					goto IL_2486;
				}
			}
			if (this.index.SelectedIndex == 2)
			{
				correlation.stk_symbol_list = new List<string>();
				correlation._correlation = new Dictionary<string, double>();
				correlation._zScore = new Dictionary<string, double>();
				correlation.loadExpiry();
				List<string> DBsymbols2 = StocksBasedVolatility.dataDownload(correlation._currentMonthExpiry, correlation.stk_symbolsURL);
				if (DBsymbols2.Any<string>())
				{
					string text2 = string.Join("", DBsymbols2.ToArray());
					correlation.stk_symbol_list = StocksBasedVolatility.splitData(text2.Remove(text2.Length - 1), correlation.stk_symbolsURL);
				}
				string[] _11dayDataArray2 = correlation._11dayDataInArray(correlation._currentMonthExpiry, correlation._11daysLtpUrl);
				bool contains_FINNIFTY = false;
				foreach (string input2 in correlation.stk_symbol_list)
				{
					contains_FINNIFTY = Regex.IsMatch(input2, "\\bFINNIFTY\\b");
					if (contains_FINNIFTY)
					{
						break;
					}
				}
				if (contains_FINNIFTY)
				{
					int finnifty_index = correlation.stk_symbol_list.FindIndex((string a) => Regex.IsMatch(a, "\\bFINNIFTY\\b"));
					double[] finnifty_last11Days = correlation.get_11dayLTP(_11dayDataArray2.ElementAt(finnifty_index));
					double finnifty_day = finnifty_last11Days.ElementAt(0);
					double finnifty_day2 = finnifty_last11Days.ElementAt(1);
					double finnifty_day3 = finnifty_last11Days.ElementAt(2);
					double finnifty_day4 = finnifty_last11Days.ElementAt(3);
					double finnifty_day5 = finnifty_last11Days.ElementAt(4);
					double finnifty_day6 = finnifty_last11Days.ElementAt(5);
					double finnifty_day7 = finnifty_last11Days.ElementAt(6);
					double finnifty_day8 = finnifty_last11Days.ElementAt(7);
					double finnifty_day9 = finnifty_last11Days.ElementAt(8);
					double finnifty_day10 = finnifty_last11Days.ElementAt(9);
					double finnifty_day11 = finnifty_last11Days.ElementAt(10);
					List<double> x_finnifty = new List<double>();
					x_finnifty.Add((finnifty_day2 - finnifty_day) / finnifty_day2 * 100.0);
					x_finnifty.Add((finnifty_day3 - finnifty_day2) / finnifty_day3 * 100.0);
					x_finnifty.Add((finnifty_day4 - finnifty_day3) / finnifty_day4 * 100.0);
					x_finnifty.Add((finnifty_day5 - finnifty_day4) / finnifty_day5 * 100.0);
					x_finnifty.Add((finnifty_day6 - finnifty_day5) / finnifty_day6 * 100.0);
					x_finnifty.Add((finnifty_day7 - finnifty_day6) / finnifty_day7 * 100.0);
					x_finnifty.Add((finnifty_day8 - finnifty_day7) / finnifty_day8 * 100.0);
					x_finnifty.Add((finnifty_day9 - finnifty_day8) / finnifty_day9 * 100.0);
					x_finnifty.Add((finnifty_day10 - finnifty_day9) / finnifty_day10 * 100.0);
					x_finnifty.Add((finnifty_day11 - finnifty_day10) / finnifty_day11 * 100.0);
					for (int index2 = 0; index2 <= correlation.stk_symbol_list.Count - 2; index2++)
					{
						string symbolNow2 = correlation.stk_symbol_list.ElementAt(index2);
						if (symbolNow2 != "FINNIFTY")
						{
							double[] _last11Days2 = correlation.get_11dayLTP(_11dayDataArray2.ElementAt(index2));
							double day12 = _last11Days2.ElementAt(0);
							double day13 = _last11Days2.ElementAt(1);
							double day14 = _last11Days2.ElementAt(2);
							double day15 = _last11Days2.ElementAt(3);
							double day16 = _last11Days2.ElementAt(4);
							double day17 = _last11Days2.ElementAt(5);
							double day18 = _last11Days2.ElementAt(6);
							double day19 = _last11Days2.ElementAt(7);
							double day20 = _last11Days2.ElementAt(8);
							double day21 = _last11Days2.ElementAt(9);
							double day22 = _last11Days2.ElementAt(10);
							List<double> y2 = new List<double>();
							y2.Add((day13 - day12) / day13 * 100.0);
							y2.Add((day14 - day13) / day14 * 100.0);
							y2.Add((day15 - day14) / day15 * 100.0);
							y2.Add((day16 - day15) / day16 * 100.0);
							y2.Add((day17 - day16) / day17 * 100.0);
							y2.Add((day18 - day17) / day18 * 100.0);
							y2.Add((day19 - day18) / day19 * 100.0);
							y2.Add((day20 - day19) / day20 * 100.0);
							y2.Add((day21 - day20) / day21 * 100.0);
							y2.Add((day22 - day21) / day22 * 100.0);
							double correlationResult2 = correlation.CorrCoEff(x_finnifty.ToArray(), y2.ToArray());
							correlationResult2 *= 100.0;
							correlation._correlation.Add(symbolNow2, correlationResult2);
							double zScoreResult2 = zScore.zScore_Calc(finnifty_last11Days, _last11Days2);
							correlation._zScore.Add(symbolNow2, zScoreResult2);
						}
					}
				}
				this.corrForVol_Rise_Symbols.Clear();
				this.corrForVol_Rise.Clear();
				this.zScoreForVol_Rise.Clear();
				this.corrForVol_Fall_Symbols.Clear();
				this.corrForVol_Fall.Clear();
				this.zScoreForVol_Fall.Clear();
				this.corrForVol_NoChange_Symbols.Clear();
				this.corrForVol_NoChange.Clear();
				this.zScoreForVol_NoChange.Clear();
				string[] finnifty_symbols = new downloadSiteCls(new Uri(this.Finnifty)).getSite().Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				foreach (string val4 in finnifty_symbols)
				{
					foreach (KeyValuePair<string, double> kvp19 in this.correlationForVolatility_Rise_Symbols)
					{
						string symbol4 = kvp19.Key;
						double correlation10 = kvp19.Value;
						if (val4 == symbol4)
						{
							string s10 = symbol4;
							double c10 = correlation10;
							this.finnifty_corrForVol_Rise_Symbols.Add(s10, c10);
							this.corrForVol_Rise_Symbols = this.finnifty_corrForVol_Rise_Symbols;
						}
					}
				}
				foreach (KeyValuePair<string, double> line7 in this.finnifty_corrForVol_Rise_Symbols)
				{
					double corr7 = line7.Value;
					foreach (KeyValuePair<double, double> kvp20 in this.correlationForVolatility_Rise)
					{
						double volatility4 = kvp20.Key;
						double correlation11 = kvp20.Value;
						if (corr7 == correlation11)
						{
							double s11 = volatility4;
							double c11 = correlation11;
							this.finnifty_corrForVol_Rise.Add(s11, c11);
							this.corrForVol_Rise = this.finnifty_corrForVol_Rise;
						}
					}
				}
				foreach (KeyValuePair<double, double> line8 in this.finnifty_corrForVol_Rise)
				{
					double corr8 = line8.Value;
					foreach (KeyValuePair<double, double> kvp21 in this.zScoreForVolatility_Rise)
					{
						double correlation12 = kvp21.Key;
						double z_score4 = kvp21.Value;
						if (corr8 == correlation12)
						{
							double s12 = correlation12;
							double c12 = z_score4;
							this.finnifty_zScoreForVol_Rise.Add(s12, c12);
							this.zScoreForVol_Rise = this.finnifty_zScoreForVol_Rise;
						}
					}
				}
				foreach (string val5 in finnifty_symbols)
				{
					foreach (KeyValuePair<string, double> kvp22 in this.correlationForVolatility_Fall_Symbols)
					{
						string symbol5 = kvp22.Key;
						double correlation13 = kvp22.Value;
						if (val5 == symbol5)
						{
							string s13 = symbol5;
							double c13 = correlation13;
							this.finnifty_corrForVol_Fall_Symbols.Add(s13, c13);
							this.corrForVol_Fall_Symbols = this.finnifty_corrForVol_Fall_Symbols;
						}
					}
				}
				foreach (KeyValuePair<string, double> line9 in this.finnifty_corrForVol_Fall_Symbols)
				{
					double corr9 = line9.Value;
					foreach (KeyValuePair<double, double> kvp23 in this.correlationForVolatility_Fall)
					{
						double volatility5 = kvp23.Key;
						double correlation14 = kvp23.Value;
						if (corr9 == correlation14)
						{
							double s14 = volatility5;
							double c14 = correlation14;
							this.finnifty_corrForVol_Fall.Add(s14, c14);
							this.corrForVol_Fall = this.finnifty_corrForVol_Fall;
						}
					}
				}
				foreach (KeyValuePair<double, double> line10 in this.finnifty_corrForVol_Fall)
				{
					double corr10 = line10.Value;
					foreach (KeyValuePair<double, double> kvp24 in this.zScoreForVolatility_Fall)
					{
						double correlation15 = kvp24.Key;
						double z_score5 = kvp24.Value;
						if (corr10 == correlation15)
						{
							double s15 = correlation15;
							double c15 = z_score5;
							this.finnifty_zScoreForVol_Fall.Add(s15, c15);
							this.zScoreForVol_Fall = this.finnifty_zScoreForVol_Fall;
						}
					}
				}
				foreach (string val6 in finnifty_symbols)
				{
					foreach (KeyValuePair<string, double> kvp25 in this.correlationForVolatility_NoChange_Symbols)
					{
						string symbol6 = kvp25.Key;
						double correlation16 = kvp25.Value;
						if (val6 == symbol6)
						{
							string s16 = symbol6;
							double c16 = correlation16;
							this.finnifty_corrForVol_NoChange_Symbols.Add(s16, c16);
							this.corrForVol_NoChange_Symbols = this.finnifty_corrForVol_NoChange_Symbols;
						}
					}
				}
				foreach (KeyValuePair<string, double> line11 in this.finnifty_corrForVol_NoChange_Symbols)
				{
					double corr11 = line11.Value;
					foreach (KeyValuePair<double, double> kvp26 in this.correlationForVolatility_NoChange)
					{
						double volatility6 = kvp26.Key;
						double correlation17 = kvp26.Value;
						if (corr11 == correlation17)
						{
							double s17 = volatility6;
							double c17 = correlation17;
							this.finnifty_corrForVol_NoChange.Add(s17, c17);
							this.corrForVol_NoChange = this.finnifty_corrForVol_NoChange;
						}
					}
				}
				foreach (KeyValuePair<double, double> line12 in this.finnifty_corrForVol_NoChange)
				{
					double corr12 = line12.Value;
					foreach (KeyValuePair<double, double> kvp27 in this.zScoreForVolatility_NoChange)
					{
						double correlation18 = kvp27.Key;
						double z_score6 = kvp27.Value;
						if (corr12 == correlation18)
						{
							double s18 = correlation18;
							double c18 = z_score6;
							this.finnifty_zScoreForVol_NoChange.Add(s18, c18);
							this.zScoreForVol_NoChange = this.finnifty_zScoreForVol_NoChange;
						}
					}
				}
			}
			IL_2486:
			IEnumerable<string> volatility_Rise_Symbols = from kvp in this.corrForVol_Rise_Symbols
			select kvp.Key.ToString();
			this.textBoxVolaRise_Symbols.Text = string.Join(Environment.NewLine, volatility_Rise_Symbols);
			IEnumerable<string> volatility_Rise_Vola = from kvp in this.corrForVol_Rise
			select kvp.Key.ToString().Substring(0, 6);
			this.textBoxVolaRise_Vola.Text = string.Join(Environment.NewLine, volatility_Rise_Vola);
			IEnumerable<string> corr_Volatility_Rise = this.corrForVol_Rise.Select(delegate(KeyValuePair<double, double> kvp)
			{
				string stringValue = kvp.Value.ToString();
				if (stringValue.Length < 6)
				{
					return stringValue;
				}
				return stringValue.Substring(0, 6);
			});
			this.textBoxVolaRise_Correlation.Text = string.Join(Environment.NewLine, corr_Volatility_Rise);
			IEnumerable<string> volatility_Fall_Symbols = from kvp in this.corrForVol_Fall_Symbols
			select kvp.Key.ToString();
			this.textBoxVolaFall_Symbols.Text = string.Join(Environment.NewLine, volatility_Fall_Symbols);
			IEnumerable<string> volatility_Fall_Vola = from kvp in this.corrForVol_Fall
			select kvp.Key.ToString().Substring(0, 6);
			this.textBoxVolaFall_Vola.Text = string.Join(Environment.NewLine, volatility_Fall_Vola);
			List<string> corr_Volatility_Fall = this.corrForVol_Fall.Select(delegate(KeyValuePair<double, double> kvp)
			{
				if (kvp.Value.ToString().Length < 6)
				{
					return kvp.Value.ToString();
				}
				return kvp.Value.ToString().Substring(0, 6);
			}).ToList<string>();
			this.textBoxVolaFall_Correlation.Text = string.Join(Environment.NewLine, corr_Volatility_Fall);
			IEnumerable<string> volatility_NoChange_Symbols = from kvp in this.corrForVol_NoChange_Symbols
			select kvp.Key.ToString();
			this.textBoxVolaNoChange_Symbols.Text = string.Join(Environment.NewLine, volatility_NoChange_Symbols);
			List<string> volatility_NoChange_Vola = this.corrForVol_NoChange.Select(delegate(KeyValuePair<double, double> kvp)
			{
				if (kvp.Key.ToString().Length < 6)
				{
					return kvp.Key.ToString();
				}
				return kvp.Key.ToString().Substring(0, 6);
			}).ToList<string>();
			this.textBoxVolaNoChange_Vola.Text = string.Join(Environment.NewLine, volatility_NoChange_Vola);
			List<string> corr_Volatility_NoChange = this.corrForVol_NoChange.Select(delegate(KeyValuePair<double, double> kvp)
			{
				if (kvp.Value.ToString().Length < 6)
				{
					return kvp.Value.ToString();
				}
				return kvp.Value.ToString().Substring(0, 6);
			}).ToList<string>();
			this.textBoxVolaNoChange_Correlation.Text = string.Join(Environment.NewLine, corr_Volatility_NoChange);
			IEnumerable<string> zScore_Volatility_Rise = this.zScoreForVol_Rise.Select(delegate(KeyValuePair<double, double> kvp)
			{
				string stringValue = kvp.Value.ToString();
				if (stringValue.Length >= 6)
				{
					return stringValue.Substring(0, 6);
				}
				return stringValue;
			});
			this.textBoxVolaRise_zScore.Text = string.Join(Environment.NewLine, zScore_Volatility_Rise);
			List<string> zScore_Volatility_Fall = this.zScoreForVol_Fall.Select(delegate(KeyValuePair<double, double> kvp)
			{
				if (kvp.Value.ToString().Length < 6)
				{
					return kvp.Value.ToString();
				}
				return kvp.Value.ToString().Substring(0, 6);
			}).ToList<string>();
			this.textBoxVolaFall_zScore.Text = string.Join(Environment.NewLine, zScore_Volatility_Fall);
			List<string> zScore_Volatility_NoChange = this.zScoreForVol_NoChange.Select(delegate(KeyValuePair<double, double> kvp)
			{
				if (kvp.Value.ToString().Length < 6)
				{
					return kvp.Value.ToString();
				}
				return kvp.Value.ToString().Substring(0, 6);
			}).ToList<string>();
			this.textBoxVolaNoChange_zScore.Text = string.Join(Environment.NewLine, zScore_Volatility_NoChange);
			this.niftyVola.Content = StocksBasedVolatility.niftyVola;
			this.bankniftyVola.Content = StocksBasedVolatility.bankniftyVola;
			this.finniftyVola.Content = StocksBasedVolatility.finniftyVola;
			this.label1.Visibility = Visibility.Visible;
			this.label2.Visibility = Visibility.Visible;
			this.label3.Visibility = Visibility.Visible;
			this.label4.Visibility = Visibility.Visible;
			this.label5.Visibility = Visibility.Visible;
			this.label6.Visibility = Visibility.Visible;
			this.label7.Visibility = Visibility.Visible;
			this.label8.Visibility = Visibility.Visible;
			this.label9.Visibility = Visibility.Visible;
			this.label10.Visibility = Visibility.Visible;
			this.label11.Visibility = Visibility.Visible;
			this.label12.Visibility = Visibility.Visible;
			this.note.Visibility = Visibility.Visible;
			this.LabelVolaRise.Visibility = Visibility.Visible;
			this.LabelVolaFall.Visibility = Visibility.Visible;
			this.LabelVolaNoChange.Visibility = Visibility.Visible;
			this.scrollViewer.Visibility = Visibility.Visible;
			this.scanButton.Content = "Scan the Stocks";
		}

		// Token: 0x040003A2 RID: 930
		private ToolTip tt;

		// Token: 0x040003A3 RID: 931
		private ObservableCollection<string> _stockSymbols;

		// Token: 0x040003A4 RID: 932
		private readonly string STOCKFUTUREPATH = "https://smartfinance.in/symbols/STK.txt";

		// Token: 0x040003A5 RID: 933
		private readonly string Banknifty = "https://smartfinance.in/symbols/banknifty.txt";

		// Token: 0x040003A6 RID: 934
		private readonly string Finnifty = "https://smartfinance.in/symbols/finnifty.txt";

		// Token: 0x040003A7 RID: 935
		private Dictionary<string, double> correlationForVolatility_Rise_Symbols = new Dictionary<string, double>();

		// Token: 0x040003A8 RID: 936
		private Dictionary<double, double> correlationForVolatility_Rise = new Dictionary<double, double>();

		// Token: 0x040003A9 RID: 937
		private Dictionary<double, double> zScoreForVolatility_Rise = new Dictionary<double, double>();

		// Token: 0x040003AA RID: 938
		private Dictionary<string, double> corrForVol_Rise_Symbols = new Dictionary<string, double>();

		// Token: 0x040003AB RID: 939
		private Dictionary<double, double> corrForVol_Rise = new Dictionary<double, double>();

		// Token: 0x040003AC RID: 940
		private Dictionary<double, double> zScoreForVol_Rise = new Dictionary<double, double>();

		// Token: 0x040003AD RID: 941
		private Dictionary<string, double> finnifty_corrForVol_Rise_Symbols = new Dictionary<string, double>();

		// Token: 0x040003AE RID: 942
		private Dictionary<double, double> finnifty_corrForVol_Rise = new Dictionary<double, double>();

		// Token: 0x040003AF RID: 943
		private Dictionary<double, double> finnifty_zScoreForVol_Rise = new Dictionary<double, double>();

		// Token: 0x040003B0 RID: 944
		private Dictionary<string, double> correlationForVolatility_Fall_Symbols = new Dictionary<string, double>();

		// Token: 0x040003B1 RID: 945
		private Dictionary<double, double> correlationForVolatility_Fall = new Dictionary<double, double>();

		// Token: 0x040003B2 RID: 946
		private Dictionary<double, double> zScoreForVolatility_Fall = new Dictionary<double, double>();

		// Token: 0x040003B3 RID: 947
		private Dictionary<string, double> corrForVol_Fall_Symbols = new Dictionary<string, double>();

		// Token: 0x040003B4 RID: 948
		private Dictionary<double, double> corrForVol_Fall = new Dictionary<double, double>();

		// Token: 0x040003B5 RID: 949
		private Dictionary<double, double> zScoreForVol_Fall = new Dictionary<double, double>();

		// Token: 0x040003B6 RID: 950
		private Dictionary<string, double> finnifty_corrForVol_Fall_Symbols = new Dictionary<string, double>();

		// Token: 0x040003B7 RID: 951
		private Dictionary<double, double> finnifty_corrForVol_Fall = new Dictionary<double, double>();

		// Token: 0x040003B8 RID: 952
		private Dictionary<double, double> finnifty_zScoreForVol_Fall = new Dictionary<double, double>();

		// Token: 0x040003B9 RID: 953
		private Dictionary<string, double> correlationForVolatility_NoChange_Symbols = new Dictionary<string, double>();

		// Token: 0x040003BA RID: 954
		private Dictionary<double, double> correlationForVolatility_NoChange = new Dictionary<double, double>();

		// Token: 0x040003BB RID: 955
		private Dictionary<double, double> zScoreForVolatility_NoChange = new Dictionary<double, double>();

		// Token: 0x040003BC RID: 956
		private Dictionary<string, double> corrForVol_NoChange_Symbols = new Dictionary<string, double>();

		// Token: 0x040003BD RID: 957
		private Dictionary<double, double> corrForVol_NoChange = new Dictionary<double, double>();

		// Token: 0x040003BE RID: 958
		private Dictionary<double, double> zScoreForVol_NoChange = new Dictionary<double, double>();

		// Token: 0x040003BF RID: 959
		private Dictionary<string, double> finnifty_corrForVol_NoChange_Symbols = new Dictionary<string, double>();

		// Token: 0x040003C0 RID: 960
		private Dictionary<double, double> finnifty_corrForVol_NoChange = new Dictionary<double, double>();

		// Token: 0x040003C1 RID: 961
		private Dictionary<double, double> finnifty_zScoreForVol_NoChange = new Dictionary<double, double>();
	}
}
