   M S B A M L   `   `   `  ����  FarmersMarketApp"    FarmersMarketApp.AdminWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Admin��5   	   $	��450��6   $	��800��6$   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ txtProductId��5      $	��100��6,   $��0,0,10,0q�68    � ToolTip$ 
Product ID��6J   �� 5      -   5        $ txtProductName��5      $	��150��6.   $��0,0,10,0q�6:   $ Product Name��6L   �� 5      -   5        $ 	txtAmount��5      $	��100��6)   $��0,0,10,0q�65   $ Amount (kg)��6G   �� 5      -   5        $ txtPrice��5      $	��100��6(   $��0,0,10,0q�64   $ Price (CAD/kg)��6F   �� 5      -   5        $	��Add��5      $��75��6#   6.   �� 5      -   5        $��Update��5      $��75��6&   $��10,0,0,0q�61   6C   �� 5      -   5        $��Delete��5      $��75��6&   $��10,0,0,0q�61   6C   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgProducts��5      $��1��6'   $��10q�64      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Product ID��6%   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ProductID+6W     5      $	 Product Name��6%   
 .  6;   �� *ProductName+6[     5      $	 Amount (kg)��6%   
 .  6:   �� *Amount+6U     5      $	 Price (CAD/kg)��6%   
 .  6=   �� *
PricePerKg+6\   5      �� 5   
   -	   5        $��2��5      $��Refresh��6   $��75��60   $��10q�6;   6G   5      5      