   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  9!clr-namespace:BookShop.ConvertersBookShop.Converters  $    BookShop.Views.Books.BooksView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9books'clr-namespace:BookShop.ViewModels.Books     8
converters!clr-namespace:BookShop.Converters       � 	Resources      BooleanToVisibilityConverter=   7BookShop.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter6   0BookShop.Converters.StringToImageSourceConverter   StringToImageSourceConverter��%-   &	        &	      &	 
     ��     .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1�� �� �� �� $
��Auto � � ColumnDefinitions �� �� �� .+��� $��3��$	��0 5q����� *
SearchText+$ PropertyChanged=�� $��0��$��1�� �� $
��Auto ��� $
��Auto �.+���  	 Price#���  $��Center=�$��0 0 0 5q�� $��1�� �� �� .+��� $��22��$��0 0 2 0q����� *
MinPrice+$ PropertyChanged=��� $��1��$��2 0 0 0q����� *
MaxPrice+$ PropertyChanged=�� $��1��$��1��$��2 0 2 0q� �� $
��Auto ��� $
��Auto �.+���  
 Genres#���  $��Center=�$��0 0 0 5q��� $��1�� �� SelectedValuePath$ Id�� �� DisplayMemberPath$
 Name������ *Genres+$ PropertyChanged=� �� SelectedItem �� *SelectedGenre+$ PropertyChanged=� �� Mode$ TwoWay=�� $��2��$��1��$��2 0 2 0q� �� $
��Auto ��� $
��Auto �.+���   	Available#���  $��Center=�$��0 0 0 5q��� $��1�� d� IsThreeState$
 True��  BookIsAvailable#���  $��Center=�$��2 3 0 0 q�	 d� 	IsChecked	 �� *IsAvailable+$ PropertyChanged=��� $��2��$��0��$��3��
 �� Orientation$
 
Horizontal=�$��Center=�$
��0 10q�.+���  	 Reset#���  $��0 0 2 0q����� *ClearFilterCommand+��  	 Apply#���  $��2 0 0 0q����� *ApplyFilterCommand+�� $��2��$��Disabled=�$��5q����� *Items+$ PropertyChanged=� �� *SelectedItem+$ PropertyChanged=����� .R�� ���� .R��  �� $��* ��� .+��� $��0��$��UniformToFill=�$	��330������ *Image+ �� 	Converter# [ � $��1�� �� �� .+��� $��0��$��18(�$��Center=�$��SemiBold"����� *Name+$ PropertyChanged=�� $��1��$	��0 5q� �� $
��Auto ���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��SemiBold"� 
	 Author#��� 	 �� $��10 0 0 0q�$��1������ *Author+$ PropertyChanged=��� $��1��$��SemiBold"� 
 PricePerOne#��� 
 �� $��1��$��10 0 0 0q�$��1������ *Price+$ PropertyChanged=��� $��2��$��SemiBold"� 	 Genre#���  �� $��2��$��10 0 0 0q�$��1������ *Genre+$ PropertyChanged=��� $��3��$��SemiBold"�#���  �� $��3��$��10 0 0 0q�$��1��${�False��	 �� *	Available+$ PropertyChanged=��� $
 
Horizontal=�$��3��$	��0 3q�.+��� $��Center=�$��Center=�  AddBook#���  $��0 5 5 5q�y���  �� Path$ IsAdmin�# [  ���� *
AddCommand+�� $��Center=�$��Center=�  EditBook#���  $��5q�y��� $ IsAdmin�# [  ���� *EditCommand+�� $��Center=�$��Center=�  ViewBook#���  $��5q����� *ViewCommand+�� $��Center=�$��Center=�  
DeleteBook#���  $��5q�y��� $ IsAdmin�# [  ���� *DeleteCommand+�� $��Center=�$��Center=�  	AddToCart#���  $��5 0 5 0q�y��� $ IsAdmin�# [ ���� *AddToCartCommand+