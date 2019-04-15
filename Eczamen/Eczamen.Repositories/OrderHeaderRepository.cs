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
    public class OrderHeaderRepository: DbRepository<OrderHeader>, IOrderHeaderRepository
    {
        public OrderHeaderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
