using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProgram
{
    internal class transportasiUmum
    {
        public enum angkutan
        {
            bus,
            angkot
        };

        public class Daerah {
            public static string getDaerah(angkutan transport) {
                string[] namaDaerah = {
                    "BojongSoang",
                    "Buah Batu"
                };

                return namaDaerah[(int)transport];
            }
        }

        public enum statPesanan { 
            sudahPesan,
            belumMemesan,
        }

        public enum Trigger { 
            berangkat,
            standby
        }

        public class Transport
        {
            private statPesanan currentStat = statPesanan.belumMemesan;

            public class statTransition {
                public statPesanan statAwal;
                public statPesanan statAkhir;
                public Trigger trigger;

                public statTransition(statPesanan statAwal, statPesanan statAkhir, Trigger trigger) { 
                    this.statAwal = statAwal;
                    this.statAkhir = statAkhir;
                    this.trigger = trigger;
                }
            }

            statTransition[] transitions = new statTransition[]
            {
                new statTransition(statPesanan.belumMemesan, statPesanan.belumMemesan, Trigger.standby),
                new statTransition(statPesanan.belumMemesan, statPesanan.sudahPesan, Trigger.berangkat),
                new statTransition(statPesanan.sudahPesan, statPesanan.sudahPesan, Trigger.berangkat),
                new statTransition(statPesanan.sudahPesan, statPesanan.belumMemesan, Trigger.standby)
            };

            private statPesanan getNextStat(statPesanan statAwal, Trigger trigger) {
                statPesanan statAkhir = statAwal;
                for (int i = 0; i < transitions.Length; i++) { 
                    statTransition update = transitions[i];
                    if (statAwal == update.statAwal && trigger == update.trigger) {
                        statAkhir = update.statAkhir;
                    }
                }
                return statAkhir;
            }

            public void activateTrigger(Trigger trigger) {
                currentStat = getNextStat(currentStat, trigger);
                Console.WriteLine(currentStat);

                if (currentStat == statPesanan.belumMemesan) {
                    Console.WriteLine("Tiket belum dipesan");
                } else
                {
                    Console.WriteLine("Tiket sudah dipesan");
                }
            }
        }
    }
}
