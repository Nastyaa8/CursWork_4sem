   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5      H DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters 5      '    !BookShop.Views.Books.BookInfoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9books'clr-namespace:BookShop.ViewModels.Books     5      T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5        � 	Resources  5      B  <BookShop.Mvvm.Converters.InverseBooleanToVisibilityConverter '  #InverseBooleanToVisibilityConverter;  5BookShop.Mvvm.Converters.StringToImageSourceConverter  ImageConverter��%:   &	        &	        5   
   69     5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5   
   $��1��6   $
��Auto=�6$   $��5q�6G   .��5      � $��5q�6    5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$    � ColumnDefinitions 5#      �� 5$      $
��Auto �6'   �� 5%      .+�5'      �� 
�������$	��0 5q�61    �� CornerRadius$ 5��6>   $��2q�6O   $��2��6c   $��Center=�6w   ._�5(      �� $	��400��6   $��Uniform=�6*   ��6<   �� *Entity.Image+$ PropertyChanged=� �� 	Converter# [ 6�   5)      �� 5*      $��1��6   $��16(�6)   $��SemiBold"�67   #��� ��6M   $��0 0 5 10q�6k   �� 5+      $��1��6   $��16(�6)   $��1��67   $��	10 0 5 10q�6G   ��6Z   �� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� 5,      $��SemiBold"�6   $��16(�62   $��2��6@   $��0��6M    
 Author#���  6]   $��0 0 5 10q�6}   �� 5-      $��2��6   $��16(�6)   $��1��67   $��	10 0 5 10q�6G   ��6Z   �� *Entity.Author+$ PropertyChanged=�$
 True��$
 True���� 5.      $��SemiBold"�6   $��16(�62   $��3��6@   $��0��6M    	 Genre#���  6^   $��0 0 5 10q�6}   �� 5/      $��3��6   $��16(�6)   $��1��67   $��	10 0 5 10q�6G   ��50      �� *Entity.Genre+$ PropertyChanged=�$
 True��$
 True���� 52      $��SemiBold"�6   $��16(�62   $��4��6@   $��0��6M    	 Price#���  6]   $��0 0 5 10q�6|   �� 53      $��16(�6   $��4��6�   $��1��6�   $��	10 0 5 10q�6�   ��6*   �� *Entity.Price+$ PropertyChanged=�$
 True��$
 True�� �� Mode$ TwoWay=�6�   �� 54      $��16(�6   ${�False��6)   $��SemiBold"�6;   $��5��6Q   $��0��6^   $��2��6n   $��0 0 5 15q�6�     BookIsAvailable#���  6�   	 d� 	IsChecked	 6�   �� *Entity.Available+$ PropertyChanged=�$
 True��$
 True���� 56      $��SemiBold"�6   $��16(�62   $��6��6@   $��0��6M     Description#���  6]   $��0 0 5 10q�6�   �� 57      $��16(�6   $��6��6�   $��1��6�   $��	10 0 5 10q�6�   ��6*   �� *Entity.Description+$ PropertyChanged=�$
 True��$
 True��$ TwoWay=�6�   58      59      �� 5:   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��5q�6;   .+�5;      �� $��Center=�6   $��Center=�6�     	AddToCart#���  6�   $��5 0 5 0q�6�   y�62   ��  �� Path$ IsAdmin�# [  ��6�   �� *AddToCartCommand+�� 5<        Back#���  6   $��0 0 5 0q�66   ��6G   �� *BackCommand+6i   5=      5>      5?      