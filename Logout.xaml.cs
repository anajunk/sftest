using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using HtmlAgilityPack;

namespace New_SF_IT
{
	// Token: 0x02000012 RID: 18
	public partial class Logout : Window
	{
		// Token: 0x060000BA RID: 186 RVA: 0x00007B17 File Offset: 0x00005D17
		public Logout()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00007B51 File Offset: 0x00005D51
		[NullableContext(1)]
		private void textUser_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.txtbUsername.Focus();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00007B5F File Offset: 0x00005D5F
		[NullableContext(1)]
		private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtbUsername.Text) && this.txtbUsername.Text.Length > 0)
			{
				this.textUser.Visibility = Visibility.Visible;
				return;
			}
			this.textUser.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00007B9F File Offset: 0x00005D9F
		[NullableContext(1)]
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
			Environment.Exit(0);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00007BB0 File Offset: 0x00005DB0
		[NullableContext(1)]
		private void logoutWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (File.Exists(this.path))
			{
				string[] array = File.ReadAllLines(this.path);
				int i = 0;
				foreach (string s in array)
				{
					if (!string.IsNullOrWhiteSpace(s) && i == 0)
					{
						this.txtbUsername.Text = s.Trim();
					}
					i++;
				}
			}
			this.txtbUsername.Focus();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00007C18 File Offset: 0x00005E18
		[NullableContext(1)]
		private void btnLogout_Click(object sender, RoutedEventArgs e)
		{
			string pwd = "";
			object accountDomainSid = WindowsIdentity.GetCurrent().User.AccountDomainSid;
			string usr = this.txtbUsername.Text.Trim();
			string sid = accountDomainSid.ToString().Trim();
			string weburl = string.Concat(new string[]
			{
				this.baseSmartfinanceInfo,
				"/logoutTrack.php?user=",
				usr,
				"&pwd=",
				pwd,
				"&sid=",
				sid,
				"&submit=Login"
			});
			try
			{
				if (!string.IsNullOrEmpty(usr) && usr.Length != 0)
				{
					if (usr.Length >= 1 && usr.Length <= 32)
					{
						this.wbLogout.Navigate(weburl);
						MessageBox.Show("\"LOGOUT DONE SUCCESSFULLY\"" + Environment.NewLine + Environment.NewLine + "Thank you for using, Smart Finance");
						base.Close();
						Environment.Exit(0);
					}
					else
					{
						MessageBox.Show("Username Allows 6 to 32 Characters Only", "Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
						this.txtbUsername.Clear();
						this.txtbUsername.Focus();
					}
				}
				else
				{
					MessageBox.Show("Please enter the Username", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Unable connect to server", "Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x040000FE RID: 254
		[Nullable(1)]
		private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stt_trail_software.txt");

		// Token: 0x040000FF RID: 255
		[Nullable(1)]
		private string baseSmartfinanceInfo = "https://smartfinance.in/stt_software/desktop_trail";

		// Token: 0x04000100 RID: 256
		private bool closetheform;

		// Token: 0x04000101 RID: 257
		[Nullable(1)]
		private HtmlDocument _htmlDoc = new HtmlDocument();
	}
}
