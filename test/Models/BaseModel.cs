using System.Reflection;

namespace Wangkanai.Validation.Models
{
    public class BaseModel
    {
        public static PropertyInfo GetProperty<T>(string name) where T : BaseModel
            => typeof(T).GetProperty(name);
    }
}