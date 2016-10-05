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
            try
            {
                return JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }

        public static object Deserialize<T>(String s)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(s);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return null;
            }
        }   

    }
}
