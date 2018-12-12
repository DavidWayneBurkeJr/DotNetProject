using DotNetProject.Data;
using DotNetProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Newtonsoft.Json;

namespace DotNetProject.Controllers
{
    public class APIController : Controller
    {
        ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        public APIController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _context = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult SelectAPI()
        {
            List<APIListModel> apis = new List<APIListModel>();
            apis = (from product in _context.APIListModels select product).ToList();
            apis.Insert(0, new APIListModel { Id = 0, APIName = "Select" });
            ViewBag.APIList = apis;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectAPI(APIListModel selection)
        {
            List<SubscriptionModel> subscriptions = new List<SubscriptionModel>();
            subscriptions = (from product in _context.SubscriptionModels where (product.UserId == _userManager.GetUserId(User)) select product).ToList();
            if (selection.Id == 0)
            {
                ModelState.AddModelError("", "Select API");
                List<APIListModel> apis = new List<APIListModel>();
                apis = (from product in _context.APIListModels select product).ToList();
                apis.Insert(0, new APIListModel { Id = 0, APIName = "Select" });
                ViewBag.APIList = apis;
                var closeModal = new CloseModal
                {
                    ShouldClose = true,
                    FetchData = false
                };
                return RedirectToAction("Index", "Home");
            } else if (subscriptions.Any(u => u.ApiId == selection.Id))
            {
                ModelState.AddModelError("", "API already added");
                List<APIListModel> apis = new List<APIListModel>();
                apis = (from product in _context.APIListModels select product).ToList();
                apis.Insert(0, new APIListModel { Id = 0, APIName = "Select" });
                ViewBag.APIList = apis;
                var closeModal = new CloseModal
                {
                    ShouldClose = true,
                    FetchData = false
                };
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int SelectedValue = selection.Id;
                _context.SubscriptionModels.Add(new SubscriptionModel { ApiId = SelectedValue, UserId = _userManager.GetUserId(User) });
                _context.SaveChanges();
                var closeModal = new CloseModal
                {
                    ShouldClose = true,
                    FetchData = false
                };
                return RedirectToAction("Index", "Home");
            }

            
            
        }

        // API Stuff

        [HttpPost]
        public IActionResult GetWeatherInfo(string latitude, string longitude)
        {
            string appId = "f06c088d68f929077a6ba94b535fe6db";
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}", latitude, longitude, appId);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);
                WeatherViewModel weatherViewModel = new WeatherViewModel
                {
                    City = "City",
                    Temperature = "69",
                    Condition = "Shitty"
                };
                return PartialView("WeatherView", weatherViewModel);
            }
        }
    }
}