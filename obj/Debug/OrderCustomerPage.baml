   M S B A M L   `   `   `  ����F  BControlLaba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ControlLabaControlLaba  5      #    ControlLaba.OrderCustomerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ControlLaba     5        N� Title$  OrderCustomerPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	StoreGrid��5      $��1��6&   $��3��63   $��2��6D      
IsReadOnly .  �� SelectedIndex$ 0��6j      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ProductName��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6:   �� *Products.ProductName+  5      $ Quantity��6%   	 67   �� *
Quantity+  5       $ CostProduct��6%   	 6:   �� *Products.CostProduct+5"        5#   
   -   5        $ 	CheckGrid��5#      $��1��6&   $��3��63   $��3��6D   $��4��6T    . $ 0��6z    .  5$      5'      �� 5(   
   -   5        $��Добавить��5(      $��2��69   $��2��6F   �� 5)   
   -   5        $��Удалить��5)      $��3��68   $��2��6E   �� 5*   
   -   5        
 ��Name$
 Oplata��5*      $��Оплата��6"   $��5��61   $��0��6>   6N   �� 5+   
   -   5        $
 NyznoOplata��5+      $��К оплате:��6'   $��5��69   $��3��6F   {�.  6w   �� 5,   
   -   5        $��Выгрузка чека��5,      $��6��6=   $��0��6J   $��5��6Z   5-      5.      