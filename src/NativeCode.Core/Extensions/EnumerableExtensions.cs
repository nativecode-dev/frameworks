namespace NativeCode.Core.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, CancellationToken cancellationToken)
        {
            return collection.TakeWhile(x => !cancellationToken.IsCancellationRequested);
        }
    }
}