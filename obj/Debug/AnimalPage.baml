   M S B A M L   `   `   `  ����F  BControlLaba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ControlLabaControlLaba  5          ControlLaba.AnimalPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ControlLaba     5        N� Title$  
AnimalPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
AnimalGrid��5      $��1��6'   $��6��64   $��3��6E      
IsReadOnly .  �� SelectedIndex$ 0��6k      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Species��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *	Species+  5      $	 Age��6%   	 62   �� *Age+  5      $ FarmName��6%   	 67   �� *Farm.FarmName+5!      �� 5"   
   $��1��6   $��3��6    $��15(�60   
 �� TextAlignment$
 Center=�6>   $.��(Данные для заполнения��6U   {�.  $��Bottom=�6�   �� 5#   
   $��4��6   $��3��6"   $��Center=�62   .+�5$      �� -   5         ��Name$ 
TypeAnimal��5$      $��Тип животного��6*    �� 	MaxLength$ 50��6?   6N   �� 5%      -   5        $ AgeBox��5%      $��Возраст��6&   $ 2��65   6C   �� 5&      -   5         ��Name$ FarmBox��5&      5'      �� 5(   
   $��6��6   $��3��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Bottom=�6h   .+�5)      �� -   5        $��Добавить��5)      6(   �� 5*      -   5        $��Изменить��5*      6(   �� 5+      -   5        $��Удалить��5+      6'   5,      5-      5.      