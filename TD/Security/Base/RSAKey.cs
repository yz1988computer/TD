using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD.Security.Base
{
    /// <summary>
    /// RSA公钥、密钥
    /// </summary>
    public class RSAKey
    {
        /// <summary>
        /// 公钥，可以提供给别人
        /// </summary>
        public string PublicKey { get; set; }
        
        /// <summary>
        /// 私钥，需要保密
        /// </summary>
        public string PrivateKey { get; set; }
    }
}
