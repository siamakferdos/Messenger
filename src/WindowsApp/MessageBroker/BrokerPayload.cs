using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Config;

namespace WindowsApp.MessageBroker
{
    internal class BrokerPayload
    {

        public string InstanceID { get; private set; }
        public string InstanceName { get; private set; }
        public string Body { get; private set; }
        public DateTime MessageTime { get; private set; }

        public BrokerPayload(string message)
        {
            InstanceID = AppConfig.InstanceID; 
            InstanceName = AppConfig.InstanceName; 
            MessageTime = DateTime.Now;
            Body = message;
        }
    }
}
