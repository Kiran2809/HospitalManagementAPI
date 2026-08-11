using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.MappingProfiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<CreatePatientDto, Patient>();

            CreateMap<UpdatePatientDto, Patient>();

            CreateMap<Patient, PatientResponseDto>();
        }
    }
}