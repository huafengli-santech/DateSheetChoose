using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CMTest.Models
{
    public class PortInfo : PropertyChangedBase
    {
        public string EName { get; set; }
        public string CName { get; set; }
        private int _index;
        public List<string> EParaNames { get; set; }
        public List<string> CParaNames { get; set; }
        private string _selectedEParaName;
        private string _selectedCParaName;

        public int Index
        {
            get { return _index; }
            set
            {
                _index= value;
                NotifyOfPropertyChange(() => Index);
                SelectedCParaName = CParaNames == null ? null : CParaNames[_index];
                SelectedEParaName = EParaNames == null ? null : EParaNames[_index];
            }
        }

        public string SelectedEParaName
        {
            get { return _selectedEParaName; }
            set
            {
                _selectedEParaName= value;
                NotifyOfPropertyChange(() => SelectedEParaName);
            }
        }

        public string SelectedCParaName
        {
            get { return _selectedCParaName; }
            set
            {
                _selectedCParaName = value;
                NotifyOfPropertyChange(() => SelectedCParaName);
            }
        }
    }
}