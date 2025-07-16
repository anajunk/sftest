using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace New_SF_IT.OotionScanner
{
	// Token: 0x0200002C RID: 44
	[NullableContext(1)]
	[Nullable(0)]
	internal class optionsScannerConditionClass
	{
		// Token: 0x06000233 RID: 563 RVA: 0x00027EF8 File Offset: 0x000260F8
		public static Dictionary<double, double> filterStrikesPremiumOrIVinUpAndDowntrend(Dictionary<double, double> _Strikes, double CLTP, string GreaterOrLesser)
		{
			int count = _Strikes.Count;
			Dictionary<double, double> dict = new Dictionary<double, double>();
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<double, double> item = _Strikes.ElementAt(currentRow);
				double key = item.Key;
				double value = item.Value;
				double Strike = Convert.ToDouble(key);
				double PremiumOrIV = Convert.ToDouble(value);
				if (GreaterOrLesser == "Greaterthan" && Strike >= CLTP && dict.Count <= 4)
				{
					dict.Add(Strike, PremiumOrIV);
				}
				if (GreaterOrLesser == "Lesserthan" && Strike <= CLTP && dict.Count <= 4)
				{
					dict.Add(Strike, PremiumOrIV);
				}
			}
			return dict;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00027F94 File Offset: 0x00026194
		public static Dictionary<double, double> FilterStrikesBetweenTargetPrices(Dictionary<double, double> _StrikeDict, double _BuyOrSellEntryTargetPrice, double _Target7, string BuyOrSell, string CallorPut)
		{
			Dictionary<double, double> filteredStrikesDict = new Dictionary<double, double>();
			int count = _StrikeDict.Count;
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<double, double> item = _StrikeDict.ElementAt(currentRow);
				double key = item.Key;
				double Value = item.Value;
				double Strike = Convert.ToDouble(key);
				double PremiumOrIV = Convert.ToDouble(Value);
				if (CallorPut == "Call")
				{
					if (BuyOrSell == "Buy")
					{
						if (Strike >= _BuyOrSellEntryTargetPrice && Strike <= _Target7)
						{
							filteredStrikesDict.Add(Strike, PremiumOrIV);
						}
					}
					else if (BuyOrSell == "Sell" && Strike <= _BuyOrSellEntryTargetPrice && Strike >= _Target7)
					{
						filteredStrikesDict.Add(Strike, PremiumOrIV);
					}
				}
				else if (CallorPut == "Put")
				{
					if (BuyOrSell == "Sell")
					{
						if (Strike <= _BuyOrSellEntryTargetPrice && Strike >= _Target7)
						{
							filteredStrikesDict.Add(Strike, PremiumOrIV);
						}
					}
					else if (BuyOrSell == "Buy" && Strike >= _BuyOrSellEntryTargetPrice && Strike <= _Target7)
					{
						filteredStrikesDict.Add(Strike, PremiumOrIV);
					}
				}
			}
			return filteredStrikesDict;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00028098 File Offset: 0x00026298
		public static Dictionary<double, double> FilterPutWeeklyStrikesBetweenTargetPrices(Dictionary<double, double> _StrikeDict, double _BuyOrSellEntryTargetPrice, double _Target7, string BuyOrSell)
		{
			Dictionary<double, double> filteredStrikesDict = new Dictionary<double, double>();
			int count = _StrikeDict.Count;
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<double, double> item = _StrikeDict.ElementAt(currentRow);
				double key = item.Key;
				double Value = item.Value;
				double Strike = Convert.ToDouble(key);
				double PremiumOrIV = Convert.ToDouble(Value);
				if (BuyOrSell == "Buy")
				{
					if (Strike <= _BuyOrSellEntryTargetPrice && Strike >= _Target7)
					{
						filteredStrikesDict.Add(Strike, PremiumOrIV);
					}
				}
				else if (BuyOrSell == "Sell" && Strike >= _BuyOrSellEntryTargetPrice && Strike <= _Target7)
				{
					filteredStrikesDict.Add(Strike, PremiumOrIV);
				}
			}
			return filteredStrikesDict;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00028130 File Offset: 0x00026330
		public static Dictionary<double, double> filterStrikesPremiumOrIVbyLTP(Dictionary<double, double> _Strikes, double CLP, string Keyword)
		{
			int count = _Strikes.Count;
			Dictionary<double, double> dict = new Dictionary<double, double>();
			for (int currentRow = 0; currentRow <= count - 1; currentRow++)
			{
				KeyValuePair<double, double> item = _Strikes.ElementAt(currentRow);
				double key = item.Key;
				double Value = item.Value;
				double Strike = Convert.ToDouble(key);
				double PremiumOrIV = Convert.ToDouble(Value);
				if (Keyword == "GreaterThan")
				{
					if (Strike >= CLP)
					{
						dict.Add(Strike, PremiumOrIV);
					}
				}
				else if (Keyword == "LesserThan" && Strike <= CLP)
				{
					dict.Add(Strike, PremiumOrIV);
				}
			}
			return dict;
		}
	}
}
