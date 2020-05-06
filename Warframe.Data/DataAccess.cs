using System;

namespace Warframe.Data
{
    public abstract class DataAccess
    {
        protected DataAccess()
        {
            if (!Configure.Initialized)
                throw new InvalidOperationException("Call Configure.Init before constructing a data access class.");
            CoreClient = Configure.GetClient().Result;
        }

        protected CoreClient CoreClient { get; }
    }
}