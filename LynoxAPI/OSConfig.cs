using System;
using System.Collections.Generic;

namespace Lynox.LynoxAPI;

public class OSConfig
{
    public static Dictionary<string, string> OSConfigs = new Dictionary<string, string>()
    {
        {"kernelname", "Lynox"},
        {"osname", OSDistribution.Info.DISTRO_NAME},
        {"osauthor", OSDistribution.Info.DISTRO_AUTHOR},
        {"osversion", OSDistribution.Info.DISTRO_VERSION},
    };

    public static string FetchOSConfig(string configName)
    {
        foreach (var osconfig in OSConfigs)
        {
            if (osconfig.Key == configName.ToLower())
            {
                return osconfig.Value;
            }
        }
        Console.WriteLine("WARNING: OS Configuration has not been fetched as it does not exist.");
        return "";
    }
}