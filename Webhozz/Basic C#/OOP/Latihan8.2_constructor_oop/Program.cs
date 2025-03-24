using System;


//Class mobil untuk merepresentasikan sebuah mobil
class Mobil
{
    //properti untuk menyimpan merk dan warna mobil
    public string Merk;
    public string Warna;

    //constructor untuk menginisialiasasi objek mobil dengan merk dan warna tertentu
    public Mobil(string merk, string warna)
    {
        Merk = merk;
        Warna = warna;
    }
    //method untuk menampilkan informasi bahwa mobil sedang berjalan
    public void Jalankan()
    {
        Console.WriteLine(Merk + " berwarna " + Warna + " sedang berjaaln.");
    }
}

//program utama (entry point)
class Program
{
    static void Main()
    {
        //membuat objek mobil dengan constructor
        Mobil mobil1 = new Mobil("toyota", "merah");
        Mobil mobil2 = new Mobil("hyundai", "abu");

        //memanggil method Jalankan() untuk masing masig objek
        mobil1.Jalankan();
        mobil2.Jalankan();
    }
}