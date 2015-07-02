namespace NativeCode.Sqlite.QueryBuilder.Converters
{
    using System;

    public class EnumConverter : IQueryValueConverter
    {
        public bool CanConvert(Type type)
        {
            return type == typeof(Enum);
        }

        public object Convert(object value)
        {
            return (int)value;
        }
    }
}