using CnpValidator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CnpValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CnpController : ControllerBase
    {
        private const int CnpLenght = 13;
        private readonly ILogger<CnpController> _logger;

        public CnpController(ILogger<CnpController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Validate")]
        public CnpValidationResponse Validate([FromBody] string cnp)
        {
            var isValid = true;
            var response = new CnpValidationResponse {Errors = new List<string>()};

            if(cnp.Length != CnpLenght)
            {
                response.Errors.Add($"CNP length must be {CnpLenght}");
                isValid = false;
            }
            
            if (!new Regex(@"[0-9]").IsMatch(cnp))
            {
                response.Errors.Add("CNP should contain only digits.");
                isValid = false;
            }

            response.IsValid = isValid;
            return response;
        }
    }
}