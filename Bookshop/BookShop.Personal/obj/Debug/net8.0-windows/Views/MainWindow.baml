   M S B A M L   `   `   `  ����H  DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters  5   	   V;clr-namespace:BookShop.Mvvm.Commands;assembly=BookShop.MvvmBookShop.Mvvm.Commands  5   	   L HBookShop.Personal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BookShop.Personal.ViewModelsBookShop.Personal.ViewModels 5   	   A%clr-namespace:BookShop.Personal.ViewsBookShop.Personal.Views 5	   	   (   "BookShop.Personal.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5   	   Pcommands;clr-namespace:BookShop.Mvvm.Commands;assembly=BookShop.Mvvm     5   	   A
viewModels*clr-namespace:BookShop.Personal.ViewModels     5   	   7views%clr-namespace:BookShop.Personal.Views     5	   	     � WindowStartupLocation$  CenterScreen=�5   	      WindowBackground#���   5   	     PersonTitle � Title# �  5   	   $	��800��6/   $
��1100��6<    J� InputBindings 5      �� 5   
   +   %BookShop.Mvvm.Commands.CustomCommands   ShowMessage �� Command# Z 6   
 �� Key$ X��5       �� 	Modifiers$	 Altf�6    � 	Resources 5      B   <BookShop.Mvvm.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter �� DataType0  *BookShop.Personal.ViewModels.MainViewModel&   BookShop.Personal.Views.MainView��%h   &	       (��      5      *, +)  5   
   69   �� 5   
   "  6   .R�5        5      5      .��5      � $��5q�6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        #���  5      $��Center=�5       $��99��6-   $	��Top=�5!      $��72(�5"      $��Freestyle Script)�6   $��Center=�5#      �� 5$   
   $��1��6   ��6&   �� *CurrentViewModel+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�� 5%   
   $��2��6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5'      ��  	 Login#���  6�   $��3q�6�   $
��10 5q�6�   y�6   �� *
IsLogged+$
 PropertyChanged=� �� 	Converter# [ $ TwoWay=���6�   �� *OpenLoginCommand+6  �� 5(        	LanguageT#���  6C   $��3q�6i   $
��10 5q�6t   ��6   �� *ChangeLanguageCommand+6�   �� 5)        ChangeCT#���  6@   $
��10 5q�6e   $��3q�6t   ��6   �� *ChangeThemeCommand+6�   5*      5+      5,      5-      