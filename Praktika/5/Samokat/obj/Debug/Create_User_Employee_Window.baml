   M S B A M L   `   `   `  ����B  >Samokat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SamokatSamokat  5   	   )    #Samokat.Create_User_Employee_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   !localclr-namespace:Samokat  5   	     � Title$  
MainWindow��5	   	   $
��1015��6   $	��812��6*   ���#ff335f.��5
      � .+�5   
   �� $��50��6   $	��250��6   $��Center=�6(   $	��Top=�6E   $��25q�6]   $��logo.png��6i   �� 5   
   $��Center=�6   $	��Top=�62   $��0, 100, 0, 0q�6J   .+�5      �� -   5         ��Name$ Type_Of_ComboBox��5      $��25(�61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Тип новой записи��6?   $��Center=�6q   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5         ��Name$ LastName_TextBox��5      $��25(�60   $- 'Фамилия пользователя��6>    �� TextAlignment$ Center=�6t   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5        $ FirstName_TextBox��5      $��25(�61   $% Имя пользователя��6?   $ Center=�6q   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5        $ MiddleName_TextBox��5      $��25(�62   $/ )Отчество пользователя��6@   $ Center=�6w   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5        $ Username_TextBox��5      $��25(�60   $ 
Логин��6>   $ Center=�6e   $��50��6|   $	��712��6�   $��15q�6�   
�������6�   G� 5      -   5         G�Name$ Password_PasswordBox��5      $��25(�68   $ Пароль��6F   $��Center=�6n   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5        $&  Priority_Payment_Method_ComboBox��5      $��25(�6A   $4 .Приоритетный тип платежа��6O   $��Center=�6�   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -   5        $ Position_ComboBox��5      $��25(�62   $ Должность��6@   $��Center=�6k   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      -	   5        $ Age_TextBox��5      $��25(�6+   $ Возраст��69   $ Center=�6b   $��50��6y   $	��712��6�   $��15q�6�   
�������6�   �� 5      -
   5        $ Experience_TextBox��5      $��25(�62   $ Опыт работы��6@   $ Center=�6m   $��50��6�   $	��712��6�   $��15q�6�   
�������6�   �� 5      $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� -   5         ��Name$! Create_User_Employee_Button��5      $��15q�6>   $��25(�6J   $	��350��6X   $��50��6d   
�������$.��(Добавить новую запись��6�   6�   �� 5      -   5        $ Close_Button��5      $��15q�6/   $��25(�6;   $	��350��6I   $��50��6U   
�������$��Закрыть��6t   6�   5       5"      5&      5'      