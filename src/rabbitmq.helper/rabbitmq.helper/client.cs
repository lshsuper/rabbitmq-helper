using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rabbitmq.helper.tools;
using RabbitMQ.Client;
using RabbitMQ.Client.Impl;

namespace rabbitmq.helper
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //示例
            RabbitMQHelper.Instance.BaiscConsume(new tools.option.BasicQueueOption()
            {
                QueueName = "ceshi9",
                Config = new tools.option.RabbitMQConfig()
                {
                    VirtualHost = "/lsh-blog"
                }
            }, (msg) =>
            {
                BeginInvoke(new Action(()=> {
                    lv_show.Items.Add(msg);
                }));
                 
                return true;
            });
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            RabbitMQHelper.Instance.BasicPublish(new tools.option.BasicQueueOption()
            {
                QueueName = "ceshi9",
                Message = tb_msg.Text,
                RoutingKey="ceshi9",
                Config = new tools.option.RabbitMQConfig()
                {
                    VirtualHost = "/lsh-blog"
                }
            });
        }
    }
}
