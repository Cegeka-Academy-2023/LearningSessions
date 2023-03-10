using CnpValidator.Models;

namespace CnpValidator.cnpStrategy
{

    public class CnpValidator
    {
        private CnpValidatorStrategy cnpValidatorStrategys;
        private string country;

        public CnpValidator(string requestedCountry)
        {
            country = requestedCountry;
        }

        public CnpValidationResponse ValidateCnp(string cnp)
        {
            switch (country)
            {
                case "RO":
                    cnpValidatorStrategys = new RomanianCNPValidator();
                    return cnpValidatorStrategys.Validate(cnp);
                case "BUL":
                    cnpValidatorStrategys = new BulgarianCNPValidator();
                    return cnpValidatorStrategys.Validate(cnp);
            }

            throw new Exception("No support for that country");
        }
    }
}
