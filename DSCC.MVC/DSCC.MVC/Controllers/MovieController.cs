using DSCC.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace DSCC.MVC.Controllers
{
    public class MovieController : Controller
    {
        private const string BASE_URL = "https://localhost:44361/";
        private readonly Uri ClientBasAddress = new Uri(BASE_URL);
        private readonly HttpClient _client;

        public MovieController()
        {
            _client = new HttpClient();
            _client.BaseAddress = ClientBasAddress;
        }

        private void HeaderClearing()
        {
            // Clearing default headers
            _client.DefaultRequestHeaders.Clear();

            // Define the request type of the data
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            var movies = new List<Movie>();
            HeaderClearing();
            HttpResponseMessage httpResponseMessage = await _client.GetAsync("api/Movies");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<Movie>>(responseMessage);
            }
            return View(movies);
        }

        public async Task<ActionResult> Details(int id)
        {
            Movie movie = new Movie();
            HeaderClearing();

            HttpResponseMessage httpResponseMessage = await _client.GetAsync($"api/Movies/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movie>(responseMessage);
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            HeaderClearing();
            return View(movie);
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                string createGenreInfo = JsonConvert.SerializeObject(movie);
                StringContent stringContentInfo = new StringContent(createGenreInfo, Encoding.UTF8, "application/json");
                HttpResponseMessage createHttpResponseMessage = _client.PostAsync(_client.BaseAddress + "api/Movies", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Movie movie = new Movie();
            HeaderClearing();

            HttpResponseMessage httpResponseMessage = await _client.GetAsync($"api/Movies/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movie>(responseMessage);
            }

            return View(movie);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                string createSubjectInfo = JsonConvert.SerializeObject(movie);
                StringContent stringContentInfo = new StringContent(createSubjectInfo, Encoding.UTF8, "application/json");
                HttpResponseMessage editHttpResponseMessage = _client.PutAsync(_client.BaseAddress + $"api/Movies/{id}", stringContentInfo).Result;
                if (editHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(movie);
        }

        // GET: Subject/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Movie movie = new Movie();
            HeaderClearing();

            HttpResponseMessage httpResponseMessage = await _client.GetAsync($"api/Movies/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movie>(responseMessage);
            }
            return View(movie);
        }

        // POST: Subject/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Movie subject)
        {
            HttpResponseMessage deleteSubjectHttpResponseMessage = _client.DeleteAsync(_client.BaseAddress + $"api/Movies/{id}").Result;
            if (deleteSubjectHttpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
