using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.MappingProfiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentDto, Appointment>();

            CreateMap<UpdateAppointmentDto, Appointment>();

            CreateMap<Appointment, AppointmentResponseDto>()
                .ForMember(
                    dest => dest.PatientName,
                    opt => opt.MapFrom(
                        src => src.Patient!.Name))
                .ForMember(
                    dest => dest.DoctorName,
                    opt => opt.MapFrom(
                        src => src.Doctor!.Name))
                .ForMember(
                    dest => dest.Specialization,
                    opt => opt.MapFrom(
                        src => src.Doctor!.Specialization));
        }
    }
}