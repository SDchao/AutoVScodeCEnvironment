using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoVScodeCEnvironment
{
    public partial class Form_Process : Form
    {
        public Form_Process()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void UpdateText(string text)
        {
            label.Text = text;
        }

        public void UpdateProcess(int process)
        {
            processBar.Value = process;
        }
    }
}
