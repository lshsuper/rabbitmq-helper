using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq.helper.tools.option
{
    /// <summary>
    /// rabbitmq配置
    /// </summary>
    public class RabbitMQConfig
    {
        /// <summary>
        /// 心跳时间
        /// </summary>
        public int Heart { get; set; } = 60;
        /// <summary>
        /// 虚拟主机名称
        /// </summary>
        public string VirtualHost { get; set; } = "/";
        public string HostName { get; set; } = "127.0.0.1";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = "guest";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "guest";
        /// <summary>
        /// 是否自动连接
        /// </summary>
        public bool IsAutoConn { get; set; } = true;
        /// <summary>
        /// 连接名称
        /// </summary>
        public string ConnName { get; set; } = "conn_" + Guid.NewGuid().ToString("N");
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; } = 5672;

    }
}
