   M S B A M L   `   `   `  ����?  ;chat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:chatchat  5   	       Chat.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:chat     5   	   -   5          � Title$  
MainWindow��5   	   $	��429��6   $	��458��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ btn_menu_chat��5
      $
��Chat��6(   $
��Left=�67   $��	10,32,0,0q�6R   $	��Top=�6e   $	��100��6}   6�   �� 5   
   -   5        $ btn_menu_direct_message��5      $��Direct message��62   $
��Left=�6K   $��	10,74,0,0q�6f   $	��Top=�6y   $	��100��6�   6�   �� 5   
   -   5        $ btn_menu_search��5      $��Search��6*   $
��Left=�6;   $��
10,117,0,0q�6V   $	��Top=�6j   $	��100��6�   6�   �� 5   
   -   5        $ btn_menu_block��5      $��Block��6)   $
��Left=�69   $��
10,159,0,0q�6T   $	��Top=�6h   $	��100��6�   6�   � 5   
   -   5         �Name$ grid_sign_in��5      $
��Left=�6%   $	��378��6@   $��
115,10,0,0q�6M   $	��Top=�6a   $	��325��6y   $y�Hidden=�6�   .+�5      �� $��Sign in��6   $
��Left=�6&   $��	114,0,0,0q�6A   $	��Top=�6T   $
��Bold"�6l   $��20(�6~   �� 5      $2��,Enter username you would like to sign in as.��6   $
��Left=�6K   $��	37,37,0,0q�6f   $	��Top=�6y   �� 5      -   5         ��Name$ txt_sign_in��5      $
��Left=�6+   $��23��6F   $��	10,89,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��208��6�   6�   �� 5      -   5        $ btn_sign_in��5      $��Login��6*   $
��Left=�6:   $��
240,89,0,0q�6U   $	��Top=�6i   $��75��6�   6�   5      � 5   
   -	   5        $ 	grid_chat��5      $
��Left=�6"   $	��378��6=   $��
115,10,0,0q�6J   $	��Top=�6^   $	��325��6v   $y�Hidden=�6�   .+�5      �� $��Chatroom��6   $
��Left=�6'   $��	114,0,0,0q�6B   $	��Top=�6U   $
��Bold"�6m   $��20(�6   �� 5      -
   5         ��Name$ lb_chat��5      $
��Left=�6'   $	��270��6B   $��	10,42,0,0q�6O   $	��Top=�6b   $	��305��6z   �� 5      -   5        $ txt_chat��5      $
��Left=�6(   $��23��6C   $��
10,332,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��208��6�   6�   �� 5      -   5        $ btn_chat��5      $
��Send��6'   $
��Left=�66   $��240,332,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   5      � 5   
   -   5        $ grid_direct_message1��5      $
��Left=�6-   $	��378��6H   $��
115,10,0,0q�6U   $	��Top=�6i   $	��325��6�   $y�Hidden=�6�   .+�5      �� $��Direct Message��6   $
��Left=�6-   $��	104,0,0,0q�6H   $	��Top=�6[   $
��Bold"�6s   $��20(�6�   �� 5      $6��0Enter username you would like to direct message.��6   $
��Left=�6O   $��	37,37,0,0q�6j   $	��Top=�6}   �� 5      -   5        $ txt_dm_user��5      $
��Left=�6+   $��23��6F   $��
50,101,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�    J� RenderTransformOrigin$ 0.738,0.261&�6�   6�   �� 5      -   5        $ btn_dm_user��5      $��Send message��6*   $
��Left=�6A   $��183,101,0,0q�6\   $	��Top=�6q   $	��109��6�   6�   5       � 5!   
   -   5        $ grid_direct_message2��5!      $
��Left=�6-   $	��378��6H   $��
115,10,0,0q�6U   $	��Top=�6i   $	��325��6�   $y�Hidden=�6�   .+�5"      �� -   5         ��Name$ lbl_dm��5"      $��Direct Message��6$   $
��Left=�6=   $��	104,0,0,0q�6X   $	��Top=�6k   $
��Bold"�6�   $��20(�6�   �� 5#      -   5        $ lb_direct_message��5#      $
��Left=�61   $	��270��6L   $��	10,42,0,0q�6Y   $	��Top=�6l   $	��305��6�   �� 5$      -   5        $ txt_direct_message��5$      $
��Left=�62   $��23��6M   $��
10,332,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��208��6�   6�   �� 5%      -   5        $ btn_direct_message��5%      $
��Send��61   $
��Left=�6@   $��240,332,0,0q�6[   $	��Top=�6p   $��75��6�   6�   5&      � 5(   
   -   5        $ grid_search��5(      $
��Left=�6$   $	��378��6?   $��
115,10,0,0q�6L   $	��Top=�6`   $	��325��6x   $y�Hidden=�6�   .+�5)      �� $��Search��6   $
��Left=�6%   $��	104,0,0,0q�6@   $	��Top=�6S   $
��Bold"�6k   $��20(�6}   �� 5*      -   5        $ 	lb_search��5*      $
��Left=�6)   $	��270��6D   $��	10,86,0,0q�6Q   $	��Top=�6d   $	��305��6|   �� 5+      -   5        $ 
txt_search��5+      $
��Left=�6*   $��23��6E   $��	10,42,0,0q�6Q   $
 Wrap=�6d   $	��Top=�6x   $	��208��6�   6�   �� 5,      -   5        $ 
btn_search��5,      $��Search��6)   $
��Left=�6:   $��
240,42,0,0q�6U   $	��Top=�6i   $��75��6�   6�   5-      � 5.   
   -   5        $ 
grid_block��5.      $
��Left=�6#   $	��378��6>   $��
115,10,0,0q�6K   $	��Top=�6_   $	��325��6w   .+�5/      �� $��Block users��6   $
��Left=�6*   $��	104,0,0,0q�6E   $	��Top=�6X   $
��Bold"�6p   $��20(�6�   �� 50      -   5        $ lb_block��50      $
��Left=�6(   $	��242��6C   $��	10,86,0,0q�6P   $	��Top=�6c   $	��305��6{   �� 51      -   5        $ 	txt_block��51      $
��Left=�6)   $��23��6D   $��	10,42,0,0q�6P   $
 Wrap=�6c   $	��Top=�6w   $	��208��6�   6�   �� 52      -   5        $ 	btn_block��52      $��Block��6(   $
��Left=�68   $��
240,42,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 53      -   5        $ btn_remove_block��53      $��Remove��6/   $
��Left=�6@   $��
10,348,0,0q�6[   $	��Top=�6o   $��75��6�   6�   54      55      56      