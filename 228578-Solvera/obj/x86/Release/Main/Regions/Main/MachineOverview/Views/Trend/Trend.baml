   M S B A M L   `   `   `  ����   228578-Solvera#    HMI.MainRegion.MO.Views.Trend   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  $
��1832��$
��1000��   FP_Black_Gradient#��[  .��� -     �Name$  
LayoutRoot�� � RowDefinitions �� $	��110 ��� $��* �.+�� $��1�� �� �� $
��Auto ��� $
��Auto �.+�!  VisiWin.Controls.TrendChart  -     Name$ 
TrendChart��$��10q�   VisiWin.Controls.ChartBase   IsTranslateYEnabled .  .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command ��  �� Path$ LoadChartInstance�	 �� Mode$	 OneWay=�
   CommandParameter
 %  System.Windows.Markup.Reference     Name$ 
TrendChart��   Markers "  VisiWin.Controls.ChartMarker     LineThickness$ 2Q�   
IsSelected .    CurvesContainers 3	  -VisiWin.Controls.TrendCurvesContainerDateTime	  -    	 Name$ DateTimeCurveContainer���
  �VisiWin.Controls.CurvesContainerBase2`2[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  
ScaleBrush
 ����� 
  Range ��  �� ElementName$ resolutionComboBox��$ SelectedValue�$	 TwoWay=��  �VisiWin.Controls.TrendCurvesContainerBase`2[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Curves "  VisiWin.Controls.TrendCurve2  -     Name$ curve1��  FP_Blue�  �VisiWin.Controls.CurveBase2`2[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	LineColor# �     LineThickness$ 2Q�   IsScaleVisible .     ArchiveName �� *TrendData.ArchiveName+   	TrendName �� *TrendData.TrendName_1+
 � Tag �� *TrendData.CurveTag_1+   MinValue �� *
MinValue+   MaxValue �� *
MaxValue+  -   $ curve2�� 
 FP_Red# �  $ 2Q�   
ScaleBrush
 �����   	LineStyle$	 Dot=� �� *TrendData.ArchiveName+ �� *TrendData.TrendName_2+ �� *TrendData.CurveTag_2+ �� *
MinValue+ �� *
MaxValue+�� $��1��$��Center=�$��Stretch=�  �� Orientation$  
Horizontal=�$��10q�.+�  VisiWin.Controls.ComboBox  -   !  Name$! resolutionComboBox��  CB_Main#���  "   LocalizableLabelText$" @TrendSystem.Text17��$	��Top=�$	��250��$��45��$��0,0,1,0q�# �� SelectedIndex$# 0������ *Resolutions+#  VisiWin.Controls.NumericVarIn  -   $  Name$	$ min��$��5,0,0,0q�$��45��$	��120��  NVI_Main#���  *  $VisiWin.Controls.VariableBaseControl%   LocalizableLabelText$% @TrendSystem.Text8��&   LocalizableUnitText$& @Units.grad��'   Value' �� *
MinValue+$ curve1��$	 TwoWay=�  -   $	$ max��$��5,0,0,0q�$��45��$	��120��#���  $% @TrendSystem.Text9��$& @Units.grad��' �� *
MaxValue+$ curve1��$	 TwoWay=�  VisiWin.Controls.Button   
 B_Gray#���  (   Text$( <<��$��45��$	��150��$��40,0,0,0q�$
��-0.7������ *ShiftXCommand+$ 
TrendChart��  #���  $( <��$��45��$	��150��$��10,0,0,0q�$
��-0.1������ *ShiftXCommand+$ 
TrendChart��  #���  $( >��$��45��$	��150��$��10,0,0,0q�$	��0.1������ *ShiftXCommand+$ 
TrendChart��  #���  $( >>��$��45��$	��150��$��10,0,0,0q�$	��0.7������ *ShiftXCommand+$ 
TrendChart��#  VisiWin.Controls.ToggleButton    TB_Main#���  $	��150��$��40,0,5,0q�$��45��)   LocalizableTextOn$) @TrendSystem.Text10��*   LocalizableTextOff$* @TrendSystem.Text11��+   CornerRadius$+ 4��, d� 	IsChecked, �� *
IsOnline+$ DateTimeCurveContainer��  $y�	Collapsed=�$��45��$	��150��#���  $��	150,0,0,0q�-   LocalizableText$- @Buttons.Text60��$��Center=�$��Right=�&   System.Windows.Controls.DataGrid  $��2��$��	10,10,5,5q�$��2q�  FP_BorderBrush#���    DG_Standart#���  $��2������ *CurveInformations+.   Columns. 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn/   Width5  /System.Windows.Controls.DataGridLengthConverter$
/ Auto 0   MinWidth$	0 100Q�1   Header1 6  0VisiWin.Extensions.LocalizedTextBindingExtension  2   LocalizableText$2 @TrendSystem.Text12��1  +System.Windows.Controls.DataGridBoundColumn3   Binding3 �� $ LocalizedArchiveName�  $
/ Auto $	0 150Q�1   $2 @TrendSystem.Text13��3 �� $ LocalizedTrendName�  $	/ 100  	 TB_Trend4   ElementStyle#4 [	 1   $2 @TrendSystem.Text14��  $/ *  
 	TB_Center#4 [
 1   $2 @TrendSystem.Text15��3 �� $ MarkedXValues�  $/ * #4 [
 1   $2 @TrendSystem.Text16��3 �� $ MarkedYValues��   FP_Blue_Gradient#���  5 J� Effect5 3  -System.Windows.Media.Effects.DropShadowEffect  6   Color$6 White��7   	Direction$	7 270Q�8   Opacity$	8 0.7Q�.+�   VisiWin.Controls.TextBlock  -	   9  Name$9 header��$��Center=�
�������$
��Bold"�$��48(�$��50,0,0,0q�:   LocalizableText: �� *TrendData.Header+  $	��160��$��90��  	B_Gray_ns#���  $��	0,10,10,0q�$- @Buttons.Text56��$	��Top=�$��Right=����� *Back+