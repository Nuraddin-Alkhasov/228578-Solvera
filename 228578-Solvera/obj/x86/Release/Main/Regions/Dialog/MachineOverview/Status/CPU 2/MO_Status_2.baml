   M S B A M L   `   `   `  ����   228578-Solvera+    %HMI.DialogRegion.MO.Views.MO_Status_2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�$	��400��
   LocalizableText
 �� *Header+  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$
��10,0q�.+�  VisiWin.Controls.GroupBox    	GB_Group2#���     LocalizableHeaderText$ @Status.Text2��.��� $��5,5,5,5q� � ColumnDefinitions �� $��* ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��0��$��0,0,5,0q�.+�!  VisiWin.Controls.TextVarOut  $��45��  TVO_Main#���  *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @Status.Text6��   Value �� *Data_1+  #���  $��45��$��0,5,0,0q�$ @Status.Text7�� �� *Data_2+  #���  $��45��$��0,5,0,0q�$ @Status.Text8�� �� *Data_3+  $��1��$��2��$��45��#���  $ @Status.Text9��$��0,5,0,0q� �� *MR.Header.Name+�� $��1��  FP_BorderBrush#���  $	��145��$	��145��$��2q�$ 4��
�������$	��Top=�._�!  VisiWin.Controls.PictureBox  $��4��$��2q�$��Center=�$��Center=�   SymbolResourceKey �� *MR.Article.Info.Art.Image+� .+�  #���  $ @Status.Text3��$��0,0,0,0q�.���  �� $��* ��� $��* �.+��� $��0��$��0,0,0,0q�.+�  #���  $��0,0,0,0q�$��Bottom=�$ @Status.Text13��.����  �� Orientation$ 
Horizontal=�$	��0,5q�$	��315��.+�#	  VisiWin.Controls.NumericVarIn	  $��45��  NVI_Main#���  $	��150��$ @Status.Text14��$��5,0,0,0q�   VariableName$Q KCPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Charge.Layers.Set�� 	  RawLimitMin$ 0Q� 	  RawLimitMax$ 5Q�   AuthorizationRight$ Status��	  $��1��$��45��#���  $	��150��$ @Status.Text76��$��5,0,0,0q�$T NCPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Charge.Layers.Actual��$ 0Q�$ 5Q�$ Status��  $��45��#���  $	��305��$��0,5,0,0q�$ @Status.Text1�� �� *Box+  $��45��#���  $	��305��$ @Status.Text3��$��0,5,0,5q� �� *Charge+�� $��1��$��0,0,0,0q�.+�  #���  $��0,0,0,0q�$��Bottom=�$ @Status.Text16��.���� $��5,5,5,5q�$	��315��.+�
  VisiWin.Controls.ComboBox
  $��45��  CB_Main#���  {�.   
  LocalizableLabelText$ @Status.Text76��$��0,0,0,0q� 
  VariableName$S MCPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Charge.Paint.Actual�� 
  	StateList �� *
PaintTypes+
  $��45��#���  $ @Status.Text75��$��0,5,0,0q� 
  AuthorizationRight$ Status��$Q KCPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Data.Charge.Paint.Next�� �� *
PaintTypes+$  VisiWin.Controls.NumericVarOut  $��46�� 	 NVO_Main#��� 	 $	��200��$ @Status.Text11��   LocalizableUnitText$ 	@Units.kg��$��Right=�$	��Top=�$��0,3,3,0q�   FormatString$	 0.0��$ __UNLINKED_R4��   Value �� *Weight+  VisiWin.Controls.Region  ���� *	Content+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� �� $��* ��� $��* �.+�  $��0��$��50��$	��200��   LocalizableText$ @Buttons.Text8��$
��Left=� 
 	B_Blue_ns#��� 
    AuthorizationRight$ Status������ *Update+{�1  +VisiWin.Extensions.VariableBindingExtension      VariableName$B  <CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Release��  $��1��$��50��$	��200��$ @Buttons.Text9��$��Right=�  B_Red_ns#���  $��	0,10,0,10q�$ Status������ *Delete+{�  $B  <CPU2.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.Status.to.Release��