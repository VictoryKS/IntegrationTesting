using IIG.BinaryFlag;
using IIG.CoSFE.DatabaseUtils;
using IIG.PasswordHashingUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntegrationTesting
{
    [TestClass]
    public class BinaryFlagWithDBTest
    {
        private const string Server = @"DESKTOP-6MADJRE";
        private const string Database = @"IIG.CoSWE.FlagpoleDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"12345";
        private const int ConnectionTime = 75;
        private FlagpoleDatabaseUtils flagpoleDatabaseUtils = new FlagpoleDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);

        private MultipleBinaryFlag binaryFlag_10 = new MultipleBinaryFlag(10);
        private MultipleBinaryFlag binaryFlag_10_f = new MultipleBinaryFlag(10, false);
        private MultipleBinaryFlag binaryFlag_33 = new MultipleBinaryFlag(33);
        private MultipleBinaryFlag binaryFlag_33_f = new MultipleBinaryFlag(33, false);
        private MultipleBinaryFlag binaryFlag_65 = new MultipleBinaryFlag(65);
        private MultipleBinaryFlag binaryFlag_65_f = new MultipleBinaryFlag(65, false);

        [TestMethod]
        public void Test_AddFlag_10()
        {
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("t", binaryFlag_10.GetFlag()));
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("f", binaryFlag_10_f.GetFlag()));
        }
        [TestMethod]
        public void Test_AddFlag_33()
        {
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("tTt", binaryFlag_33.GetFlag()));
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("fFf", binaryFlag_33_f.GetFlag()));
        }
        [TestMethod]
        public void Test_AddFlag_65()
        {
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("TTT", binaryFlag_65.GetFlag()));
            Assert.IsTrue(flagpoleDatabaseUtils.AddFlag("FFF", binaryFlag_65_f.GetFlag()));
        }

        [TestMethod]
        public void Test_AddFlag_65_Ecxeption()
        {
            Assert.IsFalse(flagpoleDatabaseUtils.AddFlag("ghj", binaryFlag_65.GetFlag()));
            Assert.IsFalse(flagpoleDatabaseUtils.AddFlag("t", binaryFlag_65_f.GetFlag()));
        }

        [TestMethod]
        public void Test_GetFlagFromDB()
        {
            string flagView;
            bool? flagValue;
            flagpoleDatabaseUtils.GetFlag(3, out flagView, out flagValue); 
            Assert.AreEqual(true, flagValue);
            Assert.AreEqual("tTt", flagView);
        }

        [TestMethod]
        public void Test_GetFlagFromDB_Exception()
        {
            string flagView;
            bool? flagValue; 
            Assert.IsFalse(flagpoleDatabaseUtils.GetFlag(1000, out flagView, out flagValue));
            Assert.IsFalse(flagpoleDatabaseUtils.GetFlag(-1000, out flagView, out flagValue));
        }

        [TestMethod]
        public void Test_GetFlagFromDB_SetFlag()
        {
            Assert.IsFalse(binaryFlag_10_f.GetFlag());

            string flagView;
            bool? flagValue;
            for (ulong i = 0; i < 10; i++)
            {
                flagpoleDatabaseUtils.GetFlag((int)i + 7, out flagView, out flagValue);
                if (flagValue.Value)
                {
                    binaryFlag_10_f.SetFlag(i);
                }
            }

            Assert.IsTrue(binaryFlag_10_f.GetFlag());
        }
    }
}
