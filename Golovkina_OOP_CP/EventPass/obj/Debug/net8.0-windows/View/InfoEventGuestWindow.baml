   M S B A M L   `   `   `  ����D  @EventPass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EventPass.ViewEventPass.View  5   	   )    #EventPass.View.InfoEventGuestWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EventPass.View     5   	   $	��325��5      $	��600��6'     � Icon$  	/icon.png��6I   ��63   Z� .��5      (�  (� Stretch$ Uniform=�6   .��5	   
   � .+�5
      � $��Center=�6   $	��309��60   $��Center=�6=   $	��600��6X   .+�5      �� $��	20,29,0,0q�6    �� CornerRadius$ 20��5      $	��Top=�5      $	��270��5      $	��235��5      $
��Left=�5      $
}�True��5      ��5      �� 5      -   5        ImageBrush_EventPic�� j� Stretch$
 Fill=�5   B   5      �� 5      -   5         ��Name$ Label_EventName��5      $��
EVENT NAME��61   $
��Left=�6F   $��35��6a   $��
315,29,0,0q�6m   $	��Top=�6�   $	��275��6�   $
��Bold"�6�   $��18(�6�   �� 5      -   5        $ 
Label_Date��5      $��Date: ��6,   $
��Left=�6=   $��
315,64,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   $��14(�6�   $	��126��6�   �� 5      -   5        $ 
Label_Time��5      $��Time: ��6,   $
��Left=�6=   $��
452,64,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   $��14(�6�   $	��115��6�   �� 5      $��548,257,14,14q�6   $��/Resources/icon.png��6/   $
��Fill=�6L   �� 5      $��Event��6   $��541,284,24,5q�6(   $
��Bold"�6>   ���	#FFA6A6A6$��9(�6g   �� 5      $
��Pass��6   $��565,284,6,5q�6'   $
��Bold"�6<   ���	#FF9B72CF$��9(�6e   �� 5      -   5         ��Name$ Button_LoginToBuy��5      $��Login to buy��64   $��374,0,70,44q�6K   ���	#FF9B72CF
�������$
��Bold"�6�   $��35��6�   $��Bottom=�6�    � Cursor$
 Hand��6�   ��6�   Z� ��5      �� 5       �� 
TargetType" ��6*   .R�5      ��  ��Name$ border��6%   #��z��5       #��z��5!      #��z��5"      $ 20��5#      ._�5$   "   �� $��Center=�63   $��Center=�5%   !   $
��True��5&   !   5'      	 �� Triggers	 5(      P� 5)   "   
 P� Property
 �@J�IsMouseOver P� Value$
 True��6A   . �5*   &   ��  �� 
TargetName$ border��6-    �� Property � �� �� Value �#decdff6W   5+   #   5-      5/      �� 50      $��1q�6   $
��Left=�6-   $��31��6H   $��315,184,0,0q�6T   $	��Top=�6i   $	��252��6�   ���	#339B72CF$ 8,8,8,8��6�   �� 51      -   5        $ 
Label_City��51      $��City: ��6,   $
��Left=�6=   $��452,145,0,0q�6X   $	��Top=�6m   $
��Bold"�6�   $��14(�6�   $	��115��6�   52      �� 53      -   5        $ Label_Price��53      $��Price: ��6)   $
��Left=�6;   $��315,105,0,0q�6V   $	��Top=�6k   $
��Bold"�6�   $��14(�6�   $	��125��6�   �� 54      -   5        $ Label_FreePlaces��54      $��Free: ��6.   $
��Left=�6?   $��452,105,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   $��14(�6�   $	��113��6�   �� 55      -	   5        $ Label_EventType��55      $��Type: ��6-   $
��Left=�6>   $��315,145,0,0q�6Y   $	��Top=�6n   $
��Bold"�6�   $��14(�6�   $	��125��6�   �� 56      -
   5        $ Label_Extra��56      $��Extra��6)   $
��Left=�69   $��321,184,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   $��14(�6�   58      59      5:      