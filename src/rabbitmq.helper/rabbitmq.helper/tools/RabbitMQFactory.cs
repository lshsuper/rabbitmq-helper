using rabbitmq.helper.tools.option;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq.helper.tools
{
    public class RabbitMQFactory
    {
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="connName"></param>
        /// <returns></returns>
        public IConnection CreateConn(RabbitMQConfig config)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = config.HostName;
            factory.Password = config.Password;
            factory.Port = config.Port;
            factory.AutomaticRecoveryEnabled = config.IsAutoConn;
            IConnection conn = factory.CreateConnection(config.ConnName);
            return conn;
        }
        /// <summary>
        /// 创建渠道
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IModel CreateChannel(IConnection conn)
        {
            IModel channel = conn.CreateModel();
            return channel;
        }
    }
}
