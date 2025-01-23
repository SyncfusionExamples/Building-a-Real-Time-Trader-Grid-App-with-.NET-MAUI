using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    internal class TextForegroundConverter : IValueConverter
    {
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="info">The culture to use during the conversion.</param>
        /// <summary>Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="info" />.</summary>
        /// <returns>To be added.</returns>
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo info)
        {
            if (value is double numericValue) // Ensure value is a double
            {
                if (numericValue > 1 && numericValue <= 2)
                    return Colors.Green;
                else if (numericValue >= 0 && numericValue <= 1)
                    return Colors.Black;
                else
                    return Colors.Red;
            }

            return Colors.Gray; // Default color for invalid values
        }

        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="info">The culture to use during the conversion.</param>
        /// <summary> Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="info" />.</summary>
        /// <returns> To be added.</returns>
        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
