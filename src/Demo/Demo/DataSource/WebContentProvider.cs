namespace Demo.DataSource
{
    using System;
    using System.Collections.Generic;

    using Demo.ViewModels;
    using Demo.Views;

    using NativeCode.Mobile.Core.XamarinForms.Controls;

    public class WebContentProvider : FlipViewContentProvider<Uri>
    {
        public WebContentProvider(IEnumerable<Uri> enumerable) : base(enumerable)
        {
        }

        protected override FlipViewContent CreateFlipViewContent(int position)
        {
            var viewModel = new WebContentViewModel(this.GetContentItem(position));
            return new WebContentView(viewModel);
        }
    }
}