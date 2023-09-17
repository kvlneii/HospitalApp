namespace HospitalApp.Models
{
    public enum StatusResponse
    {
        OK = 200,
        UserIsAlreadyRegistered,
        BadPassword,
        UserNotFound,
        RefreshTokenIsExpired
    }
}
