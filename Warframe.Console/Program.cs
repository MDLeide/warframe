using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe.Data;

namespace Warframe.Console
{
    class Program
    {
        const string BaseUrl = "http://content.warframe.com/PublicExport/Manifest/";
        const string Index = "http://content.warframe.com/PublicExport/index_en.txt.lzma";
        const int Refresh = 60;

        static void Main(string[] args)
        {
            var dataSaver = new DataSaver("C:\\warframeData\\", BaseUrl, Index);

            var types = Enum.GetValues(typeof(CoreDataType));
            foreach (var type in types.Cast<CoreDataType>())
                dataSaver.SaveData(type);
        }
    }
}
