using Microsoft.Data.SqlClient;

namespace StudyCase4_VehicleMonitoring
{
    public partial class CreateEditForm : Form
    {
        //jika connection ke databasenya nanti berbeda (Cloud, server atau local), maka connectionstring di bawah akan berubah lagi format isinya.
        string connectionString = DatabaseHelper.GetConnectionString();
        public int? VehID { get; set; }
        public CreateEditForm(int? id = null)
        {
            InitializeComponent();

            VehID = id;
            if (id != null)
                LoadData(id.Value);
            this.DialogResult = DialogResult.Cancel;
        }
        private void LoadData(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TransportLog WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dateTimePicker1.Text = reader["Tanggal"].ToString();
                    tbQty.Text = reader["Qty_L"].ToString();
                    tbHarga.Text = reader["Harga_BBM_Rp"].ToString();
                    tbAdoBuka.Text = reader["Adometer_Buka"].ToString();
                    tbAdoTutup.Text = reader["Adometer_Tutup"].ToString();
                    tbKm.Text = reader["KM"].ToString();
                    tbTotal.Text = reader["Total_BBM_Rp"].ToString();
                    tbTol.Text = reader["Biaya_Toll_Rp"].ToString();
                    tbParkir.Text = reader["Parkir_Rp"].ToString();
                    tbGrand.Text = reader["Grand_Total"].ToString();
                    tbJob.Text = reader["Job_Number"].ToString();
                    tbSupir.Text = reader["Supir"].ToString();
                    cbEfisien.Text = reader["Efisiensi_BBM"].ToString();
                }
            }
        }

        private void CreateEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (VehID == null)
                {
                    // Removed KM, Total_BBM_Rp, and Grand_Total from INSERT
                    query = "INSERT INTO TransportLog (Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, Biaya_Toll_Rp, Parkir_Rp, Job_Number, Supir, Efisiensi_BBM) " +
                            "VALUES (@Tanggal, @Qty_L, @Harga_BBM_Rp, @Adometer_Buka, @Adometer_Tutup, @Biaya_Toll_Rp, @Parkir_Rp, @Job_Number, @Supir, @Efisiensi_BBM)";
                }
                else
                {
                    // Removed KM, Total_BBM_Rp, and Grand_Total from UPDATE
                    query = "UPDATE TransportLog SET Tanggal=@Tanggal, Qty_L=@Qty_L, Harga_BBM_Rp=@Harga_BBM_Rp, Adometer_Buka=@Adometer_Buka, Adometer_Tutup=@Adometer_Tutup, " +
                            "Biaya_Toll_Rp=@Biaya_Toll_Rp, Parkir_Rp=@Parkir_Rp, Job_Number=@Job_Number, Supir=@Supir, Efisiensi_BBM=@Efisiensi_BBM WHERE ID=@id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@Tanggal", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Qty_L", Convert.ToDouble(tbQty.Text));
                cmd.Parameters.AddWithValue("@Harga_BBM_Rp", Convert.ToInt32(tbHarga.Text));
                cmd.Parameters.AddWithValue("@Adometer_Buka", Convert.ToInt32(tbAdoBuka.Text));
                cmd.Parameters.AddWithValue("@Adometer_Tutup", Convert.ToInt32(tbAdoTutup.Text));
                cmd.Parameters.AddWithValue("@Biaya_Toll_Rp", Convert.ToInt32(tbTol.Text));
                cmd.Parameters.AddWithValue("@Parkir_Rp", Convert.ToInt32(tbParkir.Text));
                cmd.Parameters.AddWithValue("@Job_Number", tbJob.Text);
                cmd.Parameters.AddWithValue("@Supir", tbSupir.Text);
                cmd.Parameters.AddWithValue("@Efisiensi_BBM", cbEfisien.SelectedItem?.ToString() ?? "");

                if (cbEfisien.SelectedItem == null)
                {
                    MessageBox.Show("Please select an Efisiensi BBM value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (VehID != null)
                    cmd.Parameters.AddWithValue("@id", VehID.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }



        }
    }
}
