   M S B A M L   `   `   `  ����R  NIERG3080 --- Pokemon Go, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IERG3080_____Pokemon_GoIERG3080_____Pokemon_Go  5      $    IERG3080_____Pokemon_Go.Manage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:IERG3080_____Pokemon_Go     5        N� Title$  Manage��5	      .��5      � 
�������.+�5   
   �� -   5        $��Pokemon_box��5      $|�False��6$   .+�5      �� -   5        $	��box��5      $��useful_picture/box.png��6   $	��931��6?   $	��600��6K    �� Left$ 41��6X   �� 5      -   5        $��pokemon_image��5      $ ��useful_picture/unknown.png��6)   $	��189��6M   $	��205��6Y   $	 297��6f   
 �� Top$	 186��6x   �� 5      -   5         ��Name$ money_board��5      $��useful_picture/money.png��6)   $
��Fill=�6K   $	��322��6Z   $��78��6f   $ 70��6r   $ 10��6�   �� 5      -   5        $��	coin_icon��5      $��useful_picture/coin.png��6%   $��80��6F   $��80��6Q   $	 108��6]   $ 8��6o   �� 5      -   5         ��Name$ 
textBlock1��5      $
��Wrap=�6,   $��Pokemon storage��6@   $��20(�6W   $
��Bold"�6e   $��29��6w   $	��218��6�   $	 108��6�   $	 151��6�   �� 5      -   5        $ 
textBlock2��5      $
��Wrap=�6,   $0��*Pokemon backpack (Demo Version) (Size = 1)��6@   $��20(�6r   $
��Bold"�6�   $��81��6�   $	��188��6�   $	 711��6�   $	 151��6�   �� 5      -   5        $ 
textBlock3��5      $
��Wrap=�6,   $'��!Select a Pokemon to view its info��6@   $��15(�6i   $
��Bold"�6w   $	��208��6�   $	��195��6�   $	 500��6�   $	 185��6�   �� 5      -	   5        $ 
textBlock4��5      $
��Wrap=�6,   $	��X 0��6@   $��30(�6K   $
��Bold"�6Y   $��42��6k   $	��130��6w   $	 217��6�   $ 28��6�   �� 5      -
   5         ��Name$ 
pokemonbox��5      $	��208��6*   $	��168��67   $	 108��6C   $	 185��6U   �� 5      -   5        $ mybag��5      $	��142��6%   $	��188��62   $	 711��6z   $	 251��6�   ��6>   �� *DataContext+ �� ElementName$ 
pokemonbox��6�   �� 5      -   5         ��Name$ 
ShowButton��5      $��View Pokemon info��6)   $	��195��6E   $��20(�6Q   $
��Bold"�6_   $	 500��6�   $	 420��6�   $��33��6�   �� 5      -   5        $ 
SellButton��5      $��Sell Pokemon��6)   $	��168��6@   $��20(�6L   $
��Bold"�6Z   $	 108��6�   $	 420��6�   $��33��6�   �� 5      -   5        $ TransButton��5      $��Transfer Pokemon��6*   $	��189��6E   $��20(�6Q   $
��Bold"�6_   $	 297��6�   $	 420��6�   $��33��6�   �� 5      -   5        $ 
Exitbutton��5      $��X��6)   $��50(�65   $
��Bold"�6C   $��60��6U   $��60��6a   $	 870��6y   $ 23��6�   ��5      �� 5       �� 
TargetType" ��6   .�5       �� 	 �� Property	 � ��
 �� Value

 �   �67    �� Triggers 5!      P� 5"       P� Property �@J�IsMouseOver P� Value$
 true��6=   . �5#   "   �� 	 � ��

 �����6?   5$      5&      5(      5)      5*      5+      