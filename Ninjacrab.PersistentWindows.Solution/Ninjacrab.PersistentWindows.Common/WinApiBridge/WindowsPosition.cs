﻿using System;
using System.Runtime.InteropServices;

namespace Ninjacrab.PersistentWindows.Common.WinApiBridge
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowsPosition
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int Left;
        public int Top;
        public int Width;
        public int Height;
        public int Flags;
    }

    // workaround LiteDB compatibility issue in RECT data structure
    public struct RECT2
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public int Height
        {
            get
            {
                return Bottom - Top;
            }
        }
        public int Width
        {
            get
            {
                return Right - Left;
            }
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}), {2} x {3}", Left, Top, Width, Height);
        }

        /*
        public override bool Equals(object obj)
        {
            if (obj is RECT2)
            {
                RECT2 ob = (RECT2)obj;
                if (Left <= -25600 && ob.Left <= -25600)
                {
                    // avoid false unequal due to slight value difference 
                    return true;
                }
            }
            else
            {
                return false;
            }
            return base.Equals(obj);
        }
        */
    }
}
