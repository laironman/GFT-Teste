using NUnit.Framework;

namespace Gft.UnitTest
{
    public class MenuTest
    {
        [Test]
        [TestCase("manh�", "ovos, torrada, caf�", 1, 2, 3)]
        [TestCase("manh�", "ovos, torrada, caf�", 2, 1, 3)]
        [TestCase("manh�", "ovos, torrada, caf�, erro", 1, 2, 3, 4)]
        [TestCase("manh�", "ovos, torrada, caf� (x3)", 1, 2, 3, 3, 3)]
        [TestCase("noite", "carne, batata, vinho, bolo", 1, 2, 3, 4)]
        [TestCase("noite", "carne, batata (x2), bolo", 1, 2, 2, 4)]
        public void TestGenerateMenu(string periodo,string resultado,int[] pratos)
        {
            var menu = new Menu();
            Assert.AreEqual(resultado, menu.Generate(periodo, pratos));
        }
    }
}
