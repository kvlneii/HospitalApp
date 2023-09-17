namespace HospitalApp.Models.DTO
{
    public class PrescriptionDTO
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthdate { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<MedicamentDTO> Medicaments { get; set; }

    }
}
