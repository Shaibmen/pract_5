   M S B A M L   `   `   `  ����F  BControlLaba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ControlLabaControlLaba  5   	       ControlLaba.SkladWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ControlLaba     5   	     � Title$  SkladWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
FarmButton��5      $��0��6%   $��
Ферма��65   6E   �� 5   
   -   5        $ ExpensesButton��5      $��1��6)   $��Расходы��69   6K   �� 5   
   -   5        $ AnimalsButton��5      $��2��6(   $��Животные��68   6K   �� 5   
   -   5        $ WarehouseButton��5      $��3��6*   $��
Склад��6:   6J   �� 5   
   -   5        $ InventoryButton��5      $��1��6*   $"��Инвентаризация��67   6P   �� 5   
   -   5        $ ProductsButton��5      $��2��6)   $��0��66   $��
Товар��6F   6V   �� 5   
   -   5        $ SuppliesButton��5      $��1��6)   $��1��66   $��Поставки��6F   6Y   �� 5    
   -   5        $ CustomerButton��5       $��1��6)   $��2��66   $��Клиент��6F   6W   �� 5!   
   -	   5        $ OrdersButton��5!      $��1��6'   $��4��64   $��Заказы��6D   6U   �� 5"   
   -
   5        $ FeedBackButton��5"      $��2��6)   $��1��66   $��Отзывы��6F   6W    � 5$   
   -   5          �Name$ 	PageFrame��5$      $��3��6#   $��5��60   $��0��6A   $��4��6Q     � NavigationUIVisibility$ Hidden=�6e   6�   5%      5&      