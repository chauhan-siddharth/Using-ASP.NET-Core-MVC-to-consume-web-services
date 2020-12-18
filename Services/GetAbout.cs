using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace Project3_FinalExam.Services
{
    public class GetAbout : IGetAbout
    {

        public async Task<List<About>> GetAllAbout()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/about", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<About>(data);
                    List<About> AboutList = new List<About>();
                    About underGradMajors = new About();
                    AboutList.Add(rtnResults);
                    return AboutList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<About> AboutList = new List<About>();
                    return AboutList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<About> AboutList = new List<About>();
                    return AboutList;
                }
            }
        }
    }
}
