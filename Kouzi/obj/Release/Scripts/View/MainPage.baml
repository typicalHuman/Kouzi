   M S B A M L   `   `   `  ���� @  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  !    Kouzi.Scripts.View.MainPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     %localclr-namespace:Kouzi     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  MainPage��   	Kouzi.App   
MainPageVM � DataContext# Z .��� .+��� -   $
��List��
�������$��20(�$��Courier New)�$��5q�   ListViewItemStyle#��[  $��Stretch=�$��Stretch=�.@��� -   $
��Item��.���� .+�]� $
��0 10q�.+��� $��1.��$��Center=�$
��Left=��� $
��Auto��$	��100��
����������#1b1c1b$
��10 0q�$
��Left=�.@��� .��Fafs � ContextMenu ��   MaterialDesignMenu#��[ ���#2b2c2b
�������$��17(�$��Courier New)�.@�m� $��Добавить��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     CommandParameter$' !Scripts/View/AddingBuyerPage.xaml��   Command �� *AddingBuyerCommand+(  "System.Windows.Controls.DatePicker  	   SelectedDateFormat$	 Short=�$
��20 0q�$��20(�
�������
����������#1b1c1b$��Center=�  DatePickerStyle#��[ $
��Left=��� $��Right=�$��Right=�$��40��  MaximizeButtonStyle#��[ 
���  ��
 � ToolTip$)
 #Удалить покупателя����0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�   Size$ 23X��� -   $��EquipmentListView��
����������#1b1c1b  ListViewStyle#��[ ���� *Buyers+ �� UpdateSourceTrigger$ PropertyChanged=�   $ SizeChanged��.    �� *SizeChangedCommand+ ��  �� ElementName$ EquipmentListView�� �� Path$ ActualWidth� �� View �� .P��� $��Название�� �� Width �� *ColumnWidth+$ PropertyChanged=� �� CellTemplate �� .R��� $
��Auto��$��50��
�������
������ $��Center=��� $��Количество�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� -   
�������$��Center=�$��Center=��� $��Стоимость�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� $��5��$��Center=�$��Center=��� $��
Сумма�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� $��5��$��Center=�$��Center=��� $��Стоимость(м)�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� $��5��$��Center=�$��Center=��� $��Сумма(м)�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� $��5��$��Center=�$��Center=��� $��Разность�� �� *ColumnWidth+$ PropertyChanged=� �� .R��� $��5��$��Center=�$��Center=��� $
��0 15q�