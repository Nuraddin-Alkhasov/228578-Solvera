   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   S_Status  �� 
TargetType   VisiWin.Controls.Switch �� Property �� Value#  VisiWin.Controls.ToggleButton  ButtonBackgroundBrush  ButtonBlinkBrush  ButtonPressedBorderBrush �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration		 �� To
 �� TargetProperty �� 
TargetName  LabelFeeder � ColumnDefinitions  
LabelWidth   CornerRadius �� CornerRadius  FP_LightGreen   TextOn 
 FP_Red   TextOff ��Name  FP_Blue&   VisiWin.Controls.SymbolPresenter    SymbolHorizontalAlignment J� IsHitTestVisible   SymbolMargin J� SnapsToDevicePixels   SymbolResourceKey   SymbolResourceKey   Symbol   Symbol � UseLayoutRounding   SymbolVerticalAlignment 	 LabelMargin �� TextAlignment   	LabelText 
 ConnectionErrorBorderBrush " ConnectionErrorBackgroundBrush  Name  ConnectionErrorSymbol �� 	UriSource  �� Triggers! P� Property" P� Value# �� 
TargetName$ ]� 
Conditions% �� Property& �� Value' �� RelativeSource�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      &vwhttp://inosoft.com/visiwin7   %_	  &	        �� "    .���  � ��$ 1q���  �@ CornerRadius$ 3����  � ��$ Segoe UI)���  � ��$ SemiBold"���  �@ 	LabelText$  ����  �@ TextOn$ ON����  �@ TextOff$	 OFF����  � ��$ 16(���  � ��# �  ��  �@ 
BlinkBrush# �  ��  � ��# �  �� ! �@ SymbolHorizontalAlignment$ Center=���  �@ SymbolMargin$ 0,0,0,0q���  � ��$ Center=���  � ��$ Center=���  � ��$ 0,0,10,0q���  � �� �� "   .R�� $ RootGrid��   CheckStates��.   Checked��. �� .���� $ 0D�$	 2X�$
 (Grid.Column)�$ Slider��  	Unchecked��. �� .���� $ 0D�$	 0X�$
 (Grid.Column)�$ Slider��  Indeterminate��. �� .���� $ 0D�$	 1X�$
 (Grid.Column)�$ Slider��.+�� $ Switch��#���   �� #���  �� $��* �.+�� $ 
SliderPart��$��1�� �� $��0.25* ��� $��0.25* ��� $��0.25* ��� $��0.25* �.+��� #��z��#��z��$��4��$��0��# z #��z��._��  �� $
��0.5* ��� $
��0.5* �.+��� #��z��$��0q�#���  $��0��$ 2,0,0,2��._��� 
�������$��Center=�#��z $��Center=��� #��z��$��0q�#���  $��1��$ 0,2,2,0��._��� 
�������$��Center=�#��z $��Center=��� $ Slider��#��z��#��z��#���  $��2��$��2��# z $
��-1,0q�._�� .+�  $��0��#��z  .  #��z # z # z # z # z #��z �� 
������ $��0��#��z�� .  #��� 	 $ Right=�#��z #��z��#��z��$��SemiBold"�$��16(��� $ ConnectionError��#��� 
 $��1q�#���  $��4��$��0��$ 5��$��-4q�$y�	Collapsed=�  $ ConnectionErrorSymbol��$��4��$��0��$��Right=�$��0,-17,-10,0q�# �  $y�	Collapsed=�$	��Top=����� .R��� $��24��$
��Fill=�$��24������ $\ Vpack://application:,,,/VisiWin7.Styles.WPF;component/Images/connection_error_24x24.png?�  P� ! � {�" .  . ��� $# 
SliderPart�� �@J�Opacity$ 1Q�P� ! �@ IsQualityGood" .  . ��� $# ConnectionError�� � y�$ Visible=��� $# ConnectionErrorSymbol�� � y�$ Visible=�]� $ �� % �@ 	BlinkMode$& 
BlinkBrush=��� % �@ 
BlinkState& . ./��� $# Slider�� �� *
BlinkBrush+' �� *TemplatedParent+ � ��]� $ �� % �@ 	BlinkMode$& 
Visibility=��� % �@ 
BlinkState& . ./��� $# 
SliderPart�� � y�$ Hidden=�