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
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context) 
            => _context = context;
        
        [HttpGet]
        [Route("/customers")]
        public async Task<IActionResult> Index()
            => StatusCode(200, await _context.Customers.ToListAsync());

       
    }
}
