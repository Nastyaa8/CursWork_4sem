   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  5      $    BookShop.Views.Users.UsersView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9users'clr-namespace:BookShop.ViewModels.Users     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   &   System.Windows.Controls.DataGrid  5   
   $��1��6      
IsReadOnly$
 True��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         AutoGenerateColumns$ False��5      ��5      �� *Items+$ PropertyChanged=� �� SelectedItem 5      �� *SelectedItem+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [  6%   	   Header$	 Id��6^   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6j   �� *Id+$ PropertyChanged=�6�     5        HeaderStyleLogin# [ 6%   $
 * 6�    6U   �� *Login+$ PropertyChanged=�6�     5        HeaderStyleEmail# [ 6%   $
 * 6�    6U   �� *Email+$ PropertyChanged=�6�     5        HeaderStyleFirstName# [ 6%   $
 * 6�    6Y   �� *	FirstName+$ PropertyChanged=�6�     5        HeaderStyleLastName# [ 6%   $
 * 6�    6X   �� *
LastName+$ PropertyChanged=�6�     5        HeaderStylePhone# [ 6%   $
 * 6�    6U   �� *Phone+$ PropertyChanged=�6�     5        HeaderStyleAddress# [ 6%   $
 * 6�    6W   �� *	Address+$ PropertyChanged=�6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5         HeaderStyleIsAdmin# [ 6)   $

 Auto 6�    6[   �� *	IsAdmin+$ PropertyChanged=�6�   5"      �� 5#   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��3q�6;   .+�5$      �� $��Center=�6   $��Center=�62     AddUser#���  6M   $��0 0 5 0q�6q   ��6�   �� *
AddCommand+�� 5%      $��Center=�6   $��Center=�62    	 EditUser#��� 	 6M   $��5q�6r   ��6}   �� *EditCommand+�� 5&      $��Center=�6   $��Center=�62    
 
DeleteUser#��� 
 6M   $��5 0 0 0q�6t   ��6�   �� *DeleteCommand+5'      5(      5)      