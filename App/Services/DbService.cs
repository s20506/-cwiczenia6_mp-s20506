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
}