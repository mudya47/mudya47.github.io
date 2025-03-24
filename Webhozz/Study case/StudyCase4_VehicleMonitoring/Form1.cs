using System.Data;
using Microsoft.Data.SqlClient;

namespace StudyCase4_VehicleMonitoring
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=ALLEN_WILSON\\SQLEXPRESS; Database=Transport; Integrated Security=True; TrustServerCertificate=True;";
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

                    string query = "SELECT ID, Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, KM, Total_BBM_Rp, Biaya_Toll_Rp, Parkir_Rp, Grand_Total, Job_Number, Supir, Efisiensi_BBM FROM TransportLog";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ?? Bersihkan DataGridView sebelum load ulang
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    DataGridViewTextBoxColumn colNo = new DataGridViewTextBoxColumn();
                    colNo.Name = "ID";
                    colNo.HeaderText = "ID";
                    colNo.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colNo);

                    DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                    colDate.Name = "Tanggal";
                    colDate.HeaderText = "Tanggal";
                    colDate.MinimumWidth = 200;
                    dataGridView1.Columns.Add(colDate);

                    DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
                    colQty.Name = "Qty_L";
                    colQty.HeaderText = "Pembelian Bensin";
                    colQty.MinimumWidth = 100;
                    dataGridView1.Columns.Add(colQty);

                    DataGridViewTextBoxColumn colHargaBbm = new DataGridViewTextBoxColumn();
                    colHargaBbm.Name = "Harga_BBM_Rp";
                    colHargaBbm.HeaderText = "Harga_BBM_Rp";
                    colHargaBbm.MinimumWidth = 80;
                    dataGridView1.Columns.Add(colHargaBbm);

                    DataGridViewTextBoxColumn colAdoBuka = new DataGridViewTextBoxColumn();
                    colAdoBuka.Name = "Adometer_Buka";
                    colAdoBuka.HeaderText = "Adometer_Buka";
                    colAdoBuka.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colAdoBuka);

                    DataGridViewTextBoxColumn colAdoTutup = new DataGridViewTextBoxColumn();
                    colAdoTutup.Name = "Adometer_Tutup";
                    colAdoTutup.HeaderText = "Adometer_Tutup";
                    colAdoTutup.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colAdoTutup);

                    DataGridViewTextBoxColumn colKM = new DataGridViewTextBoxColumn();
                    colKM.Name = "KM";
                    colKM.HeaderText = "KM";
                    colKM.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colKM);

                    DataGridViewTextBoxColumn colTotalBbm = new DataGridViewTextBoxColumn();
                    colTotalBbm.Name = "Total_BBM_Rp";
                    colTotalBbm.HeaderText = "Total_BBM_Rp";
                    colTotalBbm.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colTotalBbm);

                    DataGridViewTextBoxColumn colBiayaToll = new DataGridViewTextBoxColumn();
                    colBiayaToll.Name = "Biaya_Toll_Rp";
                    colBiayaToll.HeaderText = "Biaya_Toll_Rp";
                    colBiayaToll.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colBiayaToll);

                    DataGridViewTextBoxColumn colParkir = new DataGridViewTextBoxColumn();
                    colParkir.Name = "Parkir_Rp";
                    colParkir.HeaderText = "Parkir_Rp";
                    colParkir.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colParkir);

                    DataGridViewTextBoxColumn colGrandTotal = new DataGridViewTextBoxColumn();
                    colGrandTotal.Name = "Grand_Total";
                    colGrandTotal.HeaderText = "Grand_Total";
                    colGrandTotal.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colGrandTotal);

                    DataGridViewTextBoxColumn colJobNo = new DataGridViewTextBoxColumn();
                    colJobNo.Name = "Job_Number";
                    colJobNo.HeaderText = "Job_Number";
                    colJobNo.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colJobNo);

                    DataGridViewTextBoxColumn colSupir = new DataGridViewTextBoxColumn();
                    colSupir.Name = "Supir";
                    colSupir.HeaderText = "Supir";
                    colSupir.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colSupir);

                    DataGridViewTextBoxColumn colEfisienBbm = new DataGridViewTextBoxColumn();
                    colEfisienBbm.Name = "Efisiensi_BBM";
                    colEfisienBbm.HeaderText = "Efisiensi_BBM";
                    colEfisienBbm.MinimumWidth = 50;
                    dataGridView1.Columns.Add(colEfisienBbm);

                    // ?? Tambahkan data ke dalam DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row["ID"], row["Tanggal"], row["Qty_L"],
                            row["Harga_BBM_Rp"], row["Adometer_Buka"], row["Adometer_Tutup"],
                            row["KM"], row["Total_BBM_Rp"], row["Biaya_Toll_Rp"],
                            row["Parkir_Rp"], row["Grand_Total"], row["Job_Number"],
                            row["Supir"], row["Efisiensi_BBM"]);
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


            var result = form.ShowDialog(); // Show the form

            if (result == DialogResult.OK) // Refresh only if data was saved
                LoadData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idVehicle = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            CreateEditForm form = new CreateEditForm(idVehicle);

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(
                this.Location.X + (this.Width - form.Width) / 2,
                this.Location.Y + (this.Height - form.Height) / 2
            );

            var result = form.ShowDialog(); // Show the form
            if (result == DialogResult.OK) // Refresh only if data was saved
                LoadData();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string vehicle = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data " + vehicle + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (result == DialogResult.Yes)
                {
                    int idMhs = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM TransportLog WHERE ID = @id";
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
    }
}
