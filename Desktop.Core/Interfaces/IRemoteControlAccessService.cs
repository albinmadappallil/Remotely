﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tess.Desktop.Core.Interfaces
{
    public interface IRemoteControlAccessService
    {
        Task<bool> PromptForAccess(string requesterName, string organizationName);
    }
}
