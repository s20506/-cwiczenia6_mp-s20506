using APBD_5.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/prescriptions")]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{idPrescription}")]
    public async Task<IActionResult> GetPrescription(int idPrescription)
    {
        try
        {
            var prescription = await _dbService.GetPrescription(idPrescription);

            if (idPrescription == null) return NotFound("Prescription not found!");

            return Ok(prescription);
        }
        catch (Exception exception)
        {
            return Conflict(exception.Message);
        }
    }
}