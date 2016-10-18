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
using System.Threading;
using ProxySwitchHTML.Model;
using xNet;

namespace ProxySwitchHTML
{
    public partial class Form1 : Form
    {
        ChromiumWebBrowser m_chromeBrowser = null;
        ProxyJSClass proxyJSClass = null;
        private object LocalLocker = new object();
        private int indexProxy = new int();

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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            new Thread(() => Run()) { IsBackground = true }.Start();
        }
        private void Run()
        {
            object obj = LocalLocker;
            lock (obj)
            {
                Global.IsWork = true;
                Global.ThreadPool.Clear();
                indexProxy = 0;
                for (int i = 0; i < Global.CountThread; i++)
                {
                    Global.ThreadPool.Add(new Thread(new ThreadStart(this.AsyncCheckStart)));
                    Global.ThreadPool[i].IsBackground = true;
                    Global.ThreadPool[i].Start();
                }
            }
        }
        private void AsyncCheckStart()
        {
            object obj = LocalLocker;
            while (Global.IsWork)
            {
                try
                {
                    data OneProxy;
                    lock (obj)
                    {
                        OneProxy = Global.LoadProxy[indexProxy];
                    }
                    CheckProxy(OneProxy, indexProxy);
                    Interlocked.Increment(ref indexProxy);
                }
                catch (Exception)
                {
                    if (indexProxy >= Global.LoadProxy.Count)
                    {
                        Global.IsWork = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
        }

        private void CheckProxy(data data, int ind)
        {
            object obj = LocalLocker;
            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    if (data.status == data.ProxyStatus.success) { return; }
                    httpRequest.Proxy = ProxyClient.Parse(ProxyType.Socks5, data.proxy);
                    httpRequest.UserAgent = Http.OperaUserAgent();
                    httpRequest.KeepAlive = false;
                    httpRequest.Get("http://proxy.am/api.php");
                    lock (obj)
                    {
                        m_chromeBrowser.ExecuteScriptAsync(String.Format("ChangeColumn({0},{1});", ind, (int)data.ProxyStatus.success));
                        data.status = data.ProxyStatus.success;
                    }  
                }
            }
            catch (HttpException)
            {
                lock (obj)
                {
                    m_chromeBrowser.ExecuteScriptAsync(String.Format("ChangeColumn({0},{1});", ind, (int)data.ProxyStatus.error));
                    data.status = data.ProxyStatus.error;
                }
            }
        }

    }
}
