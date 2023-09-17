namespace HospitalApp.Entitites
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Type { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionsMedicament { get; set; } = new List<PrescriptionMedicament>();
    }
}
