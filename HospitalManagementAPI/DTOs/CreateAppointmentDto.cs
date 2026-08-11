namespace HospitalManagementAPI.DTOs
{
    public class CreateAppointmentDto
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; } = string.Empty;
    }
}