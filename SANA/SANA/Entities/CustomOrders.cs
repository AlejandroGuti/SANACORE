using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class CustomOrders
    {
        public int Id { get; set; }
        public int FkIdCustomer { get; set; }
        public int FkIdOrders { get; set; }
        public DateTime? GenerationDate { get; set; }
        public decimal? Total { get; set; }

        public Customer FkIdCustomerNavigation { get; set; }
        public Orders FkIdOrdersNavigation { get; set; }
    }
}
