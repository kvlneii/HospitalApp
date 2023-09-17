using Microsoft.EntityFrameworkCore;
using HospitalApp.Entitites;
using HospitalApp.Models;
using HospitalApp.Models.DTO;

namespace HospitalApp.Services
{
    public class HospitalDbService : IHospitalDbService
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public HospitalDbService(HospitalDbContext context)
        {
            this._hospitalDbContext = context;
        }


        public async Task<IList<DoctorDTO>> GetDoctorsAsync()
        {
            return await _hospitalDbContext.Doctors.Select(e => new DoctorDTO
            { 
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
            }).ToListAsync();
        }

        public async Task<string> AddDoctorAsync(DoctorDTO doctorDto)
        {
            await _hospitalDbContext.Doctors.AddAsync(new Doctor
            {
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Email = doctorDto.Email
            });
            await _hospitalDbContext.SaveChangesAsync();

            return "Success!";
        }

        public async Task<string> DeleteDoctorAsync(int doctorId)
        {
            var tmp = await _hospitalDbContext.Doctors.FindAsync(doctorId);

            if (tmp == null)
                return "Can not find the doctor in DB!";

            var isHavingPatiets = await _hospitalDbContext.Prescriptions.AnyAsync(e => e.IdDoctor == doctorId);

            if (isHavingPatiets)
                return "It is not possible to delete the doctor because he signed prescriptions to patients";

            _hospitalDbContext.Remove(tmp);
            await _hospitalDbContext.SaveChangesAsync();

            return "Success!";
        }

        public async Task<string> ChangeDoctorAsync(int doctorId, DoctorDTO dto)
        {
            var tmp = await _hospitalDbContext.Doctors.FindAsync(doctorId);

            if (tmp == null)
                return "Can not find the doctor in DB!";

            tmp.LastName = dto.LastName;
            tmp.FirstName = dto.FirstName;
            tmp.Email = dto.Email;

            await _hospitalDbContext.SaveChangesAsync();

            return "Success!";
        }

        public async Task<PrescriptionDTO> GetPrescriptionAsync(int idPrescription)
        {
            var tmpPrescription = await _hospitalDbContext.Prescriptions.FindAsync(idPrescription);

            if (tmpPrescription == null)
                return null;

            PrescriptionDTO prescriptionDto = await _hospitalDbContext.Prescriptions
                    .Where(e => e.IdPrescription == idPrescription)
                    .Select(e => new PrescriptionDTO
                    {
                        PatientFirstName = e.Patient.FirstName,
                        PatientLastName = e.Patient.LastName,
                        PatientBirthdate = e.Patient.Birthdate,
                        DoctorFirstName = e.Doctor.FirstName,
                        DoctorLastName = e.Doctor.LastName,
                        DoctorEmail = e.Doctor.Email,
                        Date = e.Date,
                        DueDate = e.DueDate,
                        Medicaments = e.PrescriptionMedicaments.Select(e => new MedicamentDTO
                        {
                            Name = e.Medicament.Name,
                            Dose = e.Dose,
                            Details = e.Details
                        })
                    }).FirstAsync();


            return prescriptionDto;
        }
    }
}
