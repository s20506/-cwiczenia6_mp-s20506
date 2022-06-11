using App.Models;

namespace APBD_5.Services;

public interface IDbService
{
    Task CreateDoctor(CreateDoctorDto dto);

    Task<DoctorDto?> GetDoctor(int idDoctor);
    
    Task UpdateDoctor(int idDoctor, UpdateDoctorDto dto);
    
    Task DeleteDoctor(int idDoctor);

    Task<PrescriptionDto?> GetPrescription(int idPrescription);
}