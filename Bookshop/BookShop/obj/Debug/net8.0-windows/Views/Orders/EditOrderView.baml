   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BookShop.ViewModels.OrdersBookShop.ViewModels.Orders  5      )    #BookShop.Views.Orders.EditOrderView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;orders(clr-namespace:BookShop.ViewModels.Orders     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5   
   $��1��6   $
��Auto=�6$   $��0q�6G   .��5      � $��0q�6     5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      .+�5!      ��    Date#���   6   $��0 0 5 10q�6:   $��SemiBold"�6L   �� 5"      $��0��6   $��1��6)   $��0 0 5 10q�69   ��6L   �� *Entity.Date+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True�� �� StringFormat$ 
dd.MM.yyyy���� 5#      $��1��6   $��0��6)     
TotalPrice#���  69   $��SemiBold"�6]   $��0 0 5 10q�6s   �� 5$      $��1��6   $��1��6)   $��0 0 5 10q�69   $
��Wrap=�6�   ��6K   �� *Entity.TotalPrice+$ PropertyChanged=�$
 True��$
 True��6�   �� 5%      $��2��6   $��0��6)     	FirstName#���  69   $��SemiBold"�6\   $��0 0 5 10q�6r   �� 5&      $��2��6   $��1��6)   $��0 0 5 10q�69   ��6K   �� *Entity.User.FirstName+$ PropertyChanged=�$
 True��$
 True���� 5'      $��3��6   $��0��6)     LastName#���  69   $��SemiBold"�6[   $��0 0 5 10q�6q   �� 5(      $��3��6   $��1��6)   $��0 0 5 10q�69   ��6K   �� *Entity.User.LastName+$ PropertyChanged=�$
 True��$
 True���� 5)      $��4��6   $��0��6)    
 Status#���  69   $��SemiBold"�6Y   $��0 0 5 10q�6o   �� 5*      $��4��6   $��1��6(   $��0 0 0 10q�68    �� DisplayMemberPath$
 Name��5-       �� SelectedValuePath$ Id��5.      ��5+      �� *
Statuses+$ PropertyChanged=�$
 True��$
 True�� �� SelectedItem 5,      �� *SelectedStatus+$ PropertyChanged=�$
 True��$
 True��5.      50      51      �� 52   
   $��2��6   	 �� Orientation$	 
Horizontal=�6"   $��0q�6;   .+�53      ��   Save#���  6   $��0 0 5 0q�66   ��6G   �� *SaveCommand+6i   �� 54        Back#���  6   $��5 0 0 0q�66   ��6G   �� *BackCommand+6i   55      56      57      