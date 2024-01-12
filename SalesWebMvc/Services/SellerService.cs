using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private SalesWebMvcContext _salesWebMvcContext;

        public SellerService(SalesWebMvcContext salesWebMvcContext)
        {
            _salesWebMvcContext = salesWebMvcContext;
        }
        public List<Seller> FindAll()
        {
            return _salesWebMvcContext.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _salesWebMvcContext.Seller.Add(seller);
            _salesWebMvcContext.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _salesWebMvcContext.Seller.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Seller seller = _salesWebMvcContext.Seller.Find(id);
            _salesWebMvcContext.Seller.Remove(seller);
            _salesWebMvcContext.SaveChanges();
        }
    }
}
