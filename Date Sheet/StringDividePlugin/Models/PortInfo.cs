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
            set
            { 
                SetProperty(ref _index, value);

                SelectedCParaName = CParaNames==null ?null: CParaNames[_index];
                SelectedEParaName = EParaNames==null? null: EParaNames[_index];
            }
        }


        public List<string> EParaNames { get; set; }    
        public List<string> CParaNames { get; set; }

        private string _selectedEParaName;
        public string SelectedEParaName
        {
            get { return _selectedEParaName; }
            set { SetProperty(ref _selectedEParaName, value); }
        }

        private string _selectedCParaName;
        public string SelectedCParaName
        {
            get { return _selectedCParaName; }
            set { SetProperty(ref _selectedCParaName, value); }
        }

    }
}
