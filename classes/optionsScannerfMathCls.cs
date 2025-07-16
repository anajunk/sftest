using System;
using System.Runtime.CompilerServices;

namespace New_SF_IT.classes
{
	// Token: 0x0200004F RID: 79
	[NullableContext(1)]
	[Nullable(0)]
	public class optionsScannerfMathCls
	{
		// Token: 0x060003B5 RID: 949 RVA: 0x0007A1BC File Offset: 0x000783BC
		public static double ImpliedVolatility(double _currentOptPremium, int _days_left, double _LTFutureStrike, double _StrikeChoosen, string _OT)
		{
			if (double.IsNaN(_currentOptPremium))
			{
				return 0.0;
			}
			decimal currentOptPremium = Convert.ToDecimal(_currentOptPremium);
			decimal StrikeChoosen = Convert.ToDecimal(_StrikeChoosen);
			decimal LTFutureStrike = Convert.ToDecimal(_LTFutureStrike);
			decimal days_left = _days_left;
			decimal interestRate = 0.10m;
			decimal TempVola = 1m;
			try
			{
				if (_LTFutureStrike == 0.0 || _days_left == 0 || _StrikeChoosen == 0.0 || _currentOptPremium == 0.0)
				{
					return 0.0;
				}
				if (_OT == "Call")
				{
					decimal CalculatedPremium;
					do
					{
						decimal dValueA = optionsScannerfMathCls.get_dValueX(LTFutureStrike, StrikeChoosen, TempVola, days_left, interestRate);
						decimal dValueB = optionsScannerfMathCls.get_dValueY(dValueA, TempVola, days_left);
						CalculatedPremium = optionsScannerfMathCls.get_CallPremium(LTFutureStrike, dValueA, dValueB, StrikeChoosen, interestRate, days_left);
						decimal newDvalueForVega = optionsScannerfMathCls.get_NewDvalueA(dValueA);
						decimal tempVega = optionsScannerfMathCls.get_Vega(LTFutureStrike, days_left, newDvalueForVega);
						decimal differenceBetweenPremium = (CalculatedPremium - currentOptPremium) / tempVega;
						TempVola -= differenceBetweenPremium;
					}
					while (CalculatedPremium - currentOptPremium >= 0.05m);
				}
				else if (_OT == "Put")
				{
					decimal putdiff;
					do
					{
						decimal dValueA = optionsScannerfMathCls.get_dValueX(LTFutureStrike, StrikeChoosen, TempVola, days_left, interestRate);
						decimal dValueB = optionsScannerfMathCls.get_dValueY(dValueA, TempVola, days_left);
						decimal CalculatedPremium = optionsScannerfMathCls.get_PutPremium(LTFutureStrike, dValueA, dValueB, StrikeChoosen, interestRate, days_left);
						decimal newDvalueForVega = optionsScannerfMathCls.get_NewDvalueA(dValueA);
						decimal tempVega = optionsScannerfMathCls.get_Vega(LTFutureStrike, days_left, newDvalueForVega);
						decimal differenceBetweenPremium = (CalculatedPremium - currentOptPremium) / tempVega;
						TempVola -= differenceBetweenPremium;
						putdiff = CalculatedPremium - currentOptPremium;
					}
					while (putdiff >= 0.05m);
				}
				if (TempVola < 0m || TempVola > 1m)
				{
					TempVola = 0m;
				}
			}
			catch (Exception)
			{
				TempVola = 0m;
				return Convert.ToDouble(TempVola);
			}
			return Convert.ToDouble(TempVola);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0007A3B0 File Offset: 0x000785B0
		public static decimal get_dValueX(decimal LTFutureStrike, decimal StrikeChoosen, decimal _volatility, decimal days_left, decimal interestRate)
		{
			return (Convert.ToDecimal(Math.Log(Convert.ToDouble(LTFutureStrike / StrikeChoosen))) + (_volatility * _volatility / 2m + 0.10m) * (days_left / 365m)) / (_volatility * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m))));
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0007A439 File Offset: 0x00078639
		public static decimal get_dValueY(decimal valueA, decimal volatility, decimal days_left)
		{
			return valueA - volatility * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m)));
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0007A468 File Offset: 0x00078668
		private static decimal get_CallPremium(decimal LTFutureStrike, decimal d1, decimal d2, decimal StrikeChoosen, decimal interestRate, decimal days_left)
		{
			decimal normalDis_d = optionsScannerfMathCls.NormalDistribution(d1);
			decimal normalDis_d2 = optionsScannerfMathCls.NormalDistribution(d2);
			decimal timeANDrate = Convert.ToDecimal(Math.Exp(Convert.ToDouble(interestRate * (days_left / 365m) * -1m)));
			LTFutureStrike * normalDis_d - StrikeChoosen * timeANDrate * normalDis_d2;
			return LTFutureStrike * normalDis_d - StrikeChoosen * timeANDrate * normalDis_d2;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0007A4E8 File Offset: 0x000786E8
		private static decimal get_PutPremium(decimal LTFutureStrike, decimal dValueA, decimal dValueB, decimal StrikeChoosen, decimal interestRate, decimal days_left)
		{
			return StrikeChoosen * ((decimal)Math.Exp((double)(interestRate * (days_left / 365m) * -1m)) * optionsScannerfMathCls.NormalDistribution(dValueB * -1m)) - LTFutureStrike * optionsScannerfMathCls.NormalDistribution(dValueA * -1m);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0007A55D File Offset: 0x0007875D
		private static decimal get_NewDvalueA(decimal dValueA)
		{
			return Convert.ToDecimal(Math.Exp(Convert.ToDouble(dValueA * dValueA) * -1.0 / 2.0) * 0.398862018);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0007A593 File Offset: 0x00078793
		private static decimal get_Vega(decimal LTFutureStrike, decimal days_left, decimal newDvalueForVega)
		{
			return LTFutureStrike * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m))) * newDvalueForVega;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0007A5C0 File Offset: 0x000787C0
		public static decimal NormalDistribution(decimal number)
		{
			decimal sign = 1m;
			if (number < 0m)
			{
				sign = -1m;
			}
			return 0.5m * (1m + sign * optionsScannerfMathCls.ErrorFactor(Math.Abs(number) / (decimal)Math.Sqrt(2.0)));
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0007A628 File Offset: 0x00078828
		public static decimal ErrorFactor(decimal number)
		{
			decimal A = 0.254829592m;
			decimal A2 = -0.284496736m;
			decimal A3 = 1.421413741m;
			decimal A4 = -1.453152027m;
			decimal A5 = 1.061405429m;
			decimal pak = 0.3275911m;
			number = Math.Abs(number);
			decimal temp = 1m / (1m + pak * number);
			return 1m - ((((A5 * temp + A4) * temp + A3) * temp + A2) * temp + A) * (temp * (decimal)Math.Exp((double)(1m * (number * number) * -1m)));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0007A738 File Offset: 0x00078938
		public static double calculate_NormalDistribution(double number)
		{
			double result;
			try
			{
				double signature = 1.0;
				if (number < 0.0)
				{
					signature = -1.0;
				}
				result = 0.5 * (1.0 + signature * optionsScannerfMathCls.get_ErrorFactor(Math.Abs(number) / Math.Sqrt(2.0)));
			}
			catch (Exception)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0007A7B8 File Offset: 0x000789B8
		private static double get_ErrorFactor(double numberFromNormalDis)
		{
			double arbit = 0.254829592;
			double arbit2 = -0.284496736;
			double arbit3 = 1.421413741;
			double arbit4 = -1.453152027;
			double arbit5 = 1.061405429;
			double pricision = 0.3275911;
			numberFromNormalDis = Math.Abs(numberFromNormalDis);
			double factor = 1.0 / (1.0 + pricision * numberFromNormalDis);
			return 1.0 - ((((arbit5 * factor + arbit4) * factor + arbit3) * factor + arbit2) * factor + arbit) * (factor * Math.Exp(1.0 * (numberFromNormalDis * numberFromNormalDis) * -1.0));
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0007A868 File Offset: 0x00078A68
		public static double premium(double d1, double d2, double StrikeChoosen, double currentMprice, double _days_expiry, string _optionType)
		{
			double tempPremium = 0.0;
			double normalDisA = optionsScannerfMathCls.calculate_NormalDistribution(d1);
			double normalDisB = optionsScannerfMathCls.calculate_NormalDistribution(d2);
			double normalDisC = optionsScannerfMathCls.calculate_NormalDistribution(-d1);
			double normalDisD = optionsScannerfMathCls.calculate_NormalDistribution(-d2);
			double yearly = _days_expiry / 365.0;
			double expValue = Math.Exp(-0.1 * yearly);
			if (_optionType == "Call")
			{
				tempPremium = currentMprice * normalDisA - StrikeChoosen * normalDisB * expValue;
			}
			else if (_optionType == "Put")
			{
				tempPremium = StrikeChoosen * normalDisD * expValue - currentMprice * normalDisC;
			}
			return tempPremium;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0007A8F6 File Offset: 0x00078AF6
		public static double priceRange(double _IV, double _currentLTP, int enteredHoldDays)
		{
			return _currentLTP * _IV / (Math.Sqrt(365.0) * Math.Sqrt((double)enteredHoldDays));
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0007A912 File Offset: 0x00078B12
		public static double buyOrsell(double _refPrice, double _PriceRange, double _ratio, int _PlusOneOrMinusOne)
		{
			return _refPrice + _PriceRange * _ratio * (double)_PlusOneOrMinusOne;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0007A91C File Offset: 0x00078B1C
		public static int GetDaysLeft4Expiry(string _expiry)
		{
			if (!string.IsNullOrWhiteSpace(_expiry))
			{
				DateTime expiryDate = DateTime.Parse(_expiry);
				DateTime todayDate = DateTime.Now;
				DateTime date = expiryDate.Date;
				DateTime tDate = todayDate.Date;
				return (date - tDate).Days + 1;
			}
			return 0;
		}
	}
}
