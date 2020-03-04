using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kouzi.Scripts.Controls
{
    /// <summary>
    /// Логика взаимодействия для SaveNotificationWindow.xaml
    /// </summary>
    public partial class SaveNotificationWindow : Window
    {
        public SaveNotificationWindow()
        {
            InitializeComponent();
            App.SaveNotificationWindowVM.CloseAction = Close;
        }
    }
}
