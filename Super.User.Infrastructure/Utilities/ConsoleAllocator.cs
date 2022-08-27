using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace Super.User.Infrastructure.Utilities
{
    /// <summary>
    /// ConsoleAllocator Static Object
    /// Used to show and hide console window
    /// </summary>
    [SuppressUnmanagedCodeSecurity]

    public static class ConsoleAllocator
    {
        #region Fields
        /// <summary>
        /// SwHide field
        /// Used to hide console window
        /// </summary>
        /// <value> const integer</value>
        const int SwHide = 0;


        /// <summary>
        /// SwShow field
        /// Used to show console window
        /// </summary>
        /// <value> const integer</value>
        const int SwShow = 5;

        #endregion

        #region DLL Kernel32 Imports
        /// <summary>
        /// AllocConsole DLL Method
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        ///<value> boolean</value>
        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();


        /// <summary>
        /// FreeConsole DLL Method
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        ///<value> boolean</value>
        [DllImport(@"kernel32.dll")]
        private static extern bool FreeConsole();

        /// <summary>
        /// GetConsoleWindow DLL Method
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>The return value is a handle to the window used by the console associated with the calling process or NULL if there is no such associated console.</returns>
        [DllImport(@"kernel32.dll")]
        ///<value> IntPtr</value>
        static extern IntPtr GetConsoleWindow();

        [DllImport(@"user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion

        #region Utility Methods

        /// <summary>
        /// HasConsole Get Accesor property
        /// Determines if the console window is accessed
        /// Returns true if the console window is accessed
        /// </summary>
        /// <value> boolean</value>
        public static bool HasConsole
        {
            get { return GetConsoleWindow() != IntPtr.Zero; }
        }

        /// <summary>
        /// ShowConsoleWindow method
        /// Shows or hides console window
        /// </summary>
        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SwShow);
            }
        }

        /// <summary>
        /// HideConsoleWindow method
        /// Hides console window
        /// </summary>
        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SwHide);
            FreeConsole();
        }
  
    #endregion
     } 
}
