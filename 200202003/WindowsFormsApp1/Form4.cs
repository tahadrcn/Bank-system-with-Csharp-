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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("SERVER = localhost; DATABASE=testdb;UID=root;PWD=556119675561tT.");
        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
            listele1();
            listele2();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("insert ignore into customer(custc,cusname,cusnum,cusmail,cusaddres,delno) values ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt başarıyla eklendi.");
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
       

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd2 = new MySqlCommand("update delegate set maaş='" + textBox9.Text + "' where delno='" + textBox10.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi.");
            tablo2.Clear();
            listele2();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }
        DataTable tablo = new DataTable();
        DataTable tablo1 = new DataTable();
        DataTable tablo2 = new DataTable();
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter thdr = new MySqlDataAdapter("select *from customer", baglanti);
            thdr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        private void listele1()
        {
            baglanti.Open();
            MySqlDataAdapter thdrc = new MySqlDataAdapter("select *from para_birim", baglanti);
            thdrc.Fill(tablo1);
            dataGridView2.DataSource = tablo1;
            baglanti.Close();

        }
        private void listele2()
        {
            baglanti.Open();
            MySqlDataAdapter thdrc = new MySqlDataAdapter("select delname,delno,maaş from delegate", baglanti);
            thdrc.Fill(tablo2);
            dataGridView3.DataSource = tablo2;
            baglanti.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void c_Click(object sender, EventArgs e)
        {
            if (c.Text == "Ekle")
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("insert ignore into para_birim(birim,kur) values ('" + textBox7.Text + "','" + textBox8.Text + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarıyla eklendi.");
                tablo1.Clear();
                listele1();
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is TextBox)
                    {
                        Controls[i].Text = "";
                    }
                }
            }
            
            if (c.Text == "Güncelle")
            {
                baglanti.Open();
                MySqlCommand cmd2 = new MySqlCommand("update para_birim set kur='" + textBox8.Text + "' where birim='" + textBox7.Text + "'", baglanti);
                cmd2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarıyla güncellendi.");
                tablo1.Clear();
                listele1();
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is TextBox)
                    {
                        Controls[i].Text = "";
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("delete from para_birim where birim='" + dataGridView2.CurrentRow.Cells["birim"].Value.ToString() + "'and kur='" + dataGridView2.CurrentRow.Cells["kur"].Value.ToString() + " ' ", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            tablo1.Clear();
            listele1();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView2.CurrentRow.Cells["birim"].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells["kur"].Value.ToString();
            c.Text = "Güncelle";
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView3.CurrentRow.Cells["maaş"].Value.ToString();
            textBox10.Text = dataGridView3.CurrentRow.Cells["delno"].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            c.Text = "Ekle";
        }
    }
    }

