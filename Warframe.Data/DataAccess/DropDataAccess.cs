using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Warframe.Data
{
    class DropDataAccess
    {
        public void GetDropData()
        {
            var obj = JObject.Parse(string.Empty);
            foreach (var planet in obj.Properties())
            {
                
            }
        }
    }
}
