   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   (    "plant_locator_tool.EditPlantWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  
Edit Plant��5   	   $	��400��6   $	��325��6)   ���#3b3b3b
������� � 
ResizeMode$ CanMinimize=�6]   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� 
�������$��Center=�6#   $��0��6>   $��0��6N   $��Name:��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��1��6N   $��Phone Number:��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��2��6N   $��Products Produced:��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��3��6N   $��Street��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��4��6N   $
��City��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��5��6N   $��State��6[   �� 5   
   
�������$��Center=�6#   $��0��6>   $��6��6N   $	��Zip��6[   �� 5    
   -   5         ��Name$ updatePlantbutton��5    F   $��30, 10, 30, 10q�6   $��0��6)   $��7��69   $��Update��6a   6r   �� 5$      -   5         ��Name$ plantNameTextbox��5$   3   $��1��6   $��0��6&   $��10q�6M   �� 5%      -   5        $ phoneNumberTextbox��5%   3   $��1��6   $��1��6&   $��10q�6O    �� 	MaxLength$ 12��6[   �� 5&      -   5        $ productsProducedTextbox��5&   3   $��1��6   $��2��6&   $��10q�6T   $��50��6`    �� TextWrapping$
 Wrap=�6l   " �� VerticalScrollBarVisibility$
 Auto=�6�   $	 100��6�   �� 5'      -   5        $ streetTextbox��5'   3   $��1��6   $��3��6&   $��10q�6J   �� 5(      -   5        $ cityTextbox��5(   3   $��1��6   $��4��6&   $��10q�6H   �� 5)      -   5        $ stateTextbox��5)   3   $��1��6   $��5��6&   $ 2��6I   $��10q�6W   �� 5*      -   5        $ 
zipTextBox��5*   3   $��1��6   $��6��6&   $ 5��6G   $��10q�6U   �� 5,      -	   5        $ cancelButton��5,   J   $��30, 10, 30, 10q�6   $��1��6-   $��7��6=   $��Cancel��6`   6q   5/      50      