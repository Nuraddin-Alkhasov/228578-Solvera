   M S B A M L   `   `   `  ����   228578-Solvera/    )HMI.MessageBoxRegion.Views.MessageBoxView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+��� -    ��Name$ border��$	��650�� J� RenderTransformOrigin$ 1, 0.5&�$	��250��$
��1600��$	��800��
�������$��0q�  BackgroundBrush#���   �� CornerRadius$ 5��$��Center=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect    ShadowDarkBottomColor   Color# �  z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�$	��400������ *
HeaderText+
   LocalizableText
 �� *HeaderLocalizableText+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$ 5��$��	10,0,10,0q�  MainViewBackgroundBrush#��[ ._�� -    �Name$ MessageArea��$��Center=�$��Center=�$��10q�.+�&   VisiWin.Controls.SymbolPresenter  -     Name$ MessageIcon��$
��Left=�$��Center=�   SymbolResourceKey �� *Icon+y��� *IconVisible+  -   $	 MessageText��$��16(�  DialogForegroundBrush#���  $��60,0,0,0q�$
��Left=�$��Center=����� *	Content+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $	��70* ��� $	��70* ��� $	��51* ��� $	��19* �.+�  VisiWin.Controls.Button  -     Name$ 
LeftButton��$��0��$	��200��$��50��$
��Left=�$
��Left��  	B_Blue_ns#���  $
��0,10q�   LocalizableText �� *LeftButtonLocalizableText+y��� *LeftButtonVisible+���� *	CloseMB+  -   $ MiddleButton��$��1��$	��200��$��50��$��Center=�$��Middle��  	B_Gray_ns#���  $
��5,10q� �� *MiddleButtonLocalizableText+y��� *MiddleButtonVisible+���� *	CloseMB+  -   $ RightButton��$��2��$	��200��$��50��$��Right=�$��Right��  B_Red_ns#���  $��2��$
��0,10q� �� *RightButtonLocalizableText+y��� *RightButtonVisible+���� *	CloseMB+