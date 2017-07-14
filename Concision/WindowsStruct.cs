using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Concision
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLINFO
    {
        public UInt32 cbSize;
        public UInt32 fMask;
        public Int32 nMin;
        public Int32 nMax;
        public UInt32 nPage;
        public Int32 nPos;
        public Int32 nTrackPos;
    }
}
