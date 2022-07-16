using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


class SGNLHackerRankGetRelevantFoodOutlets
{

    /*
     * Complete the 'getRelevantFoodOutlets' function below.
     *
     * URL for cut and paste
     * https://jsonmock.hackerrank.com/api/food_outlets?city=<city>&page=<pageNumber>
     *
     * The function is expected to return an array of strings.
     * 
     * The function accepts a city argument (String) and maxCost argument(Integer).
     */


    public static List<string> getRelevantFoodOutlets(string city, int maxCost)
    {
        //maxCost = maxCost;
        var result = new List<string>() { };
        var pageNumber = 1;
        var url = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page={1}";
        var pageOneResult = Get(url);


        var resultOfPageOneObject = JsonConvert.DeserializeObject<FoodOutLetData>(pageOneResult);
        while (pageNumber != resultOfPageOneObject.Total_pages)
        {
            pageNumber = pageNumber + 1;
            var newUrl = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}&page={pageNumber}";
            var pResults = Get(newUrl);
            var pResultsObject = JsonConvert.DeserializeObject<FoodOutLetData>(pResults);
            resultOfPageOneObject.Data.AddRange(pResultsObject.Data);
        }
        foreach (var value in resultOfPageOneObject.Data.Where(x => x.City == city && x.Estimated_cost < maxCost))
        {
            if (!result.Exists(x => x.ToLower() == value.Name.ToLower()))
            {
                result.Add(value.Name);
            }
        }

        return result;
    }

    public static string Get(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

    public class CityData
    {
        public string City { get; set; }
        public string Name { get; set; }
        public int Estimated_cost { get; set; }
        public UserRating User_rating { get; set; }
        public int id { get; set; }
    }
    public class FoodOutLetData
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<CityData> Data { get; set; }
    }

    public class UserRating
    {
        public double Average_rating { get; set; }
        public int Votes { get; set; }
    }

}

