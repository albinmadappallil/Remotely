using Tess.Shared.Models;
using System;

namespace Tess.Desktop.Core.Interfaces
{
    public interface ICursorIconWatcher
    {
        event EventHandler<CursorInfo> OnChange;

        CursorInfo GetCurrentCursor();
    }

}
