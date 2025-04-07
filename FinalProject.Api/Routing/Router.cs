namespace FinalProject.Api.Routing;

public static class Router
{
    public const string root = "Api/";
    public const string version = "v1/";
    public const string role=root+version;

    
    public static class Doctor
    {
        public const string prefix = role + "Doctor";
        public const string GetDoctorById = prefix + "/GetDoctorById";
        public const string GetDoctorsPaginated = prefix + "/GetDoctorsPaginated";
        public const string GetDoctorReservationsById = prefix + "/GetReservationsByDoctorId";
    }
    
    public static class Authentication
    {
        public const string Prefix = role+"Authentication";
        public const string Register = Prefix+"/Register";
        public const string Login = Prefix+"/Login";
        public const string SetNewPassword=Prefix+"/SetNewPassword";
    }

    public static class Patient
    {
        public const string prefix = role + "Patient";
        public const string GetPatientById = prefix + "/GetPatientById";
        public const string UpdatePatient = prefix + "/UpdatePatient";
        public const string UpdatePatientProfilePicture = prefix + "/UpdateProfilePicture";
    }


    public static class RefreshToken
    {
        public const string prefix = role + "RefreshToken";
        public const string CreateRefreshToken = prefix + "/CreateRefreshToken";
    }


    public static class Reservation
    {
        public const string prefix = role + "Reservation";
        public const string GetAllReservations = prefix + "/GetAllReservations";
        public const string PatientReservationsById = prefix + "/PatientReservationsById";
        public const string CancelPatientReservationById = prefix + "/CancelPatientReservationById";
        public const string GetAllReservationsByPatientById = prefix + "/GetAllReservationsByPatientById";
    }

    public static class Admin
    {
        public const string prefix = role + "Admin";
        public const string AddDoctor = prefix + "/AddDoctor";
        public const string EditDoctor = prefix + "/EditDoctor";
        public const string RemoveDoctor = prefix + "/RemoveDoctor";
        public const string GetAllReservations = prefix + "/GetAllReservations";
    }
    
    
    public static class PayPal
    {
        public const string prefix = role + "PayPal";
        public const string Create = prefix + "/Create";
        public const string Success = prefix + "/Success";
        public const string Cancel = prefix + "/Cancel";
    }
    
}