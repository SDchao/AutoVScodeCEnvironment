namespace AutoVScodeCEnvironment
{
    partial class Form_Process
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.processBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(214, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(77, 12);
            this.label.TabIndex = 0;
            this.label.Text = "正在处理……";
            // 
            // processBar
            // 
            this.processBar.Location = new System.Drawing.Point(12, 38);
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(488, 23);
            this.processBar.TabIndex = 1;
            // 
            // Form_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 74);
            this.ControlBox = false;
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Process";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ProgressBar processBar;
    }
}