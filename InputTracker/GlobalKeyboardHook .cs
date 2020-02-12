using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace InputTracker
{
    internal class GlobalKeyboardHook
    {
        public delegate int keyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);

        public struct KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        private readonly keyboardHookProc khp;

        private IntPtr hhook = IntPtr.Zero;

        public event KeyEventHandler KeyDown;

        public event KeyEventHandler KeyUp;

        public GlobalKeyboardHook()
        {
            khp = new keyboardHookProc(HookProc);
            Hook();
        }

        ~GlobalKeyboardHook()
        {
            Unhook();
        }

        public void Hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, khp, hInstance, 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(hhook);
        }

        public int HookProc(int code, int wParam, ref KeyboardHookStruct lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                KeyEventArgs kea = new KeyEventArgs(key);
                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                {
                    KeyDown(this, kea);
                }
                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                {
                    KeyUp(this, kea);
                }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref KeyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}