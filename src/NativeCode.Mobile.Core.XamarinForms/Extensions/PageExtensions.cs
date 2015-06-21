namespace NativeCode.Mobile.Core.XamarinForms.Extensions
{
    using System;

    using NativeCode.Mobile.Core.XamarinForms.Helpers;

    using Xamarin.Forms;

    public static class PageExtensions
    {
        public static NavigationPage WithNavigation(this Page page)
        {
            return new ManagedNavigationPage(page);
        }

        private class ManagedNavigationPage : NavigationPage, IDisposable
        {
            private bool disposed;

            public ManagedNavigationPage(Page page) : base(page)
            {
                this.Popped += HandlePopped;
                this.Pushed += HandlePushed;
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            private static void HandlePopped(object sender, NavigationEventArgs e)
            {
                CloseDrawer();
            }

            private static void HandlePushed(object sender, NavigationEventArgs e)
            {
                CloseDrawer();
            }

            private static void CloseDrawer()
            {
                var master = AppHelper.GetMasterDetailPage();

                if (master != null && master.IsPresented)
                {
                    master.IsPresented = false;
                }
            }

            private void Dispose(bool disposing)
            {
                if (disposing && !this.disposed)
                {
                    this.disposed = true;

                    this.Popped -= HandlePopped;
                    this.Pushed -= HandlePushed;
                }
            }
        }
    }
}