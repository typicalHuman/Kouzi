using Kouzi.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kouzi
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainVM MainVM { get; set; }
        public static MainPageVM MainPageVM { get; set; }
        public static AddingBuyerPageVM AddingBuyerPageVM { get; set; }
        public static AddingEquipmentPageVM AddingEquipmentPageVM { get; set; }
        public static BackButtonVM BackButtonVM { get; set; }
        public static BuyersResultPageVM BuyersResultPageVM { get; set; }
        public static EquipmentsResultPageVM EquipmentsResultPageVM { get; set; }
        public static FileVM FileVM { get; set; }
        public static SaveNotificationWindowVM SaveNotificationWindowVM { get; set; }

        public App()
        {
            MainVM = new MainVM();
            MainPageVM = new MainPageVM();
            AddingBuyerPageVM = new AddingBuyerPageVM();
            AddingEquipmentPageVM = new AddingEquipmentPageVM();
            BackButtonVM = new BackButtonVM();
            BuyersResultPageVM = new BuyersResultPageVM();
            EquipmentsResultPageVM = new EquipmentsResultPageVM();
            FileVM = new FileVM();
            SaveNotificationWindowVM = new SaveNotificationWindowVM();
        }
    }
}
