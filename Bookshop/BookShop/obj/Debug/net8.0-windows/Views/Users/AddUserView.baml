   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  5      &     BookShop.Views.Users.AddUserView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9users'clr-namespace:BookShop.ViewModels.Users     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5   
   $��1��6   $
��Auto=�6$   $��5q�6G   .��5      � $��5q�6     5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      .+�5!      ��  	  Login#���   6   $��0 0 5 10q�6;   �� 5"      $��0��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *
User.Login+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� 5#      $��1��6   $��0��6)    	 Email#���  69   $��0 0 5 10q�6X   �� 5$      $��1��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *
User.Email+$ PropertyChanged=�$
 True��$
 True���� 5%      $��2��6   $��0��6)     	FirstName#���  6:   $��0 0 5 10q�6]   �� 5&      $��2��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *User.FirstName+$ PropertyChanged=�$
 True��$
 True���� 5'      $��3��6   $��0��6)     LastName#���  69   $��0 0 5 10q�6[   �� 5(      $��3��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *User.LastName+$ PropertyChanged=�$
 True��$
 True���� 5)      $��4��6   $��0��6)     Address#���  69   $��0 0 5 10q�6Z   �� 5*      $��4��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *User.Address+$ PropertyChanged=�$
 True��$
 True���� 5+      $��5��6   $��0��6)    	 Phone#���  6:   $��0 0 5 10q�6Y   �� 5,      $��5��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *
User.Phone+$ PropertyChanged=�$
 True��$
 True���� 5-      $��6��6   $��0��6)     Password#���  69   $��0 0 5 10q�6[   �� 5.      $��6��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *User.Password+$ PropertyChanged=�$
 True��$
 True���� 5/      $��7��6   $��0��6(   $��0 0 5 10q�68     IsAdmin#���  6J    d� 	IsChecked 6n   �� *User.IsAdmin+$ PropertyChanged=�$
 True��$
 True��50      51      �� 52   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�53      ��   Save#���  6   $��5 0 5 0q�66   ��6G   �� *SaveCommand+6i   �� 54       	 Back#��� 	 6   $��5 0 0 0q�66   ��6G   �� *BackCommand+6i   55      56      57      