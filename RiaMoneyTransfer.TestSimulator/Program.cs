using RiaMoneyTransfer.TestSimulator;
using System.Net.Http.Json;

string[] FirstNames = ["Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos"];
string[] LastNames = ["Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane"];
var random = new Random(DateTime.Now.Microsecond);
var baseUrl = "http://localhost:5030/api/v1/customer";
var Id = 0;


for (var i = 0; i <= random.Next(2, 5); i++)
{
    await PostRequest();
}
await GetRequest();

async Task GetRequest()
{
    using (var httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync(baseUrl);

        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"GET Request Successful:\n{responseData}");
        }
        else
        {
            Console.WriteLine($"GET Request Failed: {response.StatusCode}, {response.Content.ToString}");
        }
    }
}

async Task PostRequest()
{
    using (var httpClient = new HttpClient())
    {
        int customers = random.Next(2, 5);
        var response = await httpClient.PostAsJsonAsync(baseUrl, Enumerable.Range(1, customers).Select(i => newCustomer()).ToList());

        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"POST Request Successful:\n{responseData}");
        }
        else
        {
            Console.WriteLine($"POST Request Failed: {response.StatusCode}, {response.Content.ToString}");
        }
    }
}

CustomerDto newCustomer()
{
    return new CustomerDto()
    {
        LastName = LastNames[random.Next(0, 10)],
        FirstName = FirstNames[random.Next(0, 10)],
        Age = random.Next(10, 91),
        Id = Id++
    };
}