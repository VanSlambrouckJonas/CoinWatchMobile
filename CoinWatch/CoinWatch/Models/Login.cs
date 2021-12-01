using System;
using System.Collections.Generic;
using System.Text;

namespace CoinWatch.Models
{
    public class Login
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Assets { get; set; } = new List<string> { "ADA", "BTC", "1INCH", "XDG", "USDTZ", "MANA" };
    }
}
