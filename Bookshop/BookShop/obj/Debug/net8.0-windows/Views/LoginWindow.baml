   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels  5   	        BookShop.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8
viewModels!clr-namespace:BookShop.ViewModels     5   	     � 
ResizeMode$  NoResize=�5   	    � SizeToContent$ Height=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      WindowBackground#���   5   	    � Title$ LoginWindow��5   	   $	��250��6   $	��320��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   ��   
LoginTitle#���  6   $��Center=�67   $��20q�6T   $��20(�6`   $
��Bold"�6n   6�   � 5   
   $��1��6   $��15q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $��0��6   $��0��6%   #���  65   $��5q�6Y   �� 5       $��0��6   $��1��6#   $��5q�63   ��6>   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� 5"      $��1��6   $��0��6%     Password#���  65   $��5q�6W   �� 5#      $��1��6   $��1��6#   $��5q�63   ��6>   �� *
Password+$ PropertyChanged=��� 5%      $��2��6   $��0��6#   $��2��63   $��Center=�6G     LoginButton#���  6d   $
��5 15q�6�   ��5&      �� *LoginCommand+5'      5(      5)      5*      