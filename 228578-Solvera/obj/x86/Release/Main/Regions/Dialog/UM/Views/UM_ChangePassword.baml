   M S B A M L   `   `   `  ����   228578-Solvera1    +HMI.DialogRegion.UM.Views.UM_ChangePassword   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$
��1000��$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��
   LocalizableText$1
 +@UserManagement.View.Buttons.ChangePassword��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X������ *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�!  VisiWin.Controls.TextVarOut    TVO_Main#���  $��45��*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$# @UserManagement.View.UserName��   VariableName$ __UNLINKED_BSTR��   Value �� *
UserName+  #���  $��45��$��0,5,0,0q�$' !@UserManagement.View.FullUserName��$ __UNLINKED_BSTR�� �� *UserFullName+  #���  $��45��$��0,5,0,0q�$" @UserManagement.View.Comment��$ __UNLINKED_BSTR�� �� *	Comment+$  VisiWin.Controls.PasswordVarIn    PVI_Main#���  $��0,5,0,0q�+  %VisiWin.Controls.VariableInputControl    LostKeyboardFocusBehavior$ 
WriteInput=�$��45��   TouchpadName$ PasswordTouchpad��$&  @UserManagement.View.OldPassword�� 	  VisiWin.Controls.TextVarIn 	  Value �� *OldPassword+ �� Mode$ TwoWay=�  #���  $��0,5,0,0q�$ 
WriteInput=�$��45��$ PasswordTouchpad��$# @UserManagement.View.Password�� �� *
Password+$ TwoWay=�  #���  $��0,5,0,0q�$ 
WriteInput=�$��45��$ PasswordTouchpad��$) #@UserManagement.View.SecondPassword�� �� *	Password2+$ TwoWay=��� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* �.+�  $��0��$
��Left=�$��50��$	��200��   LocalizableText$ @Buttons.Text8��  	B_Blue_ns#���  ���� *
ChangePW+  $��1��$��Right=�$��50��$	��200��$ @Buttons.Text13��  B_Red_ns#���  ���� *Close+