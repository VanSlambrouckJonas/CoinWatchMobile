using System;
using System.Collections.Generic;
using System.Text;

namespace CoinWatch.Models
{
    public class AssetPair
    {
        public string altname { get; set; }
        public string wsname { get; set; }
        public string aclass_base { get; set; }
        public string @base { get; set; }
        public string aclass_quote { get; set; }
        public string quote { get; set; }
        public string lot { get; set; }
        public int pair_decimals { get; set; }
        public int lot_decimals { get; set; }
        public int lot_multiplier { get; set; }
        public List<int> leverage_buy { get; set; }
        public List<int> leverage_sell { get; set; }
        public List<List<double>> fees { get; set; }
        public List<List<double>> fees_maker { get; set; }
        public string fee_volume_currency { get; set; }
        public int margin_call { get; set; }
        public int margin_stop { get; set; }
        public string ordermin { get; set; }
    }
}
