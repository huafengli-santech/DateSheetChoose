using Common.Adpter;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism_DataSheet.ViewModels;
using Prism_DataSheet.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Prism_DataSheet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        string path = $@"{Environment.CurrentDirectory}\Modules";
        protected override Window CreateShell()
        {
            //判断存在该文件夹，不存在则创建一个
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                Directory.CreateDirectory(path);
            }
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<HelloView, HelloViewModel>();
        }
        /// <summary>
        /// 配置区域适配
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            //添加自定义区域适配对象,会自动适配标记上prism:RegionManager.RegionName的容器控件为Region
            regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlsAdpter>());
            //regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = $@"{path}" };
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("HelloView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }
            });
            base.OnInitialized();
        }
    }
}
