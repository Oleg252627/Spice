using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eczamen.Abstractions
{
    public interface IDbEntity
    {
        [Key]
        int Id { get; set; }
    }
}
