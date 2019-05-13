namespace AutoVScodeCEnvironment
{
    partial class Form_main
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
            this.label = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(21, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(353, 36);
            this.label.TabIndex = 0;
            this.label.Text = "欢迎使用VS code C语言环境一键配置器\r\n该程序会自动为您安装编译器、添加系统环境变量与写入配置文件\r\n你所需要做的就是以管理员权限启动这个应用，再选择个文" +
    "件夹。";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(126, 74);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(161, 40);
            this.button.TabIndex = 1;
            this.button.Text = "已获取管理员权限\r\n开始吧！";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(400, 125);
            this.Controls.Add(this.button);
            this.Controls.Add(this.label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button;
        public System.Windows.Forms.Label label;
    }
}

