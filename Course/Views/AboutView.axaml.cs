using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Course.Views
{
    public partial class AboutView : Window
    {
        public AboutView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("CloseBtn").Click += delegate
            {
                Close();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
