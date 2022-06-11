using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class DoctorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}