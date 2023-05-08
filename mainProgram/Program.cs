using mainProgram;
using static mainProgram.transportasiUmum;

String namaPenumpang = "Fadhil";
transportasiUmum.angkutan angkt = angkutan.angkot;
string namaDaerah = Daerah.getDaerah(angkt);
Console.WriteLine("Data penumpang: ");
Console.WriteLine(
        "Nama penumpang: " + namaPenumpang
        + "\nAngkutan yang dipakai: " + angkt
        + "\nDaerah: " + namaDaerah
    );

Console.WriteLine("");
Console.WriteLine("Riwayat pemesanan penumpang: ");
Transport transportasi = new Transport();
transportasi.activateTrigger(Trigger.standby);
transportasi.activateTrigger(Trigger.berangkat);
transportasi.activateTrigger(Trigger.standby);
