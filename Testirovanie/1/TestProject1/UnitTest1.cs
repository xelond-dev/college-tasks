namespace TestProject1;

using ConsoleApp2;

[TestClass]
public class UnitTest1
{
        [TestMethod]
        public void TestPassword_ZeroScore()
        {
            // Пустая строка, не содержит ни одной из необходимых характеристик
            Assert.AreEqual(5, Program.CheckPassword(""));
        }

        [TestMethod]
        public void TestPassword_OneScore()
        {
            // Пароль содержит только строчные буквы
            Assert.AreEqual(5, Program.CheckPassword("abcdefg"));
        }

        [TestMethod]
        public void TestPassword_TwoScores()
        {
            // Пароль содержит строчные буквы и цифры
            Assert.AreEqual(5, Program.CheckPassword("abc123"));
        }

        [TestMethod]
        public void TestPassword_ThreeScores()
        {
            // Пароль содержит строчные, заглавные буквы и цифры
            Assert.AreEqual(5, Program.CheckPassword("Abc123"));
        }

        [TestMethod]
        public void TestPassword_FourScores()
        {
            // Пароль содержит строчные, заглавные буквы, цифры и спецсимволы
            Assert.AreEqual(5, Program.CheckPassword("Abc123!"));
        }

        [TestMethod]
        public void TestPassword_FiveScores()
        {
            // Пароль содержит все необходимые компоненты: цифры, строчные и заглавные буквы, спецсимволы, длина > 7
            Assert.AreEqual(5, Program.CheckPassword("Abc123!xyz"));
        }
}
