   M S B A M L   `   `   `  ����  228578-Solvera5    /HMI.DialogRegion.Dashboard.Views.WidgetSelector   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   -   5          VisiWin.Controls.View   Name$  WS��5   
   $
��1920��5   
   $
��1080��6      DialogSurroundBrush#���   6%    J� Opacity$ 0Q�6X    � DataContext 5   
   0  *VisiWin.Extensions.AdapterBindingExtension     Name$ 	Dashboard��.��5
      � .+�5   
     VisiWin.Controls.Button  
������ $��0q�6-   ��6A   �� *Close+� 5   
   -   5         �Name$ border��5       J� RenderTransformOrigin$ 1, 0.5&�6   $
��1250��6>   $	��800��6K   $��Center=�6X   $��Center=�6u   z�5      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   .+�5        VisiWin.Controls.Border  
�������$	 0.7Q�6,    �� CornerRadius$ 5��6:   	 J� Effect	 5      -  'System.Windows.Media.Effects.BlurEffect  5      
   Radius$
 10Q�6!   5      �� 5      
�������$��5q�6*   $��0q�65     BackgroundBrush#���  6I   $ 5��6x   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5          VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5    #   $
��Left=�67   $��Center=�6R   
�������$��18(�6�   $
��Bold"�6�      LocalizableText$ @Dashboard.AddWidget��6�   $	��400��6�     5!      -   5          Name$ CancelButton��5!       $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *Close+�� 5"      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5$      -   5         ��Name$ 
LayoutRoot��5$      $��2��61   $��0q�6>   
�������
������ ._�5%      �  � ColumnDefinitions 5&      �� 5'   "   $	��400 �63   �� 5(   "   $��* �63   .+�5*      � $��35��6#   .+�5+   "     $��Center=�6P   $��Stretch=�6k   $��16(�6�   
���   � 6/   �� *Name+6�   5,        5-      $��0��6(   $��
-5,-5,0,-5q�68   
�������$	 0.7Q�6`   $ 5��6n   	 5.   "     5/   &   $
 10Q�61   51        VisiWin.Controls.ListBox  52      -   5          Name$
 list��52   )   $��0��67   $��2q�6G     FP_BorderBrush#���  6[   $��0,0,5,0q�6�     LB_DashBoard#���  6�     FP_Black_Gradient#���  6,  $��Visible=�6]     AuthorizationRight$ 	Dashboard��6�  ��6�   �� *AvailableDashboardWidgets+ �� SelectedItem 6�   �� *SelectedDashboardWidget+ �� 
GroupStyle 53   "   (  "System.Windows.Controls.GroupStyle  54   &      ContainerStyle 55   *   �� 56   .    �� 
TargetType" ��64   .�57   2   ��  �� Property � �� �� Value 58   6   �� 59   :    �� 
TargetType" ��6J   .R�5:   >   9�  9� 
IsExpanded . ��5;   B   �� 5<   F    �� Orientation$ 
Horizontal=�6Q   $��50��6j   .+�5=   J     $��10,0,0,0q�6}   $��Center=�6�   $��18(�6�   $
��Bold"�6�   
������� 6W   ��  �� Path$
 Name�6�   5>   G   .��5@   B   �� 5A   ?   5B   ;   5D   3   5E   /   5G   '   ��5I   "   �� 5J   &   " ��6,   .�5K   *   -   5        �� 5L   *    � ��
 �����6G   �� 5M   *    � �� 5O   .   �� 5Q   2   " ��6B   .R�5R   6   �� $��Border��6=   $��1,2,2,1q�6K   
������� J� SnapsToDevicePixels . ._�5S   :   �� $��40��6K   $��30,0,0,0q�6W    . 6j   5T   7    �� Triggers 5U   6   P� 5V   :     P� Property  �@��
IsSelected! P� Value! . . �5W   >   �� " �� 
TargetName$" Border��6E    � ��
 �����6o   �� 5X   >    � ��
 �   �6[   �� 5Y   >    � ��$ SemiBold"�6[   5Z   ;   5\   3   5^   +   5_   '   5a        5b      $��1��6(   $	��810��68   $��-5q�6D   
�������$	 0.7Q�6d   $ 5��6r   	 5c   "     5d   &   $
 10Q�61   5f      �� 5g      $��1��6%   #���  65     FP_BackgroundBrush#���  6d   $	��800��6�   $��2q�6�   $ 3��6�   }�. ._�5h   "   	  VisiWin.Controls.Region	  -   5        # 	 Name$# DashboardPreviewRegion��5h   ,   $ J� IsHitTestVisible$ .  6L   5i      5j      5l      �� 5m      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5o      $��4��6    5p      �� 5q      $��* �6/   �� 5r      $��* �6/   .+�5t        $��0��6$   $��50��64   $	��200��6@   $
��Left=�6L   %   LocalizableText$% @Buttons.Text42��6g     	B_Blue_ns#���  6�   &   AuthorizationRight$& 	Dashboard��6�   ��6�   �� *Add+6�     5u      $��1��6$   $��50��64   $	��200��6A   $��Right=�6M   $% @Buttons.Text13��6i    	 B_Red_ns#��� 	 6�   $��	0,10,0,10q�6�   ��6�   �� *Close+6�   5v      5w      5x      5y      5z      5{      