using System;

class Program
{
    static void SapaUser()//fungsi tanpa parameter
    {
        Console.WriteLine("Hallo, selamat datang!");
    }

    static void TampilNama(string nama)//fungsi dengan parameter
    {
        Console.WriteLine("Halo, " + nama + "!");
    }
    static int Tambah (int a, int b) //fungsi dengan return value
    {
        return a + b;
    }
    static void Main() //function Main adalah function utama yang akan ditampilkan saat aplikasi dijalankan
    {
        SapaUser();
        TampilNama("A");
        int hasil1 = Tambah(1, 2);
        int hasil2 = Tambah(3, 4);
        Console.WriteLine("Hasil penjumlahan: " + hasil1);
        Console.WriteLine("Hasil penjumlahan: " + hasil2);
    }


}