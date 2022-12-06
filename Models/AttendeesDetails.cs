using System.ComponentModel.DataAnnotations;// the class for the validation properties(look alike to filters in actions.)

namespace RealRSVPApplication.Models;

public class AttendeeDetails{
    // always use nullable values as the variables of a model.
    // validation attributes.
    
    [Required(ErrorMessage="Name field can not be empty")]
    public string? Name{get;set;}
    
    //REUIRED USES THE NULL VALUE TO DETERMINE WHETHER THE PROPERTY IS EMPTY. 
    
    [Required(ErrorMessage = "E-mail required")]
    public string? Email{get;set;}
    
    [Required(ErrorMessage = "Input a valid phone number please")]
    public int? Phone{get;set;}
    
    [Required(ErrorMessage = "Must have an attendance value")]
    public bool? WillAttend{get;set;}

    // I have added this by myself, it was not there initially.

    //No nullable bool since its working with a check box.
    // Adding a UIHint
    [UIHint("checkbox")]
    [Required(ErrorMessage ="You Must check the box please for you to be allowed")]
    [Display(Name = "Are you confirming that whatever you say here is true to the best of your knowledge")]
    public bool BooleanValue{get;set;}

    // This ia also added. Used for specifying the type in the model directly.
    [UIHint("Password")]
    public string? Password{get;set;}
    
}