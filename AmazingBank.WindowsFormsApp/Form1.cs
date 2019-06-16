using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazingBank.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessSomething_Click(object sender, EventArgs e)
        {
            Thread threadProcessSomething;
            threadProcessSomething = new Thread(ProcessSomething);
            threadProcessSomething.Start();
        }

        public static void ProcessSomething()
        {
            UInt64 counter = 0;
            while (counter < 99999999)
            {
                counter++;
                Debug.WriteLine(Guid.NewGuid());
            }
        }
    }
}
