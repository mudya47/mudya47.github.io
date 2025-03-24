using System;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace StudyCase3_CrudMHS
{
    public partial class CreateEditForm : Form
    {
        //database connection
        private string connectionString = "Server=ALLEN_WILSON\\SQLEXPRESS; Database=Mahasiswa; Integrated Security=True; TrustServerCertificate=True;";

        public int? MhsID { get; set; }
        public CreateEditForm(int? id = null)
        {
            InitializeComponent();

            MhsID = id;
            if (id != null)
                LoadData(id.Value);
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadData(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM mahasiswa WHERE id_mahasiswa = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    txtNim.Text = reader["nim"].ToString();
                    txtNama.Text = reader["nama"].ToString();
                    txtJurusan.Text = reader["jurusan"].ToString();
                    txtAngkatan.Text = reader["angkatan"].ToString();
                    txtIPK.Text = reader["ipk"].ToString();
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

                if (MhsID == null)
                    query = "INSERT INTO mahasiswa (nim, nama, jurusan, angkatan, ipk) VALUES (@nim, @nama, @jurusan, @angkatan, @ipk)";
                else
                    query = "UPDATE mahasiswa SET nim=@nim, nama=@nama, jurusan=@jurusan, angkatan=@angkatan, ipk=@ipk WHERE id_mahasiswa=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nim", txtNim.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@jurusan", txtJurusan.Text);
                cmd.Parameters.AddWithValue("@angkatan", int.Parse(txtAngkatan.Text));
                cmd.Parameters.AddWithValue("@IPK", decimal.Parse(txtIPK.Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));
                
                if (MhsID != null)
                    cmd.Parameters.AddWithValue("@id", MhsID.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
