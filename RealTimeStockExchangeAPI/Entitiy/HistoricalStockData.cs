namespace RealTimeStockExchangeAPI.Entitiy
{
    public class HistoricalStockData
    {

        public double close { get; set; }
        public double fclose { get; set; }
        public double fhigh { get; set; }
        public double flow { get; set; }
        public double fopen { get; set; }
        public int fvolume { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public string priceDate { get; set; }
        public string symbol { get; set; }
        public double uclose { get; set; }
        public double uhigh { get; set; }
        public double ulow { get; set; }
        public double uopen { get; set; }
        public int uvolume { get; set; }
        public int volume { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public long date { get; set; }
        public long updated { get; set; }

    }
}
