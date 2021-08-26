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

        [HttpGet]
        [Route("/customers/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            
            if(id == null || customer == null)
                return NotFound();

            return StatusCode(200, customer);
        }

        [HttpPost]
        [Route("/customers")]
        public async Task<IActionResult> Create([Bind("CorporateName, FantasyName, CNPJ, AgentName, AgentEmail, PhoneNumber")] Customer customer)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, customer);
            
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return StatusCode(201, customer);
        }

        [HttpPut]
        [Route("/customers/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("CorporateName, FantasyName, CNPJ, AgentName, AgentEmail, PhoneNumber")] Customer customer)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, customer);

            try
            {
                customer.Id = id;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CustomerExist(id))
                    return NotFound();
            }

            return StatusCode(200, customer);
        }

        [HttpDelete]
        [Route("/customers/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existCustomer =_context.Invoices.Any(i => i.CustomerId == id);
            if(existCustomer)
                return StatusCode(404, new {
                    Message =  "This customer cannot to be deleted.",
                    Error = "This customer has been used on a couple invoices."
                });
            
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
                return StatusCode(404, new {
                    Message =  "Error to delete customer.",
                    Error = "This customer was not found."
                });

            _context.Remove(customer);
            await _context.SaveChangesAsync();
            
            return StatusCode(204);
        }

        private bool CustomerExist(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }
    }
}
