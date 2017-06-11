using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WebSocketSharp;

namespace Tryzde
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamReader reader = new StreamReader(openFileDialog1.OpenFile()))
            {
                using (var ws = new WebSocket("ws://10.20.0.30"))
                {
                    string line;
                    ws.Connect();
                    while ((line = reader.ReadLine()) != null)
                    {
                        ws.Send(line);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
