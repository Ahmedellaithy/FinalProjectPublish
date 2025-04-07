namespace FinalProject.Data.CommandResponse.ReservationResponse;

public class CancelPatientReservationResponse
{
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public TimeSpan ReservationDate { get; set; }
}