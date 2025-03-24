using System;

class Program
{
    static void Main()
    {
        //deklarasi dan inisiasi array
        int[] angka = {10, 20, 30, 40, 50};

        //akses elemen array
        Console.WriteLine("element pertama: " + angka[0]); //10
        Console.WriteLine("element terakhir: " + angka[4]); //50
        Console.WriteLine("element terakhir: " + angka[3]); //40

        //looping pada array
        for (int i = 0; i < angka.Length; i++)
        {
            Console.WriteLine("Element ke " + i + ": " + angka[i]);
        }

        //foreach untuk array
        string[] nama = { "Andi", "Budi", "Citra" };
        foreach (string n in nama)
        {
            Console.WriteLine("Nama: " + n);
        }
    }
}