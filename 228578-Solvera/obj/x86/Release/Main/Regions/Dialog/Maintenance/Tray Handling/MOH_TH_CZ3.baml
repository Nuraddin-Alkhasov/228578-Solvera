   M S B A M L   `   `   `  ����   228578-Solvera3    -HMI.DialogRegion.Maintenance.Views.MOH_TH_CZ3   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  -   
������ $��0q�� -    �Name$ border��$	��700��$	��500�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @Maintenance.Text78��$	��400��  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q��� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� -    ��Name$ 
LayoutRoot��$��	10,0,10,0q�$��2��$��2q�
�������
������ ._�� .+��� $��14(� �� TabStripPlacement$
 Left=�$��10,0,0,0q�$��0q�#���  .@��� -    ��Name$
 btn1��$��60��$	��200�� �� 
IsSelected .   	TI_Filter#���  $��
0,10,0,-10q���/  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Maintenance.Text61��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @Maintenance.Text13��.����  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+�#  VisiWin.Controls.NumericVarIn    NVI_Main#���  $	��120��$��45��$��0,0,0,0q�   LocalizableUnitText$ @Units.h��*  $VisiWin.Controls.VariableBaseControl   VariableName$~ xCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Circulating fan.Operating hours.Maintenance.Hours��   AuthorizationRight$ MaintenanceOH��  #���  $	��120��$��45��$��10,0,0,0q�{�.  $ @Units.m���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ 
Horizontal=�$��Center=�$��Center=�.+�$	  VisiWin.Controls.NumericVarOut	    NVO_Main#���  $	��120��$��45��$��0,0,0,0q� 	  LocalizableUnitText$ @Units.h��${ uCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Circulating fan.Operating hours.Temporary.Hour��	  #���  $	��120��$��45��$��10,0,0,0q�$ @Units.m��$} wCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Circulating fan.Operating hours.Temporary.Minute���� -   $
 btn2��$��60��$	��200�� . #���  $��
0,20,0,-20q���  $ @Maintenance.Text85��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ 
Horizontal=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$u oCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Cooler.Operating hours.Maintenance.Hours��$ MaintenanceOH��  #���  $	��120��$��45��$��10,0,0,0q�{�.  $ @Units.m���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$r lCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Cooler.Operating hours.Temporary.Hour��	  #���  $	��120��$��45��$��10,0,0,0q�$ @Units.m��$t nCPU2.PLC.Blocks.04 Tray handling.07 CZ.03 Air 3.DB CZ Air 3 HMI.Actual.Cooler.Operating hours.Temporary.Minute���� $
��Left=�$��Stretch=�#���  $��	210,0,0,0q�$��4���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��.+�  -   $��50��$	��200��$
��Left=�   LocalizableText$ @Buttons.Text2��  	B_Blue_ns#���     AuthorizationRight$ MaintenanceOH��  -	   $��50��$	��200��$��Right=�$ @Buttons.Text13��  B_Red_ns#���  $��	0,10,0,10q�