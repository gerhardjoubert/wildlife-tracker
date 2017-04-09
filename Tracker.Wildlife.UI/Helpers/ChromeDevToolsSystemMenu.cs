using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Planner.UI.Helpers
{
    public enum ChromeDevToolsLocation
    {
        Signature,
        Mail
    }

    static class ChromeDevToolsSystemMenu
    {
        // P/Invoke constants
        public static int WM_SYSCOMMAND = 0x112;
        public static int MF_STRING = 0x0;
        public static int MF_SEPARATOR = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        // ID for the Chrome dev tools item on the system menu
        public static int SYSMENU_CHROME_DEV_TOOLS_SIGNATURE = 0x1;
        public static int SYSMENU_CHROME_DEV_TOOLS_MAIL = 0x2;

        public static void CreateSysMenu(Form form, ChromeDevToolsLocation cdtl)
        {
            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(form.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the Dev Tools menu item
            switch (cdtl)
            {
                case ChromeDevToolsLocation.Signature:
                    AppendMenu(hSysMenu, MF_STRING, SYSMENU_CHROME_DEV_TOOLS_SIGNATURE, "Signature Dev Tools");
                    break;
                case ChromeDevToolsLocation.Mail:
                    AppendMenu(hSysMenu, MF_STRING, SYSMENU_CHROME_DEV_TOOLS_MAIL, "Mail Dev Tools");
                    break;
            }
            
        }
    }
}
