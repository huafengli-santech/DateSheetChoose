   M S B A M L   `   `   `  ????   Prism DataSheet&     Prism_DataSheet.Views.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   -     ?Name$  window??!  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True ? WindowStartupLocation$ CenterScreen=? ? WindowStyle$
 None=? ? AllowsTransparency$
 True?? ? 
ResizeMode$ NoResize=?$	??600??$	??800?? ? Title ?? *Title+??Z? .???? -   
??????? ?? CornerRadius$ 5??$??5q? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   
BlurRadius$	 5Q?
   Color$
 #e6e6e6??   Opacity$ 1Q?   	Direction$ 0Q?   ShadowDepth$ 0Q?._??  ? RowDefinitions ?? $
??0.1* ??? .+?? $??0?? ? ColumnDefinitions ?? ?? .+??? $??0??
?????? $??5q????? *	Modules+ ?? SelectedItem ?? *
ModuleInfo+???? .R??? $
??50 5q????? *DisplayName+???? .R??  ? Orientation$ 
Horizontal=???  ?? Orientation$ 
Horizontal=?$??1??$??Right=?.+???  ? ToolTip$ 	最小化??   FormButtonStyle#??[  $??18(?$	??―?????? *
MinCommand+????  ?? ElementName$ window???? $ 	最大化??#??[  $??18(?$
??Bold"?$	??☐?????? *
MaxCommand+???? $ window???? $ 关闭??#??[  $??18(?$??×?????? *CloseCommand+???? $ window???? $??1??
?????? !  Prism.Regions.RegionManager   
RegionName$ ContentRegion??