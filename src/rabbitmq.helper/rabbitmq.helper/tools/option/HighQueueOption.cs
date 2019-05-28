using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq.helper.tools.option
{
   public class HighQueueOption:QueueOption
    {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public Dictionary<string,object> Properties { get; set; }
        public string QueueName { get; set; }
    }
}
