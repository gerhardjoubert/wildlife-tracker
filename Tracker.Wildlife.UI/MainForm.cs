using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracker.Wildlife.UI
{
    public partial class MainForm : Form
    {
        #region Properties

        public static ChromiumWebBrowser cwb = null;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitCef();
            InitBrowser();
        }

        #region Cef

        private void InitCef()
        {
            try
            {
                var settings = new CefSettings();
                settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

                Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            }
            catch (Exception e)
            {
                //EventLog.WriteEntry("Kariba Planner", string.Format("{0}{3}{3}{1}{3}{3}{2}", e.Message, e.InnerException, e.StackTrace, Environment.NewLine));
            }
        }

        #endregion

        private void InitBrowser()
        {
            cwb = new ChromiumWebBrowser("");
            cwb.IsBrowserInitializedChanged += new EventHandler<IsBrowserInitializedChangedEventArgs>(cwb_IsBrowserInitializedChanged);
            cwb.Dock = DockStyle.Fill;
            pnlCwb.Controls.Add(cwb);
        }

        private void cwb_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            string page = string.Format(@"{0}\HTMLResources\html\map.html", Application.StartupPath);
            cwb.Load(page);
        }
    }
}
