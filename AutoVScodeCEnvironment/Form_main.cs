using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using AutoVScodeCEnvironment.Classes;

namespace AutoVScodeCEnvironment
{
    public partial class Form_main : Form
    {
        private float version = 1.6f;
        private Thread updateThread;
        
        public Form_main()
        {
            updateThread = new Thread(() => CheckUpdate());
            updateThread.Start();
            updateThread.IsBackground = true;
            InitializeComponent();

        }

        private void CheckUpdate()
        {
            string url = 
                "https://raw.githubusercontent.com/SDchao/AutoVScodeCEnvironment/master/AutoVScodeCEnvironment/version";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
            request.Timeout = 10000;
            try
            {
                WebResponse response = request.GetResponse();
                Stream stream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                float olVersion = Convert.ToSingle(reader.ReadToEnd());
                response.Close();

                if(olVersion > version)
                {
                    DialogResult result = MessageBox.Show("发现更新版本！是否前往更新？" +
                        "\n当前版本：" + version + 
                        "\n最新版本：" + olVersion,"发现更新",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if(result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start
                            ("https://github.com/SDchao/AutoVScodeCEnvironment/releases");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }     
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
                if (updateThread.ThreadState == ThreadState.Running)
                {
                    updateThread.Interrupt();
                }
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
