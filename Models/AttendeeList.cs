

namespace RealRSVPApplication.Models;

public static class AttendeeList{
    // Everything in a static class is declared as static.
    private static List<AttendeeDetails> attendees = new List<RealRSVPApplication.Models.AttendeeDetails>();

    public static IEnumerable<AttendeeDetails> Attendees {
        get{ return attendees;}
    }
    public static void AddAttendees(AttendeeDetails attender){
        attendees.Add(attender);
    }  
}