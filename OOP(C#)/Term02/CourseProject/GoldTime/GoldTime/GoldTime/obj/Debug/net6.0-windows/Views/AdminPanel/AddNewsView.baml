   M S B A M L   `   `   `  ����C  ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GoldTime.Views.AdminPanelGoldTime.Views.AdminPanel  5      +    %GoldTime.Views.AdminPanel.AddNewsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:GoldTime.Views.AdminPanel     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        N� Title$  AddNewsView��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��2* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��130px �6   �� 5      �� 5      .+�5   
   �� $��0��5      $��2��5      $��Center=�5      $��24(�5         ColorContent#���   5         
CreateNews#���  5!       �� TextAlignment$ Center=�5"      �� 5#   
   $��1��5$      $��1��5%      $
��30px��5&      $��	30,0,30,0q�5'      
������ #���   5)      $��0,0,0,1q�5*      #���   5+      ��5,      �� *
NameNews+ �� Mode$ TwoWay=��� 5-   
   $��1��5.      $��0��5/      $��20,0,0,0q�50      $��Center=�51      #���   52        NameNews#���  53      �� 54   
   $��2��55      $��1��56      $��30,30,30,30q�57       �� AcceptsReturn$
 True��58      
������ #���   5:      $��0,0,0,1q�5;      #���   5<       �� TextWrapping$
 Wrap=�5>      ��5=      �� *DescriptionNews+$ TwoWay=�5>      �� 5?   
   $��2��5@      $��0��5A      $��
20,30,0,30q�5B      #���   5C        DescriptionNews#���  5D      �� 5E   
   $��5��5F      $��2��5G      $��Center=�5H      $��Center=�5I       �� Orientation$ 
Horizontal=�5J      .+�5K      �� $��140px��5L      $
��40px��5M      $��0,0,10,0q�5N       
 Button#���  5O      $��0q�5P        EnterImageNews#���  5R      #���   5S      ��5Q      �� *
GetImage+5S      �� 5T      $��140px��5U      $
��40px��5V      $��10,0,0,0q�5W      #���  5X      $��0q�5Y        ClearFields#���  5[      #���   5\      ��5Z      �� *ClearFields+5\      5]      �� 5^   
   $��5��5_      $��2��5`      $��140px��5a      $
��40px��5b      #���  5c      $��0q�5d        AddNewsInList#���  5f      #���   5g      ��5e      �� *
CreateNews+5g      �� 5h   
   $��3��5i      $��2��5j      $��280px��5k      $��330px��5l      $��5q�5m      $��5q�5n      $
{�true��5o       J� IsHitTestVisible$
 true��5p      ��5q      �� 5r      	 �� 
TargetType"	 ��6"   .R�5s      ��   Card#���  5t      $��0q�5u      
 �� CornerRadius$
 10��5v      ._�5w      �  5x      �� 5y   "   $��270px �60   �� 5z   "   .+�5|      �� $��0��6(   $��10q�65   ��5}   "   �� 5~   &    �� ImageSource 61   �� *ImagePathModel+5�      �� 5�      $��1��6)   $��10q�66   .+�5�   "   �� $��Center=�5�   %   $��24(�5�   %   #���   5�   %   ��5�   %   �� *NameNewsModel+5�      5�      5�      5�      5�      5�      5�      