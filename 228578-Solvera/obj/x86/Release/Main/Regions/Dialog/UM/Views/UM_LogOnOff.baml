   M S B A M L   `   `   `  ����   228578-Solvera+    %HMI.DialogRegion.UM.Views.UM_LogOnOff   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$	��520��$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��
   LocalizableText$+
 %@UserManagement.View.Buttons.LogOnOff��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X������ *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�   VisiWin.Controls.TextVarIn    TVI_Main#���  $��50��*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$# @UserManagement.View.UserName��   Value �� *CurrentUserName+ �� Mode$ TwoWay=�{��� *
IsLogedOff+$  VisiWin.Controls.PasswordVarIn    PVI_Main#���  $��0,5,0,0q�$��50��+  %VisiWin.Controls.VariableInputControl   TouchpadName$ PasswordTouchpad��    LostKeyboardFocusBehavior$ 
WriteInput=�$# @UserManagement.View.Password�� �� *
Password+$ TwoWay=�{��� *
IsLogedOff+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��.+�  -   $ 
LeftButton��$	��200��$��50��$
��Left=�   LocalizableText$( "@UserManagement.View.Buttons.LogOn��  	B_Blue_ns#���  {��� *
IsLogedOff+���� *LogOnCommand+  -   $ RightButton��$	��200��$��50��$��Right=�$) #@UserManagement.View.Buttons.LogOff��  B_Red_ns#���  {��� *	IsLogedIn+���� *LogOffCommand+