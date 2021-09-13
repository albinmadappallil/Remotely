using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tess.Desktop.XPlat.ViewModels;
using Tess.Desktop.XPlat.Views;

namespace Tess.Desktop.XPlat.Views
{
    public class HostNamePrompt : Window
    {
        public HostNamePrompt()
        {
            Owner = MainWindow.Current;
            InitializeComponent();
        }

        public HostNamePromptViewModel ViewModel => DataContext as HostNamePromptViewModel;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
