   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GoldTime.Views.ShopGoldTime.Views.Shop  5      -    'GoldTime.Views.Shop.NewsDescriptionView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GoldTime.Views.Shop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  NewsDescriptionView��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��50px �6   �� 5      .+�5   
   ��    ColorContent#���   6   $��0,0,0,1q�6>   ._�5      � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ MainSettingsNavigator��5      $��0��5      $��0��5      $
��30px��5      $
��30px��5      $��15,0,0,0q�5      $
��Left=�5       $��0q�5!      $��MainSettings��5#      ��5"      �� *SetMainPage+��5$      �� 5%       �� ImageSource$1 +..\..\Resources\Images\Application\Back.png��6%   5'      �� 5(      $��0��5)      $��2��5*      $��Right=�5+      $��Center=�5,       �� Orientation$ 
Horizontal=�5-      .+�5.      �� -   5        $ EditNews��5/      $
��30px��50      $
��30px��51      $��0,0,15,0q�52      $��0q�53      ��54      �� *Edit+��55      �� 56      $1 +..\..\Resources\Images\Description\Edit.png��6)   58      �� 59      -   5        $ 
DeleteNews��5:      $
��30px��5;      $
��30px��5<      $��0,0,15,0q�5=      $��0q�5>      ��5?      �� *Delete+��5@      �� 5A      $3 -..\..\Resources\Images\Description\Delete.png��6)   5C      5D      5E      5F      � 5G   
   $��1��6    5H      �� 5I      �� 5J      .+�5L      �� $��0��5M      $	��300��5N      $	��300��5O       �� RadiusX$ 20��5P       �� RadiusY$ 20��5Q      ��5R      �� 5S       6!   �� *	ImagePath+5U      �� 5V      -   5        $ GetImage��5W      $��0��5X      $��90��5Y      $��40��5Z      $��10,0,0,0q�5[      $��Center=�5\        Card#���  5]      $��0q�5^        EnterImageWatch#���  5`      #���   5a      $y�Hidden=�5b      ��5_      �� *
GetImage+5b      � 5c      $��1��6    5d      �� 5e      �� 5f      $��50 �6$   .+�5h      �� $��0��6   $��Center=�6*   .+�5i      �� -   5         ��Name$
 Name��5j      $��30��5k      $��
30,12,30,0q�5l      
������ $��0q�5n      $��18(�5o      #���   5p      	 J� IsHitTestVisible$	 False��5q      
 �� TextAlignment$
 Center=�5s      ��5r      �� *
NameNews+ �� Mode$ TwoWay=�5s      �� 5t      $��30��5u      $��20,0,0,0q�5v      $��Center=�5w      #���   5x       �� TextAlignment$ Center=�5z      ��5y      �� *
DateTime+5z      �� 5{      -   5        $ Description��5|      $	��200��5}      $��30,12,30,30q�5~       �� AcceptsReturn$
 True��5      
������ $��0q�5�      $��14(�5�      #���   5�      $	 False��5�       �� TextWrapping$
 Wrap=�5�      ��5�      �� *ImformationsNews+$ TwoWay=�5�      5�      �� 5�      -   5        $ ToSave��5�      $��1��5�      $	��115��5�      $��40��5�      $��0,0,10,0q�5�      #���  5�      $��0q�5�        Save#���  5�      #���   5�      $y�Hidden=�5�      ��5�      �� *Save+5�      5�      5�      5�      5�      