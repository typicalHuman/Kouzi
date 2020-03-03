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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Globalization;
using GalaSoft.MvvmLight.Messaging;
using Kouzi.Scripts.ViewModel;
using Kouzi.Scripts.Other;

namespace Kouzi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
            InitializeComponent();
            App.MainVM.CloseAction = this.Close;
            NavigationSetup();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


            App.MainPageVM.TestBuyers();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                MyFrame.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }

    }
}
