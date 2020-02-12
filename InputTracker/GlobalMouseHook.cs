using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InputTracker
{
    internal class GlobalMouseHook
    {
        public delegate int mouseHookProc(int code, int wParam, ref MouseHookStruct lParam);

        public struct POINT
        {
            public int x;
            public int y;
        }

        public struct MouseHookStruct
        {
            public POINT pt;
            public uint mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private const int WH_MOUSE_LL = 14;

        // private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;

        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;
        private const int WM_MOUSEWHEEL = 0x20A;

        private readonly mouseHookProc mhp;

        private IntPtr hhook = IntPtr.Zero;

        public event MouseEventHandler ButtonDown;

        public event MouseEventHandler ButtonUp;

        public event MouseEventHandler DblClk;

        public event MouseEventHandler MouseMove;

        public GlobalMouseHook()
        {
            mhp = new mouseHookProc(HookProc);
            Hook();
        }

        ~GlobalMouseHook()
        {
            Unhook();
        }

        public void Hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_MOUSE_LL, mhp, hInstance, 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public int HookProc(int code, int wParam, ref MouseHookStruct lParam)
        {
            if (code >= 0)
            {
                #region Get MouseEventArgsData

                MouseHookStruct mouseHookStruct = lParam;
                MouseButtons button = MouseButtons.None;
                short mouseDelta = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                    case WM_LBUTTONUP:
                    case WM_LBUTTONDBLCLK:
                        button = MouseButtons.Left;
                        break;

                    case WM_RBUTTONDOWN:
                    case WM_RBUTTONUP:
                    case WM_RBUTTONDBLCLK:
                        button = MouseButtons.Right;
                        break;

                    case WM_MBUTTONDOWN:
                    case WM_MBUTTONUP:
                    case WM_MBUTTONDBLCLK:
                        button = MouseButtons.Middle;
                        break;

                    case WM_MOUSEWHEEL:
                        mouseDelta = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);
                        break;
                }

                int clickCount = 0;
                if (button != MouseButtons.None)
                    if (wParam == WM_LBUTTONDBLCLK || wParam == WM_RBUTTONDBLCLK || wParam == WM_MBUTTONDBLCLK)
                        clickCount = 2;
                    else
                        clickCount = 1;

                #endregion Get MouseEventArgsData

                MouseEventArgs mea = new MouseEventArgs(
                                                   button,
                                                   clickCount,
                                                   mouseHookStruct.pt.x,
                                                   mouseHookStruct.pt.y,
                                                   mouseDelta);
                if (clickCount == 0)
                {
                    MouseMove?.Invoke(this, mea);
                }
                else if (clickCount == 2)
                {
                    DblClk?.Invoke(this, mea);
                }
                else
                {
                    switch (wParam)
                    {
                        case WM_LBUTTONDOWN:
                        case WM_RBUTTONDOWN:
                        case WM_MBUTTONDOWN:
                            ButtonDown?.Invoke(this, mea);
                            break;

                        case WM_LBUTTONUP:
                        case WM_RBUTTONUP:
                        case WM_MBUTTONUP:
                            ButtonUp?.Invoke(this, mea);
                            break;
                    }
                }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, mouseHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref MouseHookStruct lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}