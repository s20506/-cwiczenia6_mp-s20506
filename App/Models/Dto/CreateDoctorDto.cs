using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class CreateDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}