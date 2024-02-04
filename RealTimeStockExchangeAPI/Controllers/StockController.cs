using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Net.Http;

using Newtonsoft.Json.Linq;

using System.Runtime.InteropServices.JavaScript;
using RealTimeStockExchangeAPI.IService;
using RealTimeStockExchangeAPI.Entitiy;
using Microsoft.AspNetCore.Authorization;

namespace RealTimeStockExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }


        static public List<Stock> stocks = new List<Stock>()
        {
            new Stock("NFLX",
                300,
                "February 2, 2024"

               )

        };

        [HttpGet ]
        public ActionResult<IEnumerable<Stock>> GetStocks()
        {
            var stocks = stockService.GetAllData();
            return Ok(stocks);
        }

        [HttpGet("{symbol}/history")]
        public ActionResult<IEnumerable<HistoricalStockData>> GetStockHistory(string symbol)
        {
            var historyData = stockService.GetStockHistory(symbol);

            if (historyData == null || !historyData.Any())
            {
                return NotFound($"No historical data found for symbol: {symbol}");
            }

            return Ok(historyData);
        }



    }
}
