   M S B A M L   `   `   `  ����   228578-Solvera(    "HMI.DialogRegion.MO.Views.MO_PZ_EF   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   -   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$	��500��$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @MachineOverview.Text91��$	��400��  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q��� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2��� -   $	 grd��$��2��$��	10,0,10,0q� �� $��* ��� $��* ��� $��* ��� $��* �.+�  VisiWin.Controls.GroupBox     LocalizableHeaderText$ @MachineOverview.Text87��  GB_Group#���  $��1��.����  �� Orientation$ 
Horizontal=�$��Center=�$��5,10,5,5q�.+�$  VisiWin.Controls.NumericVarOut  -     Name$ 
NSTime_Min��  NVO_Main#���  $	��220��$��45��   LocalizableUnitText$ @Units.m��*  $VisiWin.Controls.VariableBaseControl   VariableName$i cCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Exhaust fan.State.Restart.Minute��  -   $ 
NSTime_Sec��#���  $	��220��$��45��$��5,0,0,0q�$ @Units.s��   FormatString$ 0��$i cCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Exhaust fan.State.Restart.Second��  -     Name$ Purge��$y�	Collapsed=�$ @MachineOverview.Text88��#���    FP_Yellow_Gradient#���  $��1��.���� $ 
Horizontal=�$��Center=�$��5,10,5,5q�.+�  -	   $ 	PTime_Min��#���  $	��220��$��45��$ @Units.m��$ 0��$g aCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Exhaust fan.State.Purge.Minute��  -
   $ 	PTime_Sec��#���  $	��220��$��45��$��5,0,0,0q�$ @Units.s��$ 0��$g aCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.Actual.Exhaust fan.State.Purge.Second��!  VisiWin.Controls.TextVarOut  -     Name$	 PS1��  FP_Gray_Gradient   
BlinkBrush# �  
�������  FP_Blue_Gradient#���  $��2q�$��2��$��60��$��60��   CornerRadius$ 30��$��Right=�$��Center=�$��
0,20,50,10q�   LocalizableLabelText$ @MachineOverview.Text89��$ __UNLINKED_BSTR��  -   $	 PS2��# �  
�������#���  $��2q�$��3��$��60��$��60��$ 30��$��Right=�$��Center=�$��	0,0,50,10q�$ @MachineOverview.Text90��$ __UNLINKED_BSTR���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* �.+�	  VisiWin.Controls.Key	  -    	 Name$
 V_On��   LocalizableText$ @Buttons.Text19�� 
	 B_Gray#��� 	 $��50��$	��200�� 	  KeyMode$ KeyMode=� 	  VariableName$S MCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.PC.Exhaust fan.On��   AuthorizationRight$ Exhaust��	  -   $ V_Off��$ @Buttons.Text17��$��1�� 	
 B_Red#��� 
 $��50��$	��200��$ KeyMode=�$T NCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Air.DB PZ Air HMI.PC.Exhaust fan.Off��$ Exhaust��