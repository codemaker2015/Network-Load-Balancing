using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;

  public class Server
    {
      public static void Main()
      {
          int recv;
          byte[] data = new byte[1024];
          string str;

          TcpListener newsock = new TcpListener(3333);
          newsock.Start();
          Console.WriteLine("Waiting for a client...");

          TcpClient client = newsock.AcceptTcpClient();
          NetworkStream ns = client.GetStream();
          
         
          while (true)
          {
              string welcome = "Welcome to my test server";
              data = Encoding.ASCII.GetBytes(welcome);
              ns.Write(data, 0, data.Length);

              recv = ns.Read(data, 0, data.Length);
              str=Encoding.ASCII.GetString(data, 0, recv);
              Console.WriteLine(str);
              
              if (recv == 0)
              break;              
          }
          
          ns.Close();
          client.Close();
          newsock.Stop();
      }
    }
