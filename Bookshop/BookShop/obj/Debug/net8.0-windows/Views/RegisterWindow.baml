   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels  5   	   #    BookShop.Views.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8
viewModels!clr-namespace:BookShop.ViewModels     5   	     � 
ResizeMode$  NoResize=�5   	    � SizeToContent$ Height=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      WindowBackground#���   5   	     RegisterTitle � Title# �  5   	   $	��400��61   $	��320��6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� #���  6   $��Center=�6:   $��20q�6W   $��20(�6c   $
��Bold"�6q   6�   � 5   
   $��1��6   $��15q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5       �� 5!      $
��Auto �6#   �� 5"      .+�5%      �� $��0��6   $��0��6%    	 Login#���  65   $��5q�6T   �� 5&       �� 	MaxLength$	 255��6   $��0��6&   $��1��63   $��5q�6C   ��6N   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=��� 5(      $��1��6   $��0��6%    	 Email#���  65   $��5q�6T   �� 5)      $	 255��6   $��1��6&   $��1��63   $��5q�6C   ��6N   �� *Email+$ PropertyChanged=��� 5+      $��2��6   $��0��6%     LastName#���  65   $��5q�6W   �� 5,      $	 255��6   $��2��6&   $��1��63   $��5q�6C   ��6N   �� *
LastName+$ PropertyChanged=��� 5.      $��3��6   $��0��6%     	FirstName#���  65   $��5q�6X   �� 5/      $	 255��6   $��3��6&   $��1��63   $��5q�6C   ��6N   �� *	FirstName+$ PropertyChanged=��� 51      $��4��6   $��0��6%    	 Phone#���  65   $��5q�6T   �� 52      $	 255��6   $��4��6&   $��1��63   $��5q�6C   ��6N   �� *Phone+$ PropertyChanged=��� 54      $��5��6   $��0��6%     Address#���  65   $��5q�6V   �� 55      $	 255��6   $��5��6&   $��1��63   $��5q�6C   ��6N   �� *	Address+$ PropertyChanged=��� 57      $��6��6   $��0��6%     Password#���  65   $��5q�6W   �� 58      $	 255��6   $��6��6&   $��1��63   $��5q�6C   ��6N   �� *
Password+$ PropertyChanged=��� 5:      $��7��6   $��0��6%    	 ConfirmPassword#��� 	 65   $��5q�6^   �� 5;      $	 255��6   $��7��6&   $��1��63   $��5q�6C   ��6N   �� *ConfirmPassword+$ PropertyChanged=��� 5=      $��8��6   $��0��6#   $��2��63   $��Center=�6G    
 RegisterButton#��� 
 6d   $
��5 15q�6�   ��5>      �� *RegisterCommand+5?      5@      5A      5B      