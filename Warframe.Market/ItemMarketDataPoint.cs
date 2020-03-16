using System;

namespace Warframe.Market
{
    public class ItemMarketDataPoint
    {
        public Item Item { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public float Volume { get; set; }
        public float AveragePrice { get; set; }
        public float MedianPrice { get; set; }
        public float SimpleMovingAverage { get; set; }
    }
}