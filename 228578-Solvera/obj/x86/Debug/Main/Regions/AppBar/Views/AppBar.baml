   M S B A M L   `   `   `  ����  228578-Solvera#    HMI.AppBarRegion.Views.AppBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $��88��5      $
��1000��6   .��5      �    BackgroundBrush#���   6     � ColumnDefinitions  5	   
   �� 5
      $��* �6   �� 5      $��8 �6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ White��6      	Direction$ 0Q�6-      Opacity$	 0.7Q�6<   .+�5   
   �� $��1��6    
 FP_Red#���  6$   �� 5   
   $��	10,10,0,0q�6   $	��Top=�6(   .+�5        VisiWin.Controls.Button  -   5          Name$ ButtonCloseMenu��5      
������ $��52��6w   $��62��6�   $��	0,10,0,10q�6�   $��Right=�6�   $	��Top=�6�     AB_Close   Symbol# �  6  y�6J   �� *CloseButtonVisibility+��6�   Z� ��6�   �� *Close+6    5      -   5        $ ButtonOpenMenu��5      
������ $��52��6v   $��62��6�   $��	0,10,0,10q�6�   $��Right=�6�   $	��Top=�6�     AB_Open# �  6  y�6J   �� *OpenButtonVisibility+��6�   Z� ��6�   �� *Open+6  ,  &VisiWin.Controls.NavigationRadioButton  5      -   5          Name$ 	dashboard��5   '    d� 	IsChecked$
 TrueY�6l   $��60��6}   $��0,60,0,0q�6�     
NRB_AppBar#���  6�     AB_Dashboard"  VisiWin.Controls.RadioButton	   Symbol#	 �  6�   
   LocalizableText
 6:   �� *LTDashboardViewButton+��6�   �� *DashboardViewOpen+  5      -   5        $
 home��5   '   $��80��6b   $��0,10,0,0q�6o   #���  6�     AB_Home#	 �  6�      SymbolMargin$ 	-13,0,0,0q�6�   
 65   �� *LTMainViewButton+��6�   �� *MainViewOpen+  5      -   5        $ recipe��5   '   $��60��6f   $��0,10,0,0q�6r   #���  6�     
AB_Recipes#	 �  6�   
 67   �� *LTRecipeViewButton+��6�   �� *RecipesViewOpen+  5      -   5        $ orders��5   '   $��60��6f   $��0,10,0,0q�6r   #���  6�     	AB_Orders#	 �  6�   
 67   �� *LTOrdersViewButton+��6�   �� *OrdersViewOpen+  5      -   5        $ um��5   '   $��60��6_   $��0,10,0,0q�6k   #���  6}    	 AB_UserManagement#	 � 	 6�   
 64   �� *LTUMViewButton+��6�   �� *
UMViewOpen+  5      -   5        $ logging��5   '   $��60��6i   $��0,10,0,0q�6u   #���  6�    
 
AB_Logging#	 � 
 6�   
 69   �� *LTLoggingViewButton+��6�   �� *LoggingViewOpen+  5      -	   5        $ pm��5   '   $��60��6�   $��0,10,0,0q�6�   #���  6�     AB_Preventivemaintenance#	 �  6�   
 � Tag 63   �� *
PMStatus+ �� Mode$ OneWay=�
 6Y   �� *LTPMViewButton+��6�   �� *
PMViewOpen+  5      -
   5        $ diagnose��5   '   $��60��6�   $��0,10,0,0q�6�   #���  6�     AB_Diagnose#	 �  6�    69   �� *	DStatus+$ OneWay=�
 6_   �� *LTDiagnoseViewButton+��6�   �� *DiagnoseViewOpen+5      �� 5   
   $��
10,0,10,20q�6   $��Bottom=�6)   .+�5           SymbolMargin$ 3,0,0,0q�69     AB_Languages# �  6P   $��60��6x   $��0,0,0,10q�6�     B_AppBar#���  6�      Text 6   �� *CurrentLanguage+��6�   �� *ChangeLanguage+6�     5       $ 3,0,0,0q�65     AB_LogIn# �  6L   $��60��6p   $��0,0,0,10q�6|   #���  6�    6   �� *CurrentUser+��6�   �� *LogIn+6�     5!      $ 3,0,0,0q�6=   $��60��6T     
AB_Turnoff# �  6`   #���  6�      LocalizableText 6   �� *
PowerOff+��6�   �� *Exit+5"      5#      5$      