using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabbarTransLibraries
{
    public class Enum
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
