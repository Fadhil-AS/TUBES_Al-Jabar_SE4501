using Al_JabbarTransLibraries;
using NUnit.Framework;
using static Al_JabbarTransLibraries.ClassAutomata;
using static Al_JabbarTransLibraries.ClassTableDriven.Kantor;


namespace TestProject_Automata
{
    public class Tests
    {
       

        [Test]
        public void TransitionConstructor_InitializesProperties()
        {
            // Arrange
            prosesPesan stateAwal = prosesPesan.ASAL;
            prosesPesan stateAkhir = prosesPesan.TUJUAN;
            Trigger trigger = Trigger.PILIH_TUJUAN;

            // Act
            var transition = new ClassAutomata.prosesPemesanan.Transition(stateAwal, stateAkhir, trigger);

            // Assert
            Assert.AreEqual(stateAwal, transition.stateAwal);
            Assert.AreEqual(stateAkhir, transition.stateAkhir);
            Assert.AreEqual(trigger, transition.trigger);
        }

        [Test]
        public void TestGetStateBerikutnya()
        {
            ClassAutomata.prosesPemesanan pesanan = new ClassAutomata.prosesPemesanan();

            // Test case 1
            Assert.AreEqual(pesanan.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN), prosesPesan.TUJUAN);

            // Test case 2
            Assert.AreEqual(pesanan.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA), prosesPesan.HARGA);

            // Test case 3
            Assert.AreEqual(pesanan.getStateBerikutnya(prosesPesan.HARGA, Trigger.BERANGKAT), prosesPesan.DIBERANGKATKAN);
        }

        [Test]
        public void ActivateTrigger_ShouldUpdateCurrentStateAndPrintMessage()
        {
            // Arrange
            prosesPemesanan prosesPesan = new prosesPemesanan();

            // Act
            prosesPesan.activateTrigger(Trigger.PILIH_TUJUAN);

            // Assert
            Assert.AreEqual(prosesPesan.currentState, prosesPesan.getStateBerikutnya(prosesPesan.currentState, Trigger.PILIH_TUJUAN));
        }

        [Test]
        public void TestPrintCurrentState()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ClassAutomata.prosesPemesanan automata = new ClassAutomata.prosesPemesanan();
                automata.printCurrentState();
                string expectedOutput = "State sekarang adalah : ASAL" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

    }
}