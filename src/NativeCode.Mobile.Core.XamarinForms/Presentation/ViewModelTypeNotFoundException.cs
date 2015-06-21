namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using System;

    public class ViewModelTypeNotFoundException : Exception
    {
        public ViewModelTypeNotFoundException(Type viewModel) : base(CreateExceptionMessage(viewModel))
        {
            this.ViewModel = viewModel;
        }

        public Type ViewModel { get; private set; }

        public static string CreateExceptionMessage(Type viewType)
        {
            return string.Format("Could not find the requested view model {0}.", viewType.AssemblyQualifiedName);
        }
    }
}