   M S B A M L   `   `   `  ����@  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  5      A%clr-namespace:Kouzi.Scripts.ViewModelKouzi.Scripts.ViewModel  5      ?$clr-namespace:Kouzi.Scripts.ControlsKouzi.Scripts.Controls  5
      !    Kouzi.Scripts.View.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Kouzi     5      4vm%clr-namespace:Kouzi.Scripts.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      0cntrl$clr-namespace:Kouzi.Scripts.Controls  5
        N� Title$  MainPage��5         	Kouzi.App   
MainPageVM � DataContext# Z 6    � 	Resources 5      "  Kouzi.EquipmentInfoConverter   equipConverter��%   &	          5   
   6'   5      .��5      � -   5        $��MainGrid��5      .+�5   
   �� -   5        $
��List��5      
�������$��20(�5   &   $��Courier New)�5      $��5q�6,     ListViewItemStyle#��[ 67   $��Stretch=�5      $��Stretch=�6D     ListViewStyle#��[ 5      ��5   4   �� *Buyers+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      �� .+�5      ]� $
��0 10q�6$   .+�5      �� $��Center=�6d   $
��Left=�6   ��6(   �� *Index+$ PropertyChanged=�6   �� 5#      $
��Auto��5$   $   $	��100��61   
����������#1b1c1b$
��10 0q�5%   $   $
��Left=�62   ��5#   (   ��  �� RelativeSource ��  �� AncestorType" � �� Path$ DataContext.BuyersNames�$ PropertyChanged=� �� SelectedValue 5%   H   �� *Name+$ PropertyChanged=�	 � ContextMenu	 5&   "   �� 5'   &     MaterialDesignMenu#��[ 62   ���#2b2c2b
�������$��17(�5)   .   $��Courier New)�6<   # Z 6U   .@�5*   *   m� $��Добавить имя��63   $��Center=�6I   .  (System.Windows.Interactivity.Interaction
   Triggers
 5+   .   /  )System.Windows.Interactivity.EventTrigger  5,   2      	EventName$ Click��6A   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-   6   6  0System.Windows.Interactivity.InvokeCommandAction     CommandParameter$' !Scripts/View/AddingBuyerPage.xaml��5.   H      Command 5-   L   �� *AddingBuyerPageCommand+5.   H   5/   3   51   +   m� 52   *   $��Удалить имя��63   $��Center=�6H   
 53   .     54   2   $ Click��6A   . 55   6      6L   �� *RemoveBuyerNameCommand+ 56   K   �� $ PlacementTarget.Text� ��  �� Mode$ FindAncestor=�$ ContextMenuL�57   3   59   +   5:   '   5<      (  "System.Windows.Controls.DatePicker  5@         SelectedDateFormat$ Short=�6)   $
��20 0q�6D   $��20(�6S   
�������
�������
������ $��Center=�5D   %     DatePickerStyle#��[ 5E   %   $
��Left=�6N      Text 5F   %   �� *Date+$ PropertyChanged=� �� Mode$ TwoWay=��� 5K      $��Right=�6%   $��Right=�6A   $��40��6X     MaximizeButtonStyle#��[ 5L   !   
���  �� � ToolTip$) #Удалить покупателя��5M   2   ��5L   N   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�   Size$ 23X�
 5N   "     5O   &   $ Click��65   . 5P   *      6@   ��  �� " �$$ DataContext.RemoveBuyerCommand�$ PropertyChanged=� 5Q   @   �� *Index+5R   '   5T      5W      �� 5Z      $��EquipmentListView��5\   #   
����������#1b1c1b#��[ 6<   ��5]   #   �� *EquipmentList+$ PropertyChanged=�
 5^        5_   "   $ SizeChanged��61   . 5`   &      6<   ��  �� " �$$ DataContext.SizeChangedCommand� 5a   8   ��  �� ElementName$ EquipmentListView��$ ActualWidth�5b   #   	 5d      �� 5e   "   #��[ 6.   ���#2b2c2b
�������.@�5f   &   m� $/��)Добавить оборудование��6/   $��Center=�6N   
 5g   *     5h   .   $ Click��6=   . 5i   2      6H   �� *AddEquipmentCommand+5j   /   5l   '   m� 5m   &   $-��'Удалить оборудование��6/   $��Center=�6M   
 5n   *     5o   .   $ Click��6=   . 5p   2      6H   �� *RemoveEquipmentCommand+ 5q   H   �� $# PlacementTarget.SelectedValue� �� $ FindAncestor=�$ ContextMenuL�5r   /   5t   '   5u   #    �� View 5w      �� 5x   "   .P�5y   &   �� $��Название��65    �� Width 6H   ��  �� " �$ DataContext.ColumnWidth� �� CellTemplate 5z   *   �� 5{   .   .R�5|   2   �� .+�5}   6   �� $��block��6W   $y�	Collapsed=�6@   # Z 6d   �� 5~   6   $��EquipmentInfoBox��5�   ;   $
��Auto��5   ;   $��50��6H   
�������$��Center=�5�   ;   ���#1b1c1b��5~   ?   �� $ block��$  DataContext.EquipmentsInfo�$ PropertyChanged=� �� SelectedIndex 5�   =   �� *Index+$ PropertyChanged=�	 5�   :   �� 5�   >   #��[ 6J   ���#2b2c2b
�������# Z 5�   F   .@�5�   B   m� $+��%Добавить информацию��6K   
 5�   F     5�   J   $ Click��6Y   . 5�   N     $+ %Scripts/View/AddingEquipmentPage.xaml��5�   `    5�   d   �� *AddEquipmentInfoCommand+5�   `   5�   K   5�   C   m� 5�   B   $)��#Удалить информацию��6K   
 5�   F     5�   J   $ Click��6Y   . 5�   N      6d   �� *RemoveEquipmentInfoCommand+ 5�   `   �� $# PlacementTarget.SelectedValue� �� $ FindAncestor=�$ ContextMenuL�5�   K   5�   C   5�   ?   
 5�   :     5�   >   $ SelectionChanged��6M   . 5�   B      6X   �� $ block��$, &DataContext.SelectEquipmentInfoCommand� 5�   F   `� 5�   J    `� 	Converter# [  6W   .1�5�   N   �� $ EquipmentInfoBox��6V   $ SelectedValue�6u   �� 5�   N   $ EquipmentListView��6V   $ SelectedIndex�6v   $ PropertyChanged=�6�   �� 5�   N   $
 List��6V   $ SelectedIndex�6i   5�   K   5�   C   5�   ?   5�   7   5�   3   5�   /   5�   '   �� 5�   &   $��Количество��65    6I   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� -   5        
�������$
��Auto��5�   N   $��Center=�6[   ��5�   :   �� *Count+$ PropertyChanged=�.��5�   x   5�   3   5�   /   5�   '   �� 5�   &   $��Стоимость��65    6H   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�5�   <   $��Center=�5�   (   ��5�   <   �� *Cost+$ PropertyChanged=�5�   (   5�   /   5�   '   �� 5�   &   $��
Сумма��65    6D   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6x   $��Center=�5�   (   ��5�   <   �� *Sum+$ PropertyChanged=�5�   (   5�   /   5�   '   �� 5�   &   $��Стоимость(м)��65    6K   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6|   $��Center=�5�   (   ��5�   =   �� *MyCost+$ PropertyChanged=�5�   (   5�   /   5�   '   �� 5�   &   $��Сумма(м)��65    6G   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6z   $��Center=�5�   (   ��5�   <   �� *MySum+$ PropertyChanged=�5�   (   5�   /   5�   '   �� 5�   &   $��Разность��65    6G   ��  �� " �$ DataContext.ColumnWidth� 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6y   $��Center=�6�   ��6<   �� *Diff+$ PropertyChanged=�6�   5�   /   5�   '   5�   #   5�      �� 5�       �� Orientation$ Vertical=�6&   $��Right=�6=   .+�5�      �� ���#32CD32��6(   �� *	Benefit+$ PropertyChanged=�6f   �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� -   5        
�������$
��Auto��5�   7   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Кредит��6D   ��5�   (   �� *Credit+$ PropertyChanged=��� 5�   "   -   5        $
��10 0q�5�   K   
�������$
��Auto��5�   7   $ 
Дебет��6D   ��5�   &   �� *Debit+$ PropertyChanged=�5�      5�      �� 5�      $
��0 15q�6$   5�      5�      5�      5�      5�      