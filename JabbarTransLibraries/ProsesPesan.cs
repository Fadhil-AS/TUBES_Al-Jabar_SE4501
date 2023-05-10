using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JabbarTransLibraries.Automata;
using JabbarTransLibraries;

namespace JabbarTransLibraries
{
    public class ProsesPesan<T>
    {
        public enum Bandung
        {
            Tasik = 1,
            Cilacap,
            Magelang,
            Yogya,
            Wonogiri,
            Pacitan
        }
        public enum Jakarta
        {
            Tasik = 1,
            Banjar,
            Pangandaran
        }

        public enum AreaType
        {
            Bandung = 1,
            Jakarta
        }

        private string namaPemesan;
        private AreaType kotaAsal;
        private T kotaTujuan { get; set; }
        public ProsesPesan(string namaPemesan)
        {
            this.namaPemesan = namaPemesan;
        }

        public AreaType getKotaAsal()
        {
            return kotaAsal;
        }

        /*public T getKotaTujuan<T>() where T : Enum
        {
            return kotaTujuan;
        }*/

        public void setKotaTujuan(T kotaTujuan)
        {
            this.kotaTujuan = kotaTujuan;
        }

        public void setKotaAsal(AreaType kotaAsal)
        {
            this.kotaAsal = kotaAsal;
        }

        public void PrintEnumValues<T>()
        {
            Type enumType = typeof(T);

            if (enumType.IsEnum)
            {
                string[] enumNames = System.Enum.GetNames(enumType);

                for (int i = 0; i < enumNames.Length; i++)
                {
                    Console.WriteLine($"{(i + 1)}. {(enumNames[i])}");
                }
            }
            else
            {
                Console.WriteLine("Tipe data bukan enum.");
            }
        }


        public void pilihAsal(int choice)
        {
            //Debug.Assert(currentState == prosesPesan.ASAL, "Maaf, Anda hanya dapat memilih asal saat state berada di ASAL");


            Debug.Assert(choice != null && choice <= 2, "input tidak valid!");

            AreaType selectedEnum = AreaType.Bandung;
            Type enumType = typeof(AreaType);

            for (int i = 0; i <= System.Enum.GetNames(enumType).Length; i++)
            {
                if (choice == i)
                {
                    selectedEnum = (AreaType)i;
                    break;
                }
            }
            setKotaAsal(selectedEnum);
        }

        public void pilihTujuan(int choiceTujuan)
        {
            //Debug.Assert(currentState == prosesPesan.TUJUAN, "Maaf, method ini hanya dapat diakses saat state berada di TUJUAN");

            AreaType kantorAsal = getKotaAsal();

            if (kantorAsal == AreaType.Bandung)
            {
                // Menggunakan enum Bandung


                Debug.Assert(choiceTujuan != null && choiceTujuan <= 6, "input tidak valid!");
                Bandung bandungEnum = Bandung.Tasik;
                Type enumType = typeof(Bandung);

                for (int i = 1; i <= System.Enum.GetNames(enumType).Length; i++)
                {
                    if (choiceTujuan == i)
                    {
                        bandungEnum = (Bandung)i;
                        break;
                    }
                }

                setKotaTujuan((T)(object)bandungEnum);
            }
            else if (kantorAsal == AreaType.Jakarta)
            {
                // Menggunakan enum Jakarta


                Debug.Assert(choiceTujuan != null && choiceTujuan <= 3, "input tidak valid!");
                Jakarta jakartaEnum = Jakarta.Tasik;
                Type enumType = typeof(Bandung);

                for (int i = 0; i < System.Enum.GetNames(enumType).Length; i++)
                {
                    if (choiceTujuan == i)
                    {
                        jakartaEnum = (Jakarta)i;
                        break;
                    }
                }

                setKotaTujuan((T)(object)jakartaEnum);
            }
            else
            {
                throw new ArgumentException("Kantor asal tidak valid!");
            }
        }

        /*public void cekHarga()
        {
            //Debug.Assert(currentState == prosesPesan.HARGA, "Maaf, method ini hanya dapat diakses saat state berada di HARGA");

            AreaType kantorAsal = getKotaAsal();

            if (kantorAsal == AreaType.Bandung)
            {
                Bandung asalBandung = getKotaTujuan<Bandung>();

                switch (asalBandung)
                {
                    case Bandung.Tasik:
                        Console.WriteLine("Harga tiket Bandung - Tasik sebesar Rp. 100.000");
                        break;
                    case Bandung.Cilacap:
                        Console.WriteLine("Harga tiket Bandung - Cilacap sebesar Rp. 120.000");
                        break;
                    case Bandung.Magelang:
                        Console.WriteLine("Harga tiket Bandung - Magelang sebesar Rp. 140.000");
                        break;
                    case Bandung.Yogya:
                        Console.WriteLine("Harga tiket Bandung - Yogya sebesar Rp. 160.000");
                        break;
                    case Bandung.Wonogiri:
                        Console.WriteLine("Harga tiket Bandung - Wonogiri sebesar Rp. 180.000");
                        break;
                    case Bandung.Pacitan:
                        Console.WriteLine("Harga tiket Bandung - Pacitan sebesar Rp. 200.000");
                        break;
                    default:
                        throw new ArgumentException("Tujuan tidak valid!");
                }
            }
            else if (kantorAsal == AreaType.Jakarta)
            {
                Jakarta asalJakarta = kotaTujuan;

                switch (asalJakarta)
                {
                    case Jakarta.Tasik:
                        Console.WriteLine("Harga tiket Jakarta - Tasik sebesar Rp. 100.000");
                        break;
                    case Jakarta.Banjar:
                        Console.WriteLine("Harga tiket Jakarta - Banjar sebesar Rp. 120.000");
                        break;
                    case Jakarta.Pangandaran:
                        Console.WriteLine("Harga tiket Jakarta - Pangadaran sebesar Rp. 140.000");
                        break;
                    default:
                        throw new ArgumentException("Tujuan tidak valid");
                }
            }
        }*/
    }
}
