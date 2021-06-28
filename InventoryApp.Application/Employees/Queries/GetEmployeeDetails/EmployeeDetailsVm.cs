﻿using AutoMapper;
using InventoryApp.Application.Common.Mappings;
using InventoryApp.Domain;
using System.Collections.Generic;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

        public IEnumerable<CheckoutDto> Checkouts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(dest => dest.Department,
                    opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Position,
                    opt => opt.MapFrom(src => src.Position.Name));
        }
    }
}