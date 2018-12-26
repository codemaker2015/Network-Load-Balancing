using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Loadbalancing
{
    public partial class IPForm : Form
    {
        public IPForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPForm ipf = new IPForm();
            this.Hide();
            Browse br = new Browse();
            br.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        SqlConnection objConnect = new SqlConnection("Data Source=APTTECH5;Initial Catalog=NetworkLoad;Integrated Security=True");
        SqlCommand objCommand;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Enter all IP Addresses and Click Submit");
            }
            else
            {
                objConnect.Open();
                objCommand = new SqlCommand("truncate table ipaddr", objConnect);
                objCommand.ExecuteNonQuery();
                objConnect.Close();
                objConnect.Open();
                objCommand = new SqlCommand("insert into ipaddr values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", objConnect);
                objCommand.ExecuteNonQuery();
                objConnect.Close();

                IPForm ipf = new IPForm();
                this.Hide();
                //Upload up = new Upload();
                //up.Show();
                Browse br = new Browse();
                br.Show();
            }
        }

        private void IPForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}