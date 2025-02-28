using System.Reflection;

namespace WebApi.Models
{
    public static class ObjectExtensions
    {
        public static PropertyInfo[] GetNotNullProperties(this object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return obj.GetType()
                      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .Where(prop => prop.GetValue(obj) != null)
                      .ToArray();
        }
    }

}



