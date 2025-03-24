using System.Data;
using Microsoft.Data.SqlClient;

namespace StudyCase3_CrudMHS
{
    public partial class Form1 : Form
    {
        //connection ke database
        private string connectionString = "Server=ALLEN_WILSON\\SQLEXPRESS; Database=Mahasiswa; Integrated Security=True; TrustServerCertificate=True;";
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

                    string query = "SELECT id_mahasiswa, nim, nama, jurusan, angkatan, ipk FROM mahasiswa";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ?? Bersihkan DataGridView sebelum load ulang
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                    colId.Name = "IDMahasiswa"; //Tidak boleh pakai spasi
                    colId.HeaderText = "Id Mahasiswa";
                    colId.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colId);

                    DataGridViewTextBoxColumn colNo = new DataGridViewTextBoxColumn();
                    colNo.Name = "NIM";
                    colNo.HeaderText = "NIM";
                    colNo.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colNo);

                    DataGridViewTextBoxColumn colNama = new DataGridViewTextBoxColumn();
                    colNama.Name = "NamaMahasiswa";
                    colNama.HeaderText = "Nama Mahasiswa";
                    colNama.MinimumWidth = 200;
                    dataGridView1.Columns.Add(colNama);

                    DataGridViewTextBoxColumn colJur = new DataGridViewTextBoxColumn();
                    colJur.Name = "Jurusan";
                    colJur.HeaderText = "Jurusan";
                    colJur.MinimumWidth = 100;
                    dataGridView1.Columns.Add(colJur);

                    DataGridViewTextBoxColumn colAngkatan = new DataGridViewTextBoxColumn();
                    colAngkatan.Name = "Angkatan";
                    colAngkatan.HeaderText = "Angkatan";
                    colAngkatan.MinimumWidth = 80;
                    dataGridView1.Columns.Add(colAngkatan);

                    DataGridViewTextBoxColumn colIpk = new DataGridViewTextBoxColumn();
                    colIpk.Name = "IPK";
                    colIpk.HeaderText = "IPK";
                    colIpk.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colIpk);

                    // ?? Tambahkan data ke dalam DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row["id_mahasiswa"], row["nim"], row["nama"], row["jurusan"], row["angkatan"], row["ipk"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal koneksi ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            form.ShowDialog(); // Menampilkan form sebagai dialog modal
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idMahasiswa = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IDMahasiswa"].Value);
            CreateEditForm form = new CreateEditForm(idMahasiswa);

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            form.ShowDialog(); // Menampilkan form sebagai dialog modal
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mahasiswa = dataGridView1.SelectedRows[0].Cells["NamaMahasiswa"].Value.ToString();

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data " + mahasiswa + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (result == DialogResult.Yes)
                {
                    int idMhs = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IDMahasiswa"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM mahasiswa WHERE id_mahasiswa = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idMhs);
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
