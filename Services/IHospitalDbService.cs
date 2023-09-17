using HospitalApp.Models;
using HospitalApp.Models.DTO;

namespace HospitalApp.Services
{
    public interface IHospitalDbService
    {
        Task<IList<DoctorDTO>> GetDoctorsAsync();
        Task<string> AddDoctorAsync(DoctorDTO doctor);
        Task <string> DeleteDoctorAsync(int doctorId);
        Task<string> ChangeDoctorAsync(int doctorId, DoctorDTO dto);
        Task<PrescriptionDTO> GetPrescriptionAsync(int idPrescription);
    }
}
