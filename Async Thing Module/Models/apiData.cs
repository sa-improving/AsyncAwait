using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Async_Thing_Module.Models
{
    public class apiData
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<int> GetRandomNumber()
        {
            HttpResponseMessage response = await _client.GetAsync("https://seriouslyfundata.azurewebsites.net/api/generatearandomnumber");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(responseBody);
        }

        public async Task<string> GetChuckNorrisFact()
        {
            HttpResponseMessage response = await _client.GetAsync("https://seriouslyfundata.azurewebsites.net/api/chucknorrisfact");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var fact = Newtonsoft.Json.JsonConvert.DeserializeObject<ChuckNorrisFact>(responseString);

            return fact.Joke;
        }

        public async Task<List<Seleucid>> GetSeleucids()
        {
            HttpResponseMessage response = await _client.GetAsync("https://seriouslyfundata.azurewebsites.net/api/seleucids");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var seleucidResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SeleucidResponse>(responseContent);

            return seleucidResponse.Seleucids;
        }

        public async Task<Teacher> GetATeacher()
        {
            HttpResponseMessage response = await _client.GetAsync("https://seriouslyfundata.azurewebsites.net/api/ateacher");
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            using (var stringReader = new System.IO.StringReader(responseContent))
            {
                var serializer = new XmlSerializer(typeof(Teacher));
                return serializer.Deserialize(stringReader) as Teacher;
            }
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            HttpResponseMessage response = await _client.GetAsync("https://seriouslyfundata.azurewebsites.net/api/yourteachers");
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            using (var stringReader = new System.IO.StringReader(responseContent))
            {
                var serializer = new XmlSerializer(typeof(List<Teacher>));
                return serializer.Deserialize(stringReader) as List<Teacher>;
            }
        }

    }
}
