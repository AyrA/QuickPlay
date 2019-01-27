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

        /// <summary>
        /// Extracts the VLC library
        /// </summary>
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

        /// <summary>
        /// Kills the library directory
        /// </summary>
        public static void KillLib()
        {
            if (Directory.Exists(_LibDir))
            {
                Directory.Delete(_LibDir, true);
            }
        }

        /// <summary>
        /// Static initializer
        /// </summary>
        static VlcInterface()
        {
            using (var P = Process.GetCurrentProcess())
            {
                _LibDir = Path.Combine(Path.GetDirectoryName(P.MainModule.FileName), "lib");
            }
        }

        /// <summary>
        /// Gets the media file name
        /// </summary>
        public string FileName
        { get; private set; }

        /// <summary>
        /// Gets or sets the current media position as seconds
        /// </summary>
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

        /// <summary>
        /// Gets or sets the current media position as a percentage
        /// </summary>
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

        /// <summary>
        /// Gets the media length in Milliseconds
        /// </summary>
        public long Length
        {
            get
            {
                return Player.Length;
            }
        }

        /// <summary>
        /// Gets if the media is paused
        /// </summary>
        public bool Paused
        {
            get
            {
                return Player.State == MediaStates.Paused;
            }
        }

        /// <summary>
        /// Gets or sets the current volume
        /// </summary>
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

        /// <summary>
        /// Initializes a new VLC player
        /// </summary>
        /// <param name="FileName">Media file</param>
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
            //The player is architecture specific
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

        /// <summary>
        /// Stops the current media
        /// </summary>
        public void Stop()
        {
            if (Player.State != MediaStates.Stopped)
            {
                Player.Stop();
            }
        }

        /// <summary>
        /// Plays the current media
        /// </summary>
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

        /// <summary>
        /// Pauses/Unpauses the current media
        /// </summary>
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

        /// <summary>
        /// Seeks the current media relative to the current position
        /// </summary>
        /// <param name="Offset">Position offset in seconds</param>
        public void Seek(float Offset)
        {
            Position += Offset;
        }
    }
}
