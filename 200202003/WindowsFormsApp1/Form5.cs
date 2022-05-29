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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("SERVER = localhost; DATABASE=testdb;UID=root;PWD=556119675561tT.");

        public string tem_noo { get; set; }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            label9.Text = tem_noo;
            listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text =="Ekle") {
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
            if (button1.Text == "Güncelle")
            {
                baglanti.Open();
                MySqlCommand cmd2 = new MySqlCommand("update customer set cusname='"+textBox1.Text+ "',cusnum='" + textBox3.Text + "',cusmail='" + textBox4.Text + "',cusaddres='" + textBox5.Text + "',delno='" + textBox6.Text + "',hesap_para='" + textBox8.Text + "' where custc='"+textBox2.Text+"'", baglanti);
                cmd2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt başarıyla güncellendi.");
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
            
        DataTable tablo = new DataTable();
        private void listele()
        {
            baglanti.Open();
            MySqlDataAdapter thdr = new MySqlDataAdapter("select *from customer where delno='"+label9.Text+"'",baglanti);
            thdr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("delete  from customer where cusname='"+dataGridView1.CurrentRow.Cells["cusname"].Value.ToString()+ "'and cusnum='" + dataGridView1.CurrentRow.Cells["cusnum"].Value.ToString()+" ' ", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
            tablo.Clear();
            listele();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlDataAdapter thdr = new MySqlDataAdapter("select *from customer where cusname like'"+textBox7.Text+"%'", baglanti);
            DataTable tablo2 = new DataTable();
            thdr.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["cusname"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["custc"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["cusnum"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["cusmail"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["cusaddres"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["delno"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["hesap_para"].Value.ToString();
            button1.Text = "Güncelle";
            if (button1.Text == "Güncelle")
            {
                label8.Visible = true;
                textBox8.Visible = true;
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form1 = new Form3();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Text = "Ekle";

        }
    }
}
