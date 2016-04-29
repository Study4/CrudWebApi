using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using CrudWebApi.Bll;
using CrudWebApi.Model;
using CrudWebApi.Api.Model.Dtos;

namespace CrudWebApi.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeLogic _logic;
        private IMapper _mapper;

        public EmployeeService(IMapper mapper)
        {
            _mapper = mapper;
            _logic = new EmployeeLogic();
        }

        /// <summary>
        /// 取得
        /// </summary>
        /// <returns></returns>
        public IQueryable<EmployeeDto> GetAll()
        {
            return _logic.GetAll().ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
        }

        /// <summary>
        /// 取得 by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> GetAllAsync(int id)
        {
            return _mapper.Map<EmployeeDto>(await _logic.GetAllAsync(id));
        }


        /// <summary>
        /// 儲存與更新
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> SaveAsync(EmployeeDto dto)
        {
            var model = _mapper.Map<Employee>(dto);
            return _mapper.Map<EmployeeDto>(await _logic.SaveAsync(model));
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> DeleteAsync(int id)
        {
            return _mapper.Map<EmployeeDto>(await _logic.DeleteAsync(id));
        }

        public void Dispose()
        {
            _logic.Dispose();
        }
        
    }
}