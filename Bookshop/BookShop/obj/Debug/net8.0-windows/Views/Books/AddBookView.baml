   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5      H DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters 5      &     BookShop.Views.Books.AddBookView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9books'clr-namespace:BookShop.ViewModels.Books     5      T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5        � 	Resources  5      ;  5BookShop.Mvvm.Converters.StringToImageSourceConverter   ImageConverter��%   &	          5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5   
   $��1��6   $
��Auto=�6$   $��5q�6G   .��5      � $��5q�6    5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$    � ColumnDefinitions 5"      �� 5#      $
��Auto �6'   �� 5$      .+�5&      �� $��SemiBold"�6   #��� ��62   $��0 0 5 10q�6P   �� 5'      $��0��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� 5(      $��SemiBold"�6   $��1��62   $��0��6?    
 Author#���  6O   $��0 0 5 10q�6o   �� 5)      $��1��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *Entity.Author+$ PropertyChanged=�$
 True��$
 True���� 5*      $��SemiBold"�6   $��2��62   $��0��6?    	 Genre#���  6P   $��0 0 5 10q�6o   �� 5+      $��2��6   $��1��6(   $��0 0 5 10q�68    �� DisplayMemberPath$
 Name��5-       �� SelectedValuePath$ Id��64   ��5,      �� *Genres+$ PropertyChanged=� �� SelectedItem 5.      �� *SelectedGenre+$ PropertyChanged=�$
 True��$
 True���� 50      $��SemiBold"�6   $��3��62   $��0��6?    	 Price#���  6O   $��0 0 5 10q�6n   �� 51      $��3��6�   $��1��6�   $��0 0 5 10q�6�   ��6   �� *Entity.Price+$ PropertyChanged=�$
 True��$
 True��	 �� Mode$	 TwoWay=�6�   �� 52      $��SemiBold"�6   $��4��61   $��0��6>   $��2��6N   $��0 0 5 15q�6b     BookIsAvailable#���  6t   
 d� 	IsChecked
 6�   �� *Entity.Available+$ PropertyChanged=�$
 True��$
 True���� 53      $��SemiBold"�6   $��5��62   $��0��6?    	 Cover#���  6O   $��0 0 5 10q�6n   �� 54      $��5��6   $��1��6*   $��0 0 5 10q�6:   .+�55      �  56      �� 57      �� 58      $
��Auto �6/   .+�5:      ��  �� 
IsReadOnly$
 True��6"   ��64   �� *Entity.Image+$ PropertyChanged=�$
 True��$
 True���� 5;       � ToolTip$# Выбрать обложку��6!   $	��...��6;   $��1��6I   $	��5 0q�6Y   $��5 0 0 0q�6g   ��6x   �� *SelectImageCommand+5<      �� 5=      $	��0 5q�6   $��UniformToFill=�6)   ��6A   �� *Entity.Image+$ PropertyChanged=� �� 	Converter# [  6�   5>      �� 5@      $��SemiBold"�6   $��6��62   $��0��6?     Description#���  6O   $��0 0 5 10q�6t   �� 5A      $��6��6�   $��1��6�   $��0 0 5 10q�6�    �� AcceptsReturn$
 True��6�    �� MaxLines$ 5��6�   $��50��6  " �� VerticalScrollBarVisibility$
 Auto=�6  ��6   �� *Entity.Description+$ PropertyChanged=�$
 True��$
 True��$	 TwoWay=�6  5B      5C      �� 5D   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5E      ��   Save#���  6   $��0 0 5 0q�66   ��6G   �� *SaveCommand+6i   �� 5F        Back#���  6   $��0 0 5 0q�66   ��6G   �� *BackCommand+6i   5G      5H      5I      