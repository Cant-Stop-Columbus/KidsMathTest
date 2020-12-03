//using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using FluencyMath.DataModels;

namespace FluencyMath.Repositories
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class, IDTO
    {
        public string RepositoryName { get; set; } = typeof(T).FullName.Replace("DTO", "Repository");

        //public Repository(IOptions<AppSettings> appSettings) : base(appSettings)
        //{
        //}

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
            //try
            //{
            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    return db.Select<T>();
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "GetAll");
            //}
        }

        public virtual IEnumerable<T> GetByIds(List<Guid> Ids)
        {
            throw new NotImplementedException();
            //try
            //{
            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    return db.Select<T>(x => Sql.In(x, Ids));
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "GetByIds", null, Ids);
            //}
        }

        public T GetById(Guid id)
        {
            throw new  NotImplementedException();
            //try
            //{
            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    return db.Single<T>(x => x.Id == id);
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "GetById", null, id);
            //}
        }

        public void Save(T dto)
        {
            throw new NotImplementedException();
            //try
            //{
            //    if (dto.Id == Guid.Empty)
            //        throw new Exception("Empty Id is not allowed on Save");

            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    db.Save(dto);
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "Save", dto);
            //}

        }

        public void Delete(T dto)
        {
            throw new NotImplementedException();
            //try
            //{
            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    db.Delete(dto);
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "Delete", dto);
            //}
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
            //try
            //{
            //    using IDbConnection db = RecruitingDataFactory.OpenDbConnection();
            //    db.DeleteById<T>(id);
            //}
            //catch (Exception ex)
            //{
            //    throw new RepositoryException(ex, RepositoryName, "DeleteById", id);
            //}
        }
    }
}