using System;

namespace Tryitter
{
    [Serializable]
    public class AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
