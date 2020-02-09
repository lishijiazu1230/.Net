using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 委托实例_窗体之间传值
{
    public partial class Form2 : Form
    {
        Action<string> _act;
        public Form2(Action<string> act)
        {
            this._act = act;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _act(textBox1.Text.ToString());
        }
    }
}
