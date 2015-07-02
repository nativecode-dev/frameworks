namespace NativeCode.Sqlite.QueryBuilder.Converters
{
    using System;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class DateTimeConverter : IQueryValueConverter
    {
        public bool CanConvert(Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTime?);
        }

        public object Convert(object value)
        {
            if (value is DateTime)
            {
                ((DateTime)value).ToTicks();
            }

            var time = value as DateTime?;

            if (time != null)
            {
                return time.ToTicks();
            }

            return value;
        }
    }
}