using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Eczamen.AppContext;
using Eczamen.Entitie;
using Eczamen.Repositories.Generic;
using Eczamen.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Eczamen.Repositories
{
    public class CouponRepository: DbRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CreateCouponPost(IFormFileCollection file, Coupon model)
        {
            if (file.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = file[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                model.Picture = p1;
            }

            return await AddItemAsync(model);
        }

        public async Task<Coupon> EditCouponGet(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var coupon = await GetItemAsync(id);
            if (coupon == null)
            {
                return null;
            }

            return coupon;
        }

        public async Task<bool> EditCouponPost(IFormFileCollection file, Coupon model)
        {
            var coupon = await GetItemAsync(model.Id);
            if (file.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = file[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                coupon.Picture = p1;
            }
            coupon.MinimumAmount = model.MinimumAmount;
            coupon.Name = model.Name;
            coupon.Discount = model.Discount;
            coupon.CouponType = model.CouponType;
            coupon.IsActive = model.IsActive;
            return await UpdateItem(coupon);
        }

        public async Task<bool> DeleteCoupon(Coupon model)
        {
            return await DeleteItemAsync(model.Id);
        }

        public async Task<Coupon> DeleteCouponGet(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await GetItemAsync(id);
        }
    }
}
