using System;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QuanlyCongviecNhom.Helpers
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value?.ToString()?.Trim().ToLower() ?? string.Empty;

            return status switch
            {
                "todo" or "chưa làm" or "cần làm" => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9E9E9E")),      // Xám
                "inprogress" or "đang làm" => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2196F3")),      // Xanh dương
                "done" or "hoàn thành" => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")),      // Xanh lá
                "overdue" or "trễ hạn" => new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F44336")),      // Đỏ
                _ => new SolidColorBrush(Colors.Gray)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}