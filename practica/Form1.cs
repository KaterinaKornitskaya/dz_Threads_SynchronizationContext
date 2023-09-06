using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica
{
    // Задача - при нажатии кнопки число увеличивается на 10
    public partial class Form1 : Form
    {
        public SynchronizationContext uiContext;
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            label1.Text = 10.ToString();
        }

        private void ThreadFunk()
        {
            uiContext.Send(d => label1.Text = (int.Parse(label1.Text) + 10).ToString(), null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart MethodThread = new ThreadStart(ThreadFunk);
            thread = new Thread(MethodThread);
            thread.Start();
        }
    }
}
