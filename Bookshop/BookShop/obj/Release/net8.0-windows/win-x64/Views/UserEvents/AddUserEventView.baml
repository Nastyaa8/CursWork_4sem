   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:BookShop.ViewModels.UserEventsBookShop.ViewModels.UserEvents  0    *BookShop.Views.UserEvents.AddUserEventView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     C
userEvents,clr-namespace:BookShop.ViewModels.UserEvents     .���   � RowDefinitions  �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��$	��0 5q�  �� $
��Auto ��� .+���    SelectEvent#���   &   System.Windows.Controls.DataGrid  $��1��$	��0 5q�   
IsReadOnly$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False������ *Events+$ PropertyChanged=� �� SelectedItem �� *Entity.Event+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# �  	   Header$	 Id��
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+$ PropertyChanged=�    HeaderStyleName# �  $
 *  �� *Name+$ PropertyChanged=�    HeaderStyleDescription# �  $
 *  �� *Description+$ PropertyChanged=�    HeaderStyleLocation# �  $
 *  �� *
Location+$ PropertyChanged=�    HeaderStyleDate# �  $
 *  �� *Date+$ PropertyChanged=� �� StringFormat$ 
dd.MM.yyyy���� $��2�� �� Orientation$ 
Horizontal=�.+���   Save#���  $��0 0 5 0q����� *SaveCommand+��   Back#���  $��5 0 0 0q����� *BackCommand+