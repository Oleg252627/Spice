using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eczamen.Models.Extension
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> item, int selectedValue)
        {
            return from VAR in item
                select new SelectListItem
                {
                    Text = item.GetPropertyValue("NameCategory"),
                    Value = item.GetPropertyValue("Id"),
                    Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                };
        }
    }
}
