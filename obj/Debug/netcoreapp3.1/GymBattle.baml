   M S B A M L   `   `   `  ����R  NIERG3080 --- Pokemon Go, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:IERG3080_____Pokemon_GoIERG3080_____Pokemon_Go  5   	   '    !IERG3080_____Pokemon_Go.GymBattle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:IERG3080_____Pokemon_Go     5   	     N� Title$  Window1��5   	   $	��600��6   $
��1000��6&   .��5	      � ��5
   
   �� 5       �� Opacity$
 0.71Q�6    �� ImageSource$ /battle_background.png��6(   .+�5   
   �� -   5         ��Name$ player2_pokemon��5      $
��Left=�6)   $	��185��6D   $��
653,48,0,0q�6Q   $	��Top=�6e   $	��170��6}   $��/pikachu2.png��6�    �� BitmapScalingMode$ HighQuality=�6�    �� EdgeMode$ Aliased=�6�   z�5      T� 5       T� X 6%   �� *
player2X+ T� Y 6<   �� *
player2Y+5      �� 5   
   -   5        $ player1_pokemon��5      $
��Left=�6)   $	��161��6D   $��275,242,0,0q�6Q   $	��Top=�6f   $	��173��6~   $��/pikachu2.png��6�   $ HighQuality=�6�   $ Aliased=�6�    J� RenderTransformOrigin$ 0.274,0.438&�6�   z�5      T� 5       6%   �� *
player1X+ 6<   �� *
player1Y+5      �� 5   
   -   5        	 ��Name$	 player1_name��5      $��Pikachu (Lv. 5)��6&   $
��Left=�6@   $��27��6[   $��314,402,0,0q�6g   $	��Top=�6|   $	��134��6�   ���	#DDFFFFFF6�   �� 5   
   -   5        $	 player2_name��5      $��Pikachu (Lv.10)��6&   $
��Left=�6@   $��27��6[   $��689,206,0,0q�6g   $	��Top=�6|   $	��134��6�   ���	#DDFFFFFF6�   � 5   
   -   5        
 �Name$
 player1_bar��5      $
��Left=�6+   $��18��6F   $��141,320,0,0q�6R   $	��Top=�6g   $	��100��6   �� 5   
   -   5        $	 
player1_hp��5      $��	HP: 10/10��6$   $
��Left=�68   $��27��6S   $��141,338,0,0q�6_   $	��Top=�6t   $	��100��6�   ���	#DDFFFFFF6�   � 5   
   -   5        $
 player2_bar��5      $
��Left=�6+   $��18��6F   $��533,106,0,0q�6R   $	��Top=�6g   $	��100��6   �� 5   
   -   5        $	 
player2_hp��5      $��	HP: 10/10��6$   $
��Left=�68   $��27��6S   $��533,124,0,0q�6_   $	��Top=�6t   $	��100��6�   ���	#DDFFFFFF6�   �� 5   
   -	   5         ��Name$ attackboard��5      $
��Left=�6)   $	��169��6D   $��533,260,0,0q�6Q   $
��Wrap=�6f   $	��Top=�6z   $	��364��6�   ���	#DDFFFFFF J� OpacityMask
 �   �6�   � 5   
   -
   5         �Name$ actions��5      $
��Left=�6%   $��62��6@   $��
41,466,0,0q�6L   $	��Top=�6`   $	��907��6x   .+�5      �� $��Action 1��6   $
��Left=�6(   $��62��6C   $��0,0,0,0q�6O   $	��Top=�6`   $	��200��6x   �� 5       $��Action 2��6   $
��Left=�6(   $��62��6C   $��35,0,0,0q�6O   $	��Top=�6a   $	��200��6y   �� 5!      $��Action 3��6   $
��Left=�6(   $��62��6C   $��35,0,0,0q�6O   $	��Top=�6a   $	��200��6y   �� 5"      $��Action 4��6   $
��Left=�6(   $��62��6C   $��35,0,0,0q�6O   $	��Top=�6a   $	��200��6y   5#      �� 5$   
   -   5        $ player1_item1��5$      $
��Left=�6'   $��20��6B   $��141,295,0,0q�6N   $	��Top=�6c   $��20��6{   $��/shield.png��6�   $ HighQuality=�6�   $ Aliased=�6�   �� 5&   
   -   5        $ player2_item1��5&      $
��Left=�6'   $��20��6B   $��
533,81,0,0q�6N   $	��Top=�6b   $��20��6z   $��/shield.png��6�   $ HighQuality=�6�   $ Aliased=�6�   5'      5(      