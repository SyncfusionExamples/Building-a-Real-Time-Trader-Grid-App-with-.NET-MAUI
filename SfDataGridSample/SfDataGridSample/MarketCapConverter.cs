using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class MarketCapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double marketCap)
            {
                if (marketCap >= 1_000_000_000_000) // Trillions
                    return $"${marketCap / 1_000_000_000_000:F1} Trillion";
                else if (marketCap >= 1_000_000_000) // Billions
                    return $"${marketCap / 1_000_000_000:F1} Billion";
                else if (marketCap >= 1_000_000) // Millions
                    return $"${marketCap / 1_000_000:F1} Million";
                else if (marketCap >= 1_000) // Thousands
                    return $"${marketCap / 1_000:F1} Thousand";
                else
                    return $"${marketCap:N2}"; // Show exact number
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value; // Not needed in this case
        }
    }
}
