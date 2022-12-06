using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RealRSVPApplication.Models;

namespace RealRSVPApplication.Controllers;

public class ContextObjectsController : Controller
{   
    [HttpGet]
    public IActionResult HomePage(){
        ViewBag.GreetThem = "Hello over there man.";
        return View("HomePage");
    }
    [HttpGet]
    public IActionResult RedirectedAction(){
                //In  A REAL WORLD iD PLACE THIs LIST IN A MODEL.
        // Note that I've assigned the string value type to nullable.
        IDictionary<string,string?> RequestArrayValues = new Dictionary<string,string?>(); 
        
        // Some magic just happenned here I had to convert the Request types ToString()
        RequestArrayValues["ContentType"] =  Request.ContentType?? "No output generated";
        RequestArrayValues["Query"] = Request.Query.ToString();
        RequestArrayValues["Cookies"] = Request.Cookies.ToString();
        RequestArrayValues["Body"] = Request.Body.ToString();
        RequestArrayValues["Host"] = Request.Host.ToString();
        return View(RequestArrayValues);
    }

    
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}