using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Course.ViewModels;

namespace Course.Views
{
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("MenuAboutBtn").Click += async delegate
            {
                var aboutWindow = new AboutView();
                await aboutWindow.ShowDialog((Window)this.VisualRoot);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
