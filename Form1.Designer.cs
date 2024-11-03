namespace gosLauncher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon notifyIcon; // NotifyIcon untuk tray
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip; // Menu konteks
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem; // Menu untuk keluar
        private System.Windows.Forms.TextBox inputTextBox;

        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            
            // inputTextBox
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // this.inputTextBox.BackColor = System.Drawing.Color.Lime;
            this.inputTextBox.BackColor = System.Drawing.Color.Purple;
            this.inputTextBox.ForeColor = System.Drawing.Color.White;
            this.inputTextBox.Font = new System.Drawing.Font("FiraCode Nerd Font", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Size = new System.Drawing.Size(260, 25);
            this.inputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextBox_KeyPress);
            
            // notifyIcon
            this.notifyIcon.Icon = new System.Drawing.Icon(@"E:\Developer\Program\C#\gosLauncher\20230315_144251.ico");
            this.notifyIcon.Visible = true;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);

            // contextMenuStrip
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);

            // Form1
            this.KeyPreview = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Tanpa title bar
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Pusatkan form
            this.BackColor = System.Drawing.Color.Lime; // Atur ke warna tertentu (akan digunakan untuk transparansi)
            this.TransparencyKey = System.Drawing.Color.Lime; // Atur warna transparan
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.Controls.Add(this.inputTextBox);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
