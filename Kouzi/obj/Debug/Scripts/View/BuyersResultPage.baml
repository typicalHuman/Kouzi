   M S B A M L   `   `   `  ����@  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  5      )    #Kouzi.Scripts.View.ResultBuyersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Kouzi     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  ResultBuyersPage��5
       N� 
Foreground
 ����� N� FontSize$ 20(�63    N� 
FontFamily$ Courier New)�5         	Kouzi.App   BuyersResultPageVM � DataContext# Z 6    .��5      � .+�5   
   �� # Z 6   ��5      �� *
BuyersList+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      �� .+�5      �� $��25(�5      $��5q�6*   ��5   $   ��  �� StringFormat$ Имя: {0}�� �� Path$
 Name�5   *   R� 5      .@�5      Q� $��TreeEquipment��5   +   $��Оборудование:��5   +   $��25(�6B   
�������.@�5   "   �� $��EquipmentListView��5   #   
�������$��Stretch=�5   #   $��Stretch=�6A      ListViewStyle#��[  5   <   ��5   #   �� *EquipmentList+$ PropertyChanged=�	 �� View	 5   &   �� 5   *   .P�5   .   �� $��Название��6=   
 �� Width
 6P   ��  �� RelativeSource ��  �� AncestorType" �$ DataContext.ColumnWidth� �� CellTemplate 5   2   �� 5    6   .R�5!   :   �� $
��Auto��5"   ;   $��50��6H   $��Center=�5#   ;   ��5!   D   �� *Name+$ PropertyChanged=�5$   ;   5%   7   5'   /   �� 5(   .   $��Количество��6=   
 6Q   ��  �� " �$ DataContext.ColumnWidth� 5)   2   �� 5*   6   .R�5+   :   �� $
��Auto��5,   :   $��Center=�6G   ��5+   D   �� *Count+$ PropertyChanged=�5-   ;   5.   7   50   /   �� 51   .   $��Стоимость��6=   
 6P   ��  �� " �$ DataContext.ColumnWidth� 52   2   �� 53   6   .R�54   :   �� $��Center=�55   <   $��Center=�56   (   ��54   D   �� *Cost+$ PropertyChanged=�56   (   57   7   59   /   �� 5:   .   $��
Сумма��6=   
 6L   ��  �� " �$ DataContext.ColumnWidth� 5;   2   �� 5<   6   .R�5=   :   �� $��Center=�6�   $��Center=�5>   (   ��5=   D   �� *Sum+$ PropertyChanged=�5>   (   5?   7   5A   /   �� 5B   .   $��Стоимость(м)��6=   
 6S   ��  �� " �$ DataContext.ColumnWidth� 5C   2   �� 5D   6   .R�5E   :   �� $��Center=�6�   $��Center=�5F   (   ��5E   E   �� *MyCost+$ PropertyChanged=�5F   (   5G   7   5I   /   �� 5J   .   $��Сумма(м)��6=   
 6O   ��  �� " �$ DataContext.ColumnWidth� 5K   2   �� 5L   6   .R�5M   :   �� $��Center=�6�   $��Center=�5N   (   ��5M   D   �� *MySum+$ PropertyChanged=�5N   (   5O   7   5Q   /   �� 5R   .   $��Разность��6=   
 6O   ��  �� " �$ DataContext.ColumnWidth� 5S   2   �� 5T   6   .R�5U   :   �� $��Center=�6�   $��Center=�6�   ��6D   �� *Diff+$ PropertyChanged=�6�   5V   7   5X   /   5Y   +   5[   #   5]      5^      5_      5`      5c      5d      5e      