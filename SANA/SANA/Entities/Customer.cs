using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CustomOrders = new HashSet<CustomOrders>();
        }

        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Euser { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<CustomOrders> CustomOrders { get; set; }
    }
}
