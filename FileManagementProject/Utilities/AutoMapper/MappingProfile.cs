﻿using AutoMapper;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDtoForCreate, Employee>();
            CreateMap<Employee, EmployeeDtoForCreate>();
            CreateMap<EmployeeDtoForUpdate, Employee>();
            CreateMap<Employee,  EmployeeDto>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDtoForUpdate, Department>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
