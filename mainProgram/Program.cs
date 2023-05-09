using System;
using System.Diagnostics;
using static JabbarTransLibraries.Kantor;

namespace JabbarTransLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            ProsesPemesanan pesan = new ProsesPemesanan();

            Console.WriteLine("Pilih tempat keberangkatan:");
            Console.WriteLine("1. Bandung");
            Console.WriteLine("2. Jakarta");

            int choice = int.Parse(Console.ReadLine());
            // Pilih kantor pemberangkatan
            pesan.pilihAsal(choice);
            Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
            string keyakinan = Console.ReadLine();

            //Debug.Assert(keyakinan != null || keyakinan != )

            if (keyakinan == "Y" || keyakinan == "y") {
                pesan.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            } else if (keyakinan == "N" || keyakinan == "n") 
            {
                while (keyakinan != "y" && keyakinan != "Y")
                {
                    Console.WriteLine("Pilih tempat keberangkatan:");
                    choice = int.Parse(Console.ReadLine());
                    pesan.pilihAsal(choice);
                    Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                    keyakinan = Console.ReadLine();
                }

                pesan.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }

            if(pesan.pilihAsal(choice) == AreaType.Bandung)
            {
                Console.WriteLine("Trayek tersedia di kantor Bandung:");
                Console.WriteLine("1. Tasik");
                Console.WriteLine("2. Cilacap");
                Console.WriteLine("3. Magelang");
                Console.WriteLine("4. Yogya");
                Console.WriteLine("5. Wonogiri");
                Console.WriteLine("6. Pacitan");

                Console.WriteLine("Pilih kota tujuan");
                int bandungChoice = int.Parse(Console.ReadLine());

                pesan.pilihTujuan<Enum>(choice, bandungChoice);

                Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                keyakinan = Console.ReadLine();

                if (keyakinan == "Y" || keyakinan == "y")
                {
                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                else if (keyakinan == "N" || keyakinan == "n")
                {
                    while (keyakinan != "y" && keyakinan != "Y") 
                    {
                        Console.WriteLine("Pilih kota tujuan");
                        bandungChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, bandungChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    }

                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                
                }
                pesan.cekHarga(choice, bandungChoice);
            } else if (pesan.pilihAsal(choice) == AreaType.Jakarta)
            {
                Console.WriteLine("Trayek tersedia di kantor Jakarta:");
                Console.WriteLine("1. Tasik");
                Console.WriteLine("2. Banjar");
                Console.WriteLine("3. Pangandaran");

                Console.WriteLine("Pilih kota tujuan");
                int jakartaChoice = int.Parse(Console.ReadLine());
                pesan.pilihTujuan<Enum>(choice, jakartaChoice);

                Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                keyakinan = Console.ReadLine();

                if (keyakinan == "Y" || keyakinan == "y")
                {
                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                else if (keyakinan == "N" || keyakinan == "n")
                {
                    while(keyakinan != "y" && keyakinan != "Y")
                    {
                        Console.WriteLine("Pilih kota tujuan");
                        jakartaChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, jakartaChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    } 

                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                 
                }
                pesan.cekHarga(choice, jakartaChoice);
            }
        }
    }
}