   M S B A M L   `   `   `  ����   228578-Solvera4    .HMI.DialogRegion.Recipes.Views.Coating_Browser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�  VisiWin.Controls.Button  
������ $��0q����� *Close+� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$
��1200��$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @RecipeSystem.Text6��$	��400��  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�   VisiWin.Controls.TextVarIn    TVI_Main#���  *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text1��   VariableName$ __UNLINKED_BSTR��$��50��   TextLengthMin$ 3Q�   TextLengthMax$ 40Q�   AuthorizationRight$ RecipeC��   Value �� *
NameBuffer+ �� Mode$ TwoWay=�  #���  $ @RecipeSystem.Text2��$ __UNLINKED_BSTR��$��50��$ 40Q�$��0,5,0,0q�$ RecipeC�� �� *DescriptionBuffer+$ TwoWay=�&   System.Windows.Controls.DataGrid  -     Name$ dg_articles��$��2q�  FP_BorderBrush#���  $	��390��$��0,5,0,0q�  DG_StandartC#���  ���� *
Coatings+$ TwoWay=� �� SelectedItem �� *SelectedCoating+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 250
  	  Header 6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @RecipeSystem.Text7��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Header.Name+  $ *
    $ @RecipeSystem.Text8�� �� *Header.Description+    	TB_Center   ElementStyle# [ $	 200
    $ @RecipeSystem.Text9�� �� *Header.LastChanged+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��  $	 200
    $ @RecipeSystem.Text10�� �� *Header.User+  $ __UNLINKED_BSTR��$��45��#���  $ @RecipeSystem.Text11��$��0,5,0,0q� �� *Filter+$ TwoWay=��� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�  $��0��$��50��$	��200��   LocalizableText$ @Buttons.Text10��  	B_Blue_ns#���  $
��Left=�{��� *
IsSelected+���� *Load+  $��1��$��50��$	��200��$ @Buttons.Text25��#���     AuthorizationRight$ RecipeC������ *Save+  $��2��$��50��$	��200��$ @Buttons.Text9�� 	 B_Red_ns#��� 	 $��Right=�$ RecipeC��{��� *
IsSelected+���� *Delete+� $��5��$��-10,0,-10,0q�#���   y��� *Wait+.+�  
�������$	  0.7Q�$ 10��$��	0,100,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���  
 FP_Wait#��� 
 $	  0.7Q�$��	0,100,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -     ��Name$	  gif��$
��None=�