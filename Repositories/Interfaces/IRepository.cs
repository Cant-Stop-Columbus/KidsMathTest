using FluencyMath.DataModels;
using System;
using System.Collections.Generic;

namespace FluencyMath.Repositories
{
    public interface IRepository<T> where T : class, IDTO
    {
        string RepositoryName { get; set; }
        void Delete(T dto);
        void DeleteById(Guid id);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        IEnumerable<T> GetByIds(List<Guid> Ids);
        void Save(T dto);
    }
}