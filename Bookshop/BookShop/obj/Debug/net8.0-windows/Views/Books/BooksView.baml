   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5      H DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters 5      $    BookShop.Views.Books.BooksView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9books'clr-namespace:BookShop.ViewModels.Books     5      T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5        � 	Resources  5          BooleanToVisibilityConverterB  <BookShop.Mvvm.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter;  5BookShop.Mvvm.Converters.StringToImageSourceConverter   StringToImageSourceConverter��%W   &	        &	      &	 &     �� 5   
   6'     5   
   69     5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   � 5   
   $��1��6    5      �� 5      �� 5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      �� 5       �� 5!      .+�5#      �� $��3��6W   $	��0 5q�6k   ��6   �� *
SearchText+$ PropertyChanged=�6z   � 5$      $��0��6   $��1��6#    5%      �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   .+�5)      ��  	 Price#���  6   $��Center=�6;   $��0 0 0 5q�6X   � 5*      $��1��6    5+      �� 5,      �� 5-      .+�5/      �� $��22��6   $��0 0 2 0q�6i   ��6*   �� *
MinPrice+$ PropertyChanged=�6i   �� 50      $��1��6   $��2 0 0 0q�6m   ��6.   �� *
MaxPrice+$ PropertyChanged=�6m   51      52      � 53      $��1��6   $��1��6#   $��2 0 2 0q�60    54      �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   .+�58      ��  
 Genres#���  6   $��Center=�6<   $��0 0 0 5q�6Y   �� 59      $��1��6    �� SelectedValuePath$ Id��5<       �� DisplayMemberPath$
 Name��5=      ��5:      �� *Genres+$ PropertyChanged=� �� SelectedItem 5;      �� *SelectedGenre+$ PropertyChanged=� �� Mode$ TwoWay=�5=      5?      � 5@      $��2��6   $��1��6#   $��2 0 2 0q�60    5A      �� 5B      $
��Auto �6$   �� 5C      $
��Auto �6$   .+�5E      ��   	Available#���  6   $��Center=�6?   $��0 0 0 5q�6\   �� 5F      $��1��6    d� IsThreeState$
 True��6(     BookIsAvailable#���  6<   $��Center=�6h   $��2 3 0 0 q�6�   	 d� 	IsChecked	 6�   �� *IsAvailable+$ PropertyChanged=�6�   5H      �� 5I      $��2��6   $��0��6&   $��3��66   
 �� Orientation$
 
Horizontal=�6J   $��Center=�6c   $
��0 10q�6�   .+�5J      ��  	 Reset#���  6   $��0 0 2 0q�6b   ��6;   �� *ClearFilterCommand+6b   �� 5K       	 Apply#���  6   $��2 0 0 0q�6b   ��6;   �� *ApplyFilterCommand+6b   5L      5M      �� 5N   
   $��2��5O      $��Disabled=�5P      $��5q�5S      ��5Q      �� *Items+$ PropertyChanged=� 5R      �� *SelectedItem+$ PropertyChanged=���5U      �� 5V      .R�5W      � 5X      ��5Z      �� 5[      .R�5\      �  5]      �� 5^      $��* �6,   �� 5_      .+�5a      �� $��0��6    $��UniformToFill=�6   $	��330��6�   ��6-   �� *Image+ �� 	Converter# [ 6�   � 5b      $��1��6    5c      �� 5d   "   �� 5e   "   .+�5g      �� $��0��6(   $��18(�65   $��Center=�6C   $��SemiBold"�6`   ��6v   �� *Name+$ PropertyChanged=�� 5h      $��1��6#   $	��0 5q�60    5i   "   �� 5j   &   $
��Auto �67   �� 5k   &    5m   "   �� 5n   &   $
��Auto �64   �� 5o   &   $
��Auto �64   �� 5p   &   $
��Auto �64   �� 5q   &   $
��Auto �64   .+�5s   "   �� $��SemiBold"�6,    
	 Author#��� 	 6B   �� 5t   "   $��10 0 0 0q�6,   $��1��6>   ��6N   �� *Author+$ PropertyChanged=��� 5v   "   $��1��6-   $��SemiBold"�6:    
 PricePerOne#��� 
 6P   �� 5w   "   $��1��6,   $��10 0 0 0q�69   $��1��6K   ��6[   �� *Price+$ PropertyChanged=��� 5y   "   $��2��6,   $��SemiBold"�69    	 Genre#���  6O   �� 5z   "   $��2��6,   $��10 0 0 0q�69   $��1��6K   ��6[   �� *Genre+$ PropertyChanged=��� 5|   "   $��3��6-   $��SemiBold"�6:   #���  6P   �� 5}   "   $��3��6+   $��10 0 0 0q�68   $��1��6J   ${�False��6Z   	 6l   �� *	Available+$ PropertyChanged=�5~      5      5�      5�      5�      �� 5�   
   $
 
Horizontal=�6   $��3��6.   $	��0 3q�6;   .+�5�      �� $��Center=�6   $��Center=�6�     AddBook#���  6�   $��0 5 5 5q�6�   y�62   ��  �� Path$ IsAdmin�# [  ��6�   �� *
AddCommand+�� 5�      $��Center=�6   $��Center=�6�     EditBook#���  6�   $��5q�6�   y�62   �� $ IsAdmin�# [  ��6�   �� *EditCommand+�� 5�      $��Center=�6   $��Center=�62     ViewBook#���  6M   $��5q�6r   ��6}   �� *ViewCommand+�� 5�      $��Center=�6   $��Center=�6�     
DeleteBook#���  6�   $��5q�6�   y�62   �� $ IsAdmin�# [  ��6�   �� *DeleteCommand+�� 5�      $��Center=�6   $��Center=�6�     	AddToCart#���  6�   $��5 0 5 0q�6�   y�62   �� $ IsAdmin�# [ ��6�   �� *AddToCartCommand+5�      5�      5�      