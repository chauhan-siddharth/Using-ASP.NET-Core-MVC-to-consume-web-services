﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Project3_FinalExam.Services
{
    //consuming endpoint and referencing interface with ResearchFaculty
    public class GetResearchFaculty: IGetResearchFaculty
    {
        //implementing http request response
        public async Task<List<ResearchFaculty>> GetAllResearchFaculty()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/research/byFaculty", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<ResearchFaculty>>>(data);
                    List<ResearchFaculty> researchList = new List<ResearchFaculty>();
                    ResearchFaculty researchInterestArea = new ResearchFaculty();

                    foreach (KeyValuePair<string, List<ResearchFaculty>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            researchList.Add(item);
                        }
                    }

                    return researchList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<ResearchFaculty> researchList = new List<ResearchFaculty>();
                    return researchList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<ResearchFaculty> researchList = new List<ResearchFaculty>();
                    return researchList;
                }
            }
        }
    }
}

