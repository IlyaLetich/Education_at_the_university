   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GoldTime.Views.ShopGoldTime.Views.Shop  5      (    "GoldTime.Views.Shop.ComparisonView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GoldTime.Views.Shop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  ComparisonView��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��50px �6   �� 5      $	��400 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ MainSettingsNavigator��5      $��0��5      $��0��5      $
��30px��5      $
��30px��5      $��15,0,0,0q�5      $
��Left=�5         ColorContent#���   5       $��0q�5!      $��MainSettings��5#      ��5"      �� *SetMainPage+��5$      �� 5%       �� ImageSource$1 +..\..\Resources\Images\Application\Back.png��6!   5'      �� 5(      $��1��5)      $��Center=�5*      $��14(�5+      #���   5,        
Comparison#���  5-       �� TextAlignment$ Center=�5.      �� 5/      $��0��50      $��2��51      $��Right=�52      $��Center=�53       �� Orientation$ 
Horizontal=�54      .+�55      �� $
��30px��56      $
��30px��57      $��0,0,15,0q�58      $��0q�59      ��5:      �� *Delete+��5;      �� 5<      $3 -..\..\Resources\Images\Description\Delete.png��6%   5>      5?      5A      &   System.Windows.Controls.DataGrid  5B   
   $��1��5C         AutoGenerateColumns$ False��5D      
������    CanUserAddRows$
 True��5F      #���   5G      	   
IsReadOnly$
	 True��5H      ��5I      �� *	Watches+
 �� SelectedItem
 5J      �� *SelectedWatch+ �� Mode$ TwoWay=� � 	Resources 5K      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5L      "  6   .�5M      ��  � ��
 ���� 63   �� 5N       � ��# �   64   �� 5O       � ��$ 1q�68   �� 5P       � ��# �   63   5Q      5R         Columns 5S      4  .System.Windows.Controls.DataGridTemplateColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6)      Header 5U      �� 5V        
ImageWatch#���  6    #���   6G      CellTemplate 5X      �� 5Y      .R�5Z      �� $��90��6(   $��90��63   ��5[   "   �� 5\   &    61   �� *	ImagePath+5^      5_      5a      0  *System.Windows.Controls.DataGridTextColumn  5b      $	 120 5c         
Foreground# �   5e      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5d      �� *	NameModel+ 5f      �� 5g        	NameModel#���  6    #���   6F   5i        5j      $	 120 5k      # �   5m       5l      �� *NameCompany+ 5n      �� 5o        Producer#���  6    #���   6E   5q        5r      $	 100 5s      # �   5u       5t      �� *Price+ 5v      �� 5w       	 Price#���  6    #���   6B   5y        5z      $ * 5{      # �   5}       5|      �� *DescriptionModel+ 5~      �� 5        Description#���  6    #���   6H   5�      5�      5�      5�      