   M S B A M L   `   `   `  ���� 
  WPFApp    WPFApp.MainCustomerWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  MainCustomerWindow��$
��1000��$	��450��.��� ���#1A1A2E � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�����#0F3460 �� Padding$ 10q�._��� $��Big 3 Shoes Store��$��24(�
�������$��Center=��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�$��10q�.+��� $��Brand:��
��������� -    ��Name$ cbBrand��$	��200��$	��5,0q�$��Center=����#16213E���#533483�� $��	Category:��$��Center=�$	��5,0q�
��������� -   $ 
cbCategory��$	��200��$	��5,0q�$��Center=����#16213E���#533483�� -    ��Name$ 	btnSearch��$��Search��$
��10,0q�$��70�����#533483
��������� -   $��lstShoes��$��2��$��188,10,10,10q�
����������#CCCCCC$��1q�$
��Auto=�$��Stretch=����� .R��� ���#CCCCCC$��1q�$��5q�$ 10q�._��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��18(�$��0������ *	ShoesName+�� $��1��$	��0,5q�.+��� $��Brand:��$
��Bold"��� ���� *Brand.BrandName+�� $��2��$	��0,5q�.+��� $��	Category:��$
��Bold"��� ���� *Category.CategoryName+�� $��3��$	��0,5q�.+��� $��Color:��$
��Bold"��� ���� *Color+�� $��4��$	��0,5q�.+��� $��Size:��$
��Bold"��� ���� *Size+ �� StringFormat$ {0:F2}���� $��5��$	��0,5q�.+��� $��Price:��$
��Bold"��� ���� *Price+$ ${0:F2}���� $��6��$	��0,5q�.+��� $��Stock Quantity:��$
��Bold"��� ���� *StockQuantity+����  �� 
TargetType" ��.���  �� Property � ��	 �� Value$	 0,0,0,10q��� $��3��$ 
Horizontal=�$��Center=�$��Center=�$��10q�.+��� $��Selected Shoe:��$
��10,0q�
��������� -   
 ��Name$
 txtSelectedShoes��$	��200��$	��5,0q�$��Center=�${�False�����#16213E
����������� *SelectedItem.ShoesName+ �� ElementName$ lstShoes���� $��	Quantity:��$��Center=�$��20,0,5,0q�
��������� -   $
 txtQuantity��$��40��$	��5,0q�$��1��$��Center=����#16213E
��������� -   $��btnAddToCart��$��Add to Cart��$
��10,0q����#533483
��������� -   $��btnViewCart��$��	View Cart��$
��10,0q����#533483
��������� -	   $��btnCheckout��$��Checkout��$
��10,0q����#533483
��������� -
   $
 txtSelectedShoeId��$��3��$y�Hidden=����� *SelectedItem.ShoesId+$ lstShoes���� $
��Home��
�������$
��Left=�$��	25,33,0,0q�$��2��$	��Top=�$	��148�����#533483�� -   $��Profile�����#533483$
��Left=�$��	25,69,0,0q�$��2��$	��Top=�$	��148��
��������� -   $��btnViewHistory��$��View Order History�����#533483$
��Left=�$��
25,109,0,0q�$��2��$	��Top=�$	��148��
��������� -   $��	btnLogout��$��Logout�����#533483$
��Left=�$��62,8,0,0q�$��3��$	��Top=�$��74��
�������