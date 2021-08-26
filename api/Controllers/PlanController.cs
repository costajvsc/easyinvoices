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


        [HttpPut]
        [Route("/plans/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Title, Price")] Plan plan)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, plan);

            try
            {
                plan.Id = id;
                _context.Plans.Update(plan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!PlanExist(id))
                    return NotFound();
            }

            return StatusCode(200, plan);
        }

        [HttpDelete]
        [Route("/plans/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(_context.Invoices.Any(i => i.PlanId == id))
                return StatusCode(404, new {
                    Message =  "This plan cannot to be deleted.",
                    Error = "This plan has been used on a couple invoices."
                });

            var plan = await _context.Plans.FindAsync(id);
            if(plan == null)
                return StatusCode(404, new {
                    Message =  "Error to delete plan.",
                    Error = "This plan was not found."
                });
            
            _context.Remove(plan);
            await _context.SaveChangesAsync();
            
            return StatusCode(204);
        }

        private bool PlanExist(int id)
        {
            return _context.Plans.Any(p => p.Id == id);
        }
    }   
}