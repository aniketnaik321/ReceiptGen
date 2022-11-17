using ResumeBuilder.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Service
{
    public class EtyService
    {
        public static string GetTableName<T>() where T : class
        {
            Type type = typeof(T);
            var at = GetAttribute<TableAttribute>(type);
            return at.Name;
        }
        public static List<string> GetColumnNames<T>() where T : class
        {
            List<string> result = new List<string>();
            foreach (var prop in typeof(T).GetProperties()) {
                var attribute = GetAttribute<ColumnAttribute>(prop);
                if (!String.IsNullOrEmpty(attribute?.Name)){
                    result.Add(attribute.Name);
                }
                //else{
                //    result.Add(prop.Name);
                //}
            }
            return result;              
        }

        private static T GetAttribute<T>(MemberInfo memberInfo) where T : class
        {
            Contract.Requires(memberInfo != null, "memberInfo is null.");
            Contract.Ensures(Contract.Result<T>() != null);
            object[] customAttributes = memberInfo.GetCustomAttributes(typeof(T), false);
            if (customAttributes == null || customAttributes.Count() == 0) return null;
            T attribute = customAttributes.Where(a => a is T).First() as T;
            return attribute;
        }
    }
}
