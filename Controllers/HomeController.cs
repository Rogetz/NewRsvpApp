using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RealRSVPApplication.Models;

namespace RealRSVPApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Note how the Hour is called.
        ViewBag.Greet = DateTime.Now.Hour > 12 ? "Good Evening" : "Good Morning";
        return View("WelcomePage");
    }

    [HttpGet]
    public IActionResult RSVPForm(){
        return View();
    }

    [HttpPost]
    public IActionResult RSVPForm(AttendeeDetails attendee){
        // testing for validity of the model from the models set.
        if(!ModelState.IsValid){
            return View("RSVPForm");
        }

        // Note that the ViewBag here is used in another view which is the ThankyouPage.
        // Note that this Action returns a View and so It does not pass throught the ThankyouPage Action
        // It simply returns a Thankyou Page View
        // It could have passed through it if maybe it  was to return a redirect or something else
        // other than a View 
        else{
            ViewBag.Attending = attendee.WillAttend.Equals(true) ? "We look forward to seeing you our Friend" : "Thankyou for your Feedback we appreciate your response";
            AttendeeList.AddAttendees(attendee);
            return View("ThankyouPage",attendee);
        }
    }
    /*
    public IActionResult ThankyouPage(AttendeeDetails attendeeTwo){
        // NOte that you can not use the == operator on strings and boolean so we try the Equals method
        ViewBag.Attending = attendee.WillAttend.Equals(true) ? "We look forward to seeing you my Friend" : "Thankyou for your Feedback we appreciate your response";
        return View();
    }*/
    public IActionResult ListResponses(){
        // Test for whether the WillAttend is Equal to true or false.
        return View(AttendeeList.Attendees.Where(i => i.WillAttend.Equals(true)));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
