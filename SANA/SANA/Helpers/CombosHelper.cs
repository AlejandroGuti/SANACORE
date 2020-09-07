using Microsoft.AspNetCore.Mvc.Rendering;
using SANA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SANA.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        private readonly SANAContext _context;

        public CombosHelper(SANAContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboCategories()
        {
            List<SelectListItem> list = _context.Category.Select(c => new SelectListItem
            {
                Text = c.Description,
                Value = $"{c.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Select a category",
                Value = "0"
            });

            return list;

        }
    }
}
