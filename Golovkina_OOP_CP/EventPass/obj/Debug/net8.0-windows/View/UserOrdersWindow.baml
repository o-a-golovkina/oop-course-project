   M S B A M L   `   `   `  ����D  @EventPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EventPass	EventPass  5   	   %    EventPass.View.UserOrdersWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EventPass     5   	     � Title$  	EventPass��5   	   $	��450��6   $	��800��6(    � Icon$ 	/icon.png��64    � 	Resources 5
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
��Bold"�6>   ���	#FF9B72CF$��14(�6g   �� 51      -   5         ��Name$ Label_YourOrders��51      $��Your orders��62   $
��Left=�6H   $��
170,81,0,0q�6c   $	��Top=�6w   $
��Bold"�6�   $��14(�6�   �� 52      $��694,22,82,388q�6   $ ��/Resources/icon-person.png��6/   $
��Fill=�6S   �� 53      $��616,22,160,388q�6   $��/Resources/icon-money.png��60   $
��Fill=�6S   �� 54      $��540,25,241,390q�6   $��/Resources/icon-cart.png��60   $
��Fill=�6R   �� 55      -   5         ��Name$ Button_Orders��55      $��Orders��60   $��554,24,210,0q�6A   $��20��6W   $	��Top=�6c   #��[  56       � Cursor$
 Hand��6G   $��8(�6U   �� 57      -   5        $ Button_Balance��57      $��Balance��61   $��636,25,128,0q�6C   $��20��6Y   $	��Top=�6e   #��[  58      $
 Hand��6G   $��8(�6U   6b   �� 59      -   5        $ Button_UserLogin��59      $��
User login��63   $��712,25,44,0q�6H   $��20��6]   $	��Top=�6i   #��[  5:      $
 Hand��6G   $��8(�6U   6b   &   System.Windows.Controls.DataGrid  5;      -   5          Name$ DataGrid_Orders��5;      $
��Left=�64   $	��302��6O   $��173,115,0,0q�6\   $	��Top=�6q   $	��602��6�      VerticalGridLinesBrush �	#FFA6A6A6   HorizontalGridLinesBrush �	#FFA6A6A6$��10(�65     AutoGenerateColumns$ False��6C  ��6�   Z� ��6�   Z�    Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     5>      $ 
Event - id��6-   $ * 6_    6A   �� *	EventName+6_     5?      $ Date and time��6-   $ * 6b    6D   �� *	EventDate+6b     5@      $ Price��6-   $ * 6V    6<   �� *Price+6V     5A      $
 City��6-   $ * 6T    6;   �� *City+6T   5C      5D      �� 5E      -   5        $ Button_Home��5E      $��Button��6*   $
��Left=�6;   $��	49,35,0,0q�6V   $	��Top=�6i   $��44��6�   $��43��6�   $
 Hand��6�   ��6�   Z� ��6�   Z� ��6�   Z� ��5F      �� 5G      " ��6&   .R�5H      �� #��z��6!   ._�5I      �� $��/Resources/icon.png��6$   5J      5K      5M      �� 5N      -   5        $ Label_No��5N      $:��4You haven't placed any orders yet. Time to fix that!��6&   $
��Left=�6e   $��181,110,0,0q�6�   $	��Top=�6�   $	��249��6�   ���	#FFA6A6A6$��Italic$�6�   5O      5P      5Q      