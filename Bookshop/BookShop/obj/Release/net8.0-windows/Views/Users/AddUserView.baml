   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  &     BookShop.Views.Users.AddUserView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9users'clr-namespace:BookShop.ViewModels.Users     .���   � RowDefinitions  �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$
��Auto=�$��5q�.��� $��5q�  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+���  	  Login#���   $��0 0 5 10q��� $��0��$��1��$��0 0 5 10q����� *
User.Login+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� $��1��$��0�� 	 Email#���  $��0 0 5 10q��� $��1��$��1��$��0 0 5 10q����� *
User.Email+$ PropertyChanged=�$
 True��$
 True���� $��2��$��0��  	FirstName#���  $��0 0 5 10q��� $��2��$��1��$��0 0 5 10q����� *User.FirstName+$ PropertyChanged=�$
 True��$
 True���� $��3��$��0��  LastName#���  $��0 0 5 10q��� $��3��$��1��$��0 0 5 10q����� *User.LastName+$ PropertyChanged=�$
 True��$
 True���� $��4��$��0��  Address#���  $��0 0 5 10q��� $��4��$��1��$��0 0 5 10q����� *User.Address+$ PropertyChanged=�$
 True��$
 True���� $��5��$��0�� 	 Phone#���  $��0 0 5 10q��� $��5��$��1��$��0 0 5 10q����� *
User.Phone+$ PropertyChanged=�$
 True��$
 True���� $��6��$��0��  Password#���  $��0 0 5 10q��� $��6��$��1��$��0 0 5 10q����� *User.Password+$ PropertyChanged=�$
 True��$
 True���� $��7��$��0��$��0 0 5 10q�  IsAdmin#���   d� 	IsChecked �� *User.IsAdmin+$ PropertyChanged=�$
 True��$
 True���� $��2�� �� Orientation$ 
Horizontal=�$��5q�.+���   Save#���  $��5 0 5 0q����� *SaveCommand+��  	 Back#��� 	 $��5 0 0 0q����� *BackCommand+