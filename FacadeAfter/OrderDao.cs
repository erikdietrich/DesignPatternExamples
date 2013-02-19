using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeBefore
{
    public class OrderDao
    {
        public virtual void StoreOrder(Order order)
        {

        }

        public virtual IEnumerable<Order> GetOrdersForCustomer(string customerId)
        {
            return Enumerable.Empty<Order>();
        }
    }
}
