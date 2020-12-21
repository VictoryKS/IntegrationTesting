using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.FileWorker;
using IIG.PasswordHashingUtils;

namespace IntegrationTesting
{
    [TestClass]
    public class PasswordHashingUtillsWithFileTest
    {
        private string password = "password";
        private string salt1 = "salt1";
        private string salt2 = "salt2";
        private string outputFile = "F:/Учебники/4 курс/QA/Labs/IntegrationTesting/temp/test_hashing_output.txt";
        private string inputFile_readAll = "F:/Учебники/4 курс/QA/Labs/IntegrationTesting/temp/test_hashing_input_readAll.txt";
        private string inputFile_readLines = "F:/Учебники/4 курс/QA/Labs/IntegrationTesting/temp/test_hashing_input_readLines.txt";

        [TestMethod]
        public void TestWriteHash()
        {
            Assert.IsTrue(BaseFileWorker.Write(PasswordHasher.GetHash(password, salt2), outputFile));
        }

        [TestMethod]
        public void TestReadHash_ReadLines_Equal()
        {
            string[] lines = BaseFileWorker.ReadLines(inputFile_readLines);
            Assert.AreEqual(PasswordHasher.GetHash(password, salt1), lines[0]);
            Assert.AreEqual(PasswordHasher.GetHash(password, salt2), lines[1]);
        }

        [TestMethod]
        public void TestReadHash_ReadLines_NotEqual()
        {
            string[] lines = BaseFileWorker.ReadLines(inputFile_readLines);
            Assert.AreNotEqual(PasswordHasher.GetHash(password, salt2), lines[0]);
            Assert.AreNotEqual(PasswordHasher.GetHash(password, salt1), lines[1]);
        }

        [TestMethod]
        public void TestReadHash_ReaadAll_Equal()
        {
            string content = BaseFileWorker.ReadAll(inputFile_readAll);
            Assert.AreEqual(PasswordHasher.GetHash(password, salt2), content);
        }

        [TestMethod]
        public void TestReadHash_ReaadAll_NotEqual()
        {
            string content = BaseFileWorker.ReadAll(inputFile_readAll);
            Assert.AreNotEqual(PasswordHasher.GetHash(password, salt1), content);
        }
    }
}
