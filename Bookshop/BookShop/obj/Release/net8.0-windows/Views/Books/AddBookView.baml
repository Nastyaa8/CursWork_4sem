   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ConvertersBookShop.Converters  E'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5clr-namespace:BookShop.ControlsBookShop.Controls  &     BookShop.Views.Books.AddBookView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
converters!clr-namespace:BookShop.Converters     9books'clr-namespace:BookShop.ViewModels.Books     4controlsclr-namespace:BookShop.Controls       � 	Resources  6   0BookShop.Converters.StringToImageSourceConverter   ImageConverter��%   &	          .���  � RowDefinitions �� $
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
��Auto ��� .+��� $��SemiBold"�#��� ��$��0 0 5 10q��� $��0��$��1��$��0 0 5 10q����� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� $��SemiBold"�$��1��$��0�� 
 Author#���  $��0 0 5 10q��� $��1��$��1��$��0 0 5 10q����� *Entity.Author+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��2��$��0�� 	 Genre#���  $��0 0 5 10q��� $��2��$��1��$��0 0 5 10q� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Genres+$ PropertyChanged=� �� SelectedItem �� *SelectedGenre+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��3��$��0�� 	 Price#���  $��0 0 5 10q��� $��3��$��1��$��0 0 5 10q����� *Entity.Price+$ PropertyChanged=�$
 True��$
 True��	 �� Mode$	 TwoWay=��� $��SemiBold"�$��4��$��0��$��2��$��0 0 5 15q�  BookIsAvailable#���  
 d� 	IsChecked
 �� *Entity.Available+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��5��$��0�� 	 Cover#���  $��0 0 5 10q��� $��5��$��1��$��0 0 5 10q�.+��  �� �� $
��Auto �.+���  �� 
IsReadOnly$
 True������ *Entity.Image+$ PropertyChanged=�$
 True��$
 True����  � ToolTip$# Выбрать обложку��$	��...��$��1��$	��5 0q�$��5 0 0 0q����� *SelectImageCommand+�� $	��0 5q�$��UniformToFill=����� *Entity.Image+$ PropertyChanged=� �� 	Converter# [  �� $��SemiBold"�$��6��$��0��  Description#���  $��0 0 5 10q��� $��6��$��1��$��0 0 5 10q� �� AcceptsReturn$
 True�� �� MaxLines$ 5��$��50��" �� VerticalScrollBarVisibility$
 Auto=����� *Entity.Description+$ PropertyChanged=�$
 True��$
 True��$	 TwoWay=��� $��2�� �� Orientation$ 
Horizontal=�$��5q�.+���   Save#���  $��0 0 5 0q����� *SaveCommand+��   Back#���  $��0 0 5 0q����� *BackCommand+