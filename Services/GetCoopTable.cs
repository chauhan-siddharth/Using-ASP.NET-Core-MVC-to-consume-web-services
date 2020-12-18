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
    //consuming endpoint and referencing interface with CoopTable
    public class GetCoopTable : IGetCoopTable
    {
        public async Task<List<CoopTable>> GetAllCoopTable()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/employment/coopTable/coopInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<CoopTable>>>(data);

                    List<CoopTable> coopTableList = new List<CoopTable>();
                    CoopTable faculty = new CoopTable();

                    foreach (KeyValuePair<string, List<CoopTable>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            coopTableList.Add(item);
                        }
                    }

                    return coopTableList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<CoopTable> coopList = new List<CoopTable>();
                    return coopList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<CoopTable> coopList = new List<CoopTable>();
                    return coopList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
