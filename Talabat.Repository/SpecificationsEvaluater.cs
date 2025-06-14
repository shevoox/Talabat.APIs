﻿using Microsoft.EntityFrameworkCore;
using Talabat.Core.Specifications;

namespace Talabat.Infrastructure
{
    internal static class SpecificationsEvaluater<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, Ispecifications<TEntity> spec)
        {
            var query = inputQuery.AsQueryable();//_dbcontext.set<TEntity>
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);//query=_dbcontext.set<TEntity>.Where(E=>E.id==1)

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
