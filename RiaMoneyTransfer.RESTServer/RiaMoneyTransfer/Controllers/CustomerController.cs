using Microsoft.AspNetCore.Mvc;
using RiaMoneyTransfer.ApplicationCore.Dto;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Services;

namespace RiaMoneyTransfer.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/customer")]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        /// <summary>
        /// Returns the array of customers with all fields
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetAsync());
        }

        /// <summary>
        /// Insert new customers and return number of customer added
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Post([FromBody] IEnumerable<CustomerDto> customers)
        {
            return Ok(await _customerService.PostAsync(customers));
        }
    }
}