using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace playerInSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr createPlayer();

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runPlay(IntPtr player, int position);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runNext(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runPrev(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runStop(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runLoadFile(IntPtr player, IntPtr path);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runCurrentFile(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runCurrentPosition(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runLength(IntPtr player);

        [DllImport("D:/mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runSetCurrentPosition(IntPtr player, IntPtr position);

        IntPtr player;

        private void Form1_Load(object sender, EventArgs e)
        {
            player = createPlayer();

        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            runPlay(player, music_list.SelectedIndex);
            timer1.Enabled = true;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (music_list.SelectedIndex - 1 >= 0)
            {
                music_list.SelectedIndex--;
            }
            else
            {
                music_list.SelectedIndex = music_list.Items.Count - 1;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (music_list.SelectedIndex + 1 < music_list.Items.Count)
            {
                music_list.SelectedIndex++;
            }
            else
            {
                music_list.SelectedIndex = 0;
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            runStop(player);

        }

        private void btn_open_Click(object sender, EventArgs e)
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach(string path in openDialog.SafeFileNames) {
                    runLoadFile(player, Marshal.StringToCoTaskMemAnsi(System.IO.Path.GetDirectoryName(openDialog.FileName)+"\\"+path));
                    music_list.Items.Add(System.IO.Path.GetDirectoryName(openDialog.FileName) + "\\" + path);
                }
            }
        }

        private void music_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            runPlay(player, music_list.SelectedIndex);
            track_music.Maximum = Marshal.ReadInt32(runLength(player));
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            track_music.Value = Marshal.ReadInt32(runCurrentPosition(player));
        }

        private void track_music_Scroll(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string value_str = Convert.ToString(track_music.Value);
            runSetCurrentPosition(player, Marshal.StringToCoTaskMemAnsi(value_str));
            timer1.Enabled = true;
        }

    }
}
