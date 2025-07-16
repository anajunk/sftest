using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Win32;
using New_SF_IT.OptionMonth;

namespace New_SF_IT.classes
{
	// Token: 0x0200004D RID: 77
	[NullableContext(1)]
	[Nullable(0)]
	public class Comman
	{
		// Token: 0x06000385 RID: 901 RVA: 0x000784F3 File Offset: 0x000766F3
		public static Version get_softwareVersion()
		{
			return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0007850E File Offset: 0x0007670E
		internal static bool IsInternetAvailable()
		{
			return NetworkInterface.GetIsNetworkAvailable();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0007851C File Offset: 0x0007671C
		public static string get_Website(string newUrl)
		{
			string downloadedresponse = string.Empty;
			if (Comman.IsInternetAvailable())
			{
				try
				{
					ServicePointManager.Expect100Continue = true;
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					WebClient webClient = new WebClient();
					webClient.Proxy = null;
					webClient.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,/;q=0.8";
					webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31");
					downloadedresponse = webClient.DownloadString(new Uri(newUrl));
					webClient.Dispose();
					return downloadedresponse;
				}
				catch (WebException)
				{
					return downloadedresponse;
				}
				catch (Exception)
				{
					return null;
				}
			}
			MessageBox.Show("Error while connecting to Internet", "Check the Connectivity");
			return null;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x000785C4 File Offset: 0x000767C4
		internal static int Get_DifferenceBetweenDate(string _expiryDate, string _serverDate)
		{
			DateTime d = Convert.ToDateTime(_expiryDate);
			DateTime serverDate = Convert.ToDateTime(_serverDate);
			return int.Parse((d - serverDate).TotalDays.ToString());
		}

		// Token: 0x06000389 RID: 905 RVA: 0x000785FC File Offset: 0x000767FC
		public static string up_Recommendation(Dictionary<string, double> nameOfControl, double LTP, string upCycle)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			if (str.Contains("Down"))
			{
				return Comman.down_Recommendation(nameOfControl, LTP, upCycle);
			}
			string Target;
			if (str != null && str != "NULL")
			{
				if (str.Contains("Target"))
				{
					Target = str.Substring(str.IndexOf("T"));
				}
				else
				{
					Target = str.Substring(str.IndexOf("B"));
				}
			}
			else
			{
				Target = "BuyEntry";
			}
			if (!(Target == "BuyEntry"))
			{
				if (!(Target == "Target1") && !(Target == "Target2") && !(Target == "Target3"))
				{
					if (!(Target == "Target4"))
					{
						if (!(Target == "Target5"))
						{
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = "Wait till it enter FRESH cycle.";
							Equtiy_Future.neutralCount.Add("0");
						}
					}
					else
					{
						recommendation = "Wait till it enter FRESH cycle.";
						Equtiy_Future.neutralCount.Add("0");
					}
				}
				else
				{
					recommendation = "BUY";
					Equtiy_Future.buyCount.Add("1");
				}
			}
			else
			{
				recommendation = string.Format("BUY when it touches {0}", nameOfControl.ElementAt(0).Value);
				Equtiy_Future.neutralCount.Add("0");
			}
			return string.Format("As Ref price {0}, is in {1}, and moving towards {2}. ##Recommendation {3}", new object[]
			{
				LTP,
				upCycle,
				nameOfControl.ElementAt(1).Value,
				recommendation
			});
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00078794 File Offset: 0x00076994
		public static string down_Recommendation(Dictionary<string, double> nameOfControl, double LTP, string downcycle)
		{
			string str = nameOfControl.ElementAt(0).Key;
			string recommendation = string.Empty;
			string Target = "";
			try
			{
				if (str.Contains("UpCycle"))
				{
					return Comman.up_Recommendation(nameOfControl, LTP, downcycle);
				}
				if (str != null && str != "NULL")
				{
					if (str.Contains("Target"))
					{
						Target = str.Substring(str.IndexOf("T"));
					}
					else
					{
						Target = str.Substring(str.IndexOf("S"));
					}
				}
				else
				{
					Target = "SellEntry";
				}
			}
			catch (Exception)
			{
			}
			if (!(Target == "SellEntry"))
			{
				if (!(Target == "Target1") && !(Target == "Target2") && !(Target == "Target3"))
				{
					if (!(Target == "Target4"))
					{
						if (!(Target == "Target5"))
						{
							Equtiy_Future.neutralCount.Add("0");
						}
						else
						{
							recommendation = "Wait till it enter fresh cycle.";
							Equtiy_Future.neutralCount.Add("0");
						}
					}
					else
					{
						recommendation = "Wait till it enter fresh cycle.";
						Equtiy_Future.neutralCount.Add("0");
					}
				}
				else
				{
					recommendation = "SELL";
					Equtiy_Future.sellCount.Add("-1");
				}
			}
			else
			{
				recommendation = string.Format("SELL when it touches {0}", nameOfControl.ElementAt(0).Value);
				Equtiy_Future.neutralCount.Add("0");
			}
			return string.Format("As Ref price {0}, is in {1}, with price {2}. ##Recommendation {3}", new object[]
			{
				LTP,
				downcycle,
				nameOfControl.ElementAt(1).Value,
				recommendation
			});
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00078948 File Offset: 0x00076B48
		public static double get_MidValue(double Value1, double Value2)
		{
			return (Value1 + Value2) / 2.0;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00078957 File Offset: 0x00076B57
		internal static double get_Diff2Number(double Value1, double Value2)
		{
			return Value1 - Value2;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0007895C File Offset: 0x00076B5C
		public static string do_RoundOffAndReturnString(double _value)
		{
			return Math.Round(_value, 3).ToString();
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00078978 File Offset: 0x00076B78
		public static decimal NormalDistribution(decimal number)
		{
			decimal sign = 1m;
			if (number < 0m)
			{
				sign = -1m;
			}
			return 0.5m * (1m + sign * Comman.ErrorFactor(Math.Abs(number) / (decimal)Math.Sqrt(2.0)));
		}

		// Token: 0x0600038F RID: 911 RVA: 0x000789E0 File Offset: 0x00076BE0
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

		// Token: 0x06000390 RID: 912 RVA: 0x00078AF0 File Offset: 0x00076CF0
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
				result = 0.5 * (1.0 + signature * Comman.get_ErrorFactor(Math.Abs(number) / Math.Sqrt(2.0)));
			}
			catch (Exception)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00078B70 File Offset: 0x00076D70
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

		// Token: 0x06000392 RID: 914 RVA: 0x00078C20 File Offset: 0x00076E20
		public static double get_Volatility(ListBox ltp, int anumber)
		{
			double sumY = 0.0;
			double sumX = 0.0;
			int numberOfLtp = ltp.Items.Count - anumber;
			for (int ltpindex = 0; ltpindex < numberOfLtp; ltpindex++)
			{
				double valueX = Math.Log(Convert.ToDouble(ltp.Items[ltpindex + 1]) / Convert.ToDouble(ltp.Items[ltpindex]));
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

		// Token: 0x06000393 RID: 915 RVA: 0x00078D10 File Offset: 0x00076F10
		public static double get_Volatility(List<double> ltp, int anumber)
		{
			double Sum = 0.0;
			double SumSQRT = 0.0;
			int NoD = ltp.Count - anumber;
			for (int i = 0; i < NoD; i++)
			{
				double num = ltp[i + 1];
				double num2 = ltp[i];
				double ValS = Math.Log(ltp[i + 1] / ltp[i]);
				double valSQRT = ValS * ValS;
				Sum += ValS;
				SumSQRT += valSQRT;
			}
			SumSQRT = Math.Sqrt(SumSQRT / (double)NoD - Math.Pow(Sum / (double)NoD, 2.0));
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

		// Token: 0x06000394 RID: 916 RVA: 0x00078DF8 File Offset: 0x00076FF8
		public static double get_PositionalPriceRange(ListBox _allLTP, int _noOfDaysToHold, double _volatility, double _liveLTP)
		{
			int totalLtpCount = _allLTP.Items.Count;
			double tempPriceRange;
			if (totalLtpCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				_volatility = Comman.get_Volatility(_allLTP, 2) + 0.0125 * Comman.get_Volatility(_allLTP, 2);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP.Items[totalLtpCount - 2]) * Math.Sqrt((double)_noOfDaysToHold);
				double x = Convert.ToDouble(_allLTP.Items[totalLtpCount - 2]) + 0.236 * tempPriceRange;
				double y = Convert.ToDouble(_allLTP.Items[totalLtpCount - 2]) - 0.236 * tempPriceRange;
				if (Convert.ToDouble(_allLTP.Items[totalLtpCount - 1]) > x || Convert.ToDouble(_allLTP.Items[totalLtpCount - 1]) < y)
				{
					_volatility = Comman.get_Volatility(_allLTP, 1) + 0.0125 * Comman.get_Volatility(_allLTP, 1);
					tempPriceRange = _volatility * Convert.ToDouble(_allLTP.Items[totalLtpCount - 1]) * Math.Sqrt((double)_noOfDaysToHold);
				}
			}
			return tempPriceRange;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00078F08 File Offset: 0x00077108
		public static double get_IntradayPriceRange(ListBox _allLTP, double _volatility, double _liveLTP)
		{
			int totalLTPCount = _allLTP.Items.Count;
			double tempPriceRange;
			if (totalLTPCount != 11)
			{
				tempPriceRange = _liveLTP * _volatility;
			}
			else
			{
				_volatility = Comman.get_Volatility(_allLTP, 2) + 0.0125 * Comman.get_Volatility(_allLTP, 2);
				tempPriceRange = _volatility * Convert.ToDouble(_allLTP.Items[totalLTPCount - 2]);
				double x = Convert.ToDouble(_allLTP.Items[totalLTPCount - 2]) + 0.236 * tempPriceRange;
				double y = Convert.ToDouble(_allLTP.Items[totalLTPCount - 2]) - 0.236 * tempPriceRange;
				if (Convert.ToDouble(_allLTP.Items[totalLTPCount - 1]) > x || Convert.ToDouble(_allLTP.Items[totalLTPCount - 1]) < y)
				{
					_volatility = Comman.get_Volatility(_allLTP, 1) + 0.0125 * Comman.get_Volatility(_allLTP, 1);
					tempPriceRange = _volatility * Convert.ToDouble(_allLTP.Items[totalLTPCount - 1]);
				}
			}
			return tempPriceRange;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00079008 File Offset: 0x00077208
		public static string GetIEVersion()
		{
			string key = "Software\\Microsoft\\Internet Explorer";
			return Registry.LocalMachine.OpenSubKey(key, false).GetValue("Version").ToString();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00079036 File Offset: 0x00077236
		public static bool IsTextNumeric(string str)
		{
			return new Regex("[^0-9]").IsMatch(str);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00079048 File Offset: 0x00077248
		public bool do_pingTest()
		{
			return new Ping().Send(IPAddress.Parse("208.69.34.231"), 1000).Status == IPStatus.Success;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0007906D File Offset: 0x0007726D
		public static void open_link(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0007908C File Offset: 0x0007728C
		public static double get_10DaysVolatility(double sumAvg, double SquareSumAvg)
		{
			return Math.Sqrt(SquareSumAvg - Math.Pow(sumAvg, 2.0));
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000790A4 File Offset: 0x000772A4
		public static Dictionary<string, double> find_Nearest2LTP(Dictionary<string, double> all_calculatedTarget, double LTP)
		{
			Dictionary<string, double> bestMatchTarget = new Dictionary<string, double>();
			new Dictionary<string, double>();
			foreach (KeyValuePair<string, double> Target in from i in all_calculatedTarget
			orderby i.Value
			select i)
			{
				if (LTP <= Target.Value)
				{
					bestMatchTarget.Add(Target.Key, Target.Value);
					break;
				}
			}
			return bestMatchTarget;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00079138 File Offset: 0x00077338
		public static Dictionary<string, double> find_Nearest2LTP2Value(Dictionary<string, double> all_calculatedTarget, double LTP)
		{
			Dictionary<string, double> bestMatchTarget = new Dictionary<string, double>();
			Dictionary<string, double> result;
			try
			{
				all_calculatedTarget = (from x in all_calculatedTarget
				orderby x.Value
				select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				int i;
				for (i = 0; i < all_calculatedTarget.Count; i++)
				{
					if (LTP <= all_calculatedTarget.ElementAt(i).Value)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i).Key, all_calculatedTarget.ElementAt(i).Value);
						break;
					}
				}
				if (i == all_calculatedTarget.Count - 1 && bestMatchTarget.Count < 0)
				{
					bestMatchTarget.Add(all_calculatedTarget.ElementAt(0).Key, all_calculatedTarget.ElementAt(0).Value);
					bestMatchTarget.Add("NULL", 0.0);
				}
				else if (bestMatchTarget.Count != 0)
				{
					bool sellEntry = all_calculatedTarget.ElementAt(i).Key.Contains("_SellEntry");
					bool flag = all_calculatedTarget.ElementAt(i).Key.Contains("_BuyEntry");
					bool downCycle = all_calculatedTarget.ElementAt(i).Key.Contains("Down");
					if (flag || sellEntry)
					{
						if (!downCycle)
						{
							bestMatchTarget.Add("NULL", 0.0);
						}
						else if (i != 0)
						{
							bestMatchTarget.Add(all_calculatedTarget.ElementAt(i - 1).Key, all_calculatedTarget.ElementAt(i - 1).Value);
						}
					}
					else if (i != 0)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i - 1).Key, all_calculatedTarget.ElementAt(i - 1).Value);
					}
					bestMatchTarget = (from x in bestMatchTarget
					orderby x.Value
					select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				}
				result = bestMatchTarget;
			}
			catch (Exception)
			{
				result = bestMatchTarget;
			}
			return result;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000793B0 File Offset: 0x000775B0
		public static Dictionary<string, double> find_PivotNearest2LTP2Value(Dictionary<string, double> all_calculatedTarget, double LTP)
		{
			Dictionary<string, double> bestMatchTarget = new Dictionary<string, double>();
			Dictionary<string, double> result;
			try
			{
				all_calculatedTarget = (from x in all_calculatedTarget
				orderby x.Value descending
				select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				int i;
				for (i = 0; i < all_calculatedTarget.Count; i++)
				{
					if (i < all_calculatedTarget.Count - 1)
					{
						if (LTP <= all_calculatedTarget.ElementAt(i).Value && LTP >= all_calculatedTarget.ElementAt(i + 1).Value)
						{
							bestMatchTarget.Add(all_calculatedTarget.ElementAt(i).Key, all_calculatedTarget.ElementAt(i).Value);
							break;
						}
					}
					else if (LTP <= all_calculatedTarget.ElementAt(i).Value)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i).Key, all_calculatedTarget.ElementAt(i).Value);
						break;
					}
				}
				if (i == all_calculatedTarget.Count - 1 && bestMatchTarget.Count < 0)
				{
					bestMatchTarget.Add(all_calculatedTarget.ElementAt(0).Key, all_calculatedTarget.ElementAt(0).Value);
					bestMatchTarget.Add("NULL", 0.0);
				}
				else
				{
					bool sellEntry = all_calculatedTarget.ElementAt(i).Key.Contains("_SellEntry");
					if (all_calculatedTarget.ElementAt(i).Key.Contains("_BuyEntry") || sellEntry)
					{
						bestMatchTarget.Add("NULL", 0.0);
					}
					else if (i != 0)
					{
						bestMatchTarget.Add(all_calculatedTarget.ElementAt(i - 1).Key, all_calculatedTarget.ElementAt(i - 1).Value);
					}
					bestMatchTarget = (from x in bestMatchTarget
					orderby x.Value
					select x).ToDictionary((KeyValuePair<string, double> x) => x.Key, (KeyValuePair<string, double> x) => x.Value);
				}
				result = bestMatchTarget;
			}
			catch (Exception)
			{
				result = bestMatchTarget;
			}
			return result;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00079630 File Offset: 0x00077830
		public static string Recommendation(Dictionary<string, double> nameOfControl, double LTP)
		{
			return null;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00079634 File Offset: 0x00077834
		public static Dictionary<string, string> filter_TradingStrike(DataTable _resultTable, string _strikePriceColumnName, string _LTPColumnName)
		{
			Dictionary<string, string> strikewithLTP = new Dictionary<string, string>();
			for (int rowIndex = 0; rowIndex < _resultTable.Rows.Count; rowIndex++)
			{
				if (_resultTable.Rows[rowIndex][_LTPColumnName].ToString() != "-")
				{
					strikewithLTP.Add(_resultTable.Rows[rowIndex][_strikePriceColumnName].ToString(), _resultTable.Rows[rowIndex][_LTPColumnName].ToString());
				}
			}
			return strikewithLTP;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000796B8 File Offset: 0x000778B8
		public static ObservableCollection<premiumDataCls> filter_TradingStrikeByIV(DataTable _Table, string callORputOption, string IVcolumnName, string LTPcolumnName)
		{
			ObservableCollection<premiumDataCls> result = new ObservableCollection<premiumDataCls>();
			try
			{
				for (int rowIndex = 0; rowIndex < _Table.Rows.Count; rowIndex++)
				{
					if (_Table.Rows[rowIndex][IVcolumnName].ToString() != "-")
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

		// Token: 0x060003A1 RID: 929 RVA: 0x00079790 File Offset: 0x00077990
		public static double get_Buy(List<double> _ltp, double currentPrice)
		{
			int DataCount = _ltp.Count;
			double num = Comman.get_Volatility(_ltp, 2) + 0.0125 * Comman.get_Volatility(_ltp, 2);
			double num2 = _ltp[DataCount - 2];
			double pRange = num * _ltp[DataCount - 2];
			double b = _ltp[DataCount - 2] + 0.236 * pRange;
			double c = _ltp[DataCount - 2] - 0.236 * pRange;
			if (_ltp[DataCount - 1] > b || _ltp[DataCount - 1] < c)
			{
				pRange = (Comman.get_Volatility(_ltp, 1) + 0.0125 * Comman.get_Volatility(_ltp, 1)) * _ltp[DataCount - 1];
				return _ltp[DataCount - 1] + 0.25 * pRange;
			}
			return _ltp[DataCount - 2] + 0.25 * pRange;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00079868 File Offset: 0x00077A68
		public static double get_Sell(List<double> _ltp, double currentPrice)
		{
			int DataCount = _ltp.Count;
			double pRange = (Comman.get_Volatility(_ltp, 2) + 0.0125 * Comman.get_Volatility(_ltp, 2)) * _ltp[DataCount - 2];
			double b = _ltp[DataCount - 2] + 0.236 * pRange;
			double c = _ltp[DataCount - 2] - 0.236 * pRange;
			if (_ltp[DataCount - 1] > b || _ltp[DataCount - 1] < c)
			{
				pRange = (Comman.get_Volatility(_ltp, 1) + 0.0125 * Comman.get_Volatility(_ltp, 1)) * _ltp[DataCount - 1];
				return _ltp[DataCount - 1] - 0.25 * pRange;
			}
			return _ltp[DataCount - 2] - 0.25 * pRange;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00079934 File Offset: 0x00077B34
		public static double get_FnOPriceRange(List<double> _ltp)
		{
			int DataCount = _ltp.Count;
			double pRange = (Comman.get_Volatility(_ltp, 2) + 0.0125 * Comman.get_Volatility(_ltp, 2)) * _ltp[DataCount - 2];
			double b = _ltp[DataCount - 2] + 0.236 * pRange;
			double c = _ltp[DataCount - 2] - 0.236 * pRange;
			if (_ltp[DataCount - 1] > b || _ltp[DataCount - 1] < c)
			{
				pRange = (Comman.get_Volatility(_ltp, 1) + 0.0125 * Comman.get_Volatility(_ltp, 1)) * _ltp[DataCount - 1];
			}
			return pRange;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x000799D8 File Offset: 0x00077BD8
		public static double ImpliedVolatility(double _currentOptPremium, int _days_left, double _LTFutureStrike, int _StrikeChoosen, string _OT)
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
			decimal dValueA = 0.00m;
			decimal dValueB = 0.00m;
			try
			{
				if (_LTFutureStrike == 0.0 || _days_left == 0 || _StrikeChoosen == 0 || _currentOptPremium == 0.0)
				{
					return 0.0;
				}
				if (_OT == "Call")
				{
					decimal CalculatedPremium;
					do
					{
						dValueA = Comman.get_dValueX(LTFutureStrike, StrikeChoosen, TempVola, days_left, interestRate);
						dValueB = Comman.get_dValueY(dValueA, TempVola, days_left);
						CalculatedPremium = Comman.get_CallPremium(LTFutureStrike, dValueA, dValueB, StrikeChoosen, interestRate, days_left);
						decimal newDvalueForVega = Comman.get_NewDvalueA(dValueA);
						decimal tempVega = Comman.get_Vega(LTFutureStrike, days_left, newDvalueForVega);
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
						dValueA = Comman.get_dValueX(LTFutureStrike, StrikeChoosen, TempVola, days_left, interestRate);
						dValueB = Comman.get_dValueY(dValueA, TempVola, days_left);
						decimal CalculatedPremium = Comman.get_PutPremium(LTFutureStrike, dValueA, dValueB, StrikeChoosen, interestRate, days_left);
						decimal newDvalueForVega = Comman.get_NewDvalueA(dValueA);
						decimal tempVega = Comman.get_Vega(LTFutureStrike, days_left, newDvalueForVega);
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

		// Token: 0x060003A5 RID: 933 RVA: 0x00079BD8 File Offset: 0x00077DD8
		private static decimal get_PutPremium(decimal LTFutureStrike, decimal dValueA, decimal dValueB, decimal StrikeChoosen, decimal interestRate, decimal days_left)
		{
			return StrikeChoosen * ((decimal)Math.Exp((double)(interestRate * (days_left / 365m) * -1m)) * Comman.NormalDistribution(dValueB * -1m)) - LTFutureStrike * Comman.NormalDistribution(dValueA * -1m);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00079C4D File Offset: 0x00077E4D
		private static decimal get_Vega(decimal LTFutureStrike, decimal days_left, decimal newDvalueForVega)
		{
			return LTFutureStrike * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m))) * newDvalueForVega;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00079C7A File Offset: 0x00077E7A
		private static decimal get_NewDvalueA(decimal dValueA)
		{
			return Convert.ToDecimal(Math.Exp(Convert.ToDouble(dValueA * dValueA) * -1.0 / 2.0) * 0.398862018);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00079CB0 File Offset: 0x00077EB0
		private static decimal get_CallPremium(decimal LTFutureStrike, decimal d1, decimal d2, decimal StrikeChoosen, decimal interestRate, decimal days_left)
		{
			decimal normalDis_d = Comman.NormalDistribution(d1);
			decimal normalDis_d2 = Comman.NormalDistribution(d2);
			decimal timeANDrate = Convert.ToDecimal(Math.Exp(Convert.ToDouble(interestRate * (days_left / 365m) * -1m)));
			LTFutureStrike * normalDis_d - StrikeChoosen * timeANDrate * normalDis_d2;
			return LTFutureStrike * normalDis_d - StrikeChoosen * timeANDrate * normalDis_d2;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00079D30 File Offset: 0x00077F30
		public static decimal get_dValueX(decimal LTFutureStrike, decimal StrikeChoosen, decimal _volatility, decimal days_left, decimal interestRate)
		{
			return (Convert.ToDecimal(Math.Log(Convert.ToDouble(LTFutureStrike / StrikeChoosen))) + (_volatility * _volatility / 2m + 0.10m) * (days_left / 365m)) / (_volatility * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m))));
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00079DB9 File Offset: 0x00077FB9
		public static decimal get_dValueY(decimal valueA, decimal volatility, decimal days_left)
		{
			return valueA - volatility * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(days_left / 365m)));
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00079DE8 File Offset: 0x00077FE8
		public static double get_dValueA(double _IV, double _Strike, double _FuturePrice, double days_Left)
		{
			double num = Math.Log(_FuturePrice / _Strike);
			double interestRate = 0.1;
			double IVPower2 = Math.Pow(_IV, 2.0) / 2.0;
			double yearly = days_Left / 365.0;
			double num2 = (num + (interestRate + IVPower2) * yearly) / (_IV * Math.Sqrt(yearly));
			return (num + (interestRate + IVPower2) * yearly) / (_IV * Math.Sqrt(yearly));
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00079E50 File Offset: 0x00078050
		public static double get_dValueB(double _IV, double _Strike, double _FuturePrice, double days_Left)
		{
			double num = Math.Log(_FuturePrice / _Strike);
			double interestRate = 0.1;
			double IVPower2 = Math.Pow(_IV, 2.0) / 2.0;
			double yearly = days_Left / 365.0;
			double num2 = (num + (interestRate - IVPower2) * yearly) / (_IV * Math.Sqrt(yearly));
			return (num + (interestRate - IVPower2) * yearly) / (_IV * Math.Sqrt(yearly));
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00079EB8 File Offset: 0x000780B8
		public static double premium(double d1, double d2, double StrikeChoosen, double currentMprice, double _days_expiry, string _optionType)
		{
			double tempPremium = 0.0;
			double normalDisA = Comman.calculate_NormalDistribution(d1);
			double normalDisB = Comman.calculate_NormalDistribution(d2);
			double normalDisC = Comman.calculate_NormalDistribution(-d1);
			double normalDisD = Comman.calculate_NormalDistribution(-d2);
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

		// Token: 0x060003AE RID: 942 RVA: 0x00079F46 File Offset: 0x00078146
		public static double delta(double _d1, string _OT)
		{
			if (_OT == "Call")
			{
				return Convert.ToDouble(Comman.calculate_NormalDistribution(_d1));
			}
			return Convert.ToDouble(Comman.calculate_NormalDistribution(_d1) - 1.0);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00079F78 File Offset: 0x00078178
		public static double gamma(double _d1, double _futurePrice, double _days_left, double _IV)
		{
			double yearly = _days_left / 365.0;
			_IV /= 100.0;
			double pi = 3.141592653589793;
			return 1.0 / Math.Sqrt(2.0 * pi) * Math.Exp(-(_d1 * _d1 / 2.0)) / (_futurePrice * Convert.ToDouble(_IV) * Math.Sqrt(yearly));
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00079FE8 File Offset: 0x000781E8
		public static double theta(double _d1, double _d2, double _strike, double _futurePrice, double days_left, double _IV, string OT)
		{
			double interestRate = 0.1;
			double yearly = days_left / 365.0;
			double tempPI = 3.141592653589793;
			double nd = 1.0 / Math.Sqrt(2.0 * tempPI) * Math.Exp(-Math.Pow(_d1, 2.0) / 2.0);
			double tempCalc = -(_futurePrice * nd * _IV) / (2.0 * Math.Sqrt(yearly));
			double normalDist;
			if (OT == "Call")
			{
				normalDist = Comman.calculate_NormalDistribution(_d2);
				return (tempCalc - interestRate * _strike * Math.Exp(-interestRate * yearly) * normalDist) / 365.0;
			}
			normalDist = Comman.calculate_NormalDistribution(-_d2);
			return (tempCalc + interestRate * _strike * Math.Exp(-interestRate * yearly) * normalDist) / 365.0;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0007A0C8 File Offset: 0x000782C8
		public static double vega(double _d1, double _futurePrice, double _days_left)
		{
			double yearly = _days_left / 365.0;
			double tempPI = 3.141592653589793;
			return 1.0 / Math.Sqrt(2.0 * tempPI) * Math.Exp(-(_d1 * _d1) / 2.0) * _futurePrice * Math.Sqrt(yearly) * 0.01;
		}

		// Token: 0x04000F19 RID: 3865
		public static double thetaSpot;
	}
}
