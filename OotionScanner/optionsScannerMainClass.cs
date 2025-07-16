using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using FnOHelper;
using New_SF_IT.classes;
using New_SF_IT.Helpers;
using SFHelper;
using siteDownLoadHelper;

namespace New_SF_IT.OotionScanner
{
	// Token: 0x0200002D RID: 45
	[NullableContext(1)]
	[Nullable(0)]
	internal class optionsScannerMainClass : ViewModelBase
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000281C3 File Offset: 0x000263C3
		public List<string> INSTRUMENTS
		{
			get
			{
				return new List<string>
				{
					"STOCK FUTURE",
					"INDEX FUTURE"
				};
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000239 RID: 569 RVA: 0x000281E0 File Offset: 0x000263E0
		// (set) Token: 0x0600023A RID: 570 RVA: 0x000281E8 File Offset: 0x000263E8
		public string selectedINSTRUMENT
		{
			get
			{
				return this._selectedInstrument;
			}
			set
			{
				if (value != null)
				{
					this._selectedInstrument = value;
					this.SYMBOL = "";
					if (this._selectedInstrument != "")
					{
						this.LoadSymbols("");
					}
					this.OnPropertyChanged("selectedINSTRUMENT");
				}
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00028227 File Offset: 0x00026427
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0002822F File Offset: 0x0002642F
		public string SYMBOL
		{
			get
			{
				return this._displayedSymbol;
			}
			set
			{
				this._displayedSymbol = value;
				this.OnPropertyChanged("SYMBOL");
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00028243 File Offset: 0x00026443
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0002824B File Offset: 0x0002644B
		public int SELECTED_EXPIRY_INDEX
		{
			get
			{
				return this._selected_expiry_index;
			}
			set
			{
				this._selected_expiry_index = value;
				this.OnPropertyChanged("SELECTED_EXPIRY_INDEX");
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0002825F File Offset: 0x0002645F
		// (set) Token: 0x06000240 RID: 576 RVA: 0x00028281 File Offset: 0x00026481
		public ObservableCollection<string> EXPIRYDATE
		{
			get
			{
				if (this._expiryDates == null)
				{
					return null;
				}
				if (this._expiryDates.Count > 0)
				{
					return this._expiryDates;
				}
				return null;
			}
			set
			{
				this._expiryDates = value;
				this.OnPropertyChanged("EXPIRYDATE");
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00028295 File Offset: 0x00026495
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0002829D File Offset: 0x0002649D
		public ObservableCollection<string> SYMBOLS
		{
			get
			{
				return this._symbols;
			}
			set
			{
				this._symbols = value;
				this.OnPropertyChanged("SYMBOLS");
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000243 RID: 579 RVA: 0x000282B1 File Offset: 0x000264B1
		// (set) Token: 0x06000244 RID: 580 RVA: 0x000282B9 File Offset: 0x000264B9
		public string selectedEDate
		{
			get
			{
				return this._selectedEDate;
			}
			set
			{
				if (value != null)
				{
					this._selectedEDate = value;
					this.OnPropertyChanged("selectedEDate");
				}
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000282D0 File Offset: 0x000264D0
		private void LoadSymbols(string _fileName)
		{
			string selectedInstrument = this._selectedInstrument;
			if (!(selectedInstrument == "STOCK FUTURE"))
			{
				if (selectedInstrument == "INDEX FUTURE")
				{
					if (Comman.IsInternetAvailable())
					{
						string data = new downloadSiteCls(new Uri(this.INDEXPATH)).getSite();
						if (!string.IsNullOrWhiteSpace(data))
						{
							this._symbols = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
							this.OnPropertyChanged("SYMBOLS");
						}
					}
					this.SYMBOL = "NIFTY";
				}
			}
			else
			{
				if (Comman.IsInternetAvailable())
				{
					string data2 = new downloadSiteCls(new Uri(this.STOCKFUTUREPATH)).getSite();
					if (!string.IsNullOrWhiteSpace(data2))
					{
						this._symbols = new ObservableCollection<string>(data2.Split('\n', StringSplitOptions.None).ToList<string>());
						this.OnPropertyChanged("SYMBOLS");
					}
				}
				this.SYMBOL = "ICICIBANK";
			}
			this.Load_ExpiryDate("IDX-STKexpiry.txt");
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000283B8 File Offset: 0x000265B8
		private void Load_ExpiryDate(string _fileName)
		{
			if (Comman.IsInternetAvailable())
			{
				string data = new downloadSiteCls(new Uri(this.EXPIRYURL + _fileName)).getSite();
				data = data.Replace("\r", "");
				if (!string.IsNullOrWhiteSpace(data))
				{
					this._expiryDates = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
					this.OnPropertyChanged("EXPIRYDATE");
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00028428 File Offset: 0x00026628
		public ICommand LoadOptionsData
		{
			get
			{
				this.optionScannerWindow.loadButton.Content = "Loading...";
				if (this._LoadOptionsData == null)
				{
					this._LoadOptionsData = new DelegateCommand(delegate(object param)
					{
						this.LoadOptionsDataTable(param);
					});
				}
				this.optionScannerWindow.loadButton.Content = "Load";
				return this._LoadOptionsData;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00028484 File Offset: 0x00026684
		public void LoadOptionsDataTable(object O)
		{
			string _instrument = this._selectedInstrument;
			string _scriptCode = this.SYMBOL;
			_scriptCode = _scriptCode.Replace("&", "%26");
			string _expiry = this._selectedEDate;
			this.NoOfDays = optionsScannerfMathCls.GetDaysLeft4Expiry(_expiry);
			DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
			this.dT = this.fnOobj.downloadWebPage(_instrument, _scriptCode, _expiry);
			this.optionScannerWindow.trends.Visibility = Visibility.Collapsed;
			if (this.dT == null)
			{
				MessageBox.Show("Please wait for few minutes & try", "Data is null", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.dT != null)
			{
				this._TradedCallStrike = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "cLTP");
				this._TradedPutStrike = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "pLTP");
				this._cOI_Strikes = new Dictionary<string, string>();
				this._pOI_Strikes = new Dictionary<string, string>();
				optionsScannerMainClass.filertered_cOI_Strikes = new Dictionary<string, string>();
				optionsScannerMainClass.filertered_pOI_Strikes = new Dictionary<string, string>();
				this._cOI_Strikes = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "cOI");
				this._pOI_Strikes = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "pOI");
				for (int i = 0; i <= this._cOI_Strikes.Count - 1; i++)
				{
					KeyValuePair<string, string> item = this._cOI_Strikes.ElementAt(i);
					string Key = item.Key;
					string Value = item.Value;
					foreach (KeyValuePair<string, string> pair in this._pOI_Strikes)
					{
						if (pair.Key == Key)
						{
							optionsScannerMainClass.filertered_cOI_Strikes.Add(Key, Value);
							optionsScannerMainClass.filertered_pOI_Strikes.Add(pair.Key, pair.Value);
						}
					}
				}
				LiveMarketQuoteDataCls allPrices = this.getCurrentLTP.get_Quote(_instrument, _scriptCode, _expiry);
				this.currentLTP = Convert.ToDouble(allPrices.ltp);
				this.openPrice = Convert.ToDouble(allPrices.open);
				this.underlyingPrice = Convert.ToDouble(allPrices.underlyingValue);
				this.prevDayLTP = Convert.ToDouble(allPrices.preClose);
				this.filterOptionData();
				MessageBox.Show("Data is Loaded Successfully", "Option Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				this.optionScannerWindow.conditionBox.IsEnabled = true;
				this.optionScannerWindow.all.IsChecked = new bool?(true);
				this.optionScannerWindow.analyse.IsEnabled = true;
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00028720 File Offset: 0x00026920
		public void LoadOptionsDataTable_Weekly()
		{
			string _instrument = "INDEX FUTURE";
			string _scriptCode = "NIFTY";
			_scriptCode = _scriptCode.Replace("&", "%26");
			this.loadExpiry_Weekly();
			this._selectedEDate = this._currentMonthExpiryy_weekly;
			string _expiry = this._selectedEDate;
			this.NoOfDays = optionsScannerfMathCls.GetDaysLeft4Expiry(_expiry);
			DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
			this.dT = this.fnOobj.downloadWebPage(_instrument, _scriptCode, _expiry);
			if (this.dT == null)
			{
				MessageBox.Show("Please wait for few minutes & try", "Data is null", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.dT != null)
			{
				this._TradedCallStrike = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "cLTP");
				this._TradedPutStrike = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "pLTP");
				this._cOI_Strikes = new Dictionary<string, string>();
				this._pOI_Strikes = new Dictionary<string, string>();
				optionsScannerMainClass.filertered_cOI_Strikes_weekly = new Dictionary<string, string>();
				optionsScannerMainClass.filertered_pOI_Strikes_weekly = new Dictionary<string, string>();
				this._cOI_Strikes = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "cOI");
				this._pOI_Strikes = FnOHelperCls.filter_TradingStrike(this.dT, "strikePrice", "pOI");
				for (int i = 0; i <= this._cOI_Strikes.Count - 1; i++)
				{
					KeyValuePair<string, string> item = this._cOI_Strikes.ElementAt(i);
					string Key = item.Key;
					string Value = item.Value;
					foreach (KeyValuePair<string, string> pair in this._pOI_Strikes)
					{
						if (pair.Key == Key)
						{
							optionsScannerMainClass.filertered_cOI_Strikes_weekly.Add(Key, Value);
							optionsScannerMainClass.filertered_pOI_Strikes_weekly.Add(pair.Key, pair.Value);
						}
					}
				}
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00028914 File Offset: 0x00026B14
		public void loadExpiry_Weekly()
		{
			string data = new downloadSiteCls(new Uri(this.EXPIRYURL + "IDX-STKexpiryWeek.txt")).getSite();
			if (data == null)
			{
				MessageBox.Show("Check your Internet connection", "Connectivity Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			data = data.Replace("\r", "");
			if (!string.IsNullOrWhiteSpace(data))
			{
				this._expiry_weekly = new ObservableCollection<string>(data.Split('\n', StringSplitOptions.None).ToList<string>());
				this._currentMonthExpiryy_weekly = this._expiry_weekly[0];
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0002899C File Offset: 0x00026B9C
		public Dictionary<double, double> filterStrikes(Dictionary<string, string> _Strike, double _refPrice, string OT, int DaysLeft)
		{
			int count = _Strike.Count;
			Dictionary<double, double> dict = new Dictionary<double, double>();
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<string, string> item = _Strike.ElementAt(currentRow);
				string key = item.Key;
				string Value = item.Value;
				double Strike = Convert.ToDouble(key);
				double Premium = Convert.ToDouble(Value);
				if (Premium >= 2.0)
				{
					if (OT == "Call" && Strike + Premium >= this.currentLTP)
					{
						double IV = optionsScannerfMathCls.ImpliedVolatility(Premium, DaysLeft, _refPrice, Strike, OT);
						if (!double.IsNaN(IV) && IV != 0.0)
						{
							dict.Add(Strike, Premium);
						}
					}
					if (OT == "Put" && Strike - Premium <= this.currentLTP)
					{
						double IV2 = optionsScannerfMathCls.ImpliedVolatility(Premium, DaysLeft, _refPrice, Strike, OT);
						if (!double.IsNaN(IV2) && IV2 != 0.0)
						{
							dict.Add(Strike, Premium);
						}
					}
				}
			}
			return dict;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00028A98 File Offset: 0x00026C98
		public Dictionary<double, double> filterIV(Dictionary<double, double> filteredStrike, int DaysLeft, double _refPrice, string OT)
		{
			Dictionary<double, double> IVlist = new Dictionary<double, double>();
			int count = filteredStrike.Count;
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<double, double> item = filteredStrike.ElementAt(currentRow);
				double key = item.Key;
				double Value = item.Value;
				double strike = Convert.ToDouble(key);
				double premium = Convert.ToDouble(Value);
				this.IV = optionsScannerfMathCls.ImpliedVolatility(premium, DaysLeft, _refPrice, strike, OT);
				IVlist.Add(strike, this.IV);
			}
			return IVlist;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00028B0C File Offset: 0x00026D0C
		public double IVforPriceRange(Dictionary<double, double> _IVlist, double _refPrice)
		{
			int count = _IVlist.Count<KeyValuePair<double, double>>();
			Dictionary<double, double> IVpricerange = new Dictionary<double, double>();
			for (int i = 0; i <= count - 1; i++)
			{
				KeyValuePair<double, double> item = _IVlist.ElementAt(i);
				double key = item.Key;
				double Value = item.Value;
				double strike = Convert.ToDouble(key);
				double _IV = Convert.ToDouble(Value);
				if (strike >= _refPrice)
				{
					IVpricerange.Add(strike, _IV);
				}
			}
			double _IV2 = 0.0;
			if (IVpricerange.Count != 0)
			{
				_IV2 = Convert.ToDouble(IVpricerange.ElementAt(0).Value);
			}
			return _IV2;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00028B98 File Offset: 0x00026D98
		public List<double> TargetsCalc(double _refPrice, double priceRange, int PlusOrMinus1)
		{
			List<double> list = new List<double>();
			double BuyOrSellEntry = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.baseratioBuyOrSell, PlusOrMinus1);
			double T = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T1ratio, PlusOrMinus1);
			double T2 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T2ratio, PlusOrMinus1);
			double T3 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T3ratio, PlusOrMinus1);
			double T4 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T4ratio, PlusOrMinus1);
			double T5 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T5ratio, PlusOrMinus1);
			double T6 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T6ratio, PlusOrMinus1);
			double T7 = optionsScannerfMathCls.buyOrsell(_refPrice, priceRange, optionsScannerbaseRatios.T7ratio, PlusOrMinus1);
			list.Add(BuyOrSellEntry);
			list.Add(T);
			list.Add(T2);
			list.Add(T3);
			list.Add(T4);
			list.Add(T5);
			list.Add(T6);
			list.Add(T7);
			return list;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00028C5C File Offset: 0x00026E5C
		public List<double> TargetPremiums(Dictionary<double, double> strikeDict, Dictionary<double, double> ivDict, double DaysLeft, double _refPrice, string OT)
		{
			List<double> targPremium = new List<double>();
			int count = strikeDict.Count;
			for (int i = 0; i <= count - 1; i++)
			{
				KeyValuePair<double, double> item = strikeDict.ElementAt(i);
				double key = item.Key;
				double value = item.Value;
				double Strike = Convert.ToDouble(key);
				double Premium = Convert.ToDouble(value);
				double value2 = Convert.ToDouble(ivDict.ElementAt(i).Value);
				decimal _Strike = Convert.ToDecimal(Strike);
				Convert.ToDecimal(Premium);
				decimal _IV = Convert.ToDecimal(value2);
				decimal ltfutureStrike = Convert.ToDecimal(_refPrice);
				decimal _DaysLeft = Convert.ToDecimal(DaysLeft);
				decimal _interestRate = 0.10m;
				decimal num = optionsScannerfMathCls.get_dValueX(ltfutureStrike, _Strike, _IV, _DaysLeft, _interestRate);
				decimal _d2 = optionsScannerfMathCls.get_dValueY(num, _IV, _DaysLeft);
				double d3 = Convert.ToDouble(num);
				double d2 = Convert.ToDouble(_d2);
				double TargetPremium = optionsScannerfMathCls.premium(d3, d2, Strike, _refPrice, (double)this.NoOfDays, OT);
				targPremium.Add(TargetPremium);
			}
			return targPremium;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00028D44 File Offset: 0x00026F44
		public void filterOptionData()
		{
			this.callDict = this.filterStrikes(this._TradedCallStrike, this.underlyingPrice, "Call", this.NoOfDays);
			this.cIV = this.filterIV(this.callDict, this.NoOfDays, this.underlyingPrice, "Call");
			this.cIVpricerange = this.IVforPriceRange(this.cIV, this.underlyingPrice);
			this.refPrice = this.underlyingPrice;
			this.cPriceRange = optionsScannerfMathCls.priceRange(this.cIVpricerange, this.refPrice, 1);
			this.putDict = this.filterStrikes(this._TradedPutStrike, this.underlyingPrice, "Put", this.NoOfDays);
			this.pIV = this.filterIV(this.putDict, this.NoOfDays, this.underlyingPrice, "Put");
			this.pIVpricerange = this.IVforPriceRange(this.pIV, this.underlyingPrice);
			this.pPriceRange = optionsScannerfMathCls.priceRange(this.pIVpricerange, this.refPrice, 1);
			if (this.cPriceRange == 0.0 && this.pPriceRange == 0.0)
			{
				if (optionsScannerMainClass.callTable.Rows.Count != 0)
				{
					optionsScannerMainClass.callTable.Rows.Clear();
					optionsScannerMainClass.putTable.Rows.Clear();
					return;
				}
			}
			else
			{
				if (this.cPriceRange != 0.0 && this.pPriceRange == 0.0)
				{
					this.callBuyTargets = this.TargetsCalc(this.refPrice, this.cPriceRange, 1);
					this.callSellTargets = this.TargetsCalc(this.refPrice, this.cPriceRange, -1);
					this.callBE = this.callBuyTargets[0];
					this.callBT1 = this.callBuyTargets[1];
					this.callBT2 = this.callBuyTargets[2];
					this.callBT3 = this.callBuyTargets[3];
					this.callBT4 = this.callBuyTargets[4];
					this.callBT5 = this.callBuyTargets[5];
					this.callBT6 = this.callBuyTargets[6];
					this.callBT7 = this.callBuyTargets[7];
					this.callSE = this.callSellTargets[0];
					this.callST1 = this.callSellTargets[1];
					this.callST2 = this.callSellTargets[2];
					this.callST3 = this.callSellTargets[3];
					this.callST4 = this.callSellTargets[4];
					this.callST5 = this.callSellTargets[5];
					this.callST6 = this.callSellTargets[6];
					this.callST7 = this.callSellTargets[7];
					this.cBuyEntry = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBE, "Call");
					this.cBT1 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT1, "Call");
					this.cBT2 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT2, "Call");
					this.cBT3 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT3, "Call");
					this.cBT4 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT4, "Call");
					this.cBT5 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT5, "Call");
					this.cBT6 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT6, "Call");
					this.cBT7 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT7, "Call");
					this.cSellEntry = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callSE, "Call");
					this.cST1 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST1, "Call");
					this.cST2 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST2, "Call");
					this.cST3 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST3, "Call");
					this.cST4 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST4, "Call");
					this.cST5 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST5, "Call");
					this.cST6 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST6, "Call");
					this.cST7 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST7, "Call");
					optionsScannerMainClass.callTable = this.CreateTable(this.callBuyTargets, this.callSellTargets, this.callDict, this.cIV, this.cBuyEntry, this.cBT1, this.cBT2, this.cBT3, this.cBT4, this.cBT5, this.cBT6, this.cBT7, this.cSellEntry, this.cST1, this.cST2, this.cST3, this.cST4, this.cST5, this.cST6, this.cST7, "Call");
					return;
				}
				if (this.cPriceRange == 0.0 && this.pPriceRange != 0.0)
				{
					this.putBuyTargets = this.TargetsCalc(this.refPrice, this.pPriceRange, 1);
					this.putSellTargets = this.TargetsCalc(this.refPrice, this.pPriceRange, -1);
					this.putBE = this.putBuyTargets[0];
					this.putBT1 = this.putBuyTargets[1];
					this.putBT2 = this.putBuyTargets[2];
					this.putBT3 = this.putBuyTargets[3];
					this.putBT4 = this.putBuyTargets[4];
					this.putBT5 = this.putBuyTargets[5];
					this.putBT6 = this.putBuyTargets[6];
					this.putBT7 = this.putBuyTargets[7];
					this.putSE = this.putSellTargets[0];
					this.putST1 = this.putSellTargets[1];
					this.putST2 = this.putSellTargets[2];
					this.putST3 = this.putSellTargets[3];
					this.putST4 = this.putSellTargets[4];
					this.putST5 = this.putSellTargets[5];
					this.putST6 = this.putSellTargets[6];
					this.putST7 = this.putSellTargets[7];
					this.pBuyEntry = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBE, "Put");
					this.pBT1 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT1, "Put");
					this.pBT2 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT2, "Put");
					this.pBT3 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT3, "Put");
					this.pBT4 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT4, "Put");
					this.pBT5 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT5, "Put");
					this.pBT6 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT6, "Put");
					this.pBT7 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT7, "Put");
					this.pSellEntry = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putSE, "Put");
					this.pST1 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST1, "Put");
					this.pST2 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST2, "Put");
					this.pST3 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST3, "Put");
					this.pST4 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST4, "Put");
					this.pST5 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST5, "Put");
					this.pST6 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST6, "Put");
					this.pST7 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST7, "Put");
					optionsScannerMainClass.putTable = this.CreateTable(this.putBuyTargets, this.putSellTargets, this.putDict, this.pIV, this.pBuyEntry, this.pBT1, this.pBT2, this.pBT3, this.pBT4, this.pBT5, this.pBT6, this.pBT7, this.pSellEntry, this.pST1, this.pST2, this.pST3, this.pST4, this.pST5, this.pST6, this.pST7, "Put");
					return;
				}
				this.callBuyTargets = this.TargetsCalc(this.refPrice, this.cPriceRange, 1);
				this.callSellTargets = this.TargetsCalc(this.refPrice, this.cPriceRange, -1);
				this.putBuyTargets = this.TargetsCalc(this.refPrice, this.pPriceRange, 1);
				this.putSellTargets = this.TargetsCalc(this.refPrice, this.pPriceRange, -1);
				this.callBE = this.callBuyTargets[0];
				this.callBT1 = this.callBuyTargets[1];
				this.callBT2 = this.callBuyTargets[2];
				this.callBT3 = this.callBuyTargets[3];
				this.callBT4 = this.callBuyTargets[4];
				this.callBT5 = this.callBuyTargets[5];
				this.callBT6 = this.callBuyTargets[6];
				this.callBT7 = this.callBuyTargets[7];
				this.callSE = this.callSellTargets[0];
				this.callST1 = this.callSellTargets[1];
				this.callST2 = this.callSellTargets[2];
				this.callST3 = this.callSellTargets[3];
				this.callST4 = this.callSellTargets[4];
				this.callST5 = this.callSellTargets[5];
				this.callST6 = this.callSellTargets[6];
				this.callST7 = this.callSellTargets[7];
				this.putBE = this.putBuyTargets[0];
				this.putBT1 = this.putBuyTargets[1];
				this.putBT2 = this.putBuyTargets[2];
				this.putBT3 = this.putBuyTargets[3];
				this.putBT4 = this.putBuyTargets[4];
				this.putBT5 = this.putBuyTargets[5];
				this.putBT6 = this.putBuyTargets[6];
				this.putBT7 = this.putBuyTargets[7];
				this.putSE = this.putSellTargets[0];
				this.putST1 = this.putSellTargets[1];
				this.putST2 = this.putSellTargets[2];
				this.putST3 = this.putSellTargets[3];
				this.putST4 = this.putSellTargets[4];
				this.putST5 = this.putSellTargets[5];
				this.putST6 = this.putSellTargets[6];
				this.putST7 = this.putSellTargets[7];
				this.cBuyEntry = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBE, "Call");
				this.cBT1 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT1, "Call");
				this.cBT2 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT2, "Call");
				this.cBT3 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT3, "Call");
				this.cBT4 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT4, "Call");
				this.cBT5 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT5, "Call");
				this.cBT6 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT6, "Call");
				this.cBT7 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callBT7, "Call");
				this.cSellEntry = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callSE, "Call");
				this.cST1 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST1, "Call");
				this.cST2 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST2, "Call");
				this.cST3 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST3, "Call");
				this.cST4 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST4, "Call");
				this.cST5 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST5, "Call");
				this.cST6 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST6, "Call");
				this.cST7 = this.TargetPremiums(this.callDict, this.cIV, (double)this.NoOfDays, this.callST7, "Call");
				this.pBuyEntry = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBE, "Put");
				this.pBT1 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT1, "Put");
				this.pBT2 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT2, "Put");
				this.pBT3 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT3, "Put");
				this.pBT4 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT4, "Put");
				this.pBT5 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT5, "Put");
				this.pBT6 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT6, "Put");
				this.pBT7 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putBT7, "Put");
				this.pSellEntry = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putSE, "Put");
				this.pST1 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST1, "Put");
				this.pST2 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST2, "Put");
				this.pST3 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST3, "Put");
				this.pST4 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST4, "Put");
				this.pST5 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST5, "Put");
				this.pST6 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST6, "Put");
				this.pST7 = this.TargetPremiums(this.putDict, this.pIV, (double)this.NoOfDays, this.putST7, "Put");
				optionsScannerMainClass.callTable = this.CreateTable(this.callBuyTargets, this.callSellTargets, this.callDict, this.cIV, this.cBuyEntry, this.cBT1, this.cBT2, this.cBT3, this.cBT4, this.cBT5, this.cBT6, this.cBT7, this.cSellEntry, this.cST1, this.cST2, this.cST3, this.cST4, this.cST5, this.cST6, this.cST7, "Call");
				optionsScannerMainClass.putTable = this.CreateTable(this.putBuyTargets, this.putSellTargets, this.putDict, this.pIV, this.pBuyEntry, this.pBT1, this.pBT2, this.pBT3, this.pBT4, this.pBT5, this.pBT6, this.pBT7, this.pSellEntry, this.pST1, this.pST2, this.pST3, this.pST4, this.pST5, this.pST6, this.pST7, "Put");
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0002A0D8 File Offset: 0x000282D8
		private DataTable CreateTable(List<double> BuyTargetList, List<double> SellTargetList, Dictionary<double, double> StrikesPremiumDict, Dictionary<double, double> ivDict, List<double> ListBuy, List<double> ListBT1, List<double> ListBT2, List<double> ListBT3, List<double> ListBT4, List<double> ListBT5, List<double> ListBT6, List<double> ListBT7, List<double> ListSell, List<double> ListST1, List<double> ListST2, List<double> ListST3, List<double> ListST4, List<double> ListST5, List<double> ListST6, List<double> ListST7, string OT)
		{
			this.dT1 = new DataTable();
			DataColumn dcUp = new DataColumn("Strike Price", typeof(string));
			DataColumn dcUp2 = new DataColumn("Premium", typeof(double));
			DataColumn dcUp3 = new DataColumn("IV", typeof(double));
			DataColumn dcUp4 = null;
			DataColumn dcUp5 = null;
			DataColumn dcUp6 = null;
			DataColumn dcUp7 = null;
			DataColumn dcUp8 = null;
			DataColumn dcUp9 = null;
			DataColumn dcUp10 = null;
			DataColumn dcUp11 = null;
			DataColumn dcUp12 = null;
			DataColumn dcUp13 = null;
			DataColumn dcUp14 = null;
			DataColumn dcUp15 = null;
			DataColumn dcUp16 = null;
			DataColumn dcUp17 = null;
			DataColumn dcUp18 = null;
			DataColumn dcUp19 = null;
			if (OT == "Call")
			{
				dcUp4 = new DataColumn("Buy Entry");
				dcUp5 = new DataColumn("Buy T1", typeof(double));
				dcUp6 = new DataColumn("Buy T2", typeof(double));
				dcUp7 = new DataColumn("Buy T3", typeof(double));
				dcUp8 = new DataColumn("Buy T4", typeof(double));
				dcUp9 = new DataColumn("Buy T5", typeof(double));
				dcUp10 = new DataColumn("Buy T6", typeof(double));
				dcUp11 = new DataColumn("Buy T7", typeof(double));
				dcUp12 = new DataColumn("Sell Entry", typeof(double));
				dcUp13 = new DataColumn("Sell T1", typeof(double));
				dcUp14 = new DataColumn("Sell T2", typeof(double));
				dcUp15 = new DataColumn("Sell T3", typeof(double));
				dcUp16 = new DataColumn("Sell T4", typeof(double));
				dcUp17 = new DataColumn("Sell T5", typeof(double));
				dcUp18 = new DataColumn("Sell T6", typeof(double));
				dcUp19 = new DataColumn("Sell T7", typeof(double));
			}
			else if (OT == "Put")
			{
				dcUp4 = new DataColumn("Sell Entry");
				dcUp5 = new DataColumn("Sell T1", typeof(double));
				dcUp6 = new DataColumn("Sell T2", typeof(double));
				dcUp7 = new DataColumn("Sell T3", typeof(double));
				dcUp8 = new DataColumn("Sell T4", typeof(double));
				dcUp9 = new DataColumn("Sell T5", typeof(double));
				dcUp10 = new DataColumn("Sell T6", typeof(double));
				dcUp11 = new DataColumn("Sell T7", typeof(double));
				dcUp12 = new DataColumn("Buy Entry", typeof(double));
				dcUp13 = new DataColumn("Buy T1", typeof(double));
				dcUp14 = new DataColumn("Buy T2", typeof(double));
				dcUp15 = new DataColumn("Buy T3", typeof(double));
				dcUp16 = new DataColumn("Buy T4", typeof(double));
				dcUp17 = new DataColumn("Buy T5", typeof(double));
				dcUp18 = new DataColumn("Buy T6", typeof(double));
				dcUp19 = new DataColumn("Buy T7", typeof(double));
			}
			this.dT1.Columns.Add(dcUp);
			this.dT1.Columns.Add(dcUp2);
			this.dT1.Columns.Add(dcUp3);
			this.dT1.Columns.Add(dcUp4);
			this.dT1.Columns.Add(dcUp5);
			this.dT1.Columns.Add(dcUp6);
			this.dT1.Columns.Add(dcUp7);
			this.dT1.Columns.Add(dcUp8);
			this.dT1.Columns.Add(dcUp9);
			this.dT1.Columns.Add(dcUp10);
			this.dT1.Columns.Add(dcUp11);
			this.dT1.Columns.Add(dcUp12);
			this.dT1.Columns.Add(dcUp13);
			this.dT1.Columns.Add(dcUp14);
			this.dT1.Columns.Add(dcUp15);
			this.dT1.Columns.Add(dcUp16);
			this.dT1.Columns.Add(dcUp17);
			this.dT1.Columns.Add(dcUp18);
			this.dT1.Columns.Add(dcUp19);
			int totalCount = StrikesPremiumDict.Count;
			for (int currentRow = 0; currentRow <= totalCount - 1; currentRow++)
			{
				KeyValuePair<double, double> itemStrikePremium = StrikesPremiumDict.ElementAt(currentRow);
				double keyStrike = itemStrikePremium.Key;
				double keyPremium = itemStrikePremium.Value;
				double value = ivDict.ElementAt(currentRow).Value;
				if (OT == "Call")
				{
					this.StrikePrice = Convert.ToString(keyStrike.ToString() + ".CE");
				}
				else if (OT == "Put")
				{
					this.StrikePrice = Convert.ToString(keyStrike.ToString() + ".PE");
				}
				double Premium = Convert.ToDouble(keyPremium);
				double tempIV = Convert.ToDouble(value);
				double indexBuyEntry = ListBuy.ElementAt(currentRow);
				double indexBT = ListBT1.ElementAt(currentRow);
				double indexBT2 = ListBT2.ElementAt(currentRow);
				double indexBT3 = ListBT3.ElementAt(currentRow);
				double indexBT4 = ListBT4.ElementAt(currentRow);
				double indexBT5 = ListBT5.ElementAt(currentRow);
				double indexBT6 = ListBT6.ElementAt(currentRow);
				double indexBT7 = ListBT7.ElementAt(currentRow);
				double indexSellEntry = ListSell.ElementAt(currentRow);
				double indexST = ListST1.ElementAt(currentRow);
				double indexST2 = ListST2.ElementAt(currentRow);
				double indexST3 = ListST3.ElementAt(currentRow);
				double indexST4 = ListST4.ElementAt(currentRow);
				double indexST5 = ListST5.ElementAt(currentRow);
				double indexST6 = ListST6.ElementAt(currentRow);
				double value2 = ListST7.ElementAt(currentRow);
				DataRow CreateNewRow = this.dT1.NewRow();
				this.dT1.Rows.Add(CreateNewRow);
				double IV = Math.Round(tempIV * 100.0, 3);
				double BuyEntry = Math.Round(indexBuyEntry, 2);
				double BT = Math.Round(indexBT, 2);
				double BT2 = Math.Round(indexBT2, 2);
				double BT3 = Math.Round(indexBT3, 2);
				double BT4 = Math.Round(indexBT4, 2);
				double BT5 = Math.Round(indexBT5, 2);
				double BT6 = Math.Round(indexBT6, 2);
				double BT7 = Math.Round(indexBT7, 2);
				double SellEntry = Math.Round(indexSellEntry, 2);
				double ST = Math.Round(indexST, 2);
				double ST2 = Math.Round(indexST2, 2);
				double ST3 = Math.Round(indexST3, 2);
				double ST4 = Math.Round(indexST4, 2);
				double ST5 = Math.Round(indexST5, 2);
				double ST6 = Math.Round(indexST6, 2);
				double ST7 = Math.Round(value2, 2);
				if (OT == "Call")
				{
					this.dT1.Rows[currentRow]["Strike Price"] = this.StrikePrice;
					this.dT1.Rows[currentRow]["Premium"] = Premium;
					this.dT1.Rows[currentRow]["IV"] = IV;
					this.dT1.Rows[currentRow]["Buy Entry"] = BuyEntry;
					this.dT1.Rows[currentRow]["Buy T1"] = BT;
					this.dT1.Rows[currentRow]["Buy T2"] = BT2;
					this.dT1.Rows[currentRow]["Buy T3"] = BT3;
					this.dT1.Rows[currentRow]["Buy T4"] = BT4;
					this.dT1.Rows[currentRow]["Buy T5"] = BT5;
					this.dT1.Rows[currentRow]["Buy T6"] = BT6;
					this.dT1.Rows[currentRow]["Buy T7"] = BT7;
					this.dT1.Rows[currentRow]["Sell Entry"] = SellEntry;
					this.dT1.Rows[currentRow]["Sell T1"] = ST;
					this.dT1.Rows[currentRow]["Sell T2"] = ST2;
					this.dT1.Rows[currentRow]["Sell T3"] = ST3;
					this.dT1.Rows[currentRow]["Sell T4"] = ST4;
					this.dT1.Rows[currentRow]["Sell T5"] = ST5;
					this.dT1.Rows[currentRow]["Sell T6"] = ST6;
					this.dT1.Rows[currentRow]["Sell T7"] = ST7;
				}
				else if (OT == "Put")
				{
					this.dT1.Rows[currentRow]["Strike Price"] = this.StrikePrice;
					this.dT1.Rows[currentRow]["Premium"] = Premium;
					this.dT1.Rows[currentRow]["IV"] = IV;
					this.dT1.Rows[currentRow]["Sell Entry"] = BuyEntry;
					this.dT1.Rows[currentRow]["Sell T1"] = BT;
					this.dT1.Rows[currentRow]["Sell T2"] = BT2;
					this.dT1.Rows[currentRow]["Sell T3"] = BT3;
					this.dT1.Rows[currentRow]["Sell T4"] = BT4;
					this.dT1.Rows[currentRow]["Sell T5"] = BT5;
					this.dT1.Rows[currentRow]["Sell T6"] = BT6;
					this.dT1.Rows[currentRow]["Sell T7"] = BT7;
					this.dT1.Rows[currentRow]["Buy Entry"] = SellEntry;
					this.dT1.Rows[currentRow]["Buy T1"] = ST;
					this.dT1.Rows[currentRow]["Buy T2"] = ST2;
					this.dT1.Rows[currentRow]["Buy T3"] = ST3;
					this.dT1.Rows[currentRow]["Buy T4"] = ST4;
					this.dT1.Rows[currentRow]["Buy T5"] = ST5;
					this.dT1.Rows[currentRow]["Buy T6"] = ST6;
					this.dT1.Rows[currentRow]["Buy T7"] = ST7;
				}
			}
			DataRow newRowObj = this.dT1.NewRow();
			this.dT1.Rows.InsertAt(newRowObj, 0);
			double TargetBuyEntry = Math.Round(BuyTargetList[0], 2);
			double BuyTarget = Math.Round(BuyTargetList[1], 2);
			double BuyTarget2 = Math.Round(BuyTargetList[2], 2);
			double BuyTarget3 = Math.Round(BuyTargetList[3], 2);
			double BuyTarget4 = Math.Round(BuyTargetList[4], 2);
			double BuyTarget5 = Math.Round(BuyTargetList[5], 2);
			double BuyTarget6 = Math.Round(BuyTargetList[6], 2);
			double BuyTarget7 = Math.Round(BuyTargetList[7], 2);
			double TargetSellEntry = Math.Round(SellTargetList[0], 2);
			double SellTarget = Math.Round(SellTargetList[1], 2);
			double SellTarget2 = Math.Round(SellTargetList[2], 2);
			double SellTarget3 = Math.Round(SellTargetList[3], 2);
			double SellTarget4 = Math.Round(SellTargetList[4], 2);
			double SellTarget5 = Math.Round(SellTargetList[5], 2);
			double SellTarget6 = Math.Round(SellTargetList[6], 2);
			double SellTarget7 = Math.Round(SellTargetList[7], 2);
			if (OT == "Call")
			{
				this.dT1.Rows[0]["Buy Entry"] = TargetBuyEntry;
				this.dT1.Rows[0]["Buy T1"] = BuyTarget;
				this.dT1.Rows[0]["Buy T2"] = BuyTarget2;
				this.dT1.Rows[0]["Buy T3"] = BuyTarget3;
				this.dT1.Rows[0]["Buy T4"] = BuyTarget4;
				this.dT1.Rows[0]["Buy T5"] = BuyTarget5;
				this.dT1.Rows[0]["Buy T6"] = BuyTarget6;
				this.dT1.Rows[0]["Buy T7"] = BuyTarget7;
				this.dT1.Rows[0]["Sell Entry"] = TargetSellEntry;
				this.dT1.Rows[0]["Sell T1"] = SellTarget;
				this.dT1.Rows[0]["Sell T2"] = SellTarget2;
				this.dT1.Rows[0]["Sell T3"] = SellTarget3;
				this.dT1.Rows[0]["Sell T4"] = SellTarget4;
				this.dT1.Rows[0]["Sell T5"] = SellTarget5;
				this.dT1.Rows[0]["Sell T6"] = SellTarget6;
				this.dT1.Rows[0]["Sell T7"] = SellTarget7;
			}
			else if (OT == "Put")
			{
				this.dT1.Rows[0]["Sell Entry"] = TargetBuyEntry;
				this.dT1.Rows[0]["Sell T1"] = BuyTarget;
				this.dT1.Rows[0]["Sell T2"] = BuyTarget2;
				this.dT1.Rows[0]["Sell T3"] = BuyTarget3;
				this.dT1.Rows[0]["Sell T4"] = BuyTarget4;
				this.dT1.Rows[0]["Sell T5"] = BuyTarget5;
				this.dT1.Rows[0]["Sell T6"] = BuyTarget6;
				this.dT1.Rows[0]["Sell T7"] = BuyTarget7;
				this.dT1.Rows[0]["Buy Entry"] = TargetSellEntry;
				this.dT1.Rows[0]["Buy T1"] = SellTarget;
				this.dT1.Rows[0]["Buy T2"] = SellTarget2;
				this.dT1.Rows[0]["Buy T3"] = SellTarget3;
				this.dT1.Rows[0]["Buy T4"] = SellTarget4;
				this.dT1.Rows[0]["Buy T5"] = SellTarget5;
				this.dT1.Rows[0]["Buy T6"] = SellTarget6;
				this.dT1.Rows[0]["Buy T7"] = SellTarget7;
			}
			if (OT == "Call")
			{
				this.optionScannerWindow.dataGrid1.DataContext = this.dT1;
				this.optionScannerWindow.dataGrid1.ItemsSource = this.dT1.DefaultView;
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[0]).Binding = new Binding("Strike Price");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[1]).Binding = new Binding("Premium");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[2]).Binding = new Binding("IV");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[3]).Binding = new Binding("Buy Entry");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[4]).Binding = new Binding("Buy T1");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[5]).Binding = new Binding("Buy T2");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[6]).Binding = new Binding("Buy T3");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[7]).Binding = new Binding("Buy T4");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[8]).Binding = new Binding("Buy T5");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[9]).Binding = new Binding("Buy T6");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[10]).Binding = new Binding("Buy T7");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[11]).Binding = new Binding("Sell Entry");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[12]).Binding = new Binding("Sell T1");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[13]).Binding = new Binding("Sell T2");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[14]).Binding = new Binding("Sell T3");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[15]).Binding = new Binding("Sell T4");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[16]).Binding = new Binding("Sell T5");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[17]).Binding = new Binding("Sell T6");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid1.Columns[18]).Binding = new Binding("Sell T7");
				this.optionScannerWindow.dataGrid1.ItemContainerGenerator.StatusChanged += delegate([Nullable(2)] object s, EventArgs e)
				{
					if (this.optionScannerWindow.dataGrid1.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
					{
						((DataGridRow)this.optionScannerWindow.dataGrid1.ItemContainerGenerator.ContainerFromIndex(0)).Background = Brushes.White;
					}
				};
			}
			else if (OT == "Put")
			{
				this.optionScannerWindow.dataGrid2.DataContext = this.dT1;
				this.optionScannerWindow.dataGrid2.ItemsSource = this.dT1.DefaultView;
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[0]).Binding = new Binding("Strike Price");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[1]).Binding = new Binding("Premium");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[2]).Binding = new Binding("IV");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[3]).Binding = new Binding("Sell Entry");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[4]).Binding = new Binding("Sell T1");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[5]).Binding = new Binding("Sell T2");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[6]).Binding = new Binding("Sell T3");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[7]).Binding = new Binding("Sell T4");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[8]).Binding = new Binding("Sell T5");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[9]).Binding = new Binding("Sell T6");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[10]).Binding = new Binding("Sell T7");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[11]).Binding = new Binding("Buy Entry");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[12]).Binding = new Binding("Buy T1");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[13]).Binding = new Binding("Buy T2");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[14]).Binding = new Binding("Buy T3");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[15]).Binding = new Binding("Buy T4");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[16]).Binding = new Binding("Buy T5");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[17]).Binding = new Binding("Buy T6");
				((DataGridTextColumn)this.optionScannerWindow.dataGrid2.Columns[18]).Binding = new Binding("Buy T7");
				this.optionScannerWindow.dataGrid2.ItemContainerGenerator.StatusChanged += delegate([Nullable(2)] object s, EventArgs e)
				{
					if (this.optionScannerWindow.dataGrid2.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
					{
						((DataGridRow)this.optionScannerWindow.dataGrid2.ItemContainerGenerator.ContainerFromIndex(0)).Background = Brushes.White;
					}
				};
			}
			return this.dT1;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000252 RID: 594 RVA: 0x0002B9A4 File Offset: 0x00029BA4
		public ICommand Analyse
		{
			get
			{
				if (this._Analyse == null)
				{
					this._Analyse = new DelegateCommand(delegate(object param)
					{
						this.CheckboxFucntion(param);
					});
				}
				return this._Analyse;
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0002B9CC File Offset: 0x00029BCC
		public void CheckboxFucntion(object O)
		{
			this.optionScannerWindow.trends.Visibility = Visibility.Visible;
			this.optionScannerWindow.conditionChosen.Content = string.Concat(new string[]
			{
				"'",
				optionsScannerView.optionType,
				optionsScannerView.condition,
				optionsScannerView.parameter,
				"'"
			});
			this.optionScannerWindow.analyse.Content = "Analysing...";
			bool? isChecked = this.optionScannerWindow.all.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				if (optionsScannerMainClass.callTable.Rows.Count != 0 && optionsScannerMainClass.putTable.Rows.Count == 0)
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				else if (optionsScannerMainClass.callTable.Rows.Count == 0 && optionsScannerMainClass.putTable.Rows.Count != 0)
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				else if (optionsScannerMainClass.callTable.Rows.Count == 0 && optionsScannerMainClass.putTable.Rows.Count == 0)
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " as per Options Scanner Principle", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
			}
			else
			{
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.lessthan.IsChecked;
						flag = false;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							isChecked = this.optionScannerWindow.between.IsChecked;
							flag = false;
							if (isChecked.GetValueOrDefault() == flag & isChecked != null)
							{
								isChecked = this.optionScannerWindow.ltp.IsChecked;
								flag = false;
								if (isChecked.GetValueOrDefault() == flag & isChecked != null)
								{
									isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
									flag = false;
									if (isChecked.GetValueOrDefault() == flag & isChecked != null)
									{
										isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
										flag = false;
										if (isChecked.GetValueOrDefault() == flag & isChecked != null)
										{
											isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
											flag = false;
											if (isChecked.GetValueOrDefault() == flag & isChecked != null)
											{
												isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
												flag = false;
												if (isChecked.GetValueOrDefault() == flag & isChecked != null)
												{
													isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
													flag = false;
													if (isChecked.GetValueOrDefault() == flag & isChecked != null)
													{
														isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
														flag = false;
														if (isChecked.GetValueOrDefault() == flag & isChecked != null)
														{
															isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
															flag = false;
															if (isChecked.GetValueOrDefault() == flag & isChecked != null)
															{
																isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
																flag = false;
																if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																{
																	isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
																	flag = false;
																	if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																	{
																		isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
																		flag = false;
																		if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																		{
																			if (optionsScannerMainClass.callTable.Rows.Count != 0)
																			{
																				this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
																				this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
																				this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
																			}
																			else
																			{
																				this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
																				MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
																			}
																			this.optionScannerWindow.analyse.Content = "Analyse";
																			goto IL_56AC;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.lessthan.IsChecked;
						flag = false;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							isChecked = this.optionScannerWindow.between.IsChecked;
							flag = false;
							if (isChecked.GetValueOrDefault() == flag & isChecked != null)
							{
								isChecked = this.optionScannerWindow.ltp.IsChecked;
								flag = false;
								if (isChecked.GetValueOrDefault() == flag & isChecked != null)
								{
									isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
									flag = false;
									if (isChecked.GetValueOrDefault() == flag & isChecked != null)
									{
										isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
										flag = false;
										if (isChecked.GetValueOrDefault() == flag & isChecked != null)
										{
											isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
											flag = false;
											if (isChecked.GetValueOrDefault() == flag & isChecked != null)
											{
												isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
												flag = false;
												if (isChecked.GetValueOrDefault() == flag & isChecked != null)
												{
													isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
													flag = false;
													if (isChecked.GetValueOrDefault() == flag & isChecked != null)
													{
														isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
														flag = false;
														if (isChecked.GetValueOrDefault() == flag & isChecked != null)
														{
															isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
															flag = false;
															if (isChecked.GetValueOrDefault() == flag & isChecked != null)
															{
																isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
																flag = false;
																if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																{
																	isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
																	flag = false;
																	if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																	{
																		isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
																		flag = false;
																		if (isChecked.GetValueOrDefault() == flag & isChecked != null)
																		{
																			if (optionsScannerMainClass.putTable.Rows.Count != 0)
																			{
																				this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
																				this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
																				this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
																			}
																			else
																			{
																				this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
																				this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
																				MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
																			}
																			this.optionScannerWindow.analyse.Content = "Analyse";
																			goto IL_56AC;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.ltp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							Dictionary<double, double> _filteredStrikesNPremium = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.callDict, this.currentLTP, "GreaterThan");
							Dictionary<double, double> _filteredIV = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.cIV, this.currentLTP, "GreaterThan");
							if (optionsScannerMainClass.callTable.Rows.Count != 0)
							{
								List<double> _BuyEntry = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBE, "Call");
								List<double> _BuyT = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT1, "Call");
								List<double> _BuyT2 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT2, "Call");
								List<double> _BuyT3 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT3, "Call");
								List<double> _BuyT4 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT4, "Call");
								List<double> _BuyT5 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT5, "Call");
								List<double> _BuyT6 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT6, "Call");
								List<double> _BuyT7 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callBT7, "Call");
								List<double> _SellEntry = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callSE, "Call");
								List<double> _SellT = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST1, "Call");
								List<double> _SellT2 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST2, "Call");
								List<double> _SellT3 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST3, "Call");
								List<double> _SellT4 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST4, "Call");
								List<double> _SellT5 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST5, "Call");
								List<double> _SellT6 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST6, "Call");
								List<double> _SellT7 = this.TargetPremiums(_filteredStrikesNPremium, _filteredIV, (double)this.NoOfDays, this.callST7, "Call");
								DataTable strikesIVbyGreaterthanLTPTable = this.CreateTable(this.callBuyTargets, this.callSellTargets, _filteredStrikesNPremium, _filteredIV, _BuyEntry, _BuyT, _BuyT2, _BuyT3, _BuyT4, _BuyT5, _BuyT6, _BuyT7, _SellEntry, _SellT, _SellT2, _SellT3, _SellT4, _SellT5, _SellT6, _SellT7, "Call");
								this.optionScannerWindow.dataGrid1.ItemsSource = strikesIVbyGreaterthanLTPTable.DefaultView;
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
							}
							else
							{
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
								MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
							}
							this.optionScannerWindow.analyse.Content = "Analyse";
							goto IL_56AC;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.ltp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							Dictionary<double, double> _filteredStrikesNPremium2 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.putDict, this.currentLTP, "GreaterThan");
							Dictionary<double, double> _filteredIV2 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.pIV, this.currentLTP, "GreaterThan");
							if (optionsScannerMainClass.putTable.Rows.Count != 0)
							{
								List<double> _BuyEntry2 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBE, "Put");
								List<double> _BuyT8 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT1, "Put");
								List<double> _BuyT9 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT2, "Put");
								List<double> _BuyT10 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT3, "Put");
								List<double> _BuyT11 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT4, "Put");
								List<double> _BuyT12 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT5, "Put");
								List<double> _BuyT13 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT6, "Put");
								List<double> _BuyT14 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putBT7, "Put");
								List<double> _SellEntry2 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putSE, "Put");
								List<double> _SellT8 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST1, "Put");
								List<double> _SellT9 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST2, "Put");
								List<double> _SellT10 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST3, "Put");
								List<double> _SellT11 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST4, "Put");
								List<double> _SellT12 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST5, "Put");
								List<double> _SellT13 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST6, "Put");
								List<double> _SellT14 = this.TargetPremiums(_filteredStrikesNPremium2, _filteredIV2, (double)this.NoOfDays, this.putST7, "Put");
								DataTable strikesIVbyGreaterthanLTPTable2 = this.CreateTable(this.putBuyTargets, this.putSellTargets, _filteredStrikesNPremium2, _filteredIV2, _BuyEntry2, _BuyT8, _BuyT9, _BuyT10, _BuyT11, _BuyT12, _BuyT13, _BuyT14, _SellEntry2, _SellT8, _SellT9, _SellT10, _SellT11, _SellT12, _SellT13, _SellT14, "Put");
								this.optionScannerWindow.dataGrid2.ItemsSource = strikesIVbyGreaterthanLTPTable2.DefaultView;
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
							}
							else
							{
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
								MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
							}
							this.optionScannerWindow.analyse.Content = "Analyse";
							goto IL_56AC;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.ltp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							Dictionary<double, double> _filteredStrikesNPremium3 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.callDict, this.currentLTP, "LesserThan");
							Dictionary<double, double> _filteredIV3 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.cIV, this.currentLTP, "LesserThan");
							if (optionsScannerMainClass.callTable.Rows.Count != 0)
							{
								List<double> _BuyEntry3 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBE, "Call");
								List<double> _BuyT15 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT1, "Call");
								List<double> _BuyT16 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT2, "Call");
								List<double> _BuyT17 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT3, "Call");
								List<double> _BuyT18 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT4, "Call");
								List<double> _BuyT19 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT5, "Call");
								List<double> _BuyT20 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT6, "Call");
								List<double> _BuyT21 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callBT7, "Call");
								List<double> _SellEntry3 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callSE, "Call");
								List<double> _SellT15 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST1, "Call");
								List<double> _SellT16 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST2, "Call");
								List<double> _SellT17 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST3, "Call");
								List<double> _SellT18 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST4, "Call");
								List<double> _SellT19 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST5, "Call");
								List<double> _SellT20 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST6, "Call");
								List<double> _SellT21 = this.TargetPremiums(_filteredStrikesNPremium3, _filteredIV3, (double)this.NoOfDays, this.callST7, "Call");
								DataTable strikesIVbyLesserThanLTPTable = this.CreateTable(this.callBuyTargets, this.callSellTargets, _filteredStrikesNPremium3, _filteredIV3, _BuyEntry3, _BuyT15, _BuyT16, _BuyT17, _BuyT18, _BuyT19, _BuyT20, _BuyT21, _SellEntry3, _SellT15, _SellT16, _SellT17, _SellT18, _SellT19, _SellT20, _SellT21, "Call");
								this.optionScannerWindow.dataGrid1.ItemsSource = strikesIVbyLesserThanLTPTable.DefaultView;
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
							}
							else
							{
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
								MessageBox.Show("There is no tradable strikes in" + this.optionScannerWindow.autoCText.Text + "Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
							}
							this.optionScannerWindow.analyse.Content = "Analyse";
							goto IL_56AC;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.ltp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							Dictionary<double, double> _filteredStrikesNPremium4 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.putDict, this.currentLTP, "LesserThan");
							Dictionary<double, double> _filteredIV4 = optionsScannerConditionClass.filterStrikesPremiumOrIVbyLTP(this.pIV, this.currentLTP, "LesserThan");
							if (optionsScannerMainClass.putTable.Rows.Count != 0)
							{
								List<double> _BuyEntry4 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBE, "Put");
								List<double> _BuyT22 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT1, "Put");
								List<double> _BuyT23 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT2, "Put");
								List<double> _BuyT24 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT3, "Put");
								List<double> _BuyT25 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT4, "Put");
								List<double> _BuyT26 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT5, "Put");
								List<double> _BuyT27 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT6, "Put");
								List<double> _BuyT28 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putBT7, "Put");
								List<double> _SellEntry4 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putSE, "Put");
								List<double> _SellT22 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST1, "Put");
								List<double> _SellT23 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST2, "Put");
								List<double> _SellT24 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST3, "Put");
								List<double> _SellT25 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST4, "Put");
								List<double> _SellT26 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST5, "Put");
								List<double> _SellT27 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST6, "Put");
								List<double> _SellT28 = this.TargetPremiums(_filteredStrikesNPremium4, _filteredIV4, (double)this.NoOfDays, this.putST7, "Put");
								DataTable strikesIVbyLesserThanLTPTable2 = this.CreateTable(this.putBuyTargets, this.putSellTargets, _filteredStrikesNPremium4, _filteredIV4, _BuyEntry4, _BuyT22, _BuyT23, _BuyT24, _BuyT25, _BuyT26, _BuyT27, _BuyT28, _SellEntry4, _SellT22, _SellT23, _SellT24, _SellT25, _SellT26, _SellT27, _SellT28, "Put");
								this.optionScannerWindow.dataGrid2.ItemsSource = strikesIVbyLesserThanLTPTable2.DefaultView;
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
							}
							else
							{
								this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
								this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
								MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
							}
							this.optionScannerWindow.analyse.Content = "Analyse";
							goto IL_56AC;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_195A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_195A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_1E97;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_1E97;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_23D4;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_23D4;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_2911;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_2911;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_2E7E;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_2E7E;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_341E;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_341E;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_39BE;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_39BE;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_3FCD;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_3FCD;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_4C9A;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						goto IL_4EB8;
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = false;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
						flag = true;
						if (isChecked.GetValueOrDefault() == flag & isChecked != null)
						{
							goto IL_5673;
						}
					}
				}
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				if (!(isChecked.GetValueOrDefault() == flag & isChecked != null))
				{
					goto IL_56AC;
				}
				isChecked = this.optionScannerWindow.between.IsChecked;
				flag = false;
				if (!(isChecked.GetValueOrDefault() == flag & isChecked != null))
				{
					goto IL_56AC;
				}
				isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
				flag = true;
				if (!(isChecked.GetValueOrDefault() == flag & isChecked != null))
				{
					goto IL_56AC;
				}
				IL_5673:
				this.optionScannerWindow.trends.Visibility = Visibility.Collapsed;
				this.optionScannerWindow.analyse.Content = "Analyse";
				MessageBox.Show("Choose the Condition", "INVALID SELECTION", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
				goto IL_56AC;
				IL_4EB8:
				this.optionScannerWindow.trends.Visibility = Visibility.Collapsed;
				this.optionScannerWindow.analyse.Content = "Analyse";
				MessageBox.Show("Choose the Parameter", "INVALID SELECTION", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
				goto IL_56AC;
				IL_4C9A:
				this.optionScannerWindow.trends.Visibility = Visibility.Collapsed;
				this.optionScannerWindow.analyse.Content = "Analyse";
				MessageBox.Show("Choose the appropriate OPTION TYPE Parameter", "INVALID SELECTION", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
				goto IL_56AC;
				IL_3FCD:
				Dictionary<double, double> _filteredStrikesDict = new Dictionary<double, double>();
				Dictionary<double, double> _IV = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag2;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Buy_Down.IsChecked;
						flag = true;
						flag2 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_4051;
					}
				}
				flag2 = false;
				IL_4051:
				bool BuyDownTrend = flag2;
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag3;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWP_Sell_Up.IsChecked;
						flag = true;
						flag3 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_40C9;
					}
				}
				flag3 = false;
				IL_40C9:
				bool SellUpTrend = flag3;
				if (optionsScannerMainClass.putTable.Rows.Count != 0)
				{
					double putWeekPriceRange = optionsScannerfMathCls.priceRange(this.pIVpricerange, this.underlyingPrice, 7);
					List<double> putWeekBuyTargets = this.TargetsCalc(this.refPrice, putWeekPriceRange, 7);
					List<double> putWeekSellTargets = this.TargetsCalc(this.refPrice, putWeekPriceRange, -7);
					double putWeekBE = putWeekBuyTargets[0];
					double putWeekBT = putWeekBuyTargets[1];
					double putWeekBT2 = putWeekBuyTargets[2];
					double putWeekBT3 = putWeekBuyTargets[3];
					double putWeekBT4 = putWeekBuyTargets[4];
					double putWeekBT5 = putWeekBuyTargets[5];
					double putWeekBT6 = putWeekBuyTargets[6];
					double putWeekBT7 = putWeekBuyTargets[7];
					double putWeekSE = putWeekSellTargets[0];
					double putWeekST = putWeekSellTargets[1];
					double putWeekST2 = putWeekSellTargets[2];
					double putWeekST3 = putWeekSellTargets[3];
					double putWeekST4 = putWeekSellTargets[4];
					double putWeekST5 = putWeekSellTargets[5];
					double putWeekST6 = putWeekSellTargets[6];
					double putWeekST7 = putWeekSellTargets[7];
					if (BuyDownTrend)
					{
						_filteredStrikesDict = optionsScannerConditionClass.FilterPutWeeklyStrikesBetweenTargetPrices(this.putDict, putWeekSE, putWeekST7, "Buy");
						_IV = optionsScannerConditionClass.FilterPutWeeklyStrikesBetweenTargetPrices(this.pIV, putWeekSE, putWeekST7, "Buy");
					}
					else if (SellUpTrend)
					{
						_filteredStrikesDict = optionsScannerConditionClass.FilterPutWeeklyStrikesBetweenTargetPrices(this.putDict, putWeekBE, putWeekBT7, "Sell");
						_IV = optionsScannerConditionClass.FilterPutWeeklyStrikesBetweenTargetPrices(this.pIV, putWeekBE, putWeekBT7, "Sell");
					}
					List<double> pWeekBuyEntry = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBE, "Put");
					List<double> pWeekBT = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT, "Put");
					List<double> pWeekBT2 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT2, "Put");
					List<double> pWeekBT3 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT3, "Put");
					List<double> pWeekBT4 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT4, "Put");
					List<double> pWeekBT5 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT5, "Put");
					List<double> pWeekBT6 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT6, "Put");
					List<double> pWeekBT7 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekBT7, "Put");
					List<double> pWeekSellEntry = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekSE, "Put");
					List<double> pWeekST = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST, "Put");
					List<double> pWeekST2 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST2, "Put");
					List<double> pWeekST3 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST3, "Put");
					List<double> pWeekST4 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST4, "Put");
					List<double> pWeekST5 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST5, "Put");
					List<double> pWeekST6 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST6, "Put");
					List<double> pWeekST7 = this.TargetPremiums(_filteredStrikesDict, _IV, (double)this.NoOfDays, putWeekST7, "Put");
					DataTable putBestWeeklyTrends = this.CreateTable(putWeekBuyTargets, putWeekSellTargets, _filteredStrikesDict, _IV, pWeekBuyEntry, pWeekBT, pWeekBT2, pWeekBT3, pWeekBT4, pWeekBT5, pWeekBT6, pWeekBT7, pWeekSellEntry, pWeekST, pWeekST2, pWeekST3, pWeekST4, pWeekST5, pWeekST6, pWeekST7, "Put");
					this.optionScannerWindow.dataGrid2.ItemsSource = putBestWeeklyTrends.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_39BE:
				Dictionary<double, double> _filteredStrikesDict2 = new Dictionary<double, double>();
				Dictionary<double, double> _IV2 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag4;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Buy_Up.IsChecked;
						flag = true;
						flag4 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_3A42;
					}
				}
				flag4 = false;
				IL_3A42:
				bool BuyUpTrend = flag4;
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag5;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BestWC_Sell_Down.IsChecked;
						flag = true;
						flag5 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_3ABA;
					}
				}
				flag5 = false;
				IL_3ABA:
				bool SellDownTrend = flag5;
				if (optionsScannerMainClass.callTable.Rows.Count != 0)
				{
					double callWeekPriceRange = optionsScannerfMathCls.priceRange(this.cIVpricerange, this.underlyingPrice, 7);
					List<double> callWeekBuyTargets = this.TargetsCalc(this.refPrice, callWeekPriceRange, 7);
					List<double> callWeekSellTargets = this.TargetsCalc(this.refPrice, callWeekPriceRange, -7);
					double callWeekBE = callWeekBuyTargets[0];
					double callWeekBT = callWeekBuyTargets[1];
					double callWeekBT2 = callWeekBuyTargets[2];
					double callWeekBT3 = callWeekBuyTargets[3];
					double callWeekBT4 = callWeekBuyTargets[4];
					double callWeekBT5 = callWeekBuyTargets[5];
					double callWeekBT6 = callWeekBuyTargets[6];
					double callWeekBT7 = callWeekBuyTargets[7];
					double callWeekSE = callWeekSellTargets[0];
					double callWeekST = callWeekSellTargets[1];
					double callWeekST2 = callWeekSellTargets[2];
					double callWeekST3 = callWeekSellTargets[3];
					double callWeekST4 = callWeekSellTargets[4];
					double callWeekST5 = callWeekSellTargets[5];
					double callWeekST6 = callWeekSellTargets[6];
					double callWeekST7 = callWeekSellTargets[7];
					if (BuyUpTrend)
					{
						_filteredStrikesDict2 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.callDict, callWeekBE, callWeekBT7, "Buy", "Call");
						_IV2 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.cIV, callWeekBE, callWeekBT7, "Buy", "Call");
					}
					else if (SellDownTrend)
					{
						_filteredStrikesDict2 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.callDict, callWeekSE, callWeekST7, "Sell", "Call");
						_IV2 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.cIV, callWeekSE, callWeekST7, "Sell", "Call");
					}
					List<double> cWeekBuyEntry = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBE, "Call");
					List<double> cWeekBT = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT, "Call");
					List<double> cWeekBT2 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT2, "Call");
					List<double> cWeekBT3 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT3, "Call");
					List<double> cWeekBT4 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT4, "Call");
					List<double> cWeekBT5 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT5, "Call");
					List<double> cWeekBT6 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT6, "Call");
					List<double> cWeekBT7 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekBT7, "Call");
					List<double> cWeekSellEntry = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekSE, "Call");
					List<double> cWeekST = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST, "Call");
					List<double> cWeekST2 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST2, "Call");
					List<double> cWeekST3 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST3, "Call");
					List<double> cWeekST4 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST4, "Call");
					List<double> cWeekST5 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST5, "Call");
					List<double> cWeekST6 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST6, "Call");
					List<double> cWeekST7 = this.TargetPremiums(_filteredStrikesDict2, _IV2, (double)this.NoOfDays, callWeekST7, "Call");
					DataTable CallBestWeeklyTrends = this.CreateTable(callWeekBuyTargets, callWeekSellTargets, _filteredStrikesDict2, _IV2, cWeekBuyEntry, cWeekBT, cWeekBT2, cWeekBT3, cWeekBT4, cWeekBT5, cWeekBT6, cWeekBT7, cWeekSellEntry, cWeekST, cWeekST2, cWeekST3, cWeekST4, cWeekST5, cWeekST6, cWeekST7, "Call");
					this.optionScannerWindow.dataGrid1.ItemsSource = CallBestWeeklyTrends.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_341E:
				Dictionary<double, double> _filteredStrikesDict3 = new Dictionary<double, double>();
				Dictionary<double, double> _IV3 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag6;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						flag6 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_34A2;
					}
				}
				flag6 = false;
				IL_34A2:
				bool putBetweenBuyTargets = flag6;
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag7;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						flag7 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_351A;
					}
				}
				flag7 = false;
				IL_351A:
				bool putBetweenSellTargets = flag7;
				if (optionsScannerMainClass.putTable.Rows.Count != 0)
				{
					if (putBetweenBuyTargets)
					{
						_filteredStrikesDict3 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.putDict, this.putBE, this.putBT7, "Buy", "Put");
						_IV3 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.pIV, this.putBE, this.putBT7, "Buy", "Put");
					}
					else if (putBetweenSellTargets)
					{
						_filteredStrikesDict3 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.putDict, this.putSE, this.putST7, "Sell", "Put");
						_IV3 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.pIV, this.putSE, this.putST7, "Sell", "Put");
					}
					List<double> BuyEntry = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBE, "Put");
					List<double> BT = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT1, "Put");
					List<double> BT2 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT2, "Put");
					List<double> BT3 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT3, "Put");
					List<double> BT4 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT4, "Put");
					List<double> BT5 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT5, "Put");
					List<double> BT6 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT6, "Put");
					List<double> BT7 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putBT7, "Put");
					List<double> SellEntry = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putSE, "Put");
					List<double> ST = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST1, "Put");
					List<double> ST2 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST2, "Put");
					List<double> ST3 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST3, "Put");
					List<double> ST4 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST4, "Put");
					List<double> ST5 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST5, "Put");
					List<double> ST6 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST6, "Put");
					List<double> ST7 = this.TargetPremiums(_filteredStrikesDict3, _IV3, (double)this.NoOfDays, this.putST7, "Put");
					DataTable putStikesBWBuytgtsTable = this.CreateTable(this.putBuyTargets, this.putSellTargets, _filteredStrikesDict3, _IV3, BuyEntry, BT, BT2, BT3, BT4, BT5, BT6, BT7, SellEntry, ST, ST2, ST3, ST4, ST5, ST6, ST7, "Put");
					this.optionScannerWindow.dataGrid2.ItemsSource = putStikesBWBuytgtsTable.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_2E7E:
				Dictionary<double, double> _filteredStrikesDict4 = new Dictionary<double, double>();
				Dictionary<double, double> _IV4 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag8;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_BE_Tgts.IsChecked;
						flag = true;
						flag8 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_2F02;
					}
				}
				flag8 = false;
				IL_2F02:
				bool callBetweenBuyTargets = flag8;
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag9;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.between.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.BW_SE_Tgts.IsChecked;
						flag = true;
						flag9 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_2F7A;
					}
				}
				flag9 = false;
				IL_2F7A:
				bool callBetweenSellTargets = flag9;
				if (optionsScannerMainClass.callTable.Rows.Count != 0)
				{
					if (callBetweenBuyTargets)
					{
						_filteredStrikesDict4 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.callDict, this.callBE, this.callBT7, "Buy", "Call");
						_IV4 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.cIV, this.callBE, this.callBT7, "Buy", "Call");
					}
					else if (callBetweenSellTargets)
					{
						_filteredStrikesDict4 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.callDict, this.callSE, this.callST7, "Sell", "Call");
						_IV4 = optionsScannerConditionClass.FilterStrikesBetweenTargetPrices(this.cIV, this.callSE, this.callST7, "Sell", "Call");
					}
					List<double> BuyEntry2 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBE, "Call");
					List<double> BT8 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT1, "Call");
					List<double> BT9 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT2, "Call");
					List<double> BT10 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT3, "Call");
					List<double> BT11 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT4, "Call");
					List<double> BT12 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT5, "Call");
					List<double> BT13 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT6, "Call");
					List<double> BT14 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callBT7, "Call");
					List<double> SellEntry2 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callSE, "Call");
					List<double> ST8 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST1, "Call");
					List<double> ST9 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST2, "Call");
					List<double> ST10 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST3, "Call");
					List<double> ST11 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST4, "Call");
					List<double> ST12 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST5, "Call");
					List<double> ST13 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST6, "Call");
					List<double> ST14 = this.TargetPremiums(_filteredStrikesDict4, _IV4, (double)this.NoOfDays, this.callST7, "Call");
					DataTable callStikesBWBuytgtsTable = this.CreateTable(this.callBuyTargets, this.callSellTargets, _filteredStrikesDict4, _IV4, BuyEntry2, BT8, BT9, BT10, BT11, BT12, BT13, BT14, SellEntry2, ST8, ST9, ST10, ST11, ST12, ST13, ST14, "Call");
					this.optionScannerWindow.dataGrid1.ItemsSource = callStikesBWBuytgtsTable.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_2911:
				Dictionary<double, double> _filterStrikesinUpOrDown = new Dictionary<double, double>();
				Dictionary<double, double> _IV5 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag10;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						flag10 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_2995;
					}
				}
				flag10 = false;
				IL_2995:
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag11;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						flag11 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_2A0B;
					}
				}
				flag11 = false;
				IL_2A0B:
				bool _putSellinUpLesserthan = flag11;
				if (flag10 || _putSellinUpLesserthan)
				{
					_filterStrikesinUpOrDown = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.putDict, this.currentLTP, "Lesserthan");
					_IV5 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.pIV, this.currentLTP, "Lesserthan");
				}
				if (optionsScannerMainClass.putTable.Rows.Count != 0)
				{
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBE, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT1, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT2, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT3, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT4, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT5, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT6, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putBT7, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putSE, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST1, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST2, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST3, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST4, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST5, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST6, "Put");
					this.TargetPremiums(_filterStrikesinUpOrDown, _IV5, (double)this.NoOfDays, this.putST7, "Put");
					DataTable PstrikesIVbyLesserthanUpDown = this.CreateTable(this.putBuyTargets, this.putSellTargets, _filterStrikesinUpOrDown, _IV5, this.pBuyEntry, this.pBT1, this.pBT2, this.pBT3, this.pBT4, this.pBT5, this.pBT6, this.pBT7, this.pSellEntry, this.pST1, this.pST2, this.pST3, this.pST4, this.pST5, this.pST6, this.pST7, "Put");
					this.optionScannerWindow.dataGrid2.ItemsSource = PstrikesIVbyLesserthanUpDown.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_23D4:
				Dictionary<double, double> _filterStrikesinUpOrDown2 = new Dictionary<double, double>();
				Dictionary<double, double> _IV6 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag12;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						flag12 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_2458;
					}
				}
				flag12 = false;
				IL_2458:
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag13;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.lessthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						flag13 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_24CE;
					}
				}
				flag13 = false;
				IL_24CE:
				bool _callSellinDownLesser = flag13;
				if (flag12 || _callSellinDownLesser)
				{
					_filterStrikesinUpOrDown2 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.callDict, this.currentLTP, "Lesserthan");
					_IV6 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.cIV, this.currentLTP, "Lesserthan");
				}
				if (optionsScannerMainClass.callTable.Rows.Count != 0)
				{
					List<double> _BuyEntry5 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBE, "Call");
					List<double> _BuyT29 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT1, "Call");
					List<double> _BuyT30 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT2, "Call");
					List<double> _BuyT31 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT3, "Call");
					List<double> _BuyT32 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT4, "Call");
					List<double> _BuyT33 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT5, "Call");
					List<double> _BuyT34 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT6, "Call");
					List<double> _BuyT35 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callBT7, "Call");
					List<double> _SellEntry5 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callSE, "Call");
					List<double> _SellT29 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST1, "Call");
					List<double> _SellT30 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST2, "Call");
					List<double> _SellT31 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST3, "Call");
					List<double> _SellT32 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST4, "Call");
					List<double> _SellT33 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST5, "Call");
					List<double> _SellT34 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST6, "Call");
					List<double> _SellT35 = this.TargetPremiums(_filterStrikesinUpOrDown2, _IV6, (double)this.NoOfDays, this.callST7, "Call");
					DataTable CstrikesIVbyLesserthanUpDown = this.CreateTable(this.callBuyTargets, this.callSellTargets, _filterStrikesinUpOrDown2, _IV6, _BuyEntry5, _BuyT29, _BuyT30, _BuyT31, _BuyT32, _BuyT33, _BuyT34, _BuyT35, _SellEntry5, _SellT29, _SellT30, _SellT31, _SellT32, _SellT33, _SellT34, _SellT35, "Call");
					this.optionScannerWindow.dataGrid1.ItemsSource = CstrikesIVbyLesserthanUpDown.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_1E97:
				Dictionary<double, double> _filterStrikesinUpOrDown3 = new Dictionary<double, double>();
				Dictionary<double, double> _IV7 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag14;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pBuyinDown.IsChecked;
						flag = true;
						flag14 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_1F1B;
					}
				}
				flag14 = false;
				IL_1F1B:
				isChecked = this.optionScannerWindow.put.IsChecked;
				flag = true;
				bool flag15;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.pSellinUp.IsChecked;
						flag = true;
						flag15 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_1F91;
					}
				}
				flag15 = false;
				IL_1F91:
				bool _putSellinUpGreaterthan = flag15;
				if (flag14 || _putSellinUpGreaterthan)
				{
					_filterStrikesinUpOrDown3 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.putDict, this.currentLTP, "Greaterthan");
					_IV7 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.pIV, this.currentLTP, "Greaterthan");
				}
				if (optionsScannerMainClass.putTable.Rows.Count != 0)
				{
					List<double> _BuyEntry6 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBE, "Put");
					List<double> _BuyT36 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT1, "Put");
					List<double> _BuyT37 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT2, "Put");
					List<double> _BuyT38 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT3, "Put");
					List<double> _BuyT39 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT4, "Put");
					List<double> _BuyT40 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT5, "Put");
					List<double> _BuyT41 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT6, "Put");
					List<double> _BuyT42 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putBT7, "Put");
					List<double> _SellEntry6 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putSE, "Put");
					List<double> _SellT36 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST1, "Put");
					List<double> _SellT37 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST2, "Put");
					List<double> _SellT38 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST3, "Put");
					List<double> _SellT39 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST4, "Put");
					List<double> _SellT40 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST5, "Put");
					List<double> _SellT41 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST6, "Put");
					List<double> _SellT42 = this.TargetPremiums(_filterStrikesinUpOrDown3, _IV7, (double)this.NoOfDays, this.putST7, "Put");
					DataTable PstrikesIVbyGreaterthanUpDown = this.CreateTable(this.putBuyTargets, this.putSellTargets, _filterStrikesinUpOrDown3, _IV7, _BuyEntry6, _BuyT36, _BuyT37, _BuyT38, _BuyT39, _BuyT40, _BuyT41, _BuyT42, _SellEntry6, _SellT36, _SellT37, _SellT38, _SellT39, _SellT40, _SellT41, _SellT42, "Put");
					this.optionScannerWindow.dataGrid2.ItemsSource = PstrikesIVbyGreaterthanUpDown.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Put Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
				goto IL_56AC;
				IL_195A:
				Dictionary<double, double> _filterStrikesinUpOrDown4 = new Dictionary<double, double>();
				Dictionary<double, double> _IV8 = new Dictionary<double, double>();
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag16;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cBuyinUp.IsChecked;
						flag = true;
						flag16 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_19DE;
					}
				}
				flag16 = false;
				IL_19DE:
				isChecked = this.optionScannerWindow.call.IsChecked;
				flag = true;
				bool flag17;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					isChecked = this.optionScannerWindow.greaterthan.IsChecked;
					flag = true;
					if (isChecked.GetValueOrDefault() == flag & isChecked != null)
					{
						isChecked = this.optionScannerWindow.cSellinDown.IsChecked;
						flag = true;
						flag17 = (isChecked.GetValueOrDefault() == flag & isChecked != null);
						goto IL_1A54;
					}
				}
				flag17 = false;
				IL_1A54:
				bool _callSellinDownGreater = flag17;
				if (flag16 || _callSellinDownGreater)
				{
					_filterStrikesinUpOrDown4 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.callDict, this.currentLTP, "Greaterthan");
					_IV8 = optionsScannerConditionClass.filterStrikesPremiumOrIVinUpAndDowntrend(this.cIV, this.currentLTP, "Greaterthan");
				}
				if (optionsScannerMainClass.callTable.Rows.Count != 0)
				{
					List<double> _BuyEntry7 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBE, "Call");
					List<double> _BuyT43 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT1, "Call");
					List<double> _BuyT44 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT2, "Call");
					List<double> _BuyT45 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT3, "Call");
					List<double> _BuyT46 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT4, "Call");
					List<double> _BuyT47 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT5, "Call");
					List<double> _BuyT48 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT6, "Call");
					List<double> _BuyT49 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callBT7, "Call");
					List<double> _SellEntry7 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callSE, "Call");
					List<double> _SellT43 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST1, "Call");
					List<double> _SellT44 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST2, "Call");
					List<double> _SellT45 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST3, "Call");
					List<double> _SellT46 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST4, "Call");
					List<double> _SellT47 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST5, "Call");
					List<double> _SellT48 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST6, "Call");
					List<double> _SellT49 = this.TargetPremiums(_filterStrikesinUpOrDown4, _IV8, (double)this.NoOfDays, this.callST7, "Call");
					DataTable CstrikesIVbyGreaterthanUpDown = this.CreateTable(this.callBuyTargets, this.callSellTargets, _filterStrikesinUpOrDown4, _IV8, _BuyEntry7, _BuyT43, _BuyT44, _BuyT45, _BuyT46, _BuyT47, _BuyT48, _BuyT49, _SellEntry7, _SellT43, _SellT44, _SellT45, _SellT46, _SellT47, _SellT48, _SellT49, "Call");
					this.optionScannerWindow.dataGrid1.ItemsSource = CstrikesIVbyGreaterthanUpDown.DefaultView;
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Visible;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.optionScannerWindow.callTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTableLabel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.callTablePanel.Visibility = Visibility.Collapsed;
					this.optionScannerWindow.putTablePanel.Visibility = Visibility.Collapsed;
					MessageBox.Show("There is no tradable strikes in " + this.optionScannerWindow.autoCText.Text + " Call Option right now", "Options Scanner Data", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				this.optionScannerWindow.analyse.Content = "Analyse";
			}
			IL_56AC:
			this.optionScannerWindow.analyse.IsEnabled = false;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00031096 File Offset: 0x0002F296
		public ICommand IV_Rank
		{
			get
			{
				if (this._Analyse == null)
				{
					this._Analyse = new DelegateCommand(delegate(object param)
					{
						this.findIVrank(param);
					});
				}
				return this._Analyse;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000310BD File Offset: 0x0002F2BD
		public void findIVrank(object O)
		{
			new Dictionary<double, double>();
			Dictionary<double, double> dictionary = this.cIV;
			this.IV = optionsScannerfMathCls.ImpliedVolatility(4.0, this.NoOfDays, this.underlyingPrice, 444.0, "Call");
		}

		// Token: 0x04000568 RID: 1384
		private optionsScannerView optionScannerWindow = Application.Current.Windows.Cast<Window>().FirstOrDefault((Window window) => window is optionsScannerView) as optionsScannerView;

		// Token: 0x04000569 RID: 1385
		private ObservableCollection<string> _symbols;

		// Token: 0x0400056A RID: 1386
		private ObservableCollection<string> _expiryDates;

		// Token: 0x0400056B RID: 1387
		private readonly string STOCKFUTUREPATH = "https://smartfinance.in/symbols/STK.txt";

		// Token: 0x0400056C RID: 1388
		private readonly string INDEXPATH = "https://smartfinance.in/symbols/IDX.txt";

		// Token: 0x0400056D RID: 1389
		private string _selectedInstrument;

		// Token: 0x0400056E RID: 1390
		private string _selectedEDate;

		// Token: 0x0400056F RID: 1391
		private string _displayedSymbol;

		// Token: 0x04000570 RID: 1392
		private readonly string EXPIRYURL = "https://smartfinance.in/expiry/";

		// Token: 0x04000571 RID: 1393
		private int _selected_expiry_index;

		// Token: 0x04000572 RID: 1394
		private ObservableCollection<string> _expiry_weekly;

		// Token: 0x04000573 RID: 1395
		private string _currentMonthExpiryy_weekly = string.Empty;

		// Token: 0x04000574 RID: 1396
		private DataTable dT;

		// Token: 0x04000575 RID: 1397
		private DataTable dT1;

		// Token: 0x04000576 RID: 1398
		public Dictionary<string, string> _TradedCallStrike;

		// Token: 0x04000577 RID: 1399
		public Dictionary<string, string> _TradedPutStrike;

		// Token: 0x04000578 RID: 1400
		public Dictionary<string, string> _cOI_Strikes;

		// Token: 0x04000579 RID: 1401
		public Dictionary<string, string> _pOI_Strikes;

		// Token: 0x0400057A RID: 1402
		public static Dictionary<string, string> filertered_cOI_Strikes;

		// Token: 0x0400057B RID: 1403
		public static Dictionary<string, string> filertered_pOI_Strikes;

		// Token: 0x0400057C RID: 1404
		public static Dictionary<string, string> filertered_cOI_Strikes_weekly;

		// Token: 0x0400057D RID: 1405
		public static Dictionary<string, string> filertered_pOI_Strikes_weekly;

		// Token: 0x0400057E RID: 1406
		private FnOHelperCls fnOobj = new FnOHelperCls();

		// Token: 0x0400057F RID: 1407
		private LiveMarketQuoteCls getCurrentLTP = new LiveMarketQuoteCls();

		// Token: 0x04000580 RID: 1408
		private ICommand _LoadOptionsData;

		// Token: 0x04000581 RID: 1409
		private ICommand _Analyse;

		// Token: 0x04000582 RID: 1410
		private Dictionary<double, double> callDict = new Dictionary<double, double>();

		// Token: 0x04000583 RID: 1411
		private Dictionary<double, double> putDict = new Dictionary<double, double>();

		// Token: 0x04000584 RID: 1412
		private Dictionary<double, double> cIV = new Dictionary<double, double>();

		// Token: 0x04000585 RID: 1413
		private Dictionary<double, double> pIV = new Dictionary<double, double>();

		// Token: 0x04000586 RID: 1414
		private List<double> callBuyTargets = new List<double>();

		// Token: 0x04000587 RID: 1415
		private List<double> callSellTargets = new List<double>();

		// Token: 0x04000588 RID: 1416
		private List<double> putBuyTargets = new List<double>();

		// Token: 0x04000589 RID: 1417
		private List<double> putSellTargets = new List<double>();

		// Token: 0x0400058A RID: 1418
		private List<double> cBuyEntry = new List<double>();

		// Token: 0x0400058B RID: 1419
		private List<double> cBT1 = new List<double>();

		// Token: 0x0400058C RID: 1420
		private List<double> cBT2 = new List<double>();

		// Token: 0x0400058D RID: 1421
		private List<double> cBT3 = new List<double>();

		// Token: 0x0400058E RID: 1422
		private List<double> cBT4 = new List<double>();

		// Token: 0x0400058F RID: 1423
		private List<double> cBT5 = new List<double>();

		// Token: 0x04000590 RID: 1424
		private List<double> cBT6 = new List<double>();

		// Token: 0x04000591 RID: 1425
		private List<double> cBT7 = new List<double>();

		// Token: 0x04000592 RID: 1426
		private List<double> cSellEntry = new List<double>();

		// Token: 0x04000593 RID: 1427
		private List<double> cST1 = new List<double>();

		// Token: 0x04000594 RID: 1428
		private List<double> cST2 = new List<double>();

		// Token: 0x04000595 RID: 1429
		private List<double> cST3 = new List<double>();

		// Token: 0x04000596 RID: 1430
		private List<double> cST4 = new List<double>();

		// Token: 0x04000597 RID: 1431
		private List<double> cST5 = new List<double>();

		// Token: 0x04000598 RID: 1432
		private List<double> cST6 = new List<double>();

		// Token: 0x04000599 RID: 1433
		private List<double> cST7 = new List<double>();

		// Token: 0x0400059A RID: 1434
		private List<double> pBuyEntry = new List<double>();

		// Token: 0x0400059B RID: 1435
		private List<double> pBT1 = new List<double>();

		// Token: 0x0400059C RID: 1436
		private List<double> pBT2 = new List<double>();

		// Token: 0x0400059D RID: 1437
		private List<double> pBT3 = new List<double>();

		// Token: 0x0400059E RID: 1438
		private List<double> pBT4 = new List<double>();

		// Token: 0x0400059F RID: 1439
		private List<double> pBT5 = new List<double>();

		// Token: 0x040005A0 RID: 1440
		private List<double> pBT6 = new List<double>();

		// Token: 0x040005A1 RID: 1441
		private List<double> pBT7 = new List<double>();

		// Token: 0x040005A2 RID: 1442
		private List<double> pSellEntry = new List<double>();

		// Token: 0x040005A3 RID: 1443
		private List<double> pST1 = new List<double>();

		// Token: 0x040005A4 RID: 1444
		private List<double> pST2 = new List<double>();

		// Token: 0x040005A5 RID: 1445
		private List<double> pST3 = new List<double>();

		// Token: 0x040005A6 RID: 1446
		private List<double> pST4 = new List<double>();

		// Token: 0x040005A7 RID: 1447
		private List<double> pST5 = new List<double>();

		// Token: 0x040005A8 RID: 1448
		private List<double> pST6 = new List<double>();

		// Token: 0x040005A9 RID: 1449
		private List<double> pST7 = new List<double>();

		// Token: 0x040005AA RID: 1450
		private double refPrice;

		// Token: 0x040005AB RID: 1451
		private double currentLTP;

		// Token: 0x040005AC RID: 1452
		private double prevDayLTP;

		// Token: 0x040005AD RID: 1453
		private double openPrice;

		// Token: 0x040005AE RID: 1454
		private double underlyingPrice;

		// Token: 0x040005AF RID: 1455
		private double IV;

		// Token: 0x040005B0 RID: 1456
		private double cIVpricerange;

		// Token: 0x040005B1 RID: 1457
		private double cPriceRange;

		// Token: 0x040005B2 RID: 1458
		private double pIVpricerange;

		// Token: 0x040005B3 RID: 1459
		private double pPriceRange;

		// Token: 0x040005B4 RID: 1460
		private double priceDifference;

		// Token: 0x040005B5 RID: 1461
		private double callBE;

		// Token: 0x040005B6 RID: 1462
		private double callBT1;

		// Token: 0x040005B7 RID: 1463
		private double callBT2;

		// Token: 0x040005B8 RID: 1464
		private double callBT3;

		// Token: 0x040005B9 RID: 1465
		private double callBT4;

		// Token: 0x040005BA RID: 1466
		private double callBT5;

		// Token: 0x040005BB RID: 1467
		private double callBT6;

		// Token: 0x040005BC RID: 1468
		private double callBT7;

		// Token: 0x040005BD RID: 1469
		private double callSE;

		// Token: 0x040005BE RID: 1470
		private double callST1;

		// Token: 0x040005BF RID: 1471
		private double callST2;

		// Token: 0x040005C0 RID: 1472
		private double callST3;

		// Token: 0x040005C1 RID: 1473
		private double callST4;

		// Token: 0x040005C2 RID: 1474
		private double callST5;

		// Token: 0x040005C3 RID: 1475
		private double callST6;

		// Token: 0x040005C4 RID: 1476
		private double callST7;

		// Token: 0x040005C5 RID: 1477
		private double putBE;

		// Token: 0x040005C6 RID: 1478
		private double putBT1;

		// Token: 0x040005C7 RID: 1479
		private double putBT2;

		// Token: 0x040005C8 RID: 1480
		private double putBT3;

		// Token: 0x040005C9 RID: 1481
		private double putBT4;

		// Token: 0x040005CA RID: 1482
		private double putBT5;

		// Token: 0x040005CB RID: 1483
		private double putBT6;

		// Token: 0x040005CC RID: 1484
		private double putBT7;

		// Token: 0x040005CD RID: 1485
		private double putSE;

		// Token: 0x040005CE RID: 1486
		private double putST1;

		// Token: 0x040005CF RID: 1487
		private double putST2;

		// Token: 0x040005D0 RID: 1488
		private double putST3;

		// Token: 0x040005D1 RID: 1489
		private double putST4;

		// Token: 0x040005D2 RID: 1490
		private double putST5;

		// Token: 0x040005D3 RID: 1491
		private double putST6;

		// Token: 0x040005D4 RID: 1492
		private double putST7;

		// Token: 0x040005D5 RID: 1493
		private int NoOfDays;

		// Token: 0x040005D6 RID: 1494
		private string StrikePrice;

		// Token: 0x040005D7 RID: 1495
		public static DataTable callTable = new DataTable();

		// Token: 0x040005D8 RID: 1496
		public static DataTable putTable = new DataTable();
	}
}
