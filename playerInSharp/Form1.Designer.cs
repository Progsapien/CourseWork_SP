namespace playerInSharp
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.music_list = new System.Windows.Forms.ListBox();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_prev
            // 
            this.btn_prev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev.Location = new System.Drawing.Point(17, 272);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(77, 40);
            this.btn_prev.TabIndex = 0;
            this.btn_prev.Text = "Пред.";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_play
            // 
            this.btn_play.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_play.Location = new System.Drawing.Point(100, 272);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(162, 40);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "Играть";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_next.Location = new System.Drawing.Point(268, 272);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(77, 40);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "След.";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_stop.Location = new System.Drawing.Point(351, 272);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 40);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Стоп";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_open
            // 
            this.btn_open.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_open.Location = new System.Drawing.Point(432, 272);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(104, 40);
            this.btn_open.TabIndex = 4;
            this.btn_open.Text = "Открыть";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // music_list
            // 
            this.music_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.music_list.FormattingEnabled = true;
            this.music_list.Location = new System.Drawing.Point(17, 12);
            this.music_list.Name = "music_list";
            this.music_list.Size = new System.Drawing.Size(519, 251);
            this.music_list.TabIndex = 5;
            this.music_list.SelectedIndexChanged += new System.EventHandler(this.music_list_SelectedIndexChanged);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openDialog";
            this.openDialog.Filter = "MP3 файлы (*.mp3)|*.mp3";
            this.openDialog.Multiselect = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 331);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.music_list);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_next);
            this.MinimumSize = new System.Drawing.Size(570, 369);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ListBox music_list;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}

