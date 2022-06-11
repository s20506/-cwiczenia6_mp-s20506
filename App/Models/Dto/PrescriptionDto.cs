namespace App.Models;

public class PrescriptionDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public PatientDto Patient { get; set; }
    public DoctorDto Doctor { get; set; }
    public ICollection<MedicamentDto> Medicaments { get; set; }
}