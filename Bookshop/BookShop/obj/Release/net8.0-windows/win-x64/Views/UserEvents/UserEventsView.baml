   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:BookShop.ViewModels.UserEventsBookShop.ViewModels.UserEvents  .    (BookShop.Views.UserEvents.UserEventsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     C
userEvents,clr-namespace:BookShop.ViewModels.UserEvents       � 	Resources      BooleanToVisibilityConverter��%   &	        �� .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�&   System.Windows.Controls.DataGrid  $��1��$	��0 5q�   
IsReadOnly$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False������ *Items+$ PropertyChanged=� �� SelectedItem �� *SelectedItem+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn    DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn	   HeaderStyle#	 �  
   Header$
 Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+$ PropertyChanged=�    HeaderStyleName#	 �  $ *  �� *
Event.Name+$ PropertyChanged=�    HeaderStyleDescription#	 �  $ *  �� *Event.Description+$ PropertyChanged=�    HeaderStyleLocation#	 �  $ *  �� *Event.Location+$ PropertyChanged=�    HeaderStyleDate#	 �  $ *  �� *
Event.Date+$ PropertyChanged=� �� StringFormat$ 
dd.MM.yyyy����  �� Orientation$ 
Horizontal=�$��2��$	��0 5q�.+��� $��Center=�$��Center=�  Register#���  $��0 0 5 0q����� *
AddCommand+�� $��Center=�$��Center=�  CancelRegister#���  $��5 0 0 0q����� *DeleteCommand+