   M S B A M L   `   `   `  ���� @  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  (    "Kouzi.Scripts.View.AddingBuyerPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     %localclr-namespace:Kouzi     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� 
Foreground
  ����� N� FontSize$ 20(� N� 
FontFamily$ Courier New)� N� Title$ AddingBuyerPage��   	Kouzi.App   AddingBuyerPageVM � DataContext# Z .��� .+��� .+���    MaximizeButtonStyle#��[  $
��Left=�$��50��$��40�� � ToolTip$ 
Назад��$��5q���0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	ArrowBack=�   Size$ 25X��� $��Имя��$��5q�$��30(��� $
��Auto��$	��200��$
��Left=�
�������$��5q����� *	BuyerName+	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��Bottom=�$��Center=�$	��100��$��40��$
��0 10q�#��[  ���#32CD32$ Готово����  $
 Done=�$ 25X�.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *AddBuyerCommand+