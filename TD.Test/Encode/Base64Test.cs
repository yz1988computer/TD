using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TD.Encode;

namespace TD.Test.Encode
{
    public class Base64Test
    {
        [Test]
        public void TestBase64()
        {
            var b = new Base64();
            var source = "abc123!@#ABC";
            var base64source = "YWJjMTIzIUAjQUJD";

            // 编码
            var r = b.Encode(source);
            Assert.IsTrue(r == base64source);

            //解码
            r = b.Decode(base64source);
            Assert.IsTrue(r == source);
        }
    }
}
