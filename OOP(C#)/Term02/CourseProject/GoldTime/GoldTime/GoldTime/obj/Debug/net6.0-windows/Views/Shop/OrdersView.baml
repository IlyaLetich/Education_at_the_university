   M S B A M L   `   `   `  ����C  ?Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Controls;assembly=ControlsControls  5      C ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GoldTime.Views.ShopGoldTime.Views.Shop 5      $   GoldTime.Views.Shop.OrdersView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =controls(clr-namespace:Controls;assembly=Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GoldTime.Views.Shop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  
OrdersView��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
ordersGrid��5         AutoGenerateColumns$ False��5      
������    CanUserAddRows$
 True��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5         ColorContent#���   5         
IsReadOnly$
 True��5      ��5      �� *Orders+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%v   '        �� 5      "  6   .�5      ��  � ��
	 ���� 63   �� 5       � ��#	 �   63   5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$ * 5          
Foreground# �   5"         
IsReadOnly$
 True��5#      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!      �� *Id+   Header 5$      �� 5%        NumberOrder#���  6    #���   6H   5'        5(      $ * 5)      # �   5+      $
 True��5,       5*      �� *QuentityWatchOrder+ 5-      �� 5.        
CountWatch#���  6    #���   6G   50        51      $ * 52      # �   54      $
 True��55       53      �� *
PriceOrder+ 56      �� 57        PriceOrders#���  6    #���   6H   59        5;      $ * 5<      # �   5>       5=      �� *	DateOrder+ 5?      �� 5@        	DateOrder#���  6    #���   6F   5B      5D      5E      5F      