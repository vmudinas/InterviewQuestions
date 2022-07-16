using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class SGNLHackerRank1
{

    public static List<string> getRelevantFoodOutlets(string city, int maxCost)
    {
        var result = new List<string>() { };
        var pageNumber = 1;
        var url = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page=";
        var pageOneResult = Get(url, city, pageNumber);

        var resultThing = Task.Run<List<string>>(async () => (await Get(url, city, pageNumber)).Data.Where(x=>x.Estimated_cost < maxCost).Select(x=>x.Name).ToList<string>());

        return resultThing.Result;
    }

    public static async Task<FoodOutLetData> Get(string url, string city, int pageNumber)
    {
        var result = new FoodOutLetData();
        using var client = new HttpClient();
        var response = await client.GetAsync(url + pageNumber);

        if (response.IsSuccessStatusCode)
        {
            var responses = await response.Content.ReadAsStreamAsync();
            result = await JsonSerializer.DeserializeAsync<FoodOutLetData>(responses);

            if (pageNumber != result.Total_pages)
            {
                var nextPage = pageNumber + 1;
                result.Data.AddRange((await Get(url + nextPage, city, nextPage)).Data);
            }
        }

        return result;

    }

    public class CityData
    {
        public string City { get; set; }
        public string Name { get; set; }
        public int Estimated_cost { get; set; }

    }
    public class FoodOutLetData
    {
        public int Total_pages { get; set; }
        public List<CityData> Data { get; set; }
    }

}

