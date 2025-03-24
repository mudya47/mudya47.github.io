using System;

class Program
{
    //operasi Dasar
    static void Main()
    {
        int a = 10, b = 3;
        int hasilPenjumlahan = a + b;

        Console.WriteLine("Penjumlahan: " + (a + b));
        Console.WriteLine("Pengurangan: " + (a - b));
        Console.WriteLine("Perkalian: " + (a * b));
        Console.WriteLine("Pembagian: " + (a / b));
        Console.WriteLine("Modulus: " + (a % b));

        Console.WriteLine("Hasil dari penjumlahan: " + a + "+" + b + " adalah: " + hasilPenjumlahan);

        //operator penugasan
        int angka = 5;

        angka += 3;
        Console.WriteLine(angka);
        angka *= 2;
        Console.WriteLine(angka);

        //increment/decrement
        int nilai = 5;

        Console.WriteLine(nilai++); //cetak 5, lalu tambah 1
        Console.WriteLine(nilai); //cetak 6

        Console.WriteLine(++nilai); //tambah 1, lalu cetak 7
        Console.WriteLine(++nilai); //tambah 1, lalu cetak 8
    }
}