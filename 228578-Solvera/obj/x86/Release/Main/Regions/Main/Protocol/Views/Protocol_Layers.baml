   M S B A M L   `   `   `  ����   228578-Solvera3    -HMI.MainRegion.Protocol.Views.Protocol_Layers   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1832��$	��890��.��� -     �Name$  
LayoutRoot��$��0q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�  VisiWin.Controls.GroupBox     GB_Group#���   $��2��   LocalizableHeaderText$ @Protocol.Text27��.��&   System.Windows.Controls.DataGrid  -     Name$ 
dgv_errors��   ColumnHeaderHeight$ 50Q�   	RowHeight$ 45Q�  DG_Standart#���  ���� *SelectedRun.ErrorList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100   TB_Right1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  	   Header	 6  0VisiWin.Extensions.LocalizedTextBindingExtension  
   LocalizableText$0
 *@[ClientSystem].Components.AlarmList.Count��   Binding �� *	ErrorNr+  $	 250   	TB_Center# �  	   $9
 3@[ClientSystem].Components.AlarmList.ActivationTime�� �� *ActivationTime+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��  $	 250 # �  	   $;
 5@[ClientSystem].Components.AlarmList.DeactivationTime�� �� *DeactivationTime+$ dd.MM.yyyy HH:mm:ss��4  .System.Windows.Controls.DataGridTemplateColumn  $ * 	   $/
 )@[ClientSystem].Components.AlarmList.Text��   CellTemplate �� .R� 	  VisiWin.Controls.TextBlock	  $
��Left=�$��Center=� 	  LocalizableText �� *LocalizableText+  $	 200 	   $
 @Protocol.Text10�� �� *User+  #���   $��1��$ @Protocol.Text3��.��  -   $ dgv_runs��$	��311��$ 50Q�$ 45Q�#���  "   VerticalScrollBarVisibility$ Hidden=�$   HorizontalScrollBarVisibility$ Visible=����� *SelectedCharge.RunList+ �� SelectedItem �� *SelectedRun+ �� Mode$ TwoWay=�����  �� 
TargetType)
  #System.Windows.Controls.DataGridRow" 
 .�-    �� Triggers ��  �� Binding �� *	IsError+ �� Value True.a���  �� Property � ��  FP_Red_Gradient �� Value# �     $ 90 # �  	   $
 @Protocol.Text23�� �� *RunNr+  $	 120 	   $
 @Protocol.Text15�� �� .R�  VisiWin.Controls.Button  -   $��1��  	B_Gray_ns#���  $��-5q�$��35��  $	 200 # �  	   $
 @Protocol.Text5�� �� *Start+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text30�� �� *C_S+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text31�� �� *C_E+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text59�� �� *PZ_S+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text60�� �� *PZ_E+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text32�� �� *WZ_S+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text33�� �� *WZ_E+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text34�� �� *HZ_S+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text35�� �� *HZ_E+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text28�� �� *CZ_S+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text29�� �� *CZ_E+$ dd.MM.yyyy HH:mm:ss��  $	 200 # �  	   $
 @Protocol.Text4�� �� *End+$ dd.MM.yyyy HH:mm:ss��  $	 250 	   $
 @Protocol.Text10�� �� *User+  #���   $ @Protocol.Text21��.��� $��5,10,0,5q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �.+�!  VisiWin.Controls.TextVarOut    TVO_Main#���  $��0��$��0��$��45��*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @Protocol.Text6��$��0,0,5,0q�   Value �� *SelectedOrder.Data_1+  #���  $��1��$��0��$��45��$ @Protocol.Text7��$��0,0,5,0q� �� *SelectedOrder.Data_2+  #���  $��2��$��0��$��45��$ @Protocol.Text8��$��0,0,5,0q� �� *SelectedOrder.Data_3+  #���  $��3��$��0��$��45��$ @Protocol.Text10��$��0,0,5,0q� �� *SelectedCharge.User+  #���  $��0��$��1��$��45��$ @Protocol.Text5��$��0,5,5,0q� �� *SelectedCharge.Start+  #���  $��1��$��1��$��45��$ @Protocol.Text4��$��0,5,5,0q� �� *SelectedCharge.End+  #���  $��2��$��1��$��45��$ @Protocol.Text25��$��0,5,5,0q� �� *SelectedBox.BoxNr+  #���  $��3��$��1��$��45��$ @Protocol.Text26��$��0,5,5,0q� �� *SelectedCharge.ChargeNr+