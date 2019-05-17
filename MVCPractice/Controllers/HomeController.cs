using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Test page.";

            Student data = new Student("1", "王小明", 80);
            return View(data);
        }

        [HttpPost]
        public ActionResult Transcripts(Student model)
        {
            Student data = new Student(model.id, model.name, model.score);
            return View(data);
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Register page.";

            IEnumerable<City> cityList = DBContext.Current.QueryCityList();

            ViewBag.CityList = cityList.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Village(string id = "")
        {
            IEnumerable<Village> villageList = DBContext.Current.QueryVillageList(id);

            return Json(JsonConvert.SerializeObject(villageList));
        }
    }
}