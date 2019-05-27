namespace rabbitmq.helper
{
    partial class client
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send = new System.Windows.Forms.Button();
            this.lv_show = new System.Windows.Forms.ListView();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(92, 122);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // lv_show
            // 
            this.lv_show.Location = new System.Drawing.Point(560, 122);
            this.lv_show.Name = "lv_show";
            this.lv_show.Size = new System.Drawing.Size(338, 361);
            this.lv_show.TabIndex = 1;
            this.lv_show.UseCompatibleStateImageBehavior = false;
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(213, 122);
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(100, 25);
            this.tb_msg.TabIndex = 2;
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.lv_show);
            this.Controls.Add(this.btn_send);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "client";
            this.Text = "client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListView lv_show;
        private System.Windows.Forms.TextBox tb_msg;
    }
}

