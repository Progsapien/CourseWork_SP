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
        static public extern IntPtr runGet0(IntPtr player);
        IntPtr player;

        private void Form1_Load(object sender, EventArgs e)
        {
            player = createPlayer();
            IntPtr text = Marshal.StringToCoTaskMemAnsi("D:/1.mp3");
            runLoadFile(player, text);
            runLoadFile(player, Marshal.StringToCoTaskMemAnsi("D:/2.mp3"));
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            IntPtr text;
            text = runGet0(player);
            btn_play.Text = Marshal.PtrToStringAnsi(text);
            runPlay(player, 0);
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            runPrev(player);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            runNext(player);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            runStop(player);
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            // open files;
        }

    }
}
