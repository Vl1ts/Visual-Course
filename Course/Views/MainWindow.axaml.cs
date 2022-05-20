using Avalonia.Controls;

namespace Course.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("MenuAboutBtn").Click += async delegate
            {
                var aboutWindow = new AboutView();
                await aboutWindow.ShowDialog((Window)this.VisualRoot);
            };
            
            this.FindControl<MenuItem>("MenuExitBtn").Click += delegate
            {
                this.Close();
            };
        }
    }
}
