using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GitForms.Util
{
    public class JsonConvert<T> where T : new()
    {
        public T ToObject(string json)
        {
            T objectDeserialize = new T();
            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(objectDeserialize.GetType());
            objectDeserialize = (T)ser.ReadObject(ms);
            ms.Close();
            return objectDeserialize;
        }

        public string ToJson(T entity)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, entity);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.ASCII.GetString(json, 0, json.Length);
        }
    }
}
