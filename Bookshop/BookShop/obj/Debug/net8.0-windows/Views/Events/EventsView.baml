   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BookShop.ViewModels.EventsBookShop.ViewModels.Events  5      &     BookShop.Views.Events.EventsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;events(clr-namespace:BookShop.ViewModels.Events     5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   &   System.Windows.Controls.DataGrid  5   
   $��1��6      
IsReadOnly$
 True��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         AutoGenerateColumns$ False��5      ��5      �� *Items+$ PropertyChanged=� �� SelectedItem 5      �� *SelectedItem+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5        DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn	   HeaderStyle#	 �  6%   
   Header$
 Id��6_      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6k   �� *Id+$ PropertyChanged=�6�     5        HeaderStyleName#	 �  6%   $ * 6�    6U   �� *Name+$ PropertyChanged=�6�     5        HeaderStyleDescription#	 �  6%   $ * 6�    6\   �� *Description+$ PropertyChanged=�6�     5        HeaderStyleLocation#	 �  6%   $ * 6�    6Y   �� *
Location+$ PropertyChanged=�6�     5         HeaderStyleDate#	 �  6%   $ * 6�    6U   �� *Date+$ PropertyChanged=� �� StringFormat$ 
dd.MM.yyyy��6�   5"      �� 5#   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $	��0 5q�6;   .+�5$      �� $��Center=�6   $��Center=�6�     AddEvent#���  6�   $��0 0 5 0q�6�   y�62   ��  �� Path$ IsAdmin� �� 	Converter# [  ��6�   �� *
AddCommand+�� 5%      $��Center=�6   $��Center=�6�     	EditEvent#���  6�   $��5q�6�   y�62   �� $ IsAdmin�# [  ��6�   �� *EditCommand+�� 5&      $��Center=�6   $��Center=�6�     DeleteEvent#���  6�   $��5 0 0 0q�6�   y�62   �� $ IsAdmin�# [  ��6�   �� *DeleteCommand+5'      5(      5)      