using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.MappingProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();

            CreateMap<UpdateDoctorDto, Doctor>();

            CreateMap<Doctor, DoctorResponseDto>();
        }
    }
}