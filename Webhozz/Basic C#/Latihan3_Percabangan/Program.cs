using System;

class Program
{
    //if else sederhana
    static void Main()
    {
        int angka = 10;

        if (angka > 0)
        {
            Console.WriteLine("Angka positif");
        }
        else
        {
            Console.WriteLine("Angka negatif atau nol");
        }

        //if-else banyak kondisi
        int nilai = 10;

        if (nilai >= 90)
        {
            Console.WriteLine("Grade: A");
        }else if (nilai >= 75)
        {
            Console.WriteLine("Grade: B");
        }else if (nilai >= 60)
        {
            Console.WriteLine("Grade: C");
        }else
        {
            Console.WriteLine("Grade: D");
        }

        //if dengan boolean
        bool isLogin = true;

        if (isLogin)
        {
            Console.WriteLine("Selamat datang!");
        }
        else
        {
            Console.WriteLine("Silahkan login dahulu");
        }
    }
}