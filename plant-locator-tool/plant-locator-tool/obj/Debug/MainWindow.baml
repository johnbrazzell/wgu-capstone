   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   #    plant_locator_tool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  Plant Locator Login��5   	   $	��300��6%   $	��400��62   ���#3b3b3b
������� � 
ResizeMode$ CanMinimize=�6f   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $��0.25* �6   �� 5      $��0.25* �6   �� 5      $��0.25* �6    � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $��0.10* �6   �� 5      $��0.10* �6   �� 5      $��0.25* �6   .+�5   
   �� $��Username��6   $��1��6#   $��1��63   
�������$��Right=�6S   $��Center=�6o   �� 5   
   -   5         ��Name$ userNameTextBox��5      $��2��6+   $��1��6;   $��25��6H   $	��150��6T   �� 5   
   $��Password��6   $��1��6#   $��2��63   
�������$��Right=�6T   $��Center=�6p   G� 5   
   -   5         G�Name$ passwordBox��5      $��2��6+   $��2��6;   $��25��6H   $	��150��6T   �� 5   
   -   5         ��Name$ loginButton��5      $��Login��6&   $��2��66   $��4��6F   $��75��6S   $��25��6^   $	��Top=�6j   6�   5       5#      