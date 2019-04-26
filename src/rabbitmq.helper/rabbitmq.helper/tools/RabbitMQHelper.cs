using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq.helper.tools
{
  public  class RabbitMQHelper
    {
        private static object _lockRabbitMQ = new object();
        private static RabbitMQContext _context;
        /// <summary>
        /// 单例上下文
        /// </summary>
        public static RabbitMQContext Instance
        {
            get
            {
                if (_context != null)
                    return _context;
                lock (_lockRabbitMQ)
                {
                    if (_context != null)
                        return _context;
                    _context = new RabbitMQContext();
                }
                return _context;
            }
        }
    }
}
