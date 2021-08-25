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
        
                [HttpGet]
        [Route("/plans/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var plan = await _context.Plans.FirstOrDefaultAsync(p => p.Id == id);

            if(id == null || plan == null)
                return NotFound();

            return StatusCode(200, plan);
        }


        [HttpPost]
        [Route("/plans")]
        public async Task<IActionResult> Create([Bind("Title, Price")] Plan plan)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, plan);

            _context.Add(plan);
            await _context.SaveChangesAsync();
            return StatusCode(201, plan);
        }

    }   
}