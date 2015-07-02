namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToTicks(this DateTime value)
        {
            if (value.Kind == DateTimeKind.Local)
            {
                value = value.ToUniversalTime();
            }

            return value.Ticks;
        }

        public static long ToTicks(this DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToTicks();
            }

            return DateTime.UtcNow.Ticks;
        }

        public static string ToTicksString(this DateTime value)
        {
            return value.ToTicks().ToString();
        }

        public static string ToTicksString(this DateTime? value)
        {
            return value.ToTicks().ToString();
        }

        public static long ToTimestamp(this DateTime value)
        {
            if (value.Kind == DateTimeKind.Local)
            {
                value = value.ToUniversalTime();
            }

            return (long)(value - Epoch).TotalMilliseconds;
        }

        public static long ToTimestamp(this DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToTimestamp();
            }

            return DateTime.UtcNow.ToTimestamp();
        }

        public static string ToTimestampString(this DateTime value)
        {
            return value.ToTimestamp().ToString();
        }

        public static string ToTimestampString(this DateTime? value)
        {
            return value.ToTimestamp().ToString();
        }
    }
}