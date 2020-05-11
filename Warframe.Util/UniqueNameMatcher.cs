using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Util
{
    public static class UniqueNameMatcher
    {
        public static bool AreEqual(IUniqueName a, IUniqueName b)
        {
            return a.UniqueName == b.UniqueName;
        }

        public static T Find<T>(IEnumerable<T> collection, string uniqueName)
            where T : IUniqueName
        {
            return collection.FirstOrDefault(p => p.UniqueName == uniqueName);
        }
    }
}
