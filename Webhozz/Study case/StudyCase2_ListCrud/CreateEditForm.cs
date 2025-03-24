using System;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace StudyCase2_ListCrud
{
    public partial class CreateEditForm : Form
    {
        private string connectionString = "Server=ALLEN_WILSON\\SQLEXPRESS; Database=ecommerce; Integrated Security=True; TrustServerCertificate=True;";

        // id get
        public int? ProdukID { get; set; }
        public CreateEditForm(int? id=null)
        {
            InitializeComponent();

            ProdukID = id;
            if (id != null)
                LoadData(id.Value);

            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadData(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM produk WHERE id_produk = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbNameProduk.Text = reader["nama_produk"].ToString();
                    tbHarga.Text = reader["harga"].ToString();
                    tbStok.Text = reader["stok"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (ProdukID == null)
                    query = "INSERT INTO produk (nama_produk, harga, stok) VALUES (@nama, @harga, @stok)";
                else
                    query = "UPDATE produk SET nama_produk=@nama, harga=@harga, stok=@stok WHERE id_produk=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", tbNameProduk.Text);
                //cmd.Parameters.AddWithValue("@harga", int.Parse(tbHarga.Text));
                cmd.Parameters.AddWithValue("@harga", decimal.Parse(tbHarga.Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@stok", int.Parse(tbStok.Text));

                if (ProdukID != null)
                    cmd.Parameters.AddWithValue("@id", ProdukID.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
