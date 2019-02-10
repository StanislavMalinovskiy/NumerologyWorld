using System;
using Windows.UI.Xaml.Data;

namespace Numerology.Common
{

    public class DigitsConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (value.ToString() == "10/1" && !string.IsNullOrEmpty(value.ToString()))
                {
                    string StrValue ="1/10";

                    value = StrValue.ToString();
                }

                if (value.ToString().Length > 5 && !string.IsNullOrEmpty(value.ToString()))
                {
                    if (value.ToString().Contains("10/1"))
                    {
                        string StrValue = value.ToString();
                        StrValue = StrValue.Replace("10/1", "1/10");
                        value = StrValue.ToString();
                    }
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

