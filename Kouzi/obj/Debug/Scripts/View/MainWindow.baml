   M S B A M L   `   `   `  ����@  <Kouzi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KouziKouzi  5   	   A%clr-namespace:Kouzi.Scripts.ViewModelKouzi.Scripts.ViewModel  5	   	       Kouzi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Kouzi     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   .vm%clr-namespace:Kouzi.Scripts.ViewModel  5	   	   9mahapp,http://metro.mahapps.com/winfx/xaml/controls  5
   	   -   5        $��MainWind��5   	     � WindowStyle$
  None=�5       � Title$ 
MainWindow��5   	   $	��550��6   $
��1050��6,   $	��500��5   	   $	��500��6    � WindowStartupLocation$ CenterScreen=�6"      	Kouzi.App   MainVM � DataContext# Z 5   	   
�������$��Courier New)�5      $��20(�5   	   
������� � 
ResizeMode 5   -   �� *
ResizeMode+��5   	   �� *WindowBorderThickness+ � WindowState 5   	   �� *WindowState+ � 	Resources 5         OpenMenu �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5        $
 0��6'   $ 51Q�63     5      $
 0:0:0.3��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5        $
 0��6'   $	 200Q�63     5       $
 0:0:0.3��6'   $ 51Q�69   5!      5"      5#       � Triggers 5$      :� 5%   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5&      �� #��[  6   5'      :� 5(   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5)      �� #��[ 6   5*      '  !System.Windows.Shell.WindowChrome   WindowChrome 5,        5-   
      CaptionHeight$ 0Q�5.   	      ResizeBorderThickness$ 7q�5/   	   .��51      � ���#1b1c1b � ColumnDefinitions 54   
   �� 55      $��51 �6   �� 56      �� 57      $��51 �6   �� 58      $��51 �6    �� 59      $��51 �6    � RowDefinitions 5<   
   �� 5=      $��40 �6   �� 5>      .+�5E   
   �� $��4��6   $��51��6!   $��40��6,   $��5q�69   $��0q�5F      
������  � ToolTip$ Закрыть��5G        CloseButtonStyle#��[ 5H      ��5G   #   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Close=�   Size$ 25X�.  (System.Windows.Interactivity.Interaction   Triggers 5I      /  )System.Windows.Interactivity.EventTrigger  5J         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5K      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *CloseCommand+5L      5N      �� 5S   
   $��2��6   $��40��6!   $��51��6-   $ Свернуть��5T        MaximizeButtonStyle#��[ 6$   ��5U        $ WindowMinimize=�$ 25X� 5V        5W      $ Click��6!   . 5X         5Y      �� *MinimizeCommand+5Z      5\      �� 5a   
   $��3��6   $��40��6!   $��51��6-   $ Развернуть��5b      #��[ 6&   ��5c        $ WindowMaximize=�$ 25X� 5d        5e      $ Click��6!   . 5f         5g      �� *MaximizeCommand+5h      5j      � 5q   
   -   5        $��GridMenu��5q      $��51��6   $
��Left=�6*   ���#282828$��0��5r      $��2��6   $��0��60   $��3��6=    K� ZIndex$ 3��6Q   .+�5s      �� .+�5t      � $��40��6   
�������z�5u      V� 5v      .~�5w      �� �� 5x      �� 5y      T� 5z      5{      .+�5~      �� -   5        $��ButtonOpenMenu��5~      $��40��63   $��51��6?   $��Center=�6J   $��Center=�5       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 68   
��������5�      Z� ��63   Z� y�5�      �� *OpenMenuVisibility+ 5�        5�      $ Click��6-   . 5�   "      68   �� *OpenSideCommand+5�      .��5�      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$
 Menu=�62   $��25��6>   $��25��6I   5�      �� 5�      -   5        $��ButtonCloseMenu��5�   4   $��40��6   $��51��6)   $��Center=�5�      $��Center=�6:   #��[ 5�      
��������5�      Z� ��63   Z� y�5�      �� *CloseMenuVisibility+ 5�        5�      $ Click��6-   . 5�   "      68   �� *CloseSideCommand+5�      .��5�      	  $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5�      5�      �� 5�      
������$��Disabled=�63   $��16(�5�       �� SelectedIndex 6)   �� *SelectedIndex+.@�5�      �� $��40��6#   .��5�      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      	  $ 
TableLarge=�66   $��25��6H   $��25��6T   $��Center=�6_   $��Center=�6|   $	��5 0q�5�   6   �� 5�      $��Общая таблица��6(   $��Center=�6=   $
��10 0q�6X   5�       5�        5�      $ Selected��6-   . 5�   "        CommandParameter$  Scripts/View/MainPage.xaml��5�   8    5�   8   �� *NavigateCommand+5�   8   5�      5�      �� 5�      $��40��6#   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ Radiator=�66   $��25��6G   $��25��6S   $��Center=�6^   $��Center=�6{   $	��5 0q�5�   6   �� 5�      $��Оборудование��6(   $��Center=�6<   $
��10 0q�6W   5�       5�        5�      $ Selected��6-   . 5�   "     $, &Scripts/View/EquipmentsResultPage.xaml��5�   8    5�   8   �� *NavigateCommand+5�   8   5�      5�      �� 5�      $��40��6#   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ People=�66   $��25��6D   $��25��6P   $��Center=�6[   $��Center=�6x   $	��5 0q�5�   6   �� 5�      $��Покупатели��6(   $��Center=�6:   $
��10 0q�6U   5�       5�        5�      $ Selected��6-   . 5�   "     $( "Scripts/View/BuyersResultPage.xaml��5�   8    5�   8   �� *NavigateCommand+5�   8   5�      5�      �� 5�      $��40��6#       FileVM# Z  6/   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ FileDocumentBoxPlus=�66   $��25��6Q   $��25��6]   $��Center=�6h   $��Center=�6�   $	��5 0q�5�   6   �� 5�      $��Создать��6(   $��Center=�67   $
��10 0q�6R   5�       5�        5�      $ PreviewMouseDown��6-   . 5�   "      68   �� *	CreateNew+5�      5�      �� 5�      $��40��6#   # Z  6/   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ ContentSave=�66   $��25��6I   $��25��6U   $��Center=�6`   $��Center=�6}   $	��5 0q�5�   6   �� 5�      $��Сохранить��6(   $��Center=�69   $
��10 0q�6T   5�       5�        5�      $ PreviewMouseDown��6-   . 5�   "      68   �� *SaveCommand+5�      5�      �� 5�      $��40��6#   # Z  6/   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ ContentSaveMove=�66   $��25��6M   $��25��6Y   $��Center=�6d   $��Center=�6�   $	��5 0q�5�   6   �� 5�      $��Сохранить как��6(   $��Center=�6=   $
��10 0q�6X   5�       5�        5�      $ PreviewMouseDown��6-   . 5�   "      68   �� *SaveAsCommand+5�      5�      �� 5�      $��40��6#   # Z  6/   .��5�      �� $ 
Horizontal=�6%   .+�5�      	  $ 
FolderOpen=�66   $��25��6H   $��25��6T   $��Center=�6_   $��Center=�6|   $	��5 0q�5�   6   �� 5�      $��Открыть��6(   $��Center=�67   $
��10 0q�6R   5�       5�        5�      $ PreviewMouseDown��6-   . 5�   "      68   �� *OpenCommand+5�      5�      5�      5�      5�      �� 5�      $��
Коузи��6   $��25(�6&   $
��Bold"�64   $��1��6F   $
��10 0q�5�      $��Center=�6"   �� 5�   
   $��Center=�6   $��5��64   $��1��6H   !   
MainPageVM# Z! 6X   $ 
Horizontal=�5�   f   y�6   �� *AddButtonVisibility+" �� UpdateSourceTrigger$" PropertyChanged=�.+�5      �� $��40��6   $	��150��6!   ���#32CD32
�������$+ %Добавить покупателя��5  (   #��[ 5     ��5   B     $	 Add=�$ 30X� 5       5     $ Click��6%   . 5        60   �� *AddBuyerCommand+5     5	     �� 5     $��40��6   $	��150��6!   
��� � �
�������$E ?Добавить покупателя с документами��5  (   #��[ 5     ��5  @     $ BriefcaseAdd=�$ 30X� 5       5     $ Click��6%   . 5        60   �� *AddBuyerCommand+5     5     5      � 5   
   -   5        $��MyFrame��5      $��1��6   $��1��6,   #  � Source$# MainPage.xaml?�6<   $��4��5!     $  � NavigationUIVisibility$$ Hidden=�6#   5%     5&     