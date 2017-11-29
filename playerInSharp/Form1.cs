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

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr createPlayer();

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runPlay(IntPtr player, int position);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runNext(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runPrev(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runStop(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runLoadFile(IntPtr player, IntPtr path);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runCurrentFile(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runCurrentPosition(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runLength(IntPtr player);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern void runSetCurrentPosition(IntPtr player, IntPtr position);

        [DllImport("mp3dll.dll", CallingConvention = CallingConvention.Cdecl)]
        static public extern IntPtr runLastError(IntPtr player);

        IntPtr player, error_code_ptr;
        int error_code = 0;


        Dictionary<int, string> error_list = new Dictionary<int, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            player = createPlayer();
            error_list.Add(512, "MCIERR_CUSTOM_DRIVER_BASE");
            error_list.Add(349, "MCIERR_FILE_WRITE");
            error_list.Add(348, "MCIERR_FILE_READ");
            error_list.Add(347, "MCIERR_CREATEWINDOW");
            error_list.Add(346, "MCIERR_NO_WINDOW");
            error_list.Add(343, "MCIERR_SEQ_NOMIDIPRESENT");
            error_list.Add(342, "MCIERR_SEQ_PORTUNSPECIFIED");
            error_list.Add(341, "MCIERR_SEQ_TIMER");
            error_list.Add(340, "MCIERR_SEQ_PORT_MISCERROR");
            error_list.Add(339, "MCIERR_SEQ_PORT_MAPNODEVICE");
            error_list.Add(338, "MCIERR_SEQ_PORT_NONEXISTENT");
            error_list.Add(337, "MCIERR_SEQ_PORT_INUSE");
            error_list.Add(336, "MCIERR_SEQ_DIV_INCOMPATIBLE");
            error_list.Add(329, "MCIERR_WAVE_SETINPUTUNSUITABLE");
            error_list.Add(328, "MCIERR_WAVE_INPUTSUNSUITABLE");
            error_list.Add(327, "MCIERR_WAVE_SETOUTPUTUNSUITABLE");
            error_list.Add(326, "MCIERR_WAVE_OUTPUTSUNSUITABLE");
            error_list.Add(325, "MCIERR_WAVE_INPUTUNSPECIFIED");
            error_list.Add(324, "MCIERR_WAVE_OUTPUTUNSPECIFIED");
            error_list.Add(323, "MCIERR_WAVE_SETINPUTINUSE");
            error_list.Add(322, "MCIERR_WAVE_INPUTSINUSE");
            error_list.Add(321, "MCIERR_WAVE_SETOUTPUTINUSE");
            error_list.Add(320, "MCIERR_WAVE_OUTPUTSINUSE");
            error_list.Add(312, "MCIERR_NO_INTEGER");
            error_list.Add(311, "MCIERR_DEVICE_ORD_LENGTH");
            error_list.Add(310, "MCIERR_DEVICE_LENGTH");
            error_list.Add(309, "MCIERR_SET_DRIVE");
            error_list.Add(308, "MCIERR_SET_CD");
            error_list.Add(307, "MCIERR_GET_CD");
            error_list.Add(306, "MCIERR_DEVICE_NOT_INSTALLED");
            error_list.Add(305, "MCIERR_EXTRA_CHARACTERS");
            error_list.Add(304, "MCIERR_FILENAME_REQUIRED");
            error_list.Add(303, "MCIERR_ILLEGAL_FOR_AUTO_OPEN");
            error_list.Add(302, "MCIERR_NONAPPLICABLE_FUNCTION");
            error_list.Add(301, "MCIERR_NO_ELEMENT_ALLOWED");
            error_list.Add(300, "MCIERR_NOTIFY_ON_AUTO_OPEN");
            error_list.Add(299, "MCIERR_NEW_REQUIRES_ALIAS");
            error_list.Add(298, "MCIERR_UNNAMED_RESOURCE");
            error_list.Add(297, "MCIERR_NULL_PARAMETER_BLOCK");
            error_list.Add(296, "MCIERR_INVALID_FILE");
            error_list.Add(295, "MCIERR_DUPLICATE_FLAGS");
            error_list.Add(294, "MCIERR_NO_CLOSING_QUOTE");
            error_list.Add(293, "MCIERR_BAD_TIME_FORMAT");
            error_list.Add(292, "MCIERR_MISSING_DEVICE_NAME");
            error_list.Add(291, "MCIERR_MUST_USE_SHAREABLE");
            error_list.Add(290, "MCIERR_BAD_CONSTANT");
            error_list.Add(289, "MCIERR_DUPLICATE_ALIAS");
            error_list.Add(288, "MCIERR_DEVICE_LOCKED");
            error_list.Add(287, "MCIERR_DEVICE_TYPE_REQUIRED");
            error_list.Add(286, "MCIERR_FILE_NOT_SAVED");
            error_list.Add(283, "MCIERR_FLAGS_NOT_COMPATIBLE");
            error_list.Add(282, "MCIERR_OUTOFRANGE");
            error_list.Add(281, "MCIERR_EXTENSION_NOT_FOUND");
            error_list.Add(280, "MCIERR_MULTIPLE");
            error_list.Add(279, "MCIERR_CANNOT_USE_ALL");
            error_list.Add(278, "MCIERR_DRIVER");
            error_list.Add(277, "MCIERR_INTERNAL");
            error_list.Add(276, "MCIERR_DEVICE_NOT_READY");
            error_list.Add(275, "MCIERR_FILE_NOT_FOUND");
            error_list.Add(274, "MCIERR_UNSUPPORTED_FUNCTION");
            error_list.Add(273, "MCIERR_MISSING_PARAMETER");
            error_list.Add(272, "MCIERR_DRIVER_INTERNAL");
            error_list.Add(271, "MCIERR_PARSER_INTERNAL");
            error_list.Add(270, "MCIERR_BAD_INTEGER");
            error_list.Add(269, "MCIERR_MISSING_STRING_ARGUMENT");
            error_list.Add(268, "MCIERR_PARAM_OVERFLOW");
            error_list.Add(267, "MCIERR_MISSING_COMMAND_STRING");
            error_list.Add(266, "MCIERR_CANNOT_LOAD_DRIVER");
            error_list.Add(265, "MCIERR_DEVICE_OPEN");
            error_list.Add(264, "MCIERR_OUT_OF_MEMORY");
            error_list.Add(263, "MCIERR_INVALID_DEVICE_NAME");
            error_list.Add(262, "MCIERR_HARDWARE");
            error_list.Add(261, "MCIERR_UNRECOGNIZED_COMMAND");
            error_list.Add(259, "MCIERR_UNRECOGNIZED_KEYWORD");
            error_list.Add(257, "MCIERR_INVALID_DEVICE_ID");
            error_list.Add(256, "MCIERR_BASE");
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            music_list.SelectedIndex = music_list.SelectedIndex == -1 ? 0 : music_list.SelectedIndex;
            runPlay(player, music_list.SelectedIndex);
            showLastError();
            timer1.Enabled = true;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            music_list.SelectedIndex = music_list.SelectedIndex - 1 >= 0 ? music_list.SelectedIndex - 1 : music_list.Items.Count - 1;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            music_list.SelectedIndex = music_list.SelectedIndex + 1 < music_list.Items.Count ? music_list.SelectedIndex + 1 : 0;
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
                    enableControls();
                }
            }
        }

        private void enableControls()
        {
            btn_next.Enabled = true;
            btn_play.Enabled = true;
            btn_prev.Enabled = true;
            btn_stop.Enabled = true;
            track_music.Enabled = true;
        }

        private void music_list_SelectedIndexChanged(object sender, EventArgs e)
        {

            runPlay(player, music_list.SelectedIndex);
            showLastError();
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
            showLastError();
            timer1.Enabled = true;
        }

        private void showLastError()
        {
            error_code_ptr = runLastError(player);
            error_code = Marshal.ReadInt32(error_code_ptr);
            if (error_code > 0)
            {
                timer1.Enabled = false;
                MessageBox.Show(error_list[error_code], "Ошибка");
            }
        }

    }
}
