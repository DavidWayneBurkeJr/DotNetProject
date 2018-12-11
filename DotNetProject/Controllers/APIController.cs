using DotNetProject.Data;
using DotNetProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
            return View();
        }

        [HttpPost]
        public IActionResult SelectAPI(APIListModel selection)
        {
            if (selection.Id == 0)
            {
                ModelState.AddModelError("", "Select API");
                List<APIListModel> apis = new List<APIListModel>();
                apis = (from product in _context.APIListModels select product).ToList();
                apis.Insert(0, new APIListModel { Id = 0, APIName = "Select" });
                ViewBag.APIList = apis;
                return View();
            }
            else
            {
                int SelectedValue = selection.Id;
                _context.SubscriptionModels.Add(new SubscriptionModel { ApiId = SelectedValue, UserId = _userManager.GetUserId(User) });
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            
            
        }
    }
}