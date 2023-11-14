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
        public async Task<Customer> PostNewCustomer([FromBody, Required] Customer customer)
        {
            var response = await _customerService.PostNewCustomer(customer);

            return response;
        }
    }
}