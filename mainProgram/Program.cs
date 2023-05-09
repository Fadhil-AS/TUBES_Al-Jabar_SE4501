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

            Console.WriteLine("Pilih kantor pemberangkatan:");
            Console.WriteLine("1. Bandung");
            Console.WriteLine("2. Jakarta");

            int choice = int.Parse(Console.ReadLine());
            // Pilih kantor pemberangkatan
            Console.WriteLine($"Anda memilih kantor pemberangkatan: {pesan.pilihAsal(choice)}");

            // Pilih tujuan
            Console.WriteLine($"Anda memilih kota tujuan: {pesan.pilihTujuan<Enum>(choice)}");

            // Cek harga
            pesan.printCurrentState();
        }
    }
}