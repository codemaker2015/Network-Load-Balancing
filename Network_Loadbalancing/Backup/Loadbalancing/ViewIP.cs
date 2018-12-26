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
    public partial class ViewIP : Form
    {
        public ViewIP()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=;database=ssl");
        SqlCommand cmd;
        private void ViewIP_Load(object sender, EventArgs e)
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

            ViewFiles vf = new ViewFiles();
            vf.Show();
            //ViewIP ip = new ViewIP();
            //ip.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}