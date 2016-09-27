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
            return JsonConvert.SerializeObject(o);
        }

        public static object Deserialize(String s,String type)
        {
            return JsonConvert.DeserializeObject(s);
        }

    }
}
