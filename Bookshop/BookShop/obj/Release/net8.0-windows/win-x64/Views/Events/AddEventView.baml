   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BookShop.ViewModels.EventsBookShop.ViewModels.Events  (    "BookShop.Views.Events.AddEventView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;events(clr-namespace:BookShop.ViewModels.Events     .���   � RowDefinitions  �� $
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
��Auto ��� .+��� $��SemiBold"�#��� ��$��0 0 5 10q��� $��0��$��1��$��0 0 5 10q����� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� $��SemiBold"�$��1��$��0��   Description#���   $��0 0 5 10q��� $��1��$��1��$��0 0 5 10q�$��50��" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=����� *Entity.Description+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��2��$��0��  Location#���  $��0 0 5 10q��� $��2��$��1��$��0 0 5 10q����� *Entity.Location+$ PropertyChanged=�$
 True��$
 True���� $��SemiBold"�$��3��$��0��  Date#���  $��0 0 5 10q�(  "System.Windows.Controls.DatePicker  $��3��$��1��$��0 0 5 10q�   SelectedDate �� *Entity.Date+$ PropertyChanged=�$
 True��$
 True���� $��2�� �� Orientation$ 
Horizontal=�$��5q�.+���   Save#���  $��0 0 5 0q����� *SaveCommand+��   Back#���  $��5 0 0 0q����� *BackCommand+