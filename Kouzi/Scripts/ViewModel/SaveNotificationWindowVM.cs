using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kouzi.Scripts.ViewModel
{
    public class SaveNotificationWindowVM
    {
        #region CloseCommand
        public Action CloseAction { get; set; }
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get => closeCommand ?? (closeCommand = new RelayCommand(obj =>
            {
                CloseAction();
            }));

        }
        #endregion
    }
}
