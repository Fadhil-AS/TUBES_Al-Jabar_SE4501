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

        public enum Trigger
        {
            PILIH_TUJUAN,
            CEK_HARGA,
            BERANGKAT
        }

        public class ProsesPemesanan
        {
            public prosesPesan currentState = prosesPesan.ASAL;

            public class Transition {
                public prosesPesan stateAwal;
                public prosesPesan stateAkhir;
                public Trigger trigger;

                public Transition(prosesPesan stateAwal, prosesPesan stateAkhir, Trigger trigger)
                {
                    this.stateAwal = stateAwal;
                    this.stateAkhir = stateAkhir;
                    this.trigger = trigger;
                }
            }

            Transition[] transisi =
            {
                new Transition(prosesPesan.ASAL, prosesPesan.TUJUAN, Trigger.PILIH_TUJUAN),
                new Transition(prosesPesan.TUJUAN, prosesPesan.HARGA, Trigger.CEK_HARGA),
                new Transition(prosesPesan.HARGA, prosesPesan.DIBERANGKATKAN, Trigger.BERANGKAT)
            };

            public prosesPesan getStateBerikutnya(prosesPesan stateAwal, Trigger trigger) {
                prosesPesan stateAkhir = stateAwal;

                for (int i = 0; i < transisi.Length; i++)
                {
                    Transition perubahan = transisi[i];

                    if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                    {
                        stateAkhir = perubahan.stateAkhir;
                    }
                }
                currentState = stateAkhir;
                return currentState;
            }

            public void activateTrigger(Trigger trigger) {
                currentState = getStateBerikutnya(currentState, trigger);
                Console.WriteLine(currentState);

                if (currentState == prosesPesan.ASAL)
                {
                    Console.WriteLine("Asal keberangkatan");
                }
                else if (currentState == prosesPesan.TUJUAN)
                {
                    Console.WriteLine("Pilih tujuan keberangkatan");
                }
                else if (currentState == prosesPesan.HARGA)
                {
                    Console.WriteLine("Check harga");
                }
                else {
                    Console.WriteLine("Berangkat");
                }
            }

            public void printCurrentState()
            {
                Console.WriteLine("State sekarang adalah : " + currentState);
            }


            public AreaType pilihAsal(int choice)
            {
                //Debug.Assert(currentState == prosesPesan.ASAL, "Maaf, Anda hanya dapat memilih asal saat state berada di ASAL");
                

                Debug.Assert(choice != null && choice <= 2, "input tidak valid!");

                AreaType selectedEnum = AreaType.Bandung;

                if (choice == 1)
                {
                    // Menggunakan enum Bandung
                    selectedEnum = AreaType.Bandung; // Ubah Tasik ke enum yang diinginkan
                    
                }
                else if (choice == 2)
                {
                    // Menggunakan enum Jakarta
                    selectedEnum = AreaType.Jakarta; // Ubah Tasik ke enum yang diinginkan
                    
                }
                return selectedEnum;
            }
            
            public T pilihTujuan<T>(int choice, int choiceTujuan) where T : Enum
            {
                //Debug.Assert(currentState == prosesPesan.TUJUAN, "Maaf, method ini hanya dapat diakses saat state berada di TUJUAN");

                AreaType kantorAsal = pilihAsal(choice);

                if (kantorAsal == AreaType.Bandung)
                {
                    // Menggunakan enum Bandung
                    

                    Debug.Assert(choiceTujuan != null && choiceTujuan <= 6, "input tidak valid!");
                    Bandung bandungEnum;

                    switch (choiceTujuan)
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
                   

                    Debug.Assert(choiceTujuan != null && choiceTujuan <= 3, "input tidak valid!");
                    Jakarta jakartaEnum;

                    switch (choiceTujuan)
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

            public void cekHarga(int choice, int tujuanChoice)
            {
                Debug.Assert(currentState == prosesPesan.HARGA, "Maaf, method ini hanya dapat diakses saat state berada di HARGA");

                AreaType kantorAsal = pilihAsal(choice);

                if (kantorAsal == AreaType.Bandung)
                {
                    Bandung asalBandung = pilihTujuan<Bandung>(choice, tujuanChoice);

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
                    Jakarta asalJakarta = pilihTujuan<Jakarta>(choice, tujuanChoice);

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
            }
        }
    }
}