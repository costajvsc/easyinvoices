using System;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public PlanController(AppDbContext context)
            => _context = context;

        [HttpGet]
        [Route("/plans")]
        public async Task<IActionResult> Index()
            => StatusCode(200, await _context.Plans.ToListAsync());
        
    }   
}