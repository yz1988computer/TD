using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Security;

namespace TD.Test.Security
{
    [TestFixture]
    public class DESTest
    {
        private byte[] iv = { 214, 62, 150, 136, 183, 162, 146, 226 };
        private byte[] key = { 173, 239, 105, 127, 3, 101, 244, 8 };

        [Test]
        public void GentrateKeyTest()
        {
            DES des = new DES();
            var data = des.GenerateRandomKey();
            Assert.IsTrue(data != null);
        }

        [Test]
        public void EncodeTest()
        {
            DES des = new DES();
            var data = des.Encode(key, iv, "this is a test");
            Assert.IsTrue(data == "sT4UXx8ZNqyNxRMyp+gm9Q==");
        }

        [Test]
        public void DecodeTest()
        {
            DES des = new DES();
            var data = des.Decode(key, iv, "sT4UXx8ZNqyNxRMyp+gm9Q==");
            Assert.IsTrue(data == "this is a test");
        }
    }
}
