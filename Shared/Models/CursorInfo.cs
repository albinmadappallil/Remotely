﻿using System.Drawing;

namespace Tess.Shared.Models
{
    public class CursorInfo
    {

        public CursorInfo(byte[] imageBytes, Point hotspot, string cssOverride = null)
        {
            ImageBytes = imageBytes;
            HotSpot = hotspot;
            CssOverride = cssOverride;
        }

        public byte[] ImageBytes { get; set; }
        public Point HotSpot { get; set; }
        public string CssOverride { get; set; }
    }
}
