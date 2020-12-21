using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;

namespace IntegrationTesting
{
    [TestClass]
    public class BinaryFlagTest
    {
        [TestMethod]
        public void ExecutionRoute_0_1_2_14_Constructor_LengthTooSmall_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(1);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_3_14_Constructor_LengthTooBig_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(17179868705);
            });
        }


        [TestMethod]
        public void ExecutionRoute_0_1_4_8_14_SetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(10).SetFlag(10);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_8_14_SetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(33).SetFlag(33);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_8_14_SetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(65).SetFlag(65);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_4_9_14_SetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(10, false);

            binaryFlag.SetFlag(1);
            Assert.IsTrue(binaryFlag.GetFlag());

            for (ulong i = 0; i < 10; i++)
            {
                binaryFlag_f.SetFlag(i);
            }
            Assert.IsTrue(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_9_14_SetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(33);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(33, false);

            binaryFlag.SetFlag(1);
            Assert.IsTrue(binaryFlag.GetFlag());

            for (ulong i = 0; i < 33; i++)
            {
                binaryFlag_f.SetFlag(i);
            }
            Assert.IsTrue(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_9_14_SetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(65);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(65, false);

            binaryFlag.SetFlag(1);
            Assert.IsTrue(binaryFlag.GetFlag());

            for (ulong i = 0; i < 65; i++)
            {
                binaryFlag_f.SetFlag(i);
            }
            Assert.IsTrue(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_4_10_14_ResetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(10).ResetFlag(10);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_10_14_ResetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(33).ResetFlag(33);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_10_14_ResetFlagWrongPosition_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                new MultipleBinaryFlag(65).ResetFlag(65);
            });
        }

        [TestMethod]
        public void ExecutionRoute_0_1_4_9_14_ResetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(10, false);

            binaryFlag.ResetFlag(1);
            Assert.IsFalse(binaryFlag.GetFlag());

            binaryFlag_f.ResetFlag(1);
            Assert.IsFalse(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_9_14_ResetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(33);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(33, false);

            binaryFlag.ResetFlag(1);
            Assert.IsFalse(binaryFlag.GetFlag());

            binaryFlag_f.ResetFlag(1);
            Assert.IsFalse(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_9_14_ResetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(65);
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(65, false);

            binaryFlag.ResetFlag(1);
            Assert.IsFalse(binaryFlag.GetFlag());

            binaryFlag_f.ResetFlag(1);
            Assert.IsFalse(binaryFlag_f.GetFlag());

            binaryFlag.Dispose();
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_4_12_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(10, false);
            Assert.IsFalse(binaryFlag_f.GetFlag());
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_12_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(33, false);
            Assert.IsFalse(binaryFlag_f.GetFlag());
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_12_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag_f = new MultipleBinaryFlag(65, false);
            Assert.IsFalse(binaryFlag_f.GetFlag());
            binaryFlag_f.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_4_13_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10);
            Assert.IsTrue(binaryFlag.GetFlag());
            binaryFlag.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_5_13_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(33);
            Assert.IsTrue(binaryFlag.GetFlag());
            binaryFlag.Dispose();
        }

        [TestMethod]
        public void ExecutionRoute_0_1_6_13_14_GetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(65);
            Assert.IsTrue(binaryFlag.GetFlag());
            binaryFlag.Dispose();
        }
    }
}
