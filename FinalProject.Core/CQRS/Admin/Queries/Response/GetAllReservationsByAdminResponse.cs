namespace FinalProject.Core.CQRS.Admin.Queries.Response;

public class GetAllReservationsByAdminResponse
{
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public string ReservationDate { get; set; }
}