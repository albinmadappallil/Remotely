﻿using Tess.Desktop.Core.Services;
using Tess.Desktop.Core.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tess.Desktop.Core.Interfaces
{
    public interface IFileTransferService
    {
        string GetBaseDirectory();

        Task ReceiveFile(byte[] buffer, string fileName, string messageId, bool endOfFile, bool startOfFile);
        void OpenFileTransferWindow(Viewer viewer);
        Task UploadFile(FileUpload file, Viewer viewer, CancellationToken cancelToken, Action<double> progressUpdateCallback);
    }
}
