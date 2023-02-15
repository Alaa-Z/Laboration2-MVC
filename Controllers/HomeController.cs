using Laboration2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;


namespace Laboration2.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Index(NameModel model)
        {
            if(ModelState.IsValid)
            {
                string? name = model.Name;
                // Save the name in Session 
                HttpContext.Session.SetString("nameSession",name);
                // Get the session variable 
                ViewBag.sessionContent = "Welcome " + HttpContext.Session.GetString("nameSession");
            }
           

            return View();
        }


        //Adjust routing
        [Route("/add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost] // To handle the post request 
        [Route("/add")]
        public IActionResult Add(EducationModel model)
        { 
            // Form correctly filled out 
            if(ModelState.IsValid)
            {
                // Read json file
                var jsonStr = System.IO.File.ReadAllText("educations.json");
                // Convert to a list of type EducationModel and save it
                var jsonObj = JsonConvert.DeserializeObject<List<EducationModel>>(jsonStr);

                if(jsonObj != null)
                {
                    // Add new model education to the list i json- file
                    jsonObj.Add(model);
                    System.IO.File.WriteAllText("educations.json", JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
                    // Back to home page
                    return RedirectToAction("Educations", "Home");
                }
            }
            return View(); 
        }


        //Adjust routing
        [Route("/education")]
        public IActionResult Educations()
        {
            // Read json file
            var jsonStr = System.IO.File.ReadAllText("educations.json");
            // Convert to a list of type EducationModel and save it
            var jsonObj = JsonConvert.DeserializeObject<List<EducationModel>>(jsonStr);
            return View(jsonObj);
        }

    }
}