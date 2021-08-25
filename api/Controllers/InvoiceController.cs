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
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
            => _context = context;

        [HttpGet]
        [Route("/invoices")]
        public async Task<IActionResult> Index()
            => StatusCode(200, await _context.Invoices.ToListAsync());

                [HttpGet]
        [Route("/invoices/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);

            if(id == null || invoice == null)
                return NotFound();

            return StatusCode(200, invoice);
        }


        [HttpPost]
        [Route("/invoices")]
        public async Task<IActionResult> Create([Bind("ContractDate, BillingMethod, BillingDay, CustomerId, PlanId")]Invoice invoice)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, invoice);
            
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return StatusCode(201, invoice);
        }

        [HttpPut]
        [Route("/invoices/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ContractDate, BillingMethod, BillingDay, CustomerId, PlanId")]Invoice invoice)
        {
            if(!ModelState.IsValid)
                return StatusCode(404, invoice);

            try
            {
                invoice.Id = id;
                _context.Invoices.Update(invoice);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!InvoiceExist(id))
                    return StatusCode(404, invoice);
            }

            return StatusCode(200, invoice);
        }

        [HttpDelete]
        [Route("/invoices/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);
            _context.Remove(invoice);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool InvoiceExist(int id)
        {
            return _context.Invoices.Any(i => i.Id == id);
        }
    }
}