   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BookShop.ViewModels.EventsBookShop.ViewModels.Events  5      (    "BookShop.Views.Events.AddEventView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;events(clr-namespace:BookShop.ViewModels.Events     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5   
   $��1��6   $
��Auto=�6$   $��5q�6G   .��5      � $��5q�6     5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      .+�5!      �� $��SemiBold"�6   #��� ��62   $��0 0 5 10q�6P   �� 5"      $��0��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *Entity.Name+$ PropertyChanged=� �� NotifyOnValidationError$
 True��" �� ValidatesOnNotifyDataErrors$
 True���� 5#      $��SemiBold"�6   $��1��62   $��0��6?      Description#���   6O   $��0 0 5 10q�6t   �� 5$      $��1��6   $��1��6'   $��0 0 5 10q�67   $��50��6I   " �� VerticalScrollBarVisibility$
 Auto=�6U    �� TextWrapping$
 Wrap=�6  ��6x   �� *Entity.Description+$ PropertyChanged=�$
 True��$
 True��6  �� 5%      $��SemiBold"�6   $��2��62   $��0��6?     Location#���  6P   $��0 0 5 10q�6r   �� 5&      $��2��6   $��1��6'   $��0 0 5 10q�67   ��6I   �� *Entity.Location+$ PropertyChanged=�$
 True��$
 True���� 5'      $��SemiBold"�6   $��3��62   $��0��6?     Date#���  6P   $��0 0 5 10q�6n   (  "System.Windows.Controls.DatePicker  5(      $��3��6   $��1��6*   $��0 0 5 10q�6:      SelectedDate 6L   �� *Entity.Date+$ PropertyChanged=�$
 True��$
 True��5)      5*      �� 5+   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5,      ��   Save#���  6   $��0 0 5 0q�66   ��6G   �� *SaveCommand+6i   �� 5-        Back#���  6   $��5 0 0 0q�66   ��6G   �� *BackCommand+6i   5.      5/      50      