   M S B A M L   `   `   `  ����C  ?Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Controls;assembly=ControlsControls  5      C ?GoldTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GoldTime.Views.MainViewGoldTime.Views.MainView 5      6   0GoldTime.Views.Authentication.AuthenticationView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =controls(clr-namespace:Controls;assembly=Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:GoldTime.Views.MainView     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��300��5	      $	��470��5
        � AllowsTransparency$
  True��5      
������  � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      ��    AuthenticationColor#���   6    �� CornerRadius$ 15��6@   ._�5   
   �  � RowDefinitions 5      �� 5      $
��25px �6    �� 5      �� 5      $
��40px �6    .+�5      �� -   5        $��0��5      
������   ColorContent#���  5      $��0,0,0,1q�5      ._�5      � $��Stretch=�6   .+�5      �� $��Center=�5         NameApplication#���  5!      $��SemiBold"�5"      #���  5#      �� 5$      $��10,0,0,0q�5%      $
��Left=�5&       �� Orientation$ 
Horizontal=�5'      .+�5(         Controls.WindowButton    MainWindowControl#��[ 5*         Color$ #f34f56��5+      ��5)      �� *CloseAuthenticationView+5+      5,      5-      5.       � 50      -   5          �Name$ MainBodyAuthentication��51      $��1��52        � NavigationUIVisibility$ Hidden=�54      ��53      �� *MainBodyAuthenticationPage+54      �� 55      $��2��56      #���  57      $��0,1,0,0q�58      ._�59      �� $��	10,0,10,0q�5:      $��Center=�5;      $ 
Horizontal=�5<      .+�5=      �� $
��30px��5>      $
��30px��5?      $��	10,0,10,0q�5@      $��English��5B      ��5A      �� *SetLanguage+��5C      �� 5D      	 �� ImageSource$;	 5..\..\Resources\Images\Settings\Languages\English.jpg��6)   5F      �� 5G      $
��30px��5H      $
��30px��5I      $��	10,0,10,0q�5J      $��Russian��5L      ��5K      �� *SetLanguage+��5M      �� 5N      $;	 5..\..\Resources\Images\Settings\Languages\Russian.jpg��6)   5P      5Q      5R      5S      5T      5U      