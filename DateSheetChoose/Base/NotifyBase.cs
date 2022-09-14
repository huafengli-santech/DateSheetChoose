using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DateSheetChoose.Base
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoNotify([CallerMemberName]String proName="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(proName));
        }
    }
}
