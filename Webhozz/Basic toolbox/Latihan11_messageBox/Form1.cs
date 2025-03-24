namespace Latihan11_messageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ini adalah pesan dengan tombol OK.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonOkCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Anda memilih OK.", "Hasil");
            }
            else
            {
                MessageBox.Show("Anda memilih Cancel.", "Hasil");
            }
        }

        private void buttonYesNo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Anda memilih Yes.", "Hasil");
            }
            else
            {
                MessageBox.Show("Anda memilih No.", "Hasil");
            }
        }

        private void buttonYesNoCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menyimpan perubahan?", "Konfirmasi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Data disimpan.", "Hasil");
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Data tidak disimpan.", "Hasil");
            }
            else
            {
                MessageBox.Show("Operasi dibatalkan.", "Hasil");
            }
        }

        private void buttonRetryCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Terjadi kesalahan. Coba lagi?", "Kesalahan", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            if (result == DialogResult.Retry)
            {
                MessageBox.Show("Anda memilih Retry.", "Hasil");
            }
            else
            {
                MessageBox.Show("Anda memilih Cancel.", "Hasil");
            }
        }
    }
}
