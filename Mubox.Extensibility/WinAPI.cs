﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;

namespace Mubox
{
    [SuppressUnmanagedCodeSecurity]
    public static class WinAPI
    {
        #region Cursor Position

        [System.Security.SuppressUnmanagedCodeSecurity]
        public static class Cursor
        {
            [DllImport("user32.dll")]
            internal static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

            [DllImport("user32.dll")]
            internal static extern bool SetCursorPos(int X, int Y);

            [DllImport("user32.dll")]
            internal static extern IntPtr GetCapture();

            [DllImport("user32.dll")]
            internal static extern IntPtr SetCapture(IntPtr hWnd);

            [DllImport("user32.dll")]
            internal static extern bool ReleaseCapture();
        }

        #endregion Cursor Position

        #region System Metrics

        [System.Security.SuppressUnmanagedCodeSecurity]
        public static class SystemMetrics
        {
            [DllImport("user32.dll")]
            internal static extern int GetSystemMetrics(SM smIndex);

            public enum SM : int
            {
                /// <summary>
                ///  Width of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
                /// </summary>
                SM_CXSCREEN = 0,

                /// <summary>
                /// Height of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
                /// </summary>
                SM_CYSCREEN = 1,

                /// <summary>
                /// Width of a horizontal scroll bar, in pixels.
                /// </summary>
                SM_CYVSCROLL = 2,

                /// <summary>
                /// Height of a horizontal scroll bar, in pixels.
                /// </summary>
                SM_CXVSCROLL = 3,

                /// <summary>
                /// Height of a caption area, in pixels.
                /// </summary>
                SM_CYCAPTION = 4,

                /// <summary>
                /// Width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
                /// </summary>
                SM_CXBORDER = 5,

                /// <summary>
                /// Height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
                /// </summary>
                SM_CYBORDER = 6,

                /// <summary>
                /// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border.
                /// </summary>
                SM_CXDLGFRAME = 7,

                /// <summary>
                /// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border.
                /// </summary>
                SM_CYDLGFRAME = 8,

                /// <summary>
                /// Height of the thumb box in a vertical scroll bar, in pixels
                /// </summary>
                SM_CYVTHUMB = 9,

                /// <summary>
                /// Width of the thumb box in a horizontal scroll bar, in pixels.
                /// </summary>
                SM_CXHTHUMB = 10,

                /// <summary>
                /// Default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions specified by SM_CXICON and SM_CYICON
                /// </summary>
                SM_CXICON = 11,

                /// <summary>
                /// Default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
                /// </summary>
                SM_CYICON = 12,

                /// <summary>
                /// Width of a cursor, in pixels. The system cannot create cursors of other sizes.
                /// </summary>
                SM_CXCURSOR = 13,

                /// <summary>
                /// Height of a cursor, in pixels. The system cannot create cursors of other sizes.
                /// </summary>
                SM_CYCURSOR = 14,

                /// <summary>
                /// Height of a single-line menu bar, in pixels.
                /// </summary>
                SM_CYMENU = 15,

                /// <summary>
                /// Width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
                /// </summary>
                SM_CXFULLSCREEN = 16,

                /// <summary>
                /// Height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
                /// </summary>
                SM_CYFULLSCREEN = 17,

                /// <summary>
                /// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels
                /// </summary>
                SM_CYKANJIWINDOW = 18,

                /// <summary>
                /// Nonzero if a mouse with a wheel is installed; zero otherwise
                /// </summary>
                SM_MOUSEWHEELPRESENT = 75,

                /// <summary>
                /// Height of the arrow bitmap on a vertical scroll bar, in pixels.
                /// </summary>
                SM_CYHSCROLL = 20,

                /// <summary>
                /// Width of the arrow bitmap on a horizontal scroll bar, in pixels.
                /// </summary>
                SM_CXHSCROLL = 21,

                /// <summary>
                /// Nonzero if the debug version of User.exe is installed; zero otherwise.
                /// </summary>
                SM_DEBUG = 22,

                /// <summary>
                /// Nonzero if the left and right mouse buttons are reversed; zero otherwise.
                /// </summary>
                SM_SWAPBUTTON = 23,

                /// <summary>
                /// Reserved for future use
                /// </summary>
                SM_RESERVED1 = 24,

                /// <summary>
                /// Reserved for future use
                /// </summary>
                SM_RESERVED2 = 25,

                /// <summary>
                /// Reserved for future use
                /// </summary>
                SM_RESERVED3 = 26,

                /// <summary>
                /// Reserved for future use
                /// </summary>
                SM_RESERVED4 = 27,

                /// <summary>
                /// Minimum width of a window, in pixels.
                /// </summary>
                SM_CXMIN = 28,

                /// <summary>
                /// Minimum height of a window, in pixels.
                /// </summary>
                SM_CYMIN = 29,

                /// <summary>
                /// Width of a button in a window's caption or title bar, in pixels.
                /// </summary>
                SM_CXSIZE = 30,

                /// <summary>
                /// Height of a button in a window's caption or title bar, in pixels.
                /// </summary>
                SM_CYSIZE = 31,

                /// <summary>
                /// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
                /// </summary>
                SM_CXFRAME = 32,

                /// <summary>
                /// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
                /// </summary>
                SM_CYFRAME = 33,

                /// <summary>
                /// Minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
                /// </summary>
                SM_CXMINTRACK = 34,

                /// <summary>
                /// Minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message
                /// </summary>
                SM_CYMINTRACK = 35,

                /// <summary>
                /// Width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click
                /// </summary>
                SM_CXDOUBLECLK = 36,

                /// <summary>
                /// Height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. (The two clicks must also occur within a specified time.)
                /// </summary>
                SM_CYDOUBLECLK = 37,

                /// <summary>
                /// Width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON
                /// </summary>
                SM_CXICONSPACING = 38,

                /// <summary>
                /// Height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
                /// </summary>
                SM_CYICONSPACING = 39,

                /// <summary>
                /// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; zero if the menus are left-aligned.
                /// </summary>
                SM_MENUDROPALIGNMENT = 40,

                /// <summary>
                /// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
                /// </summary>
                SM_PENWINDOWS = 41,

                /// <summary>
                /// Nonzero if User32.dll supports DBCS; zero otherwise. (WinMe/95/98): Unicode
                /// </summary>
                SM_DBCSENABLED = 42,

                /// <summary>
                /// Number of buttons on mouse, or zero if no mouse is installed.
                /// </summary>
                SM_CMOUSEBUTTONS = 43,

                /// <summary>
                /// Identical Values Changed After Windows NT 4.0
                /// </summary>
                SM_CXFIXEDFRAME = SM_CXDLGFRAME,

                /// <summary>
                /// Identical Values Changed After Windows NT 4.0
                /// </summary>
                SM_CYFIXEDFRAME = SM_CYDLGFRAME,

                /// <summary>
                /// Identical Values Changed After Windows NT 4.0
                /// </summary>
                SM_CXSIZEFRAME = SM_CXFRAME,

                /// <summary>
                /// Identical Values Changed After Windows NT 4.0
                /// </summary>
                SM_CYSIZEFRAME = SM_CYFRAME,

                /// <summary>
                /// Nonzero if security is present; zero otherwise.
                /// </summary>
                SM_SECURE = 44,

                /// <summary>
                /// Width of a 3-D border, in pixels. This is the 3-D counterpart of SM_CXBORDER
                /// </summary>
                SM_CXEDGE = 45,

                /// <summary>
                /// Height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER
                /// </summary>
                SM_CYEDGE = 46,

                /// <summary>
                /// Width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CXMINIMIZED.
                /// </summary>
                SM_CXMINSPACING = 47,

                /// <summary>
                /// Height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CYMINIMIZED.
                /// </summary>
                SM_CYMINSPACING = 48,

                /// <summary>
                /// Recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view
                /// </summary>
                SM_CXSMICON = 49,

                /// <summary>
                /// Recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
                /// </summary>
                SM_CYSMICON = 50,

                /// <summary>
                /// Height of a small caption, in pixels
                /// </summary>
                SM_CYSMCAPTION = 51,

                /// <summary>
                /// Width of small caption buttons, in pixels.
                /// </summary>
                SM_CXSMSIZE = 52,

                /// <summary>
                /// Height of small caption buttons, in pixels.
                /// </summary>
                SM_CYSMSIZE = 53,

                /// <summary>
                /// Width of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
                /// </summary>
                SM_CXMENUSIZE = 54,

                /// <summary>
                /// Height of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
                /// </summary>
                SM_CYMENUSIZE = 55,

                /// <summary>
                /// Flags specifying how the system arranged minimized windows
                /// </summary>
                SM_ARRANGE = 56,

                /// <summary>
                /// Width of a minimized window, in pixels.
                /// </summary>
                SM_CXMINIMIZED = 57,

                /// <summary>
                /// Height of a minimized window, in pixels.
                /// </summary>
                SM_CYMINIMIZED = 58,

                /// <summary>
                /// Default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
                /// </summary>
                SM_CXMAXTRACK = 59,

                /// <summary>
                /// Default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
                /// </summary>
                SM_CYMAXTRACK = 60,

                /// <summary>
                /// Default width, in pixels, of a maximized top-level window on the primary display monitor.
                /// </summary>
                SM_CXMAXIMIZED = 61,

                /// <summary>
                /// Default height, in pixels, of a maximized top-level window on the primary display monitor.
                /// </summary>
                SM_CYMAXIMIZED = 62,

                /// <summary>
                /// Least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use
                /// </summary>
                SM_NETWORK = 63,

                /// <summary>
                /// Value that specifies how the system was started: 0-normal, 1-failsafe, 2-failsafe /w net
                /// </summary>
                SM_CLEANBOOT = 67,

                /// <summary>
                /// Width of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins, in pixels.
                /// </summary>
                SM_CXDRAG = 68,

                /// <summary>
                /// Height of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins. This value is in pixels. It allows the user to click and release the mouse button easily without unintentionally starting a drag operation.
                /// </summary>
                SM_CYDRAG = 69,

                /// <summary>
                /// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in audible form; zero otherwise.
                /// </summary>
                SM_SHOWSOUNDS = 70,

                /// <summary>
                /// Width of the default menu check-mark bitmap, in pixels.
                /// </summary>
                SM_CXMENUCHECK = 71,

                /// <summary>
                /// Height of the default menu check-mark bitmap, in pixels.
                /// </summary>
                SM_CYMENUCHECK = 72,

                /// <summary>
                /// Nonzero if the computer has a low-end (slow) processor; zero otherwise
                /// </summary>
                SM_SLOWMACHINE = 73,

                /// <summary>
                /// Nonzero if the system is enabled for Hebrew and Arabic languages, zero if not.
                /// </summary>
                SM_MIDEASTENABLED = 74,

                /// <summary>
                /// Nonzero if a mouse is installed; zero otherwise. This value is rarely zero, because of support for virtual mice and because some systems detect the presence of the port instead of the presence of a mouse.
                /// </summary>
                SM_MOUSEPRESENT = 19,

                /// <summary>
                /// Windows 2000 (v5.0+) Coordinate of the top of the virtual screen
                /// </summary>
                SM_XVIRTUALSCREEN = 76,

                /// <summary>
                /// Windows 2000 (v5.0+) Coordinate of the left of the virtual screen
                /// </summary>
                SM_YVIRTUALSCREEN = 77,

                /// <summary>
                /// Windows 2000 (v5.0+) Width of the virtual screen
                /// </summary>
                SM_CXVIRTUALSCREEN = 78,

                /// <summary>
                /// Windows 2000 (v5.0+) Height of the virtual screen
                /// </summary>
                SM_CYVIRTUALSCREEN = 79,

                /// <summary>
                /// Number of display monitors on the desktop
                /// </summary>
                SM_CMONITORS = 80,

                /// <summary>
                /// Windows XP (v5.1+) Nonzero if all the display monitors have the same color format, zero otherwise. Note that two displays can have the same bit depth, but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those bits can be located in different places in a pixel's color value.
                /// </summary>
                SM_SAMEDISPLAYFORMAT = 81,

                /// <summary>
                /// Windows XP (v5.1+) Nonzero if Input Method Manager/Input Method Editor features are enabled; zero otherwise
                /// </summary>
                SM_IMMENABLED = 82,

                /// <summary>
                /// Windows XP (v5.1+) Width of the left and right edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.
                /// </summary>
                SM_CXFOCUSBORDER = 83,

                /// <summary>
                /// Windows XP (v5.1+) Height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.
                /// </summary>
                SM_CYFOCUSBORDER = 84,

                /// <summary>
                /// Nonzero if the current operating system is the Windows XP Tablet PC edition, zero if not.
                /// </summary>
                SM_TABLETPC = 86,

                /// <summary>
                /// Nonzero if the current operating system is the Windows XP, Media Center Edition, zero if not.
                /// </summary>
                SM_MEDIACENTER = 87,

                /// <summary>
                /// Metrics Other
                /// </summary>
                SM_CMETRICS_OTHER = 76,

                /// <summary>
                /// Metrics Windows 2000
                /// </summary>
                SM_CMETRICS_2000 = 83,

                /// <summary>
                /// Metrics Windows NT
                /// </summary>
                SM_CMETRICS_NT = 88,

                /// <summary>
                /// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the return value is nonzero. If the calling process is associated with the Terminal Server console session, the return value is zero. The console session is not necessarily the physical console - see WTSGetActiveConsoleSessionId for more information.
                /// </summary>
                SM_REMOTESESSION = 0x1000,

                /// <summary>
                /// Windows XP (v5.1+) Nonzero if the current session is shutting down; zero otherwise
                /// </summary>
                SM_SHUTTINGDOWN = 0x2000,

                /// <summary>
                /// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. Its value is nonzero if the current session is remotely controlled; zero otherwise
                /// </summary>
                SM_REMOTECONTROL = 0x2001,
            }
        }

        #endregion System Metrics

        #region Window Hooking

        [System.Security.SuppressUnmanagedCodeSecurity]
        public static class WindowHook
        {
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr SetWindowsHookEx(HookType hookType, IntPtr callbackPtr, IntPtr hModule, uint dwThreadId);

            [DllImport("user32.dll")]
            internal static extern UIntPtr CallNextHookEx(IntPtr hHook, int nCode, UIntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

            internal delegate UIntPtr HookProc(int code, UIntPtr wParam, IntPtr lParam);

            internal delegate int LowLevelKeyboardProc(int nCode, WM windowMessage, IntPtr keyboardHookStruct);

            internal delegate IntPtr LowLevelMouseProc(int code, WM windowMessage, IntPtr mouseHookStruct);

            public enum HookType : int
            {
                WH_JOURNALRECORD = 0,
                WH_JOURNALPLAYBACK = 1,
                WH_KEYBOARD = 2,
                WH_GETMESSAGE = 3,
                WH_CALLWNDPROC = 4,
                WH_CBT = 5,
                WH_SYSMSGFILTER = 6,
                WH_MOUSE = 7,
                WH_HARDWARE = 8,
                WH_DEBUG = 9,
                WH_SHELL = 10,
                WH_FOREGROUNDIDLE = 11,
                WH_CALLWNDPROCRET = 12,
                WH_KEYBOARD_LL = 13,
                WH_MOUSE_LL = 14
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct KBDLLHOOKSTRUCT
            {
                internal WinAPI.VK vkCode;
                internal uint scanCode;
                internal LLKHF flags;
                internal uint time;
                internal IntPtr dwExtraInfo;
            }

            [Flags]
            public enum KF : ushort
            {
                EXTENDED = 0x0100,
                DLGMODE = 0x0800,
                MENUMODE = 0x1000,
                ALTDOWN = 0x2000,
                REPEAT = 0x4000,
                UP = 0x8000
            }

            [Flags]
            public enum LLKHF : uint
            {
                EXTENDED = 0x01,
                INJECTED = 0x10,
                ALTDOWN = 0x20,
                UP = 0x80
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MSLLHOOKSTRUCT
            {
                internal System.Drawing.Point pt;
                internal uint mouseData;
                internal LLMHF flags;
                internal uint time;
                internal IntPtr dwExtraInfo;
            }

            [Flags]
            public enum LLMHF : uint
            {
                INJECTED = 0x00000001
            }
        }

        #endregion Window Hooking

        #region VK Constants

        /// <summary>
        /// Enumeration for virtual keys.
        /// </summary>
        /// <remarks>
        /// <para>Because this type is used in interop structure definitions it MUST remain uint (uint32) typed (4bytes in size).</para>
        /// <para>Changing the bit width of this enum necessarily requires refactors of all dependent code to be "uint" based instead of "VK" based.</para>
        /// <para>Don't change the base!</para>
        /// </remarks>
        public enum VK : uint
        {
            /// <summary></summary>
            LeftButton = 0x01,

            /// <summary></summary>
            RightButton = 0x02,

            /// <summary></summary>
            Cancel = 0x03,

            /// <summary></summary>
            MiddleButton = 0x04,

            /// <summary></summary>
            ExtraButton1 = 0x05,

            /// <summary></summary>
            ExtraButton2 = 0x06,

            /// <summary></summary>
            Back = 0x08,

            /// <summary></summary>
            Tab = 0x09,

            /// <summary></summary>
            Clear = 0x0C,

            /// <summary></summary>
            Return = 0x0D,

            /// <summary></summary>
            Shift = 0x10,

            /// <summary></summary>
            Control = 0x11,

            /// <summary></summary>
            Menu = 0x12,

            /// <summary></summary>
            Pause = 0x13,

            /// <summary></summary>
            Capital = 0x14,

            /// <summary></summary>
            Kana = 0x15,

            /// <summary></summary>
            Hangeul = 0x15,

            /// <summary></summary>
            Hangul = 0x15,

            /// <summary></summary>
            Junja = 0x17,

            /// <summary></summary>
            Final = 0x18,

            /// <summary></summary>
            Hanja = 0x19,

            /// <summary></summary>
            Kanji = 0x19,

            /// <summary></summary>
            Escape = 0x1B,

            /// <summary></summary>
            Convert = 0x1C,

            /// <summary></summary>
            NonConvert = 0x1D,

            /// <summary></summary>
            Accept = 0x1E,

            /// <summary></summary>
            ModeChange = 0x1F,

            /// <summary></summary>
            Space = 0x20,

            /// <summary></summary>
            Prior = 0x21,

            /// <summary></summary>
            Next = 0x22,

            /// <summary></summary>
            End = 0x23,

            /// <summary></summary>
            Home = 0x24,

            /// <summary></summary>
            Left = 0x25,

            /// <summary></summary>
            Up = 0x26,

            /// <summary></summary>
            Right = 0x27,

            /// <summary></summary>
            Down = 0x28,

            /// <summary></summary>
            Select = 0x29,

            /// <summary></summary>
            Print = 0x2A,

            /// <summary></summary>
            Execute = 0x2B,

            /// <summary></summary>
            Snapshot = 0x2C,

            /// <summary></summary>
            Insert = 0x2D,

            /// <summary></summary>
            Delete = 0x2E,

            /// <summary></summary>
            Help = 0x2F,

            /// <summary></summary>
            N0 = 0x30,

            /// <summary></summary>
            N1 = 0x31,

            /// <summary></summary>
            N2 = 0x32,

            /// <summary></summary>
            N3 = 0x33,

            /// <summary></summary>
            N4 = 0x34,

            /// <summary></summary>
            N5 = 0x35,

            /// <summary></summary>
            N6 = 0x36,

            /// <summary></summary>
            N7 = 0x37,

            /// <summary></summary>
            N8 = 0x38,

            /// <summary></summary>
            N9 = 0x39,

            /// <summary></summary>
            A = 0x41,

            /// <summary></summary>
            B = 0x42,

            /// <summary></summary>
            C = 0x43,

            /// <summary></summary>
            D = 0x44,

            /// <summary></summary>
            E = 0x45,

            /// <summary></summary>
            F = 0x46,

            /// <summary></summary>
            G = 0x47,

            /// <summary></summary>
            H = 0x48,

            /// <summary></summary>
            I = 0x49,

            /// <summary></summary>
            J = 0x4A,

            /// <summary></summary>
            K = 0x4B,

            /// <summary></summary>
            L = 0x4C,

            /// <summary></summary>
            M = 0x4D,

            /// <summary></summary>
            N = 0x4E,

            /// <summary></summary>
            O = 0x4F,

            /// <summary></summary>
            P = 0x50,

            /// <summary></summary>
            Q = 0x51,

            /// <summary></summary>
            R = 0x52,

            /// <summary></summary>
            S = 0x53,

            /// <summary></summary>
            T = 0x54,

            /// <summary></summary>
            U = 0x55,

            /// <summary></summary>
            V = 0x56,

            /// <summary></summary>
            W = 0x57,

            /// <summary></summary>
            X = 0x58,

            /// <summary></summary>
            Y = 0x59,

            /// <summary></summary>
            Z = 0x5A,

            /// <summary></summary>
            LeftWindows = 0x5B,

            /// <summary></summary>
            RightWindows = 0x5C,

            /// <summary></summary>
            Application = 0x5D,

            /// <summary></summary>
            Sleep = 0x5F,

            /// <summary></summary>
            Numpad0 = 0x60,

            /// <summary></summary>
            Numpad1 = 0x61,

            /// <summary></summary>
            Numpad2 = 0x62,

            /// <summary></summary>
            Numpad3 = 0x63,

            /// <summary></summary>
            Numpad4 = 0x64,

            /// <summary></summary>
            Numpad5 = 0x65,

            /// <summary></summary>
            Numpad6 = 0x66,

            /// <summary></summary>
            Numpad7 = 0x67,

            /// <summary></summary>
            Numpad8 = 0x68,

            /// <summary></summary>
            Numpad9 = 0x69,

            /// <summary></summary>
            Multiply = 0x6A,

            /// <summary></summary>
            Add = 0x6B,

            /// <summary></summary>
            Separator = 0x6C,

            /// <summary></summary>
            Subtract = 0x6D,

            /// <summary></summary>
            Decimal = 0x6E,

            /// <summary></summary>
            Divide = 0x6F,

            /// <summary></summary>
            F1 = 0x70,

            /// <summary></summary>
            F2 = 0x71,

            /// <summary></summary>
            F3 = 0x72,

            /// <summary></summary>
            F4 = 0x73,

            /// <summary></summary>
            F5 = 0x74,

            /// <summary></summary>
            F6 = 0x75,

            /// <summary></summary>
            F7 = 0x76,

            /// <summary></summary>
            F8 = 0x77,

            /// <summary></summary>
            F9 = 0x78,

            /// <summary></summary>
            F10 = 0x79,

            /// <summary></summary>
            F11 = 0x7A,

            /// <summary></summary>
            F12 = 0x7B,

            /// <summary></summary>
            F13 = 0x7C,

            /// <summary></summary>
            F14 = 0x7D,

            /// <summary></summary>
            F15 = 0x7E,

            /// <summary></summary>
            F16 = 0x7F,

            /// <summary></summary>
            F17 = 0x80,

            /// <summary></summary>
            F18 = 0x81,

            /// <summary></summary>
            F19 = 0x82,

            /// <summary></summary>
            F20 = 0x83,

            /// <summary></summary>
            F21 = 0x84,

            /// <summary></summary>
            F22 = 0x85,

            /// <summary></summary>
            F23 = 0x86,

            /// <summary></summary>
            F24 = 0x87,

            /// <summary></summary>
            NumLock = 0x90,

            /// <summary></summary>
            ScrollLock = 0x91,

            /// <summary></summary>
            NEC_Equal = 0x92,

            /// <summary></summary>
            Fujitsu_Jisho = 0x92,

            /// <summary></summary>
            Fujitsu_Masshou = 0x93,

            /// <summary></summary>
            Fujitsu_Touroku = 0x94,

            /// <summary></summary>
            Fujitsu_Loya = 0x95,

            /// <summary></summary>
            Fujitsu_Roya = 0x96,

            /// <summary></summary>
            LeftShift = 0xA0,

            /// <summary></summary>
            RightShift = 0xA1,

            /// <summary></summary>
            LeftControl = 0xA2,

            /// <summary></summary>
            RightControl = 0xA3,

            /// <summary></summary>
            LeftMenu = 0xA4,

            /// <summary></summary>
            RightMenu = 0xA5,

            /// <summary></summary>
            BrowserBack = 0xA6,

            /// <summary></summary>
            BrowserForward = 0xA7,

            /// <summary></summary>
            BrowserRefresh = 0xA8,

            /// <summary></summary>
            BrowserStop = 0xA9,

            /// <summary></summary>
            BrowserSearch = 0xAA,

            /// <summary></summary>
            BrowserFavorites = 0xAB,

            /// <summary></summary>
            BrowserHome = 0xAC,

            /// <summary></summary>
            VolumeMute = 0xAD,

            /// <summary></summary>
            VolumeDown = 0xAE,

            /// <summary></summary>
            VolumeUp = 0xAF,

            /// <summary></summary>
            MediaNextTrack = 0xB0,

            /// <summary></summary>
            MediaPrevTrack = 0xB1,

            /// <summary></summary>
            MediaStop = 0xB2,

            /// <summary></summary>
            MediaPlayPause = 0xB3,

            /// <summary></summary>
            LaunchMail = 0xB4,

            /// <summary></summary>
            LaunchMediaSelect = 0xB5,

            /// <summary></summary>
            LaunchApplication1 = 0xB6,

            /// <summary></summary>
            LaunchApplication2 = 0xB7,

            /// <summary></summary>
            OEM1 = 0xBA,

            Semicolon = OEM1,

            /// <summary></summary>
            OEMPlus = 0xBB,

            /// <summary></summary>
            OEMComma = 0xBC,

            /// <summary></summary>
            OEMMinus = 0xBD,

            /// <summary></summary>
            OEMPeriod = 0xBE,

            /// <summary></summary>
            OEM2 = 0xBF,

            Question = OEM2,

            /// <summary></summary>
            OEM3 = 0xC0,

            Tilde = OEM3,

            /// <summary></summary>
            OEM4 = 0xDB,

            OpenBracket = OEM4,

            /// <summary></summary>
            OEM5 = 0xDC,

            BackSlash = OEM5,

            /// <summary></summary>
            OEM6 = 0xDD,

            CloseBracket = OEM6,

            /// <summary></summary>
            OEM7 = 0xDE,

            Apostrophe = OEM7,

            /// <summary></summary>
            OEM8 = 0xDF,

            /// <summary></summary>
            OEMAX = 0xE1,

            /// <summary></summary>
            OEM102 = 0xE2,

            /// <summary></summary>
            ICOHelp = 0xE3,

            /// <summary></summary>
            ICO00 = 0xE4,

            /// <summary></summary>
            ProcessKey = 0xE5,

            /// <summary></summary>
            ICOClear = 0xE6,

            /// <summary></summary>
            Packet = 0xE7,

            /// <summary></summary>
            OEMReset = 0xE9,

            /// <summary></summary>
            OEMJump = 0xEA,

            /// <summary></summary>
            OEMPA1 = 0xEB,

            /// <summary></summary>
            OEMPA2 = 0xEC,

            /// <summary></summary>
            OEMPA3 = 0xED,

            /// <summary></summary>
            OEMWSCtrl = 0xEE,

            /// <summary></summary>
            OEMCUSel = 0xEF,

            /// <summary></summary>
            OEMATTN = 0xF0,

            /// <summary></summary>
            OEMFinish = 0xF1,

            /// <summary></summary>
            OEMCopy = 0xF2,

            /// <summary></summary>
            OEMAuto = 0xF3,

            /// <summary></summary>
            OEMENLW = 0xF4,

            /// <summary></summary>
            OEMBackTab = 0xF5,

            /// <summary></summary>
            ATTN = 0xF6,

            /// <summary></summary>
            CRSel = 0xF7,

            /// <summary></summary>
            EXSel = 0xF8,

            /// <summary></summary>
            EREOF = 0xF9,

            /// <summary></summary>
            Play = 0xFA,

            /// <summary></summary>
            Zoom = 0xFB,

            /// <summary></summary>
            Noname = 0xFC,

            /// <summary></summary>
            PA1 = 0xFD,

            /// <summary></summary>
            OEMClear = 0xFE
        }

        #endregion VK Constants

        #region Control-Alt-Shift Key Settings

        [Flags]
        public enum CAS : byte
        {
            CONTROL = 1,
            ALT = 2,
            SHIFT = 4,
        }

        #endregion Control-Alt-Shift Key Settings

        #region Windows Messages

        public static class Windows
        {
            [DllImport("user32.dll")]
            internal static extern bool ShowWindowAsync(IntPtr hWnd, ShowState nCmdShow);

            public enum ShowState : int
            {
                SW_HIDE = 0,
                SW_SHOWNORMAL = 1,
                SW_NORMAL = 1,
                SW_SHOWMINIMIZED = 2,
                SW_SHOWMAXIMIZED = 3,
                SW_MAXIMIZE = 3,
                SW_SHOWNOACTIVATE = 4,
                SW_SHOW = 5,
                SW_MINIMIZE = 6,
                SW_SHOWMINNOACTIVE = 7,
                SW_SHOWNA = 8,
                SW_RESTORE = 9,
                SW_SHOWDEFAULT = 10,
                SW_FORCEMINIMIZE = 11,
                SW_MAX = 11
            }

            public enum Position : int
            {
                HWND_TOPMOST = -1,
                HWND_NOTOPMOST = -2,
                HWND_TOP = 0,
                HWND_BOTTOM = 1
            }

            [Flags]
            public enum Options : int
            {
                NotSet = 0x0000,
                SWP_NOSIZE = 0x0001,
                SWP_NOMOVE = 0x0002,
                SWP_NOZORDER = 0x0004,
                SWP_NOREDRAW = 0x0008,
                SWP_NOACTIVATE = 0x0010,
                SWP_FRAMECHANGED = 0x0020,
                SWP_SHOWWINDOW = 0x0040,
                SWP_HIDEWINDOW = 0x0080,
                SWP_NOCOPYBITS = 0x0100,
                SWP_NOOWNERZORDER = 0x0200,
                SWP_NOSENDCHANGING = 0x0400,
                SWP_DRAWFRAME = SWP_FRAMECHANGED,
                SWP_NOREPOSITION = SWP_NOOWNERZORDER,
                SWP_DEFERERASE = 0x2000,
                SWP_ASYNCWINDOWPOS = 0x4000
            }

            [DllImport("user32.dll")]
            internal static extern bool SetWindowPos(IntPtr hwnd, Position position, int X, int Y, int cx, int cy, Options options);

            [DllImport("user32.dll")]
            internal static extern bool SetWindowPos(IntPtr hwnd, IntPtr insertAt, int X, int Y, int cx, int cy, uint uFlags);

            [DllImport("user32.dll")]
            internal static extern uint SetWindowLong(IntPtr hwnd, GWL nIndex, uint dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern uint GetWindowLong(IntPtr hWnd, GWL nIndex);

            public enum GWL : int
            {
                GWL_WNDPROC = (-4),
                GWL_HINSTANCE = (-6),
                GWL_HWNDPARENT = (-8),
                GWL_STYLE = (-16),
                GWL_EXSTYLE = (-20),
                GWL_USERDATA = (-21),
                GWL_ID = (-12)
            }

            [Flags]
            public enum WindowStyles : uint
            {
                WS_OVERLAPPED = 0x00000000,
                WS_POPUP = 0x80000000,
                WS_CHILD = 0x40000000,
                WS_MINIMIZE = 0x20000000,
                WS_VISIBLE = 0x10000000,
                WS_DISABLED = 0x08000000,
                WS_CLIPSIBLINGS = 0x04000000,
                WS_CLIPCHILDREN = 0x02000000,
                WS_MAXIMIZE = 0x01000000,
                WS_BORDER = 0x00800000,
                WS_DLGFRAME = 0x00400000,
                WS_VSCROLL = 0x00200000,
                WS_HSCROLL = 0x00100000,
                WS_SYSMENU = 0x00080000,
                WS_THICKFRAME = 0x00040000,
                WS_GROUP = 0x00020000,
                WS_TABSTOP = 0x00010000,

                WS_MINIMIZEBOX = 0x00020000,
                WS_MAXIMIZEBOX = 0x00010000,

                WS_CAPTION = WS_BORDER | WS_DLGFRAME,
                WS_TILED = WS_OVERLAPPED,
                WS_ICONIC = WS_MINIMIZE,
                WS_SIZEBOX = WS_THICKFRAME,
                WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

                WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
                WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
                WS_CHILDWINDOW = WS_CHILD,

                //Extended Window Styles

                WS_EX_DLGMODALFRAME = 0x00000001,
                WS_EX_NOPARENTNOTIFY = 0x00000004,
                WS_EX_TOPMOST = 0x00000008,
                WS_EX_ACCEPTFILES = 0x00000010,
                WS_EX_TRANSPARENT = 0x00000020,

                //#if(WINVER >= 0x0400)

                WS_EX_MDICHILD = 0x00000040,
                WS_EX_TOOLWINDOW = 0x00000080,
                WS_EX_WINDOWEDGE = 0x00000100,
                WS_EX_CLIENTEDGE = 0x00000200,
                WS_EX_CONTEXTHELP = 0x00000400,

                WS_EX_RIGHT = 0x00001000,
                WS_EX_LEFT = 0x00000000,
                WS_EX_RTLREADING = 0x00002000,
                WS_EX_LTRREADING = 0x00000000,
                WS_EX_LEFTSCROLLBAR = 0x00004000,
                WS_EX_RIGHTSCROLLBAR = 0x00000000,

                WS_EX_CONTROLPARENT = 0x00010000,
                WS_EX_STATICEDGE = 0x00020000,
                WS_EX_APPWINDOW = 0x00040000,

                WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
                WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

                //#endif /* WINVER >= 0x0400 */

                //#if(WIN32WINNT >= 0x0500)

                WS_EX_LAYERED = 0x00080000,

                //#endif /* WIN32WINNT >= 0x0500 */

                //#if(WINVER >= 0x0500)

                WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
                WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring

                //#endif /* WINVER >= 0x0500 */

                //#if(WIN32WINNT >= 0x0500)

                WS_EX_COMPOSITED = 0x02000000,
                WS_EX_NOACTIVATE = 0x08000000

                //#endif /* WIN32WINNT >= 0x0500 */
            }

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool BringWindowToTop(IntPtr hWnd);

            [DllImport("user32.dll")]
            internal static extern IntPtr GetActiveWindow();

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr SetActiveWindow(IntPtr hWnd);

            // For Windows Mobile, replace user32.dll with coredll.dll
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, bool fAttach);

            [DllImport("user32.dll")]
            internal static extern IntPtr GetForegroundWindow();

            public static IntPtr CurrentForegroundWindow
            {
                get
                {
                    return GetForegroundWindow();
                }
            }

            internal static bool SendMessage(IntPtr hWnd, WM Msg, UIntPtr wParam, UIntPtr lParam)
            {
                var dwResult = new IntPtr(0);
                return SendMessageTimeout(hWnd, Msg, wParam, lParam, SMTO_FLAGS.SMTO_BLOCK, 250, out dwResult);
            }

            internal static bool SendMessage(IntPtr hWnd, WM Msg, IntPtr wParam, UIntPtr lParam)
            {
                var dwResult = new IntPtr(0);
                return SendMessageTimeout(hWnd, Msg, wParam, lParam, SMTO_FLAGS.SMTO_BLOCK, 250, out dwResult);
            }

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool SendMessageTimeout(
                IntPtr hWnd,
                WM Msg,
                UIntPtr wParam,
                UIntPtr lParam,
                SMTO_FLAGS fuFlags,
                uint uTimeoutMilliseconds,
                out IntPtr lpdwResult);

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool SendMessageTimeout(
                IntPtr hWnd,
                WM Msg,
                IntPtr wParam,
                UIntPtr lParam,
                SMTO_FLAGS fuFlags,
                uint uTimeoutMilliseconds,
                out IntPtr lpdwResult);

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, UIntPtr lParam);

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool PostMessage(IntPtr hWnd, WM Msg, UIntPtr wParam, UIntPtr lParam);

            [Flags]
            public enum SMTO_FLAGS : uint
            {
                SMTO_NORMAL = 0x0000,
                SMTO_BLOCK = 0x0001,
                SMTO_ABORTIFHUNG = 0x0002,
                SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,
                SMTO_ERRORONEXIT = 0x0020,
            }

            [DllImport("user32.dll")]
            internal static extern bool TranslateMessage(ref MSG lpMsg);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool EnumWindows(EnumWindowsProc enumWindowsProc, IntPtr lParam);

            internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool EnumDesktopWindows(IntPtr hDesktop, Func<IntPtr, IntPtr, bool> enumWindowsProc, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool EnumDesktopWindows(IntPtr hDesktop, IntPtr enumWindowsCallbackPtr, IntPtr lParam);

            [DllImport("user32.dll")]
            internal static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc enumWindowsCallbackPtr, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            [DllImport("user32.dll")]
            internal static extern IntPtr GetFocus();

            [DllImport("user32.dll")]
            internal static extern IntPtr SetFocus(IntPtr hWnd);

            [DllImport("user32.dll")]
            internal static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

            [DllImport("user32.dll")]
            internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

            [DllImport("user32.dll")]
            internal static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

            [Serializable, StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                internal int Left;
                internal int Top;
                internal int Right;
                internal int Bottom;

                internal int Width { get { return Right - Left; } }

                internal int Height { get { return Bottom - Top; } }
            }

            [Flags]
            public enum MK : ushort
            {
                NONE = 0,
                MK_LBUTTON = 0x0001,
                MK_RBUTTON = 0x0002,
                MK_SHIFT = 0x0004,
                MK_CONTROL = 0x0008,
                MK_MBUTTON = 0x0010,
                MK_XBUTTON1 = 0x0020,
                MK_XBUTTON2 = 0x0040
            }

            [Serializable, StructLayout(LayoutKind.Sequential)]
            public struct MSG
            {
                internal IntPtr hwnd;
                internal WM message;
                internal int wParam;
                internal uint lParam;
                internal uint time;
                internal POINT pt;
            }

            [Serializable, StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                internal int x;
                internal int y;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        }

        public enum HitTestValues : short
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }

        /// <summary>
        /// Windows Messages
        /// Defined in winuser.h from Windows SDK v6.1
        /// Documentation pulled from MSDN.
        /// </summary>
        public enum WM : uint
        {
            /// <summary>
            /// The WM_NULL message performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
            /// </summary>
            NULL = 0x0000,

            /// <summary>
            /// The WM_CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
            /// </summary>
            CREATE = 0x0001,

            /// <summary>
            /// The WM_DESTROY message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
            /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
            /// /// </summary>
            DESTROY = 0x0002,

            /// <summary>
            /// The WM_MOVE message is sent after a window has been moved.
            /// </summary>
            MOVE = 0x0003,

            /// <summary>
            /// The WM_SIZE message is sent to a window after its size has changed.
            /// </summary>
            SIZE = 0x0005,

            /// <summary>
            /// The WM_ACTIVATE message is sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately.
            /// </summary>
            ACTIVATE = 0x0006,

            /// <summary>
            /// The WM_SETFOCUS message is sent to a window after it has gained the keyboard focus.
            /// </summary>
            SETFOCUS = 0x0007,

            /// <summary>
            /// The WM_KILLFOCUS message is sent to a window immediately before it loses the keyboard focus.
            /// </summary>
            KILLFOCUS = 0x0008,

            /// <summary>
            /// The WM_ENABLE message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed.
            /// </summary>
            ENABLE = 0x000A,

            /// <summary>
            /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
            /// </summary>
            SETREDRAW = 0x000B,

            /// <summary>
            /// An application sends a WM_SETTEXT message to set the text of a window.
            /// </summary>
            SETTEXT = 0x000C,

            /// <summary>
            /// An application sends a WM_GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller.
            /// </summary>
            GETTEXT = 0x000D,

            /// <summary>
            /// An application sends a WM_GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window.
            /// </summary>
            GETTEXTLENGTH = 0x000E,

            /// <summary>
            /// The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function.
            /// </summary>
            PAINT = 0x000F,

            /// <summary>
            /// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
            /// </summary>
            CLOSE = 0x0010,

            /// <summary>
            /// The WM_QUERYENDSESSION message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions. If any application returns zero, the session is not ended. The system stops sending WM_QUERYENDSESSION messages as soon as one application returns zero.
            /// After processing this message, the system sends the WM_ENDSESSION message with the wParam parameter set to the results of the WM_QUERYENDSESSION message.
            /// </summary>
            QUERYENDSESSION = 0x0011,

            /// <summary>
            /// The WM_QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
            /// </summary>
            QUERYOPEN = 0x0013,

            /// <summary>
            /// The WM_ENDSESSION message is sent to an application after the system processes the results of the WM_QUERYENDSESSION message. The WM_ENDSESSION message informs the application whether the session is ending.
            /// </summary>
            ENDSESSION = 0x0016,

            /// <summary>
            /// The WM_QUIT message indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function. It causes the GetMessage function to return zero.
            /// </summary>
            QUIT = 0x0012,

            /// <summary>
            /// The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized). The message is sent to prepare an invalidated portion of a window for painting.
            /// </summary>
            ERASEBKGND = 0x0014,

            /// <summary>
            /// This message is sent to all top-level windows when a change is made to a system color setting.
            /// </summary>
            SYSCOLORCHANGE = 0x0015,

            /// <summary>
            /// The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown.
            /// </summary>
            SHOWWINDOW = 0x0018,

            /// <summary>
            /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
            /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
            /// </summary>
            WININICHANGE = 0x001A,

            /// <summary>
            /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
            /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
            /// </summary>
            SETTINGCHANGE = WM.WININICHANGE,

            /// <summary>
            /// The WM_DEVMODECHANGE message is sent to all top-level windows whenever the user changes device-mode settings.
            /// </summary>
            DEVMODECHANGE = 0x001B,

            /// <summary>
            /// The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is about to be activated. The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
            /// </summary>
            ACTIVATEAPP = 0x001C,

            /// <summary>
            /// An application sends the WM_FONTCHANGE message to all top-level windows in the system after changing the pool of font resources.
            /// </summary>
            FONTCHANGE = 0x001D,

            /// <summary>
            /// A message that is sent whenever there is a change in the system time.
            /// </summary>
            TIMECHANGE = 0x001E,

            /// <summary>
            /// The WM_CANCELMODE message is sent to cancel certain modes, such as mouse capture. For example, the system sends this message to the active window when a dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of whether it is the active window. For example, the EnableWindow function sends this message when disabling the specified window.
            /// </summary>
            CANCELMODE = 0x001F,

            /// <summary>
            /// The WM_SETCURSOR message is sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
            /// </summary>
            SETCURSOR = 0x0020,

            /// <summary>
            /// The WM_MOUSEACTIVATE message is sent when the cursor is in an inactive window and the user presses a mouse button. The parent window receives this message only if the child window passes it to the DefWindowProc function.
            /// </summary>
            MOUSEACTIVATE = 0x0021,

            /// <summary>
            /// The WM_CHILDACTIVATE message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
            /// </summary>
            CHILDACTIVATE = 0x0022,

            /// <summary>
            /// The WM_QUEUESYNC message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JOURNALPLAYBACK Hook procedure.
            /// </summary>
            QUEUESYNC = 0x0023,

            /// <summary>
            /// The WM_GETMINMAXINFO message is sent to a window when the size or position of the window is about to change. An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size.
            /// </summary>
            GETMINMAXINFO = 0x0024,

            /// <summary>
            /// Windows NT 3.51 and earlier: The WM_PAINTICON message is sent to a minimized window when the icon is to be painted. This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
            /// </summary>
            PAINTICON = 0x0026,

            /// <summary>
            /// Windows NT 3.51 and earlier: The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent. This message is not sent by newer versions of Windows.
            /// </summary>
            ICONERASEBKGND = 0x0027,

            /// <summary>
            /// The WM_NEXTDLGCTL message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box.
            /// </summary>
            NEXTDLGCTL = 0x0028,

            /// <summary>
            /// The WM_SPOOLERSTATUS message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue.
            /// </summary>
            SPOOLERSTATUS = 0x002A,

            /// <summary>
            /// The WM_DRAWITEM message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
            /// </summary>
            DRAWITEM = 0x002B,

            /// <summary>
            /// The WM_MEASUREITEM message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
            /// </summary>
            MEASUREITEM = 0x002C,

            /// <summary>
            /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT message. The system sends a WM_DELETEITEM message for each deleted item. The system sends the WM_DELETEITEM message for any deleted list box or combo box item with nonzero item data.
            /// </summary>
            DELETEITEM = 0x002D,

            /// <summary>
            /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message.
            /// </summary>
            VKEYTOITEM = 0x002E,

            /// <summary>
            /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_CHAR message.
            /// </summary>
            CHARTOITEM = 0x002F,

            /// <summary>
            /// An application sends a WM_SETFONT message to specify the font that a control is to use when drawing text.
            /// </summary>
            SETFONT = 0x0030,

            /// <summary>
            /// An application sends a WM_GETFONT message to a control to retrieve the font with which the control is currently drawing its text.
            /// </summary>
            GETFONT = 0x0031,

            /// <summary>
            /// An application sends a WM_SETHOTKEY message to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window.
            /// </summary>
            SETHOTKEY = 0x0032,

            /// <summary>
            /// An application sends a WM_GETHOTKEY message to determine the hot key associated with a window.
            /// </summary>
            GETHOTKEY = 0x0033,

            /// <summary>
            /// The WM_QUERYDRAGICON message is sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
            /// </summary>
            QUERYDRAGICON = 0x0037,

            /// <summary>
            /// The system sends the WM_COMPAREITEM message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style.
            /// </summary>
            COMPAREITEM = 0x0039,

            /// <summary>
            /// Active Accessibility sends the WM_GETOBJECT message to obtain information about an accessible object contained in a server application.
            /// Applications never send this message directly. It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow. However, server applications handle this message.
            /// </summary>
            GETOBJECT = 0x003D,

            /// <summary>
            /// The WM_COMPACTING message is sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory. This indicates that system memory is low.
            /// </summary>
            COMPACTING = 0x0041,

            /// <summary>
            /// WM_COMMNOTIFY is Obsolete for Win32-Based Applications
            /// </summary>
            [Obsolete]
            COMMNOTIFY = 0x0044,

            /// <summary>
            /// The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
            /// </summary>
            WINDOWPOSCHANGING = 0x0046,

            /// <summary>
            /// The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
            /// </summary>
            WINDOWPOSCHANGED = 0x0047,

            /// <summary>
            /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
            /// Use: POWERBROADCAST
            /// </summary>
            [Obsolete]
            POWER = 0x0048,

            /// <summary>
            /// An application sends the WM_COPYDATA message to pass data to another application.
            /// </summary>
            COPYDATA = 0x004A,

            /// <summary>
            /// The WM_CANCELJOURNAL message is posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle.
            /// </summary>
            CANCELJOURNAL = 0x004B,

            /// <summary>
            /// Sent by a common control to its parent window when an event has occurred or the control requires some information.
            /// </summary>
            NOTIFY = 0x004E,

            /// <summary>
            /// The WM_INPUTLANGCHANGEREQUEST message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately.
            /// </summary>
            INPUTLANGCHANGEREQUEST = 0x0050,

            /// <summary>
            /// The WM_INPUTLANGCHANGE message is sent to the topmost affected window after an application's input language has been changed. You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows. These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on.
            /// </summary>
            INPUTLANGCHANGE = 0x0051,

            /// <summary>
            /// Sent to an application that has initiated a training card with Microsoft Windows Help. The message informs the application when the user clicks an authorable button. An application initiates a training card by specifying the HELP_TCARD command in a call to the WinHelp function.
            /// </summary>
            TCARD = 0x0052,

            /// <summary>
            /// Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, WM_HELP is sent to the window associated with the menu; otherwise, WM_HELP is sent to the window that has the keyboard focus. If no window has the keyboard focus, WM_HELP is sent to the currently active window.
            /// </summary>
            HELP = 0x0053,

            /// <summary>
            /// The WM_USERCHANGED message is sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific settings. The system sends this message immediately after updating the settings.
            /// </summary>
            USERCHANGED = 0x0054,

            /// <summary>
            /// Determines if a window accepts ANSI or Unicode structures in the WM_NOTIFY notification message. WM_NOTIFYFORMAT messages are sent from a common control to its parent window and from the parent window to the common control.
            /// </summary>
            NOTIFYFORMAT = 0x0055,

            /// <summary>
            /// The WM_CONTEXTMENU message notifies a window that the user clicked the right mouse button (right-clicked) in the window.
            /// </summary>
            CONTEXTMENU = 0x007B,

            /// <summary>
            /// The WM_STYLECHANGING message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
            /// </summary>
            STYLECHANGING = 0x007C,

            /// <summary>
            /// The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the window's styles
            /// </summary>
            STYLECHANGED = 0x007D,

            /// <summary>
            /// The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
            /// </summary>
            DISPLAYCHANGE = 0x007E,

            /// <summary>
            /// The WM_GETICON message is sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
            /// </summary>
            GETICON = 0x007F,

            /// <summary>
            /// An application sends the WM_SETICON message to associate a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption.
            /// </summary>
            SETICON = 0x0080,

            /// <summary>
            /// The WM_NCCREATE message is sent prior to the WM_CREATE message when a window is first created.
            /// </summary>
            NCCREATE = 0x0081,

            /// <summary>
            /// The WM_NCDESTROY message informs a window that its nonclient area is being destroyed. The DestroyWindow function sends the WM_NCDESTROY message to the window following the WM_DESTROY message. WM_DESTROY is used to free the allocated memory object associated with the window.
            /// The WM_NCDESTROY message is sent after the child windows have been destroyed. In contrast, WM_DESTROY is sent before the child windows are destroyed.
            /// </summary>
            NCDESTROY = 0x0082,

            /// <summary>
            /// The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated. By processing this message, an application can control the content of the window's client area when the size or position of the window changes.
            /// </summary>
            NCCALCSIZE = 0x0083,

            /// <summary>
            /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released. If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
            /// </summary>
            NCHITTEST = 0x0084,

            /// <summary>
            /// The WM_NCPAINT message is sent to a window when its frame must be painted.
            /// </summary>
            NCPAINT = 0x0085,

            /// <summary>
            /// The WM_NCACTIVATE message is sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
            /// </summary>
            NCACTIVATE = 0x0086,

            /// <summary>
            /// The WM_GETDLGCODE message is sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control can respond to the WM_GETDLGCODE message to indicate the types of input it wants to process itself.
            /// </summary>
            GETDLGCODE = 0x0087,

            /// <summary>
            /// The WM_SYNCPAINT message is used to synchronize painting while avoiding linking independent GUI threads.
            /// </summary>
            SYNCPAINT = 0x0088,

            /// <summary>
            /// The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCMOUSEMOVE = 0x00A0,

            /// <summary>
            /// The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCLBUTTONDOWN = 0x00A1,

            /// <summary>
            /// The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCLBUTTONUP = 0x00A2,

            /// <summary>
            /// The WM_NCLBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCLBUTTONDBLCLK = 0x00A3,

            /// <summary>
            /// The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCRBUTTONDOWN = 0x00A4,

            /// <summary>
            /// The WM_NCRBUTTONUP message is posted when the user releases the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCRBUTTONUP = 0x00A5,

            /// <summary>
            /// The WM_NCRBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCRBUTTONDBLCLK = 0x00A6,

            /// <summary>
            /// The WM_NCMBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCMBUTTONDOWN = 0x00A7,

            /// <summary>
            /// The WM_NCMBUTTONUP message is posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCMBUTTONUP = 0x00A8,

            /// <summary>
            /// The WM_NCMBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCMBUTTONDBLCLK = 0x00A9,

            /// <summary>
            /// The WM_NCXBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCXBUTTONDOWN = 0x00AB,

            /// <summary>
            /// The WM_NCXBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCXBUTTONUP = 0x00AC,

            /// <summary>
            /// The WM_NCXBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            /// </summary>
            NCXBUTTONDBLCLK = 0x00AD,

            /// <summary>
            /// The WM_INPUT_DEVICE_CHANGE message is sent to the window that registered to receive raw input. A window receives this message through its WindowProc function.
            /// </summary>
            INPUT_DEVICE_CHANGE = 0x00FE,

            /// <summary>
            /// The WM_INPUT message is sent to the window that is getting raw input.
            /// </summary>
            INPUT = 0x00FF,

            /// <summary>
            /// The WM_KEYDOWN message is posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed.
            /// </summary>
            KEYDOWN = 0x0100,

            /// <summary>
            /// This message filters for keyboard messages.
            /// </summary>
            KEYFIRST = 0x0100,

            /// <summary>
            /// The WM_KEYUP message is posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
            /// </summary>
            KEYUP = 0x0101,

            /// <summary>
            /// The WM_CHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_CHAR message contains the character code of the key that was pressed.
            /// </summary>
            CHAR = 0x0102,

            /// <summary>
            /// The WM_DEADCHAR message is posted to the window with the keyboard focus when a WM_KEYUP message is translated by the TranslateMessage function. WM_DEADCHAR specifies a character code generated by a dead key. A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key.
            /// </summary>
            DEADCHAR = 0x0103,

            /// <summary>
            /// The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
            /// </summary>
            SYSKEYDOWN = 0x0104,

            /// <summary>
            /// The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
            /// </summary>
            SYSKEYUP = 0x0105,

            /// <summary>
            /// The WM_SYSCHAR message is posted to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down.
            /// </summary>
            SYSCHAR = 0x0106,

            /// <summary>
            /// The WM_SYSDEADCHAR message is sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. WM_SYSDEADCHAR specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key.
            /// </summary>
            SYSDEADCHAR = 0x0107,

            /// <summary>
            /// The WM_UNICHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_UNICHAR message contains the character code of the key that was pressed.
            /// The WM_UNICHAR message is equivalent to WM_CHAR, but it uses Unicode Transformation Format (UTF)-32, whereas WM_CHAR uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
            /// </summary>
            UNICHAR = 0x0109,

            /// <summary>
            /// This message filters for keyboard messages.
            /// </summary>
            KEYLAST = 0x0109,

            /// <summary>
            /// Sent immediately before the IME generates the composition string as a result of a keystroke. A window receives this message through its WindowProc function.
            /// </summary>
            IME_STARTCOMPOSITION = 0x010D,

            /// <summary>
            /// Sent to an application when the IME ends composition. A window receives this message through its WindowProc function.
            /// </summary>
            IME_ENDCOMPOSITION = 0x010E,

            /// <summary>
            /// Sent to an application when the IME changes composition status as a result of a keystroke. A window receives this message through its WindowProc function.
            /// </summary>
            IME_COMPOSITION = 0x010F,

            IME_KEYLAST = 0x010F,

            /// <summary>
            /// The WM_INITDIALOG message is sent to the dialog box procedure immediately before a dialog box is displayed. Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box.
            /// </summary>
            INITDIALOG = 0x0110,

            /// <summary>
            /// The WM_COMMAND message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated.
            /// </summary>
            COMMAND = 0x0111,

            /// <summary>
            /// A window receives this message when the user chooses a command from the Window menu (formerly known as the system or control menu) or when the user chooses the maximize button, minimize button, restore button, or close button.
            /// </summary>
            SYSCOMMAND = 0x0112,

            /// <summary>
            /// The WM_TIMER message is posted to the installing thread's message queue when a timer expires. The message is posted by the GetMessage or PeekMessage function.
            /// </summary>
            TIMER = 0x0113,

            /// <summary>
            /// The WM_HSCROLL message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
            /// </summary>
            HSCROLL = 0x0114,

            /// <summary>
            /// The WM_VSCROLL message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
            /// </summary>
            VSCROLL = 0x0115,

            /// <summary>
            /// The WM_INITMENU message is sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This allows the application to modify the menu before it is displayed.
            /// </summary>
            INITMENU = 0x0116,

            /// <summary>
            /// The WM_INITMENUPOPUP message is sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu.
            /// </summary>
            INITMENUPOPUP = 0x0117,

            /// <summary>
            /// The WM_MENUSELECT message is sent to a menu's owner window when the user selects a menu item.
            /// </summary>
            MENUSELECT = 0x011F,

            /// <summary>
            /// The WM_MENUCHAR message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message is sent to the window that owns the menu.
            /// </summary>
            MENUCHAR = 0x0120,

            /// <summary>
            /// The WM_ENTERIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages.
            /// </summary>
            ENTERIDLE = 0x0121,

            /// <summary>
            /// The WM_MENURBUTTONUP message is sent when the user releases the right mouse button while the cursor is on a menu item.
            /// </summary>
            MENURBUTTONUP = 0x0122,

            /// <summary>
            /// The WM_MENUDRAG message is sent to the owner of a drag-and-drop menu when the user drags a menu item.
            /// </summary>
            MENUDRAG = 0x0123,

            /// <summary>
            /// The WM_MENUGETOBJECT message is sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item.
            /// </summary>
            MENUGETOBJECT = 0x0124,

            /// <summary>
            /// The WM_UNINITMENUPOPUP message is sent when a drop-down menu or submenu has been destroyed.
            /// </summary>
            UNINITMENUPOPUP = 0x0125,

            /// <summary>
            /// The WM_MENUCOMMAND message is sent when the user makes a selection from a menu.
            /// </summary>
            MENUCOMMAND = 0x0126,

            /// <summary>
            /// An application sends the WM_CHANGEUISTATE message to indicate that the user interface (UI) state should be changed.
            /// </summary>
            CHANGEUISTATE = 0x0127,

            /// <summary>
            /// An application sends the WM_UPDATEUISTATE message to change the user interface (UI) state for the specified window and all its child windows.
            /// </summary>
            UPDATEUISTATE = 0x0128,

            /// <summary>
            /// An application sends the WM_QUERYUISTATE message to retrieve the user interface (UI) state for a window.
            /// </summary>
            QUERYUISTATE = 0x0129,

            /// <summary>
            /// The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box. By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle.
            /// </summary>
            CTLCOLORMSGBOX = 0x0132,

            /// <summary>
            /// An edit control that is not read-only or disabled sends the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control.
            /// </summary>
            CTLCOLOREDIT = 0x0133,

            /// <summary>
            /// Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle.
            /// </summary>
            CTLCOLORLISTBOX = 0x0134,

            /// <summary>
            /// The WM_CTLCOLORBTN message is sent to the parent window of a button before drawing the button. The parent window can change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message.
            /// </summary>
            CTLCOLORBTN = 0x0135,

            /// <summary>
            /// The WM_CTLCOLORDLG message is sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and background colors using the specified display device context handle.
            /// </summary>
            CTLCOLORDLG = 0x0136,

            /// <summary>
            /// The WM_CTLCOLORSCROLLBAR message is sent to the parent window of a scroll bar control when the control is about to be drawn. By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control.
            /// </summary>
            CTLCOLORSCROLLBAR = 0x0137,

            /// <summary>
            /// A static control, or an edit control that is read-only or disabled, sends the WM_CTLCOLORSTATIC message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control.
            /// </summary>
            CTLCOLORSTATIC = 0x0138,

            /// <summary>
            /// The WM_MOUSEMOVE message is posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            MOUSEMOVE = 0x0200,

            /// <summary>
            /// Use WM_MOUSEFIRST to specify the first mouse message. Use the PeekMessage() Function.
            /// </summary>
            MOUSEFIRST = 0x0200,

            /// <summary>
            /// The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            LBUTTONDOWN = 0x0201,

            /// <summary>
            /// The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            LBUTTONUP = 0x0202,

            /// <summary>
            /// The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            LBUTTONDBLCLK = 0x0203,

            /// <summary>
            /// The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            RBUTTONDOWN = 0x0204,

            /// <summary>
            /// The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            RBUTTONUP = 0x0205,

            /// <summary>
            /// The WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            RBUTTONDBLCLK = 0x0206,

            /// <summary>
            /// The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            MBUTTONDOWN = 0x0207,

            /// <summary>
            /// The WM_MBUTTONUP message is posted when the user releases the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            MBUTTONUP = 0x0208,

            /// <summary>
            /// The WM_MBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            MBUTTONDBLCLK = 0x0209,

            /// <summary>
            /// The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
            /// </summary>
            MOUSEWHEEL = 0x020A,

            /// <summary>
            /// The WM_XBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            XBUTTONDOWN = 0x020B,

            /// <summary>
            /// The WM_XBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            XBUTTONUP = 0x020C,

            /// <summary>
            /// The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            XBUTTONDBLCLK = 0x020D,

            /// <summary>
            /// The WM_MOUSEHWHEEL message is sent to the focus window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
            /// </summary>
            MOUSEHWHEEL = 0x020E,

            /// <summary>
            /// Use WM_MOUSELAST to specify the last mouse message. Used with PeekMessage() Function.
            /// </summary>
            MOUSELAST = 0x020E,

            /// <summary>
            /// The WM_PARENTNOTIFY message is sent to the parent of a child window when the child window is created or destroyed, or when the user clicks a mouse button while the cursor is over the child window. When the child window is being created, the system sends WM_PARENTNOTIFY just before the CreateWindow or CreateWindowEx function that creates the window returns. When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
            /// </summary>
            PARENTNOTIFY = 0x0210,

            /// <summary>
            /// The WM_ENTERMENULOOP message informs an application's main window procedure that a menu modal loop has been entered.
            /// </summary>
            ENTERMENULOOP = 0x0211,

            /// <summary>
            /// The WM_EXITMENULOOP message informs an application's main window procedure that a menu modal loop has been exited.
            /// </summary>
            EXITMENULOOP = 0x0212,

            /// <summary>
            /// The WM_NEXTMENU message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.
            /// </summary>
            NEXTMENU = 0x0213,

            /// <summary>
            /// The WM_SIZING message is sent to a window that the user is resizing. By processing this message, an application can monitor the size and position of the drag rectangle and, if needed, change its size or position.
            /// </summary>
            SIZING = 0x0214,

            /// <summary>
            /// The WM_CAPTURECHANGED message is sent to the window that is losing the mouse capture.
            /// </summary>
            CAPTURECHANGED = 0x0215,

            /// <summary>
            /// The WM_MOVING message is sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
            /// </summary>
            MOVING = 0x0216,

            /// <summary>
            /// Notifies applications that a power-management event has occurred.
            /// </summary>
            POWERBROADCAST = 0x0218,

            /// <summary>
            /// Notifies an application of a change to the hardware configuration of a device or the computer.
            /// </summary>
            DEVICECHANGE = 0x0219,

            /// <summary>
            /// An application sends the WM_MDICREATE message to a multiple-document interface (MDI) client window to create an MDI child window.
            /// </summary>
            MDICREATE = 0x0220,

            /// <summary>
            /// An application sends the WM_MDIDESTROY message to a multiple-document interface (MDI) client window to close an MDI child window.
            /// </summary>
            MDIDESTROY = 0x0221,

            /// <summary>
            /// An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct the client window to activate a different MDI child window.
            /// </summary>
            MDIACTIVATE = 0x0222,

            /// <summary>
            /// An application sends the WM_MDIRESTORE message to a multiple-document interface (MDI) client window to restore an MDI child window from maximized or minimized size.
            /// </summary>
            MDIRESTORE = 0x0223,

            /// <summary>
            /// An application sends the WM_MDINEXT message to a multiple-document interface (MDI) client window to activate the next or previous child window.
            /// </summary>
            MDINEXT = 0x0224,

            /// <summary>
            /// An application sends the WM_MDIMAXIMIZE message to a multiple-document interface (MDI) client window to maximize an MDI child window. The system resizes the child window to make its client area fill the client window. The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position. The system also appends the title bar text of the child window to that of the frame window.
            /// </summary>
            MDIMAXIMIZE = 0x0225,

            /// <summary>
            /// An application sends the WM_MDITILE message to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format.
            /// </summary>
            MDITILE = 0x0226,

            /// <summary>
            /// An application sends the WM_MDICASCADE message to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format.
            /// </summary>
            MDICASCADE = 0x0227,

            /// <summary>
            /// An application sends the WM_MDIICONARRANGE message to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows. It does not affect child windows that are not minimized.
            /// </summary>
            MDIICONARRANGE = 0x0228,

            /// <summary>
            /// An application sends the WM_MDIGETACTIVE message to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window.
            /// </summary>
            MDIGETACTIVE = 0x0229,

            /// <summary>
            /// An application sends the WM_MDISETMENU message to a multiple-document interface (MDI) client window to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both.
            /// </summary>
            MDISETMENU = 0x0230,

            /// <summary>
            /// The WM_ENTERSIZEMOVE message is sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns.
            /// The system sends the WM_ENTERSIZEMOVE message regardless of whether the dragging of full windows is enabled.
            /// </summary>
            ENTERSIZEMOVE = 0x0231,

            /// <summary>
            /// The WM_EXITSIZEMOVE message is sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns.
            /// </summary>
            EXITSIZEMOVE = 0x0232,

            /// <summary>
            /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
            /// </summary>
            DROPFILES = 0x0233,

            /// <summary>
            /// An application sends the WM_MDIREFRESHMENU message to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window.
            /// </summary>
            MDIREFRESHMENU = 0x0234,

            /// <summary>
            /// Sent to an application when a window is activated. A window receives this message through its WindowProc function.
            /// </summary>
            IME_SETCONTEXT = 0x0281,

            /// <summary>
            /// Sent to an application to notify it of changes to the IME window. A window receives this message through its WindowProc function.
            /// </summary>
            IME_NOTIFY = 0x0282,

            /// <summary>
            /// Sent by an application to direct the IME window to carry out the requested command. The application uses this message to control the IME window that it has created. To send this message, the application calls the SendMessage function with the following parameters.
            /// </summary>
            IME_CONTROL = 0x0283,

            /// <summary>
            /// Sent to an application when the IME window finds no space to extend the area for the composition window. A window receives this message through its WindowProc function.
            /// </summary>
            IME_COMPOSITIONFULL = 0x0284,

            /// <summary>
            /// Sent to an application when the operating system is about to change the current IME. A window receives this message through its WindowProc function.
            /// </summary>
            IME_SELECT = 0x0285,

            /// <summary>
            /// Sent to an application when the IME gets a character of the conversion result. A window receives this message through its WindowProc function.
            /// </summary>
            IME_CHAR = 0x0286,

            /// <summary>
            /// Sent to an application to provide commands and request information. A window receives this message through its WindowProc function.
            /// </summary>
            IME_REQUEST = 0x0288,

            /// <summary>
            /// Sent to an application by the IME to notify the application of a key press and to keep message order. A window receives this message through its WindowProc function.
            /// </summary>
            IME_KEYDOWN = 0x0290,

            /// <summary>
            /// Sent to an application by the IME to notify the application of a key release and to keep message order. A window receives this message through its WindowProc function.
            /// </summary>
            IME_KEYUP = 0x0291,

            /// <summary>
            /// The WM_MOUSEHOVER message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
            /// </summary>
            MOUSEHOVER = 0x02A1,

            /// <summary>
            /// The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
            /// </summary>
            MOUSELEAVE = 0x02A3,

            /// <summary>
            /// The WM_NCMOUSEHOVER message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
            /// </summary>
            NCMOUSEHOVER = 0x02A0,

            /// <summary>
            /// The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
            /// </summary>
            NCMOUSELEAVE = 0x02A2,

            /// <summary>
            /// The WM_WTSSESSION_CHANGE message notifies applications of changes in session state.
            /// </summary>
            WTSSESSION_CHANGE = 0x02B1,

            TABLET_FIRST = 0x02c0,
            TABLET_LAST = 0x02df,

            /// <summary>
            /// An application sends a WM_CUT message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format.
            /// </summary>
            CUT = 0x0300,

            /// <summary>
            /// An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format.
            /// </summary>
            COPY = 0x0301,

            /// <summary>
            /// An application sends a WM_PASTE message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format.
            /// </summary>
            PASTE = 0x0302,

            /// <summary>
            /// An application sends a WM_CLEAR message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control.
            /// </summary>
            CLEAR = 0x0303,

            /// <summary>
            /// An application sends a WM_UNDO message to an edit control to undo the last operation. When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
            /// </summary>
            UNDO = 0x0304,

            /// <summary>
            /// The WM_RENDERFORMAT message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function.
            /// </summary>
            RENDERFORMAT = 0x0305,

            /// <summary>
            /// The WM_RENDERALLFORMATS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function.
            /// </summary>
            RENDERALLFORMATS = 0x0306,

            /// <summary>
            /// The WM_DESTROYCLIPBOARD message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard.
            /// </summary>
            DESTROYCLIPBOARD = 0x0307,

            /// <summary>
            /// The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard.
            /// </summary>
            DRAWCLIPBOARD = 0x0308,

            /// <summary>
            /// The WM_PAINTCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area needs repainting.
            /// </summary>
            PAINTCLIPBOARD = 0x0309,

            /// <summary>
            /// The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the scroll bar values.
            /// </summary>
            VSCROLLCLIPBOARD = 0x030A,

            /// <summary>
            /// The WM_SIZECLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area has changed size.
            /// </summary>
            SIZECLIPBOARD = 0x030B,

            /// <summary>
            /// The WM_ASKCBFORMATNAME message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
            /// </summary>
            ASKCBFORMATNAME = 0x030C,

            /// <summary>
            /// The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
            /// </summary>
            CHANGECBCHAIN = 0x030D,

            /// <summary>
            /// The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the clipboard image and update the scroll bar values.
            /// </summary>
            HSCROLLCLIPBOARD = 0x030E,

            /// <summary>
            /// This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus.
            /// </summary>
            QUERYNEWPALETTE = 0x030F,

            /// <summary>
            /// The WM_PALETTEISCHANGING message informs applications that an application is going to realize its logical palette.
            /// </summary>
            PALETTEISCHANGING = 0x0310,

            /// <summary>
            /// This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette.
            /// This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
            /// </summary>
            PALETTECHANGED = 0x0311,

            /// <summary>
            /// The WM_HOTKEY message is posted when the user presses a hot key registered by the RegisterHotKey function. The message is placed at the top of the message queue associated with the thread that registered the hot key.
            /// </summary>
            HOTKEY = 0x0312,

            /// <summary>
            /// The WM_PRINT message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
            /// </summary>
            PRINT = 0x0317,

            /// <summary>
            /// The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
            /// </summary>
            PRINTCLIENT = 0x0318,

            /// <summary>
            /// The WM_APPCOMMAND message notifies a window that the user generated an application command event, for example, by clicking an application command button using the mouse or typing an application command key on the keyboard.
            /// </summary>
            APPCOMMAND = 0x0319,

            /// <summary>
            /// The WM_THEMECHANGED message is broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
            /// </summary>
            THEMECHANGED = 0x031A,

            /// <summary>
            /// Sent when the contents of the clipboard have changed.
            /// </summary>
            CLIPBOARDUPDATE = 0x031D,

            /// <summary>
            /// The system will send a window the WM_DWMCOMPOSITIONCHANGED message to indicate that the availability of desktop composition has changed.
            /// </summary>
            DWMCOMPOSITIONCHANGED = 0x031E,

            /// <summary>
            /// WM_DWMNCRENDERINGCHANGED is called when the non-client area rendering status of a window has changed. Only windows that have set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will get this message.
            /// </summary>
            DWMNCRENDERINGCHANGED = 0x031F,

            /// <summary>
            /// Sent to all top-level windows when the colorization color has changed.
            /// </summary>
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,

            /// <summary>
            /// WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
            /// </summary>
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

            /// <summary>
            /// Sent to request extended title bar information. A window receives this message through its WindowProc function.
            /// </summary>
            GETTITLEBARINFOEX = 0x033F,

            HANDHELDFIRST = 0x0358,
            HANDHELDLAST = 0x035F,
            AFXFIRST = 0x0360,
            AFXLAST = 0x037F,
            PENWINFIRST = 0x0380,
            PENWINLAST = 0x038F,

            /// <summary>
            /// The WM_APP constant is used by applications to help define private messages, usually of the form WM_APP+X, where X is an integer value.
            /// </summary>
            APP = 0x8000,

            /// <summary>
            /// The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value.
            /// </summary>
            USER = 0x0400,

            /// <summary>
            /// An application sends the WM_CPL_LAUNCH message to Windows Control Panel to request that a Control Panel application be started.
            /// </summary>
            CPL_LAUNCH = USER + 0x1000,

            /// <summary>
            /// The WM_CPL_LAUNCHED message is sent when a Control Panel application, started by the WM_CPL_LAUNCH message, has closed. The WM_CPL_LAUNCHED message is sent to the window identified by the wParam parameter of the WM_CPL_LAUNCH message that started the application.
            /// </summary>
            CPL_LAUNCHED = USER + 0x1001,

            /// <summary>
            /// WM_SYSTIMER is a well-known yet still undocumented message. Windows uses WM_SYSTIMER for internal actions like scrolling.
            /// </summary>
            SYSTIMER = 0x118
        }

        #endregion Windows Messages

        #region Threads

        public static class Threads
        {
            [DllImport("kernel32", SetLastError = true)]
            internal static extern void SetLastError(uint dwErrCode);

            [DllImport("kernel32")]
            internal static extern IntPtr GetCurrentThreadId();

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, out IntPtr processId);
        }

        #endregion Threads

        #region SendInput API

        public static class SendInputApi
        {
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern uint SendInput(int nInputs, INPUT[] pInputs, int cbSize);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern uint SendInput(int nInputs, INPUT64[] pInputs, int cbSize);

            [DllImport("user32.dll", SetLastError = false)]
            internal static extern IntPtr GetMessageExtraInfo();

            [DllImport("kernel32")]
            internal static extern uint GetTickCount();

            [DllImport("user32.dll")]
            internal static extern ushort VkKeyScan(char ch);

            [DllImport("user32.dll")]
            internal static extern uint MapVirtualKey(VK uCode, MAPVK uMapType);

            [DllImport("user32.dll")]
            internal static extern uint MapVirtualKeyEx(VK uCode, MAPVK uMapType, IntPtr dwhkl);

            public enum MAPVK : uint
            {
                MAPVK_VK_TO_VSC = 0x00,
                MAPVK_VSC_TO_VK = 0x01,
                MAPVK_VK_TO_CHAR = 0x02,
                MAPVK_VSC_TO_VK_EX = 0x03,
                MAPVK_VK_TO_VSC_EX = 0x04
            }

            internal static KeyEventFlags ConvertFlags(WindowHook.LLKHF flags)
            {
                KeyEventFlags newFlags = KeyEventFlags.None;
                if (WinAPI.WindowHook.LLKHF.UP == (WinAPI.WindowHook.LLKHF.UP & flags))
                {
                    newFlags |= KeyEventFlags.KEYEVENTF_KEYUP;
                }
                if (WinAPI.WindowHook.LLKHF.EXTENDED == (WinAPI.WindowHook.LLKHF.EXTENDED & flags))
                {
                    newFlags |= KeyEventFlags.KEYEVENTF_EXTENDEDKEY;
                }
                return newFlags;
            }

            internal static bool IsExtendedKey(VK key)
            {
                /* http://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx
                 * The extended-key flag indicates whether the keystroke message originated from one
                 * of the additional keys on the enhanced keyboard. The extended keys consist of the
                 * ALT and CTRL keys on the right-hand side of the keyboard; the INS, DEL, HOME, END,
                 * PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
                 * the NUM LOCK key; the BREAK (CTRL+PAUSE) key; the PRINT SCRN key; and the divide (/)
                 * and ENTER keys in the numeric keypad. The extended-key flag is set if the key is an
                 * extended key.
                 */
                return (key == VK.Menu || key == VK.RightMenu ||
                    key == VK.Control || key == VK.RightControl ||
                    key == VK.Insert || key == VK.Delete || key == VK.Home || key == VK.End ||
                    key == VK.Prior || key == VK.Next ||
                    key == VK.Left || key == VK.Right || key == VK.Up || key == VK.Down ||
                    key == VK.NumLock || key == VK.Cancel || key == VK.Snapshot ||
                    key == VK.Divide);
            }

            internal static void MouseActionViaSendInput(WinAPI.WindowHook.MSLLHOOKSTRUCT hookStruct, int X, int Y)
            {
                MouseActionViaSendInput((MouseEventFlags)hookStruct.flags, hookStruct.time, X, Y, hookStruct.mouseData);
            }

            internal static void MouseActionViaSendInput(MouseEventFlags flags, uint time, int relX, int relY, uint mouseData)
            {
                // NOTE: this code yields strange behavior for mouse-wheel events and when panning a third-person view in most games
                // NOTE: this code also does not appear to perform mouse broadcast as expected
                // NOTE: only retaining this code for reference in the event someone can correct the misbehaviors, or in case there is ever a game that will only respect INPUT and not WM for mouse
                uint result = 0;
                if (IntPtr.Size == 8)
                {
                    INPUT64[] input = new INPUT64[1];
                    input[0].InputType = InputType.INPUT_MOUSE;
                    input[0].mi.dwExtraInfo = GetMessageExtraInfo();
                    input[0].mi.Flags = flags;
                    input[0].mi.time = GetTickCount();
                    input[0].mi.dx = (int)relX;
                    input[0].mi.dy = (int)relY;
                    input[0].mi.mouseData = mouseData;
                    result = SendInput(1, input, Marshal.SizeOf(input[0]));
                }
                else
                {
                    INPUT[] input = new INPUT[1];
                    input[0].InputType = InputType.INPUT_MOUSE;
                    input[0].mi.dwExtraInfo = GetMessageExtraInfo();
                    input[0].mi.Flags = flags;
                    input[0].mi.time = GetTickCount();
                    input[0].mi.dx = (int)relX;
                    input[0].mi.dy = (int)relY;
                    input[0].mi.mouseData = mouseData;
                    result = SendInput(1, input, Marshal.SizeOf(input[0]));
                }
                if (result == 0)
                {
                    int err = Marshal.GetLastWin32Error();
                    ("SendInput(mi) Blocked, 0x" + err.ToString("X")).Log();
                }
            }

            public enum InputType : int
            {
                INPUT_MOUSE = 0,
                INPUT_KEYBOARD = 1,
                INPUT_HARDWARE = 2
            }

            [Flags]
            public enum KeyEventFlags : uint
            {
                None = 0,
                KEYEVENTF_EXTENDEDKEY = 0x0001,
                KEYEVENTF_KEYUP = 0x0002,
                KEYEVENTF_UNICODE = 0x0004,
                KEYEVENTF_SCANCODE = 0x0008
            }

            internal const uint XBUTTON1 = 0x0001;
            internal const uint XBUTTON2 = 0x0002;

            [Flags]
            public enum MouseEventFlags : uint
            {
                NotSet = 0,
                MOUSEEVENTF_MOVE = 0x0001,
                MOUSEEVENTF_LEFTDOWN = 0x0002,
                MOUSEEVENTF_LEFTUP = 0x0004,
                MOUSEEVENTF_RIGHTDOWN = 0x0008,
                MOUSEEVENTF_RIGHTUP = 0x0010,
                MOUSEEVENTF_MIDDLEDOWN = 0x0020,
                MOUSEEVENTF_MIDDLEUP = 0x0040,
                MOUSEEVENTF_XDOWN = 0x0080,
                MOUSEEVENTF_XUP = 0x0100,
                MOUSEEVENTF_WHEEL = 0x0800,
                MOUSEEVENTF_HWHEEL = 0x1000,
                MOUSEEVENTF_VIRTUALDESK = 0x4000,
                MOUSEEVENTF_ABSOLUTE = 0x8000
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT
            {
                [FieldOffset(0)]
                internal InputType InputType;

                [FieldOffset(4)]
                internal KEYBDINPUT ki;

                [FieldOffset(4)]
                internal MOUSEINPUT mi;

                [FieldOffset(4)]
                internal HARDWAREINPUT hi;

                public override string ToString()
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{0}={1} ", "x86 InputType", InputType);
                    switch (InputType)
                    {
                        case InputType.INPUT_MOUSE:
                            sb.Append(mi.ToString());
                            break;

                        case InputType.INPUT_KEYBOARD:
                            sb.Append(ki.ToString());
                            break;

                        case InputType.INPUT_HARDWARE:
                            sb.Append(hi.ToString());
                            break;

                        default:
                            break;
                    }
                    return sb.ToString();
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT64
            {
                [FieldOffset(0)]
                internal InputType InputType;

                [FieldOffset(8)] // TODO: verify this offset
                internal KEYBDINPUT ki;

                [FieldOffset(8)]
                internal MOUSEINPUT mi;

                [FieldOffset(8)]
                internal HARDWAREINPUT hi;

                public override string ToString()
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{0}={1} ", "x64 InputType", InputType);
                    switch (InputType)
                    {
                        case InputType.INPUT_MOUSE:
                            sb.Append(mi.ToString());
                            break;

                        case InputType.INPUT_KEYBOARD:
                            sb.Append(ki.ToString());
                            break;

                        case InputType.INPUT_HARDWARE:
                            sb.Append(hi.ToString());
                            break;

                        default:
                            break;
                    }
                    return sb.ToString();
                }
            }

            [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable", Justification = "struct is not responsible for deallocation")]
            [StructLayout(LayoutKind.Sequential)]
            public struct MOUSEINPUT
            {
                internal int dx;
                internal int dy;
                internal uint mouseData;
                internal MouseEventFlags Flags;
                internal uint time;
                internal IntPtr dwExtraInfo;

                public override string ToString()
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{0}={1} ", "dx", dx);
                    sb.AppendFormat("{0}={1} ", "dy", dy);
                    sb.AppendFormat("{0}={1:X} ", "mouseData", mouseData);
                    sb.AppendFormat("{0}={1:X} ", "Flags", Flags);
                    sb.AppendFormat("{0}={1} ", "time", time);
                    sb.AppendFormat("{0}={1} ", "dwExtraInfo", dwExtraInfo);
                    return sb.ToString();
                }
            }

            [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable", Justification = "struct is not responsible for deallocation")]
            [StructLayout(LayoutKind.Sequential)]
            public struct KEYBDINPUT
            {
                internal ushort VirtualKey;
                internal ushort wScan;
                internal KeyEventFlags Flags;
                internal uint time;
                internal IntPtr dwExtraInfo;

                public override string ToString()
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{0}={1} ", "VirtualKey", VirtualKey);
                    sb.AppendFormat("{0}={1:X} ", "wScan", wScan);
                    sb.AppendFormat("{0}={1:X} ", "Flags", Flags);
                    sb.AppendFormat("{0}={1} ", "time", time);
                    sb.AppendFormat("{0}={1} ", "dwExtraInfo", dwExtraInfo);
                    return sb.ToString();
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HARDWAREINPUT
            {
                internal int uMsg;
                internal short wParamL;
                internal short wParamH;

                public override string ToString()
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{0}={1} ", "uMsg", uMsg);
                    sb.AppendFormat("{0}={1:X} ", "wParamL", wParamL);
                    sb.AppendFormat("{0}={1} ", "wParamH", wParamH);
                    return sb.ToString();
                }
            }
        }

        #endregion SendInput API

        #region SystemParameters

        public static class SystemParameters
        {
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, IntPtr pvParam, SPIF fWinIni);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, String pvParam, SPIF fWinIni);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref ANIMATIONINFO pvParam, SPIF fWinIni);

            /// <summary>
            /// SPI_ System-wide parameter - Used in SystemParametersInfo function
            /// </summary>
            public enum SPI : uint
            {
                /// <summary>
                /// Determines whether the warning beeper is on.
                /// The pvParam parameter must point to a BOOL variable that receives TRUE if the beeper is on, or FALSE if it is off.
                /// </summary>
                SPI_GETBEEP = 0x0001,

                /// <summary>
                /// Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
                /// </summary>
                SPI_SETBEEP = 0x0002,

                /// <summary>
                /// Retrieves the two mouse threshold values and the mouse speed.
                /// </summary>
                SPI_GETMOUSE = 0x0003,

                /// <summary>
                /// Sets the two mouse threshold values and the mouse speed.
                /// </summary>
                SPI_SETMOUSE = 0x0004,

                /// <summary>
                /// Retrieves the border multiplier factor that determines the width of a window's sizing border.
                /// The pvParam parameter must point to an integer variable that receives this value.
                /// </summary>
                SPI_GETBORDER = 0x0005,

                /// <summary>
                /// Sets the border multiplier factor that determines the width of a window's sizing border.
                /// The uiParam parameter specifies the new value.
                /// </summary>
                SPI_SETBORDER = 0x0006,

                /// <summary>
                /// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second)
                /// through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from
                /// a linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
                /// </summary>
                SPI_GETKEYBOARDSPEED = 0x000A,

                /// <summary>
                /// Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0
                /// (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second).
                /// The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%.
                /// If uiParam is greater than 31, the parameter is set to 31.
                /// </summary>
                SPI_SETKEYBOARDSPEED = 0x000B,

                /// <summary>
                /// Not implemented.
                /// </summary>
                SPI_LANGDRIVER = 0x000C,

                /// <summary>
                /// Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view.
                /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON.
                /// To retrieve this value, pvParam must point to an integer that receives the current value.
                /// </summary>
                SPI_ICONHORIZONTALSPACING = 0x000D,

                /// <summary>
                /// Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives the value.
                /// </summary>
                SPI_GETSCREENSAVETIMEOUT = 0x000E,

                /// <summary>
                /// Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds,
                /// that the system must be idle before the screen saver activates.
                /// </summary>
                SPI_SETSCREENSAVETIMEOUT = 0x000F,

                /// <summary>
                /// Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE
                /// if screen saving is enabled, or FALSE otherwise.
                /// </summary>
                SPI_GETSCREENSAVEACTIVE = 0x0010,

                /// <summary>
                /// Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
                /// </summary>
                SPI_SETSCREENSAVEACTIVE = 0x0011,

                /// <summary>
                /// Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable
                /// that receives the granularity.
                /// </summary>
                SPI_GETGRIDGRANULARITY = 0x0012,

                /// <summary>
                /// Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.
                /// </summary>
                SPI_SETGRIDGRANULARITY = 0x0013,

                /// <summary>
                /// Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap,
                /// set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the wallpaper.
                /// Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
                /// </summary>
                SPI_SETDESKWALLPAPER = 0x0014,

                /// <summary>
                /// Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.
                /// </summary>
                SPI_SETDESKPATTERN = 0x0015,

                /// <summary>
                /// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3
                /// (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam parameter must point to an integer variable that receives the setting.
                /// </summary>
                SPI_GETKEYBOARDDELAY = 0x0016,

                /// <summary>
                /// Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay
                /// (approximately 250 ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may
                /// vary depending on the hardware.
                /// </summary>
                SPI_SETKEYBOARDDELAY = 0x0017,

                /// <summary>
                /// Sets or retrieves the height, in pixels, of an icon cell.
                /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CYICON.
                /// To retrieve this value, pvParam must point to an integer that receives the current value.
                /// </summary>
                SPI_ICONVERTICALSPACING = 0x0018,

                /// <summary>
                /// Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE
                /// if enabled, or FALSE otherwise.
                /// </summary>
                SPI_GETICONTITLEWRAP = 0x0019,

                /// <summary>
                /// Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
                /// </summary>
                SPI_SETICONTITLEWRAP = 0x001A,

                /// <summary>
                /// Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item.
                /// The pvParam parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
                /// </summary>
                SPI_GETMENUDROPALIGNMENT = 0x001B,

                /// <summary>
                /// Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
                /// </summary>
                SPI_SETMENUDROPALIGNMENT = 0x001C,

                /// <summary>
                /// Sets the width of the double-click rectangle to the value of the uiParam parameter.
                /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered
                /// as a double-click.
                /// To retrieve the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
                /// </summary>
                SPI_SETDOUBLECLKWIDTH = 0x001D,

                /// <summary>
                /// Sets the height of the double-click rectangle to the value of the uiParam parameter.
                /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered
                /// as a double-click.
                /// To retrieve the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
                /// </summary>
                SPI_SETDOUBLECLKHEIGHT = 0x001E,

                /// <summary>
                /// Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT structure,
                /// and the pvParam parameter must point to the LOGFONT structure to fill in.
                /// </summary>
                SPI_GETICONTITLELOGFONT = 0x001F,

                /// <summary>
                /// Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number
                /// of milliseconds that can occur between the first and second clicks of a double-click. You can also call the SetDoubleClickTime
                /// function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
                /// </summary>
                SPI_SETDOUBLECLICKTIME = 0x0020,

                /// <summary>
                /// Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings
                /// of the buttons, or FALSE to restore their original meanings.
                /// </summary>
                SPI_SETMOUSEBUTTONSWAP = 0x0021,

                /// <summary>
                /// Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure,
                /// and the pvParam parameter must point to a LOGFONT structure.
                /// </summary>
                SPI_SETICONTITLELOGFONT = 0x0022,

                /// <summary>
                /// This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is enabled.
                /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
                /// </summary>
                SPI_GETFASTTASKSWITCH = 0x0023,

                /// <summary>
                /// This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching.
                /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
                /// </summary>
                SPI_SETFASTTASKSWITCH = 0x0024,

                //#if(WINVER >= 0x0400)
                /// <summary>
                /// Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
                /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
                /// </summary>
                SPI_SETDRAGFULLWINDOWS = 0x0025,

                /// <summary>
                /// Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled, or FALSE otherwise.
                /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
                /// </summary>
                SPI_GETDRAGFULLWINDOWS = 0x0026,

                /// <summary>
                /// Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point
                /// to a NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
                /// to sizeof(NONCLIENTMETRICS).
                /// </summary>
                SPI_GETNONCLIENTMETRICS = 0x0029,

                /// <summary>
                /// Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point
                /// to a NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure
                /// and the uiParam parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
                /// </summary>
                SPI_SETNONCLIENTMETRICS = 0x002A,

                /// <summary>
                /// Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
                /// </summary>
                SPI_GETMINIMIZEDMETRICS = 0x002B,

                /// <summary>
                /// Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
                /// </summary>
                SPI_SETMINIMIZEDMETRICS = 0x002C,

                /// <summary>
                /// Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives
                /// the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
                /// </summary>
                SPI_GETICONMETRICS = 0x002D,

                /// <summary>
                /// Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains
                /// the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
                /// </summary>
                SPI_SETICONMETRICS = 0x002E,

                /// <summary>
                /// Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar
                /// or by application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area rectangle,
                /// expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work area
                /// of the monitor that contains the specified rectangle.
                /// </summary>
                SPI_SETWORKAREA = 0x002F,

                /// <summary>
                /// Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured
                /// by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives
                /// the coordinates of the work area, expressed in virtual screen coordinates.
                /// To get the work area of a monitor other than the primary display monitor, call the GetMonitorInfo function.
                /// </summary>
                SPI_GETWORKAREA = 0x0030,

                /// <summary>
                /// Windows Me/98/95:  Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE
                /// when unloading pen windows. The pvParam parameter is null.
                /// </summary>
                SPI_SETPENWINDOWS = 0x0031,

                /// <summary>
                /// Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
                /// For a general discussion, see remarks.
                /// Windows NT:  This value is not supported.
                /// </summary>
                /// <remarks>
                /// There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme changes
                /// the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options in the control panel.
                /// The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to modify their appearance
                /// for visually-impaired users. It involves such things as audible warning to users and customized color scheme
                /// (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN.
                /// For more information on general accessibility features, see Accessibility on MSDN.
                /// </remarks>
                SPI_GETHIGHCONTRAST = 0x0042,

                /// <summary>
                /// Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
                /// Windows NT:  This value is not supported.
                /// </summary>
                SPI_SETHIGHCONTRAST = 0x0043,

                /// <summary>
                /// Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard interfaces
                /// that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if the user relies on the keyboard; or FALSE otherwise.
                /// Windows NT:  This value is not supported.
                /// </summary>
                SPI_GETKEYBOARDPREF = 0x0044,

                /// <summary>
                /// Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse,
                /// and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise.
                /// Windows NT:  This value is not supported.
                /// </summary>
                SPI_SETKEYBOARDPREF = 0x0045,

                /// <summary>
                /// Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output device,
                /// such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual information
                /// in situations where it would otherwise present the information graphically.
                /// The pvParam parameter is a pointer to a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise.
                /// Windows NT:  This value is not supported.
                /// </summary>
                SPI_GETSCREENREADER = 0x0046,

                /// <summary>
                /// Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off.
                /// Windows NT:  This value is not supported.
                /// </summary>
                SPI_SETSCREENREADER = 0x0047,

                /// <summary>
                /// Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
                /// </summary>
                SPI_GETANIMATION = 0x0048,

                /// <summary>
                /// Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
                /// </summary>
                SPI_SETANIMATION = 0x0049,

                /// <summary>
                /// Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear smoother
                /// by painting pixels at different gray levels.
                /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is enabled, or FALSE if it is not.
                /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
                /// </summary>
                SPI_GETFONTSMOOTHING = 0x004A,

                /// <summary>
                /// Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother
                /// by painting pixels at different gray levels.
                /// To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set uiParam to FALSE.
                /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
                /// </summary>
                SPI_SETFONTSMOOTHING = 0x004B,

                /// <summary>
                /// Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value.
                /// To retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
                /// </summary>
                SPI_SETDRAGWIDTH = 0x004C,

                /// <summary>
                /// Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value.
                /// To retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
                /// </summary>
                SPI_SETDRAGHEIGHT = 0x004D,

                /// <summary>
                /// Used internally; applications should not use this value.
                /// </summary>
                SPI_SETHANDHELD = 0x004E,

                /// <summary>
                /// Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer variable
                /// that receives the value. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_GETLOWPOWERTIMEOUT = 0x004F,

                /// <summary>
                /// Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer variable
                /// that receives the value. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_GETPOWEROFFTIMEOUT = 0x0050,

                /// <summary>
                /// Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value.
                /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_SETLOWPOWERTIMEOUT = 0x0051,

                /// <summary>
                /// Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value.
                /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_SETPOWEROFFTIMEOUT = 0x0052,

                /// <summary>
                /// Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_GETLOWPOWERACTIVE = 0x0053,

                /// <summary>
                /// Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_GETPOWEROFFACTIVE = 0x0054,

                /// <summary>
                /// Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate.
                /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_SETLOWPOWERACTIVE = 0x0055,

                /// <summary>
                /// Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate.
                /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
                /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
                /// Windows 95:  This flag is supported for 16-bit applications only.
                /// </summary>
                SPI_SETPOWEROFFACTIVE = 0x0056,

                /// <summary>
                /// Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.
                /// </summary>
                SPI_SETCURSORS = 0x0057,

                /// <summary>
                /// Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.
                /// </summary>
                SPI_SETICONS = 0x0058,

                /// <summary>
                /// Retrieves the input locale identifier for the system default input language. The pvParam parameter must point
                /// to an HKL variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
                /// </summary>
                SPI_GETDEFAULTINPUTLANG = 0x0059,

                /// <summary>
                /// Sets the default input language for the system shell and applications. The specified language must be displayable
                /// using the current system character set. The pvParam parameter must point to an HKL variable that contains
                /// the input locale identifier for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
                /// </summary>
                SPI_SETDEFAULTINPUTLANG = 0x005A,

                /// <summary>
                /// Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used.
                /// The value sets the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" = CTRL+SHIFT, and "3" = none.
                /// </summary>
                SPI_SETLANGTOGGLE = 0x005B,

                /// <summary>
                /// Windows 95:  Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1.
                /// The pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
                /// </summary>
                SPI_GETWINDOWSEXTENSION = 0x005C,

                /// <summary>
                /// Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing
                /// a trail of cursors and quickly erasing them.
                /// To disable the feature, set the uiParam parameter to zero or 1. To enable the feature, set uiParam to a value greater than 1
                /// to indicate the number of cursors drawn in the trail.
                /// Windows 2000/NT:  This value is not supported.
                /// </summary>
                SPI_SETMOUSETRAILS = 0x005D,

                /// <summary>
                /// Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements
                /// by briefly showing a trail of cursors and quickly erasing them.
                /// The pvParam parameter must point to an integer variable that receives a value. If the value is zero or 1, the feature is disabled.
                /// If the value is greater than 1, the feature is enabled and the value indicates the number of cursors drawn in the trail.
                /// The uiParam parameter is not used.
                /// Windows 2000/NT:  This value is not supported.
                /// </summary>
                SPI_GETMOUSETRAILS = 0x005E,

                /// <summary>
                /// Windows Me/98:  Used internally; applications should not use this flag.
                /// </summary>
                SPI_SETSCREENSAVERRUNNING = 0x0061,

                /// <summary>
                /// Same as SPI_SETSCREENSAVERRUNNING.
                /// </summary>
                SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,

                //#endif /* WINVER >= 0x0400 */

                /// <summary>
                /// Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
                /// </summary>
                SPI_GETFILTERKEYS = 0x0032,

                /// <summary>
                /// Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
                /// </summary>
                SPI_SETFILTERKEYS = 0x0033,

                /// <summary>
                /// Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
                /// </summary>
                SPI_GETTOGGLEKEYS = 0x0034,

                /// <summary>
                /// Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
                /// </summary>
                SPI_SETTOGGLEKEYS = 0x0035,

                /// <summary>
                /// Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
                /// </summary>
                SPI_GETMOUSEKEYS = 0x0036,

                /// <summary>
                /// Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
                /// </summary>
                SPI_SETMOUSEKEYS = 0x0037,

                /// <summary>
                /// Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application
                /// to present information visually in situations where it would otherwise present the information only in audible form.
                /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off.
                /// Using this value is equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
                /// </summary>
                SPI_GETSHOWSOUNDS = 0x0038,

                /// <summary>
                /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
                /// </summary>
                SPI_SETSHOWSOUNDS = 0x0039,

                /// <summary>
                /// Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
                /// </summary>
                SPI_GETSTICKYKEYS = 0x003A,

                /// <summary>
                /// Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
                /// </summary>
                SPI_SETSTICKYKEYS = 0x003B,

                /// <summary>
                /// Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point
                /// to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
                /// to sizeof(ACCESSTIMEOUT).
                /// </summary>
                SPI_GETACCESSTIMEOUT = 0x003C,

                /// <summary>
                /// Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT
                /// structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
                /// </summary>
                SPI_SETACCESSTIMEOUT = 0x003D,

                //#if(WINVER >= 0x0400)
                /// <summary>
                /// Windows Me/98/95:  Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point
                /// to a SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
                /// to sizeof(SERIALKEYS).
                /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
                /// </summary>
                SPI_GETSERIALKEYS = 0x003E,

                /// <summary>
                /// Windows Me/98/95:  Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point
                /// to a SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter
                /// to sizeof(SERIALKEYS).
                /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
                /// </summary>
                SPI_SETSERIALKEYS = 0x003F,

                //#endif /* WINVER >= 0x0400 */

                /// <summary>
                /// Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
                /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
                /// </summary>
                SPI_GETSOUNDSENTRY = 0x0040,

                /// <summary>
                /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
                /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
                /// </summary>
                SPI_SETSOUNDSENTRY = 0x0041,

                //#if(_WIN32_WINNT >= 0x0400)
                /// <summary>
                /// Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves
                /// to the default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE if the feature is on, or FALSE if it is off.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETSNAPTODEFBUTTON = 0x005F,

                /// <summary>
                /// Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default button,
                /// such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable it.
                /// Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse cursor.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETSNAPTODEFBUTTON = 0x0060,

                //#endif /* _WIN32_WINNT >= 0x0400 */

                //#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
                /// <summary>
                /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETMOUSEHOVERWIDTH = 0x0062,

                /// <summary>
                /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETMOUSEHOVERWIDTH = 0x0063,

                /// <summary>
                /// Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETMOUSEHOVERHEIGHT = 0x0064,

                /// <summary>
                /// Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. Set the uiParam parameter to the new height.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETMOUSEHOVERHEIGHT = 0x0065,

                /// <summary>
                /// Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETMOUSEHOVERTIME = 0x0066,

                /// <summary>
                /// Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent
                /// to generate a WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to TrackMouseEvent. Set the uiParam parameter to the new time.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETMOUSEHOVERTIME = 0x0067,

                /// <summary>
                /// Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point
                /// to a UINT variable that receives the number of lines. The default value is 3.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETWHEELSCROLLLINES = 0x0068,

                /// <summary>
                /// Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter.
                /// The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys.
                /// If the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines viewable,
                /// and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted
                /// as clicking once in the page down or page up regions of the scroll bar.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETWHEELSCROLLLINES = 0x0069,

                /// <summary>
                /// Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is
                /// over a submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_GETMENUSHOWDELAY = 0x006A,

                /// <summary>
                /// Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is
                /// over a submenu item.
                /// Windows 95:  Not supported.
                /// </summary>
                SPI_SETMENUSHOWDELAY = 0x006B,

                /// <summary>
                /// Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL variable
                /// that receives TRUE if the status window is visible, or FALSE if it is not.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETSHOWIMEUI = 0x006E,

                /// <summary>
                /// Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or FALSE for off.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETSHOWIMEUI = 0x006F,

                //#endif

                //#if(WINVER >= 0x0500)
                /// <summary>
                /// Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse moves.
                /// The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20 (fastest).
                /// A value of 10 is the default. The value can be set by an end user using the mouse control panel application or
                /// by an application using SPI_SETMOUSESPEED.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETMOUSESPEED = 0x0070,

                /// <summary>
                /// Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the default.
                /// This value is typically set using the mouse control panel application.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETMOUSESPEED = 0x0071,

                /// <summary>
                /// Determines whether a screen saver is currently running on the window station of the calling process.
                /// The pvParam parameter must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise.
                /// Note that only the interactive window station, "WinSta0", can have a screen saver running.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETSCREENSAVERRUNNING = 0x0072,

                /// <summary>
                /// Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer
                /// that receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETDESKWALLPAPER = 0x0073,

                //#endif /* WINVER >= 0x0500 */

                //#if(WINVER >= 0x0500)
                /// <summary>
                /// Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must point
                /// to a BOOL variable that receives TRUE for on, or FALSE for off.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETACTIVEWINDOWTRACKING = 0x1000,

                /// <summary>
                /// Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for off.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETACTIVEWINDOWTRACKING = 0x1001,

                /// <summary>
                /// Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects.
                /// The pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled.
                /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETMENUANIMATION = 0x1002,

                /// <summary>
                /// Enables or disables menu animation. This master switch must be on for any menu animation to occur.
                /// The pvParam parameter is a BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation.
                /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETMENUANIMATION = 0x1003,

                /// <summary>
                /// Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE for enabled, or FALSE for disabled.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETCOMBOBOXANIMATION = 0x1004,

                /// <summary>
                /// Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect,
                /// or FALSE to disable it.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETCOMBOBOXANIMATION = 0x1005,

                /// <summary>
                /// Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE for enabled, or FALSE for disabled.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

                /// <summary>
                /// Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the smooth-scrolling effect,
                /// or FALSE to disable it.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

                /// <summary>
                /// Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable
                /// that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor function.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETGRADIENTCAPTIONS = 0x1008,

                /// <summary>
                /// Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to disable it.
                /// The gradient effect is possible only if the system has a color depth of more than 256 colors. For more information about
                /// the gradient effect, see the GetSysColor function.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETGRADIENTCAPTIONS = 0x1009,

                /// <summary>
                /// Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the keyboard.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETKEYBOARDCUES = 0x100A,

                /// <summary>
                /// Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always underline menu
                /// access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETKEYBOARDCUES = 0x100B,

                /// <summary>
                /// Same as SPI_GETKEYBOARDCUES.
                /// </summary>
                SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,

                /// <summary>
                /// Same as SPI_SETKEYBOARDCUES.
                /// </summary>
                SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,

                /// <summary>
                /// Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must point
                /// to a BOOL variable that receives TRUE for on, or FALSE for off.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETACTIVEWNDTRKZORDER = 0x100C,

                /// <summary>
                /// Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE
                /// for on or FALSE for off.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETACTIVEWNDTRKZORDER = 0x100D,

                /// <summary>
                /// Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam parameter
                /// must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled.
                /// Hot tracking means that when the cursor moves over an item, it is highlighted but not selected. You can query this value to decide
                /// whether to use hot tracking in the user interface of your application.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETHOTTRACKING = 0x100E,

                /// <summary>
                /// Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to TRUE
                /// to enable it, or FALSE to disable it.
                /// Hot-tracking means that when the cursor moves over an item, it is highlighted but not selected.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETHOTTRACKING = 0x100F,

                /// <summary>
                /// Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation.
                /// This flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag.
                /// For more information, see AnimateWindow.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETMENUFADE = 0x1012,

                /// <summary>
                /// Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it.
                /// If fade animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system
                /// has a color depth of more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information,
                /// see AnimateWindow.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETMENUFADE = 0x1013,

                /// <summary>
                /// Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled or FALSE if disabled.
                /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out
                /// after the menu is dismissed.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETSELECTIONFADE = 0x1014,

                /// <summary>
                /// Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it.
                /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out
                /// after the menu is dismissed. The selection fade effect is possible only if the system has a color depth of more than 256 colors.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETSELECTIONFADE = 0x1015,

                /// <summary>
                /// Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or slide animation.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETTOOLTIPANIMATION = 0x1016,

                /// <summary>
                /// Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE
                /// to specify fade or slide animation.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETTOOLTIPANIMATION = 0x1017,

                /// <summary>
                /// If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide effect.
                ///  The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide animation.
                ///  For more information on slide and fade effects, see AnimateWindow.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETTOOLTIPFADE = 0x1018,

                /// <summary>
                /// If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade effect
                /// or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is possible only
                /// if the system has a color depth of more than 256 colors. For more information on the slide and fade effects,
                /// see the AnimateWindow function.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETTOOLTIPFADE = 0x1019,

                /// <summary>
                /// Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256 colors.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETCURSORSHADOW = 0x101A,

                /// <summary>
                /// Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the shadow
                /// or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETCURSORSHADOW = 0x101B,

                //#if(_WIN32_WINNT >= 0x0501)
                /// <summary>
                /// Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_GETMOUSESONAR = 0x101C,

                /// <summary>
                /// Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse pointer
                /// when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off.
                /// For more information, see About Mouse Input.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_SETMOUSESONAR = 0x101D,

                /// <summary>
                /// Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled, or FALSE otherwise. For more information, see About Mouse Input.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_GETMOUSECLICKLOCK = 0x101E,

                /// <summary>
                /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button
                /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies
                /// TRUE for on,
                /// or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_SETMOUSECLICKLOCK = 0x101F,

                /// <summary>
                /// Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_GETMOUSEVANISH = 0x1020,

                /// <summary>
                /// Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears
                /// when the user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off.
                /// For more information, see About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_SETMOUSEVANISH = 0x1021,

                /// <summary>
                /// Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable
                /// that returns TRUE if the flat menu appearance is set, or FALSE otherwise.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETFLATMENU = 0x1022,

                /// <summary>
                /// Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance
                /// or FALSE to disable it.
                /// When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup background, COLOR_MENUHILIGHT
                /// for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current menu selection.
                /// If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETFLATMENU = 0x1023,

                /// <summary>
                /// Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE
                /// if enabled or FALSE if disabled.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETDROPSHADOW = 0x1024,

                /// <summary>
                /// Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it.
                /// You must also have CS_DROPSHADOW in the window class style.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETDROPSHADOW = 0x1025,

                /// <summary>
                /// Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function
                /// to simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if the simulated input will be blocked, or FALSE otherwise.
                /// </summary>
                SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

                /// <summary>
                /// Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard
                /// or mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input,
                /// or FALSE if the screensaver will be deactivated by simulated input.
                /// </summary>
                SPI_SETBLOCKSENDINPUTRESETS = 0x1027,

                //#endif /* _WIN32_WINNT >= 0x0501 */

                /// <summary>
                /// Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE
                /// if all UI effects are enabled, or FALSE if they are disabled.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETUIEFFECTS = 0x103E,

                /// <summary>
                /// Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI effects.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETUIEFFECTS = 0x103F,

                /// <summary>
                /// Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications
                /// to force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

                /// <summary>
                /// Sets the amount of time following user input, in milliseconds, during which the system does not allow applications
                /// to force themselves into the foreground. Set pvParam to the new timeout value.
                /// The calling thread must be able to change the foreground window, otherwise the call fails.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

                /// <summary>
                /// Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable
                /// that receives the time.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

                /// <summary>
                /// Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window
                /// under the mouse pointer.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

                /// <summary>
                /// Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request.
                /// The pvParam parameter must point to a DWORD variable that receives the value.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

                /// <summary>
                /// Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request.
                /// Set pvParam to the number of times to flash.
                /// Windows NT, Windows 95:  This value is not supported.
                /// </summary>
                SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

                /// <summary>
                /// Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETCARETWIDTH = 0x2006,

                /// <summary>
                /// Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
                /// Windows NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETCARETWIDTH = 0x2007,

                //#if(_WIN32_WINNT >= 0x0501)
                /// <summary>
                /// Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives
                /// the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_GETMOUSECLICKLOCKTIME = 0x2008,

                /// <summary>
                /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button
                /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter
                /// specifies TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
                /// Windows 2000/NT, Windows 98/95:  This value is not supported.
                /// </summary>
                SPI_SETMOUSECLICKLOCKTIME = 0x2009,

                /// <summary>
                /// Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETFONTSMOOTHINGTYPE = 0x200A,

                /// <summary>
                /// Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD,
                /// if standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD.
                /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise,
                /// SystemParametersInfo fails.
                /// </summary>
                SPI_SETFONTSMOOTHINGTYPE = 0x200B,

                /// <summary>
                /// Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT
                /// that receives the information.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

                /// <summary>
                /// Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value.
                /// Valid contrast values are from 1000 to 2200. The default value is 1400.
                /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise,
                /// SystemParametersInfo fails.
                /// SPI_SETFONTSMOOTHINGTYPE must also be set to FE_FONTSMOOTHINGCLEARTYPE.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

                /// <summary>
                /// Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect.
                /// The pvParam parameter must point to a UINT.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETFOCUSBORDERWIDTH = 0x200E,

                /// <summary>
                /// Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETFOCUSBORDERWIDTH = 0x200F,

                /// <summary>
                /// Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect.
                /// The pvParam parameter must point to a UINT.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_GETFOCUSBORDERHEIGHT = 0x2010,

                /// <summary>
                /// Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
                /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
                /// </summary>
                SPI_SETFOCUSBORDERHEIGHT = 0x2011,

                /// <summary>
                /// Not implemented.
                /// </summary>
                SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

                /// <summary>
                /// Not implemented.
                /// </summary>
                SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
            }

            [Flags]
            public enum SPIF
            {
                None = 0x00,

                /// <summary>Writes the new system-wide parameter setting to the user profile.</summary>
                SPIF_UPDATEINIFILE = 0x01,

                /// <summary>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</summary>
                SPIF_SENDCHANGE = 0x02,

                /// <summary>Same as SPIF_SENDCHANGE.</summary>
                SPIF_SENDWININICHANGE = 0x02
            }

            /// <summary>
            /// ANIMATIONINFO specifies animation effects associated with user actions.
            /// Used with SystemParametersInfo when SPI_GETANIMATION or SPI_SETANIMATION action is specified.
            /// </summary>
            /// <remark>
            /// The uiParam value must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)) when using this structure.
            /// </remark>
            [StructLayout(LayoutKind.Sequential)]
            public struct ANIMATIONINFO
            {
                /// <summary>
                /// Creates an AMINMATIONINFO structure.
                /// </summary>
                /// <param name="iMinAnimate">If non-zero and SPI_SETANIMATION is specified, enables minimize/restore animation.</param>
                internal ANIMATIONINFO(System.Int32 iMinAnimate)
                {
                    this.cbSize = (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO));
                    this.iMinAnimate = iMinAnimate;
                }

                /// <summary>
                /// Always must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)).
                /// </summary>
                internal System.UInt32 cbSize;

                /// <summary>
                /// If non-zero, minimize/restore animation is enabled, otherwise disabled.
                /// </summary>
                internal System.Int32 iMinAnimate;
            }
        }

        #endregion SystemParameters

        #region KeyState

        /// <summary>
        /// <para>BEWARE: Async Key State is said to be shared over all TIQs, and is thus not 'only representative' of the 'active TIQ'.</para>
        /// </summary>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern KeyState GetAsyncKeyState(VK vk);

        public enum KeyState : ushort
        {
            Not = 0x0000,
            Was = 0x0001,
            Toggled = Was,
            Is = 0x8000
        }

        internal static bool IsPressed(VK vk)
        {
            return (KeyState.Is == (KeyState.Is & GetAsyncKeyState(vk)));
        }

        internal static bool IsToggled(VK vk)
        {
            return (KeyState.Toggled == (KeyState.Toggled & GetKeyState(vk)));
        }

        [DllImport("user32.dll")]
        private static extern KeyState GetKeyState(VK vk);

        [DllImport("user32.dll")]
        internal static extern bool SetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        internal static extern bool GetKeyboardState(byte[] lpKeyState);

        #endregion KeyState

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Beep(uint dwFreq, uint dwDuration);

        #region Isolation

        [System.Security.SuppressUnmanagedCodeSecurity]
        public static class IsolationApi
        {
            #region WinAPI

            private const uint FSCTL_SET_REPARSE_POINT = 0x000900a4;

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            private struct MountPointReparseData
            {
                internal ReparseTagType ReparseTag;
                internal ushort ReparseDataLength;
                internal ushort Reserved;
                internal ushort SubstituteNameOffset;
                internal ushort SubstituteNameLength;
                internal ushort PrintNameOffset;
                internal ushort PrintNameLength;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x3FF0)]
                internal byte[] PathBuffer;
            }

            [DllImport("kernel32", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool DeviceIoControl(
                IntPtr hDevice,
                uint dwIoControlCode,
                IntPtr lpInBuffer,
                int nInBufferSize,
                IntPtr lpOutBuffer,
                int nOutBufferSize,
                out uint lpBytesReturned,
                IntPtr lpOverlapped);

            [DllImport("kernel32", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
            private static extern IntPtr CreateFile(
                  string lpFileName,
                  EFileAccess dwDesiredAccess,
                  EFileShare dwShareMode,
                  IntPtr SecurityAttributes,
                  ECreationDisposition dwCreationDisposition,
                  EFileAttributes dwFlagsAndAttributes,
                  IntPtr hTemplateFile
                  );

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(IntPtr hObject);

            [Flags]
            private enum EFileAccess : uint
            {
                /// <summary>
                ///
                /// </summary>
                GenericRead = 0x80000000,

                /// <summary>
                ///
                /// </summary>
                GenericWrite = 0x40000000,

                /// <summary>
                ///
                /// </summary>
                GenericExecute = 0x20000000,

                /// <summary>
                ///
                /// </summary>
                GenericAll = 0x10000000
            }

            [Flags]
            private enum EFileShare : uint
            {
                /// <summary>
                ///
                /// </summary>
                None = 0x00000000,

                /// <summary>
                /// Enables subsequent open operations on an object to request read access.
                /// Otherwise, other processes cannot open the object if they request read access.
                /// If this flag is not specified, but the object has been opened for read access, the function fails.
                /// </summary>
                Read = 0x00000001,

                /// <summary>
                /// Enables subsequent open operations on an object to request write access.
                /// Otherwise, other processes cannot open the object if they request write access.
                /// If this flag is not specified, but the object has been opened for write access, the function fails.
                /// </summary>
                Write = 0x00000002,

                /// <summary>
                /// Enables subsequent open operations on an object to request delete access.
                /// Otherwise, other processes cannot open the object if they request delete access.
                /// If this flag is not specified, but the object has been opened for delete access, the function fails.
                /// </summary>
                Delete = 0x00000004
            }

            private enum ECreationDisposition : uint
            {
                /// <summary>
                /// Creates a new file. The function fails if a specified file exists.
                /// </summary>
                New = 1,

                /// <summary>
                /// Creates a new file, always.
                /// If a file exists, the function overwrites the file, clears the existing attributes, combines the specified file attributes,
                /// and flags with FILE_ATTRIBUTE_ARCHIVE, but does not set the security descriptor that the SECURITY_ATTRIBUTES structure specifies.
                /// </summary>
                CreateAlways = 2,

                /// <summary>
                /// Opens a file. The function fails if the file does not exist.
                /// </summary>
                OpenExisting = 3,

                /// <summary>
                /// Opens a file, always.
                /// If a file does not exist, the function creates a file as if dwCreationDisposition is CREATE_NEW.
                /// </summary>
                OpenAlways = 4,

                /// <summary>
                /// Opens a file and truncates it so that its size is 0 (zero) bytes. The function fails if the file does not exist.
                /// The calling process must open the file with the GENERIC_WRITE access right.
                /// </summary>
                TruncateExisting = 5
            }

            [Flags]
            private enum EFileAttributes : uint
            {
                Readonly = 0x00000001,
                Hidden = 0x00000002,
                System = 0x00000004,
                Directory = 0x00000010,
                Archive = 0x00000020,
                Device = 0x00000040,
                Normal = 0x00000080,
                Temporary = 0x00000100,
                SparseFile = 0x00000200,
                ReparsePoint = 0x00000400,
                Compressed = 0x00000800,
                Offline = 0x00001000,
                NotContentIndexed = 0x00002000,
                Encrypted = 0x00004000,
                Write_Through = 0x80000000,
                Overlapped = 0x40000000,
                NoBuffering = 0x20000000,
                RandomAccess = 0x10000000,
                SequentialScan = 0x08000000,
                DeleteOnClose = 0x04000000,
                BackupSemantics = 0x02000000,
                PosixSemantics = 0x01000000,
                OpenReparsePoint = 0x00200000,
                OpenNoRecall = 0x00100000,
                FirstPipeInstance = 0x00080000
            }

            private enum ReparseTagType : uint
            {
                IO_REPARSE_TAG_MOUNT_POINT = (0xA0000003),
                IO_REPARSE_TAG_HSM = (0xC0000004),
                IO_REPARSE_TAG_SIS = (0x80000007),
                IO_REPARSE_TAG_DFS = (0x8000000A),
                IO_REPARSE_TAG_SYMLINK = (0xA000000C),
                IO_REPARSE_TAG_DFSR = (0x80000012),
            }

            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool CreateHardLink(string lpFileName, string lpExistingFileName,
               IntPtr lpSecurityAttributes);

            #endregion WinAPI

            internal static void CreateFile(string junctionPath, string sourcePath)
            {
                string junctionFolder = System.IO.Path.GetFullPath(junctionPath).Replace(System.IO.Path.GetFileName(junctionPath), "");
                if (!System.IO.Directory.Exists(junctionFolder))
                {
                    System.IO.Directory.CreateDirectory(junctionFolder);
                }
                bool result = CreateHardLink(junctionPath, sourcePath, IntPtr.Zero);
                if (!result)
                {
                    int w32err = Marshal.GetLastWin32Error();
                    if (w32err > 0)
                    {
                        throw new System.ComponentModel.Win32Exception(w32err);
                    }
                }
            }

            internal static void CreateFolder(string junctionPath, string sourcePath)
            {
                string sourcePathInternal = "\\??\\" + sourcePath;
                if (!sourcePathInternal.EndsWith("\\"))
                {
                    sourcePathInternal += "\\";
                }
                ushort sourcePathInternalByteCount = (ushort)(sourcePathInternal.Length * 2);

                MountPointReparseData reparseDataBuffer = new MountPointReparseData();
                reparseDataBuffer.PathBuffer = new byte[0x3FF0];
                reparseDataBuffer.ReparseTag = ReparseTagType.IO_REPARSE_TAG_MOUNT_POINT;
                reparseDataBuffer.ReparseDataLength = (ushort)(sourcePathInternalByteCount + 12);
                reparseDataBuffer.PrintNameOffset = (ushort)(sourcePathInternalByteCount + 2);
                reparseDataBuffer.PrintNameLength = 0;
                reparseDataBuffer.SubstituteNameOffset = 0;
                reparseDataBuffer.SubstituteNameLength = (ushort)(sourcePathInternalByteCount);
                System.Text.UnicodeEncoding.Unicode.GetBytes(sourcePathInternal, 0, sourcePathInternal.Length, reparseDataBuffer.PathBuffer, 0);

                int reparseDataBufferPointerSize = 65535;
                IntPtr reparseDataBufferPointer = Marshal.AllocHGlobal(reparseDataBufferPointerSize);
                try
                {
                    IntPtr fileHandle = IntPtr.Zero;
                    Marshal.StructureToPtr(reparseDataBuffer, reparseDataBufferPointer, false);
                    System.IO.DirectoryInfo junctionDirectoryInfo = System.IO.Directory.CreateDirectory(junctionPath);
                    try
                    {
                        fileHandle = CreateFile(
                            junctionPath,
                            EFileAccess.GenericRead | EFileAccess.GenericWrite,
                            EFileShare.None,
                            IntPtr.Zero,
                            ECreationDisposition.OpenExisting,
                            EFileAttributes.BackupSemantics | EFileAttributes.OpenReparsePoint,
                            IntPtr.Zero);

                        int w32err = Marshal.GetLastWin32Error();

                        if ((fileHandle == IntPtr.Zero) || (w32err != 0))
                        {
                            throw new System.ComponentModel.Win32Exception(w32err);
                        }

                        uint cb;
                        DeviceIoControl(
                            fileHandle,
                            FSCTL_SET_REPARSE_POINT,
                            reparseDataBufferPointer,
                            reparseDataBuffer.ReparseDataLength + sizeof(uint) + sizeof(ushort) + sizeof(ushort),
                            IntPtr.Zero,
                            0,
                            out cb,
                            IntPtr.Zero);

                        w32err = Marshal.GetLastWin32Error();
                        if (w32err != 0)
                        {
                            if (fileHandle != IntPtr.Zero)
                            {
                                System.IO.Directory.Delete(junctionPath, false);
                            }
                            throw new System.ComponentModel.Win32Exception(w32err);
                        }
                    }
                    finally
                    {
                        if (fileHandle != IntPtr.Zero)
                        {
                            CloseHandle(fileHandle);
                        }
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(reparseDataBufferPointer);
                }
            }
        }

        #endregion Isolation

        #region Code Page

        public static class CodePage
        {
            internal static byte[] ConvertToCodePage(string text, uint codePageId)
            {
                int lenA = WideCharToMultiByte(
                    codePageId,
                    WC_COMPOSITECHECK,
                    text,
                    text.Length,
                    null,
                    0,
                    IntPtr.Zero,
                    IntPtr.Zero);
                byte[] outputBytes = new byte[lenA];
                int res = WideCharToMultiByte(
                    codePageId,
                    0,
                    text,
                    text.Length,
                    outputBytes,
                    outputBytes.Length,
                    IntPtr.Zero,
                    IntPtr.Zero);
                return outputBytes;
            }

            private const uint WC_COMPOSITECHECK = 0x00000200; // convert composite to precomposed

            [DllImport("kernel32")]
            private static extern int WideCharToMultiByte(
                uint CodePage,
                uint dwFlags,
                [MarshalAs(UnmanagedType.LPWStr)] string lpWideCharStr,
                int cchWideChar,
                [MarshalAs(UnmanagedType.LPArray)] Byte[] lpMultiByteStr,
                int cbMultiByte,
                IntPtr lpDefaultChar,
                IntPtr usedDefault);
        }

        #endregion Code Page

        #region Sandbox

        public static class SandboxApi
        {
            // TODO: sand-boxing should be a "per-game" option

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct SYSTEM_HANDLE_INFORMATION
            {
                public int Count;
                public SYSTEM_HANDLE[] Handles;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct SYSTEM_HANDLE
            {
                public int ProcessID;
                public byte ObjectType;
                public byte HandleFlags;
                public ushort HandleValue;
                public IntPtr ObjectPointer;
                public uint AccessMask;
            }

            [DllImport("ntdll.dll")]
            private static extern NTSTATUS NtQuerySystemInformation(
                SYSTEM_INFORMATION_CLASS SystemInformationClass,
                IntPtr SystemInformation,
                int SystemInformationLength,
                out int ReturnLength
            );

            [DllImport("ntdll.dll")]
            public static extern NTSTATUS NtQueryObject(
                IntPtr Handle,
                OBJECT_INFORMATION_CLASS ObjectInformationClass,
                IntPtr ObjectInformation,
                int ObjectInformationLength,
                out int ReturnLength
            );

            public enum SYSTEM_INFORMATION_CLASS
            {
                SystemHandleInformation = 16,
                SystemHandleInformationEx = 32,
            }

            public enum OBJECT_INFORMATION_CLASS
            {
                ObjectBasicInformation = 0,
                ObjectName = 1, // Undocumented??
                ObjectTypeInformation = 2,
            }

            //[StructLayout(LayoutKind.Sequential)]
            //public struct OBJECT_TYPE_INFORMATION
            //{
            //    [MarshalAs(UnmanagedType.LPWStr)]
            //    public string TypeName;
            //    public int TotalNumberOfObjects;
            //    public int TotalNumberOfHandles;
            //    public int TotalPagedPoolUsage;
            //    public int TotalNonPagedPoolUsage;
            //    public int TotalNamePoolUsage;
            //    public int TotalHandleTableUsage;
            //    public int HighWaterNumberOfObjects;
            //    public int HighWaterNumberOfHandles;
            //    public int HighWaterPagedPoolUsage;
            //    public int HighWaterNonPagedPoolUsage;
            //    public int HighWaterNamePoolUsage;
            //    public int HighWaterHandleTableUsage;
            //    public int InvalidAttributes;
            //    public GENERIC_MAPPING GenericMapping;
            //    public int ValidAccessMask;
            //    [MarshalAs(UnmanagedType.Bool)]
            //    public bool SecurityRequired;
            //    [MarshalAs(UnmanagedType.Bool)]
            //    public bool MaintainHandleCount;
            //    public int PoolType;
            //    public int DefaultPagedPoolCharge;
            //    public int DefaultNonPagedPoolCharge;
            //}

            //[StructLayout(LayoutKind.Sequential)]
            //public struct GENERIC_MAPPING
            //{
            //    uint GenericRead;
            //    uint GenericWrite;
            //    uint GenericExecute;
            //    uint GenericAll;
            //}
            /// <summary>
            /// A NT status value.
            /// </summary>
            public enum NTSTATUS : uint
            {
                // Success
                Success = 0x00000000,

                Wait0 = 0x00000000,
                Wait1 = 0x00000001,
                Wait2 = 0x00000002,
                Wait3 = 0x00000003,
                Wait63 = 0x0000003f,
                Abandoned = 0x00000080,
                AbandonedWait0 = 0x00000080,
                AbandonedWait1 = 0x00000081,
                AbandonedWait2 = 0x00000082,
                AbandonedWait3 = 0x00000083,
                AbandonedWait63 = 0x000000bf,
                UserApc = 0x000000c0,
                KernelApc = 0x00000100,
                Alerted = 0x00000101,
                Timeout = 0x00000102,
                Pending = 0x00000103,
                Reparse = 0x00000104,
                MoreEntries = 0x00000105,
                NotAllAssigned = 0x00000106,
                SomeNotMapped = 0x00000107,
                OpLockBreakInProgress = 0x00000108,
                VolumeMounted = 0x00000109,
                RxActCommitted = 0x0000010a,
                NotifyCleanup = 0x0000010b,
                NotifyEnumDir = 0x0000010c,
                NoQuotasForAccount = 0x0000010d,
                PrimaryTransportConnectFailed = 0x0000010e,
                PageFaultTransition = 0x00000110,
                PageFaultDemandZero = 0x00000111,
                PageFaultCopyOnWrite = 0x00000112,
                PageFaultGuardPage = 0x00000113,
                PageFaultPagingFile = 0x00000114,
                CrashDump = 0x00000116,
                ReparseObject = 0x00000118,
                NothingToTerminate = 0x00000122,
                ProcessNotInJob = 0x00000123,
                ProcessInJob = 0x00000124,
                ProcessCloned = 0x00000129,
                FileLockedWithOnlyReaders = 0x0000012a,
                FileLockedWithWriters = 0x0000012b,

                // Informational
                Informational = 0x40000000,

                ObjectNameExists = 0x40000000,
                ThreadWasSuspended = 0x40000001,
                WorkingSetLimitRange = 0x40000002,
                ImageNotAtBase = 0x40000003,
                RegistryRecovered = 0x40000009,

                // Warning
                Warning = 0x80000000,

                GuardPageViolation = 0x80000001,
                DatatypeMisalignment = 0x80000002,
                Breakpoint = 0x80000003,
                SingleStep = 0x80000004,
                BufferOverflow = 0x80000005,
                NoMoreFiles = 0x80000006,
                HandlesClosed = 0x8000000a,
                PartialCopy = 0x8000000d,
                DeviceBusy = 0x80000011,
                InvalidEaName = 0x80000013,
                EaListInconsistent = 0x80000014,
                NoMoreEntries = 0x8000001a,
                LongJump = 0x80000026,
                DllMightBeInsecure = 0x8000002b,

                // Error
                Error = 0xc0000000,

                Unsuccessful = 0xc0000001,
                NotImplemented = 0xc0000002,
                InvalidInfoClass = 0xc0000003,
                InfoLengthMismatch = 0xc0000004,
                AccessViolation = 0xc0000005,
                InPageError = 0xc0000006,
                PagefileQuota = 0xc0000007,
                InvalidHandle = 0xc0000008,
                BadInitialStack = 0xc0000009,
                BadInitialPc = 0xc000000a,
                InvalidCid = 0xc000000b,
                TimerNotCanceled = 0xc000000c,
                InvalidParameter = 0xc000000d,
                NoSuchDevice = 0xc000000e,
                NoSuchFile = 0xc000000f,
                InvalidDeviceRequest = 0xc0000010,
                EndOfFile = 0xc0000011,
                WrongVolume = 0xc0000012,
                NoMediaInDevice = 0xc0000013,
                NoMemory = 0xc0000017,
                NotMappedView = 0xc0000019,
                UnableToFreeVm = 0xc000001a,
                UnableToDeleteSection = 0xc000001b,
                IllegalInstruction = 0xc000001d,
                AlreadyCommitted = 0xc0000021,
                AccessDenied = 0xc0000022,
                BufferTooSmall = 0xc0000023,
                ObjectTypeMismatch = 0xc0000024,
                NonContinuableException = 0xc0000025,
                BadStack = 0xc0000028,
                NotLocked = 0xc000002a,
                NotCommitted = 0xc000002d,
                InvalidParameterMix = 0xc0000030,
                ObjectNameInvalid = 0xc0000033,
                ObjectNameNotFound = 0xc0000034,
                ObjectNameCollision = 0xc0000035,
                ObjectPathInvalid = 0xc0000039,
                ObjectPathNotFound = 0xc000003a,
                ObjectPathSyntaxBad = 0xc000003b,
                DataOverrun = 0xc000003c,
                DataLate = 0xc000003d,
                DataError = 0xc000003e,
                CrcError = 0xc000003f,
                SectionTooBig = 0xc0000040,
                PortConnectionRefused = 0xc0000041,
                InvalidPortHandle = 0xc0000042,
                SharingViolation = 0xc0000043,
                QuotaExceeded = 0xc0000044,
                InvalidPageProtection = 0xc0000045,
                MutantNotOwned = 0xc0000046,
                SemaphoreLimitExceeded = 0xc0000047,
                PortAlreadySet = 0xc0000048,
                SectionNotImage = 0xc0000049,
                SuspendCountExceeded = 0xc000004a,
                ThreadIsTerminating = 0xc000004b,
                BadWorkingSetLimit = 0xc000004c,
                IncompatibleFileMap = 0xc000004d,
                SectionProtection = 0xc000004e,
                EasNotSupported = 0xc000004f,
                EaTooLarge = 0xc0000050,
                NonExistentEaEntry = 0xc0000051,
                NoEasOnFile = 0xc0000052,
                EaCorruptError = 0xc0000053,
                FileLockConflict = 0xc0000054,
                LockNotGranted = 0xc0000055,
                DeletePending = 0xc0000056,
                CtlFileNotSupported = 0xc0000057,
                UnknownRevision = 0xc0000058,
                RevisionMismatch = 0xc0000059,
                InvalidOwner = 0xc000005a,
                InvalidPrimaryGroup = 0xc000005b,
                NoImpersonationToken = 0xc000005c,
                CantDisableMandatory = 0xc000005d,
                NoLogonServers = 0xc000005e,
                NoSuchLogonSession = 0xc000005f,
                NoSuchPrivilege = 0xc0000060,
                PrivilegeNotHeld = 0xc0000061,
                InvalidAccountName = 0xc0000062,
                UserExists = 0xc0000063,
                NoSuchUser = 0xc0000064,
                GroupExists = 0xc0000065,
                NoSuchGroup = 0xc0000066,
                MemberInGroup = 0xc0000067,
                MemberNotInGroup = 0xc0000068,
                LastAdmin = 0xc0000069,
                WrongPassword = 0xc000006a,
                IllFormedPassword = 0xc000006b,
                PasswordRestriction = 0xc000006c,
                LogonFailure = 0xc000006d,
                AccountRestriction = 0xc000006e,
                InvalidLogonHours = 0xc000006f,
                InvalidWorkstation = 0xc0000070,
                PasswordExpired = 0xc0000071,
                AccountDisabled = 0xc0000072,
                NoneMapped = 0xc0000073,
                TooManyLuidsRequested = 0xc0000074,
                LuidsExhausted = 0xc0000075,
                InvalidSubAuthority = 0xc0000076,
                InvalidAcl = 0xc0000077,
                InvalidSid = 0xc0000078,
                InvalidSecurityDescr = 0xc0000079,
                ProcedureNotFound = 0xc000007a,
                InvalidImageFormat = 0xc000007b,
                NoToken = 0xc000007c,
                BadInheritanceAcl = 0xc000007d,
                RangeNotLocked = 0xc000007e,
                DiskFull = 0xc000007f,
                ServerDisabled = 0xc0000080,
                ServerNotDisabled = 0xc0000081,
                TooManyGuidsRequested = 0xc0000082,
                GuidsExhausted = 0xc0000083,
                InvalidIdAuthority = 0xc0000084,
                AgentsExhausted = 0xc0000085,
                InvalidVolumeLabel = 0xc0000086,
                SectionNotExtended = 0xc0000087,
                NotMappedData = 0xc0000088,
                ResourceDataNotFound = 0xc0000089,
                ResourceTypeNotFound = 0xc000008a,
                ResourceNameNotFound = 0xc000008b,
                ArrayBoundsExceeded = 0xc000008c,
                FloatDenormalOperand = 0xc000008d,
                FloatDivideByZero = 0xc000008e,
                FloatInexactResult = 0xc000008f,
                FloatInvalidOperation = 0xc0000090,
                FloatOverflow = 0xc0000091,
                FloatStackCheck = 0xc0000092,
                FloatUnderflow = 0xc0000093,
                IntegerDivideByZero = 0xc0000094,
                IntegerOverflow = 0xc0000095,
                PrivilegedInstruction = 0xc0000096,
                TooManyPagingFiles = 0xc0000097,
                FileInvalid = 0xc0000098,
                InstanceNotAvailable = 0xc00000ab,
                PipeNotAvailable = 0xc00000ac,
                InvalidPipeState = 0xc00000ad,
                PipeBusy = 0xc00000ae,
                IllegalFunction = 0xc00000af,
                PipeDisconnected = 0xc00000b0,
                PipeClosing = 0xc00000b1,
                PipeConnected = 0xc00000b2,
                PipeListening = 0xc00000b3,
                InvalidReadMode = 0xc00000b4,
                IoTimeout = 0xc00000b5,
                FileForcedClosed = 0xc00000b6,
                ProfilingNotStarted = 0xc00000b7,
                ProfilingNotStopped = 0xc00000b8,
                NotSameDevice = 0xc00000d4,
                FileRenamed = 0xc00000d5,
                CantWait = 0xc00000d8,
                PipeEmpty = 0xc00000d9,
                CantTerminateSelf = 0xc00000db,
                InternalError = 0xc00000e5,
                InvalidParameter1 = 0xc00000ef,
                InvalidParameter2 = 0xc00000f0,
                InvalidParameter3 = 0xc00000f1,
                InvalidParameter4 = 0xc00000f2,
                InvalidParameter5 = 0xc00000f3,
                InvalidParameter6 = 0xc00000f4,
                InvalidParameter7 = 0xc00000f5,
                InvalidParameter8 = 0xc00000f6,
                InvalidParameter9 = 0xc00000f7,
                InvalidParameter10 = 0xc00000f8,
                InvalidParameter11 = 0xc00000f9,
                InvalidParameter12 = 0xc00000fa,
                MappedFileSizeZero = 0xc000011e,
                TooManyOpenedFiles = 0xc000011f,
                Cancelled = 0xc0000120,
                CannotDelete = 0xc0000121,
                InvalidComputerName = 0xc0000122,
                FileDeleted = 0xc0000123,
                SpecialAccount = 0xc0000124,
                SpecialGroup = 0xc0000125,
                SpecialUser = 0xc0000126,
                MembersPrimaryGroup = 0xc0000127,
                FileClosed = 0xc0000128,
                TooManyThreads = 0xc0000129,
                ThreadNotInProcess = 0xc000012a,
                TokenAlreadyInUse = 0xc000012b,
                PagefileQuotaExceeded = 0xc000012c,
                CommitmentLimit = 0xc000012d,
                InvalidImageLeFormat = 0xc000012e,
                InvalidImageNotMz = 0xc000012f,
                InvalidImageProtect = 0xc0000130,
                InvalidImageWin16 = 0xc0000131,
                LogonServer = 0xc0000132,
                DifferenceAtDc = 0xc0000133,
                SynchronizationRequired = 0xc0000134,
                DllNotFound = 0xc0000135,
                IoPrivilegeFailed = 0xc0000137,
                OrdinalNotFound = 0xc0000138,
                EntryPointNotFound = 0xc0000139,
                ControlCExit = 0xc000013a,
                PortNotSet = 0xc0000353,
                DebuggerInactive = 0xc0000354,
                CallbackBypass = 0xc0000503,
                PortClosed = 0xc0000700,
                MessageLost = 0xc0000701,
                InvalidMessage = 0xc0000702,
                RequestCanceled = 0xc0000703,
                RecursiveDispatch = 0xc0000704,
                LpcReceiveBufferExpected = 0xc0000705,
                LpcInvalidConnectionUsage = 0xc0000706,
                LpcRequestsNotAllowed = 0xc0000707,
                ResourceInUse = 0xc0000708,
                ProcessIsProtected = 0xc0000712,
                VolumeDirty = 0xc0000806,
                FileCheckedOut = 0xc0000901,
                CheckOutRequired = 0xc0000902,
                BadFileType = 0xc0000903,
                FileTooLarge = 0xc0000904,
                FormsAuthRequired = 0xc0000905,
                VirusInfected = 0xc0000906,
                VirusDeleted = 0xc0000907,
                TransactionalConflict = 0xc0190001,
                InvalidTransaction = 0xc0190002,
                TransactionNotActive = 0xc0190003,
                TmInitializationFailed = 0xc0190004,
                RmNotActive = 0xc0190005,
                RmMetadataCorrupt = 0xc0190006,
                TransactionNotJoined = 0xc0190007,
                DirectoryNotRm = 0xc0190008,
                CouldNotResizeLog = 0xc0190009,
                TransactionsUnsupportedRemote = 0xc019000a,
                LogResizeInvalidSize = 0xc019000b,
                RemoteFileVersionMismatch = 0xc019000c,
                CrmProtocolAlreadyExists = 0xc019000f,
                TransactionPropagationFailed = 0xc0190010,
                CrmProtocolNotFound = 0xc0190011,
                TransactionSuperiorExists = 0xc0190012,
                TransactionRequestNotValid = 0xc0190013,
                TransactionNotRequested = 0xc0190014,
                TransactionAlreadyAborted = 0xc0190015,
                TransactionAlreadyCommitted = 0xc0190016,
                TransactionInvalidMarshallBuffer = 0xc0190017,
                CurrentTransactionNotValid = 0xc0190018,
                LogGrowthFailed = 0xc0190019,
                ObjectNoLongerExists = 0xc0190021,
                StreamMiniversionNotFound = 0xc0190022,
                StreamMiniversionNotValid = 0xc0190023,
                MiniversionInaccessibleFromSpecifiedTransaction = 0xc0190024,
                CantOpenMiniversionWithModifyIntent = 0xc0190025,
                CantCreateMoreStreamMiniversions = 0xc0190026,
                HandleNoLongerValid = 0xc0190028,
                NoTxfMetadata = 0xc0190029,
                LogCorruptionDetected = 0xc0190030,
                CantRecoverWithHandleOpen = 0xc0190031,
                RmDisconnected = 0xc0190032,
                EnlistmentNotSuperior = 0xc0190033,
                RecoveryNotNeeded = 0xc0190034,
                RmAlreadyStarted = 0xc0190035,
                FileIdentityNotPersistent = 0xc0190036,
                CantBreakTransactionalDependency = 0xc0190037,
                CantCrossRmBoundary = 0xc0190038,
                TxfDirNotEmpty = 0xc0190039,
                IndoubtTransactionsExist = 0xc019003a,
                TmVolatile = 0xc019003b,
                RollbackTimerExpired = 0xc019003c,
                TxfAttributeCorrupt = 0xc019003d,
                EfsNotAllowedInTransaction = 0xc019003e,
                TransactionalOpenNotAllowed = 0xc019003f,
                TransactedMappingUnsupportedRemote = 0xc0190040,
                TxfMetadataAlreadyPresent = 0xc0190041,
                TransactionScopeCallbacksNotSet = 0xc0190042,
                TransactionRequiredPromotion = 0xc0190043,
                CannotExecuteFileInTransaction = 0xc0190044,
                TransactionsNotFrozen = 0xc0190045,

                MaximumNtStatus = 0xffffffff
            }

            [DllImport("kernel32", SetLastError = true)]
            private static extern bool GetProcessHandleCount(
                IntPtr hProcess,
                ref int dwHandleCount);

            /// <summary>
            /// <para>Gets system handle information.</para>
            /// <para>This is not a cheap call.</para>
            /// </summary>
            /// <returns>Managed Copy of a Windows SYSTEM_HANDLE_INFORMATION struct</returns>
            public static SYSTEM_HANDLE_INFORMATION GetSystemHandleInformation()
            {
                var ntstatus = NTSTATUS.InfoLengthMismatch;
                var cbbuf = 0x1000;
                var buf = Marshal.AllocHGlobal(cbbuf);
                try
                {
                    var returnLength = 0;
                    while (ntstatus == NTSTATUS.InfoLengthMismatch)
                    {
                        cbbuf *= 2;
                        buf = Marshal.ReAllocHGlobal(buf, new IntPtr(cbbuf));
                        ntstatus = NtQuerySystemInformation(
                            SYSTEM_INFORMATION_CLASS.SystemHandleInformation,
                            buf,
                            cbbuf,
                            out returnLength);
                    }
                    if (ntstatus != NTSTATUS.Success)
                    {
                        Trace.WriteLine("ntstatus err code: " + ntstatus);
                        return new SYSTEM_HANDLE_INFORMATION
                        {
                            Count = 0,
                            Handles = new SYSTEM_HANDLE[0],
                        };
                    }
                    var systemHandleInformation = new SYSTEM_HANDLE_INFORMATION();
                    systemHandleInformation.Count = Marshal.ReadInt32(buf);
                    systemHandleInformation.Handles = new SYSTEM_HANDLE[systemHandleInformation.Count];
                    var sizeOfSystemHandleEntry = Marshal.SizeOf(typeof(SYSTEM_HANDLE));
                    for (int i = 0; i < systemHandleInformation.Count; i++)
                    {
                        IntPtr ptr = (buf + (4 + (i * sizeOfSystemHandleEntry)));
                        SYSTEM_HANDLE entry = (SYSTEM_HANDLE)Marshal.PtrToStructure(ptr, typeof(SYSTEM_HANDLE));
                        systemHandleInformation.Handles[i] = entry;
                    }
                    return systemHandleInformation;
                }
                finally
                {
                    Marshal.FreeHGlobal(buf);
                }
            }

            [DllImport("kernel32")]
            public static extern IntPtr OpenMutex(
                uint dwDesiredAccess,
                bool bInheritHandle,
               string lpName);

            [DllImport("kernel32")]
            public static extern bool ReleaseMutex(
                IntPtr hMutex);

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DuplicateHandle(
                IntPtr hSourceProcessHandle,
                IntPtr hSourceHandle,
                IntPtr hTargetProcessHandle,
                out IntPtr lpTargetHandle,
                uint dwDesiredAccess,
                [MarshalAs(UnmanagedType.Bool)]
                bool bInheritHandle,
                uint dwOptions);

            public const UInt32 DUPLICATE_CLOSE_SOURCE = 1;
            public const UInt32 DUPLICATE_SAME_ACCESS = 2;

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(IntPtr hObject);

            private const UInt32 DELETE = 0x00010000;
            private const UInt32 READ_CONTROL = 0x00020000;
            private const UInt32 SYNCHRONIZE = 0x00100000;
            private const UInt32 WRITE_DAC = 0x00040000;
            private const UInt32 WRITE_OWNER = 0x00080000;
            private const UInt32 MUTEX_ALL_ACCESS = 0x1F0001;
            private const UInt32 MUTEX_MODIFY_STATE = 0x0001;

            /// <summary>
            /// Method which attempts to 'fix' anything which prevents us from multi-launching and sandboxing a process.
            /// </summary>
            public static void TryFixMultilaunch(Process process)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (CloseNamedMutexes(process, new string[]
                    {
                        "PoERun",
                        "AN-Mutex",
                        "AN-Mutex-Window-Guild Wars 2",
                        "AN-Mutex-Install-101",
                        // TODO: move list to config
                    })) break;
                    System.Threading.Thread.Sleep(100);
                }
            }

            public static bool CloseNamedMutexes(Process process, string[] mutexNames)
            {
                var mutexWasClosed = false;

                var processId = process.Id;
                var result = Mubox.WinAPI.SandboxApi.GetSystemHandleInformation();
                var entries = result
                    .Handles
                    .Where(entry =>
                        entry.AccessMask != 0x0012019f /* known issue with hanging file handles (pipes?), which we're not interested in */
                    //&& entry.ProcessID == processId
                    //&& entry.ObjectType == 14 // TODO: is this the correct object type?
                    ).ToList();

                var currentProcessHandle = Process.GetCurrentProcess().Handle;
                foreach (var entry in entries)
                {
                    var handle = new IntPtr(entry.HandleValue);
                    IntPtr hDupe;
                    var duped = DuplicateHandle(
                        process.Handle,
                        handle,
                        currentProcessHandle,
                        out hDupe,
                        0,
                        false,
                        DUPLICATE_SAME_ACCESS);
                    int err = Marshal.GetLastWin32Error();
                    //("pid=" + entry.ProcessID + " handle=0x" + handle.ToInt64().ToString("X") + " type=" + entry.ObjectType + " err=0x" + err.ToString("X")).Log();
                    //if (err == 0)
                    {
                        if (duped && hDupe != IntPtr.Zero)
                        {
                            var ntstatus = NTSTATUS.InfoLengthMismatch;
                            var cbbuf = 1024;
                            var buf = Marshal.AllocHGlobal(cbbuf);
                            try
                            {
                                var returnLength = 0;
                                while (ntstatus == NTSTATUS.InfoLengthMismatch)
                                {
                                    cbbuf *= 2;
                                    buf = Marshal.ReAllocHGlobal(buf, new IntPtr(cbbuf));
                                    ntstatus = NtQueryObject(
                                        hDupe,
                                        OBJECT_INFORMATION_CLASS.ObjectName,
                                        buf,
                                        cbbuf,
                                        out returnLength);
                                }
                                if (ntstatus == NTSTATUS.Success)
                                {
                                    var typeName = Marshal.PtrToStringUni(buf + 4);
                                    if (!string.IsNullOrEmpty(typeName))
                                    {
                                        //("pid=" + entry.ProcessID + " handle=0x" + handle.ToInt64().ToString("X") + " type=" + entry.ObjectType + " name=" + typeName).Log();
                                        // if in list of mutexes, close it
                                        if (mutexNames.Count(s => typeName.Contains(s)) > 0)
                                        {
                                            IntPtr hClose;
                                            var closed = DuplicateHandle(
                                                process.Handle,
                                                handle,
                                                currentProcessHandle,
                                                out hClose,
                                                0,
                                                false,
                                                DUPLICATE_SAME_ACCESS | DUPLICATE_CLOSE_SOURCE);
                                            if (closed)
                                            {
                                                CloseHandle(hClose);
                                                ("Closed Remote Handle: pid=" + process.Id + " handle=" + handle.ToInt64().ToString("X") + " status=" + ntstatus + " type=" + entry.ObjectType + " name=" + typeName).Log();
                                                mutexWasClosed = true;
                                            }
                                            else
                                            {
                                                ("Failed to Closed Remote Handle: pid=" + process.Id + " handle=" + handle.ToInt64().ToString("X") + " status=" + ntstatus + " type=" + entry.ObjectType + " name=" + typeName).Log();
                                            }
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                Marshal.FreeHGlobal(buf);
                            }

                            CloseHandle(hDupe);
                        }
                    }
                }

                return mutexWasClosed;
            }

            /*
             * Interactions with Win32 Job Objects
             * CreateProcessWithLogonW executes the new process as a child of the Secondary Logon service, which
             * has the outcome of making the process escape any Job Object membership/restrictions even if the
             * Job Object did not allow breakaway.
             *
             * Furthermore, the Secondary Logon service automatically creates its own new Job Object and assigns
             * the new process into it.  As such, it is not possible for the caller to explicitly assign the new
             * process to any other Job Object (since a process may only be assigned to one Job Object, and can
             * never be removed from a Job Object once it has been assigned to one).
             * */

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool CreateProcessWithLogonW(
               String userName,
               String domain,
               String password,
               LogonFlags logonFlags,
               String applicationName,
               String commandLine,
               CreationFlags creationFlags,
               UInt32 environment,
               String currentDirectory,
               ref STARTUPINFO startupInfo,
               out PROCESS_INFORMATION processInformation);

            [Flags]
            private enum CreationFlags
            {
                CREATE_SUSPENDED = 0x00000004,
                DETACHED_PROCESS = 0x00000008,
                CREATE_NEW_CONSOLE = 0x00000010,
                CREATE_NEW_PROCESS_GROUP = 0x00000200,
                CREATE_UNICODE_ENVIRONMENT = 0x00000400,
                CREATE_SEPARATE_WOW_VDM = 0x00000800,
                CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            }

            [Flags]
            private enum LogonFlags
            {
                LOGON_WITH_PROFILE = 0x00000001,
                LOGON_NETCREDENTIALS_ONLY = 0x00000002
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct STARTUPINFO
            {
                public Int32 cb;
                public string lpReserved;
                public string lpDesktop;
                public string lpTitle;
                public Int32 dwX;
                public Int32 dwY;
                public Int32 dwXSize;
                public Int32 dwYSize;
                public Int32 dwXCountChars;
                public Int32 dwYCountChars;
                public Int32 dwFillAttribute;
                public Int32 dwFlags;
                public Int16 wShowWindow;
                public Int16 cbReserved2;
                public IntPtr lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public int dwProcessId;
                public int dwThreadId;
            }

            private enum NET_API_STATUS : uint
            {
                NERR_Success = 0,

                /// <summary>
                /// This computer name is invalid.
                /// </summary>
                NERR_InvalidComputer = 2351,

                /// <summary>
                /// This operation is only allowed on the primary domain controller of the domain.
                /// </summary>
                NERR_NotPrimary = 2226,

                /// <summary>
                /// This operation is not allowed on this special group.
                /// </summary>
                NERR_SpeGroupOp = 2234,

                /// <summary>
                /// This operation is not allowed on the last administrative account.
                /// </summary>
                NERR_LastAdmin = 2452,

                /// <summary>
                /// The password parameter is invalid.
                /// </summary>
                NERR_BadPassword = 2203,

                /// <summary>
                /// The password does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements.
                /// </summary>
                NERR_PasswordTooShort = 2245,

                /// <summary>
                /// The user name could not be found.
                /// </summary>
                NERR_UserNotFound = 2221,

                ERROR_ACCESS_DENIED = 5,
                ERROR_NOT_ENOUGH_MEMORY = 8,
                ERROR_INVALID_PARAMETER = 87,
                ERROR_INVALID_NAME = 123,
                ERROR_INVALID_LEVEL = 124,
                ERROR_MORE_DATA = 234,
                ERROR_SESSION_CREDENTIAL_CONFLICT = 1219
            }

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, PreserveSig = true)]
            private static extern uint LookupAccountName(
                string lpSystemName,
                string lpAccountName,
                byte[] psid,
                ref int cbsid,
                StringBuilder domainName,
                ref int cbdomainLength,
                out int use);

            [DllImport("advapi32.dll")]
            private static extern bool LogonUser(
                String lpszUsername,
                String lpszDomain,
                String lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                ref IntPtr phToken);

            [DllImport("advapi32.dll")]
            private static extern bool DuplicateToken(
                IntPtr ExistingTokenHandle,
                int ImpersonationLevel,
                ref IntPtr DuplicateTokenHandle);

            [DllImport("userenv.dll", CharSet = CharSet.Auto)]
            private static extern int CreateProfile(
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszUserSid,
                [MarshalAs(UnmanagedType.LPWStr)]
                string pszUserName,
                [Out][MarshalAs(UnmanagedType.LPWStr)]
                StringBuilder pszProfilePath,
                uint cchProfilePath);

            [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern NET_API_STATUS NetUserAdd(
                //[MarshalAs(UnmanagedType.LPWStr)]
                //string servername,
                IntPtr specifyNull,
                int level,
                ref USER_INFO_1 userInfo,
                out UInt32 parm_err);

            //uiPriv
            private const uint USER_PRIV_GUEST = 0;

            private const uint USER_PRIV_USER = 1;
            private const uint USER_PRIV_ADMIN = 2;

            //uiFlags (flags)
            private const uint UF_DONT_EXPIRE_PASSWD = 0x10000;

            private const uint UF_MNS_LOGON_ACCOUNT = 0x20000;
            private const uint UF_SMARTCARD_REQUIRED = 0x40000;
            private const uint UF_TRUSTED_FOR_DELEGATION = 0x80000;
            private const uint UF_NOT_DELEGATED = 0x100000;
            private const uint UF_USE_DES_KEY_ONLY = 0x200000;
            private const uint UF_DONT_REQUIRE_PREAUTH = 0x400000;
            private const uint UF_PASSWORD_EXPIRED = 0x800000;
            private const uint UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x1000000;
            private const uint UF_NO_AUTH_DATA_REQUIRED = 0x2000000;
            private const uint UF_PARTIAL_SECRETS_ACCOUNT = 0x4000000;
            private const uint UF_USE_AES_KEYS = 0x8000000;

            //uiFlags (choice)
            private const uint UF_TEMP_DUPLICATE_ACCOUNT = 0x0100;

            private const uint UF_NORMAL_ACCOUNT = 0x0200;
            private const uint UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800;
            private const uint UF_WORKSTATION_TRUST_ACCOUNT = 0x1000;
            private const uint UF_SERVER_TRUST_ACCOUNT = 0x2000;

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct USER_INFO_1
            {
                [MarshalAs(UnmanagedType.LPWStr)]
                public string sUsername;

                [MarshalAs(UnmanagedType.LPWStr)]
                public string sPassword;

                public uint uiPasswordAge;
                public uint uiPriv;

                [MarshalAs(UnmanagedType.LPWStr)]
                public string sHome_Dir;

                [MarshalAs(UnmanagedType.LPWStr)]
                public string sComment;

                public uint uiFlags;

                [MarshalAs(UnmanagedType.LPWStr)]
                public string sScript_Path;
            }

            public class Sandbox
            {
                public string UserName { get; internal set; }

                public string Password { get; internal set; }

                public string SID { get; internal set; }

                public Process Process { get; set; }
            }

            // NOTE: may have a problem with cleaning these up
            public static WinAPI.SandboxApi.Sandbox SafeCreateSandbox(string username, string password)
            {
                var sandbox = new Sandbox
                {
                    UserName = /*"Mbx" + */ (username.Length > 20
                        ? username.Substring(0, 20)
                        : username),
                    Password = password,
                };

                var exists = DoesSandboxExist(sandbox);

                // if user account not exists, create it
                if (!exists)
                {
                    // create user account: NetUserAdd
                    var userInfoLevel1 = new USER_INFO_1
                    {
                        sPassword = sandbox.Password,
                        sUsername = sandbox.UserName,
                        uiPriv = USER_PRIV_USER,
                        uiFlags = UF_NORMAL_ACCOUNT,
                    };
                    uint parm_err;
                    var netApiStatus = NetUserAdd(IntPtr.Zero, 1, ref userInfoLevel1, out parm_err);
                    if (netApiStatus != NET_API_STATUS.NERR_Success)
                    {
                        var reason = "NetUserAdd failed for '" + username + "' reason " + netApiStatus;
                        Console.Error.WriteLine(reason);
                        throw new Exception(reason);
                    }

                    // create profile
                    SafeLoadSID(sandbox);
                    int MAX_PATH = 260;
                    StringBuilder pathBuf = new StringBuilder(MAX_PATH);
                    uint pathLen = (uint)pathBuf.Capacity;
                    int result = CreateProfile(sandbox.SID, sandbox.UserName, pathBuf, pathLen);
                }

                return sandbox;
            }

            private static bool DoesSandboxExist(Sandbox sandbox)
            {
                // check if account already exists
                /* does not work as-is:

                int use = 0;
                byte[] sid = new byte[28];
                int cbsid = sid.Length;
                var domain = new StringBuilder(260);
                int dnl = domain.Length;
                var lookupResult = LookupAccountName(
                    null,
                    sandbox.UserName,
                    sid,
                    ref cbsid,
                    null,
                    ref dnl,
                    out use);

                ("err=" + Marshal.GetLastWin32Error()).Log();
                ^ always 0

                 *
                 */

                // TODO: do a better job
                var exists = SafeLoadSID(sandbox);
                return exists;
            }

            private static bool SafeLoadSID(Sandbox sandbox)
            {
                /* see also:
                 * ConvertSidToStringSid
                 * ConvertStringSidToSid
                 * */
                try
                {
                    if (string.IsNullOrEmpty(sandbox.SID))
                    {
                        // get sid: .NET
                        var acct = new NTAccount(sandbox.UserName);
                        var si = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));
                        if (si == null)
                        {
                            return false;
                        }
                        sandbox.SID = si.ToString();
                    }
                }
                catch
                {
                    return false;
                }

                return true;
            }

            public static Process LaunchProcess(
                WinAPI.SandboxApi.Sandbox sandbox,
                string applicationPath,
                string commandLine,
                string workingDirectory)
            {
                if (sandbox.Process != null)
                {
                    return sandbox.Process;
                }

                var startupInfo = new STARTUPINFO
                {
                    cb = Marshal.SizeOf(typeof(STARTUPINFO)),
                };

                var processInformation = new PROCESS_INFORMATION
                {
                };

                var result = CreateProcessWithLogonW(
                    sandbox.UserName,
                    string.IsNullOrEmpty(Environment.UserDomainName)
                        ? Environment.MachineName
                        : Environment.UserDomainName,
                    sandbox.Password,
                    LogonFlags.LOGON_WITH_PROFILE,
                    applicationPath,
                    commandLine,
                    CreationFlags.CREATE_NEW_CONSOLE,
                    (uint)0,
                    workingDirectory,
                    ref startupInfo,
                    out processInformation);

                if (!result)
                {
                    ("CreateProcessWithLogonW failed with err 0x" + Marshal.GetLastWin32Error().ToString("X")).LogCritical();
                }

                sandbox.Process = result
                    ? Process.GetProcessById(processInformation.dwProcessId)
                    : null;

                var processHandle = sandbox.Process.Handle;

                sandbox.Process.Exited += (s, e) =>
                    {
                        // !!!
                    };

                return sandbox.Process;
            }

            [DllImport("userenv", SetLastError = true)]
            private static extern int DeleteProfile(
                string lpSidString,
                string lpProfilePath,
                string lpComputerName);

            [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern NET_API_STATUS NetUserDel(
                string servername,
                string username);

            // TODO: nothing is calling this
            // TODO: sandboxing should be a profile-level option
            public static void SafeDestroySandbox(WinAPI.SandboxApi.Sandbox sandbox)
            {
                SafeLoadSID(sandbox);

                // delete profile
                DeleteProfile(sandbox.SID, null, null);

                // delete user account
                NetUserDel(null, sandbox.UserName);
            }
        }

        #endregion Sandbox

        #region Toolhelp32

        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        public static class Toolhelp32
        {
            [Flags]
            public enum SnapshotFlags : uint
            {
                None = 0x0,
                HeapList = 0x00000001,
                Process = 0x00000002,
                Thread = 0x00000004,
                Module = 0x00000008,
                Module32 = 0x00000010,
                Inherit = 0x80000000,
                NoHeaps = 0x40000000,
                All = (HeapList | Process | Thread | Module),
            }

            [StructLayout(LayoutKind.Sequential, Pack = 8)]
            public struct PROCESSENTRY32
            {
                /*
                [FieldOffset(8)]
                public uint dwSize;
                [FieldOffset(16)]
                public uint cntUsage;
                [FieldOffset(24)]
                public uint th32ProcessID;
                [FieldOffset(32)]
                public IntPtr th32DefaultHeapID;
                [FieldOffset(40)]
                public uint th32ModuleID;
                [FieldOffset(48)]
                public uint cntThreads;
                [FieldOffset(56)]
                public uint th32ParentProcessID;
                [FieldOffset(64)]
                public int pcPriClassBase;
                [FieldOffset(72)]
                public uint dwFlags;

                [FieldOffset(80)]
                public IntPtr szExeFile;
                 */

                public IntPtr dwSize;

                public IntPtr cntUsage;

                public IntPtr th32ProcessID;

                public IntPtr th32DefaultHeapID;

                public IntPtr th32ModuleID;

                public IntPtr cntThreads;

                public IntPtr th32ParentProcessID;

                public IntPtr pcPriClassBase;

                public IntPtr dwFlags;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 520)]
                public byte[] szExeFile;

                public static PROCESSENTRY32 Create()
                {
                    return new PROCESSENTRY32
                    {
                        dwSize = new IntPtr(Marshal.SizeOf(typeof(PROCESSENTRY32))),
                        szExeFile = new byte[520],
                    };
                }
            };

            [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            internal static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, [In]UInt32 th32ProcessID);

            [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            internal static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

            [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            internal static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

            [DllImport("kernel32", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(IntPtr hObject);

            public static IEnumerable<Process> GetChildProcesses(int pid)
            {
                var children = new List<Process>();
                var handleToSnapshot = IntPtr.Zero;
                try
                {
                    WinAPI.Threads.SetLastError(0);
                    handleToSnapshot = WinAPI.Toolhelp32.CreateToolhelp32Snapshot(SnapshotFlags.Process, 0);
                    var err = Marshal.GetLastWin32Error();
                    if (err != 0 || handleToSnapshot == IntPtr.Zero || handleToSnapshot == INVALID_HANDLE_VALUE)
                    {
                        ("Toolhelp32.CreateToolhelp32Snapshot failed err=0x" + err.ToString("X")).LogError();
                        return null;
                    }
                    else
                    {
                        var procEntry = PROCESSENTRY32.Create();
                        if (WinAPI.Toolhelp32.Process32First(handleToSnapshot, ref procEntry))
                        {
                            do
                            {
                                if (pid == procEntry.th32ParentProcessID.ToInt32())
                                {
                                    var child = Process.GetProcessById((int)procEntry.th32ProcessID);
                                    children.Add(child);
                                    //("Toolhelp32.GetChildProcesses " + pid.ToString() + " " + child.Id.ToString() + " " + child.MainWindowHandle.ToString("X") + " " + child.MainWindowTitle).Log();
                                }
                            } while (Process32Next(handleToSnapshot, ref procEntry));
                        }
                        else
                        {
                            //("Toolhelp32.Process32First failed err=0x" + Marshal.GetLastWin32Error().ToString("X")).LogError();
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Log();
                    ("Toolhelp32.GetChildProcesses failed err=0x" + Marshal.GetLastWin32Error().ToString("X")).LogError();
                    return null;
                }
                finally
                {
                    // Must clean up the snapshot object!
                    if (handleToSnapshot != IntPtr.Zero)
                    {
                        CloseHandle(handleToSnapshot);
                    }
                }
                return children.ToArray();
            }
        }

        #endregion Toolhelp32

        [Flags]
        public enum DM : int
        {
            Orientation = 0x1,
            PaperSize = 0x2,
            PaperLength = 0x4,
            PaperWidth = 0x8,
            Scale = 0x10,
            Position = 0x20,
            NUP = 0x40,
            DisplayOrientation = 0x80,
            Copies = 0x100,
            DefaultSource = 0x200,
            PrintQuality = 0x400,
            Color = 0x800,
            Duplex = 0x1000,
            YResolution = 0x2000,
            TTOption = 0x4000,
            Collate = 0x8000,
            FormName = 0x10000,
            LogPixels = 0x20000,
            BitsPerPixel = 0x40000,
            PelsWidth = 0x80000,
            PelsHeight = 0x100000,
            DisplayFlags = 0x200000,
            DisplayFrequency = 0x400000,
            ICMMethod = 0x800000,
            ICMIntent = 0x1000000,
            MediaType = 0x2000000,
            DitherType = 0x4000000,
            PanningWidth = 0x8000000,
            PanningHeight = 0x10000000,
            DisplayFixedOutput = 0x20000000
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            internal const int CCHDEVICENAME = 32;
            internal const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            internal string dmDeviceName;

            internal short dmSpecVersion;
            internal short dmDriverVersion;
            internal short dmSize;
            internal short dmDriverExtra;
            internal DM dmFields;

            internal short dmOrientation;
            internal short dmPaperSize;
            internal short dmPaperLength;
            internal short dmPaperWidth;

            internal short dmScale;
            internal short dmCopies;
            internal short dmDefaultSource;
            internal short dmPrintQuality;
            internal short dmColor;
            internal short dmDuplex;
            internal short dmYResolution;
            internal short dmTTOption;
            internal short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            internal string dmFormName;

            internal short dmLogPixels;
            internal int dmBitsPerPel;    // Declared wrong in the full framework
            internal int dmPelsWidth;
            internal int dmPelsHeight;
            internal int dmDisplayFlags;
            internal int dmDisplayFrequency;

            internal int dmICMMethod;
            internal int dmICMIntent;
            internal int dmMediaType;
            internal int dmDitherType;
            internal int dmReserved1;
            internal int dmReserved2;
            internal int dmPanningWidth;
            internal int dmPanningHeight;

            internal int dmPositionX; // Using a PointL Struct does not work
            internal int dmPositionY;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            internal int nLength;
            internal IntPtr lpSecurityDescriptor;

            [MarshalAs(UnmanagedType.Bool)]
            internal bool bInheritHandle;
        }

        [System.Security.SuppressUnmanagedCodeSecurity]
        public static class Desktop
        {
            // @ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.WIN32COM.v10.en/dllproc/base/createdesktop.htm
            [DllImport("user32.dll", EntryPoint = "CreateDesktop", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern IntPtr CreateDesktop(
                string desktopName,
                string deviceName, // must be null
                IntPtr deviceMode, // must be IntPtr.Zero
                int flags, // use 0
                DESKTOP_ACCESS_MASK accessMask,
                IntPtr attributes);

            // @ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.WIN32COM.v10.en/dllproc/base/closedesktop.htm
            [DllImport("user32.dll", EntryPoint = "CloseDesktop", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseDesktop(
                IntPtr handle);

            // @pinvoke.net
            [Flags]
            public enum DESKTOP_ACCESS_MASK : uint
            {
                DESKTOP_NONE = 0,
                DESKTOP_READOBJECTS = 0x0001,
                DESKTOP_CREATEWINDOW = 0x0002,
                DESKTOP_CREATEMENU = 0x0004,
                DESKTOP_HOOKCONTROL = 0x0008,
                DESKTOP_JOURNALRECORD = 0x0010,
                DESKTOP_JOURNALPLAYBACK = 0x0020,
                DESKTOP_ENUMERATE = 0x0040,
                DESKTOP_WRITEOBJECTS = 0x0080,
                DESKTOP_SWITCHDESKTOP = 0x0100,

                GENERIC_ALL = (DESKTOP_READOBJECTS | DESKTOP_CREATEWINDOW | DESKTOP_CREATEMENU |
                                DESKTOP_HOOKCONTROL | DESKTOP_JOURNALRECORD | DESKTOP_JOURNALPLAYBACK |
                                DESKTOP_ENUMERATE | DESKTOP_WRITEOBJECTS | DESKTOP_SWITCHDESKTOP |
                                STANDARD_ACCESS.STANDARD_RIGHTS_REQUIRED),
            }
        }

        // @WinNT.h
        [Flags]
        public enum STANDARD_ACCESS : uint
        {
            STANDARD_RIGHTS_REQUIRED = 0x000F0000
        }

        public static class MACROS
        {
            internal static ushort GET_KEYSTATE_WPARAM(uint wParam)
            {
                return LOWORD(wParam);
            }

            internal static ushort GET_NCHITTEST_WPARAM(uint wParam)
            {
                return LOWORD(wParam);
            }

            public enum XBUTTONS : ushort
            {
                XBUTTON1 = 1,
                XBUTTON2 = 2
            }

            internal static XBUTTONS GET_XBUTTON_WPARAM(uint wParam)
            {
                return (XBUTTONS)HIWORD(wParam);
            }

            internal static short GET_X_LPARAM(uint lp)
            {
                return (short)LOWORD(lp);
            }

            internal static short GET_Y_LPARAM(uint lp)
            {
                return (short)HIWORD(lp);
            }

            internal static uint MAKEWPARAM(ushort l, ushort h)
            {
                return MAKELONG(l, h);
            }

            internal static uint MAKELPARAM(ushort l, ushort h)
            {
                return MAKELONG(l, h);
            }

            internal static uint MAKELRESULT(ushort l, ushort h)
            {
                return MAKELONG(l, h);
            }

            internal static ushort MAKEWORD(byte a, byte b)
            {
                return (ushort)((ushort)a | (((ushort)b) << 8));
            }

            internal static uint MAKELONG(ushort l, ushort h)
            {
                return ((uint)l) | (((uint)h) << 16);
            }

            internal static uint LODWORD(ulong dq)
            {
                return (uint)dq;
            }

            internal static uint HIDWORD(ulong dq)
            {
                return (uint)(dq >> 32);
            }

            internal static ushort LOWORD(uint dd)
            {
                return (ushort)dd;
            }

            internal static ushort HIWORD(uint dd)
            {
                return (ushort)(dd >> 16);
            }

            internal static byte LOBYTE(ushort dw)
            {
                return (byte)dw;
            }

            internal static byte HIBYTE(ushort dw)
            {
                return (byte)(dw >> 8);
            }
        }
    }
}