using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public class ExportWrapper<T>
    {
        public IEnumerable<T> Export { get; set; }
    }
}
