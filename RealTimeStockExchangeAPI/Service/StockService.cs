using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RealTimeStockExchangeAPI.Entitiy;
using RealTimeStockExchangeAPI.IService;
using System;
using System.IO;
using System.Net;

namespace RealTimeStockExchangeAPI.Service
{
    public class StockService : IStockService
    {
        public string GetData(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            try
            {
                using var webResponse = request.GetResponse();

                using var webStream = webResponse.GetResponseStream();
                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
                return data;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public List<Stock> GetAllData()
        {
            var stockSymbols = new List<string> { "AAPL", "GOOGL", "MSFT", "AMZN", "TSLA" };
            string token = "pk_f9b0307a05944c6b9a90980f58798bc0";
            List<Stock> stockDataList = new List<Stock>();

            foreach (var symbol in stockSymbols)
            {
                string url = String.Format(
                    "https://api.iex.cloud/v1/data/core/quote/{0}/quote?token={1}",
                    symbol,
                    token
                );
                var res = GetData(url);

                if (res != null)
                {
                    JArray json = JArray.Parse(res);
                    if (json?.Count > 0)
                    {
                        Stock stockData = new Stock(
                            symbol: json.Last["symbol"].ToString(),
                            currentPrice: (float)json.Last["latestPrice"],
                            timestamp: json.Last["latestTime"].ToString()
                            );

                        stockDataList.Add(stockData);
                    }
                }
            }
            return stockDataList;
        }

        public List<HistoricalStockData> GetStockHistory(string symbol)
        {
            string token = "pk_f9b0307a05944c6b9a90980f58798bc0";
            string url = $"https://api.iex.cloud/v1/data/CORE/HISTORICAL_PRICES/{symbol}?token={token}";

            var historicalData = GetData(url);

            if (string.IsNullOrEmpty(historicalData))
            {
                return null;
            }

            JArray json = JArray.Parse(historicalData);

            // Convert the JSON data into a list of HistoricalStockData objects
            List<HistoricalStockData> historyList = json.Select(item => new HistoricalStockData
            {
                close = (double)item["close"],
                fclose = (double)item["fclose"],
                fhigh = (double)item["fhigh"],
                flow = (double)item["flow"],
                fopen = (double)item["fopen"],
                fvolume = (int)item["fvolume"],
                high = (double)item["high"],
                low = (double)item["low"],
                open = (double)item["open"],
                priceDate = (string)item["priceDate"],
                symbol = (string)item["symbol"],
                uclose = (double)item["uclose"],
                uhigh = (double)item["uhigh"],
                ulow = (double)item["ulow"],
                uopen = (double)item["uopen"],
                uvolume = (int)item["uvolume"],
                volume = (int)item["volume"],
                id = (string)item["id"],
                key = (string)item["key"],
                subkey = (string)item["subkey"],
                date = (long)item["date"],
                updated = (long)item["updated"],

            }).ToList();

            return historyList;
        }
         
    }
}
