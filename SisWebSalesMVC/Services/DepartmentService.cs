using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisWebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SisWebSalesMVC.Services
{
    public class DepartmentService
    {
        private readonly SisWebSalesMVCContext _context;

        public DepartmentService(SisWebSalesMVCContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> FindallAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
