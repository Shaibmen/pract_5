   M S B A M L   `   `   `  ����F  BControlLaba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ControlLabaControlLaba  5          ControlLaba.WarehousePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ControlLaba     5        N� Title$  WarehousePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ WarehouseGrid��5      $��1��6*   $��6��67   $��3��6H      
IsReadOnly .  �� SelectedIndex$ 0��6n      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ WarehouseName��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *WarehouseName+  5      $ Location��6%   	 67   �� *
Location+  5      $ FarmName��6%   	 67   �� *Farm.FarmName+5!      �� 5"   
   $��1��6   $��3��6    $��15(�60   
 �� TextAlignment$
 Center=�6>   $.��(Данные для заполнения��6U   {�.  $��Bottom=�6�   �� 5#   
   $��4��6   $��3��6"   $��Center=�62   .+�5$      �� -   5         ��Name$ WarenameBox��5$      $��Название��6+   6;   �� 5%      -   5        $ 
AddressBox��5%      $��Адресс��6*   68   �� 5&      -   5         ��Name$ FarmBox��5&      6(   5'      �� 5(   
   $��6��6   $��3��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Bottom=�6h   .+�5)      �� -   5        $��Добавить��5)      6(   �� 5*      -   5        $��Изменить��5*      6(   �� 5+      -   5        $��Удалить��5+      6'   5,      5-      5.      