using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NutriBase.Logic.Modules.Extensions
{
    public static class ObjectExtensions
    {
        public static void CopyProperties<TSource, TTarget>(this TSource source, TTarget target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException("Source or/and Target Objects are null");
            }

            var sourceProperties = GetAllTypeProperties(source);
            var targetProperties = GetAllTypeProperties(target);

            foreach (var sourceProp in sourceProperties.Values) 
            { 
                if(targetProperties.TryGetValue(sourceProp.Name, out var targetProp) && 
                    targetProp.PropertyType == sourceProp.PropertyType &&
                    targetProp.CanWrite)
                {
                    targetProp.SetValue(target, sourceProp.GetValue(source, null), null);
                }
            }
        }

        private static Dictionary<string, PropertyInfo> GetAllTypeProperties<T>(T obj)
        {
            var properties = new Dictionary<string, PropertyInfo>();
            foreach (var prop in obj!.GetType().GetProperties())
            {
                properties[prop.Name] = prop;
            }

            return properties;
        }
    }
}
