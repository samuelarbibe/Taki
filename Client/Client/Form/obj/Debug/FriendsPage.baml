   M S B A M L   `   `   `  ����?  ;Form, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FormForm  5      3clr-namespace:Form.TakiServiceForm.TakiService  5          Form.FriendsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Form     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0takiServiceclr-namespace:Form.TakiService  5        N� Title$  FriendsPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 
BackButton��5      
������ 
������ $��5,5,0,0q�6r   $0��*/Form;component/Resources/Fonts/Asap/#Asap)�6�   $��40��6�   $	��Top=�6�   $
��Left=�6�   $��40��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftThick=�6&   $��40��6<   $��40��6G   5       �� 5"   
   -   5         ��Name$
 View��5"   4   $��1��6   $��0q�6    
������ $��7��6[   $��1��6l   $��Stretch=�6|   ��5#      �� 5$      .R�5%      ��  �� Orientation$ Vertical=�6!   $��Stretch=�68    K� IsItemsHost . $	��Top=�6i   ���	#FFE3E3E36�   5&      ��5)      �� 5*       �� DataType   Form.TakiService.User"  6   .R�5+      #  MaterialDesignThemes.Wpf.Card  ���	#FFEFEFEF���	#FF4D99D0$��0q�5.      $	��100��5/      $	��380��50      $��Center=�51      $0��*/Form;component/Resources/Fonts/Asap/#Asap)�52      $��Heavy"�53      .��54      �  55      �� 56   "   $
��Auto �57   %   �� 58   "   $
��Auto �59   %   �� 5:   "   $
��Auto �5;   %   .+�5=      �� $��0��5>   !   $��
16 16 16 4q�5?   !    #  MaterialDesignHeadlineTextBlock#��[  5@   !   ��6Z   �� *
Username+5B      �� 5C      $��1��5D   !      MaterialDesignLightSeparator#��[ 5E   !   �� 5F      $��2��5G   !   $��	16 0 16 8q�5H   !   $��Center=�5I   !   $
��Left=�5J   !      MaterialDesignBody2TextBlock#��[ 5K   !   �� 5L   "   $�Level ��6&    �� 5M   "   �6&   �� *Level+5N      �� 5O      	 ��Name$	 Panels��5P   !   $��2��5Q   !   $ 
Horizontal=�5R   !   $��	16 0 16 8q�5S   !   $��Right=�5T   !   .+�5U   "   �� $ RemoveFriendButton��5V   %   -   5        $��Right=�5X   %    & "MaterialDesignToolForegroundButton#��[ 5Y   %   $��30��5Z   %   $��2 0 2 0q�5[   %   +  %MaterialDesignThemes.Wpf.RippleAssist
   
IsCentered
 .  � ToolTip$ Remove Friend��5]   %   .��5^   &     $ AccountRemoveOutline=�6>   5_   #   �� 5`   "   $ MutualGamesButton��5a   %   -   5        $��right=�5c   %   #��[ 5d   %   $��30��5e   %   $��2 0 2 0q�5f   %   
 . $ See Mutual Games��5h   %   .��5i   &     $ 	EventTime=�6>   5j   #   5k      5l      5m      5n      5p      5q      5r      