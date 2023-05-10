using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProgram
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
        }
}
