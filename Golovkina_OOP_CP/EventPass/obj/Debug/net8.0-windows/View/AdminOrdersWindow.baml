   M S B A M L   `   `   `  ����D  @EventPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EventPass	EventPass  5   	   &     EventPass.View.AdminOrdersWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EventPass     5   	     � Title$  	EventPass��5   	   $	��450��6   $	��800��6(    � Icon$ 	/icon.png��64    � 	Resources 5
         TextOnlyHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property	 P� Value��%�  &	        �� 5   
   " ��61   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � �� �	#FFA6A6A66+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 Left=�6;   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Center=�6+   $
��Left=�6F   $��4q�6a   5      5       5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      ��  � �� �	#FF9B72CF63   5      5      5      .��5       (� 
 (� Stretch$
 Uniform=�6   .��5!   
   � $��Center=�6   .+�5"      �� $��1q�6   ���	#199B72CF �� CornerRadius$ 30,30,30,30��6@   $��146,0,-15,0q�6[   ._�5#      �� $��1q�6   $��35��6-   $��
19,15,19,0q�69   $	��Top=�6M   $ 20,20,20,20��6e   ���	#269B72CF J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5$      V� 5%      .~�5&      �� �� 5'       �� AngleX$ -1.49Q�6,   �� 5(      T� 5)       T� X$ 0.507Q�61   5*      5,      5-      � 5.      $
��Left=�6   $	��434��6.   $	��Top=�6;   $	��800��6S   $��2��6_   .+�5/      �� $��Event��6   $��34,64,718,342q�6(   $
��Bold"�6?   ���	#FFA6A6A6$��14(�6h   �� 50      $
��Pass��6   $��71,64,689,342q�6'   $
��Bold"�6>   ���	#FF9B72CF$��14(�6g   �� 51      $��Customers orders��6   $
��Left=�63   $��
170,81,0,0q�6N   $	��Top=�6b   $
��Bold"�6z   $��14(�6�   �� 52      $��210,25,571,390q�6   $��/Resources/icon-cart.png��60   $
��Fill=�6R   �� 53      -   5         ��Name$ Button_Orders��53      $��Orders��60   $��224,24,540,0q�6A   $��20��6W   $	��Top=�6c   #��[  54       � Cursor$
 Hand��6G   $��8(�6U   �� 55      -   5        $ Button_AddEvent��55      $��	Add event��62   $��306,25,450,0q�6F   $��20��6\   $	��Top=�6h   #��[  56      $
 Hand��6G   $��8(�6U   6b   �� 57      -   5        $ Button_AdminExit��57      $��
Admin exit��63   $��720,25,30,0q�6H   $��20��6]   $	��Top=�6i   #��[  58      $
 Hand��6G   $��8(�6U   6b   �� 59      -   5        $ Button_Home��59      $��Button��6.   $
��Left=�6?   $��	49,35,0,0q�6Z   $	��Top=�6m   $��44��6�   $��43��6�   $
 Hand��6�   ��6�   Z� ��6�   Z� ��6�   Z� ��5:      �� 5;      " ��6*   .R�5<      �� #��z��6%   ._�5=   "   �� $��/Resources/icon.png��6(   5>      5?      5A      &   System.Windows.Controls.DataGrid  5B      -   5          Name$ DataGrid_Orders��5B      $
��Left=�64   $	��302��6O   $��173,115,0,0q�6\   $	��Top=�6q   $	��602��6�      VerticalGridLinesBrush �	#FFA6A6A6   HorizontalGridLinesBrush �	#FFA6A6A6$��10(�65     AutoGenerateColumns$ False��6C  ��6�   Z� ��6�   Z�    Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     5E      $ 
Event - id��6-   $ * 6_    6A   �� *	EventName+6_     5F      $ Date and time��6-   $ * 6b    6D   �� *	EventDate+6b     5G      $ Price��6-   $ * 6V    6<   �� *Price+6V     5H      $
 City��6-   $ * 6T    6;   �� *City+6T     5I      $ Login��6-   $ * 6V    6<   �� *Login+6V   5K      �� 5L      -   5        $ Button_RemoveEvent��5L      $��Remove event��65   $��397,25,344,0q�6L   $��20��6b   $	��Top=�6n   #��[  5M      $
 Hand��6G   $��8(�6U   6b   �� 5N      $��288,25,492,389q�6   $��/Resources/icon-add.png��60   $
��Fill=�6Q   �� 5O      $��382,25,398,389q�6   $ ��/Resources/icon-remove.png��60   $
��Fill=�6T   �� 5P      $��699,24,80,388q�6   $��/Resources/icon-admin.png��6/   $
��Fill=�6R   $ 0.5,0.5&�6a   z�5Q      V� 5R      .~�5S      ��  �� ScaleX$ -1Q�6-   �� 5T      �� 5U      T� 5V      5W      5Y      �� 5Z      -   5        $ Button_LoadUsers��5Z      $��
Load users��63   $��496,25,254,0q�6H   $��20��6^   $	��Top=�6j   #��[  5[      $
 Hand��67   $��8(�6E   6R   �� 5\      -   5        $ Button_SaveUsers��5\      $��
Save users��63   $��578,24,173,0q�6H   $��20��6^   $	��Top=�6j   #��[  5]      $
 Hand��67   $��8(�6E   6R   �� 5^      $��483,26,300,390q�6   $��/Resources/icon-load.png��60   $
��Fill=�6R   �� 5_      $��563,27,222,391q�6   $��/Resources/icon-save.png��60   $
��Fill=�6R   5`      �� 5a      -	   5         ��Name$ Label_No��5a      $*��$Users haven't placed any orders yet.��6&   $
��Left=�6U   $��181,110,0,0q�6p   $	��Top=�6�   $	��249��6�   ���	#FFA6A6A6$��Italic$�6�   5b      5c      5d      