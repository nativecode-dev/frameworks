using System;

namespace NativeCode.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static void DisposeIfNeeded(this object instance)
        {
            var disposable = instance as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}