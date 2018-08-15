using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gameStats.Models;
using Microsoft.EntityFrameworkCore;

  namespace gameStats.Controllers
{
    public class Search : Controller
    {
        
        private readonly rawStatsContext _context;

        public Search(rawStatsContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> SearchPlayer(string searchString)
        {
            
            if (!String.IsNullOrEmpty(searchString))
            {
                var players = 
                from p in _context.Players
                where p.Nickname == searchString
                select p;
                
                if(players.Any()) 
                {
                    return View(await players.ToListAsync());
                }
            }
            return RedirectToAction("NoName");
        }

        public IActionResult NoName()
        {
            return View();
        }

         public IActionResult SearchHome()
        {
            return View();
        }
    }
}