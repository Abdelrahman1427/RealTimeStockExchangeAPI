using RealTimeStockExchangeAPI.Entitiy;

namespace RealTimeStockExchangeAPI.IService
{
    public interface IStockService
    {
        string GetData(string url);
        List<Stock> GetAllData();
        List<HistoricalStockData> GetStockHistory(string symbol);
    }
}
