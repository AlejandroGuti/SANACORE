using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANA.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int id { get; set; }
        public string NameProduct { get; set; }
        public List<ProductCategoryViewModel> GetListPCViewModel { get; set; }

    }
}
