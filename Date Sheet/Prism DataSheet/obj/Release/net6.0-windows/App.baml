   M S B A M L   `   `   `  ���� J  FPrism DataSheet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Prism_DataSheetPrism_DataSheet      Prism_DataSheet.App   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:Prism_DataSheet     [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/     �� 	Resources     FormButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value	 �� Padding  MenuButtonStyle
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   	Direction   Opacity   ShadowDepth   Color  ScrollBarThumb ! HorizontalScrollBarPageButton  VerticalScrollBarPageButton   VerticalScrollBarPageButton2  for_scrollbar �Name J� SnapsToDevicePixels � RowDefinitions �� PageUpCommand ]�Name J� IsMouseOver ]� DecreaseRepeatButton ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� PageLeftCommand �� PageRightCommand  for_scrollviewer � Cursor ��Name �� ScrollableHeight � Maximum  �� Orientation! �� ViewportHeight" �� ViewportSize*# �� #ComputedVerticalScrollBarVisibility$ �� VerticalOffset% � Value& �� ScrollableWidth' �� ViewportWidth,( �� %ComputedHorizontalScrollBarVisibility) �� HorizontalOffset* �� Triggers+ :� RoutedEvent, �� 
TargetName- �� TargetProperty	. W� To/ g� Duration0 g� 	BeginTime1 :� 
SourceName2 �� BasedOn-  'System.Windows.Input.KeyboardNavigation3   TabNavigation4 � ColumnDefinitions5 ��Name6 ��Name7 ��Name8 K� ZIndex9 K� IsItemsHost:   TabIndex	; �� X1	< �� X2= �� RelativeSource> ��Name?   DirectionalNavigation@ ��NameA �� SelectedContent"B �� SelectedContentStringFormatC �� ContentStringFormatD �� SelectedContentTemplateE �� 
TargetNameF ��NameG � ToolTipH ^� 
ConditionsI �� BindingJ �� ValueK �� AncestorLevelL �� AncestorType��%V  &	        '�� �    &	 z    &	 M    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7  7  &	 �    7  7  '�� �    7  '�� �    7  '�� �    '��     �� " ��.���  � ��$ ../Fonts/#iconfont)���  � ��
 ���� ��  � �� �#4886ff��  � ��
 �������  � ��$ 1q���  � ��$ 20����  � ��$ 20����  � ��$ 15(���  � ��$
 10,0q���  � �� �� " ��.R��� #��z��#��z��#��z��#��z��$ 15��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#44000000��  � �� �#355e89�� " ��.���  � �� �	#22000000��  � ��
 �   ���  � �� �#3f85ff��  � ��$	 0.5q���  � ��$ 5q���  � ��$ 1q���  � ��$ 24����  � ��$
 10,0q���  � �� �� " ��.R��� #��z��#��z��#	 z��$��Center=�$��Center=�#��z��#��z��$ 4��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#44000000��  � �� �#4886ff�� " ��.���  � �� �#569cd6��  � ��
 �������  � ��
 �������  � ��$ 1q���  � ��$	 100����  � ��$ 20����  � ��$ 15(���  � ��$	 2,0q���  � �� �� " ��.R��� #��z��#��z��#��z��#��z��$ 5 5 0 0��
   $ 5Q�$ 0Q�$	 0.3Q�$ 0Q�$ #569cd6��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#91cafa��  � �� �#355e89�� " n�.���  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � �� �� " n�.R�� .+��� ���#646465$ 3���� " ��.���  �@�OverridesDefaultStyle$
 true����  � ��
 ���� ��  � |�$ false����  � ��$ false����  �@J�Opacity$	 0.2Q���  � �� �� " ��.R��� #��z��#��z��#��z���� " ��.���  �@�OverridesDefaultStyle$
 true����  � ��
 ���� ��  � |�$ false����  � ��$ false����  �@J�Opacity$	 0.2Q���  � �� �� " ��.R��� #��z��#��z��#��z���� " ��.���  �@�OverridesDefaultStyle$
 true����  � ��
 ���� ��  � |�$ false����  � ��$ false����  �@J�Opacity$ 0Q���  � �� �� " ��.R��� $��0��$��0�����	#90000000�� " ��.���  �@��IsPressAndHoldEnabled$ false����  �@��IsFlicksEnabled$ false����  � ��
 ���� ��  � ��$ 0,1,1,6q���  � ��$ 10����  � ��$ 5����  �@J�Opacity$	 0.2Q���  � �� �� " ��.R�� $ Bg��$
 true�� �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��#��Z 8��  ]� $ 
PART_Track��$��1��$
��true��#{�z  �� #��Z 8��  �� #��Z 8��  n� 8�� �� $��2��#��Z 8��  P�  �@��Orientation$ 
Horizontal=�. ���  � ��
 ���� ��  � ��$ 1,0,6,1q���  � ��$ 5����  � ��$ 5����  � ��$
 Auto����  �@J�Opacity$	 0.2Q���  � �� �� " ��.R�� $ Bg��$
 true��.+�]� $ 
PART_Track��#{�z  �� #��Z 8��  �� #��Z 8��  n� 8�� �� " ��.���  � ��
 �������  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��$
 True��._�� #��z��.+��� #��z��#��z��# z �� $ PART_VerticalScrollBar��$��Right=�# z $  Vertical=�8��  #" z! #y�z# #% z$ �� $ PART_HorizontalScrollBar��$��Bottom=�# z& $  
Horizontal=�8�� #" z' #y�z( #% z) * :� $+ ScrollChanged��.[��� .���� .��W� $, PART_VerticalScrollBar��$- Opacity�. 0.8$/ 0:0:1D�W� 	0 0:0:1$, PART_VerticalScrollBar��$- Opacity�. 0.2$/ 0:0:1D�W� $, PART_HorizontalScrollBar��$- Opacity�. 0.8$/ 0:0:1D�W� 	0 0:0:1$, PART_HorizontalScrollBar��$- Opacity�. 0.2$/ 0:0:1D�:� $+ 
MouseEnter��$1 PART_VerticalScrollBar��.[��� .���� .��W� $, PART_VerticalScrollBar��$- Opacity�. 0.8$/ 0:0:0.7D�:� $+ 
MouseLeave��$1 PART_VerticalScrollBar��.[��� .���� .��W� $, PART_VerticalScrollBar��$- Opacity�. 0.2$/ 0:0:0.7D�:� $+ 
MouseEnter��$1 PART_HorizontalScrollBar��.[��� .���� .��W� $, PART_HorizontalScrollBar��$- Opacity�. 0.8$/ 0:0:0.7D�:� $+ 
MouseLeave��$1 PART_HorizontalScrollBar��.[��� .���� .��W� $, PART_HorizontalScrollBar��$- Opacity�. 0.2$/ 0:0:0.7D��� 82   " ���� 82   " ���� " ��.���  � ��$ 2q���  � ��$ Center=���  � ��$ Center=���  � ��
 �������  � �� �	#FFACACAC��  � ��$ 1q���  � ��# � ����  � �� �� " ��.R�� $ templateRoot��$
}�True��$3 Local=�$
 True��4 �� $5 ColumnDefinition0���� $5 ColumnDefinition1��$��0 � �� $6 RowDefinition0��$
��Auto ��� $6 RowDefinition1��$��* �.+��� $7 HeaderPanel��$��0��$��0��$��0q�$��Center=�$8 1��
������ $
9 True��$: 1���� $��0,0,0,1q�$��Bottom=�$
 True��
�������$	��0.1��$; 0��< �� *ActualWidth+= �� *Self+�� $> ContentPanel��$��1��$��0��#��z��#��z��#��z��$? 	Contained=�$: 2��$3 Local=�._��� $@ PART_SelectedContentHost��$��0q�#��zA $��SelectedContent��#C zB #��zD # z * P�  �@��TabStripPlacement$ Bottom=�. ��� $E HeaderPanel�� � ��$ 1���� $E ContentPanel�� � ��$ 0���� $E RowDefinition0�� � ��$ * ��� $E RowDefinition1�� � ��$
 Auto �P�  �@��TabStripPlacement$
 Left=�. ��� $E HeaderPanel�� � ��$ 0���� $E ContentPanel�� � ��$ 0���� $E HeaderPanel�� � ��$ 0���� $E ContentPanel�� � ��$ 1���� $E ColumnDefinition0�� � ��$
 Auto ��� $E ColumnDefinition1�� � ��$ * ��� $E RowDefinition0�� � ��$ * ��� $E RowDefinition1�� � ��$ 0 �P�  �@��TabStripPlacement$ Right=�. ��� $E HeaderPanel�� � ��$ 0���� $E ContentPanel�� � ��$ 0���� $E HeaderPanel�� � ��$ 1���� $E ContentPanel�� � ��$ 0���� $E ColumnDefinition0�� � ��$ * ��� $E ColumnDefinition1�� � ��$
 Auto ��� $E RowDefinition0�� � ��$ * ��� $E RowDefinition1�� � ��$ 0 �P�  � {�$ False��. ��� $E templateRoot��# � �� � ���� " ��.���  � ��
 �   ���  � ��
 ���� ��  � �� �	#FFACACAC��  � ��$ 0q���  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R�� $ templateRoot��
������ $
 True��.+��� $> 
_underline��#��z�����#4886ff$��0q�� .+��� $	F txt��$��Center=�$��Center=�#��z��#��z��$��CharacterEllipsis=�#G z��$y�Visible=�* ^� H �� I �� *IsMouseOver+= �� *Self+J true�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��J Top.0��� $	E txt�� � �� �#4886ff^� H �� I �� *	IsEnabled+= �� *Self+	J false�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��J Left.0��� $E templateRoot�� �@J�Opacity$
 0.56Q�^� H �� I �� *	IsEnabled+= �� *Self+	J false�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��
J Bottom.0��� $E templateRoot�� �@J�Opacity$
 0.56Q�^� H �� I �� *	IsEnabled+= �� *Self+	J false�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��	J Right.0��� $E templateRoot�� �@J�Opacity$
 0.56Q�^� H �� I �� *	IsEnabled+= �� *Self+	J false�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��J Top.0��� $E templateRoot�� �@J�Opacity$
 0.56Q�^� H �� I �� *
IsSelected+= �� *Self+J true�� I �� *TabStripPlacement+= �� *FindAncestor+$K 1��"L ��J Top.0���  �@K�ZIndex$ 1���� $	E txt�� � �� �#4886ff�� $E 
_underline�� � ��$ 0,0,0,2q�