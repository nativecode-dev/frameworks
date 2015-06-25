namespace NativeCode.Mobile.Core.XamarinForms.Droid.Extensions
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    using View = Android.Views.View;

    /// <summary>
    /// Provides extensions for <see cref="Android.Views.View" /> instances.
    /// </summary>
    public static class ViewExtensions
    {
        private const string PlatformType = "Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android";

        private const string PlatformRenderer = "RendererProperty";

        private static readonly FieldInfo FieldRenderer;

        private static BindableProperty cachedRendererProperty;

        /// <summary>
        /// Initializes static members of the <see cref="ViewExtensions"/> class.
        /// </summary>
        static ViewExtensions()
        {
            var type = Type.GetType(PlatformType, true);
            FieldRenderer = type.GetField(PlatformRenderer, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        }

        /// <summary>
        /// Gets the renderer property.
        /// </summary>
        internal static BindableProperty RendererProperty
        {
            get { return cachedRendererProperty ?? (cachedRendererProperty = (BindableProperty)FieldRenderer.GetValue(null)); }
        }

        /// <summary>
        /// Attempts to get the <see cref="IVisualElementRenderer" /> for a given <see cref="BindableObject" />.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="create">if set to <c>true</c> creates a renderer.</param>
        /// <returns>Returns a <see cref="IVisualElementRenderer" />.</returns>
        public static IVisualElementRenderer GetRenderer(this VisualElement element, bool create = true)
        {
            var renderer = element.GetValue(RendererProperty) as IVisualElementRenderer;

            if (renderer != null)
            {
                return renderer;
            }

            if (!create)
            {
                return null;
            }

            renderer = RendererFactory.GetRenderer(element);
            element.SetValue(RendererProperty, renderer);

            // TODO: Why do we have to call this twice?
            return RendererFactory.GetRenderer(element);
        }

        /// <summary>
        /// Attempts to get a native Android <see cref="View" />.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>Returns a <see cref="View" />.</returns>
        public static View GetNativeView(this VisualElement element)
        {
            var renderer = element.GetRenderer();

            if (renderer == null)
            {
                throw new InvalidOperationException("Could not get renderer for bindable object.");
            }

            return renderer.ViewGroup.RootView;
        }
    }
}