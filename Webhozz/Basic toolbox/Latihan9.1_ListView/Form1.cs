namespace Latihan9._1_ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set mode tampilan ListView ke Detail
            listView1.View = View.Details;

            // Tambahkan kolom ke ListView
            //listView1.Columns.Add("No", 50);


            // Tambahkan 10 data sample ke ListView
            string[,] produk = {
                { "1", "Laptop ASUS", "10.000.000", "5" },
                { "2", "Mouse Logitech", "250.000", "15" },
                { "3", "Keyboard Razer", "1.500.000", "10" },
                { "4", "Monitor LG 24\"", "2.000.000", "8" },
                { "5", "SSD NVMe 512GB", "1.200.000", "12" },
                { "6", "Flashdisk 64GB", "120.000", "20" },
                { "7", "Headset Gaming", "600.000", "7" },
                { "8", "Printer Epson L3110", "2.800.000", "6" },
                { "9", "Router TP-Link", "450.000", "10" },
                { "10", "Harddisk Eksternal 1TB", "1.000.000", "9" }
             };

            for (int i = 0; i < 10; i++)
            {
                ListViewItem item = new ListViewItem(produk[i, 0]); // No
                item.SubItems.Add(produk[i, 1]); // Nama Produk
                item.SubItems.Add(produk[i, 2]); // Harga
                item.SubItems.Add(produk[i, 3]); // Stok
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
