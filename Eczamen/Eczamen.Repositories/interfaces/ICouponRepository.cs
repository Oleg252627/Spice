using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Eczamen.Abstractions;
using Eczamen.Entitie;
using Microsoft.AspNetCore.Http;

namespace Eczamen.Repositories.interfaces
{
    public interface ICouponRepository: IDbRepository<Coupon>
    {
        Task<bool> CreateCouponPost(IFormFileCollection file, Coupon model);
        Task<Coupon> EditCouponGet(int? id);
        Task<bool> EditCouponPost(IFormFileCollection file, Coupon model);
        Task<bool> DeleteCoupon(Coupon model);
        Task<Coupon> DeleteCouponGet(int? id);
    }
}
