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
        {
            var invoices = await (from i in _context.Invoices
                                join c in _context.Customers on i.Customer equals c
                                join p in _context.Plans on i.Plan equals p
                                select new {
                                    Id = i.Id,
                                    ContractDate = i.ContractDate,
                                    BillingMethod = i.BillingMethod,
                                    BillingDay = i.BillingDay,
                                    Title = p.Title,
                                    Price = p.Price,
                                    FantasyName  = c.FantasyName,
                                    AgentName = c.AgentName
                                }).ToListAsync();

            return StatusCode(200, invoices);
        }

        [HttpGet]
        [Route("/invoices/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if(!InvoiceExist(id))
                return StatusCode(400, new {
                    Message =  "Error to find this Invoice.",
                    Error = $"Not found any invoice with this Id: {id}",
                    Data = new {
                        Id = id
                    }
                });


            var invoice = await (from i in _context.Invoices
                                join c in _context.Customers on i.Customer equals c
                                join p in _context.Plans on i.Plan equals p
                                where i.Id == id
                                select new {
                                    Id = i.Id,
                                    ContractDate = i.ContractDate,
                                    BillingMethod = i.BillingMethod,
                                    BillingDay = i.BillingDay,
                                    Title = p.Title,
                                    Price = p.Price,
                                    FantasyName  = c.FantasyName,
                                    AgentName = c.AgentName
                                }).FirstAsync();

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
             return StatusCode(201, new {
                Message = $"Invoice {invoice.Id} was created with success.",
                Data = invoice
            });
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
                    return StatusCode(400, new {
                        Message = $"Cannot updated the {invoice.Id} invoice.",
                        Error = $"Not found any invoice with this Id: {id}",
                        Data = invoice
                    });
            }

            return StatusCode(200, new {
                Message = $"Invoice {invoice.Id} was updated with success.",
                Data = invoice
            });
        }

        [HttpDelete]
        [Route("/invoices/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);
            if(invoice == null)
                return StatusCode(404, new {
                    Message =  "Error to delete this invoice.",
                    Error = "This invoice was not found."
                });


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