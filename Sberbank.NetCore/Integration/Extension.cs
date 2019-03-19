using Sberbank.NetCore.Integration.Interfaces;
using System;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration
{
    internal static class Extension
    {
        public static void AddNotNull<TValue>(this Dictionary<string, object> source, string key, TValue? value)
            where TValue : struct
        {
            if (value.HasValue)
            {
                var type = typeof(TValue);
                if (type.IsEnum)
                    source.Add(key, $"{Convert.ToInt32(value.Value)}");
                else if (type.IsPrimitive)
                    source.Add(key, $"{value}");
            }
        }

        public static void AddNotNull(this Dictionary<string, object> source, string key, IValueParameter parameter)
            => source.AddNotNull(key, parameter?.Value);

        public static void AddNotNull(this Dictionary<string, object> source, string key, IParameters value)
        {
            if (value?.CollectParameters() != null)
                source.Add(key, value);
        }

        public static void AddNotNull(this Dictionary<string, object> source, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                source.Add(key, value);
        }
    }
}
