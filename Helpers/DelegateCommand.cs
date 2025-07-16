using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace New_SF_IT.Helpers
{
	// Token: 0x0200002F RID: 47
	[NullableContext(1)]
	[Nullable(0)]
	public class DelegateCommand : ICommand
	{
		// Token: 0x06000279 RID: 633 RVA: 0x00033551 File Offset: 0x00031751
		public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
		{
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0003355B File Offset: 0x0003175B
		public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
		{
			if (executeAction == null)
			{
				throw new ArgumentNullException("executeAction");
			}
			this.executeAction = executeAction;
			this.canExecute = canExecute;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00033580 File Offset: 0x00031780
		public bool CanExecute(object parameter)
		{
			bool result = true;
			Func<object, bool> canExecuteHandler = this.canExecute;
			if (canExecuteHandler != null)
			{
				result = canExecuteHandler(parameter);
			}
			return result;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600027C RID: 636 RVA: 0x000335A4 File Offset: 0x000317A4
		// (remove) Token: 0x0600027D RID: 637 RVA: 0x000335DC File Offset: 0x000317DC
		public event EventHandler CanExecuteChanged;

		// Token: 0x0600027E RID: 638 RVA: 0x00033614 File Offset: 0x00031814
		public void RaiseCanExecuteChanged()
		{
			EventHandler handler = this.CanExecuteChanged;
			if (handler != null)
			{
				handler(this, new EventArgs());
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00033637 File Offset: 0x00031837
		public void Execute(object parameter)
		{
			this.executeAction(parameter);
		}

		// Token: 0x04000612 RID: 1554
		private Func<object, bool> canExecute;

		// Token: 0x04000613 RID: 1555
		private Action<object> executeAction;
	}
}
