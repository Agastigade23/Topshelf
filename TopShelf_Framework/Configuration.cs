using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf_Framework
{
    internal class Configuration
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<OwnService>(service =>
                {
                    service.ConstructUsing(s => new OwnService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("TopShelf_Framework");
                configure.SetDisplayName("TopShelf_Framework");
                configure.SetDescription("WinService With Topshelf");
            });
        }
    }
}
