using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_JabbarTransLibraries
{
    public class ClassTableDriven
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
