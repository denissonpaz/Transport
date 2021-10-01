using System;
using System.Collections.Generic;
namespace Transport
{
    
    public class Helper
    {
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static bool IsListNotEmpty<T>(IList<T> list)
        {
            return (list != null && list.Count > 0);
        }
    }
}
