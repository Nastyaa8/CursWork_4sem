   M S B A M L   `   `   `  ����H  DBookShop.Mvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullT:clr-namespace:BookShop.Mvvm.Helpers;assembly=BookShop.MvvmBookShop.Mvvm.Helpers  5      Z=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.MvvmBookShop.Mvvm.Converters  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a1    +BookShop.Mvvm.Converters.BooleanOrConverter   BooleanOrConverter  WindowBackground  �� ImageSource j� Stretch  
ThemeBrush �� Color  ButtonBrush ! ErrorTemplateSilverlightStyle �� Orientation ��Name �Name K� ZIndex � Points J� IsHitTestVisible	 � Points
 �� StrokeEndLineCap �� StrokeStartLineCap ��Name �Name � AllowsTransparency � PlacementRectangle � PlacementTarget �� ElementName*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors3   -BookShop.Mvvm.Helpers.RepositionPopupBehavior �� 
TargetType �� Triggers �� Binding �� Path �� Value �� Property �� Value �� RelativeSource �� AncestorType J� Opacity �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth    Color!   Opacity"   	Direction#   
BlurRadius  DataGridColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  HeaderStyleLogin$ �� BasedOn 	 Login  HeaderStyleEmail 		 Email 
 HeaderStyleFirstName  	FirstName  HeaderStyleLastName  LastName  HeaderStylePhone 	 Phone  HeaderStyleAddress  Address  HeaderStyleIsAdmin  IsAdmin  HeaderStyleName  HeaderStyleDescription  Description  HeaderStyleLocation  Location  HeaderStyleDate  Date  HeaderStyleTotalPrice  
TotalPrice  HeaderStyleStatus 
 Status% ]� 
Conditions& �� Property' �� Value  	FailBrush( �� 
StartPoint) �� EndPoint* � Offset+ � Color   HighlightRow, �� UpdateSourceTrigger�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3i+http://schemas.microsoft.com/xaml/behaviors  5      Fhelpers:clr-namespace:BookShop.Mvvm.Helpers;assembly=BookShop.Mvvm  5      L
converters=clr-namespace:BookShop.Mvvm.Converters;assembly=BookShop.Mvvm  5      %�  &	        &	      &	 f     &	 �     &	 �     &	 m    &	 �    7  &	 �    7  &	
 I    7  &	 �    7  &	 �    7  &	 *	    7  &	 u	    7  &	 �	    7  &	 
    7  &	 V
    7  &	 �
    7  &	 �
    7  &	 7    7  '�� �    7  &	 �    &	  4    7     5      6$   �� 5      $!  ../Resources/Background.jpg��6*   $ UniformToFill=�6T   6n   �� 5	      $ Black��6)   �� 5
      $ Black��6*   6:   �� 5      .R�5   
   �� $ 
Horizontal=�6   .+�5      �� $ border��6   $
��1.25q�6%   ���	#FFDC000C._�5      � .+�5      � $ toolTipCorner��6   $ 2��5      $��-1q�5       �   @T� @T� @T� ���	#FFDC000C$��Right=�5      $	��Top=�5      $
 True��5      � 5      $ 3��6   	 �   ��� ��� $��-1q�5      $��Right=�5      $	��1.5��5      $
 Round=�5      $ Round=�5       
�������$	��Top=�5"      $
 True��5#      �� 5$      $ adorner��60   5%      5&      � 5(      $ placard��6   $
 True��5)      $
��Fade=�5*      $	��Top=�5+      $ 	10,-1,0,0�5-       5,      �� $ toolTipCorner�� 5/        50      ��52      �� 53      " �6    54      �� 56       6*   �� $ adorner��$ AdornedElement.IsFocused� True57      .a�58   "   ��  � ��$
 True��6;   59      �� 5;       6*   �� $ toolTipCorner��$ IsMouseOver� True5<      .a�5=   "   ��  � ��$
 True��6;   5>      �� 5@       6*   ��  �� *FindAncestor+" �$ IsActive�	 False5A      .a�5B   "   ��  � ��$ False��6;   5C      5E      .��5G      �� $ errorBorder��6   ���	#FFDC000C$��0,0,8,8q�5I      $ 1Q�5J      $ 4��5K      $ False��5L      $��24��5M      $	��267��5N       5O        5P      $ 4Q�6+   $  Black��5Q      $	! 0.6Q�5R      $	" 315Q�5S      $# 4Q�5T      ._�5V      �� 
�������$��8,3,8,3q�5X      $
��Wrap=�5Y      ��5V       �� $ adorner��$A ;AdornedElement.(Validation.Errors).CurrentItem.ErrorContent�5Y      5Z      5[      5\      5]      �� 5_      "  6.   .�5`   
   ��  � ��# �  6'   5a      �� 5c      "  6%   8$   .�5d   
   ��  � ��# �  6$   5e      �� 5g      "  6%   8$   .�5h   
   ��  � ��# � 	 6$   5i      �� 5k      "  6)   8$   .�5l   
   ��  � ��# �  6$   5m      �� 5o      "  6(   8$   .�5p   
   ��  � ��# �  6$   5q      �� 5s      "  6%   8$   .�5t   
   ��  � ��# �  6$   5u      �� 5w      "  6'   8$   .�5x   
   ��  � ��# �  6$   5y      �� 5{      "  6'   8$   .�5|   
   ��  � ��# �  6$   5}      �� 5      "  6$   8$   .�5�   
   ��  � ��# � ��6$   5�      �� 5�      "  6+   8$   .�5�   
   ��  � ��# �  6$   5�      �� 5�      "  6(   8$   .�5�   
   ��  � ��# �  6$   5�      �� 5�      "  6$   8$   .�5�   
   ��  � ��# �  6$   5�      �� 5�      "  6*   8$   .�5�   
   ��  � ��# �  6$   5�      �� 5�      "  6&   8$   .�5�   
   ��  � ��# �  6$   5�      �� 5�      " ��6   .�5�   
   ��  �@=�ErrorTemplate8   65    5�      ]� 5�      % 5�      �� 5�      & �@J�IsKeyboardFocused$
' True��6A   �� 5�      & �@J�	IsFocused$
' True��69   /�5�      �� 5�       � ��# �  67   5�      5�      �� 5�      $	( 0,0&�6,   $	) 0,1&�6=   .��5�   
   � $* 0Q�6   $+ 	#BBFF0000��6"   � 5�   
   $* 1Q�6   $+ 	#BBFF0000��6"   5�      �� 5�      " ��6!    5�   
   �� 5�       6   �� *	Available+$, PropertyChanged=�	 False6]   .a�5�      ��  � ��8   6/   5�      5�      5�      