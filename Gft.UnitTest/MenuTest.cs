using NUnit.Framework;

namespace Gft.UnitTest
{
    public class MenuTest
    {
        [Test]
        [TestCase("manhã", "ovos, torrada, café", 1, 2, 3)]
        [TestCase("manhã", "ovos, torrada, café", 2, 1, 3)]
        [TestCase("manhã", "ovos, torrada, café, erro", 1, 2, 3, 4)]
        [TestCase("manhã", "ovos, torrada, café (x3)", 1, 2, 3, 3, 3)]
        [TestCase("noite", "carne, batata, vinho, bolo", 1, 2, 3, 4)]
        [TestCase("noite", "carne, batata (x2), bolo", 1, 2, 2, 4)]
        public void TestGenerateMenu(string periodo,string resultado,int[] pratos)
        {
            var menu = new Menu();
            Assert.AreEqual(resultado, menu.Generate(periodo, pratos));
        }
    }
}
