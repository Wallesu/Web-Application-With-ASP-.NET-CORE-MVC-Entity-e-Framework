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
    }
}
