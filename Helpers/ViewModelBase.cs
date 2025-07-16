using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MediatorLib;

namespace New_SF_IT.Helpers
{
	// Token: 0x02000030 RID: 48
	[NullableContext(1)]
	[Nullable(0)]
	internal class ViewModelBase : INotifyPropertyChanged
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000280 RID: 640 RVA: 0x00033648 File Offset: 0x00031848
		// (remove) Token: 0x06000281 RID: 641 RVA: 0x00033680 File Offset: 0x00031880
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000282 RID: 642 RVA: 0x000336B5 File Offset: 0x000318B5
		protected ViewModelBase()
		{
			this.ThrowOnInvalidPropertyName = true;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000336C4 File Offset: 0x000318C4
		public virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000284 RID: 644 RVA: 0x000336EA File Offset: 0x000318EA
		public Mediator Mediator
		{
			get
			{
				return ViewModelBase.mediator;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000285 RID: 645 RVA: 0x000336F1 File Offset: 0x000318F1
		// (set) Token: 0x06000286 RID: 646 RVA: 0x000336F9 File Offset: 0x000318F9
		private protected bool ThrowOnInvalidPropertyName { protected get; private set; }

		// Token: 0x06000287 RID: 647 RVA: 0x00033704 File Offset: 0x00031904
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;
				if (this.ThrowOnInvalidPropertyName)
				{
					throw new Exception(msg);
				}
			}
		}

		// Token: 0x04000615 RID: 1557
		private static readonly Mediator mediator = new Mediator();
	}
}
