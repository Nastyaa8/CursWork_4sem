   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ConvertersBookShop.Converters  E'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5clr-namespace:BookShop.ControlsBookShop.Controls  '    !BookShop.Views.Books.BookInfoView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
converters!clr-namespace:BookShop.Converters     9books'clr-namespace:BookShop.ViewModels.Books     4controlsclr-namespace:BookShop.Controls       � 	Resources  =   7BookShop.Converters.InverseBooleanToVisibilityConverter '  #InverseBooleanToVisibilityConverter6   0BookShop.Converters.StringToImageSourceConverter  ImageConverter��%   &	        &	          .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$
��Auto=�$��5q�.��� $��5q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+��� 
�������$	��0 5q� �� CornerRadius$ 5��$��2q�$��2��$��Center=�._��� $	��400��$��Uniform=����� *Entity.Image+$ PropertyChanged=� �� 	Converter# [ �� $��1��$��16(�$��SemiBold"�#��� ��$��0 0 5 10q��� $��1��$��16(�$��1��$��	10 0 5 10q����� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� $��SemiBold"�$��16(�$��2��$��0�� 
 Author#���  $��0 0 5 10q��� $��2��$��16(�$��1��$��	10 0 5 10q����� *Entity.Author+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��16(�$��3��$��0�� 	 Genre#���  $��0 0 5 10q��� $��3��$��16(�$��1��$��	10 0 5 10q����� *Entity.Genre+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��16(�$��4��$��0�� 	 Price#���  $��0 0 5 10q��� $��16(�$��4��$��1��$��	10 0 5 10q����� *Entity.Price+$ PropertyChanged=�$
 True��$
 True�� �� Mode$ TwoWay=��� $��16(�${�False��$��SemiBold"�$��5��$��0��$��2��$��0 0 5 15q�  BookIsAvailable#���  	 d� 	IsChecked	 �� *Entity.Available+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��16(�$��6��$��0��  Description#���  $��0 0 5 10q��� $��16(�$��6��$��1��$��	10 0 5 10q����� *Entity.Description+$ PropertyChanged=�$
 True��$
 True��$ TwoWay=��� $��2��
 �� Orientation$
 
Horizontal=�$��5q�.+��� $��Center=�$��Center=�  	AddToCart#���  $��5 0 5 0q�y���  �� Path$ IsAdmin�# [  ���� *AddToCartCommand+��   Back#���  $��0 0 5 0q����� *BackCommand+