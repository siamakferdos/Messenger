using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMessenger.Config
{
    public class AppConfig
    {
        private static string _instanceID = Guid.NewGuid().ToString();

        public static string InstanceName = "New Instance";

        public static string InstanceID { 
            get 
            {
                return _instanceID;
            }  
        }
    }
}
