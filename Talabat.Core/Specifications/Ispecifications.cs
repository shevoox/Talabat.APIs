using System.Linq.Expressions;

namespace Talabat.Core.Specifications
{
    public interface Ispecifications<T> where T : class

    {
        public Expression<Func<T, bool>>? Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; }
        public Expression<Func<T, object>> OrderBy { get; }
        public Expression<Func<T, object>> OrderByDesc { get; }
    }
}
