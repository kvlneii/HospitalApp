namespace HospitalApp.Models.DTO
{
    public class LoginDTO
    {
        public StatusResponse StatusResponse { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
