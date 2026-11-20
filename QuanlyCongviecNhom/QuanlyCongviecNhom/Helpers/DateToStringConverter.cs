using System.Globalization;
using System.Windows;
using System.Windows.Data;

using System;


namespace QuanlyCongviecNhom.Helpers
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                string format = parameter as string ?? "dd/MM/yyyy";
                return date.ToString(format);
            }
            return "Không có hạn";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParseExact(value?.ToString(), "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}