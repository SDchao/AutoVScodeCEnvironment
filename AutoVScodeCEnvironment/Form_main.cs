using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoVScodeCEnvironment.Classes;

namespace AutoVScodeCEnvironment
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择您的工程文件夹\n您今后的C语言源码都需要储存在此文件夹内。",
            };
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Visible = false;
                Operation operation = new Operation();
                operation.Start(dialog.SelectedPath,this);
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bilibili.com/video/av52434248");
        }
    }
}
