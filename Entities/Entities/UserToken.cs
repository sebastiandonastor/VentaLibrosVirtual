using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
