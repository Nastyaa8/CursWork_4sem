   M S B A M L   `   `   `  ����L  HBookShop.Personal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookShopBookShop  5      H DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters 5      K*clr-namespace:BookShop.Personal.Views.BaseBookShop.Personal.Views.Base  5      K*clr-namespace:BookShop.Personal.ViewModelsBookShop.Personal.ViewModels  5	      E'clr-namespace:BookShop.Personal.ControlBookShop.Personal.Control  5
      &     BookShop.Personal.Views.MainView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +bookShopclr-namespace:BookShop     5      T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5      ;base*clr-namespace:BookShop.Personal.Views.Base     5      A
viewModels*clr-namespace:BookShop.Personal.ViewModels     5	      ;control'clr-namespace:BookShop.Personal.Control     5
         WindowBackground#���   5        � 	Resources  5      ;  5BookShop.Mvvm.Converters.BooleanToVisibilityConverter   BooleanToVisibilityConverterB  <BookShop.Mvvm.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter9  3BookShop.Mvvm.Converters.ByteToImageSourceConverter  ByteToImageSourceConverter��%W   &	       &	      &	 &       5   
   62     5   
   69     5   
   60   5      .��5      � y�6   �� *
IsLogged+ �� 	Converter# [  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5      $
��0.2* �6   .+�5    
   (   "BookShop.Personal.Control.UserIcon  (   "BookShop.Personal.Control.UserIcon   ImageChanged$ UserIcon_OnImageChanged��6   $��0��6�   $��0��6�   $��3��6�      Image 6C   �� *
User.Image+ �� UpdateSourceTrigger$ PropertyChanged=�# [  �� Mode$ TwoWay=�   DescriptionText 6�   �� *
User.Email+	   Text	 5!      �� 5"      �� 5#      �6   �� *User.LastName+ �� 5$      $� ��6    �� 5%      �6   �� *User.FirstName+5&      5(      � 52   
   $��1��6   $��2��6    53      �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6     5<      �� 5=      $
��Auto �6#   �� 5>      .+�5A      �� $��16(�6   $��SemiBold"�6&    	 Login#���  6<   $��10q�6[   �� 5B      $��1��6   $��0��6&   $��10q�63   $��18(�6?   ��6M   �� *
User.Login+$ PropertyChanged=�
 �� ValidatesOnDataErrors$

 True��" �� ValidatesOnNotifyDataErrors$
 True�� �� NotifyOnValidationError$
 True���� 5D      $��16(�6   $��SemiBold"�6&   $��10q�6<   $��0��6H   $��1��6X    	 Email#���  6e   �� 5E      $��1��6   $��1��6&   $��10q�63   $��18(�6?   ��6M   �� *
User.Email+$ PropertyChanged=�$

 True��$
 True��$
 True���� 5G      $��16(�6   $��SemiBold"�6&   $��10q�6<   $��0��6H   $��2��6X     LastName#���  6e   �� 5H      $��1��6   $��2��6&   $��10q�63   $��18(�6?   ��6M   �� *User.LastName+$ PropertyChanged=�$

 True��$
 True��$
 True���� 5J      $��16(�6   $��SemiBold"�6&   $��10q�6<   $��0��6I   $��3��6Y     	FirstName#���  6f   �� 5K      $��1��6   $��3��6&   $��10q�63   $��18(�6?   ��6M   �� *User.FirstName+$ PropertyChanged=�$

 True��$
 True��$
 True���� 5M      $��16(�6   $��SemiBold"�6&   $��10q�6<   $��0��6I   $��4��6Y    	 Phone#���  6f   �� 5N      $��1��6   $��4��6&   $��10q�63   $��18(�6?   ��6M   �� *
User.Phone+$ PropertyChanged=�$

 True��$
 True��$
 True���� 5P      $��16(�6   $��SemiBold"�6&   $��10q�6<   $��0��6I   $��5��6Y    	 Address#��� 	 6f   �� 5Q      $��1��6   $��5��6&   $��10q�63   $��18(�6?   ��6M   �� *User.Address+$ PropertyChanged=�$

 True��$
 True��$
 True��5R      �� 5S   
   $��1��6   $��3��6!   $��20q�6.    
 Save#��� 
 6:   $
��15 5q�6[   ��6j   �� *SaveCommand+5T      5U      