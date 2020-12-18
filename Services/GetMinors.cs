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
    //consuming endpoint and referencing interface with Minors
    public class GetMinors : IGetMinors
    {
        //implementing http request response
        public async Task<List<Minors>> GetAllMinors()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/minors", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Minors>>>(data);

                    List<Minors> facultyList = new List<Minors>();
                    Minors faculty = new Minors();

                    foreach (KeyValuePair<string, List<Minors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            facultyList.Add(item);
                        }
                    }

                    return facultyList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Minors> facultyList = new List<Minors>();
                    return facultyList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Minors> facultyList = new List<Minors>();
                    return facultyList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
