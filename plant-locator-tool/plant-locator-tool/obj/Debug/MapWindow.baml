   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 68   "    plant_locator_tool.MapWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	   bwpfRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     68     � Title$  Plant Locator��5   	   $	��450��6   $	��800��6,    � 
ResizeMode$ CanMinimize=�68   ���#3b3b3b
�������.��5      �  � ColumnDefinitions 5   
   �� 5      $	��10* �6   6-   �� 5      $	��10* �6   6-   �� 5      $	��50* �6   6-    � RowDefinitions 5   
   �� 5      $��5* �6   6*   �� 5      $��5* �6   6*   �� 5      $	��60* �6   6+   .+�5/   
   ]� $��0��6   $��0��6$   $��2��61   .+�50      o� $	��Top=�6   ���#3b3b3b���#3b3b3b$��0q�6S   .@�51      m� $
��File��6   
����������#3b3b3b���#3b3b3b.@�52      m� -   5         m�Name$ adminOptions��52   6   $��Admin Options��6   ���#3b3b3b
����������#3b3b3b$��0q�6�   .@�53      m� -   5        $ addPlantMenuItem��53   7   $��	Add Plant��6#   ���#3b3b3b
�������6�   m� 54      -   5        $ viewPlantMenuItem��54   8   $��View Plants��6#   ���#3b3b3b
�������6�   m� 55      -   5        $ addUserMenuItem��55   5   $��Add User��6#   ���#3b3b3b6�   m� 56      -   5        $ viewUsersMenuItem��56   7   $��
View Users��6#   ���#3b3b3b6�   m� 57      -   5        $ reports��57   4   $��Reports��6#   ���#3b3b3b6r   58      m� 5:      -   5        $ changePasswordMenuItem��5:   8   $��Change Password��6   ���#3b3b3b
�������6�   m� 5;      -   5        $ quitMenuItem��5;   -   $
��Quit��6   ���#3b3b3b
�������6�   5<      5=      5?      �� 5D   
   -	   5         ��Name$ 	searchBar��5D      $��1��6%   $��0��62   $
��Auto��6B   $
��Auto��6O   $��20��6]   $��80��6l   $	��150��6z   $��40��6�   $��Stretch=�6�   $��Stretch=�6�   $��10, 5, 10, 5q�6�   �� 5E   
   -
   5         ��Name$ searchButton��5E      $��1��6'   $
��Auto��64   $
��Auto��6A   $��1��6O   $��Search��6z   $��Stretch=�6�   $��Stretch=�6�   $��0q�6�   �� 5I   
   $��2��6   $��0��6"   $��2��62   .+�5J      �� $��Plant Information Panel��6   
�������$��14(�6I   $
��Bold"�6W   $��Center=�6i   �� 5K      -   5         ��Name$ plantNameLabel��5K   '   
�������$��Plant Name:��6?   �� 5L      -   5        $ phoneNumberLabel��5L   '   
�������$��Plant Phone:��6A   �� 5M      -   5        $ streetLabel��5M   '   
�������$��Plant Street:��6<   �� 5N      -   5        $ 	cityLabel��5N   '   
�������$��Plant City:��6:   �� 5O      -   5        $ 
stateLabel��5O   '   
�������$��Plant State:��6;   �� 5P      -   5        $ zipLabel��5P   '   
�������$��
Plant Zip:��69   �� 5Q      -   5         ��Name$ productionInfoLabel��5Q   ?   
�������$��
5, 0, 0, 0q�6+   $��
Produces: ��6\   $
��Wrap=�6n   �� 5R      -   5        $ lastUpdatedByLabel��5R   '   
�������$��Last Updated By: ��6C   �� 5S      -   5        $ lastUpdatedDateLabel��5S   '   
�������$��Update Date: ��6E   5V      '  !Microsoft.Maps.MapControl.WPF.Map  5Y   
   -   5        	  Name$	 mainMap��5Y   �   +  %Microsoft.Maps.MapControl.WPF.MapCore
   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F
 @AkbVNqEV1maGXyLUBXjt4QnK1H6LgGdg3UmVxVPEjPbVFtp_a6uqmp7WF-pQQ6n_ 6      Mode;  5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$ AerialWithLabels 6i      	ZoomLevel$ 2Q�6�   $��2��6�   $��1��6�   $��2��6�   6�   5Z      5[      