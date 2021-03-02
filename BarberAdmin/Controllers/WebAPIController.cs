using BarberAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UnityEngine;

namespace BarberAdmin.Controllers
{
    public class WebAPIController : Controller
    {
        HttpClient client = new HttpClient();
        
        // GET: WebAPI
        public ActionResult Index()
        {
            var barber = new Barber(); 
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Clear();
            var responseTask = client.GetAsync("api/barbers/1").Result;
            // responseTask.Wait();

            // var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<Barber>().Result;
                //readTask.Wait();
                barber = readTask;
            }
            else //web api sent error response 
            {
                //log response status here..
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(barber);
        }

        public async Task<string> GetStuff(int id)
        {
            string path = $"api/barbers/{id}";
            try
            {
                client.BaseAddress = new Uri("http://localhost:44352/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Could not retrieve stuff {id}");
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Exception when retrieving stuff {exception}");
            }
            return null;
        }
    }
}
