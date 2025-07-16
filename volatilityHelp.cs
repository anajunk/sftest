using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace New_SF_IT
{
	// Token: 0x0200000E RID: 14
	[NullableContext(1)]
	[Nullable(0)]
	internal class volatilityHelp
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00005A90 File Offset: 0x00003C90
		public static double get_Volatility(List<double> ltp, int anumber)
		{
			double sumY = 0.0;
			double sumX = 0.0;
			int numberOfLtp = ltp.Count - anumber;
			for (int ltpindex = 0; ltpindex < numberOfLtp; ltpindex++)
			{
				double valueX = Math.Log(Convert.ToDouble(ltp[ltpindex + 1]) / Convert.ToDouble(ltp[ltpindex]));
				double valueY = valueX * valueX;
				sumX += valueX;
				sumY += valueY;
			}
			double avgX = sumX / (double)numberOfLtp;
			double SumSQRT = Math.Sqrt(sumY / (double)numberOfLtp - Math.Pow(avgX, 2.0));
			if (SumSQRT >= 75.0 && SumSQRT < 100.0)
			{
				SumSQRT /= 3.0;
			}
			else if (SumSQRT >= 100.0)
			{
				SumSQRT /= 5.0;
			}
			return SumSQRT;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005B70 File Offset: 0x00003D70
		public static double get_PriceRange(List<double> _allLTP, double _liveLTP, double _volatility, int _days2Hold)
		{
			return 0.0;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00005B7C File Offset: 0x00003D7C
		public static double get_buyEntry(List<double> _allLTP, double d, double _volatility, double LTP)
		{
			double valPriceRange;
			double tempPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility;
				tempPriceRange = volatilityHelp.get_tempPriceRange(valPriceRange, d);
				return LTP + tempPriceRange * d;
			}
			_volatility = volatilityHelp.get_Volatility(_allLTP, 2) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 2);
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2];
			double x = _allLTP[_allLTP.Count - 2] + d * valPriceRange;
			double y = _allLTP[_allLTP.Count - 2] - d * valPriceRange;
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				_volatility = volatilityHelp.get_Volatility(_allLTP, 1) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 1);
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1];
				tempPriceRange = volatilityHelp.get_tempPriceRange(valPriceRange, d);
				return _allLTP[_allLTP.Count - 1] + tempPriceRange * d;
			}
			tempPriceRange = volatilityHelp.get_tempPriceRange(valPriceRange, d);
			return _allLTP[_allLTP.Count - 2] + tempPriceRange * d;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005C7A File Offset: 0x00003E7A
		private static double get_tempPriceRange(double valPriceRange, double d)
		{
			return Math.Pow(Math.Sqrt(valPriceRange) + d, 2.0);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005C94 File Offset: 0x00003E94
		public static double get_sellEntry(List<double> _allLTP, double d, double _volatility, double LTP)
		{
			double valPriceRange;
			double tempPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility;
				tempPriceRange = volatilityHelp.get_tempPriceRange(valPriceRange, d);
				return LTP - tempPriceRange * d;
			}
			_volatility = volatilityHelp.get_Volatility(_allLTP, 2) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 2);
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2];
			double x = _allLTP[_allLTP.Count - 2] + d * valPriceRange;
			double y = _allLTP[_allLTP.Count - 2] - d * valPriceRange;
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				_volatility = volatilityHelp.get_Volatility(_allLTP, 1) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 1);
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1];
				tempPriceRange = Math.Pow(Math.Sqrt(valPriceRange) - d, 2.0);
				return _allLTP[_allLTP.Count - 1] - d * tempPriceRange;
			}
			tempPriceRange = Math.Pow(Math.Sqrt(valPriceRange) - d, 2.0);
			return _allLTP[_allLTP.Count - 2] - d * tempPriceRange;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00005DB0 File Offset: 0x00003FB0
		public static double get_IntradayPriceRange(List<double> _allLTP, double _volatility, double _liveLTP)
		{
			int totalLTPCount = _allLTP.Count;
			double tempPriceRange;
			if (totalLTPCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				double num = volatilityHelp.get_Volatility(_allLTP, 1);
				_volatility = volatilityHelp.get_Volatility(_allLTP, 1) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 1);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 1]);
			}
			return tempPriceRange;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00005E10 File Offset: 0x00004010
		public static double calculate_trigger(List<double> _allLtp, double _d, double _volatility, double _LTP)
		{
			if (_allLtp.Count != 11)
			{
				return _LTP;
			}
			_volatility = volatilityHelp.get_Volatility(_allLtp, 2) + 0.0125 * volatilityHelp.get_Volatility(_allLtp, 2);
			double valPriceRange = _volatility * _allLtp[_allLtp.Count - 2];
			double x = _allLtp[_allLtp.Count - 2] + _d * valPriceRange;
			double y = _allLtp[_allLtp.Count - 2] - _d * valPriceRange;
			if (_allLtp[_allLtp.Count - 1] > x || _allLtp[_allLtp.Count - 1] < y)
			{
				return _allLtp[_allLtp.Count - 1];
			}
			return _allLtp[_allLtp.Count - 2];
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00005EBC File Offset: 0x000040BC
		public static double get_BuyPositionaltarget(List<double> _allLtp, double HoldingDays, double TargetCell, double _volatility, double _LTP)
		{
			if (_allLtp.Count == 11)
			{
				double priceRange = _LTP * _volatility * Math.Sqrt(HoldingDays);
				return Math.Round(_LTP + TargetCell * (priceRange / 81.0), 3);
			}
			return 0.0;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005F0C File Offset: 0x0000410C
		public static double get_SellPositionaltarget(List<double> _allLtp, double HoldingDays, double TargetCell, double _volatility, double _LTP)
		{
			if (_allLtp.Count == 11)
			{
				double priceRange = _LTP * _volatility * Math.Sqrt(HoldingDays);
				return Math.Round(_LTP - TargetCell * (priceRange / 81.0), 3);
			}
			return 0.0;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005F5C File Offset: 0x0000415C
		internal static double get_buyEntryPostional(List<double> _allLTP, int _HoldingDays, double _volatility, double _LTP)
		{
			double valPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = _LTP * _volatility * Math.Sqrt((double)_HoldingDays);
				return _LTP + 25.0 * (valPriceRange / 81.0);
			}
			double pastVolatility = volatilityHelp.get_Volatility(_allLTP, 2);
			double currentVolatility = volatilityHelp.get_Volatility(_allLTP, 1);
			if (pastVolatility > currentVolatility)
			{
				_volatility = pastVolatility + 0.0125 * pastVolatility;
			}
			else
			{
				_volatility = currentVolatility + 0.0125 * currentVolatility;
			}
			double x = _allLTP[_allLTP.Count - 2] + 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			double y = _allLTP[_allLTP.Count - 2] - 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1] * Math.Sqrt((double)_HoldingDays);
				return _allLTP[_allLTP.Count - 1] + 25.0 * (valPriceRange / 81.0);
			}
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2] * Math.Sqrt((double)_HoldingDays);
			return _allLTP[_allLTP.Count - 2] + 25.0 * (valPriceRange / 81.0);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000060C0 File Offset: 0x000042C0
		internal static double get_sellEntryPositional(List<double> _allLTP, int DAYS2Hold, double _volatility, double LTP)
		{
			double valPriceRange;
			if (_allLTP.Count != 11)
			{
				valPriceRange = LTP * _volatility * Math.Sqrt((double)DAYS2Hold);
				return LTP - 25.0 * (valPriceRange / 81.0);
			}
			double pastVolatility = volatilityHelp.get_Volatility(_allLTP, 2);
			double currentVolatility = volatilityHelp.get_Volatility(_allLTP, 1);
			if (pastVolatility > currentVolatility)
			{
				_volatility = pastVolatility + 0.0125 * pastVolatility;
			}
			else
			{
				_volatility = currentVolatility + 0.0125 * currentVolatility;
			}
			double x = _allLTP[_allLTP.Count - 2] + 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			double y = _allLTP[_allLTP.Count - 2] - 0.236 * _volatility * _allLTP[_allLTP.Count - 2];
			if (_allLTP[_allLTP.Count - 1] > x || _allLTP[_allLTP.Count - 1] < y)
			{
				valPriceRange = _volatility * _allLTP[_allLTP.Count - 1] * Math.Sqrt((double)DAYS2Hold);
				return _allLTP[_allLTP.Count - 1] - 25.0 * (valPriceRange / 81.0);
			}
			valPriceRange = _volatility * _allLTP[_allLTP.Count - 2] * Math.Sqrt((double)DAYS2Hold);
			return _allLTP[_allLTP.Count - 2] - 25.0 * (valPriceRange / 81.0);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006224 File Offset: 0x00004424
		internal static double get_PositionalPriceRange(List<double> _allLTP, int DAYS2Hold, double _volatility, double _liveLTP)
		{
			int totalLTPCount = _allLTP.Count;
			double tempPriceRange;
			if (totalLTPCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				_volatility = volatilityHelp.get_Volatility(_allLTP, 2) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 2);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 2]) * Math.Sqrt((double)DAYS2Hold);
				double x = Convert.ToDouble(_allLTP[totalLTPCount - 2]) + 0.236 * tempPriceRange;
				double y = Convert.ToDouble(_allLTP[totalLTPCount - 2]) - 0.236 * tempPriceRange;
				if (Convert.ToDouble(_allLTP[totalLTPCount - 1]) > x || Convert.ToDouble(_allLTP[totalLTPCount - 1]) < y)
				{
					_volatility = volatilityHelp.get_Volatility(_allLTP, 1) + 0.0125 * volatilityHelp.get_Volatility(_allLTP, 1);
					tempPriceRange = _volatility * Convert.ToDouble(_allLTP[totalLTPCount - 1]) * Math.Sqrt((double)DAYS2Hold);
				}
			}
			return tempPriceRange;
		}
	}
}
