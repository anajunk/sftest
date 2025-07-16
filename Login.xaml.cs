using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using HtmlAgilityPack;
using New_SF_IT.classes;

namespace New_SF_IT
{
	// Token: 0x02000011 RID: 17
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Login : Window
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x00006F80 File Offset: 0x00005180
		public Login()
		{
			this.InitializeComponent();
			this.CheckAndUpdateSoftwareVersion();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007084 File Offset: 0x00005284
		private void textUser_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.txtbUsername.Focus();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007092 File Offset: 0x00005292
		private void txtbUsername_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtbUsername.Text) && this.txtbUsername.Text.Length > 0)
			{
				this.textUser.Visibility = Visibility.Visible;
				return;
			}
			this.textUser.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000070D2 File Offset: 0x000052D2
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000070DC File Offset: 0x000052DC
		private void read_fromFile(string _path)
		{
			if (File.Exists(_path))
			{
				StreamReader readerObj = File.OpenText(_path);
				this.txtbUsername.Text = readerObj.ReadLine();
				this.cbRemember.IsChecked = new bool?(true);
				this.cbRemember.IsEnabled = false;
				readerObj.Dispose();
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000712C File Offset: 0x0000532C
		private void display_SuccessMessage()
		{
			MessageBox.Show("        LOGIN DONE SUCCESSFULLY.", "STT Software");
			bool? isChecked = this.cbRemember.IsChecked;
			bool flag = true;
			if (isChecked.GetValueOrDefault() == flag & isChecked != null)
			{
				this.write_DetailToFile(this._profilePATH);
			}
			else
			{
				this.write_DetailToFile(this._profilePATHTemp);
			}
			base.Hide();
			new MainWindow().Show();
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(3.0);
			timer.Tick += delegate([Nullable(2)] object sender, EventArgs args)
			{
				timer.Stop();
				new Disclaimer().ShowDialog();
			};
			timer.Start();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000071E1 File Offset: 0x000053E1
		private void write_DetailToFile(string _path)
		{
			if (!File.Exists(_path))
			{
				StreamWriter streamWriter = File.CreateText(_path);
				streamWriter.WriteLine(this.txtbUsername.Text.Trim());
				streamWriter.Dispose();
			}
			File.SetAttributes(_path, FileAttributes.Hidden);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007213 File Offset: 0x00005413
		private object get_SystemSID()
		{
			this._wi = WindowsIdentity.GetCurrent();
			this.sid = this._wi.User.AccountDomainSid;
			return this.sid;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000723C File Offset: 0x0000543C
		private void setServerDateTrial(string serverDate)
		{
			if (serverDate != null)
			{
				MainWindow.serverCurrentTrialDate = serverDate;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00007248 File Offset: 0x00005448
		private string Is_ProfilePresent(string downloadedData)
		{
			if (downloadedData == null || !downloadedData.Contains("username"))
			{
				return string.Empty;
			}
			this._htmlDoc = new HtmlDocument();
			this._htmlDoc.LoadHtml(downloadedData);
			this.expiryDate = this._htmlDoc.GetElementbyId("edate").InnerHtml;
			this.serverDate = this._htmlDoc.GetElementbyId("serverdate").InnerHtml;
			this.setServerDateTrial(this.serverDate);
			this.daysLeft4SoftwareExpiry = Comman.Get_DifferenceBetweenDate(this.expiryDate, this.serverDate);
			string innerHtml = this._htmlDoc.GetElementbyId("username").InnerHtml;
			string innerHtml2 = this._htmlDoc.GetElementbyId("indexes").InnerHtml;
			if (!(this._htmlDoc.GetElementbyId("username").InnerHtml == "validusername"))
			{
				return "INVALIDUSERID";
			}
			if (!(this._htmlDoc.GetElementbyId("expiry").InnerHtml == "validdate"))
			{
				downloadedData.Contains("MONTH");
				return "mEXPIRED";
			}
			if (this._htmlDoc.GetElementbyId("indexes").InnerHtml == "newuser")
			{
				if (this._htmlDoc.GetElementbyId("flag").InnerHtml == "loggedout")
				{
					return "ALLOK";
				}
				return "LOGGEDINALREADY";
			}
			else
			{
				if (!(this._htmlDoc.GetElementbyId("ssid").InnerHtml == "validsystem"))
				{
					return "DIFFRENTSYSTEM";
				}
				if (this._htmlDoc.GetElementbyId("flag").InnerHtml == "loggedout")
				{
					return "ALLOK";
				}
				return "LOGGEDINALREADY";
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007410 File Offset: 0x00005610
		private void logInProcess(string isValidUser)
		{
			if (isValidUser == "ALLOK")
			{
				this.display_SuccessMessage();
				return;
			}
			if (isValidUser == "DIFFRENTSYSTEM")
			{
				MessageBox.Show(string.Concat(new string[]
				{
					"Application can be accessed from only one system.",
					Environment.NewLine,
					"Send email briefing this issue to",
					Environment.NewLine,
					"smartfinancein@gmail.com",
					Environment.NewLine,
					"with your Userid."
				}), "Trying to access from diffrent System.");
				this.loginBtn.IsEnabled = true;
				this.progressBar.Value = 0.0;
				return;
			}
			if (isValidUser == "INVALIDUSERID")
			{
				MessageBox.Show(Environment.NewLine + "Username and password is invalid." + Environment.NewLine + "Check the spelling", "Username not found.");
				this.loginBtn.IsEnabled = true;
				this.progressBar.Value = 0.0;
				return;
			}
			if (isValidUser == "EXPIRED")
			{
				this.display_SuccessMessage();
				this.loginBtn.IsEnabled = true;
				this.progressBar.Value = 0.0;
				return;
			}
			if (isValidUser == "mEXPIRED")
			{
				this.display_SuccessMessage();
				this.loginBtn.IsEnabled = true;
				this.progressBar.Value = 0.0;
				return;
			}
			if (!(isValidUser == "LOGGEDINALREADY"))
			{
				return;
			}
			this.loginBtn.IsEnabled = true;
			this.progressBar.Value = 0.0;
			MessageBox.Show(string.Concat(new string[]
			{
				"User already logged in",
				Environment.NewLine,
				"#Reason : you were not logged out properly.",
				Environment.NewLine,
				"Solution :",
				Environment.NewLine,
				"Click OK, and Logout",
				Environment.NewLine
			}), "Already logged in.");
			base.Hide();
			new Logout().Show();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007608 File Offset: 0x00005808
		private void PerformLogin()
		{
			if (Comman.IsInternetAvailable())
			{
				if (string.IsNullOrWhiteSpace(this.txtbUsername.Text.Trim()))
				{
					MessageBox.Show("Please fill the Username.");
					base.Dispatcher.BeginInvoke(new ThreadStart(delegate()
					{
						this.txtbUsername.Focus();
					}), Array.Empty<object>());
					return;
				}
				if (this.txtbUsername.Text.Trim().Length < 5)
				{
					MessageBox.Show("Username should be more than 4 characters.", "Invalid Username.");
					base.Dispatcher.BeginInvoke(new ThreadStart(delegate()
					{
						this.txtbUsername.Focus();
					}), Array.Empty<object>());
					return;
				}
				try
				{
					object systemSID = this.get_SystemSID();
					Login.USERNAME = this.txtbUsername.Text.Trim();
					this.loginURL = string.Format(this.loginRawUrl, this.txtbUsername.Text.Trim(), this.sid, "Login");
					string downloadedData = Comman.get_Website(this.loginURL);
					this.isValidUser = this.Is_ProfilePresent(downloadedData);
					if (string.IsNullOrWhiteSpace(this.isValidUser))
					{
						MessageBox.Show("Wait for a few moments and try again." + Environment.NewLine + "If the error still exists, exit and restart this application.", "Server error");
						return;
					}
					this.logInProcess(this.isValidUser);
					return;
				}
				catch (Exception)
				{
					MessageBox.Show("Try again after a few minutes.", "Server error");
					return;
				}
			}
			MessageBox.Show("Check internet connectivity.", "Connection error");
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00007778 File Offset: 0x00005978
		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			Login.<btnLogin_Click>d__32 <btnLogin_Click>d__;
			<btnLogin_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<btnLogin_Click>d__.<>4__this = this;
			<btnLogin_Click>d__.<>1__state = -1;
			<btnLogin_Click>d__.<>t__builder.Start<Login.<btnLogin_Click>d__32>(ref <btnLogin_Click>d__);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000077B0 File Offset: 0x000059B0
		public void CheckAndUpdateSoftwareVersion()
		{
			try
			{
				this.softwareVersion = Comman.get_softwareVersion();
				string currentversion = Comman.get_softwareVersion().ToString();
				Login.MajorVersion = currentversion.Substring(0, currentversion.Length - 2);
				if (new StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create(Login.baseSmartFinanceInfo + "/VersionInfoTrial.txt")).GetResponse()).GetResponseStream()).ReadToEnd() != Login.MajorVersion && MessageBox.Show(this.UpdationSteps, "New Update is Available for Smart Trading Tool", MessageBoxButton.YesNo, MessageBoxImage.Asterisk).ToString() == "Yes")
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://smartfinance.in/software/Smart_Trading_Tool_Trial.zip",
						UseShellExecute = true
					});
					Application.Current.Shutdown();
					Environment.Exit(0);
				}
				this.read_fromFile(this._profilePATH);
			}
			catch (Exception i)
			{
				MessageBox.Show(string.Concat(new string[]
				{
					"Possible reason:",
					Environment.NewLine,
					"1. Check internet connectivity",
					Environment.NewLine,
					"2. Addons Redirecting in IE.",
					Environment.NewLine,
					"3. Internet connectivity required to operate",
					Environment.NewLine,
					"Support: 044-43856715",
					Environment.NewLine,
					i.Message
				}), "Application startup [Error:101]");
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00007914 File Offset: 0x00005B14
		private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtbUsername.Text) && this.txtbUsername.Text.Length > 0)
			{
				this.textUser.Visibility = Visibility.Visible;
				return;
			}
			this.textUser.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00007954 File Offset: 0x00005B54
		private void goToRegister(object sender, MouseButtonEventArgs e)
		{
			new Register().Show();
			base.Close();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00007968 File Offset: 0x00005B68
		private void Timer_Tick(object sender, EventArgs e)
		{
			this.progressBar.Value = (double)this.progressValue;
			if (this.progressValue >= 100)
			{
				this.timer.Stop();
				this.PerformLogin();
				this.btnClose.IsEnabled = true;
				return;
			}
			this.progressValue++;
		}

		// Token: 0x040000E3 RID: 227
		public static string USERNAME;

		// Token: 0x040000E4 RID: 228
		public static string PASSWORD;

		// Token: 0x040000E5 RID: 229
		private DispatcherTimer timer;

		// Token: 0x040000E6 RID: 230
		private int progressValue;

		// Token: 0x040000E7 RID: 231
		private string loginRawUrl = Login.baseSmartFinanceInfo + "/logintrack.php?usr={0}&sid={1}&submit={2}";

		// Token: 0x040000E8 RID: 232
		public static string baseSmartFinanceInfo = "https://smartfinance.in/stt_software/desktop_trail";

		// Token: 0x040000E9 RID: 233
		private string _profilePATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\stt_trail_software.txt";

		// Token: 0x040000EA RID: 234
		private string _profilePATHTemp = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tempnewIT.txt";

		// Token: 0x040000EB RID: 235
		public static string MajorVersion;

		// Token: 0x040000EC RID: 236
		private object sid;

		// Token: 0x040000ED RID: 237
		private WindowsIdentity _wi;

		// Token: 0x040000EE RID: 238
		private string loginURL;

		// Token: 0x040000EF RID: 239
		private string isValidUser;

		// Token: 0x040000F0 RID: 240
		private HtmlDocument _htmlDoc = new HtmlDocument();

		// Token: 0x040000F1 RID: 241
		private string expiryDate;

		// Token: 0x040000F2 RID: 242
		private string serverDate;

		// Token: 0x040000F3 RID: 243
		private int daysLeft4SoftwareExpiry;

		// Token: 0x040000F4 RID: 244
		private Version softwareVersion;

		// Token: 0x040000F5 RID: 245
		private bool closetheform;

		// Token: 0x040000F6 RID: 246
		private string UpdationSteps = string.Concat(new string[]
		{
			"Software update procedure:",
			Environment.NewLine,
			Environment.NewLine,
			"1. Click YES to download the latest version installer(Zip) file",
			Environment.NewLine,
			Environment.NewLine,
			"2. Uninstall the previous version of Smart Trading Tool from CONTROL PANEL under PROGRAMs",
			Environment.NewLine,
			Environment.NewLine,
			"3. Extract the downloaded zip file then double click on Smart Trading Tool.msi.",
			Environment.NewLine,
			Environment.NewLine,
			"4. Installation will start and will take few minutes to complete.",
			Environment.NewLine,
			Environment.NewLine,
			"5. After successful installation, Login with your Username & Password."
		});
	}
}
