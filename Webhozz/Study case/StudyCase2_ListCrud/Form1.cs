using System.Data;
using Microsoft.Data.SqlClient;

namespace StudyCase2_ListCrud
{
    public partial class Form1 : Form
    {
        // connection db
        private string connectionString = "Server=ALLEN_WILSON\\SQLEXPRESS; Database=ecommerce; Integrated Security=True; TrustServerCertificate=True;";
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id_produk, nama_produk, harga, stok FROM produk";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ?? Bersihkan DataGridView sebelum load ulang
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    DataGridViewTextBoxColumn colNo = new DataGridViewTextBoxColumn();
                    colNo.Name = "No";
                    colNo.HeaderText = "No";
                    colNo.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colNo);

                    DataGridViewTextBoxColumn colNama = new DataGridViewTextBoxColumn();
                    colNama.Name = "NamaProduk";
                    colNama.HeaderText = "Nama Produk";
                    colNama.MinimumWidth = 200;
                    dataGridView1.Columns.Add(colNama);

                    DataGridViewTextBoxColumn colHarga = new DataGridViewTextBoxColumn();
                    colHarga.Name = "Harga";
                    colHarga.HeaderText = "Harga";
                    colHarga.MinimumWidth = 100;
                    dataGridView1.Columns.Add(colHarga);

                    DataGridViewTextBoxColumn colStok = new DataGridViewTextBoxColumn();
                    colStok.Name = "Stok";
                    colStok.HeaderText = "Stok";
                    colStok.MinimumWidth = 80;
                    dataGridView1.Columns.Add(colStok);

                    // ?? Tambahkan data ke dalam DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row["id_produk"], row["nama_produk"], row["harga"], row["stok"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal koneksi ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            int idProduk = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["No"].Value);
            CreateEditForm form = new CreateEditForm(idProduk);

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            form.ShowDialog(); // Menampilkan form sebagai dialog modal
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string produk = dataGridView1.SelectedRows[0].Cells["NamaProduk"].Value.ToString();

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data " + produk + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (result == DialogResult.Yes)
                {
                    int idProduk = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["No"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM produk WHERE id_produk = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data berhasil dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(); // Refresh Data
                }
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
