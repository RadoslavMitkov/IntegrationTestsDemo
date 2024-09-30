using IntegrationTestsDemo.Api.Data;
using IntegrationTestsDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestsDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly SqlDbContext _context;
    public CustomersController(SqlDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        if (customer == null)
        {
            return BadRequest();
        }
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }
}