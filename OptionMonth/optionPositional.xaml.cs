using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using New_SF_IT.classes;

namespace New_SF_IT.OptionMonth
{
	// Token: 0x0200002B RID: 43
	public partial class optionPositional : UserControl
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00025D85 File Offset: 0x00023F85
		[NullableContext(1)]
		private void btnCalClick(object sender, RoutedEventArgs e)
		{
			this.Initialize_Variable();
			this.CalCulate();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00025D94 File Offset: 0x00023F94
		[NullableContext(1)]
		public optionPositional(Option option1)
		{
			this.InitializeComponent();
			this.option = option1;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00025DAC File Offset: 0x00023FAC
		public void filter_Strikes()
		{
			if (this.OPTION_TABLE != null)
			{
				this.CALLSTRIKE = new Dictionary<string, string>();
				this.PUTSTRIKE = new Dictionary<string, string>();
				this.CALLSTRIKE = Comman.filter_TradingStrike(this.OPTION_TABLE, "StrikePrice", "cLTP");
				this.PUTSTRIKE = Comman.filter_TradingStrike(this.OPTION_TABLE, "StrikePrice", "pLTP");
				Option.callStrike = this.CALLSTRIKE;
				Option.putStrike = this.PUTSTRIKE;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00025E24 File Offset: 0x00024024
		public void Initialize_Variable()
		{
			try
			{
				if (Option.LIVE_DATA != null)
				{
					optionPositional.LOW = Option.LIVE_DATA.low;
					optionPositional.HIGH = Option.LIVE_DATA.high;
					optionPositional.LTP = Option.LIVE_DATA.ltp;
					optionPositional.OPEN = Option.LIVE_DATA.open;
					optionPositional.UNDERLYINGPRICE = Option.LIVE_DATA.underlyingValue;
					if (Option.OPTIONCHAIN_TABLE != null)
					{
						this.OPTION_TABLE = Option.OPTIONCHAIN_TABLE;
						this.filter_Strikes();
						int lastElementIndex = this.CALLSTRIKE.Count - 4;
						int secondLastElementIndex = this.CALLSTRIKE.Count - 3;
						double lastStrike = Convert.ToDouble(this.CALLSTRIKE.Keys.ElementAt(lastElementIndex));
						double secondLastStrike = Convert.ToDouble(this.CALLSTRIKE.Keys.ElementAt(secondLastElementIndex));
						this.strikeSpread = lastStrike - secondLastStrike;
						if (Option.LTP_MONTH != null && Option.LTP_MONTH.Count > 10)
						{
							this.LTP_HISTORICAL = Option.LTP_MONTH;
							this.LTP_HISTORICAL = this.LTP_HISTORICAL.Skip(Math.Max(0, this.LTP_HISTORICAL.Count<double>() - 10)).ToList<double>();
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00025F64 File Offset: 0x00024164
		internal bool CalCulate()
		{
			try
			{
				if (this.OPTION_TABLE != null && this.LTP_HISTORICAL != null)
				{
					if (Option.DAYS_LEFT_TILL_EXPIRY <= 0)
					{
						return false;
					}
					this.days_left = Option.DAYS_LEFT_TILL_EXPIRY;
					this.NoOfHoldDaysOptions = Convert.ToInt32(this.txtbxDays2HoldOptions.Text);
					if (this.NoOfHoldDaysOptions <= 1)
					{
						MessageBox.Show("Days to Hold should be 2 - 10 days.", "Enter greater than One");
						return false;
					}
					this.DAYS_TO_HOLD = this.NoOfHoldDaysOptions;
					bool? isChecked = this.option.rBtnCall.IsChecked;
					bool flag = true;
					if (!(isChecked.GetValueOrDefault() == flag & isChecked != null))
					{
						isChecked = this.option.rBtnPut.IsChecked;
						flag = true;
						if (!(isChecked.GetValueOrDefault() == flag & isChecked != null))
						{
							MessageBox.Show("Call/Put strike need to be selected.", "Please select call or Put");
							return false;
						}
					}
					if (this.option.listBxStrike.SelectedIndex == -1)
					{
						MessageBox.Show("Please select the call/put strike.", "Select Strike Price");
						return false;
					}
					int strikeChoosen = Convert.ToInt32(Convert.ToDouble(this.option.listBxStrike.SelectedItem));
					double premiumOfStrike = Convert.ToDouble(this.option.txtbxOptionPremium.Text);
					isChecked = this.option.rBtnCall.IsChecked;
					flag = true;
					double intransic;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						intransic = optionPositional.LTP - (double)strikeChoosen;
					}
					else
					{
						intransic = (double)strikeChoosen - optionPositional.LTP;
					}
					if (strikeChoosen != 0 && premiumOfStrike != 0.0 && intransic != 0.0)
					{
						if (intransic > premiumOfStrike)
						{
							MessageBox.Show("INTRNSIC should not be greater than Current Option Price", "Intransic");
							return false;
						}
						string OptionType = string.Empty;
						isChecked = this.option.rBtnCall.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							OptionType = "Call";
						}
						else
						{
							OptionType = "Put";
						}
						optionPositional.CurrentIV = Comman.ImpliedVolatility(premiumOfStrike, this.days_left, optionPositional.UNDERLYINGPRICE, strikeChoosen, OptionType);
						this.txtbxIV.Text = Math.Round(Convert.ToDecimal(optionPositional.CurrentIV * 100.0), 2).ToString();
						double volatility = Comman.get_Volatility(this.LTP_HISTORICAL, 2);
						this.txtbxVolatility.Text = Math.Round(volatility * Math.Sqrt(365.0) * 100.0, 2).ToString();
						this.txtbxDailyVolatility.Text = Math.Round(volatility * 100.0, 2).ToString();
						optionPositional.priceRange = optionPositional.UNDERLYINGPRICE * optionPositional.CurrentIV * Math.Sqrt((double)this.DAYS_TO_HOLD / 365.0);
						double buyEntry = optionPositional.UNDERLYINGPRICE + 0.236 * optionPositional.priceRange;
						double buyTarget = optionPositional.UNDERLYINGPRICE + 0.382 * optionPositional.priceRange;
						double buyTarget2 = optionPositional.UNDERLYINGPRICE + 0.5 * optionPositional.priceRange;
						double buyTarget3 = optionPositional.UNDERLYINGPRICE + 0.618 * optionPositional.priceRange;
						double buyTarget4 = optionPositional.UNDERLYINGPRICE + 0.786 * optionPositional.priceRange;
						double buyTarget5 = optionPositional.UNDERLYINGPRICE + 0.888 * optionPositional.priceRange;
						double buyTarget6 = optionPositional.UNDERLYINGPRICE + 1.236 * optionPositional.priceRange;
						double sellEntry = optionPositional.UNDERLYINGPRICE - 0.236 * optionPositional.priceRange;
						double sellTarget = optionPositional.UNDERLYINGPRICE - 0.382 * optionPositional.priceRange;
						double sellTarget2 = optionPositional.UNDERLYINGPRICE - 0.5 * optionPositional.priceRange;
						double sellTarget3 = optionPositional.UNDERLYINGPRICE - 0.618 * optionPositional.priceRange;
						double sellTarget4 = optionPositional.UNDERLYINGPRICE - 0.786 * optionPositional.priceRange;
						double sellTarget5 = optionPositional.UNDERLYINGPRICE - 0.888 * optionPositional.priceRange;
						double sellTarget6 = optionPositional.UNDERLYINGPRICE - 1.236 * optionPositional.priceRange;
						double _priceDifference = optionPositional.LTP - optionPositional.UNDERLYINGPRICE;
						this.txtBxbuyEntry.Text = Math.Round(buyEntry + _priceDifference, 3).ToString();
						this.txtBxTarget1.Text = Math.Round(buyTarget + _priceDifference, 3).ToString();
						this.txtBxTarget2.Text = Math.Round(buyTarget2 + _priceDifference, 3).ToString();
						this.txtBxTarget3.Text = Math.Round(buyTarget3 + _priceDifference, 3).ToString();
						this.txtBxTarget4.Text = Math.Round(buyTarget4 + _priceDifference, 3).ToString();
						this.txtBxTarget5.Text = Math.Round(buyTarget5 + _priceDifference, 3).ToString();
						this.txtBxTarget6.Text = Math.Round(buyTarget6 + _priceDifference, 3).ToString();
						this.txtBxRefTarget.Text = Math.Round(optionPositional.UNDERLYINGPRICE, 3).ToString();
						this.txtBxsellEntry.Text = Math.Round(sellEntry + _priceDifference, 3).ToString();
						this.txtBxTarget1Sell.Text = Math.Round(sellTarget + _priceDifference, 3).ToString();
						this.txtBxTarget2Sell.Text = Math.Round(sellTarget2 + _priceDifference, 3).ToString();
						this.txtBxTarget3Sell.Text = Math.Round(sellTarget3 + _priceDifference, 3).ToString();
						this.txtBxTarget4Sell.Text = Math.Round(sellTarget4 + _priceDifference, 3).ToString();
						this.txtBxTarget5Sell.Text = Math.Round(sellTarget5 + _priceDifference, 3).ToString();
						this.txtBxTarget6Sell.Text = Math.Round(sellTarget6 + _priceDifference, 3).ToString();
						int diffrenceBetweenDays = this.days_left - this.DAYS_TO_HOLD;
						if (diffrenceBetweenDays <= 0)
						{
							MessageBox.Show("Holding days should be less than, days left till expiry", "Invalid Days to Hold");
							return false;
						}
						double dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, optionPositional.UNDERLYINGPRICE, (double)diffrenceBetweenDays);
						double dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, optionPositional.UNDERLYINGPRICE, (double)diffrenceBetweenDays);
						this.txtBxRefTarget_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxRefTarget_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxRefTarget_Gamma.Text = Math.Round(Comman.gamma(dValue, optionPositional.UNDERLYINGPRICE, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxRefTarget_Omega.Text = Math.Round(optionPositional.UNDERLYINGPRICE * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxRefTarget_Vega.Text = Math.Round(Comman.vega(dValue, optionPositional.UNDERLYINGPRICE, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxRefTarget_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, optionPositional.UNDERLYINGPRICE, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyEntry, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyEntry, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyEntry, (double)diffrenceBetweenDays, OptionType);
						this.txtBxbuyEntry_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxbuyEntry_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxbuyEntry_Gamma.Text = Math.Round(Comman.gamma(dValue, buyEntry, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxbuyEntry_Omega.Text = Math.Round(buyEntry * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxbuyEntry_Vega.Text = Math.Round(Comman.vega(dValue, buyEntry, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxbuyEntry_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyEntry, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget1_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget1_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget1_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget1_Omega.Text = Math.Round(buyTarget * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget1_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget1_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget2, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget2, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget2, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget2_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget2_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget2_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget2, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget2_Omega.Text = Math.Round(buyTarget2 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget2_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget2, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget2_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget2, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget3, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget3, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget3, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget3_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget3_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget3_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget3, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget3_Omega.Text = Math.Round(buyTarget3 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget3_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget3, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget3_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget3, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget4, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget4, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget4, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget4_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget4_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget4_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget4, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget4_Omega.Text = Math.Round(buyTarget4 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget4_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget4, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget4_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget4, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget5, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget5, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget5, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget5_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget5_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget5_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget5, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget5_Omega.Text = Math.Round(buyTarget5 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget5_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget5, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget5_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget5, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget6, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, buyTarget6, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, buyTarget6, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget6_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget6_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget6_Gamma.Text = Math.Round(Comman.gamma(dValue, buyTarget6, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget6_Omega.Text = Math.Round(buyTarget6 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget6_Vega.Text = Math.Round(Comman.vega(dValue, buyTarget6, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget6_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, buyTarget6, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellEntry, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellEntry, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellEntry, (double)diffrenceBetweenDays, OptionType);
						this.txtBxsellEntry_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxsellEntry_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxsellEntry_Gamma.Text = Math.Round(Comman.gamma(dValue, sellEntry, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxsellEntry_Omega.Text = Math.Round(sellEntry * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxsellEntry_Vega.Text = Math.Round(Comman.vega(dValue, sellEntry, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxsellEntry_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellEntry, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget1Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget1Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget1Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget1Sell_Omega.Text = Math.Round(sellTarget * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget1Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget1Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget2, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget2, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget2, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget2Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget2Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget2Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget2, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget2Sell_Omega.Text = Math.Round(sellTarget2 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget2Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget2, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget2Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget2, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget3, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget3, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget3, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget3Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget3Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget3Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget3, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget3Sell_Omega.Text = Math.Round(sellTarget3 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget3Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget3, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget3Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget3, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget4, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget4, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget4, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget4Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget4Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget4Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget4, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget4Sell_Omega.Text = Math.Round(sellTarget4 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget4Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget4, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget4Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget4, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget5, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget5, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget5, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget5Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget5Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget5Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget5, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget5Sell_Omega.Text = Math.Round(sellTarget5 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget5Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget5, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget5Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget5, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
						dValue = Comman.get_dValueA(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget6, (double)diffrenceBetweenDays);
						dValue2 = Comman.get_dValueB(optionPositional.CurrentIV, (double)strikeChoosen, sellTarget6, (double)diffrenceBetweenDays);
						premiumOfStrike = Comman.premium(dValue, dValue2, (double)strikeChoosen, sellTarget6, (double)diffrenceBetweenDays, OptionType);
						this.txtBxTarget6Sell_Premium.Text = Math.Round(premiumOfStrike, 3).ToString();
						this.txtBxTarget6Sell_Delta.Text = Math.Round(Comman.delta(dValue, OptionType), 3).ToString();
						this.txtBxTarget6Sell_Gamma.Text = Math.Round(Comman.gamma(dValue, sellTarget6, (double)diffrenceBetweenDays, optionPositional.CurrentIV), 3).ToString();
						this.txtBxTarget6Sell_Omega.Text = Math.Round(sellTarget6 * Comman.delta(dValue, OptionType) / premiumOfStrike, 3).ToString();
						this.txtBxTarget6Sell_Vega.Text = Math.Round(Comman.vega(dValue, sellTarget6, (double)diffrenceBetweenDays), 3).ToString();
						this.txtBxTarget6Sell_Theta.Text = Math.Round(Comman.theta(dValue, dValue2, (double)strikeChoosen, sellTarget6, (double)diffrenceBetweenDays, optionPositional.CurrentIV, OptionType), 3).ToString();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error-331");
				return false;
			}
			return true;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000276E8 File Offset: 0x000258E8
		[NullableContext(1)]
		private void UserControl_Initialized(object sender, EventArgs e)
		{
		}

		// Token: 0x040004E4 RID: 1252
		public static double LOW;

		// Token: 0x040004E5 RID: 1253
		public static double HIGH;

		// Token: 0x040004E6 RID: 1254
		public static double LTP;

		// Token: 0x040004E7 RID: 1255
		public static double OPEN;

		// Token: 0x040004E8 RID: 1256
		public static double UNDERLYINGPRICE;

		// Token: 0x040004E9 RID: 1257
		public static double priceRange;

		// Token: 0x040004EA RID: 1258
		public static double CurrentIV;

		// Token: 0x040004EB RID: 1259
		[Nullable(1)]
		private DataTable OPTION_TABLE;

		// Token: 0x040004EC RID: 1260
		[Nullable(1)]
		private Dictionary<string, string> CALLSTRIKE;

		// Token: 0x040004ED RID: 1261
		[Nullable(1)]
		private Dictionary<string, string> PUTSTRIKE;

		// Token: 0x040004EE RID: 1262
		[Nullable(1)]
		private List<double> LTP_HISTORICAL;

		// Token: 0x040004EF RID: 1263
		private int days_left;

		// Token: 0x040004F0 RID: 1264
		private double strikeSpread;

		// Token: 0x040004F1 RID: 1265
		private int DAYS_TO_HOLD;

		// Token: 0x040004F2 RID: 1266
		private int NoOfHoldDaysOptions;

		// Token: 0x040004F3 RID: 1267
		[Nullable(1)]
		private Option option;
	}
}
