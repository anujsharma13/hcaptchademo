using hcaptchademo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace hcaptchademo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Result(Student s)
        {
            //var _googlerecaptcha=GoogleCaptchaService.verifyrecaptcha()
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            GoogleCaptchaService googleCaptchaService = new GoogleCaptchaService();
            var _googlecaptcha = await googleCaptchaService.verifycaptcha(EncodedResponse);
            if (_googlecaptcha)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            return View("Result", s);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
