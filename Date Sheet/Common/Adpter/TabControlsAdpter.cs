using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
namespace Common.Adpter
{
    public class TabControlsAdpter : RegionAdapterBase<TabControl>
    {
        public TabControlsAdpter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        regionTarget.Items.Add(new TabItem
                        {
                            Content = item as UIElement, //在Region里显示的View
                            Header = GetPluginName(item.ToString())
                        });
                    }
                }
            };
        }
        private string GetPluginName(string itemName)
        {
            string pluginName = "";
            if (itemName.Contains("LoadModule"))
            {
                pluginName = "模块生成";
            }
            else if (itemName.Contains("StringDivide"))
            {
                pluginName = "型号分解";
            }
            return pluginName;
        }
        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
