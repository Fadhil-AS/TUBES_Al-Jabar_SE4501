using System.Diagnostics;
using static JabbarTransLibraries.Kantor;

namespace JabbarTransLibraries
{
    public class Kantor
    {
        public enum Bandung
        {
            Tasik,
            Cilacap,
            Magelang,
            Yogya,
            Wonogiri,
            Pacitan
        }
        public enum Jakarta
        {
            Tasik,
            Banjar,
            Pangandaran
        }

        public enum AreaType
        {
            Bandung,
            Jakarta
        }

        public enum prosesPesan
        {
            ASAL,
            TUJUAN,
            HARGA,
            DIBERANGKATKAN
        }

        public class ProsesPemesanan
        {
            public prosesPesan currentState = prosesPesan.ASAL;


            public void printCurrentState()
            {
                Console.WriteLine("State sekarang adalah : " + currentState);
            }


            public AreaType pilihAsal(int choice)
            {
                /* Debug.Assert(currentState == prosesPesan.ASAL, "Maaf, Anda hanya dapat memilih asal saat state berada di ASAL");*/
                /*if (currentState != prosesPesan.ASAL)
                {
                    Console.WriteLine("Maaf, method ini hanya dapat diakses saat state berada di ASAL");
                }*/

                Debug.Assert(choice != null && choice <= 2, "input tidak valid!");

                AreaType selectedEnum = AreaType.Bandung;

                if (choice == 1)
                {
                    // Menggunakan enum Bandung
                    selectedEnum = AreaType.Bandung; // Ubah Tasik ke enum yang diinginkan
                    /*Console.WriteLine($"Kantor Pemberangkatan: Bandung");*/

                    currentState = prosesPesan.TUJUAN;
                }
                else if (choice == 2)
                {
                    // Menggunakan enum Jakarta
                    selectedEnum = AreaType.Jakarta; // Ubah Tasik ke enum yang diinginkan
                    /*Console.WriteLine($"Kantor Pemberangkatan: Jakarta");*/

                    currentState = prosesPesan.TUJUAN;
                }
                return selectedEnum;
            }

            public T pilihTujuan<T>(int choice) where T : Enum
            {
                Debug.Assert(currentState == prosesPesan.TUJUAN, "Maaf, method ini hanya dapat diakses saat state berada di TUJUAN");

                AreaType kantorAsal = pilihAsal(choice);


                currentState = prosesPesan.HARGA;

                if (kantorAsal == AreaType.Bandung)
                {
                    // Menggunakan enum Bandung
                    Console.WriteLine("Trayek tersedia di kantor Bandung:");
                    Console.WriteLine("1. Tasik");
                    Console.WriteLine("2. Cilacap");
                    Console.WriteLine("3. Magelang");
                    Console.WriteLine("4. Yogya");
                    Console.WriteLine("5. Wonogiri");
                    Console.WriteLine("6. Pacitan");

                    int bandungChoice = int.Parse(Console.ReadLine());

                    Debug.Assert(bandungChoice != null && bandungChoice <= 6, "input tidak valid!");
                    Bandung bandungEnum;

                    switch (bandungChoice)
                    {
                        case 1:
                            bandungEnum = Bandung.Tasik;
                            break;
                        case 2:
                            bandungEnum = Bandung.Cilacap;
                            break;
                        case 3:
                            bandungEnum = Bandung.Magelang;
                            break;
                        case 4:
                            bandungEnum = Bandung.Yogya;
                            break;
                        case 5:
                            bandungEnum = Bandung.Wonogiri;
                            break;
                        case 6:
                            bandungEnum = Bandung.Pacitan;
                            break;
                        default:
                            throw new ArgumentException("input tidak valid!");
                    }

                    return (T)(object)bandungEnum;
                }
                else if (kantorAsal == AreaType.Jakarta)
                {
                    // Menggunakan enum Jakarta
                    Console.WriteLine("Trayek tersedia di kantor Jakarta:");
                    Console.WriteLine("1. Tasik");
                    Console.WriteLine("2. Banjar");
                    Console.WriteLine("3. Pangandaran");

                    int jakartaChoice = int.Parse(Console.ReadLine());

                    Debug.Assert(jakartaChoice != null && jakartaChoice <= 3, "input tidak valid!");
                    Jakarta jakartaEnum;

                    switch (jakartaChoice)
                    {
                        case 1:
                            jakartaEnum = Jakarta.Tasik;
                            break;
                        case 2:
                            jakartaEnum = Jakarta.Banjar;
                            break;
                        case 3:
                            jakartaEnum = Jakarta.Pangandaran;
                            break;
                        default:
                            throw new ArgumentException("input tidak valid!");
                    }

                    return (T)(object)jakartaEnum;
                }
                else
                {
                    throw new ArgumentException("Kantor asal tidak valid!");
                }
            }
        }
    }
}