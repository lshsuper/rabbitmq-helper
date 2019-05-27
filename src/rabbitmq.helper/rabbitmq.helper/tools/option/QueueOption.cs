using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq.helper.tools.option
{
   public class QueueOption
    {
        public RabbitMQConfig Config { get; set; }
        public string Message { get; set; }
        public QueueOption()
        {
            Config = new RabbitMQConfig();
        }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; } =string.Empty;

    }
}
