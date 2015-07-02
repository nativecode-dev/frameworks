namespace NativeCode.Sqlite.QueryBuilder.Converters
{
    using System;

    public interface IQueryValueConverter
    {
        bool CanConvert(Type type);

        object Convert(object value);
    }
}