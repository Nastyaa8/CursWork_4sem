   M S B A M L   `   `   `  ���� C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookShop.ConvertersBookShop.Converters  3clr-namespace:BookShop.HelpersBookShop.Helpers  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a,    &BookShop.Converters.BooleanOrConverter   BooleanOrConverter  WindowBackground  �� ImageSource j� Stretch  
ThemeBrush �� Color  ButtonBrush ! ErrorTemplateSilverlightStyle �� Orientation ��Name �Name K� ZIndex � Points J� IsHitTestVisible	 � Points
 �� StrokeEndLineCap �� StrokeStartLineCap ��Name �Name � AllowsTransparency � PlacementRectangle � PlacementTarget �� ElementName*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors.   (BookShop.Helpers.RepositionPopupBehavior �� 
TargetType �� Triggers �� Binding �� Path �� Value �� Property �� Value �� RelativeSource �� AncestorType J� Opacity �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth    Color!   Opacity"   	Direction#   
BlurRadius  DataGridColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  HeaderStyleLogin$ �� BasedOn 	 Login  HeaderStyleEmail 		 Email 
 HeaderStyleFirstName  	FirstName  HeaderStyleLastName  LastName  HeaderStylePhone 	 Phone  HeaderStyleAddress  Address  HeaderStyleIsAdmin  IsAdmin  HeaderStyleName  HeaderStyleDescription  Description  HeaderStyleLocation  Location  HeaderStyleDate  Date  HeaderStyleTotalPrice  
TotalPrice  HeaderStyleStatus 
 Status% ]� 
Conditions& �� Property' �� Value  	FailBrush( �� 
StartPoint) �� EndPoint* � Offset+ � Color   HighlightRow, �� UpdateSourceTrigger�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     0
converters!clr-namespace:BookShop.Converters  3i+http://schemas.microsoft.com/xaml/behaviors  ,	behaviorsclr-namespace:BookShop.Helpers  %�  &	        &	      &	 @     &	 Q     &	 b     &	 {    &	 �    7  &	 �    7  &	
 �    7  &	     7  &	 4    7  &	 Z    7  &	 �    7  &	 �    7  &	 �    7  &	 �    7  &	     7  &	 >    7  &	 d    7  '�� �    7  &	 (    &	  ~    7     �� $!  ../Resources/Background.jpg��$ UniformToFill=��� $ Black���� $ Black���� .R��� $ 
Horizontal=�.+��� $ border��$
��1.25q����	#FFDC000C._�� .+�� $ toolTipCorner��$ 2��$��-1q� �   @T� @T� @T� ���	#FFDC000C$��Right=�$	��Top=�$
 True��� $ 3��	 �   ��� ��� $��-1q�$��Right=�$	��1.5��$
 Round=�$ Round=�
�������$	��Top=�$
 True���� $ adorner��� $ placard��$
 True��$
��Fade=�$	��Top=�$ 	10,-1,0,0� �� $ toolTipCorner��   ���� " � ��  �� $ adorner��$ AdornedElement.IsFocused� True.a���  � ��$
 True����  �� $ toolTipCorner��$ IsMouseOver� True.a���  � ��$
 True����  ��  �� *FindAncestor+" �$ IsActive�	 False.a���  � ��$ False��.���� $ errorBorder�����	#FFDC000C$��0,0,8,8q�$ 1Q�$ 4��$ False��$��24��$	��267��   $ 4Q�$  Black��$	! 0.6Q�$	" 315Q�$# 4Q�._��� 
�������$��8,3,8,3q�$
��Wrap=����� $ adorner��$A ;AdornedElement.(Validation.Errors).CurrentItem.ErrorContent��� "  .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# � 	 �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# � ���� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� "  8$   .���  � ��# �  �� " ��.���  �@=�ErrorTemplate8    ]� % �� & �@J�IsKeyboardFocused$
' True���� & �@J�	IsFocused$
' True��/���  � ��# �  �� $	( 0,0&�$	) 0,1&�.��� $* 0Q�$+ 	#BBFF0000��� $* 1Q�$+ 	#BBFF0000���� " �� ��  �� *	Available+$, PropertyChanged=�	 False.a���  � ��8   