   M S B A M L   `   `   `  ����U  Q228578-Solvera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5   	   )    #HMI.Resources.UserControls.MO.MV_LD   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   	   6UC+clr-namespace:HMI.Resources.UserControls.MO   5   	   -   5          J� Opacity$  0Q�5   @   .��5      � -   5         �Name$ A��5      .+�5   
   !  VisiWin.Controls.PictureBox     SymbolResourceKey$ 	MV_LDHCDC��6   $	��352��66   $	��364��6B   $��3q�6O   $
��Left=�6Z   $	��Top=�6u    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
         Color$ Black��6#      
BlurRadius$ 3Q�61      	Direction$	 270Q�6A      Opacity$	 0.5Q�6R   5      .   (HMI.Resources.UserControls.MO.MVMaterial  5   
   $��135,190,0,0q�6   $
��Left=�6-   $	��Top=�6H   $	��155��6`   $��65��6l      
IsMaterial$P JCPU1.PLC.Blocks.01 Basket feeding.02 HC.00 Main.DB HC PD.Charge.isMaterial��5      	   ValueWeight$R	 LCPU1.PLC.Blocks.01 Basket feeding.02 HC.01 Belt.DB HC Belt HMI.Actual.Weight��5        5   
   $��305,178,0,0q�6   $
��Left=�6-   $	��Top=�6H   $��30��6`   $	��110��6k   $P JCPU1.PLC.Blocks.01 Basket feeding.03 DC.00 Main.DB DC PD.Charge.isMaterial��5        5   
   $
��Left=�6   $	��Top=�64   $��	12,23,0,0q�6L   $	��110��6_   $	��101��6l   $P JCPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.isMaterial��5        VisiWin.Controls.Button  5   
   -   5           	B_Station#���   5   ,   $��-5q�6P     5   
   -   5          
B_Function#���  5   +   $	��125��6Q   $
��Left=�6]   $��0,-5,170,-5q�6x   
   AuthorizationRight$
 
ManualMode��6�   #  VisiWin.Controls.ToggleButton  5   
   $��Bottom=�6      LocalizableText$ @MachineOverview.Text99��65     TB_Main#���  6_   $
��Left=�6�   $	��107��6�   $��70��6�   $��
163,0,0,25q�6�      AuthorizationRight$ 
ManualMode��6�      VariableName$G ACPU1.PLC.Blocks.00 Main.02 HMI.01 PC.DB PC.General.Manual loading��6�   {�.   d� 	IsChecked$
 TrueY�6K  5      5      