﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisWebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SisWebSalesMVC.Services
{
    public class SalesRecordService
    {
        private readonly SisWebSalesMVCContext _context;

        public SalesRecordService(SisWebSalesMVCContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
