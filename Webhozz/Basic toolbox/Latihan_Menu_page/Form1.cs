namespace Latihan_Menu_page
{
    public partial class Form1 : Form
    {
        private UserControl activeControl = null; // Simpan kontrol yang sedang aktif
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowControl(UserControl control)
        {
            if (activeControl != null && activeControl.GetType() == control.GetType())
                return; // Cegah reload jika panel yang sama sudah ditampilkan

            panelContainer.Controls.Clear(); // Hapus tampilan sebelumnya
            control.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(control);
            panelContainer.BringToFront(); // Pastikan panel aktif di depan

            activeControl = control; // Simpan kontrol yang sedang aktif
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowControl(new DashboardControl()); // Tampilkan dashboard saat startup
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashboardControl dashboard = new DashboardControl();
            dashboard.Dock = DockStyle.Fill; // 🔹 Atur agar memenuhi panelContainer
            ShowControl(dashboard);
        }

        private void kendaraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KendaraanControl kendaraan = new KendaraanControl();
            kendaraan.Dock = DockStyle.Fill; // 🔹 Atur agar memenuhi panelContainer
            ShowControl(kendaraan);
        }
    }
}
