   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   228578-Solvera4   .HMI.MainRegion.Dashboard.Widgets.DB_Widget_TYC   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     $	��585��$	��470��
������   J� Opacity$  0Q�.��� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$��-5q�$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� $ 5��   BackgroundBrush#���   $��2q�  FP_Blue#���  ._�� .+�   VisiWin.Controls.TextBlock  $��0�� �� TextAlignment$
 Left=�	 �� Padding$	 10, 6, 0, 0q�$��35��$	��Top=�
�������$��18(�
   LocalizableText$
 @Dashboard.Text15��   LiveCharts.Wpf.PieChart  -     Name$ pieeee��$	��420��&    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�$��Bottom=�   	Hoverable .  $��10q�   Series    LiveCharts.Wpf.PieSeries  -     Name$ notToday��   LiveCharts.Wpf.Series   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 20    FontSize$ 18Q�   
DataLabels .    Fill# �     
LabelPoint �� *
PointLabel+  -   $ Today��$ 20 $ 18Q� .   	FP_Yellow# �   �� *
PointLabel+  $��0��$ Right=�$	 10, 6, 0, 0q�$��35��$	��Top=�
�������$��20(�$
 @Units.charges��$��417,425,10,0q�$
��Bold"�