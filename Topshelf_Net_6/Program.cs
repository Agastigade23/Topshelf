using Topshelf;
using Topshelf_Net_6;

HostFactory.Run(windowsService =>
{
    windowsService.Service<ServiceExample>(s =>
    {
        s.ConstructUsing(service => new ServiceExample());
        s.WhenStarted(service => service.Start());
        s.WhenStopped(service => service.Stop());
    });

    windowsService.RunAsLocalSystem();
    windowsService.StartAutomatically();

    windowsService.SetDescription("Topshelf_Net_6");
    windowsService.SetDisplayName("Topshelf_Net_6");
    windowsService.SetServiceName("WInservice with .Net 6 Topshelf");
});