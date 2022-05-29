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
 
    public partial class Form1 : Form
    {
        MySqlConnection baglanti = new MySqlConnection("SERVER = localhost; DATABASE=testdb;UID=root;PWD=556119675561tT.");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }
        


        void Giriş()
        {
            string sorgu = "Select *From delegate where delno='" + textBox2.Text + "'And deltc='" + textBox5.Text + "'";
            baglanti.Open();
            cmd = new MySqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sorgu;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");

            }
            baglanti.Close();
        }
        void Giriş1()
        {
            string sorgu = "Select *From customer where cusname='" + textBox1.Text + "'And custc='" + textBox4.Text + "'";
            baglanti.Open();
            cmd = new MySqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sorgu;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");

            }
            baglanti.Close();
        }
        void Giriş2()
        {
            string sorgu = "Select *From müdür where nick='" + textBox3.Text + "'And pass='" + textBox6.Text + "'";
            baglanti.Open();
            cmd = new MySqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = sorgu;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form4 frm4 = new Form4();
                frm4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");

            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Mgb_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Giriş1();
            Form2 frm = new Form2();
            frm.kullaniciAdi = textBox1.Text;
            frm.ShowDialog();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giriş();
            Form3 frm = new Form3();
            frm.tem_no = textBox2.Text;
            frm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Giriş2();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {       
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
