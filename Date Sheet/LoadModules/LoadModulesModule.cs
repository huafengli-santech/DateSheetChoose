using LoadModules.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
namespace LoadModules
{
    [Module(ModuleName = "LoadModule")]
    public class LoadModulesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //通过region manager 添加模块页面窗体
            var regionmanager = containerProvider.Resolve<IRegionManager>();
            //通过ContentRegion管理导航默认初始页面ContactView
            var contentRegion = regionmanager.Regions["ContentRegion"]; //需要绑定到主界面的那个区域
            contentRegion.RequestNavigate(nameof(LoadModule));//注册需要绑定的窗体是哪一个
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册类型，发现不写也可以正常运行
            containerRegistry.RegisterForNavigation<LoadModule>();
        }
    }
}