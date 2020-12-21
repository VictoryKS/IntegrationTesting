using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;

namespace IntegrationTesting
{
    [TestClass]
    public class PasswordHashingUtilsTest
    {
        [TestMethod]
        public void TestGetHash()
        {
            string pass = "passwrd";

            string result = PasswordHasher.GetHash(pass);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(pass, result);
        }

        [TestMethod]
        public void TestGetHash2()
        {
            string pass = "passwrd";
            string salt = "salt";

            string result = PasswordHasher.GetHash(pass, salt);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(pass, result);
        }

        [TestMethod]
        public void TestGetHash3()
        {
            string pass = "passwrd";
            uint adlerMod32 = 16;

            string result = PasswordHasher.GetHash(pass, null, adlerMod32);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(pass, result);
        }

        [TestMethod]
        public void TestGetHash4()
        {
            string pass = "passwrd";
            string salt = "salt";
            uint adlerMod32 = 16;

            string result = PasswordHasher.GetHash(pass, salt, adlerMod32);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(pass, result);
        }

        [TestMethod]
        public void TestGetHashSpecialSymbols()
        {
            string pass1 = "紅蓮華 𝅘𝅥𝅯𝅘𝅥𝅯";
            string pass2 = "Кириллица";
            string salt1 = "salt";
            string salt2 = "𝄞𝅘𝅥𝅯𝅗𝅥";
            uint adlerMod32 = 16;

            string result1 = PasswordHasher.GetHash(pass1, salt1, adlerMod32);

            Assert.IsNotNull(result1);
            Assert.AreNotEqual(pass1, result1);

            string result2 = PasswordHasher.GetHash(pass2, salt1, adlerMod32);

            Assert.IsNotNull(result2);
            Assert.AreNotEqual(pass2, result2);

            Assert.ThrowsException<OverflowException>(() => PasswordHasher.GetHash(pass1, salt2, adlerMod32));
        }

        [TestMethod]
        public void TestInit()
        {
            string pass = "passwrd";
            string salt1 = "salt1";
            string salt2 = "salt2";
            uint adlerMod32 = 16;

            PasswordHasher.Init(salt1, adlerMod32);
            Assert.AreEqual(PasswordHasher.GetHash(pass), PasswordHasher.GetHash(pass, salt1, adlerMod32));

            Assert.AreNotEqual(PasswordHasher.GetHash(pass), PasswordHasher.GetHash(pass, salt2, adlerMod32));
        }

        [TestMethod]
        public void TestInitNull()
        {
            string pass = "passwrd";
            string salt1 = null;
            uint adlerMod32 = 16;

            PasswordHasher.Init(salt1, adlerMod32);
            Assert.AreEqual(PasswordHasher.GetHash(pass), PasswordHasher.GetHash(pass, salt1, adlerMod32));
        }

        [TestMethod]
        public void TestPasswordNull()
        {
            string pass = null;
            Assert.ThrowsException<ArgumentNullException>(() => PasswordHasher.GetHash(pass));
        }

        [TestMethod]
        public void TestPasswordEmpty()
        {
            string pass = "";

            Assert.IsNotNull(PasswordHasher.GetHash(pass));
        }
    }
}
