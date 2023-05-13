using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_JabbarTransLibraries
{
    public class ClassTableDriven
    {
        public class Kantor {
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
        }
    }
}
