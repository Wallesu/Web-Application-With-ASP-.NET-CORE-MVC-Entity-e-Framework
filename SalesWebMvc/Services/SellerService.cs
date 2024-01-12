using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private SalesWebMvcContext _salesWebMvcContext;

        public SellerService(SalesWebMvcContext salesWebMvcContext)
        {
            _salesWebMvcContext = salesWebMvcContext;
        }
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _salesWebMvcContext.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _salesWebMvcContext.Seller.Add(seller);
            await _salesWebMvcContext.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _salesWebMvcContext.Seller.Include(seller => seller.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            Seller seller = await _salesWebMvcContext.Seller.FindAsync(id);
            _salesWebMvcContext.Seller.Remove(seller);
            await _salesWebMvcContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _salesWebMvcContext.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _salesWebMvcContext.Update(seller);
                await _salesWebMvcContext.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message); 
            }
            
        }
    }
}
