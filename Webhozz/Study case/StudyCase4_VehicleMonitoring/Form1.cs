using System.Data;
using Microsoft.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;

// ✅ Alias declarations go here:
using PdfFont = iTextSharp.text.Font;
using BaseColor = iTextSharp.text.BaseColor;

class DatabaseHelper
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["TransportDB"].ConnectionString;
    }
}

namespace StudyCase4_VehicleMonitoring
{
    public partial class Form1 : Form
    {
        //jika connection ke databasenya nanti berbeda (Cloud, server atau local), maka connectionstring di bawah akan berubah lagi format isinya.
        string connectionString = DatabaseHelper.GetConnectionString(); 
        private DateTime dateNow = DateTime.Now.Date;

        public Form1()
        {
            InitializeComponent();
            
            LoadData(dateNow, dateNow);
        }
        private void LoadData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
   
                    string query = @"SELECT ID, Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, KM, Total_BBM_Rp, 
                                    Biaya_Toll_Rp, Parkir_Rp, Grand_Total, Job_Number, Supir, Efisiensi_BBM 
                                     FROM TransportLog 
                                    WHERE Tanggal BETWEEN @startDate AND @endDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        // lanjutkan bind ke DataGridView


                        // ?? Bersihkan DataGridView sebelum load ulang
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        DataGridViewTextBoxColumn colNo = new DataGridViewTextBoxColumn();
                        colNo.Name = "No";
                        colNo.HeaderText = "No";
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
                        int rowNumber = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView1.Rows.Add(rowNumber, row["Tanggal"], row["Qty_L"],
                                row["Harga_BBM_Rp"], row["Adometer_Buka"], row["Adometer_Tutup"],
                                row["KM"], row["Total_BBM_Rp"], row["Biaya_Toll_Rp"],
                                row["Parkir_Rp"], row["Grand_Total"], row["Job_Number"],
                                row["Supir"], row["Efisiensi_BBM"]);

                            rowNumber++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal koneksi ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable DataTransportLog(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT ID, Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, KM, Total_BBM_Rp, 
                       Biaya_Toll_Rp, Parkir_Rp, Grand_Total, Job_Number, Supir, Efisiensi_BBM 
                FROM TransportLog 
                WHERE Tanggal BETWEEN @startDate AND @endDate";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data dari database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
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
                LoadData(dateNow, dateNow);

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
                LoadData(dateNow, dateNow);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(dateNow, dateNow);
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

                    LoadData(dateNow, dateNow); // Refresh Data
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Buat nama file dengan timestamp (format: yyyyMMdd_HHmmss)
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"VehicleMonitoring_{timestamp}.pdf";

            // Get user's Downloads folder path
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // Combine into full file path
            string filePath = Path.Combine(downloadsPath, fileName);

            try
            {
                Document doc = new Document(PageSize.A4.Rotate());
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                DateTime dateStart = startDate.Value.Date;
                DateTime dateEnd = endDate.Value.Date;

                string rangeText = $"TRANSPORT LOG {dateStart:dd-MM-yyyy} - {dateEnd:dd-MM-yyyy}";

                // Paragraph title = new Paragraph("Data Karyawan", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD));
                Paragraph title = new Paragraph(rangeText);

                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(14); // Jumlah kolom
                table.WidthPercentage = 100;

                // Optional: header font (bold, white on gray)
                PdfFont headerFont = new PdfFont(PdfFont.FontFamily.HELVETICA, 9f, PdfFont.BOLD, BaseColor.WHITE);
                BaseColor headerBackground = BaseColor.DARK_GRAY;

                // List of headers
                string[] headers = {
                    "No.", "Tanggal", "Pembelian Bensin (Qty L)", "Harga BBM (Rp)", "Adomete Buka",
                    "Adometer Tutup", "KM", "Total BBM (Rp)", "Biaya Toll (Rp)", "Parkir Rp",
                    "Grand Total", "Job Number", "Supir", "Efisiensi BBM"
                };

                // Add styled header cells
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.BackgroundColor = headerBackground;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                DataTable transportData = DataTransportLog(dateStart, dateEnd);

                PdfFont tableFont = new PdfFont(PdfFont.FontFamily.HELVETICA, 9f, PdfFont.NORMAL, BaseColor.BLACK);

                int rowNumber = 1;

                foreach (DataRow row in transportData.Rows)
                {
                    // ⬇️ Add row number as first cell
                    table.AddCell(new Phrase(rowNumber.ToString(), tableFont));

                    // ⬇️ Add the rest of the columns starting from index 1
                    for (int i = 1; i < transportData.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(row[i].ToString(), tableFont));
                    }

                    rowNumber++;
                }


                doc.Add(table);
                doc.Close();

                // Tampilkan pesan jika berhasil
                MessageBox.Show($"PDF berhasil disimpan di:\n{filePath}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                // Tampilkan pesan error jika gagal
                MessageBox.Show($"Terjadi kesalahan:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            DateTime dateStart = startDate.Value.Date;
            DateTime dateEnd = endDate.Value.Date;

            LoadData(dateStart, dateEnd);
        }
    }
}
