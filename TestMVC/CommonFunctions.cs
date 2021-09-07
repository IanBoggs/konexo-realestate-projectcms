using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TestMVC
{
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }
    }


    public static class CommonFunctions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum obj)
where TEnum : struct, IComparable, IFormattable, IConvertible // correct one    
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = x.DisplayName(),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }

        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType()
                .GetField(value.ToString());
            EnumDisplayNameAttribute attribute = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
            as EnumDisplayNameAttribute;
            return attribute == null ? value.ToString() : attribute.DisplayName;
        }


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