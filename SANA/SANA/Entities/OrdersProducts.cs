using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class OrdersProducts
    {
        public int Id { get; set; }
        public int FkIdProducts { get; set; }
        public int FkIdOrders { get; set; }
        public int? Amount { get; set; }
        public decimal? Tpprice { get; set; }

        public Orders FkIdOrdersNavigation { get; set; }
        public Products FkIdProductsNavigation { get; set; }
    }
}
