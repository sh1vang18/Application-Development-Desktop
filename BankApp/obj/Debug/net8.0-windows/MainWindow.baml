   M S B A M L   `   `   `  ����B  >BankApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BankAppBankApp  5   	       BankApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:BankApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �  � ColumnDefinitions 5      �� 5      $	��43* �6#   �� 5      $	��37* �6#    � RowDefinitions 5      �� 5      $
��120* �6    �� 5      $
��205* �6    �� 5      $
��109* �6    .+�5      �� -   5         ��Name$ 
txtBalance��5      $
��Left=�6*   $��24��6E   $��
148,10,0,0q�6Q   $��1��6e    �� TextWrapping$
 Wrap=�6r   $	��Top=�6�   $	��112��6�   �� 5      -   5        $ 	txtChecks��5      $
��Left=�6)   $��24��6D   $��
148,39,0,0q�6P   $��1��6d   $
 Wrap=�6q   $	��Top=�6�   $	��112��6�   �� 5      -   5         ��Name$ accBalLabel��5      $��Account Balance :��6)   $
��Left=�6E   $��24��6`   $��	10,10,0,0q�6l   $��1��6   $	��Top=�6�   $	��117��6�   �� 5      -   5        $ 
checkLabel��5      $��Total Check(s) :��6(   $
��Left=�6C   $��24��6^   $��	35,39,0,0q�6j   $��1��6}   $	��Top=�6�   $��92��6�   �� 5      -   5         ��Name$ 	txtResult��5      $��1��6+   $
��Left=�6;   $	��155��6V   $��	23,10,0,0q�6c   $��1��6v   $
��Wrap=�6�   $	��Top=�6�   $	��296��6�   $��16(�6�   $
��Bold"�6�   �� 5      -   5         ��Name$ calculateButton��5      $��	Calculate��6.   $
��Left=�6B   $��24��6]   $��
148,86,0,0q�6i   $��1��6}   $	��Top=�6�   $��87��6�    J� RenderTransformOrigin$ 0.416,-1.849&�6�   5      5      5      