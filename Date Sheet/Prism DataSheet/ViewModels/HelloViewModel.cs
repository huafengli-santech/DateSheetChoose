using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Prism_DataSheet.Views;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Prism_DataSheet.ViewModels
{
    public class HelloViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand BorderLoadedFunc { get; set; }
        public HelloViewModel()
        {
            BorderLoadedFunc = new DelegateCommand(FormLoadedFunc);
        }
        private void FormLoadedFunc()
        {
            Task.Run(() =>
            {
                Thread.Sleep(10000);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                });
            });
        }
        public string Title => "欢迎使用选型软件";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
