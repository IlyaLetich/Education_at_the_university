   M S B A M L   `   `   `  ����C  ?Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Controls;assembly=ControlsControls  5      C ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GoldTime.Views.MainViewGoldTime.Views.MainView 5      &    GoldTime.Views.MainView.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =controls(clr-namespace:Controls;assembly=Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:GoldTime.Views.MainView     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��800��5	      $	��450��5
      $��750px��5      $��520px��5        � AllowsTransparency$
  True��5      
������  � Icon$0 *..\..\Resources\Images\Application\App.png��5       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStyle$
 None=�5      .��5      ��    MainGradient#���   6    �� CornerRadius$ 15��69   ._�5   
   �  � RowDefinitions 5      �� 5      $
��25px �6    �� 5      �� 5      $
��60px �6    .+�5      �� -   5        $��0��5      
������   ColorContent#���  5      $��0,0,0,1q�5      ._�5!      � $��Stretch=�6   .+�5"      �� $��Center=�5#        NameApplication#���  5$      $��SemiBold"�5%      #���  5&      �� 5'      $��10,0,0,0q�5(      $
��Left=�5)       �� Orientation$ 
Horizontal=�5*      .+�5+         Controls.WindowButton    MainWindowControl#��[ 5-         Color$ #f34f56��5.      ��5,      �� *CloseMainView+5.        5/      #��[ 51      $ #fac537��52      ��50      �� *HideMainView+52        53      #��[ 55      $ #3aea49��56      ��54      �� *OpenFullScreen+56      57      58      59       � 5;      -   5          �Name$ MainBodyBack��5<      $��1��5=        LightBackground#���  5>      	  � NavigationUIVisibility$	 Hidden=�5@      ��5?      �� *MainPageBack+5@       � 5A      -   5        $ MainBodyFront��5B      $��1��5C      $	 Hidden=�5E      ��5D      �� *MainPageFront+5E      �� 5G      $��2��5H      #���  5I      $��0,1,0,0q�5J      ._�5K      �� $��Center=�6   $ 
Horizontal=�6:   .+�5L      �� -   5        
 ��Name$
 	AdminMain��5M      $
��60px��5N      $��0q�5O      
������ $��0q�5Q      .��5R      '   !Controls.PageNavigatorRadioButton  $��70��5S      $��
AdminPanel��5U        
AdminPanel#���  5V      #���  5W         	ImagePath$4 ...\..\Resources\Images\MainView\AdminPanel.png��5X         	SizeImage$ 32��5Y      ��5T      �� *SetMainPage+5Y      5Z      �� 5[      $
��60px��5\      $��0q�5]      
������ $��0q�5_      .��5`        $��70��5a      $
��News��5c        News#���  5d      #���  5e      $. (..\..\Resources\Images\MainView\News.png��5f      $ 32��5g      ��5b      �� *SetMainPage+5g      5h      �� 5i      $
��60px��5j      $��0q�5k      
������ $��0q�5m      .��5n        $��70��5o      $
��Shop��5q        Shop#���  5r      #���  5s      $. (..\..\Resources\Images\MainView\Shop.png��5t      $ 32��5u      ��5p      �� *SetMainPage+5u      5v      �� 5w      -   5        $
 
BasketMain��5x      $
��60px��5y      $��0q�5z      
������ $��0q�5|      .��5}        $��70��5~      $��Basket��5�       
 Basket#���  5�      #���  5�      $0 *..\..\Resources\Images\MainView\Busket.png��5�      $ 32��5�      ��5      �� *SetMainPage+5�      5�      �� 5�      -   5        $
 
OrdersMain��5�      $
��60px��5�      $��0q�5�      
������ $��0q�5�      .��5�        $��70��5�      $��Orders��5�       
	 Orders#��� 	 5�      #���  5�      $0 *..\..\Resources\Images\MainView\Orders.png��5�      $ 32��5�      ��5�      �� *SetMainPage+5�      5�      �� 5�      $
��60px��5�      $��0q�5�      
������ $��0q�5�      .��5�        $��70��5�      $��Settings��5�       
 Settings#��� 
 5�      #���  5�      $2 ,..\..\Resources\Images\MainView\Settings.png��5�      $ 32��5�      ��5�      �� *SetMainPage+5�      5�      5�      5�      5�      5�      5�      