using AutoMapper;
using CrudWebApi.Model;
using CrudWebApi.Api.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebApi.Api.Model.Dtos
{
    public class EventProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

        }
    }
}
