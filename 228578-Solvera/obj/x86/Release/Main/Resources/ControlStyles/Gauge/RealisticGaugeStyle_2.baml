   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   RealisticGaugeStyle_2  �� 
TargetType   VisiWin.Controls.Gauge �� Property �� Value � Color � Offset   VisiWin.Controls.GaugeBase+  %VisiWin.Controls.GraphicalBaseControl*  $VisiWin.Controls.VariableBaseControl �� EndPoint �� 
StartPoint �� 
TargetType �Name	 ��Name
 �� CornerRadius J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius A�Name �� RelativeSource �� AncestorType �� Path   Diameter K� ZIndex � RowDefinitions   SymbolVerticalAlignment    SymbolHorizontalAlignment   SymbolMargin   Symbol �� Orientation   LabelTextBrush   LabelTextMargin   	LabelText   LabelTextVisibility ��Name   ValueTextBrush   UnitTextBrush    UnitTextMargin$  VisiWin.Controls.NumericVarOut!   UnitText"   UnitTextVisibility  VisiWin.Controls.GaugeArc#  Name$   RulerBaseLineThickness%   ArcThickness&   EndAngle'   EndAngle(   RulerBaseLineFill)   Fill*   RulerBaseLineStroke+   Stroke,   
StartAngle-   
StartAngle.   ReferenceEndAngle"/   ReferenceValueDistanceBrush0   ReferenceStartAngle#  VisiWin.Controls.GaugePointer1  Name2   PointerHeight3   PointerStyle4   PointerWidth3  -System.Windows.Media.Effects.DropShadowEffect  FP_Red_C5   Color6   ShadowDepth7   
BlurRadius8   RenderingBias9 �� Triggers: P� Property; P� Value< �� 
TargetName= ]� 
Conditions> �� Property? �� Value@ �� Stretch�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      &vwhttp://inosoft.com/visiwin7   %�  &	        �� "    .���  � �� 
� .��� $ 	#FF0C0C0C��$ 1Q�� $ 	#FF515151��$ 0Q���  �@ CentralAngle$	 179Q���  �@ 
StartAngle$
 -154Q���  �@ LabelTextBrush
 �������  �@ RulerBaseLineThickness$ 4Q���  �@ RulerBaseLineFill
 ���� ��  �@ RulerBaseLineStroke
 ���� ��  �@ RulerMajorLineBrush
 �������  �@ RulerMinorLineBrush
 �������  �@ ScaleTextBrush
 �������  �@ UnitTextBrush
 �������  �@ ValueTextBrush
 �������  �@ MajorThickness$ 2Q��� # �@ ReferenceValueDistanceBrush
 ���� ��  �@ MinorLength$ -8Q���  �@ MajorLength$	 -12Q���  �@ ScaleTextOffset$	 -23Q���  �@ PointerOffset$ 0Q���  �@ LimitMaxVisibility$ Never=���  �@ LimitMinVisibility$ Never=���  � ��$ 2q���  � ��$ 5q��� ! �@ SymbolHorizontalAlignment$ Center=���  �@ SymbolMargin$ 0,30,0,0q���  �@ UnitTextMargin$ 3,0,0,0q���  �@ ValueTextMargin$ 0,0,0,0q���  �@ LabelTextMargin$ 0,0,-2,0q���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFBABFCF��$ 0.314Q�� $ 	#FFB6CBDC��$ 0.682Q�� $ 	#FF576470��$ 0.419Q�� $ 	#FF343F47��$ 1Q�� $ 	#FF5D5F66��$ 0.043Q���  � �� �� "   .R�� $ PART_GaugeGrid��}�.  $
��Left=�$	��Top=�.+��� .+�� .+��� $	 	BtnShadow��$��-2q�
�������$	
 100��   $ 10Q�A� $ 
Background��#��z��#��z������  �� $ vw:GaugeL�$ BorderThickness.Top�� $ PART_HostGrid��}�.  $
��Left=�#��z #��z��$	��Top=�#��z .+�� $ 0�� �� �� .+��� #��z #��z #��z #��z $��Center=�$��Center=��� $��Center=�$ Vertical=�$��Bottom=�$	 199��$��1��.+��� #��z $��Center=�#��z $
��Wrap=�#��z #y�z $��Center=��� $ 
Horizontal=�.+��� $ ValueFormattedTextBlock��#��z $��Center=�$
��Bold"�$��Center=����� *ValueFormatted+ �� *TemplatedParent+�� #��z $��Center=�#��z  $
��Wrap=�#��z! #y�z" $��Center=�  $# RulerBaseLineControl��#% z$ #' z& #) z( #+ z* #- z, $ 1��  $# PART_ReferenceArc��#% z$ #' z. #) z/ #+ z* #- z0 $	 198��  $1 PART_Pointer��$��Center=�#��z2 #��z3 $��Center=�#��z4 $	 200��A� $ 
PointerCap��$��Center=�$��Center=�$��25��$��25��$��2��$	 201������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF000000��$ 0.675Q�� $ 	#FFC1B5B5��$ 0.031Q����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF152029��$ 0.846Q�� $ 	#FF140204��$ 0.342Q�   #5 �  $6 0Q�$7 20Q�$8 Quality=�9 P� : �@ ScaleDisplayMode$; 	ScaleOnly=�. ��� $< RulerBaseLineControl�� � y�$ Hidden=��� $< PART_ReferenceArc�� � y�$ Hidden=�]� = �� > �@ 	BlinkMode$? 
BlinkBrush=��� > �@ 
BlinkState? . ./��� $< ValueFormattedTextBlock�� �� *
BlinkBrush+ �� *TemplatedParent+ � ��]� = �� > �@ 	BlinkMode$? 
Visibility=��� > �@ 
BlinkState? . ./��� $< ValueFormattedTextBlock�� � y�$ Hidden=���  �@ PointerStyle �� "   .���  � ��$	 117����  � �� �� "  .R�� .+�F� "�����.�zF���m�Ɓ	�����zF	$
��Auto��$
@ Fill=�$��7������ $ 1,0.5&�$ 0,0.5&�.��� $ 	#FF890A0A��$ 0.197Q�� $ 	#FFC40808��$ 1Q�� $ 	#FFE32323��$
 0.61Q�