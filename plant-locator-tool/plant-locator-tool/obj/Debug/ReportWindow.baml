   M S B A M L   `   `   `  ����M  Iplant-locator-tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:plant_locator_toolplant_locator_tool  5   	   %    plant_locator_tool.ReportWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:plant_locator_tool     5   	     � Title$  Reports��5   	   $��434.06��6   $��779.156��6)   ���#3b3b3b
������� � 
ResizeMode$ CanMinimize=�6a   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��84* �6   �� 5      $
��458* �6   �� 5      $	��69* �6    � RowDefinitions 5   
   �� 5      $
��235* �6   �� 5      $
��184* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ reportDataGrid��5      $
��Left=�6+   $	��229��6F   $��
210,50,0,0q�6S   $	��Top=�6g   $	��370��6   $��2��6�   $��1��6�   �� 5   
   -   5         ��Name$  plantsByCreationDateButton��5      $��Generate Report��65   $
��Left=�6x   $��
42,100,0,0q�6�   $	��Top=�6�   $	��116��6�   $��42��6�   $��2��6�   �� 5   
   -   5        $  numberOfPlantsByUserButton��5      $��Generate Report��65   $
��Left=�6x   $��
42,211,0,0q�6�   $	��Top=�6�   $	��116��6�   $��42��6�   $��2��6�   $��2��6�   �� 5   
   -   5        $ exportCSVButton��5   &   $��
Export CSV��6   $
��Left=�6]   $��
465,59,0,0q�6x   $��1��6�   $	��Top=�6�   $	��115��6�   $��47��6�   $��1��6�   �� 5   
   -   5        $ closeButton��5   <   $��Close��6   $
��Left=�6!   $��209.943,59,0,0q�6k   $��1��6�   $	��Top=�6�   $	��115��6�   $��47��6�   $��1��6�   �� 5   
   $"��List Plants by Creation Date��6   $
��Left=�67   $��	12,67,0,0q�6R   $	��Top=�6e   $��28��6}   $	��186��6�   
�������$��14(�6�   $��2��6�   �� 5   
   $&�� Number of Plants Created by User��6   $
��Left=�6;   $��
12,169,0,0q�6V   $	��Top=�6j   
�������$��28��6�   $	��234��6�   $��14(�6�   $��2��6�   5      5      