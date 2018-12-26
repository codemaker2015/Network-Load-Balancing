using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Loadbalancing
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }
        string hname, lb1;
        public Download(string ip,string lbs)
        {
            hname = ip;
            lb1 = lbs;
            InitializeComponent();
        }
        string str1, str2;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox1.Text = DateTime.Now.TimeOfDay.ToString();
            str1 = textBox1.Text;
            richTextBox1.Text = File.ReadAllText("//" + hname + "/ssl data/" + lb1 + "");
            textBox2.Text = DateTime.Now.TimeOfDay.ToString();
            str2 = textBox2.Text;
            int getindex1 = Convert.ToInt32(str1.LastIndexOf(':'));
            str1 = str1.Substring(getindex1 + 1);
            int getindex2 = Convert.ToInt32(str2.LastIndexOf(':'));
            str2 = str2.Substring(getindex2 + 1);
            double d1, d2, d3;
            d1 = Convert.ToDouble(str1);
            d2 = Convert.ToDouble(str2);
            d3 = d2 - d1;
            textBox3.Text = d3.ToString();
            MessageBox.Show("Response Time  " + d3.ToString() + "  Seconds...");
            MessageBox.Show("Downloading From " + hname);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}