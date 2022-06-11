using App.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_5.Services;

public class DbService : IDbService
{
    private readonly MainDbContext _dbContext;

    public DbService(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateDoctor(CreateDoctorDto dto)
    {
        _dbContext.Doctors.Add(new Doctor()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        });
        await _dbContext.SaveChangesAsync();
    }

    public async Task<DoctorDto?> GetDoctor(int idDoctor)
    {
        return await _dbContext.Doctors.Select(e => new DoctorDto()
            {
                Id = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            })
            .Where(e => e.Id == idDoctor)
            .SingleOrDefaultAsync();
    }

    public async Task UpdateDoctor(int idDoctor, UpdateDoctorDto dto)
    {
        _dbContext.Doctors.Update(new Doctor()
        {
            IdDoctor = idDoctor,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        });
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDoctor(int idDoctor)
    {
        _dbContext.Doctors.Remove(new Doctor()
        {
            IdDoctor = idDoctor,
        });
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PrescriptionDto?> GetPrescription(int idPrescription)
    {
        return await _dbContext.Prescriptions.Select(e => new PrescriptionDto()
            {
                Id = e.IdDoctor,
                Date = e.Date,
                DueDate = e.DueDate,
                Patient = new PatientDto()
                {
                    Id = e.Patient.IdPatient, FirstName = e.Patient.FirstName, LastName = e.Patient.LastName,
                    Birthdate = e.Patient.Birthdate
                },
                Doctor = new DoctorDto()
                {
                    Id = e.Doctor.IdDoctor, FirstName = e.Doctor.FirstName, LastName = e.Doctor.LastName,
                    Email = e.Doctor.Email
                },
                Medicaments = e.PrescriptionMedicaments.Select(pm => pm)
                    .Where(pm => pm.IdPrescription == e.IdPrescription)
                    .Select(pm => new MedicamentDto()
                    {
                        Id = pm.Medicament.IdMedicament, Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description, Type = pm.Medicament.Type
                    })
                    .ToList()
            })
            .Where(e => e.Id == idPrescription)
            .SingleOrDefaultAsync();
    }
}