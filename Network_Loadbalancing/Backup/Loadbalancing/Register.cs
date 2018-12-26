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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection objConnect = new SqlConnection("server=.;uid=sa;database=ssl");
        SqlCommand objCommand;
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Please Enter all the Columns and then Click Submit");
                }
                else
                {
                    objConnect.Open();
                    objCommand = new SqlCommand("reg", objConnect);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@usrname", textBox1.Text);
                    objCommand.Parameters.AddWithValue("@pwd", textBox2.Text);
                    objCommand.Parameters.AddWithValue("@addr", textBox3.Text);
                    objCommand.Parameters.AddWithValue("@phone", textBox4.Text);
                    objCommand.Parameters.AddWithValue("@email", textBox5.Text);
                    objCommand.ExecuteNonQuery();
                    objConnect.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    MessageBox.Show("Values are inserted");
                    Register reg = new Register();
                    this.Hide();

             }
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        }
}