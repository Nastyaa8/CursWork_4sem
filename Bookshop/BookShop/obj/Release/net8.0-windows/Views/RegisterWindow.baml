   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels  #    BookShop.Views.RegisterWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
viewModels!clr-namespace:BookShop.ViewModels       � 
ResizeMode$  NoResize=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterScreen=�   WindowBackground#���     RegisterTitle � Title# �  $	��400��$	��320��.���  � RowDefinitions �� $
��Auto ��� .+��� #���  $��Center=�$��20q�$��20(�$
��Bold"�� $��1��$��15q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+��� $��0��$��0�� 	 Login#���  $��5q���  �� 	MaxLength$	 255��$��0��$��1��$��5q����� *Login+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��0�� 	 Email#���  $��5q��� $	 255��$��1��$��1��$��5q����� *Email+$ PropertyChanged=��� $��2��$��0��  LastName#���  $��5q��� $	 255��$��2��$��1��$��5q����� *
LastName+$ PropertyChanged=��� $��3��$��0��  	FirstName#���  $��5q��� $	 255��$��3��$��1��$��5q����� *	FirstName+$ PropertyChanged=��� $��4��$��0�� 	 Phone#���  $��5q��� $	 255��$��4��$��1��$��5q����� *Phone+$ PropertyChanged=��� $��5��$��0��  Address#���  $��5q��� $	 255��$��5��$��1��$��5q����� *	Address+$ PropertyChanged=��� $��6��$��0��  Password#���  $��5q��� $	 255��$��6��$��1��$��5q����� *
Password+$ PropertyChanged=��� $��7��$��0�� 	 ConfirmPassword#��� 	 $��5q��� $	 255��$��7��$��1��$��5q����� *ConfirmPassword+$ PropertyChanged=��� $��8��$��0��$��2��$��Center=� 
 RegisterButton#��� 
 $
��5 15q����� *RegisterCommand+