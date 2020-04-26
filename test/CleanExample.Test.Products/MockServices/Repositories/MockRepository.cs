﻿using CleanExample.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanExample.Test.Products.MockServices.Repositories
{
    public abstract class MockRepository<T> where T : AbstractEntity
    {
        static IList<T> store;

        protected IList<T> GetStore()
        {
            if (store == null)
                store = new List<T>();

            return store;
        }

        public T Create(T entity)
        {
            entity.Id = System.Guid.NewGuid();
            GetStore().Add(entity);
            return entity;
        }

        public bool Delete(Guid id)
        {
            var stored = GetStore().FirstOrDefault(x => x.Id == id);
            if (stored != null)
            {
                return GetStore().Remove(stored);
            }

            return false;
        }

        public bool Update(T entity)
        {
            var stored = GetStore().FirstOrDefault(x => x.Id == entity.Id);
            if (stored != null)
            {
                stored = entity;
                return true;
            }

            return false;
        }

        public IEnumerable<T> FindAll()
        {
            return GetStore().ToList();
        }

        public T FindById(Guid id)
        {
            return GetStore().FirstOrDefault(x => x.Id == id);
        }
    }
}