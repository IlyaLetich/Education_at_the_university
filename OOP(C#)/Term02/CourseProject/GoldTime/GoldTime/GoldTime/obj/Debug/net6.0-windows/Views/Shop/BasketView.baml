   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GoldTime.Views.ShopGoldTime.Views.Shop  5      $    GoldTime.Views.Shop.BasketView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GoldTime.Views.Shop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  
BasketView��5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   � $��0��6   .+�5      �� $��Stretch=�5      
������ $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      $��Disabled=�5      ��5      �� *	Watches+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      � $��35��6    � ColumnDefinitions 5      �� 5   "   $
��Auto �63   �� 5   "   $
��Auto �63   �� 5   "   $
��Auto �63   �� 5    "   $��* �63   �� 5!   "   $
��Auto �63   .+�5$      �� $��0��5%   !   $
��30px��5&   !   $
��30px��5'   !   ��5(   "   �� 5)   &    �� ImageSource 61   �� *	ImagePath+5+      �� 5,      $��1��5-   !   $��	10,0,10,0q�5.   !   $��Center=�5/   !      ColorContent#���   50   !   ��51   !   �� *	NameModel+�� 52      $��2��53   !   $��	10,0,10,0q�54   !   $��Center=�55   !   #���   56   !   ��57   !   �� *NameCompany+�� 58      $��3��59   !   $��	10,0,10,0q�5:   !   $��Center=�5;   !   #���   5<   !   ��5=   !   �� *Price+�� 5>      -   5        $��4��5?   !   $
��30px��5@   !   $
��30px��5A   !   $��0,0,15,0q�5B   !   $��0q�5C   !   #���   5G   !   ��5E   !   �� *Delete+��5F   !   �� *Id+��5H   "   �� 5I   &   $3 -..\..\Resources\Images\Description\Delete.png��61   5K      5L      5M      5O      5P      �� 5Q   
   $��1��6   $��0,0,0,2q�6   ._�5R      �  5S      �� 5T      $	��100 �6'   �� 5U      $	��300 �6'   �� 5V      �� 5W      $	��100 �6'   .+�5Y      �� $��0��5Z      $��20,0,0,0q�5[      $��Center=�5\      $��20(�5]      #���   5^        ResultPrice#���  5_      �� 5`      $��1��5a      $��Center=�5b      $��20(�5c      #���   5d      ��5e      �� *
TotalPrice+�� 5f      $��3��5g      $��90��5h      $
��30px��5i       
 Button#���  5j      $��0q�5k        Buy#���  5m      ��5l      �� *Buy+5m      5n      5o      5p      5q      