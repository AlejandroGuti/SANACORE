using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            CustomOrders = new HashSet<CustomOrders>();
            OrdersProducts = new HashSet<OrdersProducts>();
        }

        public int Id { get; set; }
        public int IdOrders { get; set; }

        public ICollection<CustomOrders> CustomOrders { get; set; }
        public ICollection<OrdersProducts> OrdersProducts { get; set; }
    }
}
