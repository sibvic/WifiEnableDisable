using CommandLine;
using System;
using System.Threading.Tasks;

class Wifi
{
    public Wifi(WifiOptions options)
    {
        _options = options;
    }

    readonly WifiOptions _options;
    Random _rnd = new Random();

    public async Task<int> StartAsync()
    {
        while (true)
        {
            await Task.Delay(_options.Uptime * 60000);
            Console.WriteLine("Disabling wifi");
            System.Diagnostics.Process.Start("netsh", "interface set interface \"" + _options.Inteface + "\" disable");

            var downtime = _rnd.Next(_options.DowntimeMin * 60, _options.DowntimeMax * 60);
            await Task.Delay(downtime * 1000);
            Console.WriteLine("Enabling wifi");
            System.Diagnostics.Process.Start("netsh", "interface set interface \"" + _options.Inteface + "\" enable");
        }
        return 0;
    }
}

namespace WifiEnableDisable
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<WifiOptions>(args)
                .MapResult(
                    (WifiOptions opts) => new Wifi(opts).StartAsync().Result,
                    errs => 1);
        }
    }
}
