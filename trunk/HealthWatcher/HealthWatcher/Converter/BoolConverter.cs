using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Data;

namespace HealthWatcher.Converter
{
    public class BoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool tmpValue = System.Convert.ToBoolean(value);
                if (tmpValue)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Red;
                }
            }
            return Brushes.Red;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
