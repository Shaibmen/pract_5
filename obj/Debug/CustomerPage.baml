   M S B A M L   `   `   `  ����F  BControlLaba, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ControlLabaControlLaba  5          ControlLaba.CustomerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ControlLaba     5        N� Title$  CustomerPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CustomerGrid��5      $��1��6)   $��6��66   $��3��6G      
IsReadOnly .  �� SelectedIndex$ 0��6m      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	FirstName��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 68   �� *	FirstName+  5      $ LastName��6%   	 67   �� *
LastName+  5      $ Email��6%   	 64   �� *Email+  5       $ Phone��6%   	 64   �� *Phone+  5!      $ RoleName��6%   	 67   �� *Roles.RoleName+5#      �� 5$   
   $��1��6   $��3��6    $��15(�60   
 �� TextAlignment$
 Center=�6>   $.��(Данные для заполнения��6U   {�.  $��Bottom=�6�   �� 5%   
   $��4��6   $��3��6"   $��Center=�62   .+�5&      �� -   5         ��Name$
 Name��5&      $��Имя��6$    �� 	MaxLength$ 50��6/   6>   �� 5'      -   5        $ 
SecondName��5'      $��Фамилия��6*   $ 50��69   6H   �� 5(      -   5        $ EmailBox��5(      $��
Почта��6(   $	 100��65   6E   �� 5)      -   5        $ 	NumberBox��5)      $��Телефон��6)   $ 11��68   6G   5*      �� 5+   
   $��5��6   $��3��6"   $��Center=�62   .+�5,      �� -   5         ��Name$ RoleBox��5,      6(   5-      �� 5.   
   $��6��6   $��3��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Bottom=�6h   .+�5/      �� -   5        $��Добавить��5/      6(   �� 50      -   5        $��Изменить��50      6(   �� 51      -	   5        $��Удалить��51      6'   52      53      54      