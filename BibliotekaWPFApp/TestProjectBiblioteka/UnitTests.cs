using BibliotekaWPFApp;

namespace TestProjectBiblioteka
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void BookToStringTest()
        {
            Ksiazka b = new Ksiazka("title1","author1",1);

            Assert.IsTrue(b.ToString().Contains("title1") && b.ToString().Contains("author1"));
        }

        [TestMethod]
        public void BorrowToStringTest()
        {
            Wpozyczenie b = new Wpozyczenie(1,1);

            Assert.IsTrue(b.ToString().Contains("Wypo¿yczono"));
        }

        [TestMethod]
        public void ClientToStringTest()
        {
            Klient c = new Klient("Jan", "Kowalski");

            Assert.IsTrue(c.ToString().Contains("Jan") && c.ToString().Contains("Kowalski"));
        }


        [TestMethod]
        public void CategoryToStringTest()
        {
            Kategoria c = new Kategoria("Krymina³");

            Assert.IsTrue(c.ToString().Contains("Krymina³"));
        }


    }
}