using System;
using System.Collections.Generic; //library untuk list

class Program
{
    static void Main()
    {
        List<string> namaList = new List<string>();

        //penambahan data
        namaList.Add("Andi");
        namaList.Add("Budi");
        namaList.Add("Citra");

        //menampilkan isi list
        foreach (string nama in namaList)
        {
            Console.WriteLine("Nama: " + nama);
        }

        //operasi dasar pada List
        List<int> angkaList = new List<int>() { 10, 20, 30 };

        //penambahan element
        angkaList.Add(40);
        angkaList.Add(50);

        //menghapus element
        angkaList.Remove(20); //menghapus element yang nilainya 20
        angkaList.RemoveAt(0); //RemoveAt berfungsi untuk menghapus element yang berada pada index 0

        //menampilkan list
        foreach (int angka in angkaList)
        {
            Console.WriteLine(angka);
        }
    }
}