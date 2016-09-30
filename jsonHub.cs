using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataTransaction
{
    public static class jsonHub
    {
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public static object Deserialize<T>(String s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }   

    }
}
