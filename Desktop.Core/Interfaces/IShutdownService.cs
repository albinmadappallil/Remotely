using System.Threading.Tasks;

namespace Tess.Desktop.Core.Interfaces
{
    public interface IShutdownService
    {
        Task Shutdown();
    }
}
