   M S B A M L   `   `   `  ����U  Q228578-Solvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5   
   )    #HMI.MainRegion.MO.Views.MO_MainView   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   6UC+clr-namespace:HMI.Resources.UserControls.MO   5   
   $
��1832��5   
   $
��1000��6      FP_Black_Gradient#��[  6%   .��5      � .+�5	   
   �� -   5          ��Name$	  Mod��5	      $	��Top=�6   $��5q�66    �� CornerRadius$ 0,0,200,200��6J     FP_Red_Gradient#���  6e   $��Center=�6�   $��80��6�   $
��1000��6�    J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ White��6#      	Direction$	 270Q�61      Opacity$	 0.7Q�6A   ._�5         VisiWin.Controls.TextBlock  -   5          Name$	 txt��5      $��Center=�6(   $��Center=�6C   
�������$
��Bold"�6s   $��24(�6�   5      � 5   
   -   5         �Name$ 
LayoutRoot��5      $��0,30,0,0q�6$   6Q   ,   &HMI.Resources.UserControls.MO.MVBasket  5   
   $��677,341,0,0q�6   $
��Left=�6,   $	��Top=�6G      IsBasket$Q KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.isBaskets��5      	   
IsMaterial$Q	 KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.isMaterial��5      
   SetLayer$Q
 KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layers.Set��5         ActualLayer$T NCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layers.Actual��5      
   CPU$
 CPU1��5      	   AS$	 Set��6&     5   
   $��677,382,0,0q�6   $
��Left=�6+   $	��Top=�6F   $Q KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.isBaskets��5      $Q	 KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.isMaterial��5      $Q
 KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layers.Set��5      $T NCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layers.Actual��5         IsDischarge$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Discharge��5      $
 CPU1��5         Station$ 4��6%   $ Actual��61     VisiWin.Controls.Button  5    
   -   5        $
��Left=�5       $	��Top=�6/   $	��150��6G   $	��105��6S     
B_Material#���  6`   $��640,366,0,0q�6�   6�     5!   
   -   5        $
��Left=�5!      $	��Top=�6/   $��70��6G   $	��125��6R   #���  6_   $��672,336,0,0q�6�   6�   0   *HMI.Resources.UserControls.MO.M_WorkMode_R  5$   
   $
��Left=�6   $	��Top=�65   $��	20,10,0,0q�6M      Header$ @MachineOverview.Text8��5%         	Automatic$e _CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating Mode.Automatic��5&         Manual$b \CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating Mode.Manual��5'         SetUp$a [CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating Mode.Setup��5(         Start$\ VCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Automatic.Start��5)         Stop$[ UCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Automatic.Stop��5*         StartStatus$Z TCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.to.Automatic.State��5+         WorkingModeStatus$_ YCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.to.Operating Mode.State��5,      0   *HMI.Resources.UserControls.MO.M_WorkMode_L  5/   
   $��Right=�6   $	��Top=�66   $��	0,10,10,0q�6N      Header$ @MachineOverview.Text17��50         	Automatic$f `CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.from.Operating Mode.Automatic��51         Manual$c ]CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.from.Operating Mode.Manual��52         SetUp$b \CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.from.Operating Mode.Setup��53         Start$] WCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.from.Automatic.Start��54         Stop$\ VCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.from.Automatic.Stop��55         StartStatus$[ UCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.to.Automatic.State��56         WorkingModeStatus$` ZCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket handling.to.Operating Mode.State��57        59   
   $
��Left=�6   $��Bottom=�65   $��	20,0,0,10q�6P   $ @MachineOverview.Text18��5:      $e _CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating Mode.Automatic��5;      $b \CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating Mode.Manual��5<      $a [CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating Mode.Setup��5=      $\ VCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Automatic.Start��5>      $[ UCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Automatic.Stop��5?      $Z TCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.to.Automatic.State��5@      $_ YCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.to.Operating Mode.State��5A        5C   
   $��Right=�6   $��Bottom=�66   $��	0,0,10,10q�6Q   $ @MachineOverview.Text19��5D      $d ^CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating Mode.Automatic��5E      $a [CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating Mode.Manual��5F      $` ZCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating Mode.Setup��5G      $[ UCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Start��5H      $Z TCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Stop��5I      $Y SCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Automatic.State��5J      $^ XCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Operating Mode.State��5K      � 5P   
   -   5        $ powerOFF��5P        DialogSurroundBrush#���  6!   $y�Hidden=�6T   .+�5Q        VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6,   $
��1010��6:   $	��410��6G   $��Center=�6T   $��Center=�6q    5R      -  'System.Windows.Media.Effects.BlurEffect  5S      !   Radius$! 10Q�6!   5U      �� 5V      $
��1000��6   $	��400��6"     FP_Yellow_Gradient#���  6/   $��5q�6a   #���  6u     5W      $��24(�6   $
��Bold"�6)   $��	0,340,0,0q�6;   " �� TextAlignment$" Center=�6O   $��Center=�6f   $	��Top=�6�   $��65��6�   #   LocalizableText$# @MachineOverview.Text48��6�     5X      $��65��6   $��24(�6'   $
��Bold"�65   $��	0,0,0,340q�6G   $" Center=�6Z   $��Center=�6q   $��Bottom=�6�   $# @MachineOverview.Text49��6�   � 5Y      $��Center=�6   $	��100��67   $��0q�6D   $��Center=�6O   $	��950��6j     
PB_Loading#���  6v    
 FP_Red#���  6�   
���   �$��3q�6�   $ � Minimum$$ 0Q�6�   % � Maximum$	% 500Q�6�   & � Value& 6  1	  +VisiWin.Extensions.VariableBindingExtension	  ' 	  VariableName$^' XCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.to.Control voltage.Countdown��5Z      � 5[   
   $��Center=�6   $��Bottom=�6,   $	��270��6G   $	��130��6S   $��
0,0,600,20q�6`   .+�5\        
�������$	  0.7Q�6,   $��-5q�6:    5]        5^      $! 10Q�6!   5`        5a      #���  6   #���  6K   $��5q�6{   (   Child.( 5c      � .+�5d      
  VisiWin.Controls.Key
  -   5        ) 
 Name$) ON��5d      $	��100��6)   $��80��65   $
��Left=�6A   $��20,0,0,0q�6]   $��Center=�6o   *   LocalizableText$* @Buttons.Text19��6�     	B_Gray_ns#���  6�   + 
  KeyMode$+ KeyMode=�6�   $��20(�6�   $
��Bold"�6�   , 
  VariableName$Y, SCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Control voltage.On��6  -   AuthorizationRight$- MachineOnOff��6e  
  5e      -   5        $	) OFF��5e      $	��100��6*   $��80��66   $��Right=�6B   $��0,0,20,0q�6^   $��Center=�6p   $* @Buttons.Text17��6�     B_Red_ns#���  6�   $+ KeyMode=�6�   $��20(�6�   $
��Bold"�6�   $Z, TCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.from.Control voltage.Off��6  $- MachineOnOff��6g  5f      5h      5i        VisiWin.Controls.GroupBox  5j   
    	 	GB_Group2#��� 	 6   $	��120��6:   $
��Left=�6F   $	��Top=�6a   .   LocalizableHeaderText$. @MachineOverview.Text109��6y   $��410,152,0,0q�6�   .��5k      �� / �� Orientation$/ 
Horizontal=�6   $��5,10,5,5q�62   .+�5l      $  VisiWin.Controls.NumericVarOut  -	   5        0  Name$
0 Tmin��5l   #    
 NVO_Main#��� 
 61   $	��105��6T   $��45��6`   *  $VisiWin.Controls.VariableBaseControl1   VariableName$I1 CCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.Charges��6l   5m      5n        5o   
   #��� 	 6   $
��Left=�6:   $��Bottom=�6U   $. @MachineOverview.Text77��6p   $��550,0,0,734q�6�   .��5p      �� $/ 
Horizontal=�6   $��5,10,5,5q�62   .+�5q        #��� 
 6$   $��85��6G   $��45��6R   2   LocalizableUnitText$2 @Units.m��6^   $R1 LCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.to.Clock.Minuten��6}     5r      #��� 
 6$   $��85��6G   $��45��6R   $��5,0,0,0q�6^   $2 @Units.s��6o   $S1 MCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Gerneral.to.Clock.Sekunden��6�   5s      5t      5v      5x      