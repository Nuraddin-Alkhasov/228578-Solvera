   M S B A M L   `   `   `  ����  228578-Solvera4    .HMI.MainRegion.Diagnose.Views.Diagnose_Current   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1832��5      $	��890��6   .��5      � -   5          �Name$  
LayoutRoot��5      .+�5	   
   &   System.Windows.Controls.DataGrid     LBI_Diagnose#���   6     DG_Standart#���  6�   ��6H   �� *Alarms+ �� SelectedItem 6g   �� *Alarm+ �� Mode$ TwoWay=�   Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6�     	TB_Center1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6�      Header 6&   /  )VisiWin.Extensions.LocalizedTextExtension     Text$9 3@[ClientSystem].Components.AlarmList.ActivationTime��   Binding 6{   �� *ActivationTime+	 �� StringFormat$	 HH:mm:ss��6�     5      $	 100 6s     TB_Right# [ 6�    6&     $0 *@[ClientSystem].Components.AlarmList.Count�� 6   �� *Name+6�     5      $ * 6r    6&     $/ )@[ClientSystem].Components.AlarmList.Text�� 6|   �� *Text+5      � 5   
   -   5        $  SubMenu��5      $��Center=�6    $��Right=�6;   $��0��6W   .+�5        VisiWin.Controls.Border  
�������
 J� Opacity$	
 0.7Q�6+    �� CornerRadius$ 4,0,0,4��69    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6!   5        5      $ 4,0,0,4��6   $��5,5,0,5q�60   $��2,2,0,2q�6B     FP_BorderBrush#���  6\     	FP_Yellow#���  6�      Child. 5      �� $��Center=�6   $��0q�68   .+�5      	  VisiWin.Controls.Key	   	  KeyMode$ KeyMode=�6   $��Center=�6/   $	��160��6J   
  VisiWin.Controls.Button 
  Text$ B1��6V   $��	10,10,0,5q�6`   $
��Left=�6t   $��60��6�    
  LocalizableText$ @Diagnose.Text3��6�     	B_Gray_ns#���  6�    
  AuthorizationRight$ DiagnoseCurrent��6�   ��6�   �� *Ack+6�   	  5      $ KeyMode=�6   $��Center=�6/   $	��160��6J   $ B1��6V   $
��Left=�6a   $��	10,5,0,10q�6|   $��60��6�   #���  6�   $ @Diagnose.Text4��6�   $ DiagnoseCurrent��6   ��6�   �� *	HornOff+6   5      5      5      
  5    
   -   5         
 Name$ ButtonCloseMenu��5       $��72��6-   $��80��69   $��Right=�6D   $��Bottom=�6`     B_Filter#���  6�    
  SymbolResourceKey$ 	MenuClose��6�   $y�Hidden=�6�   ��6|   �� *Close+6�   
  5!   
   -   5        $ ButtonOpenMenu��5!      $��72��6,   $��80��68   $��Right=�6C   $��Bottom=�6_   #���  6�   $ MenuOpen��6�   $ DiagnoseCurrent��6�   ��6z   �� *Open+6�   5"      5#      