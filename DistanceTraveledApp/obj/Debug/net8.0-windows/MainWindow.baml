   M S B A M L   `   `   `  ����N  JDistanceTraveledApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DistanceTraveledAppDistanceTraveledApp  5   	   $    DistanceTraveledApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DistanceTraveledApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   � $��
0,-10,0,10q�6    � RowDefinitions 5      �� 5      $	��45* �6    �� 5      $
��119* �6    �� 5      $	��53* �6     � ColumnDefinitions 5      �� 5      $
��443* �6#   �� 5      $
��357* �6#   .+�5      �� -   5         ��Name$ 
speedLabel��5      $��Speed :��6(   $
��Left=�6:   $��24��6U   $��	51,34,0,0q�6a   $��1��6t   $	��Top=�6�   $��87��6�   �� 5      -   5        $ 	timeLabel��5      $��Time :��6'   $
��Left=�68   $��24��6S   $��	51,76,0,0q�6_   $��1��6r   $	��Top=�6   $��87��6�   �� 5      -   5         ��Name$ txtSpeed��5      $
��Left=�6(   $��24��6C   $��
143,34,0,0q�6O   $��1��6c    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��148��6�   �� 5      -   5        $ txtTime��5      $
��Left=�6'   $��24��6B   $��
143,76,0,0q�6N   $��1��6b   $
 Wrap=�6o   $	��Top=�6�   $	��148��6�   �� 5      -   5         ��Name$ calculateButton��5      $��Calculate Distance ��6.   $
��Left=�6L   $��32��6g   $��143,127,0,0q�6s   $��1��6�   $	��Top=�6�   $	��128��6�   6�   �� 5      -   5         ��Name$ 
resultText��5      $��1��6,   $
��Left=�6<   $	��178��6W   $��	27,22,0,0q�6d   $��1��6w   $
��Wrap=�6�   $	��Top=�6�   $	��272��6�   $��16(�6�   $
��Bold"�6�   5      5      5      