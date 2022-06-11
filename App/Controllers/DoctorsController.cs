using APBD_5.Services;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/doctors")]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
    {
        try
        {
            await _dbService.CreateDoctor(dto);

            return Ok();
        }
        catch (Exception exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpGet("{idDoctor}")]
    public async Task<IActionResult> GetDoctor(int idDoctor)
    {
        try
        {
            var doctor = await _dbService.GetDoctor(idDoctor);

            if (doctor == null) return NotFound("Doctor not found!");

            return Ok(doctor);
        }
        catch (Exception exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpPut("{idDoctor}")]
    public async Task<IActionResult> UpdateDoctor(int idDoctor, UpdateDoctorDto dto)
    {
        try
        {
            var doctor = await _dbService.GetDoctor(idDoctor);

            if (doctor == null) return NotFound("Doctor not found!");

            await _dbService.UpdateDoctor(idDoctor, dto);

            return Ok();
        }
        catch (Exception exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpDelete("{idDoctor}")]
    public async Task<IActionResult> DeleteDoctor(int idDoctor)
    {
        try
        {
            var doctor = await _dbService.GetDoctor(idDoctor);

            if (doctor == null) return NotFound("Doctor not found!");

            await _dbService.DeleteDoctor(idDoctor);

            return Ok();
        }
        catch (Exception exception)
        {
            return Conflict(exception.Message);
        }
    }
}