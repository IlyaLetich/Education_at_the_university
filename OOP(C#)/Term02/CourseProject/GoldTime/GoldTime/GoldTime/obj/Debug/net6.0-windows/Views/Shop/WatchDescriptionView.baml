   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GoldTime.Views.ShopGoldTime.Views.Shop  5      .    (GoldTime.Views.Shop.WatchDescriptionView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GoldTime.Views.Shop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  WatchDescriptionView��5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      $��2* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��120px �6   �� 5      $	��300 �6   .+�5   
   �� $��0��5      $��3��5         ColorContent#���   5      $��0,0,0,0q�5      ._�5       �  5!      �� 5"      �� 5#      �� 5$      .+�5&      �� -   5         ��Name$ MainSettingsNavigator��5'      $��0��5(      $��0��5)      $
��30px��5*      $
��30px��5+      $��15,0,0,0q�5,      $
��Left=�5-      $��0q�5.      $��MainSettings��50      ��5/      �� *SetMainPage+��51      �� 52       �� ImageSource$1 +..\..\Resources\Images\Application\Back.png��6%   54      �� 55      $��0��56      $��2��57      $��Right=�58      $��Center=�59       �� Orientation$ 
Horizontal=�5:      .+�5;      �� -   5        $ 	EditWatch��5<      $
��30px��5=      $
��30px��5>      $��0,0,15,0q�5?      $��0q�5@      ��5A      �� *Edit+��5B      �� 5C      $1 +..\..\Resources\Images\Description\Edit.png��6)   5E      �� 5F      -   5        $ DeleteWatch��5G      $
��30px��5H      $
��30px��5I      $��0,0,15,0q�5J      $��0q�5K      ��5L      �� *Delete+��5M      �� 5N      $3 -..\..\Resources\Images\Description\Delete.png��6)   5P      5Q      5S      5T      �� 5U   
   -   5         ��Name$ 	NameModel��5V      $��1��5W      $��2��5X      $��30��5Y      $��
30,12,30,0q�5Z      
������ $��0q�5\      $��14(�5]      #���   5^       J� IsHitTestVisible$ False��5_      ��5`      �� *	NameModel+ �� Mode$ TwoWay=��� 5a   
   $��1��5b      $��1��5c      $��20,0,0,0q�5d      $��Center=�5e      #���   5f        	NameModel#���  5g      �� 5h   
   -   5        $ NameCompany��5i      $��2��5j      $��2��5k      $��30��5l      $��
30,12,30,0q�5m      
������ $��0q�5o      $��14(�5p      #���   5q      $ False��5r      	 J� Opacity$	 1Q�5s      ��5t      �� *NameCompany+$ TwoWay=��� 5u   
   $��2��5v      $��1��5w      $��20,0,0,0q�5x      $��Center=�5y      #���   5z        Producer#���  5{      �� 5|   
   -   5        $ Price��5}      $��3��5~      $��2��5      $��30��5�      $��
30,12,30,0q�5�      
������ $��0q�5�      $��14(�5�      #���   5�      $ False��5�      ��5�      �� *Price+$ TwoWay=��� 5�   
   $��3��5�      $��1��5�      $��20,0,0,0q�5�      $��Center=�5�      #���   5�       	 Price#���  5�      �� 5�   
   -   5        $ Description��5�      $��4��5�      $��2��5�      $��30,12,30,30q�5�      
 �� AcceptsReturn$

 True��5�      
������ $��0q�5�      $��14(�5�      #���   5�      $ False��5�       �� TextWrapping$
 Wrap=�5�      ��5�      �� *Description+$ TwoWay=�5�      �� 5�   
   $��4��5�      $��1��5�      $��
20,12,0,30q�5�      #���   5�        Description#���  5�      �� 5�   
   -   5        $ ToBasket��5�      $��5��5�      $��1��5�      $	��100��5�      $��40��5�      $��0,0,10,0q�5�       
 Button#���  5�      $��0q�5�        AddToBasket#���  5�      #���   5�      ��5�      �� *
ToBasket+5�      �� 5�   
   -	   5        $ ToSave��5�      $��5��5�      $��1��5�      $	��100��5�      $��40��5�      $��0,0,10,0q�5�      #���  5�      $��0q�5�        Save#���  5�      #���   5�      $y�Hidden=�5�      ��5�      �� *Save+5�      �� 5�   
   -
   5        $ ToComparison��5�      $��5��5�      $��2��5�      $	��115��5�      $��40��5�      $��10,0,0,0q�5�      $
��Left=�5�      #���  5�      $��0q�5�        AddToComparison#���  5�      #���   5�      ��5�      �� *ToComparison+5�      �� 5�   
   -   5        $ GetImage��5�      $��5��5�      $��2��5�      $	��140��5�      $��40��5�      $��10,0,0,0q�5�      $
��Left=�5�      #���  5�      $��0q�5�       	 EnterImageWatch#��� 	 5�      #���   5�      $y�Hidden=�5�      ��5�      �� *
GetImage+5�      �� 5�   
   $��1��5�      $��5��5�      $��0��5�      $	��300��5�      $	��300��5�       �� RadiusX$ 20��5�       �� RadiusY$ 20��5�      ��5�      �� 5�       6   �� *	ImagePath+5�      5�      5�      