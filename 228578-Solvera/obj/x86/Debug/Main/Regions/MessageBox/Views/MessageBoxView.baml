   M S B A M L   `   `   `  ����  228578-Solvera/    )HMI.MessageBoxRegion.Views.MessageBoxView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6      J� Opacity$  0Q�6S   .��5      � .+�5   
   �� -   5         ��Name$ border��5      $	��650��6!    J� RenderTransformOrigin$ 1, 0.5&�60   $	��250��6O   $
��1600��6_   $	��800��6o   
�������$��0q�6�     BackgroundBrush#���  6�    �� CornerRadius$ 5��6�   $��Center=�6�   $��Center=�6   J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
        ShadowDarkBottomColor   Color# �  6#   z�5      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   �� 5      $��70 �6$   .+�5         VisiWin.Controls.TextBlock  -   5        	  Name$	 
HeaderText��5      $
��Left=�63   $��Center=�6N   
�������$��18(�6|   $
��Bold"�6�   $	��400��6�   ��6�   �� *
HeaderText+
   LocalizableText
 6�   �� *HeaderLocalizableText+6�   �� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   �� 5      $��2��6   $ 5��6&   $��	10,0,10,0q�67     MainViewBackgroundBrush#��[ 6J   ._�5      � -   5         �Name$ MessageArea��5      $��Center=�61   $��Center=�6N   $��10q�6i   .+�5      &   VisiWin.Controls.SymbolPresenter  -   5          Name$ MessageIcon��5   -   $
��Left=�6e   $��Center=�6�      SymbolResourceKey 6B   �� *Icon+y�6�   �� *IconVisible+  5      -   5        $	 MessageText��5   '   $��16(�6U     DialogForegroundBrush#���  6c   $��60,0,0,0q�6�   $
��Left=�6�   $��Center=�6�   ��6<   �� *	Content+6�   5      5      �� 5       $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   � 5!      $��4��6    � ColumnDefinitions 5"      �� 5#      $	��70* �6+   �� 5$      $	��70* �6+   �� 5%      $	��51* �6+   �� 5&      $	��19* �6+   .+�5(        VisiWin.Controls.Button  -   5          Name$ 
LeftButton��5(   0   $��0��6    $	��200��6E   $��50��6Q   $
��Left=�6]   $
��Left��6�     	B_Blue_ns#���  6  $
��0,10q�6/     LocalizableText 6x   �� *LeftButtonLocalizableText+y�6�   �� *LeftButtonVisible+��6�   �� *	CloseMB+6/    5)      -   5        $ MiddleButton��5)   0   $��1��6    $	��200��6G   $��50��6S   $��Center=�6_   $��Middle��6�     	B_Gray_ns#���  6  $
��5,10q�69   6|   �� *MiddleButtonLocalizableText+y�6�   �� *MiddleButtonVisible+��6�   �� *	CloseMB+69    5*      -   5        $ RightButton��5*   0   $��2��6    $	��200��6F   $��50��6R   $��Right=�6^   $��Right��6�     B_Red_ns#���  6  $��2��63  $
��0,10q�6G   6z   �� *RightButtonLocalizableText+y�6�   �� *RightButtonVisible+��6�   �� *	CloseMB+6G  5+      5,      5-      5.      50      