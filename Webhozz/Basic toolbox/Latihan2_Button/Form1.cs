namespace Latihan2_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbNoHP.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string namaLengkap = tbName.Text.Trim(); //cara untuk mengambil nilai dari textbox
            string noHP = tbNoHP.Text.Trim();  //cara untuk mengambil nilai dari textbox
            //MessageBox.Show(namaLengkap + " No HP: " + noHP); //menampilan nilai yang diinput dari textbox

            if (string.IsNullOrWhiteSpace(namaLengkap) && string.IsNullOrWhiteSpace(noHP))
            {
                MessageBox.Show("Fields cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }else if (string.IsNullOrWhiteSpace(namaLengkap))
            {
                MessageBox.Show("Nama Lengkap must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(noHP))
            {
                MessageBox.Show("No. Handphone must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            else
            // If both fields are filled
            MessageBox.Show("Proses submit berhasil", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
