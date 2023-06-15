using System;

public class Program
{
    static void Menu()  //method untuk menampilkan halaman menu
    {
        while (true)    //agar halaman menu dapat pengulangan sampai kita memilih exit
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("              MENU GANJIL GENAP");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Pilihan: ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)  // untuk validasi pilihan menu yang dipilih
            {
                case 1: //untuk menampilkan isi menu 1 dengan kondisi jika user menginput 2
                    Console.Write("Masukan Bilangan yang ingin di cek: ");
                    int bilangan = Convert.ToInt32(Console.ReadLine());
                    EventOddCheck(bilangan);
                    Console.WriteLine();
                    break;

                case 2: //untuk menampilkan isi menu 2 dengan kondisi jika user menginput 2
                    Console.Write("Pilih (Ganjil/Genap): ");
                    string choice = Console.ReadLine();
                    if (choice == "Ganjil")     //jika choice/inputan yg user masukan adalah 'Ganjil' maka program akan diteruskan
                    {
                        Console.Write("Masukan Limit: ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        if (limit > 0)      //jika inputan limit lebih besar dari 0 maka program akan menjalankan method PrintEvenOdd
                        {
                            PrintEvenOdd(limit, choice);
                        }
                        else        //jika inputan 0 atau lebih kecil dari 0 maka akan muncul teks warning
                        {
                            Console.WriteLine("Input limit tidak valid!!!");
                            Console.WriteLine();
                        }
                    }
                    else if (choice == "Genap")     //jika choice/inputan yg user masukan adalah 'Genap' maka program akan diteruskan
                    {
                        Console.Write("Masukan Limit: ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        if (limit > 0)      //jika inputan limit lebih besar dari 0 maka program akan menjalankan method PrintEvenOdd
                        {
                            PrintEvenOdd(limit, choice);
                        }
                        else        //jika inputan 0 atau lebih kecil dari 0 maka akan muncul teks warning
                        {
                            Console.WriteLine("Input limit tidak valid!!!");
                            Console.WriteLine();
                        }
                    }
                    else        //jika inputan user bukan Ganjil/Genap maka akan muncul teks warning
                    {
                        Console.WriteLine("Input pilihan tidak valid!!!");
                        Console.WriteLine();
                    }
                    break;

                case 3:     //untuk memberhentikan program / exit dengan kondisi jika user menginput 3
                    return;

                default:        //jika user menginput dengan nilai angka lain maka akan muncul teks warning
                    Console.WriteLine("Pilihan tidak valid!!!");
                    Console.WriteLine();
                    break;
            }
        }
    }
    static void PrintEvenOdd(int limit, string choice) //method untuk menghasilkan angka ganjil/genap sesuai inputan user dan juga sesuai batasan yang user minta
    {
        if (choice == "Ganjil")     //jika inputan choice adalah Ganjil program akan diteruskan
        {
            Console.WriteLine($"Print bilangan 1-{limit}: ");
            for (int i = 1; i <= limit; i++)        //untuk pengulangan angka yang akan keluar
            {
                if (i % 2 == 1)     //rumus untuk menghasilkan angka yang akan keluar adalah ganjil
                {
                    Console.Write(i);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        else if (choice == "Genap")     //jika inputan choice adalah Genap program akan diteruskan
        {
            Console.WriteLine($"Print bilangan 1-{limit}: ");
            for (int i = 1; i <= limit; i++)        //untuk pengulangan angka yang akan keluar
            {
                if (i % 2 == 0)     //rumus untuk menghasilkan angka yang akan keluar adalah ganjil
                {
                    Console.Write(i);
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    static void EventOddCheck(int input)        //method untuk mengecek apakah angka yang dimasukan berupa ganjil/genap
    {
        if (input % 2 == 0)     //rumus untuk memastikan jika angka adalah genap
        {
            Console.WriteLine("Genap");
        }
        else        //jika tidak sesuai kondisi diatas maka sudah dipastikan angka adalah ganjil
        {
            Console.WriteLine("Ganjil");
        }
    }
    public static void Main(String[] args)      //untuk menjalankan entry point program ini
    {
        Menu();
    }
}