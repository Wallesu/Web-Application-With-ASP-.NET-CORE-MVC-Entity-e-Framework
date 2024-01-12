using SalesWebMvc.Data;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
