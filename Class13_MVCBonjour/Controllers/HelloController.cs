using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Class13_MVCBonjour.Controllers
{
    public class HelloController : Controller
    {
        //action is same page it came from is the default, so we didn't have to enter action='/Hello/Index'
        //values for input name and select name MUST match the inputs below for IActionRequest
        //get is default form method, this shows the form data in the webaddess, Post does not
        //Get is like what you write outside an envelope and post is like content inside
        private string htmlForm = @"
            <form method='POST'>
                <input name='userName'>
                <select name='language'>
                    <option>English</option>
                    <option>Spanish</option>
                    <option>Russian</option>
                    <option>French</option>
                </select>
                <button type='submit'>Greet Me!</button>
            </form>";
        
        //[HttpGet] is not a C# thing, it's an MVC thing
        [HttpGet]
        public IActionResult Index()
        {
            return Content(htmlForm, "text/html");
        }

        [HttpPost]
        public IActionResult Index(string userName, string language)
        {
            return RedirectToAction(actionName: nameof(Greeting), routeValues: new { userName, language });
        }
        
        //[HttpGet]
        [HttpGet]
        public IActionResult Greeting(string userName, string language)
        {
            string greeting ="";
            if (language.ToLower() == "english")
                greeting = "Hello";
            if (language.ToLower() == "spanish")
                greeting = "Hola";
            if (language.ToLower() == "russian")
                greeting = "Privet";
            if (language.ToLower() == "french")
                greeting = "Bonjour";

            return Content($"{greeting} {userName}");
        }
    }
}