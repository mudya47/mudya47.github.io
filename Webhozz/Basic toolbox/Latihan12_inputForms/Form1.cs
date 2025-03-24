using System.Windows.Forms;

namespace Latihan12_inputForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Ambil data dari form
            string nama = tbName.Text;
            string tanggalLahir = dtpTTL.Value.ToShortDateString();
            string jenisKelamin = rbP.Checked ? "Laki-laki" : "Perempuan"; //inline if-else; jika rbP tercheck maka nilai yang diambil adalah Laki2 (true)
            string telepon = mtbTel.Text;
            string alamat = rtbAlamat.Text;
            string tnc = cbY.Checked ? "Ya" : "Tidak"; //inline if-else (sama sperti jenis kelamin)
            string hobby = lbHobby.SelectedItem?.ToString() ?? ""; //selecteditem dipakai untuk mengambil nilai yang terpilih
            string paket = cbPaket.SelectedItem?.ToString() ?? ""; //icon ? pada selectedItem, walaupun nilai null dan diconvert ke string maka tidak akan menghasilkan error

            // Validasi input
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbP.Checked && !rbW.Checked)//jika kedua radiobutton belum tercheck maka muncul MessageBox
            {
                MessageBox.Show("Pilih jenis kelamin!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(telepon))
            {
                MessageBox.Show("No. Telepon tidak boleh kosong");
                return;
            }

            if (string.IsNullOrWhiteSpace(alamat))
            {
                MessageBox.Show("Alamat tidak boleh kosong");
                return;
            }

            if (paket == "")
            {
                MessageBox.Show("Paket belum terpilih!");
                return;
            }

            if (hobby == "")
            {
                MessageBox.Show("Hobby belum terpilih!");
                return;
            }

            if (!cbY.Checked && !cbT.Checked)//jika kedua radiobutton belum tercheck maka muncul MessageBox
            {
                MessageBox.Show("Anda belum memilih kesetujuan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //MessageBox.Show(nama);
            //MessageBox.Show(tanggalLahir);
            //MessageBox.Show(jenisKelamin);
            //MessageBox.Show(telepon);
            //MessageBox.Show(alamat);
            //MessageBox.Show(paket);
            //MessageBox.Show(tnc);
            //MessageBox.Show(hobby);


        }
    }
}
