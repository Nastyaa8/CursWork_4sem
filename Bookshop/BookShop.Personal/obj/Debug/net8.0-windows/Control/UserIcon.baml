   M S B A M L   `   `   `  ����L  HBookShop.Personal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BookShop.Personal.ControlBookShop.Personal.Control  5      E'clr-namespace:BookShop.Personal.ControlBookShop.Personal.Control  5      (    "BookShop.Personal.Control.UserIcon   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:BookShop.Personal.Control     5      ;control'clr-namespace:BookShop.Personal.Control     5      -   5          >�Name$
  Root��5	      .��5      � -   5         � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0q�6   ���	#4E000000   
ThemeBrush#��[  6<    �� CornerRadius$ 15��6f   $��Center=�6x   $��Center=�6�   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      :� 5       :� RoutedEvent$ 
MouseLeave��6'   .[�5      �� .��5   "   �� .��5   &   t�  �� TargetProperty$ BorderThickness�69    t� From 15   6   	 t� To 06?   	 g� Duration$	 0:0:0.5D�6F   5   #   5      5      :� 5       $ 
MouseEnter��6'   .[�5!      �� .��5"   "   �� .��5$   &   t� $ BorderThickness�69    05%   9    16B   $	 0:0:0.5D�6I   5&   #   5'      5(      5*      ._�5,      �� $��75��6   $��75��6#   
 J� IsHitTestVisible$

 True��61   $��Uniform=�6�   ��6I   �� *Image+ �� ElementName$
 Root�� �� UpdateSourceTrigger$ Default=� �� Mode$ TwoWay=�6�   5-      �� 5.   
   $��Center=�6   $��
20 10 20 2q�66   $��18(�6J   $��SemiBold"�6X   $��1��6n   ��6{   �� *Text+$
 Root��$ PropertyChanged=��� 5/   
   $��Center=�6   $��
20 2 20 20q�6/   $��16(�6C   $��SemiBold"�6Q   $��2��6g   ��6t   �� *DescriptionText+$
 Root��$ PropertyChanged=�50      51      