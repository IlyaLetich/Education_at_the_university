   M S B A M L   `   `   `  ����@  <Lab09, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab09Lab09  5          	Lab09.Ex1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Lab09     5        N� Title$	  Ex1��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
peopleGrid��5   /      AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6C      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ ID��6N      Width$ 60 6Z   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *ID+6Z     5      $ Имя��6>   $	 150 6K   	 6%   �� *Name+6K     5      $ Телефон��6?   $	 150 6P   	 6%   �� *Phone+6P   5      �� 5   
   $��Center=�6   $��1��63   
 �� Orientation$
 
Horizontal=�6@   .+�5      �� -   5         ��Name$ updateButton��5   Y   
������� � Cursor$
 Hand��6(   $��0 5 0 0q�66   
����� �$��Обновить��6o   6�   �� 5      -   5        $ deleteButton��5   Z   
�������$
 Hand��6(   $��20 5 0 0q�66   
����� �$��Удалить��6p   6�   5      5      5      