using System;
    
class Program
{
    static void Main()
    {   //perulangan for (Loop dengan batasan)
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Perulangan ke " +  i);
        }

        //perulangan while (loop dengan kondisi)
        int angka = 1;
        while (angka <= 5)
        {
            Console.WriteLine("angka: " + angka);
            angka++;
        }

        //perulangan do-while (minimal sekali jalan)
        int nomor = 1; 
        do
        {
            Console.WriteLine("Nomor: " + nomor);
            nomor++;
        } while (nomor <= 5);

        //perulangan foreach (untuk array/list)
        string[] nama = {"Andi","Budi","Citra"};
        foreach (string n in nama)
        {
            Console.WriteLine("Nama: " + n);
        }
    }
}