   M S B A M L   `   `   `  ����   228578-Solvera*    $HMI.MainRegion.Logging.Views.Logging   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1832��$
��1000��   FP_Black_Gradient#��[  .��� -     �Name$  
LayoutRoot�� � RowDefinitions �� $	��110 ��� $��* �.+�� $��1��.+�� .+�&   System.Windows.Controls.DataGrid    LBI_Diagnose#���    DG_Standart#���  ���� *LoggingEntries+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200   	TB_Center1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    Header /  )VisiWin.Extensions.LocalizedTextExtension     Text$( "@Logging.LoggingView.ListView.Time��   Binding �� *	TimeStamp+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��  $	 260    $) #@Logging.LoggingView.ListView.Event�� �� *LocalizedEventName+  $ *    $( "@Logging.LoggingView.ListView.Text�� �� *LocalizedText+  $	 200    $( "@Logging.LoggingView.ListView.User�� �� *User+'  !VisiWin.Controls.NavigationButton    B_Filter#���  $��72��$��80��$��Right=�$��Bottom=�  VisiWin.Controls.Button	   SymbolResourceKey$	 Filter��
   AuthorizationRight$
 Logging������ *
OpenFilter+�   FP_Blue_Gradient#���   J� Effect 3	  -System.Windows.Media.Effects.DropShadowEffect	   	  Color$ White�� 	  	Direction$	 270Q� 	  Opacity$	 0.7Q�.+� 
  VisiWin.Controls.TextBlock
  -    
 Name$ header�� 
  LocalizableText$ @Logging.Text1��$��Center=�
�������$
��Bold"�$��48(�$��50,0,0,0q�  -   $	��180��$��90��$��Right=�$��Center=�  	B_Gray_ns#���     LocalizableText$ @Buttons.Text60��{�.  $��0,0,10,0q�� -   $
  wait��$��2��  DialogSurroundBrush#���  y��� *Wait+.+�  VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q� �� CornerRadius$ 10��$��	0,110,0,0q�$	��150��$	��290��$��Center=�$��Center=� -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q���   FP_Wait#���  $	 0.7Q�$��	0,110,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -    ��Name$	 gif��$
��None=�