using System.Data;

namespace StudyCase2_ListCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cek apakah dataGridView1 sudah ada
            if (dataGridView1 == null) return;

            // Buat DataTable untuk menyimpan data statis
            DataTable dt = new DataTable();

            // Tambahkan kolom (header)
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Nama Produk", typeof(string));
            dt.Columns.Add("Harga", typeof(int));
            dt.Columns.Add("Stok", typeof(int));

            // Tambahkan 20 data statis ke dalam DataTable
            dt.Rows.Add(1, "Laptop ASUS ROG", 25000000, 10);
            dt.Rows.Add(2, "Mouse Logitech", 350000, 25);
            dt.Rows.Add(3, "Keyboard Mechanical", 750000, 15);
            dt.Rows.Add(4, "Monitor 24 Inch", 2200000, 8);
            dt.Rows.Add(5, "Flashdisk 64GB", 150000, 50);
            dt.Rows.Add(6, "Harddisk External 1TB", 1250000, 12);
            dt.Rows.Add(7, "SSD NVMe 512GB", 1200000, 10);
            dt.Rows.Add(8, "RAM DDR4 16GB", 950000, 18);
            dt.Rows.Add(9, "Power Bank 20.000mAh", 275000, 30);
            dt.Rows.Add(10, "Smartphone Samsung A54", 4500000, 7);
            dt.Rows.Add(11, "iPhone 14 Pro", 18000000, 5);
            dt.Rows.Add(12, "Tablet iPad Air", 12500000, 6);
            dt.Rows.Add(13, "Smartwatch Garmin", 3200000, 9);
            dt.Rows.Add(14, "Headset Gaming Razer", 1800000, 20);
            dt.Rows.Add(15, "Kamera Mirrorless Sony", 14500000, 4);
            dt.Rows.Add(16, "Tripod Kamera", 350000, 22);
            dt.Rows.Add(17, "Printer Canon", 1500000, 11);
            dt.Rows.Add(18, "Scanner Epson", 1800000, 10);
            dt.Rows.Add(19, "Speaker Bluetooth JBL", 850000, 19);
            dt.Rows.Add(20, "Microphone Condenser", 1200000, 14);

            // Set data ke DataGridView
            dataGridView1.DataSource = dt;

            // Styling DataGridView agar lebih rapi
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            form.ShowDialog(); // Menampilkan form sebagai dialog modal
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            form.ShowDialog(); // Menampilkan form sebagai dialog modal
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda ingin menyimpan perubahan?",
                "Konfirmasi Simpan",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Perubahan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Perubahan tidak disimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Aksi dibatalkan.", "Batal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
