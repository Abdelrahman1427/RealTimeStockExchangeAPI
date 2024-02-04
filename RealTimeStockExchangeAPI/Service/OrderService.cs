using RealTimeStockExchangeAPI.Entitiy;
using RealTimeStockExchangeAPI.IService;

namespace RealTimeStockExchangeAPI.Service
{
    public class OrderService : IOrderService
    {

        private static List<Order> _orders = new List<Order>();

        public  void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

    }
}
