using System;

namespace Tess.Desktop.Core.Interfaces
{
    public interface IAudioCapturer
    {
        event EventHandler<byte[]> AudioSampleReady;
        void ToggleAudio(bool toggleOn);
    }
}
