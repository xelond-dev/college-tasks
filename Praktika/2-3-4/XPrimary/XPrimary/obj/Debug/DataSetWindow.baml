   M S B A M L   `   `   `  ����C  ?XPrimary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:XPrimaryXPrimary  5   	       XPrimary.DataSetWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:XPrimary     5   	   _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  XPrimary (DataSet)��5	   	   $	��680��6$   $
��1125��61   
�������.��5
      ��  �� CornerRadius$ 30��6   $	��500��6   $	��800��6/    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 25Q�6      Color$
 Gray��6/      ShadowDepth$ 0Q�6<   ._�5   
   � $	��640��6   $
��1085��6   $��10q�6)   $��Center=�65   
������� � ColumnDefinitions 5      �� 5      �� 5      $
��0.3* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ CurrentTableDgr��5      $��0��5      5      �� 5      $��1��6   $	��Top=�6)   .+�5      �� $��Управление��5   	   $��20(�5   	   $
��Bold"�5   	   $��Center=�5   	   $��1��5    	   $��0,10,0,0q�5!   	   �� 5#      -   5         ��Name$
 tbx1��5#      �� 5$      -   5        $
 tbx2��5$      �� 5%      -   5        $
 tbx3��5%      �� 5&      -   5        	 ��Name$
	 cbx1��5&      �� 5'      -   5        $
	 cbx2��5'      �� 5)      -   5        $��5,10,5,5q�5*   
   $��Добавить��5+   
   5,   
   �� 5.      -   5        $��5,10,5,5q�5/      $��Изменить��50      51      �� 53      -	   5        $��5,10,5,5q�54   
   $��Удалить��55   
   56   
   57      '  !MaterialDesignThemes.Wpf.PackIcon  59      -
   5        
  Name$
 DeveloperFeatures_Icon��5:       � ToolTip$0 *Double click to disable Developer Features��5;      $y�Hidden=�5<      $��1��5=      $��20��5>      $��20��6   $��	0,15,10,0q�6(      Kind$ Wrench=�5?      $��Right=�5@      $	��Top=�5A      5B      �� 5D      -   5         ��Name$! DeveloperFeature_Debug_Text��5E      $��Bottom=�5F      $��Debug:TextBlock��5G      $y�Hidden=�5H      $��30(�5I      �� 5K      $��1��6   $	��Top=�6)   5M      �� 5O      $��1��6   $��Bottom=�6)   .+�5Q      �� $+��%Управление таблицой��5R      $��20(�5S      $
��Bold"�5T      $��Center=�5U      $��1��5V      $��	0,10,0,10q�5W      � 5Z      $��50��6    5[      �� 5\      �� 5]      $
��0.4* �6+   .+�5`      �� -   5        $	 CurrentTableCbx��5a       "  MaterialDesignOutlinedComboBox#��[  5b      $��0��5c      $��	5,0,2.5,0q�5d      5e      �� 5i      -   5        $��1��5j      $��50��5k      $��50��6%   $��	2.5,0,5,0q�60    . *MaterialDesignFloatingActionMiniDarkButton#��[ 5l      .��5n        $��22��62   $��22��6>   $ Reload=�6I   5o      5p      �� 5s      -   5        $��5,10,5,5q�5t      $+��%Представить таблицы��5u      5v      �� 5x      -   5        $��5,5,5,15q�5y      $��EF версия��5z      5{      5}      5�      5�      5�      