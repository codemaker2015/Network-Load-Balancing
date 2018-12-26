using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Loadbalancing
{
    public partial class Resptime : Form
    {
        public Resptime()
        {
            InitializeComponent();
        }

        string lbs;
        public Resptime(string lb)
        {
            lbs = lb;
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=APTTECH5;Initial Catalog=NetworkLoad;Integrated Security=True");
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c, min, min1;
            string s;

            a = Convert.ToDouble(textBox3.Text);
            b = Convert.ToDouble(textBox6.Text);
            c = Convert.ToDouble(textBox9.Text);

            min = Math.Min(a, b);
            min1 = Math.Min(min, c);

            if (min1 == a)
            {
                s = listBox1.Items[0].ToString();
            }
            else if (min1 == b)
            {
                s = listBox1.Items[1].ToString();
            }
            else
            {
                s = listBox1.Items[2].ToString();
            }
            MessageBox.Show("Minimal Response time From the server IP Address : " + s.ToString());
            Download dl = new Download(s.ToString(),lbs.ToString());
            dl.Show();
        }
        
        private void Resptime_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string i, j, k;
            i = listBox1.Items[0].ToString();
            j = listBox1.Items[1].ToString();
            k = listBox1.Items[2].ToString();
            byte[] data = new byte[1024];
            byte[] data1 = new byte[1024];
            byte[] data2 = new byte[1024];

            string input, strdata;
            string str1, str2;
            TcpClient Server1;
            int recv, recv1, recv2;
            textBox1.Text = DateTime.Now.TimeOfDay.ToString();
            str1 = textBox1.Text;
            try
            {
                Server1 = new TcpClient("" + i + "", 1111);

            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect Main Server...");
                return;
            }

            NetworkStream ns = Server1.GetStream();
            //while (true)
            //{
            input = "Hi";
            if (input != "exit")
            {
                ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns.Flush();
                recv = ns.Read(data, 0, data.Length);
                strdata = Encoding.ASCII.GetString(data, 0, recv);
                //MessageBox.Show("Response..." + strdata);
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
            }
            else
            {
                //Console.WriteLine("Disconnecting from Server...");
                //break;
            }

            //}

            ns.Close();
            Server1.Close();


            //server2
            textBox4.Text = DateTime.Now.TimeOfDay.ToString();
            str1 = textBox4.Text;
            try
            {
                Server1 = new TcpClient("" + j + "", 2222);

            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect Main Server...");
                return;
            }

            NetworkStream ns1 = Server1.GetStream();
            //while (true)
            //{
            input = "Hi";
            if (input != "exit")
            {
                ns1.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns1.Flush();
                recv1 = ns1.Read(data1, 0, data1.Length);
                strdata = Encoding.ASCII.GetString(data1, 0, recv1);
                //MessageBox.Show("Response..." + strdata);
                textBox5.Text = DateTime.Now.TimeOfDay.ToString();
                str2 = textBox5.Text;
                int getindex1 = Convert.ToInt32(str1.LastIndexOf(':'));
                str1 = str1.Substring(getindex1 + 1);
                int getindex2 = Convert.ToInt32(str2.LastIndexOf(':'));
                str2 = str2.Substring(getindex2 + 1);
                double d1, d2, d3;
                d1 = Convert.ToDouble(str1);
                d2 = Convert.ToDouble(str2);
                d3 = d2 - d1;
                textBox6.Text = d3.ToString();
            }
            else
            {
                //Console.WriteLine("Disconnecting from Server...");
                //break;
            }

            //}

            ns1.Close();
            Server1.Close();



            //server 3
            textBox7.Text = DateTime.Now.TimeOfDay.ToString();
            str1 = textBox7.Text;
            try
            {
                Server1 = new TcpClient("" + k + "", 3333);

            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect Main Server...");
                return;
            }

            NetworkStream ns2 = Server1.GetStream();
            //while (true)
            //{
            input = "Hi";
            if (input != "exit")
            {
                ns2.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns2.Flush();
                recv2 = ns2.Read(data2, 0, data2.Length);
                strdata = Encoding.ASCII.GetString(data2, 0, recv2);
                //MessageBox.Show("Response..." + strdata);
                textBox8.Text = DateTime.Now.TimeOfDay.ToString();
                str2 = textBox8.Text;
                int getindex1 = Convert.ToInt32(str1.LastIndexOf(':'));
                str1 = str1.Substring(getindex1 + 1);
                int getindex2 = Convert.ToInt32(str2.LastIndexOf(':'));
                str2 = str2.Substring(getindex2 + 1);
                double d1, d2, d3;
                d1 = Convert.ToDouble(str1);
                d2 = Convert.ToDouble(str2);
                d3 = d2 - d1;
                textBox9.Text = d3.ToString();
            }
            else
            {
                //Console.WriteLine("Disconnecting from Server...");
                //break;
            }

            //}

            ns2.Close();
            Server1.Close();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}