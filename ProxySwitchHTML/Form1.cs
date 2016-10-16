using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace ProxySwitchHTML
{
    public partial class Form1 : Form
    {
        ChromiumWebBrowser m_chromeBrowser = null;
        ProxyJSClass proxyJSClass = null;

        public Form1()
        {
            InitializeComponent();
            var page = new Uri(string.Format("file:///{0}HTML/HTMLPage1.html", GetAppLocation()));
            m_chromeBrowser = new ChromiumWebBrowser(page.ToString());
            proxyJSClass = new ProxyJSClass();
            var x = proxyJSClass.GetProxyModel;
            m_chromeBrowser.RegisterJsObject("winformObj", proxyJSClass);
            panel1.Controls.Add(m_chromeBrowser);
  


        }
        public static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_chromeBrowser.ShowDevTools();
        }
    }
}
