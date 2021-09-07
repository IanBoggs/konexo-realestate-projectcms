using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace TestMVC
{
    public static class CommonFunctions
    {

        public static Expression<Func<TData, bool>> CreateFilter<TData, TKey>(string columnName, TKey valueToCompare, bool exactMatch = true)
        {

            var parameter = Expression.Parameter(typeof(TData));
            var expressionParameter = Expression.Property(parameter, columnName);
            var value = Expression.Call(Expression.Constant(valueToCompare, typeof(TKey)), "ToLower", Type.EmptyTypes);

            if (exactMatch)
            {
                var left = Expression.Call(expressionParameter, "ToLower", Type.EmptyTypes);

                var body = Expression.Equal(left, value);
                return Expression.Lambda<Func<TData, bool>>(body, parameter);
            }
            else
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                var containsMethodExp = Expression.Call(expressionParameter, method, value);

                return Expression.Lambda<Func<TData, bool>>(containsMethodExp, parameter);
            }
            //return Expression.Lambda<Func<TData, bool>>(body, parameter);
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