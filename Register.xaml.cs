using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using HtmlAgilityPack;
using New_SF_IT.classes;

namespace New_SF_IT
{
	// Token: 0x02000016 RID: 22
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Register : Window
	{
		// Token: 0x06000112 RID: 274 RVA: 0x0000DAB8 File Offset: 0x0000BCB8
		public Register()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000DB07 File Offset: 0x0000BD07
		private void textUser_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.txtbUsername.Focus();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000DB15 File Offset: 0x0000BD15
		private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtbUsername.Text) && this.txtbUsername.Text.Length > 0)
			{
				this.textUser.Visibility = Visibility.Visible;
				return;
			}
			this.textUser.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000DB55 File Offset: 0x0000BD55
		private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.txtemail.Focus();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000DB63 File Offset: 0x0000BD63
		private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtemail.Text) && this.txtemail.Text.Length > 0)
			{
				this.textemail.Visibility = Visibility.Visible;
				return;
			}
			this.textemail.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000DBA3 File Offset: 0x0000BDA3
		private void textPhone_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.txtPhone.Focus();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000DBB1 File Offset: 0x0000BDB1
		private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtPhone.Text) && this.txtPhone.Text.Length > 0)
			{
				this.textPhone.Visibility = Visibility.Visible;
				return;
			}
			this.textPhone.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000DBF4 File Offset: 0x0000BDF4
		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			string name = this.txtbUsername.Text;
			string email = this.txtemail.Text;
			string phone = this.txtPhone.Text;
			if (!(name != "") || name == null || !(email != "") || email == null || !(phone != "") || phone == null)
			{
				MessageBox.Show("   Fill all fields.", "STT Software");
				return;
			}
			if (!Register.IsValidEmail(email))
			{
				MessageBox.Show("Give valid email ID", "STT");
				return;
			}
			object systemSID = this.get_SystemSID();
			this.loginURL = string.Format(this.loginRawUrl, new object[]
			{
				name,
				email,
				phone,
				this.sid
			});
			string downloadedData = Comman.get_Website(this.loginURL);
			this.isValidUser = this.Is_ProfilePresent(downloadedData);
			if (string.IsNullOrWhiteSpace(this.isValidUser))
			{
				MessageBox.Show("Wait for a few moments and try again." + Environment.NewLine + "If the error still exists, exit and restart this application.", "Server error");
				return;
			}
			this.registerProcess(this.isValidUser);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000DD1C File Offset: 0x0000BF1C
		public static bool IsValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
			{
				return false;
			}
			bool result;
			try
			{
				string emailPattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
				result = Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
			}
			catch (RegexMatchTimeoutException)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000DD5C File Offset: 0x0000BF5C
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000DD64 File Offset: 0x0000BF64
		private object get_SystemSID()
		{
			this._wi = WindowsIdentity.GetCurrent();
			this.sid = this._wi.User.AccountDomainSid;
			return this.sid;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000DD90 File Offset: 0x0000BF90
		private string Is_ProfilePresent(string downloadedData)
		{
			if (string.IsNullOrEmpty(downloadedData))
			{
				return string.Empty;
			}
			downloadedData = downloadedData.Trim();
			if (downloadedData == "success")
			{
				return "success";
			}
			if (!(downloadedData == "already exists"))
			{
				return "UNKNOWNSTATUS";
			}
			return "already exists";
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000DDE0 File Offset: 0x0000BFE0
		private void setServerDateTrial(string serverDate)
		{
			if (serverDate != null)
			{
				MainWindow.serverCurrentTrialDate = serverDate;
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		private void registerProcess(string isValidUser)
		{
			if (isValidUser == "success")
			{
				string text = this.txtemail.Text;
				int atIndex = text.IndexOf('@');
				string username = text.Substring(0, atIndex);
				MessageBox.Show("Registration completed Successfully" + Environment.NewLine + "Your user id is : " + username, "STT");
				this.write_DetailToFile(this._profilePATH);
				new MainWindow().Show();
				base.Close();
				return;
			}
			if (!(isValidUser == "already exists"))
			{
				MessageBox.Show("Registration failed" + Environment.NewLine + "Contact Smart Finance Suport Team", "STT");
				return;
			}
			MessageBox.Show("User Already exist ", "STT");
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		private void write_DetailToFile(string _path)
		{
			if (!File.Exists(_path))
			{
				string text = this.txtemail.Text;
				int atIndex = text.IndexOf('@');
				string username = text.Substring(0, atIndex);
				StreamWriter streamWriter = File.CreateText(_path);
				streamWriter.WriteLine(username.Trim());
				streamWriter.Dispose();
			}
			File.SetAttributes(_path, FileAttributes.Hidden);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000DEEF File Offset: 0x0000C0EF
		private void goToLogin(object sender, MouseButtonEventArgs e)
		{
			new Login().Show();
			base.Close();
		}

		// Token: 0x04000199 RID: 409
		private object sid;

		// Token: 0x0400019A RID: 410
		private WindowsIdentity _wi;

		// Token: 0x0400019B RID: 411
		private string loginRawUrl = Register.baseSmartFinanceInfo + "/register.php?name={0}&email={1}&phone={2}&ssid={3}";

		// Token: 0x0400019C RID: 412
		public static string baseSmartFinanceInfo = "https://smartfinance.in/stt_software/desktop_trail";

		// Token: 0x0400019D RID: 413
		private string loginURL;

		// Token: 0x0400019E RID: 414
		private string isValidUser;

		// Token: 0x0400019F RID: 415
		private HtmlDocument _htmlDoc = new HtmlDocument();

		// Token: 0x040001A0 RID: 416
		private string expiryDate;

		// Token: 0x040001A1 RID: 417
		private string serverDate;

		// Token: 0x040001A2 RID: 418
		private int daysLeft4SoftwareExpiry;

		// Token: 0x040001A3 RID: 419
		private string _profilePATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\stt_trail_software.txt";
	}
}
