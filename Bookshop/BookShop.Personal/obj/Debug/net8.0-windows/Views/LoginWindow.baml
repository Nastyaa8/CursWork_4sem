   M S B A M L   `   `   `  ����L  HBookShop.Personal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BookShop.Personal.ViewModelsBookShop.Personal.ViewModels  5   	   )    #BookShop.Personal.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   A
viewModels*clr-namespace:BookShop.Personal.ViewModels     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	     � 
ResizeMode$  NoResize=�5	   	    � SizeToContent$ Height=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	      WindowBackground#���   5   	    � Title$ LoginWindow��5   	   $	��270��6   $	��320��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   ��   
LoginTitle#���  6   $��Center=�67   $��20q�6T   $��20(�6`   $
��Bold"�6n   6�   � 5   
   $��1��6   $��15q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5!      �� $��0��6   $��0��6%   #���  65   $��5q�6Y   �� 5"      -   5         ��Name$ TextBox��5"      $��0��6'   $��1��64   $��5q�6D   ��6O   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5#      +  %Microsoft.Xaml.Behaviors.EventTrigger  5$      	   	EventName$	 PreviewTextInput��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5%      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     PassEventArgsToCommand$
 True��60      Command 6N   �� *TextChangeCommand+6v   5&      .��5'   *   5(      �� 5*      $��1��6   $��0��6%     Password#���  65   $��5q�6W   �� 5+      $��1��6   $��1��6#   $��5q�63   ��6>   �� *
Password+$ PropertyChanged=�.��6}    5,        5-      $	 PreviewTextInput��6%   .
 5.        $
 True��60    6N   �� *TextChangeCommand+6v   5/      .��50   *   52      �� 54      $��2��6   $��0��6'   $��2��67    �� Orientation$ 
Horizontal=�6K   $��Center=�6d   .+�55      ��   LoginButton#���  6   $
��5 15q�6A   ��6O   �� *LoginCommand+56      �� 57      $ 
Horizontal=�6   $��3��63   $��0��6A   $��2��6Q   .+�58      ��   Undo#���  6   $
��5 15q�6:   ��6H   �� *UndoCommand+�� 59        Redo#���  6   $
��5 15q�6:   ��6H   �� *RedoCommand+5:      5;      5<      5=      