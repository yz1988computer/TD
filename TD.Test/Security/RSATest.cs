using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using TD.Security;

namespace TD.Test.Security
{
    [TestFixture]
    public class RSATest
    {
        [Test]
        public void GenerateKeyTest()
        {
            RSA rsa = new RSA();
            var key = rsa.GenerateKey();
            // 每次生成不一样，此处指记录执行单元测试时的key
            //publickey
            //<RSAKeyValue><Modulus>nX8JqOtKsttNSx5XMxQ8UIprhvbbXy3yTMU04S69ZInQYFUFHas1HWEp26QUL4LIJ6CQ+698r12KbDZh7MOT7HV3Ia/aQ34Oge7AVOX0Y0E+95f7gxcb9pllsUD2lFos/FW0LuoBicxwFojcLuuc3tUoElD2oGFZ2OusBoDjEMk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>

            //privatekey
            //<RSAKeyValue><Modulus>nX8JqOtKsttNSx5XMxQ8UIprhvbbXy3yTMU04S69ZInQYFUFHas1HWEp26QUL4LIJ6CQ+698r12KbDZh7MOT7HV3Ia/aQ34Oge7AVOX0Y0E+95f7gxcb9pllsUD2lFos/FW0LuoBicxwFojcLuuc3tUoElD2oGFZ2OusBoDjEMk=</Modulus><Exponent>AQAB</Exponent><P>zf5IwDrilxz7IZCkdDvgKHlRDg22QRgD5RoCR4HmTxD6nbWESXBCdXUW5H8CgSgEJoYL4OJ4NSa3LUMnEiTZWQ==</P><Q>w7rXm3C7IS6NKoD1zrFF/wNuBr+esfsysu7XXAGxTrSt4QjSNCv1cWVYuCbSP4HPg5tor1XfUKldiTSyVoOU8Q==</Q><DP>Tmv+WmCQnyMDYHXmhfG9lusItqb1ubZg1TmfoIWNnpBCOQQ/xo2cX4ciHf9UfsMzQU9K+mR9iw6gMfUczMWGkQ==</DP><DQ>r+rDlEKq/fTQDg6gXyh3p+9WOZyKLp9+ftIqH9ipmvrLeQGrpBaKYGPdbI3/0/KBJ2FLoqNEtkOy/Pmu/BEBkQ==</DQ><InverseQ>brHt8NacSwbVIEshmrfaXoIuIirTfV2aP4hPmVvs4mQXDwRTZpv5oabczdtwyYFMKm2yWTo+OtpB9renIJ4oog==</InverseQ><D>WdF8MdBV3mCA2Qkpk6DDsO7v2Z1oiARM/Ykt2gnsyqxpoLZ732qnNOUXmQIe3OWJvkesx0xSIDSJX6M3/22eKsPMtTdMDxAUXIdxfFDDLQ5GnDH7oSa9srpUN0a8r/PGPaMGu3E96xGyYequKIf76W+VK1wjaKuDCtmIsvrxXYE=</D></RSAKeyValue>

            Assert.IsTrue(key != null);
        }

        [Test]
        public void EncodeTest()
        {
            RSA rsa = new RSA();
            var data = rsa.Encode(@"<RSAKeyValue><Modulus>nX8JqOtKsttNSx5XMxQ8UIprhvbbXy3yTMU04S69ZInQYFUFHas1HWEp26QUL4LIJ6CQ+698r12KbDZh7MOT7HV3Ia/aQ34Oge7AVOX0Y0E+95f7gxcb9pllsUD2lFos/FW0LuoBicxwFojcLuuc3tUoElD2oGFZ2OusBoDjEMk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", "你好，yz");
            Assert.IsTrue(!string.IsNullOrEmpty(data));
        }

        [Test]
        public void DecodeTest()
        {
            RSA rsa = new RSA();
            var data =
                rsa.Decode(@"<RSAKeyValue><Modulus>nX8JqOtKsttNSx5XMxQ8UIprhvbbXy3yTMU04S69ZInQYFUFHas1HWEp26QUL4LIJ6CQ+698r12KbDZh7MOT7HV3Ia/aQ34Oge7AVOX0Y0E+95f7gxcb9pllsUD2lFos/FW0LuoBicxwFojcLuuc3tUoElD2oGFZ2OusBoDjEMk=</Modulus><Exponent>AQAB</Exponent><P>zf5IwDrilxz7IZCkdDvgKHlRDg22QRgD5RoCR4HmTxD6nbWESXBCdXUW5H8CgSgEJoYL4OJ4NSa3LUMnEiTZWQ==</P><Q>w7rXm3C7IS6NKoD1zrFF/wNuBr+esfsysu7XXAGxTrSt4QjSNCv1cWVYuCbSP4HPg5tor1XfUKldiTSyVoOU8Q==</Q><DP>Tmv+WmCQnyMDYHXmhfG9lusItqb1ubZg1TmfoIWNnpBCOQQ/xo2cX4ciHf9UfsMzQU9K+mR9iw6gMfUczMWGkQ==</DP><DQ>r+rDlEKq/fTQDg6gXyh3p+9WOZyKLp9+ftIqH9ipmvrLeQGrpBaKYGPdbI3/0/KBJ2FLoqNEtkOy/Pmu/BEBkQ==</DQ><InverseQ>brHt8NacSwbVIEshmrfaXoIuIirTfV2aP4hPmVvs4mQXDwRTZpv5oabczdtwyYFMKm2yWTo+OtpB9renIJ4oog==</InverseQ><D>WdF8MdBV3mCA2Qkpk6DDsO7v2Z1oiARM/Ykt2gnsyqxpoLZ732qnNOUXmQIe3OWJvkesx0xSIDSJX6M3/22eKsPMtTdMDxAUXIdxfFDDLQ5GnDH7oSa9srpUN0a8r/PGPaMGu3E96xGyYequKIf76W+VK1wjaKuDCtmIsvrxXYE=</D></RSAKeyValue>",
                    "D9g2HP2dfOGDjwE47dIKNxu/urRGmuR2dyr9whE08nd0xo8eOpCb3oiG3ccDDHkGZkbWITdLhrbBcOANdyFswBTkLvK89HxNxOminL1tf2q5Au4Cp6utfmmBivlRfZ/zyxayRR4VKbszdThDx2t9xEs23KOPAnfyTkpUuC3mWsc=");
            Assert.IsTrue(data == "你好，yz");
        }
    }
}
