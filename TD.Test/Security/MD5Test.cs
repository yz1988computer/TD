using NUnit.Framework;
using TD.Security;

namespace TD.Test.Security
{
    [TestFixture]
    public class MD5Test
    {
        [Test]
        public void EncodeTest()
        {
            const string data = "i am testing";
            MD5 md5 = new MD5();
            var result = md5.Encode(data);
            Assert.IsTrue(result == "C6BD2686D765C25433A11810493987BD");
        }
    }
}
