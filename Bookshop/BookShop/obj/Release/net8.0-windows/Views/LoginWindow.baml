   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels       BookShop.Views.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
viewModels!clr-namespace:BookShop.ViewModels       � 
ResizeMode$  NoResize=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterScreen=�   WindowBackground#���    � Title$ LoginWindow��$	��250��$	��320��.���  � RowDefinitions �� $
��Auto ��� .+���   
LoginTitle#���  $��Center=�$��20q�$��20(�$
��Bold"�� $��1��$��15q� �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+��� $��0��$��0��#���  $��5q��� $��0��$��1��$��5q����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��0��  Password#���  $��5q��� $��1��$��1��$��5q����� *
Password+$ PropertyChanged=��� $��2��$��0��$��2��$��Center=�  LoginButton#���  $
��5 15q����� *LoginCommand+