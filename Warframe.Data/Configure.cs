using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Data
{
    public static class Configure
    {
        static CoreClient _client;

        public static void Init(string baseLocation, string indexLocation, int refreshMinutes)
        {
            BaseLocation = baseLocation;
            IndexLocation = indexLocation;
            RefreshMinutes = refreshMinutes;
            Initialized = true;
        }

        internal static bool Initialized { get; private set; }

        //todo: validate config settings
        public static string BaseLocation { get; set; }
        public static string IndexLocation { get; set; }
        public static int RefreshMinutes { get; set; }

        internal static async Task<CoreClient> GetClient()
        {
            if (!Initialized)
                throw new InvalidOperationException("Configure must be initialized before getting a client.");
            return _client ?? (_client = await CoreClient.Create(BaseLocation, IndexLocation));
        }
    }
}
