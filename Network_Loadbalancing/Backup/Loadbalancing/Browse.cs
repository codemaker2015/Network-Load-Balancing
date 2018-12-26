using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Loadbalancing
{
    public partial class Browse : Form
    {
        public Browse()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=;initial catalog=ssl");
        SqlCommand cmd;
        private void Browse_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from ddd", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select a Text File";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|Access Database(*.txt) files (*.txt)|*.txt";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
            }
            inputTextBox.Text = File.ReadAllText(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the file name of the text");
                
            }
            else
            {
                string s1, s2, s3, hname;
                s1 = textBox1.Text;
                int getindex1 = Convert.ToInt32(s1.LastIndexOf('\\'));
                s2 = s1.Substring(getindex1 + 1);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    hname = listBox1.Items[i].ToString();
                    s3 = "//" + hname + "/ssl data/" + s2 + "";
                    System.IO.File.Copy(s1, s3);
                }
                MessageBox.Show("Saved In Three Systems...");
                con.Open();
                cmd = new SqlCommand("insert into up values ('" + textBox1.Text + "')", con);
                cmd.ExecuteNonQuery();
                this.Hide();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}