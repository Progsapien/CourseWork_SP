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
        static public extern void playTest(IntPtr player);

        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr player = createPlayer();
            playTest(player);
        }

    }
}
