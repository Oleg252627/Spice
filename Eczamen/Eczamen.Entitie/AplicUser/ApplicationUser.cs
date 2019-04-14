using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Eczamen.Entitie.AplicUser
{
    public class ApplicationUser: IdentityUser
    {
        //для расширения таблици аутенфикации
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
