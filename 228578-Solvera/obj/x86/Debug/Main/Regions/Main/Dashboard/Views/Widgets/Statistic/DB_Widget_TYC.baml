   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       228578-Solvera4   .HMI.MainRegion.Dashboard.Widgets.DB_Widget_TYC   5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      $	��585��5      $	��470��6   
������   J� Opacity$  0Q�6=   .��5      � -   5         �Name$ border��5       J� RenderTransformOrigin$ 1, 0.5&�6   z�5	   
   �� 5
       �� ScaleX$	 0.3Q�6    �� ScaleY$	 0.3Q�6*   .+�5   
     VisiWin.Controls.Border  
�������$��-5q�6'   $	  0.7Q�64    �� CornerRadius$ 5��6B    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $ 5��6      BackgroundBrush#���   6#   $��2q�6R     FP_Blue#���  6f   ._�5      � .+�5         VisiWin.Controls.TextBlock  $��0��6    �� TextAlignment$
 Left=�6,   	 �� Padding$	 10, 6, 0, 0q�6A   $��35��6W   $	��Top=�6c   
�������$��18(�6�   
   LocalizableText$
 @Dashboard.Text15��6�      LiveCharts.Wpf.PieChart  5      -   5          Name$ pieeee��5      $	��420��6/   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�6<   $��Bottom=�6R      	Hoverable .  $��10q�6      Series 5         LiveCharts.Wpf.PieSeries  -   5          Name$ notToday��5   (      LiveCharts.Wpf.Series   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 20 6:      FontSize$ 18Q�6F      
DataLabels .    Fill# �  6f      
LabelPoint 6�   �� *
PointLabel+  5      -   5        $ Today��5   (   $ 20 67   $ 18Q�6D    .   	FP_Yellow# �  6d    6�   �� *
PointLabel+5        5      $��0��6   $ Right=�6,   $	 10, 6, 0, 0q�6B   $��35��6X   $	��Top=�6d   
�������$��20(�6�   $
 @Units.charges��6�   $��417,425,10,0q�6�   $
��Bold"�6�   5       5!      5"      5#      