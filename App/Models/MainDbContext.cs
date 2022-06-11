using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class MainDbContext : DbContext
{
    protected MainDbContext()
    {
    }

    public MainDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>(p =>
        {
            p.HasData(new Doctor()
                {IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jan@example.com"});
        });
        modelBuilder.Entity<Medicament>(p =>
        {
            p.HasData(new Medicament()
                {IdMedicament = 1, Name = "Apap", Description = "Lek na bol glowy", Type = "tabletka"});
        });
        modelBuilder.Entity<Patient>(p =>
        {
            p.HasData(new Patient()
                {IdPatient = 1, FirstName = "Jan", LastName = "Nowak", Birthdate = DateTime.Parse("2000-01-01")});
        });
        modelBuilder.Entity<Prescription>(p =>
        {
            p.HasData(new Prescription()
            {
                IdPrescription = 1, Date = DateTime.Parse("2022-01-01"), DueDate = DateTime.Parse("2023-01-01"),
                IdPatient = 1, IdDoctor = 1
            });
        });
        modelBuilder.Entity<PrescriptionMedicament>(p =>
        {
            p.HasKey(e => new {e.IdMedicament, e.IdPrescription});
            p.HasData(new PrescriptionMedicament()
            {
                IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "rano"
            });
        });
    }
}