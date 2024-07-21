using CustomerDataProcessingApp.Web.Models;
using CustomerDataProcessingApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace CustomerDataProcessingApp.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service)); 
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _service.GetCustomers();
            return View("~/Views/Customer/Index.cshtml", customers);
        }

        public IActionResult Create()
        {
            var customer = new Customer();
            return View("~/Views/Customer/Create.cshtml", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var isSaved = await _service.CreateCustomer(customer);
                if (isSaved) 
                   return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Create));
            }
            return View("~/Views/Customer/Create.cshtml", customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            
            var customer = await _service.GetCustomer(id.ToString());
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                await _service.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCustomer(id.ToString());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
