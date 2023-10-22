using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox
{
    internal static class SystemData
    {
        public const string OSName = "Lynox";              // OS Name
        public const string OSVer  = "0.1";                // OS Version
        public const string OSAcNa = OSName + " " + OSVer; // OS Access Name

        public static CosmosVFS fs = new();
    }
}
