using CnpValidator.Models;
using System.Text.RegularExpressions;

namespace CnpValidator.cnpStrategy;

public abstract class CnpValidatorStrategy
{
    public abstract CnpValidationResponse Validate(string cnp);

}

public class RomanianCNPValidator : CnpValidatorStrategy
{
    private const int CnpLenght = 13;

    public override CnpValidationResponse Validate(string cnp)
    {
        var isValid = true;
        var response = new CnpValidationResponse { Errors = new List<string>() };

        if (cnp.Length != CnpLenght)
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

public class BulgarianCNPValidator : CnpValidatorStrategy
{
    private const int CnpLenght = 12;
    public override CnpValidationResponse Validate(string cnp)
    {
        var isValid = true;
        var response = new CnpValidationResponse { Errors = new List<string>() };

        if (cnp.Length != CnpLenght)
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

