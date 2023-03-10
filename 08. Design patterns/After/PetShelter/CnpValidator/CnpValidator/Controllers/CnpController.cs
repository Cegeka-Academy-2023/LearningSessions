using CnpValidator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnpValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CnpController : ControllerBase
    {
        private readonly ILogger<CnpController> _logger;
        
        private cnpStrategy.CnpValidator validator;
        public CnpController(ILogger<CnpController> logger)
        {
            _logger = logger;
           
        }

        [HttpPost]
        [Route("Validate")]
        public CnpValidationResponse Validate([FromBody] string cnp, string country)
        {
            var validator = new cnpStrategy.CnpValidator(country);
            return validator.ValidateCnp(cnp);
        }
        
    }
}