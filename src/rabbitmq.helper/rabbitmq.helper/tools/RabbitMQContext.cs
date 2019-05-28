using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rabbitmq.helper.tools;
using rabbitmq.helper.tools.option;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbitmq.helper.tools
{
    /// <summary>
    /// 消息队列上下文（目前粗略实现，陆续将配置完善。。。）
    /// </summary>
    public class RabbitMQContext
    {
        /// <summary>
        /// MQ工厂（主要初始化连接和渠道的）
        /// </summary>
        private readonly RabbitMQFactory _factory;
        public RabbitMQContext()
        {
            _factory = new RabbitMQFactory();
        }

        #region +Basic
        /// <summary>
        ///基础生产
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool BasicPublish(BasicQueueOption option)
        {
            try
            {
                var currentConn = _factory.CreateConn(option.Config);
                using (currentConn)
                {
                    var currentChannel = _factory.CreateChannel(currentConn);
                    using (currentChannel)
                    {
                        currentChannel.QueueDeclare(queue: option.QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                        currentChannel.BasicPublish(exchange: "",
                                     routingKey: option.RoutingKey,
                                     basicProperties: null,
                                     body: Encoding.UTF8.GetBytes(option.Message));

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        /// <summary>
        /// 基础消费
        /// </summary>
        /// <param name="option"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public bool BaiscConsume(BasicQueueOption option, Func<string, bool> func)
        {
            try
            {
                var currentConn = _factory.CreateConn(option.Config);

                var currentChannel = _factory.CreateChannel(currentConn);

                currentChannel.QueueDeclare(queue: option.QueueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
                var consumer = new EventingBasicConsumer(currentChannel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    func.Invoke(message);  //执行业务逻辑
                        };
                currentChannel.BasicConsume(queue: option.QueueName,
                         autoAck: true,
                         consumer: consumer);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region +High
        public bool HighPublish(HighQueueOption option)
        {

            try
            {
                using (var connection = _factory.CreateConn(option.Config))
                using (var channel = _factory.CreateChannel(connection))
                {
                    channel.ExchangeDeclare(exchange: option.ExchangeName, type: option.ExchangeType);


                    var body = Encoding.UTF8.GetBytes(option.Message);
                    channel.BasicPublish(exchange: option.ExchangeName,
                                         routingKey: option.RoutingKey,
                                         basicProperties: null,
                                         body: body);

                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool HighConsume(HighQueueOption option, Func<string, bool> func)
        {

            try
            {
                var connection = _factory.CreateConn(option.Config);
                var channel = _factory.CreateChannel(connection);

                channel.ExchangeDeclare(exchange: option.ExchangeName, type: option.ExchangeType);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: option.ExchangeName,
                                  routingKey: option.RoutingKey);



                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    func.Invoke(message);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

            }
            #endregion
            #region +Common
            public void Close(string conn,string channelName)
        {

        }
        #endregion
    }
}
