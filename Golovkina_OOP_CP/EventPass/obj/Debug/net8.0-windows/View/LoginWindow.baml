   M S B A M L   `   `   `  ����D  @EventPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EventPass.ViewEventPass.View  5   	        EventPass.View.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EventPass.View     5   	   $	��400��5      $	��350��6'     � Icon$  	/icon.png��63    � 	Resources 5	         TextOnlyHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        �� 5
   
   " ��61   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � �� �	#FFA6A6A66+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 Left=�6;   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Center=�6+   $
��Left=�6F   $��4q�6a   5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �	#FF9B72CF63   5      5      5      .��5      (� 	 (� Stretch$	 Uniform=�6   .��5    
   � .+�5!      � $��Center=�6   $	��380��60   $��Center=�6=   $	��350��6X   .+�5"      �� $��147,23,150,304q�6   $��/Resources/icon.png��60   $
��Fill=�6M   �� 5#      $��Event��6   $��138,60,164,292q�6(   $
��Bold"�6@   ���	#FFA6A6A6$��14(�6i   �� 5$      $
��Pass��6   $��175,60,135,292q�6'   $
��Bold"�6?   ���	#FF9B72CF$��14(�6h   �� 5%      $��Log in��6   $��Center=�6)   $��	0,108,0,0q�6F   $��18(�6Y   $
��Bold"�6g   $��34��6y   $	��Top=�6�   �� 5&      -   5        
 ��Name$
 TextBox_Login��5&      $��Center=�5'      $	��Top=�5(      $��	0,158,0,0q�5)      $	��314��5*      $��32��5+      $��14(�5,      $��Login��5-       �� TextWrapping$
 Wrap=�5.      $��0q�51      ���	#FFA6A6A6 �� SelectionBrush �	#FF9B72CF$��Center=�54      ��5/      Z� ��50      Z�  � FocusVisualStyle 55      Z� 6g   �� 56      $��Center=�6   $��1��69   ���	#FFA6A6A6$��Center=�6W   $	��314��6r   �� 57      -   5        $
 TextBox_Password��57      $��Center=�58      $	��Top=�59      $��	0,208,0,0q�5:      $	��314��5;      $��32��5<      $��14(�5=      $��Password��5>      $
 Wrap=�5?      $��0q�5B      ���	#FFA6A6A6 �	#FF9B72CF$��Center=�5E      ��5@      Z� ��5A      Z�  5F      Z� �� 5G      $
��Left=�6   $��1��67   ���	#FFA6A6A6$	��Top=�6U   $	��314��6m   $��
16,239,0,0q�6y   �� 5H      -   5         ��Name$ Label_Exception��5H      $��	Exception��61   $
��Left=�6E   $��
16,252,0,0q�6`   $	��Top=�6t   $	��312��6�   ���	#FFCC0000$��14(�6�   $
��Bold"�6�   $y�Hidden=�6�   �� 5I      -   5         ��Name$ Button_Login��5I      $��Login��6/   $��63,294,63,0q�6?   ���	#FF9B72CF
�������$
��Bold"�6~   $��40��6�   $	��Top=�6�    � Cursor$
 Hand��6�   $��14(�6�   ��6�   Z� ��5J      �� 5K      " ��6*   .R�5L      ��  ��Name$ border��6%   #��z��5M   !   #��z��5N   !   #��z��5O   !    �� CornerRadius$ 20��5P   !   ._�5Q   "   �� $��Center=�63   $��Center=�5R   %   $
��True��5S   %   5T       �� Triggers 5U      P� 5V   "    �@J�IsMouseOver$
 True��6A   . �5W   &   ��  �� 
TargetName$ border��6-    � �� �#decdff6W   5X   #   5Z      5\      �� 5]      -   5        $ Button_NotHaveAccount��5]      $��I do not have an account��68   $��94,337,94,18q�6[   #��[  5^      $
 Hand��63   6A   G� 5_      -   5         G�Name$ PasswordBox_Password��5_      $
��Left=�6<   $��
18,208,0,0q�6W   $	��Top=�6k   $	��310��6�   ���	#FFA6A6A6 G� SelectionBrush �	#FF9B72CF$��31��6�   $��Center=�6�   $��0,0,0,0q�6  $��13(�66  ��6�   Z� ��6�   Z� 6�  5`      5a      5b      5c      