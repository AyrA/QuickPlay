using quickPlay.Properties;
using System;
using System.Diagnostics;
using System.IO;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace quickPlay
{
    public delegate void PlayerHandler(VlcInterface sender, EventType type);

    public enum EventType
    {
        Start,
        Pause,
        Stop
    }

    public class VlcInterface : IDisposable
    {
        private static string _LibDir;
        private VlcMediaPlayer Player;

        public event PlayerHandler OnStarted = delegate { };
        public event PlayerHandler OnPaused = delegate { };
        public event PlayerHandler OnStopped = delegate { };
        public event PlayerHandler OnEnded = delegate { };

        public static void ExtractLib()
        {
            if (!Directory.Exists(_LibDir))
            {
                using (var MS = new MemoryStream(Resources.lib, false))
                {
                    apak.APak.Unpack(MS, _LibDir);
                }
            }
        }

        public static void KillLib()
        {
            if (Directory.Exists(_LibDir))
            {
                Directory.Delete(_LibDir, true);
            }
        }

        static VlcInterface()
        {
            using (var P = Process.GetCurrentProcess())
            {
                _LibDir = Path.Combine(Path.GetDirectoryName(P.MainModule.FileName), "lib");
            }
        }

        public string FileName
        { get; private set; }

        public float Position
        {
            get
            {
                return Player.Position * (Length / 1000);
            }
            set
            {
                Player.Position = value * 1000 / Length;
            }
        }

        public float PositionPercentage
        {
            get
            {
                return Player.Position;
            }
            set
            {
                Player.Position = value;
            }
        }

        public long Length
        {
            get
            {
                return Player.Length;
            }
        }

        public bool Paused
        {
            get
            {
                return Player.State == MediaStates.Paused;
            }
        }

        public int Volume
        {
            get
            {
                return Player.Audio.Volume;
            }
            set
            {
                Player.Audio.Volume = value;
            }
        }

        public VlcInterface(string FileName)
        {
            this.FileName = FileName;

            if (!Directory.Exists(_LibDir))
            {
                throw new InvalidOperationException($"VLC library not installed at {_LibDir}");
            }
            InitPlayer();
        }

        private void InitPlayer()
        {
            //Disposing the old player hangs for some reason
            /*
            if (Player != null)
            {
                Player.Dispose();
            }
            //*/
            Player = new VlcMediaPlayer(new DirectoryInfo(Path.Combine(_LibDir, IntPtr.Size == 4 ? "x86" : "x64")));
            Player.Stopped += delegate
            {
                OnStopped(this, EventType.Stop);
            };
            Player.Paused += delegate
            {
                OnPaused(this, EventType.Pause);
            };
            Player.EndReached += delegate
            {
                OnEnded(this, EventType.Stop);
            };
            Player.SetMedia(new FileInfo(FileName));
        }

        public void Dispose()
        {
            if (Player != null)
            {
                Stop();
                Player.Dispose();
                Player = null;
            }
        }

        public void Stop()
        {
            if (Player.State != MediaStates.Stopped)
            {
                Player.Stop();
            }
        }

        public void Play()
        {
            if (Player.State == MediaStates.Ended)
            {
                var V = Volume;
                InitPlayer();
                Volume = V;
                Player.Play();
            }
            else if (Player.State != MediaStates.Playing)
            {
                Player.Play();
                OnStarted(this, EventType.Start);
            }

        }

        public void Pause()
        {
            if (Player.State == MediaStates.Paused)
            {
                Player.Play();
            }
            else
            {
                Player.Pause();
            }
        }

        public void Seek(float Pos)
        {
            Position += Pos;
        }

    }
}
