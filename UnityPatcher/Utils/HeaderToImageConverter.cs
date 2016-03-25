using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace UnityPatcher
{

	[ValueConversion(typeof(string), typeof(bool))]
	public class HeaderToImageConverter : IValueConverter
	{
		public static HeaderToImageConverter Instance = new HeaderToImageConverter();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && value is string)
			{
				Uri uri = new Uri($"pack://siteoforigin:,,,/images/{(value as string)}");
				if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}{uri.AbsolutePath}"))
				{
					BitmapImage source = new BitmapImage(uri);
					return source;
				}
				else
				{
					Console.WriteLine($"Missing resource: {AppDomain.CurrentDomain.BaseDirectory}{uri.AbsolutePath}");
				}
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Cannot convert back");
		}
	}

}
