namespace Demo.ViewModels
{
    using System.IO;
    using System.Reflection;

    using NativeCode.Mobile.Core.Presentation;

    public class ArticleViewModel : NavigableViewModel
    {
        private const string LoremIpsumResource = "Demo.Resources.LoremIpsum.txt";

        public ArticleViewModel()
        {
            this.Text = this.GetText();
            this.Title = "Lorem Ipsum";
        }

        public string Text { get; set; }

        private string GetText()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;

            using (var reader = new StreamReader(assembly.GetManifestResourceStream(LoremIpsumResource)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}