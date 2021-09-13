using Avalonia.Controls;
using Avalonia.Threading;
using Tess.Desktop.Core.Interfaces;
using Tess.Desktop.XPlat.Views;

namespace Tess.Desktop.XPlat.Services
{
    public class SessionIndicatorLinux : ISessionIndicator
    {
        public void Show()
        {
            Dispatcher.UIThread.Post(() =>
            {
                var indicatorWindow = new SessionIndicatorWindow();
                indicatorWindow.Show();
            });
        }
    }
}
