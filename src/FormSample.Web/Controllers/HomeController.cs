using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FormSample.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
