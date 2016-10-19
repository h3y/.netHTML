using Newtonsoft.Json;
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
            using (var request = new HttpRequest())
            {
                request.UserAgent = Http.ChromeUserAgent();
                request.Get("http://proxy.am/api.php?key=oh8jdxakyr");
                string response = request.Get("http://proxy.am/list/socks.php?t=light&switch").ToString();
                proxyModel = JsonConvert.DeserializeObject<ProxyModel>(response);
                Global.LoadProxy = new List<data>(proxyModel.data);
            }
          
        }
        public object GetProxyModel
        {
            get
            {
                return JsonConvert.SerializeObject(Global.LoadProxy);
            }
            
        }
    }
}
