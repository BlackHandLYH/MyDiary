   M S B A M L   `   `   `  ����B  >MyDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MyDiaryMyDiary  5   	       MyDiary.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MyDiary     5   	   -   5          �Name$  MyDiary��5   	    � Title$ MyDiary��5   	   $	��135��6   $	��665��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � Icon$ Image/MyDiary.ico��6�    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��6�   Z� ��5	      �� 5
   
    �� Color$ 	#FF4C8CB8��6   .��5      � -   5         �Name$ MainGrid��5      $��10q�6   .+�5   
   � -   5        $ Grid_ui��5      $��0,0,31,0q�6    .+�5      �� $
��NOW:��6   $
��Left=�6#   $��	30,10,0,0q�6>   $	��Top=�6Q   $��45��6i   $��90��6u   $��22(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������6�   �� 5      -   5        	 ��Name$	 
Label_time��5      $
��TIME��6(   $
��Left=�67   $��
100,10,0,0q�6R   $	��Top=�6f   $	��280��6~   $��45��6�   $��Center=�6�   $��22(�6�   $��Microsoft YaHei UI Light)�6�   
�������6�   �� 5      -   5        
 ��Name$
 diaryBox��5      $��40��6(   $��	30,62,0,0q�64    �� TextWrapping$
 Wrap=�6G   $��	Something��6[   $	��Top=�6l   $��Microsoft YaHei Light)�6�   $��22(�6�   $��Center=�6�   
���������6A  Z�  �� SelectionBrush 6X  Z� ��6r  Z� �� 5      -   5        $	 Label_emotion��5      $��Happy��6+   $
��Left=�6;   $��
522,10,0,0q�6V   $	��Top=�6j   $��45��6�   $��90��6�   $��22(�6�   $��Center=�6�    J� RenderTransformOrigin$ 5.922,0.678&�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6  
�������|�. 6J  �� 5      -   5         ��Name$ image_happy��5      $
��Left=�6)   $��35��6D   $��
360,16,0,0q�6P   $	��Top=�6d   $��35��6|   $��Image/sunny.png��6�   |�.  � ToolTip$ Happy��6�   �� 5      -   5        $ 	image_sad��5      $
��Left=�6'   $��35��6B   $��
422,18,0,0q�6N   $	��Top=�6b   $��35��6z   $��Image/rainy.png��6�   |�. $	 Sad��6�   �� 5      -	   5        $ image_angry��5      $
��Left=�6)   $��35��6D   $��
490,16,0,0q�6P   $	��Top=�6d   $��35��6|   $��Image/lightning.png��6�   |�. $ Angry��6�   5      � 5   
   -
   5        $ 	Grid_btns��5      .+�5      �� -   5        $	 Label_close��5      $��×��6)   $
��Left=�65   $��614,-14,0,0q�6P   $	��Top=�6e   
�������$��40��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6?  $��22(�6K  4  .System.Windows.Automation.AutomationProperties   HelpText$
 Exit��6�  $
 Exit��6�  �� 5      -   5        $	 
Label_open��5      $��o��6(   $
��Left=�64   $��-12,-14,0,0q�6O   $	��Top=�6d   
�������$��40��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6  $��16(�6�  $ 
Open Diary��6�  $ 
Open Diary��6�  �� 5      -   5        $	 Label_change��5      $��c��6*   $
��Left=�66   $��614,88,-9,0q�6Q   
�������$��40��6y   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6�   $��18(�6�   $��40��6   $	��Top=�6  $ Change Color��6�  $ Change Color��6�  �� 5      -   5        $	 
Label_help��5      $��?��6(   $
��Left=�64   $��
-14,88,0,0q�6O   $	��Top=�6c   
�������$��40��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6  $��16(�6  $
 Help��6�  $
 Help��6�  5      � 5   
   -   5        $ Grid_pw��5      $y�Hidden=�6    .+�5      G� -   5         G�Name$ PwBox��5      $
��Left=�6)   $��34��6D   $��
280,46,0,0q�6P   $	��Top=�6d   $	��182��6|   
�������
�������$��Center=�6�   ��6�   Z�  G� SelectionBrush 6�   Z� 6�   �� 5      -   5        $	 Label_password��5      $��PassWord：��6,   $
��Left=�6@   $��
152,39,0,0q�6[   $	��Top=�6o   $��45��6�   $	��121��6�   $��22(�6�   $��Center=�6�   $ 5.922,0.678&�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6  
�������|�. 6P  5      � 5    
   -   5        $ 	Grid_help��5       $y�Hidden=�6"   .+�5!      �� -   5        $	 Label_helptext��5!      $��HelpText��6,   $
��Left=�6?   $��23,6,0,0q�6Z   $��Center=�6l   $	��105��6�   $	��391��6�   $��16(�6�   $��Center=�6�   $ 5.922,0.678&�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6  
�������|�. 6Q  �� 5"      -   5        $	 Label_changepw��5"      $��修改密码��6,   $
��Left=�6;   $��
486,38,0,0q�6V   $	��Top=�6j   $��46��6�   $��90��6�   $��16(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������$��Center=�6  6&  5#      � 5$   
   -   5        $ Grid_changepw��5$      $y�Hidden=�6&   .+�5%      �� -   5        $	 Label_oldpw��5%      $��原始密码��6)   $
��Left=�68   $��
120,16,0,0q�6S   $	��Top=�6g   $��46��6   $��90��6�   $��16(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������$��Center=�6�   �� 5&      -   5        $	 Label_newpw��5&      $��	新密码��6)   $
��Left=�67   $��
120,60,0,0q�6R   $	��Top=�6f   $��46��6~   $��90��6�   $��16(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������$��Center=�6�   G� 5'      -   5        $ OldPwBox��5'      $
��Left=�6,   $��34��6G   $��
280,24,0,0q�6S   $	��Top=�6g   $	��182��6   
�������
�������$��Center=�6�   ��6�   Z�  6�   Z� 6�   G� 5(      -   5        $ NewPwBox��5(      $
��Left=�6,   $��34��6G   $��
280,66,0,0q�6S   $	��Top=�6g   $	��182��6   
�������
�������$��Center=�6�   ��6�   Z�  6�   Z� 6  �� 5)      -   5        $	 Label_changepwenter��5)      $��确认��61   $
��Left=�6>   $��
486,38,0,0q�6Y   $	��Top=�6m   $��46��6�   $��90��6�   $��16(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������$��Center=�6  6)  5*      � 5+   
   -   5        $ Grid_viewer��5+      .+�5,      �� $
��NOW:��6   $
��Left=�6#   $��	30,10,0,0q�6>   $	��Top=�6Q   $��45��6i   $��90��6u   $��22(�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6�   
�������6�   �� 5-      -   5        $	 Label_timeviewer��5-      $
��TIME��6.   $
��Left=�6=   $��
100,10,0,0q�6X   $	��Top=�6l   $	��408��6�   $��45��6�   $��Center=�6�   $��22(�6�   $��Microsoft YaHei UI Light)�6�   
�������6�   �� 5.      -   5        $
 diaryViewerBox��5.      $��40��6.   $��	30,62,0,0q�6:   $
 Wrap=�6M   $��抽一条日记吧...��6a   $	��Top=�6r   $��Microsoft YaHei Light)�6�   $��22(�6�   $��Center=�6�   
�������$
��Left=�6�  $	��584��6�  ��6G  Z�  6^  Z� ��6x  Z� 6�  �� 5/      -   5        $	 Label_emotionviewer��5/      $��Happy��61   $
��Left=�6A   $��
522,10,0,0q�6\   $	��Top=�6p   $��45��6�   $��90��6�   $��22(�6�   $��Center=�6�   $ 5.922,0.678&�6�   $��Center=�6�   $��Microsoft YaHei UI Light)�6  
�������|�. 6P  �� 50      -   5        $	 Label_random��50      $��R��6*   $
��Left=�66   $��614,88,-9,-13q�6Q   $	��Top=�6h   
�������$��40��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6  $��16(�6  $ 
Open Diary��6&  $ 
Open Diary��6Q  6�  �� 51      -    5        $	 Label_Chart��51      $��S��6)   $
��Left=�65   $��599,88,0,-13q�6P   $	��Top=�6f   
�������$��40��6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��OCR A Extended)�6�   $��0q�6
  $��16(�6  $ 
Open Diary��6$  $ 
Open Diary��6O  6�  52      53      54      