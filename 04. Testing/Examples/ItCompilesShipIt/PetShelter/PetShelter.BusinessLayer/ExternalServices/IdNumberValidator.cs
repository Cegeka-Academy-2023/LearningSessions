using System.Net.Http.Headers;
using Newtonsoft.Json;
using PetShelter.BusinessLayer.Models;

namespace PetShelter.BusinessLayer.ExternalServices;

public class IdNumberValidator : IIdNumberValidator
{
    private readonly HttpClient _httpClient;

    public IdNumberValidator(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7062");
    }

    public async Task<bool> Validate(string cnp)
    {
        var requestUri = $"{_httpClient.BaseAddress}cnp/validate";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(requestUri),
            Content = new StringContent(JsonConvert.SerializeObject(cnp),
                MediaTypeHeaderValue.Parse("application/json"))
        };

        var response = await _httpClient.SendAsync(request, CancellationToken.None);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var cnpValidationResponse = JsonConvert.DeserializeObject<IdNumberValidationResponse>(content);

            return cnpValidationResponse?.IsValid ?? false;
        }

        throw new Exception("Response failed");
    }
}