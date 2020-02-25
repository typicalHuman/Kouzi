using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class NavigateVM: ViewModelBase
    {
        public NavigateVM()
        {

        }

        public string Title { get; set; }
        public void Navigate(string url)
        {
            if (url.Contains("Main"))
                App.MainPageVM.AddButtonVisibility = System.Windows.Visibility.Visible;
            else
                App.MainPageVM.AddButtonVisibility = System.Windows.Visibility.Collapsed;
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }
    }
}
