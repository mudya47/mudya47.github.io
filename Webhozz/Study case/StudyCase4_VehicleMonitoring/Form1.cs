using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Previewer;

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
                        colNo.MinimumWidth = 35;
                        dataGridView1.Columns.Add(colNo);

                        DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                        colDate.Name = "Tanggal";
                        colDate.HeaderText = "Tanggal";
                        colDate.MinimumWidth = 150;
                        dataGridView1.Columns.Add(colDate);

                        DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
                        colQty.Name = "Qty_L";
                        colQty.HeaderText = "Pembelian Bensin"; //untuk header, format penulisan lebih baik tanpa ada underscore (hnaya pakai spasi)
                        colQty.MinimumWidth = 100;
                        dataGridView1.Columns.Add(colQty);

                        DataGridViewTextBoxColumn colHargaBbm = new DataGridViewTextBoxColumn();
                        colHargaBbm.Name = "Harga_BBM_Rp";
                        colHargaBbm.HeaderText = "Harga BBM (Rp)";
                        colHargaBbm.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colHargaBbm);

                        DataGridViewTextBoxColumn colAdoBuka = new DataGridViewTextBoxColumn();
                        colAdoBuka.Name = "Adometer_Buka";
                        colAdoBuka.HeaderText = "Adometer Buka";
                        colAdoBuka.MinimumWidth = 100;
                        dataGridView1.Columns.Add(colAdoBuka);

                        DataGridViewTextBoxColumn colAdoTutup = new DataGridViewTextBoxColumn();
                        colAdoTutup.Name = "Adometer_Tutup";
                        colAdoTutup.HeaderText = "Adometer Tutup";
                        colAdoTutup.MinimumWidth = 100;
                        dataGridView1.Columns.Add(colAdoTutup);

                        DataGridViewTextBoxColumn colKM = new DataGridViewTextBoxColumn();
                        colKM.Name = "KM";
                        colKM.HeaderText = "KM";
                        colKM.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colKM);

                        DataGridViewTextBoxColumn colTotalBbm = new DataGridViewTextBoxColumn();
                        colTotalBbm.Name = "Total_BBM_Rp";
                        colTotalBbm.HeaderText = "Total BBM (Rp)";
                        colTotalBbm.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colTotalBbm);

                        DataGridViewTextBoxColumn colBiayaToll = new DataGridViewTextBoxColumn();
                        colBiayaToll.Name = "Biaya_Toll_Rp";
                        colBiayaToll.HeaderText = "Biaya Toll (Rp)";
                        colBiayaToll.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colBiayaToll);

                        DataGridViewTextBoxColumn colParkir = new DataGridViewTextBoxColumn();
                        colParkir.Name = "Parkir_Rp";
                        colParkir.HeaderText = "Parkir (Rp)";
                        colParkir.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colParkir);

                        DataGridViewTextBoxColumn colGrandTotal = new DataGridViewTextBoxColumn();
                        colGrandTotal.Name = "Grand_Total";
                        colGrandTotal.HeaderText = "Grand Total";
                        colGrandTotal.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colGrandTotal);

                        DataGridViewTextBoxColumn colJobNo = new DataGridViewTextBoxColumn();
                        colJobNo.Name = "Job_Number";
                        colJobNo.HeaderText = "Job Number";
                        colJobNo.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colJobNo);

                        DataGridViewTextBoxColumn colSupir = new DataGridViewTextBoxColumn();
                        colSupir.Name = "Supir";
                        colSupir.HeaderText = "Supir";
                        colSupir.MinimumWidth = 50;
                        dataGridView1.Columns.Add(colSupir);

                        DataGridViewTextBoxColumn colEfisienBbm = new DataGridViewTextBoxColumn();
                        colEfisienBbm.Name = "Efisiensi_BBM";
                        colEfisienBbm.HeaderText = "Efisiensi BBM";
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

                    string query = @"SELECT ID, Tanggal, Qty_L, Harga_BBM_Rp, Adometer_Buka, Adometer_Tutup, KM, Total_BBM_Rp, 
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
            //ComboBox options list
            comboQuickRange.Items.AddRange(new string[]
            {
                "Custom", // optional
                "Today",
                "Yesterday",
                "This Week",
                "Last Week",
                "Month to Date",
                "Last Month",
                "Year to Date"
            });
            comboQuickRange.SelectedIndex = 0; // default to "Custom" or your choice
        }

        private void comboQuickRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime start = today, end = today;

            switch (comboQuickRange.SelectedItem.ToString())
            {
                case "Today":
                    start = end = today;
                    break;
                case "Yesterday":
                    start = end = today.AddDays(-1);
                    break;
                case "This Week":
                    int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    start = today.AddDays(-1 * diff);
                    end = today;
                    break;
                case "Last Week":
                    int daysSinceMonday = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    end = today.AddDays(-1 * (daysSinceMonday + 1));
                    start = end.AddDays(-6);
                    break;
                case "Month to Date":
                    start = new DateTime(today.Year, today.Month, 1);
                    end = today;
                    break;
                case "Last Month":
                    DateTime firstDayOfThisMonth = new DateTime(today.Year, today.Month, 1);
                    end = firstDayOfThisMonth.AddDays(-1);
                    start = new DateTime(end.Year, end.Month, 1);
                    break;
                case "Year to Date":
                    start = new DateTime(today.Year, 1, 1);
                    end = today;
                    break;
                default:
                    return;
            }

            startDate.Value = start;
            endDate.Value = end;
            LoadData(start, end);
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            // Switch to "Custom" when user manually changes the start date
            if (comboQuickRange.SelectedItem?.ToString() != "Custom")
                comboQuickRange.SelectedItem = "Custom";
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            // Switch to "Custom" when user manually changes the end date
            if (comboQuickRange.SelectedItem?.ToString() != "Custom")
                comboQuickRange.SelectedItem = "Custom";
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
            int idVehicle = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["No"].Value);
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
            QuestPDF.Settings.License = LicenseType.Community;

            DateTime dateStart = startDate.Value.Date;
            DateTime dateEnd = endDate.Value.Date;
            DataTable data = DataTransportLog(dateStart, dateEnd);

            if (data == null || data.Rows.Count == 0 || data.Columns.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"VehicleMonitoring_{timestamp}.pdf";
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, fileName);

            string SafeText(object val) => val == null || val == DBNull.Value ? "" : val.ToString();

            try
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);
                        page.Size(PageSizes.A4.Landscape());

                        page.Header().Element(x => x
                            .PaddingBottom(10)
                            .AlignCenter()
                            .Text($"TRANSPORT LOG {dateStart:dd-MM-yyyy} - {dateEnd:dd-MM-yyyy}")
                                .FontSize(16).Bold()
                        );

                        page.Content().Table(table =>
                        {
                            // 🧱 Column layout: No. + 14 data columns
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30); // No.
                                for (int i = 0; i < data.Columns.Count; i++)
                                    columns.RelativeColumn();
                            });

                            // 📌 Headers
                            table.Cell().Element(CellStyle).Element(x => x
                                .Background(Colors.Grey.Darken2)
                                .Padding(4)
                                .Text("No.")
                                    .FontSize(10)
                                    .Bold()
                                    .FontColor(Colors.White)
                                    .AlignCenter()
                            );

                            foreach (DataColumn column in data.Columns)
                            {
                                table.Cell().Element(CellStyle).Element(x => x
                                    .Background(Colors.Grey.Darken2)
                                    .Padding(4)
                                    .Text(column.ColumnName)
                                        .FontSize(10)
                                        .Bold()
                                        .FontColor(Colors.White)
                                        .AlignLeft()
                                );
                            }

                            // 📌 Rows
                            int rowNo = 1;
                            foreach (DataRow row in data.Rows)
                            {
                                table.Cell().Element(CellStyle).Text(rowNo++.ToString()).FontSize(9).AlignCenter();

                                for (int i = 0; i < data.Columns.Count; i++)
                                {
                                    string colName = data.Columns[i].ColumnName;
                                    string raw = SafeText(row[i]);

                                    // Format date
                                    if (colName == "Tanggal" && DateTime.TryParse(raw, out DateTime dt))
                                        raw = dt.ToString("dd/MM/yyyy");

                                    // Format Rupiah
                                    if (colName.Contains("Rp") || colName.Contains("Total") || colName.Contains("Harga") || colName.Contains("Parkir") || colName.Contains("Toll"))
                                        raw = decimal.TryParse(raw, out var rp) ? $"Rp {rp:N0}" : raw;

                                    table.Cell().Element(CellStyle).Text(raw).FontSize(9).AlignLeft();
                                }
                            }

                            // 📌 Styling helper
                            static IContainer CellStyle(IContainer container) =>
                                container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                        });

                        // 📅 Footer
                        page.Footer().AlignCenter().Text($"Generated on {DateTime.Now:dd-MM-yyyy HH:mm:ss}");
                    });
                })
                .GeneratePdf(filePath);

                MessageBox.Show($"PDF berhasil disimpan di:\n{filePath}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membuat PDF:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

class DatabaseHelper
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["TransportDB"].ConnectionString;
    }
}