   M S B A M L   `   `   `  ���� B  >MyDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MyDiaryMyDiary      MyDiary.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:MyDiary     -     �Name$  MyDiary�� � Title$ MyDiary��$	��135��$	��665�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$ Image/MyDiary.ico�� � AllowsTransparency .  � WindowStyle$
 None=���Z� ����  �� Color$ 	#FF4C8CB8��.��� -    �Name$ MainGrid��$��10q�.+�� -   $ Grid_ui��$��0,0,31,0q�.+��� $
��NOW:��$
��Left=�$��	30,10,0,0q�$	��Top=�$��45��$��90��$��22(�$��Center=�$��Microsoft YaHei UI Light)�
��������� -   	 ��Name$	 
Label_time��$
��TIME��$
��Left=�$��
100,10,0,0q�$	��Top=�$	��280��$��45��$��Center=�$��22(�$��Microsoft YaHei UI Light)�
��������� -   
 ��Name$
 diaryBox��$��40��$��	30,62,0,0q� �� TextWrapping$
 Wrap=�$��	Something��$	��Top=�$��Microsoft YaHei Light)�$��22(�$��Center=�
���������Z�  �� SelectionBrush Z� ��Z� �� -   $	 Label_emotion��$��Happy��$
��Left=�$��
522,10,0,0q�$	��Top=�$��45��$��90��$��22(�$��Center=� J� RenderTransformOrigin$ 5.922,0.678&�$��Center=�$��Microsoft YaHei UI Light)�
�������|�. �� -    ��Name$ image_happy��$
��Left=�$��35��$��
360,16,0,0q�$	��Top=�$��35��$��Image/sunny.png��|�.  � ToolTip$ Happy���� -   $ 	image_sad��$
��Left=�$��35��$��
422,18,0,0q�$	��Top=�$��35��$��Image/rainy.png��|�. $	 Sad���� -	   $ image_angry��$
��Left=�$��35��$��
490,16,0,0q�$	��Top=�$��35��$��Image/lightning.png��|�. $ Angry��� -
   $ 	Grid_btns��.+��� -   $	 Label_close��$��×��$
��Left=�$��614,-14,0,0q�$	��Top=�
�������$��40��$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��22(�4  .System.Windows.Automation.AutomationProperties   HelpText$
 Exit��$
 Exit���� -   $	 
Label_open��$��o��$
��Left=�$��-12,-14,0,0q�$	��Top=�
�������$��40��$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��16(�$ 
Open Diary��$ 
Open Diary���� -   $	 Label_change��$��c��$
��Left=�$��614,88,-9,0q�
�������$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��18(�$��40��$	��Top=�$ Change Color��$ Change Color���� -   $	 
Label_help��$��?��$
��Left=�$��
-14,88,0,0q�$	��Top=�
�������$��40��$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��16(�$
 Help��$
 Help��� -   $ Grid_pw��$y�Hidden=�.+�G� -    G�Name$ PwBox��$
��Left=�$��34��$��
280,46,0,0q�$	��Top=�$	��182��
�������
�������$��Center=���Z�  G� SelectionBrush Z� �� -   $	 Label_password��$��PassWord：��$
��Left=�$��
152,39,0,0q�$	��Top=�$��45��$	��121��$��22(�$��Center=�$ 5.922,0.678&�$��Center=�$��Microsoft YaHei UI Light)�
�������|�. � -   $ 	Grid_help��$y�Hidden=�.+��� -   $	 Label_helptext��$��HelpText��$
��Left=�$��23,6,0,0q�$��Center=�$	��105��$	��391��$��16(�$��Center=�$ 5.922,0.678&�$��Center=�$��Microsoft YaHei UI Light)�
�������|�. �� -   $	 Label_changepw��$��修改密码��$
��Left=�$��
486,38,0,0q�$	��Top=�$��46��$��90��$��16(�$��Center=�$��Microsoft YaHei UI Light)�
�������$��Center=�� -   $ Grid_changepw��$y�Hidden=�.+��� -   $	 Label_oldpw��$��原始密码��$
��Left=�$��
120,16,0,0q�$	��Top=�$��46��$��90��$��16(�$��Center=�$��Microsoft YaHei UI Light)�
�������$��Center=��� -   $	 Label_newpw��$��	新密码��$
��Left=�$��
120,60,0,0q�$	��Top=�$��46��$��90��$��16(�$��Center=�$��Microsoft YaHei UI Light)�
�������$��Center=�G� -   $ OldPwBox��$
��Left=�$��34��$��
280,24,0,0q�$	��Top=�$	��182��
�������
�������$��Center=���Z�  Z� G� -   $ NewPwBox��$
��Left=�$��34��$��
280,66,0,0q�$	��Top=�$	��182��
�������
�������$��Center=���Z�  Z� �� -   $	 Label_changepwenter��$��确认��$
��Left=�$��
486,38,0,0q�$	��Top=�$��46��$��90��$��16(�$��Center=�$��Microsoft YaHei UI Light)�
�������$��Center=�� -   $ Grid_viewer��.+��� $
��NOW:��$
��Left=�$��	30,10,0,0q�$	��Top=�$��45��$��90��$��22(�$��Center=�$��Microsoft YaHei UI Light)�
��������� -   $	 Label_timeviewer��$
��TIME��$
��Left=�$��
100,10,0,0q�$	��Top=�$	��408��$��45��$��Center=�$��22(�$��Microsoft YaHei UI Light)�
��������� -   $
 diaryViewerBox��$��40��$��	30,62,0,0q�$
 Wrap=�$��抽一条日记吧...��$	��Top=�$��Microsoft YaHei Light)�$��22(�$��Center=�
�������$
��Left=�$	��584����Z�  Z� ��Z� �� -   $	 Label_emotionviewer��$��Happy��$
��Left=�$��
522,10,0,0q�$	��Top=�$��45��$��90��$��22(�$��Center=�$ 5.922,0.678&�$��Center=�$��Microsoft YaHei UI Light)�
�������|�. �� -   $	 Label_random��$��R��$
��Left=�$��614,88,-9,-13q�$	��Top=�
�������$��40��$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��16(�$ 
Open Diary��$ 
Open Diary���� -    $	 Label_Chart��$��S��$
��Left=�$��599,88,0,-13q�$	��Top=�
�������$��40��$��40��$��Center=�$��Center=�$��OCR A Extended)�$��0q�$��16(�$ 
Open Diary��$ 
Open Diary��