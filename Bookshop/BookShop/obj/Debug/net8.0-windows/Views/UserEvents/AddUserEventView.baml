   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:BookShop.ViewModels.UserEventsBookShop.ViewModels.UserEvents  5      0    *BookShop.Views.UserEvents.AddUserEventView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      C
userEvents,clr-namespace:BookShop.ViewModels.UserEvents     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6R   � 5   
   $��1��6   $	��0 5q�6     5      �� 5      $
��Auto �6    �� 5      .+�5      ��    SelectEvent#���   6   &   System.Windows.Controls.DataGrid  5      $��1��6   $	��0 5q�6$      
IsReadOnly$
 True��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         AutoGenerateColumns$ False��5      ��5      �� *Events+$ PropertyChanged=� �� SelectedItem 5      �� *Entity.Event+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5        DataGridColumnHeaderStyle,  &System.Windows.Controls.DataGridColumn   HeaderStyle# �  6)   	   Header$	 Id��6c   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6o   �� *Id+$ PropertyChanged=�6�     5         HeaderStyleName# �  6)   $
 * 6�    6Y   �� *Name+$ PropertyChanged=�6�     5!        HeaderStyleDescription# �  6)   $
 * 6�    6`   �� *Description+$ PropertyChanged=�6�     5"        HeaderStyleLocation# �  6)   $
 * 6�    6]   �� *
Location+$ PropertyChanged=�6�     5#        HeaderStyleDate# �  6)   $
 * 6�    6Y   �� *Date+$ PropertyChanged=� �� StringFormat$ 
dd.MM.yyyy��6�   5%      5&      �� 5'   
   $��2��6    �� Orientation$ 
Horizontal=�6"   .+�5(      ��   Save#���  6   $��0 0 5 0q�66   ��6G   �� *SaveCommand+6i   �� 5)        Back#���  6   $��5 0 0 0q�66   ��6G   �� *BackCommand+6i   5*      5+      5,      