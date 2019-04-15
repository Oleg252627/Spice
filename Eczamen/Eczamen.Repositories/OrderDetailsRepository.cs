using System;
using System.Collections.Generic;
using System.Text;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class OrderDetailsRepository: DbRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
