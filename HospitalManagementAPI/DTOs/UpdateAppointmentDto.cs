namespace HospitalManagementAPI.DTOs
{
    public class UpdateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;
    }
}