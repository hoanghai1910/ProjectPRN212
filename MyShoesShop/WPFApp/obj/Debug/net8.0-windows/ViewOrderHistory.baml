   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.ViewOrderHistory   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  ViewOrderHistory��5   	   $	��450��6"   $	��800��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   .+�5      �� $��Order Date:��6   $��Center=�6*   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpOrderDate��5      $	��200��6,   $��5q�68   �� 5      -   5        $��	btnSearch��5   U   $��Search��6   $	��100��6&   $��5q�6J   6U   �� 5      -   5        $��btnClear��5   S   $��Clear��6   $	��100��6%   $��5q�6H   6S   �� 5      -   5        $��	btnGoBack��5   V   $��Go back��6   $	��100��6'   $��5q�6K   6V   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgOrderHistory��5      $��1��6)      AutoGenerateColumns$ False��66      CanUserAddRows$ False��6R   $��10q�6i      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S      
IsReadOnly$
 True��6]   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *	OrderId+6]     5      $ 
Order Date��6%   $ * 6v   $
 True��6�   	 69   �� *	OrderDate+
 �� StringFormat$
 {0:MM/dd/yyyy}��6�     5      $ Total Amount��6%   $ * 6q   $
 True��6{   	 6;   �� *TotalAmount+$
 {0:C}��6{   5      5       5!      