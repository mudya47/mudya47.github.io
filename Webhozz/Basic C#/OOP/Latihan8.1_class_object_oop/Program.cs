using System;

//Deklarasi class Mobil
class Mobil
{
    public string Merk; //properti untuk menyimpan merk mobil
    public string Warna; //properti untuk menyimpan warna mobil
    public int Ban; //properti untuk menyimpan warna mobil

    //Method (fungsi dalam class)
    public void Jalankan()
    {
        //Menampilkan informasi bahwa mobil sedang berjalan
        Console.WriteLine(Merk + " berwarna " + Warna + " sedang berjalan" + " dan mobil tersebut ban nya ada: " + Ban);
    }
}

//program utama (entry point)
class Program
{
    static void Main()
    {
        //membuat objek dari class Mobil
        Mobil mobil1 = new Mobil(); //membuat objek dari class Mobil
        mobil1.Merk = "Toyota"; //memberikan nilai pada properti merk
        mobil1.Warna = "merah"; //memberikan nilai pada properti warna
        mobil1.Ban = 4; //memberikan nilai pada properti warna

        Mobil mobil2 = new Mobil();
        mobil2.Merk = "Hyundai";
        mobil2.Warna = "Abu";
        mobil2.Ban = 4;

        //memanggil method untuk menampilkan informasi
        mobil1.Jalankan();
        mobil2.Jalankan();
    }
}