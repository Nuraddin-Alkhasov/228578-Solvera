   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   228578-Solvera4   .HMI.DialogRegion.Protocol.Views.Protocol_Trend   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   @lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  1Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$
��1820��$	��980��$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @Protocol.Text36��$	��400��  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2��� $��2��$��	10,0,10,0q�.+��� $ 5��$��0q�  FP_Blue#���  ._�#   LiveCharts.Wpf.CartesianChart  -     Name$ chart��$��5q�&    LiveCharts.Wpf.Charts.Base.Chart   Series �� *LastHourSeries+   AxisX    LiveCharts.Wpf.Axis  -     Name$ labels��   Labels �� *Labels+   	Separator    LiveCharts.Wpf.Separator     Step$ 15Q�   AxisY   -   $ oy��   MinValue �� *
MinValue+   MaxValue �� *
MaxValue+   -     Name$ oySeparator���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* �.+�  $��0��$��50��$	��200��   LocalizableText$* $@[ClientSystem].Dialogs.Common.cmdOK��$
��Left=�  	B_Gray_ns#���  ���� *Close+  $��1��$��50��$	��200��$ @Buttons.Text13��$��Right=�  B_Red_ns#���  $��	0,10,0,10q����� *Close+