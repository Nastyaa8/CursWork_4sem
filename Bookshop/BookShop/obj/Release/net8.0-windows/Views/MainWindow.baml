   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ViewModelsBookShop.ViewModels  /clr-namespace:BookShop.ViewsBookShop.Views  ;"clr-namespace:BookShop.Views.UsersBookShop.Views.Users  E'clr-namespace:BookShop.ViewModels.UsersBookShop.ViewModels.Users  E'clr-namespace:BookShop.ViewModels.BooksBookShop.ViewModels.Books  ;"clr-namespace:BookShop.Views.BooksBookShop.Views.Books  =#clr-namespace:BookShop.Views.EventsBookShop.Views.Events  G(clr-namespace:BookShop.ViewModels.EventsBookShop.ViewModels.Events  E'clr-namespace:BookShop.Views.UserEventsBookShop.Views.UserEvents  O,clr-namespace:BookShop.ViewModels.UserEventsBookShop.ViewModels.UserEvents  =#clr-namespace:BookShop.Views.OrdersBookShop.Views.Orders  G(clr-namespace:BookShop.ViewModels.OrdersBookShop.ViewModels.Orders  9!clr-namespace:BookShop.ConvertersBookShop.Converters  5clr-namespace:BookShop.CommandsBookShop.Commands      BookShop.Views.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8
viewModels!clr-namespace:BookShop.ViewModels     .viewsclr-namespace:BookShop.Views     4users"clr-namespace:BookShop.Views.Users     :users1'clr-namespace:BookShop.ViewModels.Users     ;catalog'clr-namespace:BookShop.ViewModels.Books     4books"clr-namespace:BookShop.Views.Books     6events#clr-namespace:BookShop.Views.Events     =catalog1(clr-namespace:BookShop.ViewModels.Events     >
userEvents'clr-namespace:BookShop.Views.UserEvents     B	catalog11,clr-namespace:BookShop.ViewModels.UserEvents     6orders#clr-namespace:BookShop.Views.Orders     ?
catalog111(clr-namespace:BookShop.ViewModels.Orders     8
converters!clr-namespace:BookShop.Converters     1localclr-namespace:BookShop.Commands       � WindowStartupLocation$  CenterScreen=�   WindowBackground#���     ProgramTitle � Title# �  $	��800��$
��1100�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &    BookShop.Commands.CustomCommands   ShowMessage   Command# Z  J� InputBindings ��  �� Command# Z 
 �� Key$ X�� �� 	Modifiers$	 Altf�	 � 	Resources	 =   7BookShop.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter
 �� DataType'   !BookShop.ViewModels.CartViewModel   BookShop.Views.CartView'   !BookShop.ViewModels.MainViewModel   BookShop.Views.MainView1   +BookShop.ViewModels.Books.BookWrapViewModel'	   !BookShop.Views.Books.BookWrapView1
   +BookShop.ViewModels.Users.UserWrapViewModel'   !BookShop.Views.Users.UserWrapView3   -BookShop.ViewModels.Events.EventWrapViewModel)   #BookShop.Views.Events.EventWrapView;   5BookShop.ViewModels.UserEvents.UserEventWrapViewModel1   +BookShop.Views.UserEvents.UserEventWrapView3   -BookShop.ViewModels.Orders.OrderWrapViewModel)   #BookShop.Views.Orders.OrderWrapView��%�   &	       (��      *, +)(��      *, +)(�� )     *, +)(�� ;     *,
 +)(�� M     *, +)(�� _     *, +)(�� q     *, +)  �� "
  .R�  �� "
  .R�  �� "
  .R�	  �� "
 
 .R�  �� "
  .R�  �� "
  .R�  �� "
  .R�  .��� $��5q� � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+���  	 Title#���  $��Center=�$��99��$	��Top=�$��72(�$��Freestyle Script)�$��Center=��� $��1������ *CurrentViewModel+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�� $��2��.+���  �� Orientation$ 
Horizontal=�$��Right=�.+���  	 Login#���  $��3q�$
��10 5q�y��� *
IsLogged+$ PropertyChanged=� �� 	Converter# [ $ TwoWay=����� *OpenLoginCommand+��   Registration#���  $��3q�$
��10 5q�y��� *
IsLogged+$ PropertyChanged=�# [ $ TwoWay=����� *OpenRegisterCommand+��   Cart#���  $��3q�$
��10 5q�y��� *	IsAdmin+$ PropertyChanged=�# [ $ TwoWay=����� *OpenCartCommand+��   	LanguageT#���  $��3q�$
��10 5q����� *ChangeLanguageCommand+��   ChangeCT#���  $
��10 5q�$��3q����� *ChangeThemeCommand+