using System;
using System.Collections.Generic;

namespace SANA.Entities
{
    public partial class ProductsCategory
    {
        public int Id { get; set; }
        public int FkIdProducts { get; set; }
        public int FkIdCategory { get; set; }

        public Category FkIdCategoryNavigation { get; set; }
        public Products FkIdProductsNavigation { get; set; }
    }
}
