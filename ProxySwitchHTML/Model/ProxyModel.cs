using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySwitchHTML.Model
{
    public class ProxyModel
    {
        public List<data> data { get; set; }
    }
    public class data
    {
        public enum ProxyStatus
        {
            question,
            link,
            error,
            success
        }
        public data(ProxyStatus status, string proxy, string ip, string country, string city, int speed, int uptime)
        {
            this.status = status;
            this.proxy = proxy;
            this.ip = ip;
            this.country = country;
            this.city = city;
            this.speed = speed;
            this.uptime = uptime;

        }

        public ProxyStatus status { get; set; }
        public string proxy { get; set; }
        public string ip { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int speed { get; set; }
        public int uptime { get; set; }
    }
}
