   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   &     plant_locator_tool.AddUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  Add User��5   	   $	��275��6   $	��320��6'    � 
ResizeMode$ CanMinimize=�63   ���#3b3b3b
�������.��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��Center=�6   $��0��6+   $��0��6;   
�������$��Username��6[   6p   �� 5   
   -   5         ��Name$ usernameTextBox��5   I   $��10, 15, 10, 15q�6   $��1��6,   $��0��6<   6d   �� 5   
   $��Center=�6   $��0��6,   $��1��6<   
�������$��Password��6\   6q   G� 5   
   -   5         G�Name$ passwordBox��5   K   $��10, 15, 10, 15q�6   $��1��6.   $��1��6>   6b   �� 5   
   $��Center=�6   $��0��6+   $��2��6;   
�������$��Admin��6[   �� 5   
   -   5         ��Name$ isAdminCheckbox��5   h   $��Center=�6   $��Center=�6.   $��1��6K   $��2��6[   6h   �� 5   
   -   5         ��Name$ addUserButton��5   :   $��10q�6   $��0��6   $��3��6-   $	��Add��6m   �� 5    
   -   5        $ cancelButton��5    :   $��10q�6   $��1��6   $��3��6-   $��Cancel��6k   5!      5"      