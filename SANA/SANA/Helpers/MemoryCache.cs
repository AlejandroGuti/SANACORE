using SANA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANA.Helpers
{
    public  class MemoryCache
    {
        public static MemoryCache _instance;

        public MemoryCache()
        {
             CurrentProduct = new Products
            {
                Description = "",
                Price = 0,
                IdProduct=0,
                Title=""
            }; 
        }

        public static MemoryCache Instance => _instance ?? (_instance = new MemoryCache());

        public Products CurrentProduct { get; set; }
        public List<Products> MemoryCachesList { get; set; }
    }
}
