   M S B A M L   `   `   `  ����M  IWPF 8 Practos MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPF_8_Practos_MVVMWPF_8_Practos_MVVM  5   	   #    WPF_8_Practos_MVVM.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPF_8_Practos_MVVM     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Авторизация��6   $��25(�6'   $��Center=�65   $��Center=�6R   $��3��6m   �� 5   
   -   5         ��Name$ Login_BX��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6$   $��28��6K   $��1��6W   $��1��6g   G� 5   
   -   5         G�Name$ Password_BX��5      $ Пароль��6+   $��28��6S   $��1��6_   $��2��6o   �� 5   
   -   5         ��Name$ 	ErrorSign��5   &   $
��Bold"�6   $��1��69   $��3��6I   $�� ��6V   $��0,10,0,5q�6^   $��Center=�6p   
���  ��6�   �� 5   
   -   5         ��Name$ Authorization_BTN��5   "    �� 	IsDefault . $"��Авторизоваться��6=   $��1��6V   $��4��6f   6s   5      5       