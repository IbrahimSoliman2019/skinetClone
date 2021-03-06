using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, Object>>> Includes { get; } = new List<Expression<Func<T, Object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool isPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, Object>> include)
        {
            Includes.Add(include);
        }


        protected void AddOrderBy(Expression<Func<T, Object>> orderBy)
        {
            OrderBy = orderBy;
        }
        protected void AddOrderByDescinding(Expression<Func<T, Object>> orderBy)
        {
            OrderByDescending = orderBy;
        }
        protected void ApplyPaging( int skip,int take)
        {
            Take = take;
            Skip = skip;
            isPagingEnabled = true;
        }
    }
}