using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string tem_no { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void c_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.tem_noo = label1.Text;
            frm.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = tem_no;
        }
    }
}
