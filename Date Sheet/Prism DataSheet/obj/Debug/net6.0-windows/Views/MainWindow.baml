   M S B A M L   `   `   `  ����  Prism DataSheet&     Prism_DataSheet.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   -   5          �Name$  window��5   	   $	��800��5   	   $	��600��5   	   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5	   	    � AllowsTransparency$
 True��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � Title 5   	   �� *Title+��5   	   Z� .��5      �� -   5        $��5q�5      
������� �� CornerRadius$ 5��5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 5Q�6   
   	Direction$
 0Q�5         Opacity$ 1Q�5         ShadowDepth$ 0Q�5         Color$ #e6e6e6��5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��0.1* �6    �� 5      .+�5      � $��0��6    � ColumnDefinitions 5       �� 5!      �� 5"      .+�56      �� !  Prism.Regions.RegionManager   
RegionName$ LoadModuleRegion��6!   �� 5:      $��1��6   $��Right=�5;       �� Orientation$ 
Horizontal=�5<      .+�5=      �� $	����5?         FormButtonStyle#��[  5@       � ToolTip$ 	最小化��5A      ��5=      �� *
MinCommand+��5>      ��  �� ElementName$ window��5A      �� 5B      $	����5D      #��[  5E      $ 	最大化��5F      ��5B      �� *
MaxCommand+��5C      �� $ window��5F      �� 5G      $	����5I      #��[  5J      $ 关闭��5K      ��5G      �� *CloseCommand+��5H      �� $ window��5K      5L      5N      �� 5P      $��1��6   $ ContentRegion��5Q      
������ 5R      5S      5T      5U      