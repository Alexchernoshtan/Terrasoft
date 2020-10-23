using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Terrasoft.Models;

namespace Terrasoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string text,string act)
        {
            string result = "";
            if (act == "coms")
            {   
                result = $"Your text:{text} \n" +
                    $" Count of coms: {CountOfCom(text)}";
            }else if (act =="cword")
            {
                result = $"Your text:{text} \n" +
                    $" Count of words: {CountOfWord(text)}";
            }else if (act =="symbol")
            {
                result = $"Your text:{text} \n" +
                   $" Count of symbols: {text.Length}";
            }else if (act == "question")
            {
                result = $"Your text:{text} \n" +
                   $" Count of symbols: {CountOfQues(text)}";
            }
            else if(act == "exclamation")
            {
                result = $"Your text:{text} \n" +
                      $" Count of symbols: {CountOfExclam(text)}";
            }
            return Content(result);
        }
        private string CountOfCom(string text)
        {
            int cnt = text.Count(x => x == ',');
            return cnt.ToString();
        }

        private string CountOfQues(string text)
        {
            int cnt = text.Count(x => x == '?');
            return cnt.ToString();
        }

        private string CountOfExclam(string text)
        {
            int cnt = text.Count(x => x == '!');
            return cnt.ToString();
        }
        private string CountOfWord(string text)
        {
            text = text.Trim(new char[] { ',', '.' });
            string[] textArray = text.Split(new char[] { ' ' });
            return textArray.Length.ToString();
        }
    }
}
