using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace WinSCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using WinSCP Client");

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
            //string hostKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDQ38sCI2XLgD74f3yNLKt17uTDuA0D1RJEmE19G9UBLoJvRRwTRk8lO/pEQ1uLW69u0mC34Su+XWtt2B1TFRTFZR0sFxD5Iz/61Zw7wTZPCaufMSrWBryd5TQ+sW5l6CSyvp00WUOyRIgY+OMTS4DcFLKt0iyKdScuhCSBFcewGqceFdJPdUj62rmgLCrPfr3vZO/rQGo0ipy4mexviCljE1yOvfFCC/4e4+Fap/MLlo8ogl3aLobDisBZkgZo9VIACMyjwcpfmdcnVEvwkpLta/2QRA6eEJcDNnWl32RzHZ1CbQkMH+63EDQlbVUCCEi3Tx6bg6MJ/GLkFyPjLkdP";


            // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = host,
                PortNumber = port,
                UserName = username,
                Password = password,
                SshHostKeyFingerprint = hostKey
            };

            using (Session session = new Session())
            {
                // Connect
                session.Open(sessionOptions);

                Console.WriteLine($"IsConnected: {session.Opened}");

                RemoteDirectoryInfo directory = session.ListDirectory("/C:/Agdio");

                foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    Console.WriteLine("{0} with size {1}, permissions {2} and last modification at {3}",
                        fileInfo.Name, fileInfo.Length, fileInfo.FilePermissions, fileInfo.LastWriteTime);
                }
            }

            watch.Stop();

            Console.WriteLine($"Time taken for connect: {watch.Elapsed.Seconds}s");
        }
    }
}
