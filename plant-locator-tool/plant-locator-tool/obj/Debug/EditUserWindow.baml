   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   '    !plant_locator_tool.EditUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  	Edit User��5   	   $	��275��6   $	��320��6(   ���#3b3b3b
������� � 
ResizeMode$ CanMinimize=�6\   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ nameOfUserLabel��5   T   
�������$��0��6#   $��0��63   $��2��6@   $�� ��6m   �� 5   
   
�������$��Center=�6#   $��0��6>   $��1��6N   $��Change Username To:��6[   �� 5   
   -   5         ��Name$ usernameTextBox��5   G   $��10, 15, 10, 15q�6   $��1��6*   $��1��6:   6G   �� 5   
   
�������$��Center=�6#   $��0��6>   $��2��6N   $��Change Admin Status:��6[   �� 5   
   -   5         ��Name$ isAdminCheckBox��5   h   $��Center=�6   $��Center=�6.   $��1��6K   $��2��6[   6h   �� 5   
   -   5         ��Name$ 
saveButton��5   F   $��20, 10, 20, 10q�6   $��0��6)   $��3��69   $
��Save��6Z   6i   �� 5   
   -   5        $ cancelButton��5   F   $��20, 10, 20, 10q�6   $��1��6)   $��3��69   $��Cancel��6\   6m   5      5      