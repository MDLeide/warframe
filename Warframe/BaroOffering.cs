using System;
using System.Collections.Generic;
using System.Text;

namespace Warframe
{
    public class BaroOffering
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public Dictionary<Item, int> ItemsToDucatCostOnOffer { get; set; }
    }
}
