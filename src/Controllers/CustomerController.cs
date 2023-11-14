using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Services.Interfaces;

namespace AlfarBackendChallengeV2.src.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<Customer> PostNewCustomerAsync([FromBody, Required] Customer customer)
        {
            var response = await _customerService.PostNewCustomer(customer);

            return response;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<Customer> GetCustomerAsync([FromHeader, Required] int customerId)
        {
            var response = await _customerService.GetCustomer(customerId);

            return response;
        }

        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<Customer> UpdateCustomerAsync([FromHeader, Required] int customerId, [FromBody, Required] Customer customer)
        {
            var response = await _customerService.UpdateCustomer(customerId, customer);

            return response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCustomerAsync([FromHeader, Required] int customerId)
        {
            await _customerService.DeleteCustomer(customerId);

            return NoContent();
        }
    }
}