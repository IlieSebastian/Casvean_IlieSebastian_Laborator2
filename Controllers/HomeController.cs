﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Casvean_IlieSebastian_Laborator2.Models;
using Casvean_IlieSebastian_Laborator2.DataAccess;
using Casvean_IlieSebastian_Laborator2.Models.LibraryViewModels;
using Microsoft.EntityFrameworkCore;

namespace Casvean_IlieSebastian_Laborator2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _context;
        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data = from order in _context.Orders
                                          group order by order.OrderDate into dateGroup
                                          select new OrderGroup()
                                          {
                                              OrderDate = dateGroup.Key,
                                              BookCount = dateGroup.Count()
                                          };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}
