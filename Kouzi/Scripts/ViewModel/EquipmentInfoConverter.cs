using Kouzi.Scripts.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kouzi
{
    class EquipmentInfoConverter: IMultiValueConverter
    {
        public object Convert(object[] Values, Type Target_Type, object Parameter, CultureInfo culture)
        {
            var findCommandParameters = new FindCommandParameters();
            findCommandParameters.Parameter1 = Values[0];
            findCommandParameters.Parameter2 = Values[1];
            findCommandParameters.Parameter3 = Values[2];
            return findCommandParameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
