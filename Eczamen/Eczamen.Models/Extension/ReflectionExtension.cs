﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eczamen.Models.Extension
{
    public static class ReflectionExtension
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
