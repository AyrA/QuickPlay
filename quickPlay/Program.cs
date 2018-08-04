using System;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace quickPlay
{
    static class Program
    {
        public const string GUID = "{C06BA3CC-DE12-4131-8EFC-BEF10654F53B}";
        public const int UDP_PORT = 24826;
        public const string SHOWTHIS = "SHOW";
        public const string OPENFILE = "OPEN:";

        static Mutex SI;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SI = new Mutex(true, GUID);
            if (SI.WaitOne(0, true))
            {
                Application.Run(new frmMain(args.Length == 1 ? args[0] : null));
                SI.ReleaseMutex();
            }
            else
            {
                UdpClient u = new UdpClient();
                u.Connect(new IPEndPoint(IPAddress.Loopback, 24826));
                u.Client.Send(Encoding.UTF8.GetBytes(SHOWTHIS));
                if (args.Length == 1)
                {
                    u.Client.Send(Encoding.UTF8.GetBytes(OPENFILE+args[0]));
                }
                u.Close();
            }
            SI.Close();
        }
    }
}
