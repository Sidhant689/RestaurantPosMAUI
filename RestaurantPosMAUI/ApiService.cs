using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5006/api/") };
    }

    // Generic method for GET requests
    public async Task<List<T>> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); // Throw exception for non-success status codes
            return await response.Content.ReadFromJsonAsync<List<T>>() ?? new List<T>();
        }
        catch (HttpRequestException ex)
        {
            // Log error with more context
            Console.WriteLine($"HTTP Request Error: {ex.Message}");
            // Consider using a logging framework instead of Console.WriteLine
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Parsing Error: {ex.Message}");
            return null;
        }
    }

    // Generic method for POST requests
    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            Console.WriteLine($"Error posting data: {response.StatusCode}");
            return default;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return default;
        }
    }

    // Generic method for PUT requests
    public async Task<bool> PutAsync<T>(string endpoint, T data)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, data);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating data: {ex.Message}");
            return false;
        }
    }

    // Generic method for DELETE requests
    public async Task<bool> DeleteAsync(string endpoint)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting data: {ex.Message}");
            return false;
        }
    }
}
