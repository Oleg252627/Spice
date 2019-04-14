using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.Entitie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eczamen.Models
{
    public class SubCategoryAndCategoryModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public SubCategoryModel SubCategoryModel { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        
        public List<SelectListItem> GetListItemSelected()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (SubCategoryModel.Category != null)
            {
                foreach (var VARIABLE in Categories)
                {
                    if (SubCategoryModel.Category.Id.Equals(VARIABLE.Id))
                    {
                        items.Add(new SelectListItem { Text = VARIABLE.NameCategory, Value = $"{VARIABLE.Id}", Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = VARIABLE.NameCategory, Value = $"{VARIABLE.Id}", Selected = false });
                    }

                }
            }
            else
            {
                foreach (var VARIABLE in Categories)
                {
                    items.Add(new SelectListItem { Text = VARIABLE.NameCategory, Value = $"{VARIABLE.Id}" });
                }
            }
            
            return items;
        }
    }
}
