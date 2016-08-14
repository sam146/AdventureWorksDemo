﻿namespace AW.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public abstract class Repository<T> where T : class
    {
        private DbContext _entities;
        private readonly IDbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T entityToDelete = _dbset.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var query = _dbset.Where(where);

            string selectSql = query.ToString();
            string deleteSql = "DELETE [Extent1] " + selectSql.Substring(selectSql.IndexOf("FROM"));

            var internalQuery = query.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_internalQuery").Select(field => field.GetValue(query)).First();
            var objectQuery = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.Name == "_objectQuery").Select(field => field.GetValue(internalQuery)).First() as ObjectQuery;
            var parameters = objectQuery.Parameters.Select(p => new SqlParameter(p.Name, p.Value)).ToArray();

            _entities.Database.ExecuteSqlCommand(deleteSql, parameters);
        }

        public virtual T GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public virtual T GetFirst(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll(int pageIndex, int pageSize)
        {
            return _dbset.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }
    }
}
