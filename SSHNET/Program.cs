using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using SSH.NET");

            Stopwatch watch = Stopwatch.StartNew();

            watch.Start();

            //Connecting to WinSCP
            var username = "AzurePrad";
            var password = "AzureIndia789!!";
            var host = "52.187.3.217";
            int port = 22;
            string hostKey = "ssh-rsa 2048 59:22:9e:5b:eb:c3:6c:c0:2a:01:7f:cc:b3:1e:68:aa";

            //Connecting to RebexTinySftpServer
            //var username = "tester";
            //var password = "password";
            //var host = "52.187.3.217";
            //int port = 22;

            var connectInfo = new ConnectionInfo(host, port, username, new PasswordAuthenticationMethod(username, password));

            connectInfo.Timeout = TimeSpan.FromSeconds(100);

            using (var client = new SftpClient(connectInfo))
            {
                //client.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
                //{
                //    //if (e.FingerPrint.SequenceEqual(ConvertFingerprintToByteArray("1d:c1:5a:71:c4:8e:a3:ff:01:0a:3b:46:17:6f:e1:52")))
                //    //    e.CanTrust = true;
                //    //else
                //    //    e.CanTrust = false;
                //    e.CanTrust = true;
                //};

                client.Connect();
                Console.WriteLine($"IsConnected: {client.IsConnected}");
                client.Disconnect();
                Console.WriteLine($"IsConnected: {client.IsConnected}");
            }

            watch.Stop();

            Console.WriteLine($"Time taken for connect: {watch.Elapsed.Seconds}s");
        }

        public static byte[] ConvertFingerprintToByteArray(String fingerprint)
        {
            return fingerprint.Split(':').Select(s => Convert.ToByte(s, 16)).ToArray();
        }
    }
}
