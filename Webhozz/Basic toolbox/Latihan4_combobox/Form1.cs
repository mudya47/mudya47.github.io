namespace Latihan4_combobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string selectedGender = comboBoxGender.SelectedItem?.ToString();
            string alamat = tbAlamat.Text.Trim();

            //MessageBox.Show(name + alamat + selectedGender);

            if (string.IsNullOrEmpty(selectedGender))
            {
                MessageBox.Show("Silahkan pilih jenis kelamin", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
