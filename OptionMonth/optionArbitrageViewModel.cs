using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using New_SF_IT.classes;
using New_SF_IT.Helpers;

namespace New_SF_IT.OptionMonth
{
	// Token: 0x02000027 RID: 39
	[NullableContext(1)]
	[Nullable(0)]
	internal class optionArbitrageViewModel : ViewModelBase
	{
		// Token: 0x06000201 RID: 513 RVA: 0x0002057C File Offset: 0x0001E77C
		public optionArbitrageViewModel()
		{
			this.initialize_Variable();
			this.callPremiumData = optionArbitrageViewModel.filter_TradingStrikeByIV(this.OPTION_TABLE, "StrikePrice", "cIV", "cLTP");
			this.putPremiumData = optionArbitrageViewModel.filter_TradingStrikeByIV(this.OPTION_TABLE, "StrikePrice", "pIV", "pLTP");
			if (this.callPremiumData != null)
			{
				ObservableCollection<Arbitrage> temp = this.GetArbitrage(this.callPremiumData, "Call");
				if (temp != null)
				{
					using (IEnumerator<Arbitrage> enumerator = temp.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							Arbitrage citem = enumerator.Current;
							this.CallArbitrages.Add(citem);
						}
						goto IL_D6;
					}
					goto IL_C5;
				}
				IL_D6:
				if (this.putPremiumData != null)
				{
					ObservableCollection<Arbitrage> temp2 = this.GetArbitrage(this.putPremiumData, "Put");
					if (temp2 != null)
					{
						using (IEnumerator<Arbitrage> enumerator = temp2.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Arbitrage citem2 = enumerator.Current;
								this.PutArbitrages.Add(citem2);
							}
							return;
						}
						goto IL_125;
					}
					return;
				}
				IL_125:
				MessageBox.Show("Put IV filter error", "Put Premium data error-49");
				return;
			}
			IL_C5:
			MessageBox.Show("Call IV filter error", "Call Premium data error-39");
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000206DC File Offset: 0x0001E8DC
		public void initialize_Variable()
		{
			try
			{
				if (Option.LIVE_DATA != null)
				{
					this.LOW = Option.LIVE_DATA.low;
					this.HIGH = Option.LIVE_DATA.high;
					this.LTP = Option.LIVE_DATA.ltp;
					this.OPEN = Option.LIVE_DATA.open;
					this.UNDERLYINGVALUE = Option.LIVE_DATA.underlyingValue;
					if (Option.OPTIONCHAIN_TABLE != null)
					{
						this.OPTION_TABLE = Option.OPTIONCHAIN_TABLE;
						for (int i = 0; i <= this.OPTION_TABLE.Rows.Count - 1; i++)
						{
							this.OPTION_TABLE.Rows[i]["cLTP"] = this.OPTION_TABLE.Rows[i]["cLTP"].ToString().Replace("-", "0");
							this.OPTION_TABLE.Rows[i]["pLTP"] = this.OPTION_TABLE.Rows[i]["pLTP"].ToString().Replace("-", "0");
						}
						this.filter_Strikes();
						int lastElementIndex = this.CALLSTRIKE.Count - 4;
						int secondLastElementIndex = this.CALLSTRIKE.Count - 3;
						double lastStrike = Convert.ToDouble(this.CALLSTRIKE.Keys.ElementAt(lastElementIndex));
						double secondLastStrike = Convert.ToDouble(this.CALLSTRIKE.Keys.ElementAt(secondLastElementIndex));
						this.strikeSpread = lastStrike - secondLastStrike;
						if (Option.LTP_MONTH != null && Option.LTP_MONTH.Count > 0)
						{
							this.LTP_HISTORICAL = Option.LTP_MONTH;
							if (Option.DAYS_LEFT_TILL_EXPIRY > 0)
							{
								this.days_left = Option.DAYS_LEFT_TILL_EXPIRY;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000208D0 File Offset: 0x0001EAD0
		public Dictionary<double, double> calcIV(Dictionary<string, string> _Strike, double _refPrice, string OT, int DaysLeft)
		{
			int count = _Strike.Count;
			Dictionary<double, double> dict = new Dictionary<double, double>();
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<string, string> item = _Strike.ElementAt(currentRow);
				string key = item.Key;
				string Value = item.Value;
				double Strike = Convert.ToDouble(key);
				double Premium;
				if (Convert.ToString(Value) == "-")
				{
					Premium = 0.0;
				}
				else
				{
					Premium = Convert.ToDouble(Value);
				}
				double IV = optionsScannerfMathCls.ImpliedVolatility(Premium, DaysLeft, _refPrice, Strike, OT);
				if (!double.IsNaN(IV))
				{
					dict.Add(Strike, IV);
				}
			}
			return dict;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00020964 File Offset: 0x0001EB64
		public void filter_Strikes()
		{
			if (this.OPTION_TABLE != null)
			{
				this.CALLSTRIKE = new Dictionary<string, string>();
				this.PUTSTRIKE = new Dictionary<string, string>();
				if (Option.DAYS_LEFT_TILL_EXPIRY <= 0)
				{
					return;
				}
				this.days_left = Option.DAYS_LEFT_TILL_EXPIRY;
				this._TradedCallStrike = optionArbitrageViewModel.filter_TradingStrike(this.OPTION_TABLE, "strikePrice", "cLTP");
				this._TradedPutStrike = optionArbitrageViewModel.filter_TradingStrike(this.OPTION_TABLE, "strikePrice", "pLTP");
				this.cIV = this.calcIV(this._TradedCallStrike, this.UNDERLYINGVALUE, "Call", this.days_left);
				this.pIV = this.calcIV(this._TradedPutStrike, this.UNDERLYINGVALUE, "Put", this.days_left);
				if (!this.OPTION_TABLE.Columns.Contains("cIV"))
				{
					this.OPTION_TABLE.Columns.Add("cIV");
				}
				if (!this.OPTION_TABLE.Columns.Contains("pIV"))
				{
					this.OPTION_TABLE.Columns.Add("pIV");
				}
				for (int i = 0; i <= this.cIV.Count - 1; i++)
				{
					double valuei = this.cIV.ElementAt(i).Value;
					this.OPTION_TABLE.Rows[i]["cIV"] = valuei * 100.0;
				}
				for (int j = 0; j <= this.pIV.Count - 1; j++)
				{
					double valuej = this.pIV.ElementAt(j).Value;
					this.OPTION_TABLE.Rows[j]["pIV"] = valuej * 100.0;
				}
				this.CALLSTRIKE = optionArbitrageViewModel.filter_zeroIVStrikes(this.OPTION_TABLE, "StrikePrice", "cIV");
				this.PUTSTRIKE = optionArbitrageViewModel.filter_zeroIVStrikes(this.OPTION_TABLE, "StrikePrice", "pIV");
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00020B68 File Offset: 0x0001ED68
		public static Dictionary<string, string> filter_TradingStrike(DataTable _resultTable, string _strikePriceColumnName, string _LTPColumnName)
		{
			Dictionary<string, string> strikewithLTP = new Dictionary<string, string>();
			for (int rowIndex = 0; rowIndex < _resultTable.Rows.Count; rowIndex++)
			{
				strikewithLTP.Add(_resultTable.Rows[rowIndex][_strikePriceColumnName].ToString(), _resultTable.Rows[rowIndex][_LTPColumnName].ToString());
			}
			return strikewithLTP;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00020BC8 File Offset: 0x0001EDC8
		public static Dictionary<string, string> filter_zeroIVStrikes(DataTable _resultTable, string _strikePriceColumnName, string _LTPColumnName)
		{
			Dictionary<string, string> strikewithLTP = new Dictionary<string, string>();
			for (int rowIndex = 0; rowIndex < _resultTable.Rows.Count; rowIndex++)
			{
				if (_resultTable.Rows[rowIndex][_LTPColumnName].ToString() != "0")
				{
					strikewithLTP.Add(_resultTable.Rows[rowIndex][_strikePriceColumnName].ToString(), _resultTable.Rows[rowIndex][_LTPColumnName].ToString());
				}
			}
			return strikewithLTP;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00020C4C File Offset: 0x0001EE4C
		public static ObservableCollection<premiumDataCls> filter_TradingStrikeByIV(DataTable _Table, string callORputOption, string IVcolumnName, string LTPcolumnName)
		{
			ObservableCollection<premiumDataCls> result = new ObservableCollection<premiumDataCls>();
			try
			{
				for (int rowIndex = 0; rowIndex < _Table.Rows.Count; rowIndex++)
				{
					double num = Convert.ToDouble(_Table.Rows[rowIndex][IVcolumnName]);
					double if_LTP_IsZero = Convert.ToDouble(_Table.Rows[rowIndex][LTPcolumnName]);
					if (num != 0.0 && if_LTP_IsZero != 0.0)
					{
						result.Add(new premiumDataCls
						{
							strike = Convert.ToInt32(Convert.ToDouble(_Table.Rows[rowIndex]["StrikePrice"])),
							IV = Convert.ToDouble(_Table.Rows[rowIndex][IVcolumnName]),
							premium = Convert.ToDouble(_Table.Rows[rowIndex][LTPcolumnName])
						});
					}
				}
			}
			catch (Exception)
			{
				return result;
			}
			return result;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00020D48 File Offset: 0x0001EF48
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00020D50 File Offset: 0x0001EF50
		public ObservableCollection<Arbitrage> CallArbitrages
		{
			get
			{
				return this._callArbitrages;
			}
			set
			{
				this._callArbitrages = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00020D59 File Offset: 0x0001EF59
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00020D61 File Offset: 0x0001EF61
		public ObservableCollection<Arbitrage> PutArbitrages
		{
			get
			{
				return this._putArbitrages;
			}
			set
			{
				this._putArbitrages = value;
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00020D6C File Offset: 0x0001EF6C
		private ObservableCollection<Arbitrage> GetArbitrage(ObservableCollection<premiumDataCls> PremiumData, string callORput)
		{
			ObservableCollection<Arbitrage> result = new ObservableCollection<Arbitrage>();
			Dictionary<int, double> Strikes = new Dictionary<int, double>();
			try
			{
				for (int ivIndex = 0; ivIndex < PremiumData.Count; ivIndex++)
				{
					Strikes.Add(PremiumData[ivIndex].strike, PremiumData[ivIndex].IV);
				}
				int nearest = (from x in Strikes
				orderby Math.Abs((double)Convert.ToInt32(x.Key) - this.LTP)
				select x).First<KeyValuePair<int, double>>().Key;
				int nearestIndex = this.GetNearestIndex(nearest, PremiumData);
				int startIndex;
				int endIndex;
				if (nearestIndex != 0)
				{
					if (nearestIndex > 2)
					{
						startIndex = nearestIndex - 2;
					}
					else
					{
						startIndex = 0;
					}
					if (PremiumData.Count - 1 > 6)
					{
						endIndex = nearestIndex + 4;
					}
					else
					{
						endIndex = PremiumData.Count;
					}
				}
				else
				{
					startIndex = 0;
					endIndex = PremiumData.Count;
				}
				double sum = 0.0;
				int totalIVCount = endIndex - startIndex;
				int tempStartIndex = startIndex;
				int tempEndIndex = endIndex;
				while (tempStartIndex < tempEndIndex)
				{
					double IV = Strikes.Values.ElementAt(tempStartIndex);
					sum += IV;
					tempStartIndex++;
				}
				double AvgIV = sum / (double)totalIVCount;
				AvgIV /= 100.0;
				for (int i = startIndex; i < endIndex; i++)
				{
					double d = Comman.get_dValueA(AvgIV, (double)PremiumData[i].strike, this.UNDERLYINGVALUE, (double)this.days_left);
					double d2 = Comman.get_dValueB(AvgIV, (double)PremiumData[i].strike, this.UNDERLYINGVALUE, (double)this.days_left);
					double calculatePremium = Comman.premium(d, d2, (double)PremiumData[i].strike, this.UNDERLYINGVALUE, (double)this.days_left, callORput);
					result.Add(new Arbitrage
					{
						Strike = PremiumData[i].strike,
						ActualPremium = PremiumData[i].premium.ToString(),
						CalculatedPremium = Math.Round(calculatePremium, 2).ToString(),
						ArbitrageValue = Math.Round(PremiumData[i].premium - calculatePremium, 2).ToString()
					});
				}
			}
			catch (Exception)
			{
				return result;
			}
			return result;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00020F9C File Offset: 0x0001F19C
		private int GetNearestIndex(int nearest, ObservableCollection<premiumDataCls> PremiumData)
		{
			for (int indexsearch = 0; indexsearch < PremiumData.Count; indexsearch++)
			{
				if (nearest == PremiumData[indexsearch].strike)
				{
					return indexsearch;
				}
			}
			return 0;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00020FCC File Offset: 0x0001F1CC
		private ObservableCollection<Arbitrage> GetCallArbitrage()
		{
			ObservableCollection<Arbitrage> result = new ObservableCollection<Arbitrage>();
			for (int i = 0; i < this.CALLSTRIKE.Count; i++)
			{
				result.Add(new Arbitrage
				{
					Strike = Convert.ToInt32(Convert.ToDouble(this.CALLSTRIKE.Keys.ElementAt(i))),
					ActualPremium = " " + this.CALLSTRIKE.Values.ElementAt(i),
					CalculatedPremium = i.ToString(),
					ArbitrageValue = "Call Arbitrage " + i.ToString()
				});
			}
			return result;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0002106C File Offset: 0x0001F26C
		private ObservableCollection<Arbitrage> GetPutArbitrage()
		{
			ObservableCollection<Arbitrage> putresult = new ObservableCollection<Arbitrage>();
			for (int i = 0; i < this.PUTSTRIKE.Count; i++)
			{
				putresult.Add(new Arbitrage
				{
					Strike = Convert.ToInt32(Convert.ToDouble(this.PUTSTRIKE.Keys.ElementAt(i))),
					ActualPremium = " " + this.PUTSTRIKE.Values.ElementAt(i),
					CalculatedPremium = i.ToString(),
					ArbitrageValue = "Put Arbitrage " + i.ToString()
				});
			}
			return putresult;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0002110C File Offset: 0x0001F30C
		private ObservableCollection<premiumDataCls> filterByIV(DataTable OPTION_TABLE, string callORputColumnName, string IVColumnName)
		{
			ObservableCollection<premiumDataCls> filteredResult = null;
			if (OPTION_TABLE != null)
			{
				filteredResult = Comman.filter_TradingStrikeByIV(OPTION_TABLE, "StrikePrice", "cIV", "cLTP");
			}
			return filteredResult;
		}

		// Token: 0x0400042A RID: 1066
		private double LOW;

		// Token: 0x0400042B RID: 1067
		private double HIGH;

		// Token: 0x0400042C RID: 1068
		private double LTP;

		// Token: 0x0400042D RID: 1069
		private double OPEN;

		// Token: 0x0400042E RID: 1070
		private double UNDERLYINGVALUE;

		// Token: 0x0400042F RID: 1071
		private DataTable OPTION_TABLE;

		// Token: 0x04000430 RID: 1072
		private Dictionary<string, string> CALLSTRIKE;

		// Token: 0x04000431 RID: 1073
		private Dictionary<string, string> PUTSTRIKE;

		// Token: 0x04000432 RID: 1074
		private List<double> LTP_HISTORICAL;

		// Token: 0x04000433 RID: 1075
		private double IV;

		// Token: 0x04000434 RID: 1076
		public Dictionary<string, string> _TradedCallStrike;

		// Token: 0x04000435 RID: 1077
		public Dictionary<string, string> _TradedPutStrike;

		// Token: 0x04000436 RID: 1078
		private Dictionary<double, double> cIV = new Dictionary<double, double>();

		// Token: 0x04000437 RID: 1079
		private Dictionary<double, double> pIV = new Dictionary<double, double>();

		// Token: 0x04000438 RID: 1080
		private ObservableCollection<Arbitrage> _callArbitrages = new ObservableCollection<Arbitrage>();

		// Token: 0x04000439 RID: 1081
		private ObservableCollection<Arbitrage> _putArbitrages = new ObservableCollection<Arbitrage>();

		// Token: 0x0400043A RID: 1082
		private ObservableCollection<premiumDataCls> callPremiumData;

		// Token: 0x0400043B RID: 1083
		private ObservableCollection<premiumDataCls> putPremiumData;

		// Token: 0x0400043C RID: 1084
		private int days_left;

		// Token: 0x0400043D RID: 1085
		private double strikeSpread;
	}
}
