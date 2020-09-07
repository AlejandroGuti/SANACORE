using Microsoft.AspNetCore.Mvc.Rendering;
using SANA.Helpers.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SANA.Entities
{
    public partial class Products
    {
        public Products()
        {
            OrdersProducts = new HashSet<OrdersProducts>();
            ProductsCategory = new HashSet<ProductsCategory>();
        }

        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public ICollection<OrdersProducts> OrdersProducts { get; set; }
        public ICollection<ProductsCategory> ProductsCategory { get; set; }


        [NotMapped]
        [Display(Name = "Categories")]
        [ListHasElements(ErrorMessage = "List must have elements")]
        public List<int> ProductCategories { get; set; }

        [NotMapped]
        [Display(Name = "Categories")]
        public IEnumerable<SelectListItem> ProductCategoriesPicker { get; set; }

        [NotMapped]
        public int SaveAs { get; set; }
    }
}
