using System;
using System.Linq;
using System.Linq.Expressions;

namespace CashFlow
{
    public static class LinqExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ((IOrderedQueryable<T>)ApplyOrder(source, property, "OrderBy"));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ((IOrderedQueryable<T>)ApplyOrder(source, property, "OrderByDescending"));
        }

        //private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        private static IOrderedQueryable ApplyOrder(IQueryable source, string property, string methodName)
        {
            var props = property.Split('.');
            var type = source.ElementType;
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                try
                {
                    var pi = type.GetProperty(prop);
                    if (pi != null)
                    {
                        expr = Expression.Property(expr, pi);
                        type = pi.PropertyType;
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Property = " + prop, ex);
                }
            }
            var delegateType = typeof(Func<,>).MakeGenericType(source.ElementType, type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(source.ElementType, type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable)result;
        }
    }
}
