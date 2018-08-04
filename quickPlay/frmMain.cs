using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Text;
using AyrA.UI;
using System.IO;
using System.Diagnostics;

namespace quickPlay
{
    public partial class frmMain : Form
    {
        private const int STEP = 50;
        private VlcInterface Player;
        private UdpClient u;
        private Font Fixedsys;

        public frmMain(string File)
        {
#if DEBUG
            File = @"C:\Temp\media\Bud Spencer & Terence Hill Filmmusik-8POtxa0SaBo.mp3";
#endif
            InitializeComponent();
            Fixedsys = new Font("Courier New", 11);

            try
            {
#if DEBUG
                VlcInterface.KillLib();
#endif
                VlcInterface.ExtractLib();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to Extract VLC Library. Reason: {ex.Message}", "QuickPlay has to terminate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.FailFast("Unable to extract VLC Library", ex);
            }

            if (File != null)
            {
                CreatePlayer(File);
                Player.Play();
            }
            u = new UdpClient();
            u.Client.Bind(new IPEndPoint(IPAddress.Loopback, Program.UDP_PORT));
            u.BeginReceive(new AsyncCallback(dataRec), null);
        }

        private void CreatePlayer(string FileName)
        {
            var V = 100;
            if (Player != null)
            {
                V = Player.Volume;
                Player.Dispose();
            }
            Player = new VlcInterface(FileName);
            Player.Volume = V;
            //Repeat Mode
            Player.OnEnded += delegate
            {
                Player.Play();
            };
            tPlayerUpdate.Start();
            lblInfo.Text = FileName;
            lblInfo.ForeColor = Color.Black;
        }

        private void dataRec(IAsyncResult ar)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            string Data;
            try
            {
                Data = Encoding.UTF8.GetString(u.EndReceive(ar, ref ep));
            }
            catch
            {
                return;
            }
            //only accept local Commands (in case loopback is accessible for some reason
            if (ep.Address.ToString() == IPAddress.Loopback.ToString())
            {
                if (Data == Program.SHOWTHIS)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        BringToFront();
                        TopMost = true;
                        TopMost = false;
                    });
                }
                else if (Data.StartsWith(Program.OPENFILE))
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        CreatePlayer(Data.Substring(Program.OPENFILE.Length));
                        Player.Play();
                    });
                }
            }
            u.BeginReceive(new AsyncCallback(dataRec), null);
        }

        private void lblInfo_DragLeave(object sender, EventArgs e)
        {
            lblInfo.Text = Player != null ? Player.FileName : "Drag File to play over Here";
            lblInfo.ForeColor = Color.Black;
        }

        private void pDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1)
                {
                    lblInfo.Text = "Drop File to play";
                    lblInfo.ForeColor = Color.Green;
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    lblInfo.Text = "Please drag only a single File";
                    lblInfo.ForeColor = Color.Red;
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                lblInfo.Text = "Invalid Drag and Drop Type";
                lblInfo.ForeColor = Color.Red;
                e.Effect = DragDropEffects.None;
            }
        }

        private void pDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] a = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (a.Length == 1)
            {
                CreatePlayer(a[0]);
                Player.Play();
                TaskbarProgress.SetState(Handle, TaskbarStates.Normal);
            }
            else
            {
                lblInfo.Text = "Drag a File to play over here";
                lblInfo.ForeColor = Color.Black;
            }
        }

        private void tPlayerUpdate_Tick(object sender, EventArgs e)
        {
            var Length = (int)(Player.Length / 1000d);
            var Position = (int)Math.Floor(Player.Position);
            if (pbTime.Maximum != Length && Length > 0)
            {
                if (pbTime.Value > Length)
                {
                    pbTime.Value = pbTime.Minimum;
                }
                pbTime.Maximum = Length;
            }
            if (pbTime.Value != Position && Position > 0)
            {
                pbTime.Value = Math.Min(Position, Length);
                pbTime.ForeColor = ColFromPerc(Position * 100d / Length);
                pbTime.Refresh();
                pbTime.CreateGraphics().DrawString(new TimeSpan(0, 0, 0, 0, Position * 1000).ToString(), Fixedsys, new SolidBrush(Color.Green), new Point(pbTime.Width / 2 - 40, 2));
                TaskbarProgress.SetValue(Handle, Position, Length);
            }
        }

        private Color ColFromPerc(double Percentage)
        {
            double r, g;
            if (Percentage > 50d)
            {
                r = 255;
                g = 255 - 255 * ((Percentage - 50d) / 50d);
            }
            else
            {
                g = 255;
                r = 255 * (Percentage / 50d);
            }
            return Color.FromArgb((int)r, (int)g, 0);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Player.Pause();
            TaskbarProgress.SetState(Handle, Player.Paused ? TaskbarStates.Paused : TaskbarStates.Normal);
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            Player.Position = 0;
            Player.Play();
        }

        private void btnSeekBack_Click(object sender, EventArgs e)
        {
            Player.Seek(-3);
        }

        private void btnSeekFwd_Click(object sender, EventArgs e)
        {
            Player.Seek(3);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u != null)
            {
                u.Close();
                u = null;
            }
            if (Player != null)
            {
                Player.Dispose();
                Player = null;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    Player.Pause();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Right:
                    Player.Seek(3);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Left:
                    Player.Seek(-3);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Up:
                    tbVolume.Value = Math.Min(tbVolume.Maximum, tbVolume.SmallChange + tbVolume.Value);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down:
                    tbVolume.Value = Math.Max(tbVolume.Minimum, tbVolume.Value - tbVolume.SmallChange);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Home:
                case Keys.R:
                    Player.Stop();
                    Player.Play();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Escape:
                    Close();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                default:
                    break;
            }
        }

        private void tbVolume_ValueChanged(object sender, EventArgs e)
        {
            Player.Volume = tbVolume.Value;
        }

        private void lblInfo_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Player.FileName) && File.Exists(Player.FileName))
            {
                Process.Start("explorer.exe", "\"" + Path.GetDirectoryName(Player.FileName) + "\"");
            }
        }

        private void pbTime_MouseClick(object sender, MouseEventArgs e)
        {
            Player.PositionPercentage = e.X * 1f / pbTime.Width;
        }
    }
}
