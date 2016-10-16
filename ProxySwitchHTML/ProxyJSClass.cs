﻿using Newtonsoft.Json;
using ProxySwitchHTML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace ProxySwitchHTML
{
    public class ProxyJSClass
    {
        ProxyModel proxyModel;
        public ProxyJSClass(){
            
        }
        public object GetProxyModel
        {
            get
            {
                using (var request = new HttpRequest())
                {
                    request.UserAgent = Http.ChromeUserAgent();
                    string response = request.Get("http://proxy.am/list/socks.php?t=light&switch").ToString();
                    proxyModel = JsonConvert.DeserializeObject<ProxyModel>(response);
                }
                return JsonConvert.SerializeObject(proxyModel.data);
            }
            
        }
    }
}