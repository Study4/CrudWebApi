using System.Linq;
using System.Threading.Tasks;
using System;
using CrudWebApi.Api.Model.Dtos;

namespace CrudWebApi.Api.Services
{
    public interface IEmployeeService : IDisposable
    {
        Task<EmployeeDto> DeleteAsync(int id);
        IQueryable<EmployeeDto> GetAll();
        Task<EmployeeDto> GetAllAsync(int id);
        Task<EmployeeDto> SaveAsync(EmployeeDto dto);
    }
}