   M S B A M L   `   `   `  ����   228578-Solvera3    -HMI.DialogRegion.Logging.Views.Logging_Filter   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border��$	��700��$	��500�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @Diagnose.Text5��$	��400��  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� -    ��Name$ 
LayoutRoot��$��2��$��2q�$��	10,0,10,0q�
�������
������ ._�� .+��� $��14(� �� TabStripPlacement$
 Left=�$��10,0,0,0q�$��0q�#���  .@��� -    ��Name$
 btn1��$��60��$	��200��  	TI_Filter#���  $��
0,10,0,-10q� �� 
IsSelected �� *
IsSelected+��/  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Diagnose.Text6��.���� $��Center=�$��50,0,0,0q�$	��350��.+�  VisiWin.Controls.ComboBox  $��45��
 � Tag$ -��  CB_Main#���     AuthorizationRight$ Logging������ *TimeSpanFilterTypes+ �� SelectedItem �� *SelectedTimeSpanFilterType+$  VisiWin.Controls.DateTimeVarIn    	DTVI_Main#���  $��0,10,0,0q�*  $VisiWin.Controls.VariableBaseControl   VariableName$ __UNLINKED_DATE��   
FormatDate$ 	@LongDate��   DateTimeMode$ DateTime=�$��45��   LocalizableLabelText$ @Diagnose.Text7��   
FormatTime$ 
@ShortTime��   AuthorizationRight$ Logging��   Value �� *	MinTime+ �� Mode$ TwoWay=�{��� *CustomTimeSpanFilterEnabled+  #���  $��0,10,0,0q�$ __UNLINKED_DATE��$ 	@LongDate��$ DateTime=�$��45��$ @Diagnose.Text8��$ 
@ShortTime��$ Logging�� �� *	MaxTime+$ TwoWay=�{��� *CustomTimeSpanFilterEnabled+�� -   $
 btn2��$��60��$	��200�� . #���  $��
0,20,0,-20q���  $% Logging.LoggingFilterView.Users��.��� $	��440�� �� $��60 ��� $	��270 �.+�	  VisiWin.Controls.CheckBox	  $��10,0,0,0q�#
  VisiWin.Controls.ToggleButton 
  LocalizableLabelText$( "Logging.LoggingFilterView.AllUsers��$��40�� 
  AuthorizationRight$ Logging�� d� 	IsChecked �� *IsAllUsersSelected+  VisiWin.Controls.ListBox  $��1��$��10q�  FP_BorderBrush#���  $��2q�    AuthorizationRight$  Logging������ *DesiredUsers+{��� *IsUserSelectionEnabled+���� .R�	  $��35��$��10q�! 
  	LabelText! �� *
FullName+ �� *
IsSelected+�� $
��Left=�$��Stretch=�#���  $��	210,0,0,0q�$��4���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��" � ColumnDefinitions" �� $��* ��� $��* �.+�  $��0��$��50��$	��200��#   LocalizableText$# @Buttons.Text61��$
��Left=�  	B_Blue_ns#���  ���� *Filter+  $��1��$��50��$	��200��$# @Buttons.Text13��$��Right=� 	 B_Red_ns#��� 	 $��	0,10,0,10q����� *Close+