   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BookShop.ViewModels.OrdersBookShop.ViewModels.Orders  )    #BookShop.Views.Orders.EditOrderView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;orders(clr-namespace:BookShop.ViewModels.Orders     .���   � RowDefinitions  �� $
��Auto ��� �� $
��Auto �.+��� ���� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$
��Auto=�$��0q�.��� $��0q�  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+���    Date#���   $��0 0 5 10q�$��SemiBold"��� $��0��$��1��$��0 0 5 10q����� *Entity.Date+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True�� �� StringFormat$ 
dd.MM.yyyy���� $��1��$��0��  
TotalPrice#���  $��SemiBold"�$��0 0 5 10q��� $��1��$��1��$��0 0 5 10q�$
��Wrap=����� *Entity.TotalPrice+$ PropertyChanged=�$
 True��$
 True���� $��2��$��0��  	FirstName#���  $��SemiBold"�$��0 0 5 10q��� $��2��$��1��$��0 0 5 10q����� *Entity.User.FirstName+$ PropertyChanged=�$
 True��$
 True���� $��3��$��0��  LastName#���  $��SemiBold"�$��0 0 5 10q��� $��3��$��1��$��0 0 5 10q����� *Entity.User.LastName+$ PropertyChanged=�$
 True��$
 True���� $��4��$��0�� 
 Status#���  $��SemiBold"�$��0 0 5 10q��� $��4��$��1��$��0 0 0 10q� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *
Statuses+$ PropertyChanged=�$
 True��$
 True�� �� SelectedItem �� *SelectedStatus+$ PropertyChanged=�$
 True��$
 True���� $��2��	 �� Orientation$	 
Horizontal=�$��0q�.+���   Save#���  $��0 0 5 0q����� *SaveCommand+��   Back#���  $��5 0 0 0q����� *BackCommand+