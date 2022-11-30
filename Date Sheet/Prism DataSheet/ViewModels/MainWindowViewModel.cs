using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism_DataSheet.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
namespace Prism_DataSheet.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //Region管理对象
        private IRegionManager _regionManager;
        private IModuleCatalog _moduleCatalog;
        private ObservableCollection<ModulesInfo> _modules;
        private DelegateCommand _loadModules;
        private ModulesInfo _moduleInfo;
        private DelegateCommand<object> _closeCommand;
        private DelegateCommand<object> _minCommand;
        private DelegateCommand<object> _maxCommand;
        private string _title = "ACS型号选择器";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ObservableCollection<ModulesInfo> Modules
        {
            get => _modules ?? (_modules = new ObservableCollection<ModulesInfo>());
        }
        public DelegateCommand LoadModules { get => _loadModules = new DelegateCommand(InitModules); }
        public ModulesInfo ModuleInfo
        {
            get
            {
                return _moduleInfo;
            }
            set
            {
                _moduleInfo = value;
                Navigate(value);
            }
        }
        public void InitModules()
        {
            var dirModuleCatalog = _moduleCatalog as DirectoryModuleCatalog;
            foreach (var module in dirModuleCatalog.Items)
            {
                var tempModule = module as ModuleInfo;
                switch (tempModule.ModuleName)
                {
                    case "LoadModule":
                        Modules.Add(new ModulesInfo() { DisplayName = "模块生成", Name = tempModule.ModuleName });
                        break;
                    case "StringDivide":
                        Modules.Add(new ModulesInfo() { DisplayName = "型号分析", Name = tempModule.ModuleName });
                        break;
                    case "ModuleUpdate":
                        Modules.Add(new ModulesInfo() { DisplayName = "模块刷新", Name = tempModule.ModuleName });
                        break;
                }
            }
        }
        private void Navigate(ModulesInfo info)
        {
            var paramete = new NavigationParameters();
            paramete.Add($"{info.Name}", DateTime.Now.ToString());
            _regionManager.RequestNavigate("ContentRegion", $"{info.Name}", paramete);
        }
        #region Command实现
        public DelegateCommand<object> CloseCommand
        {
            get => _closeCommand ?? (_closeCommand = new DelegateCommand<object>((o) =>
            {
                Window w = (Window)o;
                w.Close();
            }));
        }
        public DelegateCommand<object> MinCommand
        {
            get => _minCommand ?? (_minCommand = new DelegateCommand<object>((o) =>
        {
            Window w = (Window)o;
            w.WindowState = w.WindowState == WindowState.Minimized ? WindowState.Normal : WindowState.Minimized;
        }));
        }
        public DelegateCommand<object> MaxCommand
        {
            get => _maxCommand ?? (_maxCommand = new DelegateCommand<object>((o) =>
        {
            Window w = (Window)o;
            w.WindowState = w.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }));
        }
        #endregion
        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            _regionManager = regionManager;
            _moduleCatalog = moduleCatalog;
        }
    }
}
