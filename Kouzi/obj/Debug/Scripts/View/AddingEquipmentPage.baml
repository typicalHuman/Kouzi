   M S B A M L   `   `   `  ����@  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  5      ?$clr-namespace:Kouzi.Scripts.ControlsKouzi.Scripts.Controls  5      ,    &Kouzi.Scripts.View.AddingEquipmentPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Kouzi     5      6cntrl$clr-namespace:Kouzi.Scripts.Controls     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	        N� 
Foreground
  ����� N� 
FontFamily$ Courier New)�5
   +    N� Title$ AddingEquipmentPage��5       N� FontSize$ 20(�6#      	Kouzi.App   AddingEquipmentPageVM � DataContext# Z 5      .��5      � .+�5   
   �� .+�5      '   !Kouzi.Scripts.Controls.BackButton  �� 5      $��Название��6   $��5q�6(   $��30(�63   �� 5      $
��Auto��6   $	��200��6#   $
��Left=�62   
�������$��5q�6a   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�.��6P   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ TextChanged��6%   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 60   �� *TextChanged+5      .��5   *   5      �� 5       $��Стоимость��6   $��5q�6)   $��30(�64   �� 5!      -   5        $
��Auto��5!      $	��100��6#   $
��Left=�62   $��5q�6M   
���������5#      �� *Cost+$ PropertyChanged=�.��6Q    5$        5%      $ TextChanged��6%   .	 5&        
 60   �� *TextChanged+5'      .��5(   *   5)      �� 5-      $��Моя Стоимость��6   $��5q�6-   $��30(�68   �� 5.      -   5        $
��Auto��5.      $	��100��6#   $
��Left=�62   
�������$��5q�6a   ��50      �� *MyCost+$ PropertyChanged=�.��6T    51        52      $ TextChanged��6%   .	 53        
 60   �� *TextChanged+54      .��55   *   56      �� 5:       �� Orientation$ 
Horizontal=�6   $
��5 10q�62   y�6@   �� *ErrorVisibility+$ PropertyChanged=�.+�5;      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Error=�6*   
���  ��67   �� 5<      $��15(�6   
���  ��$	��5 0q�6;   $?��9Все поля должны быть заполнены!��5=      5>      5B      �� 5E   
   $��Bottom=�6   $��Center=�6,   $	��100��6I   $��40��5F      $
��0 10q�6      MaximizeButtonStyle#��[  6+   ���#32CD32 � ToolTip$ Готово��5H   &   ��5G      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Done=�   Size$ 25X� 5I        5J      $ Click��6!   .	 5K        
 6,   �� *AddEquipmentCommand+5L      5N      5Q      5R      