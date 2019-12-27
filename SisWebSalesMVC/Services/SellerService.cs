using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisWebSalesMVC.Models;

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
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
