using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Eczamen.Entitie;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eczamen.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Spicyness { get; set; }
        public enum ESpicy
        {
            NA = 0,
            NotSpicy = 1,
            Spicy = 2,
            VerySpicy = 3
        }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Sub Category")]
        public string SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        [RegularExpression(@"^\d*\,?\d{1,2}$", ErrorMessage = "Invalid format Price 0,00!")]
        public string Price { get; set; }
        public Dictionary<Category, List<SubCategory>> Dictionary { get; set; }

        public List<SelectListItem> GetSelectListItem()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (Dictionary != null)
            {
                foreach (var VARIABLE in Dictionary)
                {
                    var name = new SelectListGroup { Name = $"Category {VARIABLE.Key.NameCategory}:" };
                    if (SubCategory == null)
                    {
                        foreach (var VAR in VARIABLE.Value)
                        {

                            items.Add(new SelectListItem { Value = $"{VAR.Id}", Text = VAR.NameSubCategory, Group = name });
                        }
                    }
                    else
                    {
                        foreach (var VAR in VARIABLE.Value)
                        {
                            if (SubCategory.Id.Equals(VAR.Id))
                            {
                                items.Add(new SelectListItem { Value = $"{VAR.Id}", Text = VAR.NameSubCategory, Selected = true, Group = name });
                            }
                            else
                            {
                                items.Add(new SelectListItem { Value = $"{VAR.Id}", Text = VAR.NameSubCategory, Group = name });
                            }

                        }
                    }

                }
            }
            

            return items;
        }
    }
}
