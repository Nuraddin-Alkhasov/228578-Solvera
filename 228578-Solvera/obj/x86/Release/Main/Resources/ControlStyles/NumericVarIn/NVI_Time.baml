   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   NVI_Time  �� 
TargetType#   VisiWin.Controls.NumericVarIn �� Property  InputBackgroundBrush �� Value  InputFontBrush*  $VisiWin.Controls.VariableBaseControl  FP_BorderBrush+  %VisiWin.Controls.VariableInputControl  EmptyValidationTemplate  LabelMargin �� RelativeSource �� AncestorLevel �� AncestorType �� Padding �� TextAlignment �� 
TargetType	 �Name
 � ColumnDefinitions ��Name   CornerRadius �� CornerRadius ��Name   Text-  'System.Windows.Input.KeyboardNavigation   TabIndex � UseLayoutRounding J� IsHitTestVisible   	LabelText    UnitText  ConnectionErrorBorderBrush " ConnectionErrorBackgroundBrush&   VisiWin.Controls.SymbolPresenter  Name  ConnectionErrorSymbol   Symbol �� 	UriSource �� Triggers P� Property P� Value �� 
TargetName 	 FP_Blue_Gradient 
 InputSelectedFontBrush N� EnterActions ��Name �� 
TargetName �� TargetProperty	  �� To! g� Duration" g� AutoReverse# g� RepeatBehavior$ N� ExitActions% �� BeginStoryboardName�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      &vwhttp://inosoft.com/visiwin7   %�
  &	        �� "    .���  � ��# �  ��  � ��# �  ��  �@ 
BlinkBrush# �  ��  � ��
 �   ���  � |� .  ��  � ��$ 1q���  �@ CornerRadius$ 3����  �@ 	LabelText$  ����  � ��$
 10,0q���  � ��$ Segoe UI)���  � ��$ SemiBold"���  � ��$ 16(���  �@ ValidationErrorTemplate# �  �� ! �@ SymbolHorizontalAlignment$ Right=���  �@ SymbolMargin# �  ��  � ��$ Center=���  � ��$ Stretch=���  �@ TextAlignment$ Right=���  � ��$ Center=���  �@ WatermarkTemplate �� .R��� ���	#FF868686���� *
FontSize+ �� *FindAncestor+$ 1��"  ���� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��"  ���� *BorderThickness+ �� *FindAncestor+$ 1��"   �� *	Padding+ �� *FindAncestor+$ 1��"   �� *TextAlignment+ �� *FindAncestor+$ 1��"  ���� *WatermarkText+ �� *FindAncestor+$ 1��"  ���� *VerticalContentAlignment+ �� *FindAncestor+$ 1��"  ��  � �� �� "   .R�� $
	 Grid��
 �� $
��Auto ��� $��* ��� $
��Auto �.+��� $ BG��$��3��#��z��#��z��#��z��# z �� $ value��#��z��#��z��$��Center=�$��0,0,0,0q�$��1��|�. #��z # z��# z �� $
 head��$��SemiBold"�$
��Left=� .  $��0,0,0,0q�$
 Left=�#��z #��z��
��������� $
 unit��$��SemiBold"�$��2��$
��Left=� .  $��0,0,0,0q�$
 Left=�#��z $��Center=�
��������� $ ConnectionError��#���  $��1q�#���  $��3��# z $y�	Collapsed=�  $ ConnectionErrorSymbol��$��2��|�.  $��Right=�# �  $y�	Collapsed=�$	��Top=����� .R��� $��24��$
��Fill=�$��24������ $\ Vpack://application:,,,/VisiWin7.Styles.WPF;component/Images/connection_error_24x24.png?��� $ PART_HitArea��$��3��
������ $��0q�
������ $ 0�� P�  � {� .  . ��� $ BG�� �@J�Opacity$	 0.7Q�P�  �@ IsQualityGood .  . ��� $ ConnectionError�� � y�$ Visible=��� $ ConnectionErrorSymbol�� � y�$ Visible=�P� # �@J�AreAnyTouchesCapturedWithin . . ��� $ BG��# � 	  � ���� $ value��# � 
  � ���� $
 head��# � 
  � ���� $
 unit��# � 
  � ��P�  �@J�IsMouseCaptureWithin . . ��� $ BG��# � 	  � ���� $ value��# � 
  � ���� $
 head��# � 
  � ���� $
 unit��# � 
  � ��P�  �@ IsInputValid .  . ��� $ value��# � 
  � �� �� $ flash��.���� .���� $ BG��$1 +(Border.Background).(SolidColorBrush.Color)�$  	#FFBE2828X�$! 0:0:1D�" . $# Forever��$ �� $% flash��