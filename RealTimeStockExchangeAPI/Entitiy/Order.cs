namespace RealTimeStockExchangeAPI.Entitiy
{
    public class Order
    {
        public string StockSymbol { get; set; }
        public string OrderType { get; set; } 
        public int Quantity { get; set; }
    }
}
