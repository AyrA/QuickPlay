using System;
using System.Runtime.InteropServices;

namespace AyrA.UI
{
    /// <summary>
    /// Possible progress bar states
    /// </summary>
    [Flags]
    public enum TaskbarStates
    {
        /// <summary>
        /// Do not show a progress value
        /// </summary>
        NoProgress = 0,
        /// <summary>
        /// Behaves like normal (green)
        /// </summary>
        Indeterminate = 0x1,
        /// <summary>
        /// regular progress bar (green)
        /// </summary>
        Normal = 0x2,
        /// <summary>
        /// Error progress bar (red)
        /// </summary>
        Error = 0x4,
        /// <summary>
        /// paused progress bar (yellow)
        /// </summary>
        Paused = 0x8
    }

    public static class TaskbarProgress
    {
        [ComImportAttribute()]
        [GuidAttribute("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            // ITaskbarList
            [PreserveSig]
            void HrInit();
            [PreserveSig]
            void AddTab(IntPtr hwnd);
            [PreserveSig]
            void DeleteTab(IntPtr hwnd);
            [PreserveSig]
            void ActivateTab(IntPtr hwnd);
            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);

            // ITaskbarList2
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            // ITaskbarList3
            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
            [PreserveSig]
            void SetProgressState(IntPtr hwnd, TaskbarStates state);
        }

        [GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterfaceAttribute(ClassInterfaceType.None)]
        [ComImportAttribute()]
        private class TaskbarInstance
        {
        }

        private static ITaskbarList3 taskbarInstance = (ITaskbarList3)new TaskbarInstance();
        private static bool taskbarSupported = Environment.OSVersion.Version >= new Version(6, 1);

        /// <summary>
        /// Sets the taskbar state
        /// </summary>
        /// <param name="windowHandle">Window handle. Use your main forms Handle property if not known better</param>
        /// <param name="taskbarState">State to set</param>
        public static void SetState(IntPtr windowHandle, TaskbarStates taskbarState)
        {
            if (taskbarSupported) taskbarInstance.SetProgressState(windowHandle, taskbarState);
        }

        /// <summary>
        /// Sets the progress value in the taskbar
        /// </summary>
        /// <param name="windowHandle">Window handle. Use your main forms Handle property if not known better</param>
        /// <param name="progressValue">Value (0 - progressMax)</param>
        /// <param name="progressMax">Value representing 100%</param>
        public static void SetValue(IntPtr windowHandle, double progressValue, double progressMax)
        {
            if (taskbarSupported) taskbarInstance.SetProgressValue(windowHandle, (ulong)progressValue, (ulong)progressMax);
        }
    }
}