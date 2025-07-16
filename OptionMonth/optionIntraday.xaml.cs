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
	// Token: 0x0200002A RID: 42
	public partial class optionIntraday : UserControl
	{
		// Token: 0x06000222 RID: 546 RVA: 0x000211D8 File Offset: 0x0001F3D8
		[NullableContext(1)]
		public optionIntraday(Option option1)
		{
			this.InitializeComponent();
			this.option = option1;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00021260 File Offset: 0x0001F460
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

		// Token: 0x06000224 RID: 548 RVA: 0x000212D8 File Offset: 0x0001F4D8
		public void Initialize_Variable()
		{
			try
			{
				if (Option.LIVE_DATA != null)
				{
					optionIntraday.LOW = Option.LIVE_DATA.low;
					optionIntraday.HIGH = Option.LIVE_DATA.high;
					optionIntraday.LTP = Option.LIVE_DATA.ltp;
					optionIntraday.OPEN = Option.LIVE_DATA.open;
					optionIntraday.UNDERLYINGPRICE = Option.LIVE_DATA.underlyingValue;
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

		// Token: 0x06000225 RID: 549 RVA: 0x00021418 File Offset: 0x0001F618
		private void analysisIntraday()
		{
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0002141C File Offset: 0x0001F61C
		internal bool CalCulate()
		{
			optionIntraday.weeklyOption = false;
			if (this.option.listBxStrike.SelectedItem == null)
			{
				MessageBox.Show("Pls choose any strike from the CALL/PUT strikelist then calculate", "Strike not selected");
				return false;
			}
			if (MainWindow.currentTab == "OPT")
			{
				this.txtbxVolatility.Visibility = Visibility.Visible;
				this.txtbxVolatilityText.Visibility = Visibility.Visible;
				this.txtbxDailyVolatility.Visibility = Visibility.Visible;
				this.txtbxDailyVolatilityText.Visibility = Visibility.Visible;
				if (this.OPTION_TABLE != null && this.LTP_HISTORICAL != null)
				{
					if (Option.DAYS_LEFT_TILL_EXPIRY > 0)
					{
						this.days_left = Option.DAYS_LEFT_TILL_EXPIRY;
					}
					double _LTP = optionIntraday.LTP;
					double openPrice = optionIntraday.OPEN;
					int count = this.LTP_HISTORICAL.Count;
					double preDayLTP = this.LTP_HISTORICAL[count - 1];
					this.UserSelectedStrike = Convert.ToInt32(Convert.ToDouble(this.option.listBxStrike.SelectedItem));
					optionIntraday.UserSelectedStrikePremium = Convert.ToDouble(this.option.txtbxOptionPremium.Text);
					bool? isChecked = this.option.rBtnCall.IsChecked;
					bool flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						this.OT = "Call";
					}
					else
					{
						this.OT = "Put";
					}
					optionIntraday.IV = Comman.ImpliedVolatility(optionIntraday.UserSelectedStrikePremium, this.days_left, optionIntraday.UNDERLYINGPRICE, this.UserSelectedStrike, this.OT);
					optionIntraday.priceRange = optionIntraday.UNDERLYINGPRICE * optionIntraday.IV / Math.Sqrt(365.0);
					this.option.lblrefPrice.Content = string.Format("Ref Price(Future level):  {0}", Option.LIVE_DATA.ltp.ToString() + " ~ Underlying PriceRange: " + Math.Round(optionIntraday.priceRange, 4).ToString());
					optionIntraday.refPrice = this.refPrice_comparison(_LTP, openPrice, preDayLTP, optionIntraday.IV, optionIntraday.priceRange);
					this.buyPrice = optionIntraday.refPrice + 0.236 * optionIntraday.priceRange;
					this.sellPrice = optionIntraday.refPrice - 0.236 * optionIntraday.priceRange;
					this.LTP_HISTORICAL.Add(optionIntraday.UNDERLYINGPRICE);
					optionIntraday.volatility = Comman.get_Volatility(this.LTP_HISTORICAL, 2);
					this.txtbxVolatility.Text = Math.Round(optionIntraday.volatility * Math.Sqrt(365.0) * 100.0, 2).ToString();
					this.txtbxDailyVolatility.Text = Math.Round(optionIntraday.volatility * 100.0, 2).ToString();
					this.buyTarget1 = this.buyPrice + this.ratio1 * optionIntraday.priceRange;
					this.buyTarget2 = this.buyTarget1 + this.ratio2 * optionIntraday.priceRange;
					this.buyTarget3 = this.buyTarget2 + this.ratio3 * optionIntraday.priceRange;
					this.buyTarget4 = this.buyTarget3 + this.ratio4 * optionIntraday.priceRange;
					this.buyTarget5 = this.buyTarget4 + this.ratio5 * optionIntraday.priceRange;
					this.buyTarget6 = this.buyTarget5 + this.ratio6 * optionIntraday.priceRange;
					this.sellTarget1 = this.sellPrice - this.ratio1 * optionIntraday.priceRange;
					this.sellTarget2 = this.sellTarget1 - this.ratio2 * optionIntraday.priceRange;
					this.sellTarget3 = this.sellTarget2 - this.ratio3 * optionIntraday.priceRange;
					this.sellTarget4 = this.sellTarget3 - this.ratio4 * optionIntraday.priceRange;
					this.sellTarget5 = this.sellTarget4 - this.ratio5 * optionIntraday.priceRange;
					this.sellTarget6 = this.sellTarget5 - this.ratio6 * optionIntraday.priceRange;
					this.txtbxBuy_underlyStrike.Text = Math.Round(this.buyPrice, 3).ToString();
					this.txtbxBuy_Target1Strike.Text = Math.Round(this.buyTarget1, 3).ToString();
					this.txtbxBuy_Target2Strike.Text = Math.Round(this.buyTarget2, 3).ToString();
					this.txtbxBuy_Target3Strike.Text = Math.Round(this.buyTarget3, 3).ToString();
					this.txtbxBuy_Target4Strike.Text = Math.Round(this.buyTarget4, 3).ToString();
					this.txtbxBuy_FinalTargetStrike.Text = Math.Round(this.buyTarget5, 3).ToString();
					this.txtbxBuy_ETargetStrike.Text = Math.Round(this.buyTarget6, 3).ToString();
					this.txtbxBuy_refTargetStrike.Text = Math.Round(optionIntraday.refPrice, 3).ToString();
					this.txtbxSell_underlyStrike.Text = Math.Round(this.sellPrice, 3).ToString();
					this.txtbxSell_Target1Strike.Text = Math.Round(this.sellTarget1, 3).ToString();
					this.txtbxSell_Target2Strike.Text = Math.Round(this.sellTarget2, 3).ToString();
					this.txtbxSell_Target3Strike.Text = Math.Round(this.sellTarget3, 3).ToString();
					this.txtbxSell_Target4Strike.Text = Math.Round(this.sellTarget4, 3).ToString();
					this.txtbxSell_FinalTargetStrike.Text = Math.Round(this.sellTarget5, 3).ToString();
					this.txtbxSell_ETargetStrike.Text = Math.Round(this.sellTarget6, 3).ToString();
					this.CalCulateOptionPremium();
				}
				else
				{
					string msgBxCaption = "Not enough tradable strike present for calculation.";
					if (this.OPTION_TABLE == null)
					{
						MessageBox.Show("Data could not be downloaded", msgBxCaption);
						return false;
					}
					if (this.LTP_HISTORICAL == null)
					{
						MessageBox.Show("Historical data not loaded", msgBxCaption);
						return false;
					}
				}
			}
			else if (MainWindow.currentTab == "OPTWEEK")
			{
				if (this.OPTION_TABLE != null)
				{
					optionIntraday.weeklyOption = true;
					this.txtbxVolatility.Visibility = Visibility.Hidden;
					this.txtbxVolatilityText.Visibility = Visibility.Hidden;
					this.txtbxDailyVolatility.Visibility = Visibility.Hidden;
					this.txtbxDailyVolatilityText.Visibility = Visibility.Hidden;
					if (Option.DAYS_LEFT_TILL_EXPIRY > 0)
					{
						this.days_left = Option.DAYS_LEFT_TILL_EXPIRY;
					}
					this.UserSelectedStrike = Convert.ToInt32(Convert.ToDouble(this.option.listBxStrike.SelectedItem));
					optionIntraday.UserSelectedStrikePremium = Convert.ToDouble(this.option.txtbxOptionPremium.Text);
					bool? isChecked = this.option.rBtnCall.IsChecked;
					bool flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						this.OT = "Call";
					}
					else
					{
						this.OT = "Put";
					}
					optionIntraday.IV = Comman.ImpliedVolatility(optionIntraday.UserSelectedStrikePremium, this.days_left, optionIntraday.UNDERLYINGPRICE, this.UserSelectedStrike, this.OT);
					optionIntraday.priceRange = optionIntraday.UNDERLYINGPRICE * optionIntraday.IV / Math.Sqrt(365.0);
					this.option.lblrefPrice.Content = string.Format("Ref Price: {0}", Option.LIVE_DATA.underlyingValue.ToString() + " ~ Underlying PriceRange: " + Math.Round(optionIntraday.priceRange, 4).ToString());
					optionIntraday.refPrice = optionIntraday.UNDERLYINGPRICE;
					this.buyPrice = optionIntraday.refPrice + 0.236 * optionIntraday.priceRange;
					this.sellPrice = optionIntraday.refPrice - 0.236 * optionIntraday.priceRange;
					this.LTP_HISTORICAL.Add(optionIntraday.UNDERLYINGPRICE);
					optionIntraday.volatility = Comman.get_Volatility(this.LTP_HISTORICAL, 2);
					this.txtbxVolatility.Text = Math.Round(optionIntraday.volatility * Math.Sqrt(365.0) * 100.0, 2).ToString();
					this.txtbxDailyVolatility.Text = Math.Round(optionIntraday.volatility * 100.0, 2).ToString();
					this.buyTarget1 = this.buyPrice + this.ratio1 * optionIntraday.priceRange;
					this.buyTarget2 = this.buyTarget1 + this.ratio2 * optionIntraday.priceRange;
					this.buyTarget3 = this.buyTarget2 + this.ratio3 * optionIntraday.priceRange;
					this.buyTarget4 = this.buyTarget3 + this.ratio4 * optionIntraday.priceRange;
					this.buyTarget5 = this.buyTarget4 + this.ratio5 * optionIntraday.priceRange;
					this.buyTarget6 = this.buyTarget5 + this.ratio6 * optionIntraday.priceRange;
					this.sellTarget1 = this.sellPrice - this.ratio1 * optionIntraday.priceRange;
					this.sellTarget2 = this.sellTarget1 - this.ratio2 * optionIntraday.priceRange;
					this.sellTarget3 = this.sellTarget2 - this.ratio3 * optionIntraday.priceRange;
					this.sellTarget4 = this.sellTarget3 - this.ratio4 * optionIntraday.priceRange;
					this.sellTarget5 = this.sellTarget4 - this.ratio5 * optionIntraday.priceRange;
					this.sellTarget6 = this.sellTarget5 - this.ratio6 * optionIntraday.priceRange;
					this.txtbxBuy_underlyStrike.Text = Math.Round(this.buyPrice, 3).ToString();
					this.txtbxBuy_Target1Strike.Text = Math.Round(this.buyTarget1, 3).ToString();
					this.txtbxBuy_Target2Strike.Text = Math.Round(this.buyTarget2, 3).ToString();
					this.txtbxBuy_Target3Strike.Text = Math.Round(this.buyTarget3, 3).ToString();
					this.txtbxBuy_Target4Strike.Text = Math.Round(this.buyTarget4, 3).ToString();
					this.txtbxBuy_FinalTargetStrike.Text = Math.Round(this.buyTarget5, 3).ToString();
					this.txtbxBuy_ETargetStrike.Text = Math.Round(this.buyTarget6, 3).ToString();
					this.txtbxBuy_refTargetStrike.Text = Math.Round(optionIntraday.refPrice, 3).ToString();
					this.txtbxSell_underlyStrike.Text = Math.Round(this.sellPrice, 3).ToString();
					this.txtbxSell_Target1Strike.Text = Math.Round(this.sellTarget1, 3).ToString();
					this.txtbxSell_Target2Strike.Text = Math.Round(this.sellTarget2, 3).ToString();
					this.txtbxSell_Target3Strike.Text = Math.Round(this.sellTarget3, 3).ToString();
					this.txtbxSell_Target4Strike.Text = Math.Round(this.sellTarget4, 3).ToString();
					this.txtbxSell_FinalTargetStrike.Text = Math.Round(this.sellTarget5, 3).ToString();
					this.txtbxSell_ETargetStrike.Text = Math.Round(this.sellTarget6, 3).ToString();
					this.CalCulateOptionPremium();
				}
				else
				{
					string msgBxCaption2 = "Not enough tradable strike present for calculation.";
					if (this.OPTION_TABLE == null)
					{
						MessageBox.Show("Data could not be downloaded", msgBxCaption2);
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00021F7C File Offset: 0x0002017C
		private double refPrice_comparison(double LTP, double openPrice, double preDayLTP, double IV, double priceRange)
		{
			double _refPrice = 0.0;
			double X = preDayLTP + 0.236 * priceRange;
			double Y = preDayLTP - 0.236 * priceRange;
			if (openPrice > X || openPrice < Y || LTP > openPrice + 0.236 * priceRange || LTP < openPrice - 0.236 * priceRange)
			{
				if (openPrice > X || openPrice < Y)
				{
					_refPrice = openPrice;
				}
				if (LTP > openPrice + 0.236 * priceRange || LTP < openPrice - 0.236 * priceRange)
				{
					_refPrice = LTP;
				}
			}
			else
			{
				_refPrice = preDayLTP;
			}
			return _refPrice;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00022010 File Offset: 0x00020210
		internal bool CalCulateOptionPremium()
		{
			bool flag;
			try
			{
				if (this.option.listBxStrike.SelectedIndex > -1)
				{
					double intransic = 0.0;
					int StrikeChoosen = this.UserSelectedStrike;
					double currentOptPremium = optionIntraday.UserSelectedStrikePremium;
					bool? isChecked = this.option.rBtnCall.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						intransic = optionIntraday.UNDERLYINGPRICE - (double)StrikeChoosen;
					}
					else
					{
						isChecked = this.option.rBtnPut.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							intransic = (double)StrikeChoosen - optionIntraday.UNDERLYINGPRICE;
						}
					}
					if (currentOptPremium != 0.0)
					{
						if (StrikeChoosen != 0)
						{
							if (this.days_left > 0)
							{
								if (intransic > currentOptPremium)
								{
									MessageBox.Show("INTRANSIC should not be greater than current option price", "Intransic-239");
									return false;
								}
								int LTP_HIS = this.LTP_HISTORICAL.Count;
								optionIntraday.pdLTP = this.LTP_HISTORICAL[LTP_HIS - 2];
								decimal IV4display = Math.Round(Convert.ToDecimal(optionIntraday.IV * 100.0), 2);
								double IV4Calculation = optionIntraday.IV;
								double num = (double)StrikeChoosen + this.strikeSpread;
								double num2 = this.strikeSpread;
								double num3 = (double)StrikeChoosen - this.strikeSpread;
								double num4 = this.strikeSpread;
								if (MainWindow.currentTab == "OPT")
								{
									double buyPremium = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), (double)StrikeChoosen, this.buyPrice, (double)this.days_left, this.OT);
									double buyPremium2 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget1, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget1, (double)this.days_left), (double)StrikeChoosen, this.buyTarget1, (double)this.days_left, this.OT);
									double buyPremium3 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget2, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget2, (double)this.days_left), (double)StrikeChoosen, this.buyTarget2, (double)this.days_left, this.OT);
									double buyPremium4 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget3, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget3, (double)this.days_left), (double)StrikeChoosen, this.buyTarget3, (double)this.days_left, this.OT);
									double buyPremium5 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget4, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget4, (double)this.days_left), (double)StrikeChoosen, this.buyTarget4, (double)this.days_left, this.OT);
									double buyPremium6 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget5, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget5, (double)this.days_left), (double)StrikeChoosen, this.buyTarget5, (double)this.days_left, this.OT);
									double buyPremium7 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget6, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget6, (double)this.days_left), (double)StrikeChoosen, this.buyTarget6, (double)this.days_left, this.OT);
									double sellPremium = Comman.premium(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.sellPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, this.sellPrice, (double)this.days_left), (double)StrikeChoosen, this.sellPrice, (double)this.days_left, this.OT);
									double sellPremium2 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget1, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget1, (double)this.days_left), (double)StrikeChoosen, this.sellTarget1, (double)this.days_left, this.OT);
									double sellPremium3 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget2, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget2, (double)this.days_left), (double)StrikeChoosen, this.sellTarget2, (double)this.days_left, this.OT);
									double sellPremium4 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget3, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget3, (double)this.days_left), (double)StrikeChoosen, this.sellTarget3, (double)this.days_left, this.OT);
									double sellPremium5 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget4, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget4, (double)this.days_left), (double)StrikeChoosen, this.sellTarget4, (double)this.days_left, this.OT);
									double sellPremium6 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget5, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget5, (double)this.days_left), (double)StrikeChoosen, this.sellTarget5, (double)this.days_left, this.OT);
									double sellPremium7 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget6, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget6, (double)this.days_left), (double)StrikeChoosen, this.sellTarget6, (double)this.days_left, this.OT);
									this.txtbxIV.Text = IV4display.ToString();
									this.txtbxBuy_underlyPremium.Text = Math.Round(buyPremium, 3).ToString();
									this.txtbxBuy_Target1Premium.Text = Math.Round(buyPremium2, 3).ToString();
									this.txtbxBuy_Target2Premium.Text = Math.Round(buyPremium3, 3).ToString();
									this.txtbxBuy_Target3Premium.Text = Math.Round(buyPremium4, 3).ToString();
									this.txtbxBuy_Target4Premium.Text = Math.Round(buyPremium5, 3).ToString();
									this.txtbxBuy_FinalTargetPremium.Text = Math.Round(buyPremium6, 3).ToString();
									this.txtbxBuy_ETargetStrikePremium.Text = Math.Round(buyPremium7, 3).ToString();
									this.txtbxBuy_refTargetStrikePremium.Text = currentOptPremium.ToString();
									double tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), this.OT);
									this.txtbxBuy_refTargetOmega.Text = Math.Round(optionIntraday.refPrice * tempDelta / currentOptPremium, 3).ToString();
									this.txtbxBuy_refTargetDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_refTargetGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), optionIntraday.refPrice, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_refTargetVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), optionIntraday.refPrice, (double)this.days_left), 3).ToString();
									this.txtbxBuy_refTargetTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.OT);
									this.txtbxBuy_underlyOmega.Text = Math.Round(this.buyPrice * tempDelta / buyPremium, 3).ToString();
									this.txtbxBuy_underlyDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_underlyGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.buyPrice, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_underlyVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.buyPrice, (double)this.days_left), 3).ToString();
									this.txtbxBuy_underlyTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), (double)StrikeChoosen, this.buyPrice, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4 = this.buyTarget1;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), this.OT);
									this.txtbxBuy_Target1Omega.Text = Math.Round(this.buyTarget1 * tempDelta / buyPremium2, 3).ToString();
									this.txtbxBuy_Target1Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target1Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), strike2calculate4, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target1Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), strike2calculate4, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target1Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4, (double)this.days_left), (double)StrikeChoosen, strike2calculate4, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target2 = this.buyTarget2;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), this.OT);
									this.txtbxBuy_Target2Omega.Text = Math.Round(this.buyTarget2 * tempDelta / buyPremium3, 3).ToString();
									this.txtbxBuy_Target2Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target2Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), strike2calculate4Target2, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target2Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), strike2calculate4Target2, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target2Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target2, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target3 = this.buyTarget3;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), this.OT);
									this.txtbxBuy_Target3Omega.Text = Math.Round(this.buyTarget3 * tempDelta / buyPremium4, 3).ToString();
									this.txtbxBuy_Target3Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target3Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), strike2calculate4Target3, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target3Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), strike2calculate4Target3, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target3Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target3, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target4 = this.buyTarget4;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), this.OT);
									this.txtbxBuy_Target4Omega.Text = Math.Round(this.buyTarget4 * tempDelta / buyPremium5, 3).ToString();
									this.txtbxBuy_Target4Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target4Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), strike2calculate4Target4, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target4Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), strike2calculate4Target4, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target4Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target4, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target5 = this.buyTarget5;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), this.OT);
									this.txtbxBuy_Target5Omega.Text = Math.Round(this.buyTarget5 * tempDelta / buyPremium6, 3).ToString();
									this.txtbxBuy_Target5Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target5Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), strike2calculate4Target5, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target5Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), strike2calculate4Target5, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target5Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target5, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target6 = this.buyTarget6;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), this.OT);
									this.txtbxBuy_Target6Omega.Text = Math.Round(this.buyTarget6 * tempDelta / buyPremium7, 3).ToString();
									this.txtbxBuy_Target6Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target6Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), strike2calculate4Target6, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target6Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), strike2calculate4Target6, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target6Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target6, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									this.txtbxSell_underlyPremium.Text = Math.Round(sellPremium, 3).ToString();
									this.txtbxSell_Target1Premium.Text = Math.Round(sellPremium2, 3).ToString();
									this.txtbxSell_Target2Premium.Text = Math.Round(sellPremium3, 3).ToString();
									this.txtbxSell_Target3Premium.Text = Math.Round(sellPremium4, 3).ToString();
									this.txtbxSell_Target4Premium.Text = Math.Round(sellPremium5, 3).ToString();
									this.txtbxSell_FinalTargetPremium.Text = Math.Round(sellPremium6, 3).ToString();
									this.txtbxSell_ETargetStrikePremium.Text = Math.Round(sellPremium7, 3).ToString();
									double underlying_strike = this.sellPrice;
									double tempSellDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), this.OT);
									this.txtbxSell_underlyOmega.Text = Math.Round(this.sellPrice * tempSellDelta / sellPremium, 3).ToString();
									this.txtbxSell_underlyDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_underlyGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), underlying_strike, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_underlyVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), underlying_strike, (double)this.days_left), 3).ToString();
									this.txtbxSell_underlyTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, underlying_strike, (double)this.days_left), (double)StrikeChoosen, underlying_strike, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget = this.sellTarget1;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), this.OT);
									this.txtbxSell_Target1Omega.Text = Math.Round(this.sellTarget1 * tempDelta / sellPremium2, 3).ToString();
									this.txtbxSell_Target1Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target1Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), strike_calculateSTarget, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target1Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), strike_calculateSTarget, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target1Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget2 = this.sellTarget2;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), this.OT);
									this.txtbxSell_Target2Omega.Text = Math.Round(this.sellTarget2 * tempDelta / sellPremium3, 3).ToString();
									this.txtbxSell_Target2Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target2Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), strike_calculateSTarget2, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target2Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), strike_calculateSTarget2, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target2Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget2, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget3 = this.sellTarget3;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), this.OT);
									this.txtbxSell_Target3Omega.Text = Math.Round(this.sellTarget3 * tempDelta / sellPremium4, 3).ToString();
									this.txtbxSell_Target3Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target3Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), strike_calculateSTarget3, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target3Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), strike_calculateSTarget3, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target3Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget3, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget4 = this.sellTarget4;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), this.OT);
									this.txtbxSell_Target4Omega.Text = Math.Round(this.sellTarget4 * tempDelta / sellPremium5, 3).ToString();
									this.txtbxSell_Target4Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target4Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), strike_calculateSTarget4, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target4Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), strike_calculateSTarget4, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target4Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget4, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget5 = this.sellTarget5;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), this.OT);
									this.txtbxSell_Target5Omega.Text = Math.Round(this.sellTarget5 * tempDelta / sellPremium6, 3).ToString();
									this.txtbxSell_Target5Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target5Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), strike_calculateSTarget5, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target5Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), strike_calculateSTarget5, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target5Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget5, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget6 = this.sellTarget6;
									tempDelta = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), this.OT);
									this.txtbxSell_Target6Omega.Text = Math.Round(this.sellTarget6 * tempDelta / sellPremium7, 3).ToString();
									this.txtbxSell_Target6Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target6Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), strike_calculateSTarget6, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target6Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), strike_calculateSTarget6, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target6Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget6, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
								}
								else if (MainWindow.currentTab == "OPTWEEK")
								{
									double buyPremium8 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), (double)StrikeChoosen, this.buyPrice, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium9 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget1, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget1, (double)this.days_left), (double)StrikeChoosen, this.buyTarget1, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium10 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget2, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget2, (double)this.days_left), (double)StrikeChoosen, this.buyTarget2, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium11 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget3, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget3, (double)this.days_left), (double)StrikeChoosen, this.buyTarget3, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium12 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget4, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget4, (double)this.days_left), (double)StrikeChoosen, this.buyTarget4, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium13 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget5, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget5, (double)this.days_left), (double)StrikeChoosen, this.buyTarget5, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double buyPremium14 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget6, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.buyTarget6, (double)this.days_left), (double)StrikeChoosen, this.buyTarget6, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium8 = Comman.premium(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.sellPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, this.sellPrice, (double)this.days_left), (double)StrikeChoosen, this.sellPrice, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium9 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget1, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget1, (double)this.days_left), (double)StrikeChoosen, this.sellTarget1, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium10 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget2, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget2, (double)this.days_left), (double)StrikeChoosen, this.sellTarget2, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium11 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget3, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget3, (double)this.days_left), (double)StrikeChoosen, this.sellTarget3, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium12 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget4, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget4, (double)this.days_left), (double)StrikeChoosen, this.sellTarget4, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium13 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget5, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget5, (double)this.days_left), (double)StrikeChoosen, this.sellTarget5, (double)this.days_left, this.OT) - Comman.thetaSpot;
									double sellPremium14 = Comman.premium(Comman.get_dValueA(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget6, (double)this.days_left), Comman.get_dValueB(optionIntraday.IV, (double)StrikeChoosen, this.sellTarget6, (double)this.days_left), (double)StrikeChoosen, this.sellTarget6, (double)this.days_left, this.OT) - Comman.thetaSpot;
									this.txtbxIV.Text = IV4display.ToString();
									this.txtbxBuy_underlyPremium.Text = Math.Round(buyPremium8, 3).ToString();
									this.txtbxBuy_Target1Premium.Text = Math.Round(buyPremium9, 3).ToString();
									this.txtbxBuy_Target2Premium.Text = Math.Round(buyPremium10, 3).ToString();
									this.txtbxBuy_Target3Premium.Text = Math.Round(buyPremium11, 3).ToString();
									this.txtbxBuy_Target4Premium.Text = Math.Round(buyPremium12, 3).ToString();
									this.txtbxBuy_FinalTargetPremium.Text = Math.Round(buyPremium13, 3).ToString();
									this.txtbxBuy_ETargetStrikePremium.Text = Math.Round(buyPremium14, 3).ToString();
									this.txtbxBuy_refTargetStrikePremium.Text = currentOptPremium.ToString();
									double tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), this.OT);
									this.txtbxBuy_refTargetOmega.Text = Math.Round(optionIntraday.refPrice * tempDelta2 / currentOptPremium, 3).ToString();
									this.txtbxBuy_refTargetDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_refTargetGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), optionIntraday.refPrice, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_refTargetVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), optionIntraday.refPrice, (double)this.days_left), 3).ToString();
									this.txtbxBuy_refTargetTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left), (double)StrikeChoosen, optionIntraday.refPrice, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.OT);
									this.txtbxBuy_underlyOmega.Text = Math.Round(this.buyPrice * tempDelta2 / buyPremium8, 3).ToString();
									this.txtbxBuy_underlyDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_underlyGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.buyPrice, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_underlyVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), this.buyPrice, (double)this.days_left), 3).ToString();
									this.txtbxBuy_underlyTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, this.buyPrice, (double)this.days_left), (double)StrikeChoosen, this.buyPrice, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate5 = this.buyTarget1;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), this.OT);
									this.txtbxBuy_Target1Omega.Text = Math.Round(this.buyTarget1 * tempDelta2 / buyPremium9, 3).ToString();
									this.txtbxBuy_Target1Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target1Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), strike2calculate5, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target1Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), strike2calculate5, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target1Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate5, (double)this.days_left), (double)StrikeChoosen, strike2calculate5, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target7 = this.buyTarget2;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), this.OT);
									this.txtbxBuy_Target2Omega.Text = Math.Round(this.buyTarget2 * tempDelta2 / buyPremium10, 3).ToString();
									this.txtbxBuy_Target2Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target2Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), strike2calculate4Target7, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target2Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), strike2calculate4Target7, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target2Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target7, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target8 = this.buyTarget3;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), this.OT);
									this.txtbxBuy_Target3Omega.Text = Math.Round(this.buyTarget3 * tempDelta2 / buyPremium11, 3).ToString();
									this.txtbxBuy_Target3Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target3Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), strike2calculate4Target8, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target3Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), strike2calculate4Target8, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target3Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target8, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target9 = this.buyTarget4;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), this.OT);
									this.txtbxBuy_Target4Omega.Text = Math.Round(this.buyTarget4 * tempDelta2 / buyPremium12, 3).ToString();
									this.txtbxBuy_Target4Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target4Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), strike2calculate4Target9, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target4Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), strike2calculate4Target9, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target4Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target9, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target10 = this.buyTarget5;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), this.OT);
									this.txtbxBuy_Target5Omega.Text = Math.Round(this.buyTarget5 * tempDelta2 / buyPremium13, 3).ToString();
									this.txtbxBuy_Target5Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target5Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), strike2calculate4Target10, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target5Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), strike2calculate4Target10, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target5Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target10, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike2calculate4Target11 = this.buyTarget6;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), this.OT);
									this.txtbxBuy_Target6Omega.Text = Math.Round(this.buyTarget6 * tempDelta2 / buyPremium14, 3).ToString();
									this.txtbxBuy_Target6Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxBuy_Target6Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), strike2calculate4Target11, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxBuy_Target6Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), strike2calculate4Target11, (double)this.days_left), 3).ToString();
									this.txtbxBuy_Target6Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left), (double)StrikeChoosen, strike2calculate4Target11, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									this.txtbxSell_underlyPremium.Text = Math.Round(sellPremium8, 3).ToString();
									this.txtbxSell_Target1Premium.Text = Math.Round(sellPremium9, 3).ToString();
									this.txtbxSell_Target2Premium.Text = Math.Round(sellPremium10, 3).ToString();
									this.txtbxSell_Target3Premium.Text = Math.Round(sellPremium11, 3).ToString();
									this.txtbxSell_Target4Premium.Text = Math.Round(sellPremium12, 3).ToString();
									this.txtbxSell_FinalTargetPremium.Text = Math.Round(sellPremium13, 3).ToString();
									this.txtbxSell_ETargetStrikePremium.Text = Math.Round(sellPremium14, 3).ToString();
									double underlying_strike2 = this.sellPrice;
									double tempSellDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), this.OT);
									this.txtbxSell_underlyOmega.Text = Math.Round(this.sellPrice * tempSellDelta2 / sellPremium8, 3).ToString();
									this.txtbxSell_underlyDelta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_underlyGamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), underlying_strike2, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_underlyVega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), underlying_strike2, (double)this.days_left), 3).ToString();
									this.txtbxSell_underlyTheta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, underlying_strike2, (double)this.days_left), (double)StrikeChoosen, underlying_strike2, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget7 = this.sellTarget1;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), this.OT);
									this.txtbxSell_Target1Omega.Text = Math.Round(this.sellTarget1 * tempDelta2 / sellPremium9, 3).ToString();
									this.txtbxSell_Target1Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target1Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), strike_calculateSTarget7, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target1Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), strike_calculateSTarget7, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target1Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget7, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget8 = this.sellTarget2;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), this.OT);
									this.txtbxSell_Target2Omega.Text = Math.Round(this.sellTarget2 * tempDelta2 / sellPremium10, 3).ToString();
									this.txtbxSell_Target2Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target2Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), strike_calculateSTarget8, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target2Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), strike_calculateSTarget8, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target2Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget8, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget9 = this.sellTarget3;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), this.OT);
									this.txtbxSell_Target3Omega.Text = Math.Round(this.sellTarget3 * tempDelta2 / sellPremium11, 3).ToString();
									this.txtbxSell_Target3Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target3Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), strike_calculateSTarget9, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target3Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), strike_calculateSTarget9, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target3Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget9, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget10 = this.sellTarget4;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), this.OT);
									this.txtbxSell_Target4Omega.Text = Math.Round(this.sellTarget4 * tempDelta2 / sellPremium12, 3).ToString();
									this.txtbxSell_Target4Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target4Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), strike_calculateSTarget10, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target4Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), strike_calculateSTarget10, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target4Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget10, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget11 = this.sellTarget5;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), this.OT);
									this.txtbxSell_Target5Omega.Text = Math.Round(this.sellTarget5 * tempDelta2 / sellPremium13, 3).ToString();
									this.txtbxSell_Target5Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target5Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), strike_calculateSTarget11, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target5Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), strike_calculateSTarget11, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target5Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget11, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
									double strike_calculateSTarget12 = this.sellTarget6;
									tempDelta2 = Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), this.OT);
									this.txtbxSell_Target6Omega.Text = Math.Round(this.sellTarget6 * tempDelta2 / sellPremium14, 3).ToString();
									this.txtbxSell_Target6Delta.Text = Math.Round(Comman.delta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), this.OT), 3).ToString();
									this.txtbxSell_Target6Gamma.Text = Math.Round(Comman.gamma(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), strike_calculateSTarget12, (double)this.days_left, IV4Calculation), 3).ToString();
									this.txtbxSell_Target6Vega.Text = Math.Round(Comman.vega(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), strike_calculateSTarget12, (double)this.days_left), 3).ToString();
									this.txtbxSell_Target6Theta.Text = Math.Round(Comman.theta(Comman.get_dValueA(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), Comman.get_dValueB(IV4Calculation, (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left), (double)StrikeChoosen, strike_calculateSTarget12, (double)this.days_left, IV4Calculation, this.OT), 3).ToString();
								}
							}
							else
							{
								MessageBox.Show("No analysis can be derived on Expiry Day.", "Expiry day no calculation");
							}
						}
						else
						{
							MessageBox.Show("Strike Choosen should be greated than zero.", "No proper strike");
						}
					}
					else
					{
						MessageBox.Show("Current option premium should not be zero", "Zero premium");
					}
				}
				flag = true;
			}
			catch (Exception)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x04000445 RID: 1093
		public static double LOW;

		// Token: 0x04000446 RID: 1094
		public static double HIGH;

		// Token: 0x04000447 RID: 1095
		public static double LTP;

		// Token: 0x04000448 RID: 1096
		public static double OPEN;

		// Token: 0x04000449 RID: 1097
		public static double UNDERLYINGPRICE;

		// Token: 0x0400044A RID: 1098
		public static double IV;

		// Token: 0x0400044B RID: 1099
		public static double UserSelectedStrikePremium;

		// Token: 0x0400044C RID: 1100
		[Nullable(1)]
		private string OT = string.Empty;

		// Token: 0x0400044D RID: 1101
		private int UserSelectedStrike;

		// Token: 0x0400044E RID: 1102
		public static double priceRange;

		// Token: 0x0400044F RID: 1103
		public static double pdLTP;

		// Token: 0x04000450 RID: 1104
		public static double volatility;

		// Token: 0x04000451 RID: 1105
		public static double refPrice;

		// Token: 0x04000452 RID: 1106
		[Nullable(1)]
		private DataTable OPTION_TABLE;

		// Token: 0x04000453 RID: 1107
		[Nullable(1)]
		private Dictionary<string, string> CALLSTRIKE;

		// Token: 0x04000454 RID: 1108
		[Nullable(1)]
		private Dictionary<string, string> PUTSTRIKE;

		// Token: 0x04000455 RID: 1109
		[Nullable(1)]
		private List<double> LTP_HISTORICAL;

		// Token: 0x04000456 RID: 1110
		private double buyPrice;

		// Token: 0x04000457 RID: 1111
		private double buyTarget1;

		// Token: 0x04000458 RID: 1112
		private double buyTarget2;

		// Token: 0x04000459 RID: 1113
		private double buyTarget3;

		// Token: 0x0400045A RID: 1114
		private double buyTarget4;

		// Token: 0x0400045B RID: 1115
		private double buyTarget5;

		// Token: 0x0400045C RID: 1116
		private double buyTarget6;

		// Token: 0x0400045D RID: 1117
		private double sellPrice;

		// Token: 0x0400045E RID: 1118
		private double sellTarget1;

		// Token: 0x0400045F RID: 1119
		private double sellTarget2;

		// Token: 0x04000460 RID: 1120
		private double sellTarget3;

		// Token: 0x04000461 RID: 1121
		private double sellTarget4;

		// Token: 0x04000462 RID: 1122
		private double sellTarget5;

		// Token: 0x04000463 RID: 1123
		private double sellTarget6;

		// Token: 0x04000464 RID: 1124
		private double ratio1 = 0.132;

		// Token: 0x04000465 RID: 1125
		private double ratio2 = 0.25;

		// Token: 0x04000466 RID: 1126
		private double ratio3 = 0.368;

		// Token: 0x04000467 RID: 1127
		private double ratio4 = 0.536;

		// Token: 0x04000468 RID: 1128
		private double ratio5 = 0.75;

		// Token: 0x04000469 RID: 1129
		private double ratio6 = 1.022;

		// Token: 0x0400046A RID: 1130
		public static double cIV;

		// Token: 0x0400046B RID: 1131
		public static double pIV;

		// Token: 0x0400046C RID: 1132
		public static double d1Test;

		// Token: 0x0400046D RID: 1133
		public static double d2Test;

		// Token: 0x0400046E RID: 1134
		public static double Nd1Test;

		// Token: 0x0400046F RID: 1135
		private int days_left;

		// Token: 0x04000470 RID: 1136
		private double strikeSpread;

		// Token: 0x04000471 RID: 1137
		public static bool weeklyOption;

		// Token: 0x04000472 RID: 1138
		[Nullable(1)]
		private Option option;
	}
}
