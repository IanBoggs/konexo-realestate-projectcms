using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestMVC
{
    public static class CommonFunctions
    {
        public static Expression<Func<TData, bool>> CreateEqualsFilter<TData, TKey>(Expression<Func<TData, TKey>> selector, TKey valueToCompare)
        {
            var parameter = Expression.Parameter(typeof(TData));
            var expressionParameter = Expression.Property(parameter, GetParameterName(selector));

            var body = Expression.Equal(expressionParameter, Expression.Constant(valueToCompare, typeof(TKey)));
            //var body = Expression.GreaterThan(expressionParameter, Expression.Constant(valueToCompare, typeof(TKey)));
            return Expression.Lambda<Func<TData, bool>>(body, parameter);
        }
        public static Expression<Func<TData, bool>> CreateEqualsFilter<TData, TKey>(string column, TKey valueToCompare, bool exactMatch = true)
        {
            var parameter = Expression.Parameter(typeof(TData));
            var expressionParameter = Expression.Property(parameter, column);
            var left = Expression.Call(expressionParameter, "ToLower", Type.EmptyTypes);
            var value = Expression.Call(Expression.Constant(valueToCompare, typeof(TKey)), "ToLower", Type.EmptyTypes);


            var body = Expression.Equal(left, value);
            //var body = Expression.GreaterThan(expressionParameter, Expression.Constant(valueToCompare, typeof(TKey)));
            return Expression.Lambda<Func<TData, bool>>(body, parameter);
        }

        private static string GetParameterName<TData, TKey>(Expression<Func<TData, TKey>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return memberExpression.ToString().Substring(2);
        }
    }
}