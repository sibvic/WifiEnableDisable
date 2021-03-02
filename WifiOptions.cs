using CommandLine;

[Verb("wifi", HelpText = "Disable/enable wifi on timer.")]
class WifiOptions
{
    [Option("uptime", HelpText = "How long to keep it enabled, minutes.", Default = 10)]
    public int Uptime { get; set; }

    [Option("downtime-min", HelpText = "How long to keep it disabled (min), minutes.", Default = 3)]
    public int DowntimeMin { get; set; }

    [Option("downtime-max", HelpText = "How long to keep it disabled (max), minutes.", Default = 7)]
    public int DowntimeMax { get; set; }

    [Option("interface", Required = true, HelpText = "Name of the interface")]
    public string Inteface { get; set; }
}
