using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDividePlugin.Models
{
    public class PortInfo: BindableBase
    {
        public string EName { get; set; }
        public string CName { get; set; }
        private int _index;

        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }


        public List<string> EParaNames { get; set; }    
        public List<string> CParaNames { get; set; }    

    }
}
