   M S B A M L   `   `   `  ����  228578-Solvera&     HMI.MainRegion.UM.Views.UM_Users   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   $
��1832��5   
   $	��890��6     � 	Resources  5      /  )VisiWin.Controls.UserStateToTextConverter   UserStateToTextConverter��%   &	          5   
   6&   5	      .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgv_users��5        DG_Standart#���  6z   ��6&   �� *
UserList+ �� SelectedItem 6G   �� *SelectedUser+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+   Header 6>   /  )VisiWin.Extensions.LocalizedTextExtension  	   LocalizedText$(	 "@UserManagement.View.Grid.UserName��6�     5      $	 300 6�    6%   �� *
FullName+ 6B     $,	 &@UserManagement.View.Grid.FullUserName��6�     5      $	 300 6�    6%   �� *Group+ 6?     $%	 @UserManagement.View.Grid.Group��6�     5      $ * 6�    6%   �� *	Comment+ 6A     $'	 !@UserManagement.View.Grid.Comment��6�     5      $	 200 6�     	TB_Center
   ElementStyle#
 �  6�    6%   �� *State+ �� 	Converter# [   6t     $%	 @UserManagement.View.Grid.State��6�   5      � 5   
   -   5        $ SubMenu��5      $��Center=�6    $��Right=�6;   $��0��6W   .+�5        VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q�6+    �� CornerRadius$ 4,0,0,4��69    J� Effect 5      -	  'System.Windows.Media.Effects.BlurEffect	  5       	  Radius$ 10Q�6!   5        5      $ 4,0,0,4��6   $��5,5,0,5q�60   $��2,2,0,2q�6B     FP_BorderBrush#���  6\     	FP_Yellow#���  6�      Child. 5      �� $��Center=�6   $��0q�68   .+�5      
  VisiWin.Controls.Button
   
  LocalizableText$&  @UserManagement.View.Buttons.Add��68   $	��160��6k   $��60��6w   $y�Visible=�6�   $
��Left=�6�   {�. $��	10,10,0,5q�6�     	B_Gray_ns#���  6�    
  AuthorizationRight$ UMUsers��6�   ��6    �� *Add+6�   
  5      $) #@UserManagement.View.Buttons.Change��6\   $
��Left=�6�   $	��160��6�   $��60��6�   $y�Visible=�6�   $��10,5,0,5q�6�   #���  6�   $ UMUsers��6  ��6    �� *Change+{�6;   �� *
IsSelected+6  
  5       $) #@UserManagement.View.Buttons.Remove��6\   $
��Left=�6�   $	��160��6�   $��60��6�   $y�Visible=�6�   $��10,5,1,5q�6�   #���  6�   $ UMUsers��6  ��6    �� *Remove+{�6;   �� *
IsSelected+6  
  5!      $1 +@UserManagement.View.Buttons.ChangePassword��6^   $
��Left=�6�   $	��160��6�   $��60��6�   $y�Visible=�6�   $��	10,5,0,10q�6�   #���  6�   $ UMUsers��6  ��6    �� *
ChangePW+{�6=   �� *
IsSelected+6  5"      5#      5$      
  5%   
   -   5         
 Name$ ButtonCloseMenu��5%        B_Filter#���  6-   $��72��6Q   $��80��6]   $��Right=�6h   $��Bottom=�6�     
  SymbolHorizontalAlignment$ Center=�6�    
  SymbolResourceKey$ 	MenuClose��6�   $y�	Collapsed=�6�   ��6�   �� *Close+6�   
  5&   
   -   5        $ ButtonOpenMenu��5&      #���  6,   $��72��6P   $��80��6\   $��Right=�6g   $��Bottom=�6�   $ MenuOpen��6�   ��6�   �� *Open+6�   5'      5(      