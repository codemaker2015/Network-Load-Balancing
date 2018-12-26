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
    public partial class ViewFiles : Form
    {
        public ViewFiles()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=APTTECH5;Initial Catalog=NetworkLoad;Integrated Security=True");
        SqlCommand cmd;

        private void ViewFiles_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from up", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string str = dr[1].ToString();

                int getindex = Convert.ToInt32(str.LastIndexOf('\\'));
                string fname = str.Substring(getindex + 1);
                listBox1.Items.Add(fname);
            }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewFiles vf = new ViewFiles();
            this.Hide();

            Resptime rt = new Resptime(listBox1.SelectedItem.ToString());
            rt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}