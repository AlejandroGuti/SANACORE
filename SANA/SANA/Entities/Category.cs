using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductsCategory = new HashSet<ProductsCategory>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }

        public ICollection<ProductsCategory> ProductsCategory { get; set; }
    }
}
