namespace NativeCode.Mobile.Core.XamarinForms.Droid.Renderers
{
    using System.Windows.Input;

    using Android.App;
    using Android.Views;

    using Xamarin.Forms.Platform.Android;

    using View = Xamarin.Forms.View;

    /// <summary>
    /// Provides a renderer for controls that should be inflated from a resource.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TNativeView">The type of the native view.</typeparam>
    public abstract class InflateViewRenderer<TView, TNativeView> : ViewRenderer<TView, TNativeView>
        where TView : View where TNativeView : Android.Views.View
    {
        /// <summary>
        /// Gets the <see cref="Activity"/> instance.
        /// </summary>
        protected Activity Activity
        {
            get { return (Activity)this.Context; }
        }

        /// <summary>
        /// Gets the <see cref="LayoutInflater"/> instance.
        /// </summary>
        protected LayoutInflater LayoutInflater
        {
            get { return this.Activity.LayoutInflater; }
        }

        /// <summary>
        /// Handles the click state of a view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="command">The command.</param>
        /// <param name="parameter">The parameter.</param>
        protected virtual void HandleClickListener(TNativeView view, ICommand command, object parameter)
        {
            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }

        /// <summary>
        /// Inflates the native control from a resource.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="group">The group.</param>
        /// <param name="attachToRoot">if set to <c>true</c> [attach to root].</param>
        /// <returns>Returns a <see cref="TNativeView" /> instance.</returns>
        /// <exception cref="System.InvalidCastException">Could not cast the View to a  + typeof(TNativeView).Name + .</exception>
        protected TNativeView InflateNativeControl(int id, ViewGroup @group = null, bool attachToRoot = false)
        {
            return this.InflateNativeControl<TNativeView>(id, @group, attachToRoot);
        }

        /// <summary>
        /// Inflates the native control from a resource.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="group">The group.</param>
        /// <param name="attachToRoot">if set to <c>true</c> [attach to root].</param>
        /// <returns>Returns a casted <see cref="View" />.</returns>
        /// <exception cref="System.InvalidCastException">Could not cast the view {0} to a {1}.</exception>
        protected T InflateNativeControl<T>(int id, ViewGroup @group = null, bool attachToRoot = false) where T : Android.Views.View
        {
            var inflated = this.LayoutInflater.Inflate(id, @group, attachToRoot);

            return inflated.FindViewById<T>(inflated.Id);
        }
    }
}