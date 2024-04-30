using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using SimpleRazorApp.Pages; // Add using statement to reference the 'Models' namespace
namespace SimpleRazorApp.Services
{
public class EmployeeManager
{
    private readonly HttpClient _client;
    public EmployeeManager(HttpClient client)
    {
    _client = client;
    }
    public async Task<IEnumerable<Employees>> GetEmployeeList()
    {
        var response = await _client.GetAsync("http://localhost:5266/Employees");
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<IEnumerable<Employees>>(stream);
    }
    public async Task SaveEmployeeInfo(Employees employee)
    {
        var json = JsonSerializer.Serialize(employee);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("http://localhost:5266/Employees", content);
        response.EnsureSuccessStatusCode();
    }
}
}