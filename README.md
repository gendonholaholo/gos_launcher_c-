# gosLauncher

gosLauncher adalah aplikasi Windows yang memungkinkan pengguna untuk menjalankan aplikasi lain
dengan menggunakan input teks. Aplikasi ini dirancang dengan tampilan minimalis dan
menyediakan fitur hotkey untuk memudahkan akses.

## Fitur

- **Input Teks**: Pengguna dapat memasukkan nama aplikasi untuk dijalankan.
- **Hotkey**: Menekan `Space` akan membuka aplikasi di tray.
- **Konsep Tray**: Aplikasi berjalan di tray sistem dengan menu konteks untuk keluar.
- **Hapus Kata Terakhir**: Tekan `Ctrl + W` untuk menghapus kata terakhir dari input.
- **Tutup Aplikasi**: Tekan `Esc` untuk menyembunyikan aplikasi dengan suara yang diatur.

## Prasyarat

- .NET Framework 4.5 atau lebih tinggi.
- Windows OS.

## Instalasi

1. **Clone repositori**:

   ```bash
   git clone https://github.com/username/gosLauncher.git

Buka proyek di Visual Studio.

2. Atur ikon dan suara:
   - Ganti path ikon dan suara di Form1.Designer.cs dan Form1.cs dengan path yang sesuai di
sistem kamu.
   - Jalankan aplikasi.

3. Penggunaan:
   - Setelah aplikasi dijalankan, pengguna dapat memasukkan nama aplikasi di TextBox yang
disediakan.
   - Klik dua kali pada ikon tray untuk membuka kembali aplikasi.
   - Gunakan `Ctrl + W` untuk menghapus kata terakhir dari input dan `Esc` untuk
menyembunyikan aplikasi.
