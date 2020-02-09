using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 委托实例2_父传子
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form2 frm2;
        public Form3 frm3;
        private void Form1_Load(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.Show();
            frm3 = new Form3();
            frm3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action<string> act = new Action<string>(frm2.showMsg);
            act += frm3.showMsg;
            act(textBox1.Text.ToString());
        }
    }
}
