   M S B A M L   `   `   `  ����  228578-Solvera#    HMI.MainRegion.UM.Views.UM_PN   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1832��5      $
��1000��6      FP_BackgroundBrush#��[  6!   .��5      � -   5          �Name$  
LayoutRoot��5       � RowDefinitions 5   
   �� 5	      $	��110 �6   �� 5
      $��* �6   .+�5   
   )  #VisiWin.Controls.PanoramaNavigation  -   5        $��pn_um��5       $��1��6-      Orientation$ 
Horizontal=�6;    J� IsManipulationEnabled .     PanoramaRegions 5      %  VisiWin.Controls.PanoramaRegion    VisiWin.Controls.Region   	StartView$ UM_Users��6$     5      $ 	UM_Groups��6$   5      � 5   
     FP_Blue_Gradient#���  6    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ White��6#      	Direction$	 270Q�61   	   Opacity$		 0.7Q�6A   .+�5         VisiWin.Controls.TextBlock  -   5        
  Name$
 header��5         LocalizableText$  @UserManagement.View.Text1��6+   $��Center=�6X   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5      �� 5   
   $��1��6   $��Bottom=�6   $��Center=�6:    J� Opacity$	 0.7Q�6X     LBI_PanoramaNavigation_H#���  5        LB_PanoramaNavigation_H#���  6S    �� SelectedIndex 5      �� *SelectedPanoramaRegionIndex+ �� ElementName$ pn_um�� �� Mode$ TwoWay=� �� NotifyOnTargetUpdated .  �� NotifyOnSourceUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�.@�5      "  VisiWin.Controls.ListBoxItem    5      $��10,0,0,0q�6   5      5       5!      