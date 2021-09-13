using Microsoft.Extensions.DependencyInjection;
using Tess.Desktop.Core;
using Tess.Desktop.Core.Interfaces;
using Tess.Desktop.Core.Services;
using Tess.Shared.Utilities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tess.Desktop.XPlat.Services
{
    public class ShutdownServiceLinux : IShutdownService
    {
        public async Task Shutdown()
        {
            Logger.Debug($"Exiting process ID {Environment.ProcessId}.");
            var casterSocket = ServiceContainer.Instance.GetRequiredService<ICasterSocket>();
            await casterSocket.DisconnectAllViewers();
            Environment.Exit(0);
        }
    }
}
