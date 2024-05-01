using System;
using System.Linq.Expressions;

namespace HondaDealership.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, object>> OrderBy { get; set; }
        public bool OrderByDescending { get; set; }
    }

}
