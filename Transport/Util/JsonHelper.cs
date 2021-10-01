using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Transport
{
    
    public class JsonHelper
    {
        public static List<string> InvalidJsonElements;
        public static List<T> DeserializeToList<T>(string jsonString)
        {
            InvalidJsonElements = null;
            var array = JArray.Parse(jsonString);
            List<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    // CorrectElements  
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }

        public static string ReadFile(string file)
        {
            
            StreamReader r = new StreamReader(file);
            return r.ReadToEnd();
        }

        public static JObject Parse(string json)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);
            JObject o1 = JObject.Parse(json);
            return o1;
        }

    }
}
