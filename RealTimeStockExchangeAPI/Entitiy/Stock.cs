namespace RealTimeStockExchangeAPI.Entitiy
{
    public class Stock
    {
        public string Symbol { get; set; }
        public float CurrentPrice { get; set; }
        public string Timestamp { get; set; }

        

        public Stock(string symbol, float currentPrice , string timestamp)
        {
            Symbol = symbol;
            CurrentPrice = currentPrice;
            Timestamp = timestamp;


        }
    }
}
