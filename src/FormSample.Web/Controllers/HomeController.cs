using Microsoft.AspNetCore.Mvc;

namespace FormSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private Data _data = Data.Instance;

        public IActionResult Index()
        {
            ViewBag.IsComplete = _data.IsComplete();
            return View();
        }

        [HttpGet]
        public IActionResult Form1() {

            return View(_data);
        }

        [HttpPost]
        public IActionResult Form1(IFormCollection formCollection) {
            _data.FirstName = formCollection["firstname"];
            _data.LastName = formCollection["lastname"];
            _data.Phone = formCollection["phone"];

            return RedirectToAction("Form2");
        }

        [HttpGet]
        public IActionResult Form2() {

            return View(_data);
        }
        
        [HttpPost]
        public IActionResult Form2(IFormCollection formCollection) {
            _data.Address = formCollection["address"];
            _data.City = formCollection["city"];
            _data.State = formCollection["state"];
            _data.Zip = formCollection["zip"];

            return RedirectToAction("Summary");
        }

        [HttpGet]
        public IActionResult Summary(IFormCollection formCollection) {
            return View(_data);
        }
    }

    public class Data
    {
        private static Data _instance = new Data();
        public static Data Instance => _instance;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }

        public bool IsComplete() 
        {
            return 
                !String.IsNullOrWhiteSpace(FirstName) &&
                !String.IsNullOrWhiteSpace(LastName) &&
                !String.IsNullOrWhiteSpace(Phone) &&
                !String.IsNullOrWhiteSpace(Address) &&
                !String.IsNullOrWhiteSpace(City) &&
                !String.IsNullOrWhiteSpace(State) &&
                !String.IsNullOrWhiteSpace(Zip);
        }
    }
}
