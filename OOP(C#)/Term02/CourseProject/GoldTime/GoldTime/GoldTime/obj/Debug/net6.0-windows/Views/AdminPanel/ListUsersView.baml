   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GoldTime.Views.AdminPanelGoldTime.Views.AdminPanel  5      -    'GoldTime.Views.AdminPanel.ListUsersView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:GoldTime.Views.AdminPanel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  ListUsersView��5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
ordersGrid��5         AutoGenerateColumns$ False��5      
������    CanUserAddRows$
 True��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5         ColorContent#���   5         
IsReadOnly$
 True��5      ��5      �� *Users+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
	 ���� 63   �� 5       � ��#	 �   64   �� 5       � ��#	 �   63   5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$	 100 5          
Foreground# �   5"         
IsReadOnly$
 True��5#      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!      �� *Name+   Header 5$      �� 5%      #��� ��6    #���   6A   5'        5(      $ * 5)      # �   5+       5*      �� *Email+ 5,      �� 5-       	 Email#���  6    #���   6B   5/      51      52      53      