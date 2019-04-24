using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class NasaConnection
    {
        static string apiKey = "FFAKssQbl7T25xe2rdDlQ8MiitLwhZwXyNyfw5bK";
        static string apiBaseUrl = "https://api.nasa.gov/planetary/earth/imagery/?lon=100.75&lat=1.5&date=2014-02-01&cloud_score=True&api_key=";

        public static async Task<string> LoadDataAsync(string cityName)
        {
            string apiCall = apiBaseUrl + apiKey;
            Task<string> result;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiCall))
            using (HttpContent content = response.Content)
            {
                result = content.ReadAsStringAsync();
            }
            return await result;
        }
    }
}
