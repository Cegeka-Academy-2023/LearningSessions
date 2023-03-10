namespace CnpValidator.Models;

public class CnpValidationResponse
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; }
}