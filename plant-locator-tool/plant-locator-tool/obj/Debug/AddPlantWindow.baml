   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   '    !plant_locator_tool.AddPlantWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  AddPlantWindow��5   	   $	��400��6    $	��325��6-   ���#3b3b3b
������� � 
ResizeMode$ CanMinimize=�6a   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� 
�������$��Center=�6#   $��0��6>   $��0��6N   $��Name:��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��1��6N   $��Phone Number:��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��2��6N   $��Products Produced:��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��3��6N   $��Street��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��4��6N   $
��City��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��5��6N   $��State��6\   �� 5   
   
�������$��Center=�6#   $��0��6>   $��6��6N   $	��Zip��6\   �� 5    
   -   5         ��Name$ addPlantButton��5    b   $��30, 10, 30, 10q�6   $��Center=�6)   $��0��6D   $��7��6T   $	��Add��6z   6�   �� 5#   
   -   5         ��Name$ plantNameTextbox��5#   /   $��1��6   $��0��6"   $��10q�6I   6U   �� 5$   
   -   5        $ phoneNumberTextbox��5$   /   $��1��6   $��1��6"   $��10q�6K    �� 	MaxLength$ 12��6W   �� 5%   
   -   5        $ productsProducedTextbox��5%   /   $��1��6   $��2��6"   $��10q�6P   $��50��6\    �� TextWrapping$
 Wrap=�6h   " �� VerticalScrollBarVisibility$
 Auto=�6|   $	 100��6�   �� 5&   
   -   5        $ streetTextbox��5&   /   $��1��6   $��3��6"   $��10q�6F   �� 5'   
   -   5        $ cityTextbox��5'   /   $��1��6   $��4��6"   $��10q�6D   �� 5(   
   -   5        $ stateTextbox��5(   h   $��1��6   $��5��6"   $��Center=�6/   $��Stretch=�6J   $ 2��6~   $��50,11q�6�   �� 5)   
   -   5        $ 
zipTextBox��5)   /   $��1��6   $��6��6"   $��Center=�6C   $��Stretch=�6^   $ 5��6|   $��50,10,50,11q�6�   �� 5*   
   -	   5        $ cancelButton��5*   G   $��30, 10, 30, 10q�6   $��1��6)   $��7��69   $��Cancel��6]   6n   5-      5.      