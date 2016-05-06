using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Classes
{
    class Licence
    {
        string mac = "8C89A50F5B06";

        public Licence()
        {
            var macAddr = (from nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                                    where nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up
                                    select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            if (mac.Equals(macAddr.ToString()))
            {
                
            }
        }
    }
}
