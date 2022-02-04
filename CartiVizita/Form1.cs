using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartiVizita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox6.Clear();
            textBox1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO CartiVizita (Nume, Prenume, Functie, Telefon, Email, Companie) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "', '" + textBox6.Text + "')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Carte de vizita Salvata");
            Display();
        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From CartiVizita", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int t = dataGridView1.Rows.Add();
                dataGridView1.Rows[t].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[t].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[t].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[t].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[t].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[t].Cells[5].Value = item[5].ToString();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE From CartiVizita WHERE (Nume = '" + textBox1.Text + "') ", con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Carte de vizita Stearsa");
            Display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE CartiVizita SET Nume = '" + textBox1.Text + "', Prenume = '" + textBox2.Text + "', Functie = '" + textBox3.Text + "', Telefon = '" + textBox4.Text + "', Email = '" + textBox5.Text + "', Companie = '" + textBox6.Text + "' WHERE (Nume = '" + textBox1.Text + "')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Carte de vizita Modificata");
            Display();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From CartiVizita Where (Nume like '%" + textBox7.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int t = dataGridView1.Rows.Add();
                dataGridView1.Rows[t].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[t].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[t].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[t].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[t].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[t].Cells[5].Value = item[5].ToString();


            }

        }
    }
}