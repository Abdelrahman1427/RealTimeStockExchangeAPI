using RealTimeStockExchangeAPI.Entitiy;
using System.Collections.Generic;

namespace RealTimeStockExchangeAPI.IService
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        List<Order> GetOrders();
    }
}
