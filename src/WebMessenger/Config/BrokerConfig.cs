using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMessenger.Config
{
    internal class BrokerConfig
    {
        public static string HostName = "localhost";
        public static string Exchange = "exchange";
        public static string QueueName = $"queue-{AppConfig.InstanceName}-{AppConfig.InstanceID}";
        public static string RoutingKey = $"routing-{AppConfig.InstanceName}-{AppConfig.InstanceID}";
    }
}
