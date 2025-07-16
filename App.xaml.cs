using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace New_SF_IT
{
	// Token: 0x02000009 RID: 9
	public partial class App : Application
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002348 File Offset: 0x00000548
		[NullableContext(1)]
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stt_trail_software.txt");
			try
			{
				if (File.Exists(filePath))
				{
					new Login().Show();
				}
				else
				{
					new Register().Show();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}
	}
}
