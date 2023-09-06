using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz2
{
    // Задача - ПрогрессБары заполняются в рандном порялке,
    // в отдельном потоке
    public partial class Form1 : Form
    {
        public SynchronizationContext uiContext;
        Thread thread = null;
        List<ProgressBar> list = null;
        List<string> res = null;
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }

        private void ThreadFunk()
        {
            list = new List<ProgressBar>();
            list.Add(progressBar1);
            list.Add(progressBar2);
            list.Add(progressBar3);
            list.Add(progressBar4);
            list.Add(progressBar5);
            Random random = new Random();

            foreach (ProgressBar pb in list)
            {
                uiContext.Send(d => pb.Minimum = 0, null);
                uiContext.Send(d => pb.Maximum = 230, null);
                uiContext.Send(d => pb.Value = random.Next(pb.Minimum, pb.Maximum), null);
                //MessageBox.Show(thread.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart MethodThread = new ThreadStart(ThreadFunk);
            thread = new Thread(MethodThread);
            thread.Start();
        }
    }
}
