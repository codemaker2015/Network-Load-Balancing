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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection objConnect = new SqlConnection("server=.;uid=sa;database=ssl");
        SqlCommand objCommand;

        private void button1_Click(object sender, EventArgs e)
        {
            objConnect.Open();
            objCommand = new SqlCommand("select pwd from login where usrname='" + textBox1.Text + "'", objConnect);
            SqlDataReader dr = objCommand.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == textBox2.Text)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Correct Login");
                    this.Hide();
                    ViewIP vip = new ViewIP();
                    vip.Show();
                }
                else
                {
                    {
                        MessageBox.Show("Login Error... Please Try again");
                    }
                }
            }
            objConnect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}