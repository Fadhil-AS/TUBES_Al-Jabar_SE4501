using static JabbarTransLibraries.Automata; //diutamakan untuk Class Enum, ProsesPemesanan, & Automata
using static JabbarTransLibraries.Enum;  //aktif kalo pake Class Enum, ProsesPemesanan, & Automata

namespace JabbarTransLibraries
{
    class Program
    {
        static void Main(string[] args)
        {
            ProsesPesan<Enum> pesan = new ProsesPesan<Enum>("Vikhan");
            Alur menu = new Alur();

            Console.WriteLine("Tempat keberangkatan tersedia:");
            pesan.PrintEnumValues<AreaType>();

            Console.WriteLine("Pilih tempat keberangkatan (angka):");
            int choice = int.Parse(Console.ReadLine());


            pesan.pilihAsal(choice);
            AreaType area = (AreaType)pesan.getKotaAsal();
            string nama = area.ToString();
            Console.WriteLine($"anda memilih kota keberangkatan{(nama)}");

            Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
            string keyakinan = Console.ReadLine();

            if (keyakinan == "Y" || keyakinan == "y")
            {
                menu.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }
            else if (keyakinan == "N" || keyakinan == "n")
            {
                while (keyakinan != "y" && keyakinan != "Y")
                {
                    Console.WriteLine("Pilih tempat keberangkatan:");
                    choice = int.Parse(Console.ReadLine());
                    pesan.pilihAsal(choice);
                    area = (AreaType)pesan.getKotaAsal();
                    nama = area.ToString();
                    Console.WriteLine($"anda memilih kota keberangkatan{(nama)}");
                    Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                    keyakinan = Console.ReadLine();
                }

                menu.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }

            /*ProsesPemesanan pesan = new ProsesPemesanan();

            Console.WriteLine("Tempat keberangkatan tersedia:");
            pesan.PrintEnumValues<AreaType>();

            Console.WriteLine("Pilih tempat keberangkatan (angka):");
            int choice = int.Parse(Console.ReadLine());
            // Pilih kantor pemberangkatan
            pesan.pilihAsal(choice);
            Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
            string keyakinan = Console.ReadLine();

            //Debug.Assert(keyakinan != null || keyakinan != )

            if (keyakinan == "Y" || keyakinan == "y")
            {
                pesan.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }
            else if (keyakinan == "N" || keyakinan == "n")
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

            if (pesan.pilihAsal(choice) == AreaType.Bandung)
            {
                Console.WriteLine("Trayek tersedia di kantor Bandung:");
                pesan.PrintEnumValues<Bandung>();

                Console.WriteLine("Pilih kota tujuan (angka):");
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
                        Console.WriteLine("Pilih kota tujuan (angka):");
                        bandungChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, bandungChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    }

                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);

                }
                pesan.cekHarga(choice, bandungChoice);
            }
            else if (pesan.pilihAsal(choice) == AreaType.Jakarta)
            {
                Console.WriteLine("Trayek tersedia di kantor Jakarta:");
                pesan.PrintEnumValues<Jakarta>();

                Console.WriteLine("Pilih kota tujuan (angka):");
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
                    while (keyakinan != "y" && keyakinan != "Y")
                    {
                        Console.WriteLine("Pilih kota tujuan (angka):");
                        jakartaChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, jakartaChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    }

                    pesan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);

                }
                pesan.cekHarga(choice, jakartaChoice);
            }
        }*/
        }
    }
}