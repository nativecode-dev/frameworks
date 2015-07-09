namespace NativeCode.Core.Extensions
{
    using System;
    using System.Text;

    public static class ExceptionExtensions
    {
        public static StringBuilder BuildExceptionMessage<TException>(this TException exception, bool includeStackTrace = true) where TException : Exception
        {
            var builder = new StringBuilder();

            var aggregate = exception as AggregateException;

            if (aggregate != null)
            {
                foreach (var ex in aggregate.InnerExceptions)
                {
                    WriteException(builder, ex, includeStackTrace);
                }
            }
            else
            {
                WriteException(builder, exception, includeStackTrace);
            }

            return builder;
        }

        public static string Stringify<TException>(this TException exception, bool includeStackTrace = true) where TException : Exception
        {
            return exception.BuildExceptionMessage(includeStackTrace).ToString();
        }

        public static void WriteException(StringBuilder builder, Exception exception, bool includeStackTrace)
        {
            while (true)
            {
                builder.AppendLine(exception.Message);

                if (includeStackTrace)
                {
                    builder.AppendLine(exception.StackTrace);
                }

                if (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    continue;
                }

                break;
            }
        }
    }
}