using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using AlfarBackendChallengeV2.src.Models.Utils;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Facades.Interfaces;
using AlfarBackendChallengeV2.src.Services.Interfaces;

namespace AlfarBackendChallengeV2.src.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerFacade _customerFacade;

        public CustomerController(ICustomerService customerService, ICustomerFacade customerFacade)
        {
            _customerService = customerService;
            _customerFacade = customerFacade;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostNewCustomerAsync([FromBody, Required] Customer customer)
        {
            var response = await _customerFacade.PostNewCustomerAndSendEmailAsync(customer);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerAsync([FromHeader, Required] int customerId)
        {
            var response = await _customerService.GetCustomer(customerId);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomerAsync([FromHeader, Required] int customerId, [FromBody, Required] Customer customer)
        {
            var response = await _customerService.UpdateCustomer(customerId, customer);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomerAsync([FromHeader, Required] int customerId)
        {
            await _customerService.DeleteCustomer(customerId);

            return Ok();
        }
    }
}