using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupApplication
{
    using DomainModel;

    class Program
    {
        static void Main(string[] args)
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            using (var context = new DeviceContext())
            {
                var items = context.ControllerTypes.SelectMany(x => x.Datapoints).ToList();
            }
        }
    }
}
