using System.Reflection;

namespace ParasutIntegration.Util
{
    public static class DictionaryConverter
    {
        public static Dictionary<string, string> ToDictionary<T>(T obj)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object value = property.GetValue(obj);
                dict.Add(property.Name, value != null ? value.ToString() : string.Empty);
            }

            return dict;
        }
    }
}
