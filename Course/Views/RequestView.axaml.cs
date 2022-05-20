using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Course.Views
{
    public partial class RequestView : Window
    {
        public RequestView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
