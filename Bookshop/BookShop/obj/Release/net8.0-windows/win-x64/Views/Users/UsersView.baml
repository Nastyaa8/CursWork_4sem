   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  $    BookShop.Views.Users.UsersView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9users'clr-namespace:BookShop.ViewModels.Users     .���   � RowDefinitions  �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�&   System.Windows.Controls.DataGrid  $��1��   
IsReadOnly$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False������ *Items+$ PropertyChanged=� �� SelectedItem �� *SelectedItem+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn     DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [  	   Header$	 Id��
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+$ PropertyChanged=�    HeaderStyleLogin# [ $
 *  �� *Login+$ PropertyChanged=�    HeaderStyleEmail# [ $
 *  �� *Email+$ PropertyChanged=�    HeaderStyleFirstName# [ $
 *  �� *	FirstName+$ PropertyChanged=�    HeaderStyleLastName# [ $
 *  �� *
LastName+$ PropertyChanged=�    HeaderStylePhone# [ $
 *  �� *Phone+$ PropertyChanged=�    HeaderStyleAddress# [ $
 *  �� *	Address+$ PropertyChanged=�4  .System.Windows.Controls.DataGridCheckBoxColumn    HeaderStyleIsAdmin# [ $

 Auto  �� *	IsAdmin+$ PropertyChanged=���  �� Orientation$ 
Horizontal=�$��2��$��3q�.+��� $��Center=�$��Center=�  AddUser#���  $��0 0 5 0q����� *
AddCommand+�� $��Center=�$��Center=� 	 EditUser#��� 	 $��5q����� *EditCommand+�� $��Center=�$��Center=� 
 
DeleteUser#��� 
 $��5 0 0 0q����� *DeleteCommand+