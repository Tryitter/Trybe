using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tryitter
{
    [Serializable]
    public class JwtAuthResponse
    {
        public string? token { get; set; }
        public string? user_name { get; set; }
    }
}
