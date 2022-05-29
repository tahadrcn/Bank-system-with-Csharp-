using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    
    public partial class Form2 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("SERVER = localhost; DATABASE=testdb;UID=root;PWD=556119675561tT.");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }
        public string kullaniciAdi { get; set; }
       

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void c_Click(object sender, EventArgs e)
        {

        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            
        }
        DataTable tablo = new DataTable();
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter thdr = new MySqlDataAdapter("select * from customer where cusname='" + label4.Text + "'", baglanti);
            thdr.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = kullaniciAdi;
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd2 = new MySqlCommand("update customer set cusnum='" + textBox2.Text +  "' where cusname='" + label4.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi.");
            tablo.Clear();
            listele();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd2 = new MySqlCommand("update customer set cusmail='" + textBox3.Text + "' where cusname='" + label4.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi.");
            tablo.Clear();
            listele();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd2 = new MySqlCommand("update customer set cusaddres='" + textBox4.Text + "' where cusname='" + label4.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi.");
            tablo.Clear();
            listele();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }
    }
}
