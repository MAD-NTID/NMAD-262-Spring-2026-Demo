
using System;
using System.Globalization;

namespace CollectionViewDemo;
public class CarStatusConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool isNew = (bool)value;

        if(isNew)
        {
            return "New";
        }
        return "Used";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}