   M S B A M L   `   `   `  ����D  @EventPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EventPass.ViewEventPass.View  5   	   "    EventPass.View.BalanceWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EventPass.View     5   	   $	��310��5      $	��475��6'     � Icon$  	/icon.png��6I   ��63   Z� .��5      (�  (� Stretch$ Uniform=�6   .��5	   
   � .+�5
      � $��Center=�6   $	��375��60   $��Center=�6=   $	��600��6X   .+�5      �� $��Balance��6   $��35��6*   $��253,77,252,0q�66   $	��Top=�6L   $
��Bold"�6d   $��22(�6v   �� 5      $��On your balance:��6   $��204,316,0,0q�63   $	��Top=�6H   $��18(�6`   
�������$
��Left=�6�   $	��144��6�   �� 5      -   5         ��Name$ 	Label_SUM��5      $	��SUM��6+   $��
0,316,67,0q�69   $	��Top=�6M   $
��Bold"�6e   $��18(�6w   ���	#FF9B72CF$��Right=�6�   $	��187��6�   �� 5      $��
0,15,538,0q�6   $��/Resources/icon.png��6,   $
��Fill=�6I   $��38��6X   $	��Top=�6d   $��Right=�6|   $��38��6�   �� 5      $��Event��6   $��17,42,548,312q�6(   $
��Bold"�6?   ���	#FFA6A6A6$��9(�6h   �� 5      $
��Pass��6   $��41,42,530,312q�6'   $
��Bold"�6>   ���	#FF9B72CF$��9(�6g   �� 5      -   5         ��Name$ Button_PutMoney��5      $��	Put money��62   $��54,223,329,0q�6F   ���	#FF9B72CF
�������$
��Bold"�6�   $��44��6�   $	��Top=�6�    � Cursor$
 Hand��6�   $��18(�6�   ��6�   Z� ��5      �� 5       �� 
TargetType" ��6*   .R�5      ��  ��Name$ border��6%   #��z��5      #��z��5      #��z��5       �� CornerRadius$ 20��5      ._�5   "   �� $��Center=�63   $��Center=�5   !   $
��True��5   !   5       �� Triggers 5      P� 5   "   	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6A   . �5   &   ��  �� 
TargetName$ border��6-    �� Property � �� �� Value �#decdff6W   5    #   5"      5$      �� 5%      -   5        $ Button_WithdrawMoney��5%      $��Withdraw money��67   $��329,223,54,0q�6P   ���	#FF9B72CF
�������$
��Bold"�6�   $��44��6�   $	��Top=�6�   $
 Hand��6�   $��18(�6�   ��6�   Z� ��5&      �� 5'      " ��6*   .R�5(      �� $ border��6%   #��z��5)   !   #��z��5*   !   #��z��5+   !   $ 20��5,   !   ._�5-   "   �� $��Center=�63   $��Center=�5.   %   $
��True��5/   %   50       51      P� 52   "   	 �@J�IsMouseOver$

 True��6A   . �53   &   �� $ border��6-    � �� �#decdff6W   54   #   56      58      �� 59      -   5         ��Name$ TextBox_SUM��59      $	��Top=�5:      $��197,139,197,0q�5;      $��32��5<      $��18(�5=      $��Enter the amount��5>       �� TextWrapping$
 Wrap=�5?      $��0q�5B      ���	#FFA6A6A6 �� SelectionBrush �	#FF9B72CF$��Center=�5E      $��Center=�5F   s   ��5@      Z� ��5A      Z�  � FocusVisualStyle 5F      Z� 6�   �� 5G      $��Center=�6   $��1��69   ���	#FFA6A6A6$	��Top=�6W   $	��208��6o   $��	0,171,0,0q�6{   �� 5H      -   5        $ Label_Exception��5H      $��	Exception��61   $��	0,177,0,0q�6E   $	��Top=�6X   ���	#FFCC0000$��14(�6�   $
��Bold"�6�   $y�Hidden=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6  $	��312��6  5I      5K      5L      5M      