using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Api.Business.Services.Interfaces
{
    public interface IService<TEntity, TDto>
    {
        TDto GetById(int id);
        IEnumerable<TDto> GetAll();
        TDto Add(TDto entity);
        TDto Update(TDto entity);
        void Delete(int id);
    }
}
