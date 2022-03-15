using libraryAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace libraryAPI.BLL
{
    public class SyncUpBLL
    {
        static readonly HttpClient client = new HttpClient();
        internal bool Start()
        {
            try
            {
              //   SyncUPAuthors("https://fakerestapi.azurewebsites.net/api/v1/Authors");

                 SyncUpBooks("https://fakerestapi.azurewebsites.net/api/v1/Books");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
            return true;
        }

        private  async Task SyncUpBooks(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Books> lstBooks = new List<Books>();
                lstBooks = JsonConvert.DeserializeObject<List<Books>>(responseBody);

                BooksBLL booksBLL = new BooksBLL();
                booksBLL.Insert(lstBooks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private  async Task SyncUPAuthors(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Authors> lstAuhtors = new List<Authors>();
                lstAuhtors = JsonConvert.DeserializeObject<List<Authors>>(responseBody);

                AuthorsBLL authorsBLL = new AuthorsBLL();
                authorsBLL.Insert(lstAuhtors);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
    }
}
