   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   CB_Main  �� 
TargetType   VisiWin.Controls.ComboBox �� Property  InputBackgroundBrush �� Value  InputFontBrush  FP_BorderBrush �� 
TargetType �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode	 �� RelativeSource5   /Microsoft.Windows.Themes.SystemDropShadowChrome
  Name   Color �� MaxDropDownHeight �� ElementName ��Name#  VisiWin.Controls.ScrollViewer  Name �� ClearTypeHint ��Name ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  VisiWin.Controls.Border  Name �� CornerRadius ��Name �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible J� SnapsToDevicePixels   VisiWin.Controls.TextBlock  Name    LocalizableLabelText    LocalizableText! J� Opacity#  VisiWin.Controls.ToggleButton"  Name# d� 	IsChecked$ F�Name% �� Triggers& P� Property' P� Value( �� 
TargetName) J� Effect3  -System.Windows.Media.Effects.DropShadowEffect  ShadowDarkBottomColor*   Color+ P� 
SourceName, �� Value- �� Binding. �� Path 
 FP_Red/ N� EnterActions0 ��Name1 �� 
TargetName2 �� TargetProperty	3 �� To4 g� Duration5 g� AutoReverse6 g� RepeatBehavior7 N� ExitActions8 �� BeginStoryboardName  OutputBackgroundBrush�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     &vwhttp://inosoft.com/visiwin7   VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  .sys&clr-namespace:System;assembly=mscorlib  %H  &	        �� "    .���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 2q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 0,0,30,0q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � ��$
 Left=���  � ��$ Center=���  � ��$ 14(���  � ��$ Segoe UI)���  � ��$ SemiBold"���  � �� �� "   .R�� $ templateRoot�� �� $
��Auto ��� $��* �.+�� $ 
PART_Popup�� . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+$ TwoWay=�	 �� *TemplatedParent+.��  $
 shadow��$ Transparent��#��z ���� *ActualWidth+$ templateRoot��._��� $ DropDownBorder��#��z��$��2q�$��2,-2,2,0q�#��� ��._�  $ DropDownScrollViewer��$��Visible=�$��Hidden=�$	��240��.��� $
 grid��$ Enabled=�.+��� $ canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $ 
OpaqueRect������ *
Background+$ DropDownBorder������ *ActualHeight+$ DropDownBorder������ *ActualWidth+$ DropDownBorder���� $ ItemsPresenter��$ 	Contained=�  $ 
background��$��3��#��z��#��z��$ 3��#��z���� $
 Text��$��1��#��z #��z # z $��Right=� .  #��z��# z $��Center=�  $ header��#  z $��Center=�$	! 0.7Q�$
��Bold"�$��10,0,0,0q�#��z��#��z��#��z��  $" toggleButton��$��2��
������ # �� *IsDropDownOpen+$ TwoWay=�	 �� *TemplatedParent+���� "   .���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � ��
 ���� ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ templateRoot��#��z��$ 2��$��0q�._�F� $$ Arrow��"����        р��     �@KL ��� 	#��z��$��Right=�$��Center=�$��0,0,10,0q�% P� & �@d�	IsChecked$
' TrueY�. ��� $( Arrow�� � ��" ��    ��� р�� ��� �@KL     	�� $( Arrow�� � ��
 ������� $ Shadow��
���   �$��Bottom=�$��2��$y�Hidden=�$��1��$��2,0,2,0q�)   #* �  % P� $+ 
PART_Popup��& �@�HasDropShadow' . . ��� $( shadow�� � ��$ 0,0,5,5q��� $( shadow�� �@ Color$ 	#71000000���� $
, True��- �� $ toggleButton��$. 	IsChecked�.a���  � ��
 �������  � ��
 ������� $( 
background��# �   � ���� $( header�� �@J�Opacity$ 1Q��� $( Shadow�� � y�$ Visible=�P� & �@��SelectedIndex$' -1��/ �� $0 flash��.���� .���� $1 
background��$12 +(Border.Background).(SolidColorBrush.Color)�$3 	#FFBE2828X�$4 0:0:1D�5 . $6 Forever��7 �� $8 flash��P� & �@��HasItems' .  . ��� $( DropDownBorder�� � ��$ 0��P� & � {�' .  . ��� # �   � ��P� & �@�Tag' ��-��. ��� $( header�� � y�$ 	Collapsed=�