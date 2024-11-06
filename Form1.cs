using System.Media;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace gosLauncher
{
    public partial class Form1 : Form
    {
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 9000;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, HOTKEY_ID, 0x0002, (uint)Keys.Space);
        }

        //------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Radius untuk sudut rounded

            // Menentukan sudut rounded
            path.AddArc(0, 0, radius, radius, 180, 90); // Kiri Atas
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Kanan Atas
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Kanan Bawah
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Kiri Bawah
            path.CloseFigure();

            this.Region = new Region(path);
            base.OnPaint(e);
        }
        //------------------------------------------------------------------------

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                ShowForm();
            }
            base.WndProc(ref m);
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            inputTextBox.Focus();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.KeyCode == Keys.W)
            {
                // Ambil teks saat ini dari inputTextBox
                string currentText = inputTextBox.Text;

                // Cari posisi terakhir dari spasi
                int lastSpaceIndex = currentText.LastIndexOf(' ');

                // Hapus kata terakhir
                if (lastSpaceIndex >= 0)
                {
                    // Hapus kata terakhir dengan memotong string
                    inputTextBox.Text = currentText.Substring(0, lastSpaceIndex);
                }
                else
                {
                    // Jika tidak ada spasi, hapus seluruh teks
                    inputTextBox.Clear();
                }

                // Fokus kembali ke inputTextBox
                inputTextBox.Focus();
                e.SuppressKeyPress = true; // Menghindari bunyi beep saat menekan tombol
            }

            if (e.KeyCode == Keys.Escape)
            {
                using (
                    SoundPlayer player = new SoundPlayer(
                        @"E:\Developer\Program\C#\gosLauncher\Sounds\bye.wav"
                    )
                )
                {
                    player.Play();
                }
                this.Hide();
                e.SuppressKeyPress = true;
            }
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // string inputText = inputTextBox.Text;
                string inputText = inputTextBox.Text.Trim();
                try
                {
                    var processInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = inputText,
                        UseShellExecute = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    };
                    System.Diagnostics.Process.Start(processInfo);
                    using (
                        SoundPlayer player = new SoundPlayer(
                            @"E:\Developer\Program\C#\gosLauncher\Sounds\oke.wav"
                        )
                    )
                    {
                        player.Play();
                    }
                    inputTextBox.Clear();
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnregisterHotKey(this.Handle, HOTKEY_ID);
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
