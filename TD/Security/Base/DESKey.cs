using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD.Security.Base
{
    public sealed class DESKey
    {
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
    }
}
