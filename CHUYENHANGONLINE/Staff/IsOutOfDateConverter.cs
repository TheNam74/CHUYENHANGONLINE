using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CHUYENHANGONLINE.Staff
{
    [ValueConversion(typeof(DateTime), typeof(bool))]
    class IsOutOfDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return true;
            }
            DateTime date = (DateTime)value;
            DateTime curDate = DateTime.Now;

            TimeSpan span = curDate.Subtract(date);

            return span.TotalDays > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
