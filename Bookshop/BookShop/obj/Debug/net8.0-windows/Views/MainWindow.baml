   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels  5   	   /clr-namespace:BookShop.ViewsBookShop.Views  5   	   ;"clr-namespace:BookShop.Views.UsersBookShop.Views.Users  5   	   E'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  5	   	   E'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  5
   	   ;"clr-namespace:BookShop.Views.BooksBookShop.Views.Books  5   	   =#clr-namespace:BookShop.Views.EventsBookShop.Views.Events  5   	   G(clr-namespace:BookShop.ViewModels.EventsBookShop.ViewModels.Events  5   	   E'clr-namespace:BookShop.Views.UserEventsBookShop.Views.UserEvents  5   	   O,clr-namespace:BookShop.ViewModels.UserEventsBookShop.ViewModels.UserEvents  5   	   =#clr-namespace:BookShop.Views.OrdersBookShop.Views.Orders  5   	   G(clr-namespace:BookShop.ViewModels.OrdersBookShop.ViewModels.Orders  5   	   H DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters 5   	   V;clr-namespace:BookShop.Mvvm.Commands;assembly=BookShop.MvvmBookShop.Mvvm.Commands 5   	       BookShop.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8
viewModels!clr-namespace:BookShop.ViewModels     5   	   .viewsclr-namespace:BookShop.Views     5   	   4users"clr-namespace:BookShop.Views.Users     5   	   :users1'clr-namespace:BookShop.ViewModels.Users     5	   	   ;catalog'clr-namespace:BookShop.ViewModels.Books     5
   	   4books"clr-namespace:BookShop.Views.Books     5   	   6events#clr-namespace:BookShop.Views.Events     5   	   =catalog1(clr-namespace:BookShop.ViewModels.Events     5   	   >
userEvents'clr-namespace:BookShop.Views.UserEvents     5   	   B	catalog11,clr-namespace:BookShop.ViewModels.UserEvents     5   	   6orders#clr-namespace:BookShop.Views.Orders     5   	   ?
catalog111(clr-namespace:BookShop.ViewModels.Orders     5   	   T
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm     5   	   Pcommands;clr-namespace:BookShop.Mvvm.Commands;assembly=BookShop.Mvvm     5   	     � WindowStartupLocation$  CenterScreen=�5   	      WindowBackground#���   5   	     ProgramTitle � Title# �  5   	   $	��800��60   $
��1100��6=    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        +  %BookShop.Mvvm.Commands.CustomCommands   ShowMessage   Command# Z 5      5       J� InputBindings 5      �� 5   
    �� Command# Z 6   
 �� Key$ X��5        �� 	Modifiers$	 Altf�6   	 � 	Resources	 5"      B  <BookShop.Mvvm.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter
 �� DataType'   !BookShop.ViewModels.CartViewModel   BookShop.Views.CartView'   !BookShop.ViewModels.MainViewModel   BookShop.Views.MainView1   +BookShop.ViewModels.Books.BookWrapViewModel'	   !BookShop.Views.Books.BookWrapView1
   +BookShop.ViewModels.Users.UserWrapViewModel'   !BookShop.Views.Users.UserWrapView3   -BookShop.ViewModels.Events.EventWrapViewModel)   #BookShop.Views.Events.EventWrapView;   5BookShop.ViewModels.UserEvents.UserEventWrapViewModel1   +BookShop.Views.UserEvents.UserEventWrapView3   -BookShop.ViewModels.Orders.OrderWrapViewModel)   #BookShop.Views.Orders.OrderWrapView��%*  &	       (��      5$      *, +)(�� E     5'      *, +)(�� w     5*      *, +)(�� �     5-      *,
 +)(�� �     50      *, +)(��     53      *, +)(�� ?    56      *, +)  5#   
   69   �� 5$   
   "
  6   .R�5%        5&      �� 5'   
   "
  6   .R�5(        5)      �� 5*   
   "
  6   .R�5+      	  5,      �� 5-   
   "
 
 6   .R�5.        5/      �� 50   
   "
  6   .R�51        52      �� 53   
   "
  6   .R�54        55      �� 56   
   "
  6   .R�57        58      59      .��5:      � $��5q�6    � RowDefinitions 5;   
   �� 5<      $
��Auto �6   �� 5=      �� 5>      $
��Auto �6   .+�5@   
   ��  	 Title#���  6   $��Center=�5A      $��99��6-   $	��Top=�5B      $��72(�5C      $��Freestyle Script)�6   $��Center=�5D      �� 5E   
   $��1��6   ��6&   �� *CurrentViewModel+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�� 5F   
   $��2��6   .+�5G      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5H      ��  	 Login#���  6�   $��3q�6�   $
��10 5q�6�   y�6   �� *
IsLogged+$ PropertyChanged=� �� 	Converter# [ $ TwoWay=���6�   �� *OpenLoginCommand+6  �� 5I        Registration#���  6�   $��3q�6�   $
��10 5q�6  y�6   �� *
IsLogged+$ PropertyChanged=�# [ $ TwoWay=���6�   �� *OpenRegisterCommand+6  �� 5J        Cart#���  6�   $��3q�6�   $
��10 5q�6�   y�6   �� *	IsAdmin+$ PropertyChanged=�# [ $ TwoWay=���6�   �� *OpenCartCommand+6  �� 5K        	LanguageT#���  6C   $��3q�6i   $
��10 5q�6t   ��6   �� *ChangeLanguageCommand+6�   �� 5L        ChangeCT#���  6@   $
��10 5q�6e   $��3q�6t   ��6   �� *ChangeThemeCommand+6�   5M      5N      5O      5P      