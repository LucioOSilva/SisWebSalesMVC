using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisWebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SisWebSalesMVC.Services
{
    public class SellerService
    {
        private readonly SisWebSalesMVCContext _context;

        public SellerService(SisWebSalesMVCContext context)
        {
            _context = context;
        }


        public List<Seller> Findall()
        {
            return _context.Seller.OrderBy(x => x.Name).ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
