   M S B A M L   `   `   `  ����   228578-Solvera-    'HMI.TouchpadRegion.PasswordTouchpadView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $
��1920��$
��1080��   DialogSurroundBrush#���   -  'System.Windows.Input.KeyboardNavigation    ControlTabNavigation$
  Once=�   TabNavigation$ Cycle=�$��Center=�$��Center=� J� Opacity$ 0Q�.��� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�.  (System.Windows.Interactivity.Interaction   	Behaviors /  )VisiWin.Controls.MouseDragElementBehavior     ConstrainToParentBounds . z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	 0.7Q�	 �� CornerRadius$	 5��
 J� Effect
 -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  FP_Black_Gradient#���  $	 5��._�� $��
10,0,10,10q� � RowDefinitions �� $��70 ��� $��12 ��� $
��Auto �.+�   VisiWin.Controls.TextBlock  -     Name$ lblAlphaPadDescription��$
��Left=�$��0,0,0,0q�$��Center=�
�������$��18(�$
��Bold"�$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X���� $��1��$	��Top=� 
 FP_Red#���  $��2��$	 2���� $��2��$��
10,0,10,10q�.+�$  VisiWin.Controls.PasswordVarIn  -     Name$ passwordVarIn1��+	  %VisiWin.Controls.VariableInputControl 	  TouchpadMember .   PVI_Main#���  $��80��$
  VisiWin.Controls.TouchKeyboard
  -    
 Name$ TouchKeyboard��$��TouchKeyboard��  AlphaTouchKeyboard#���  $��0,10,0,0q�$
��1015��$	��421��