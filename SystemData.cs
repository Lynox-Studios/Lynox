using Cosmos.System.FileSystem;
using Lynox.LynoxAPI.SystemFetcher;
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
        public const string OSVer  = "0.1.0.0";                // OS Version
        public const string OSAcNa = OSName + " " + OSVer; // OS Access Name
        public const string CurrentDrive = "0:\\";

        public static CosmosVFS fs = new();
        public static ProcessManager procMgr = new();
        public static string currentUser = "root";

        public static void init() {
            procMgr.AddProc(OSName);
            var serv_fetcher = new Service(0, "SYSTEM_FETCHER", FetchManager.FetchRunning, FetchManager.FetchAll_STARTING);
            procMgr.ServiceNames.Add(serv_fetcher);
        }
    }

    internal class ProcessManager
    {
        public List<string> ProcessNames = new List<string>();
        public List<Service> ServiceNames = new List<Service>();
        public void AddProc(string procName) => ProcessNames.Add(procName);
        public void RemProc(string procName) => ProcessNames.Remove(procName);
    }

    public struct Service
    {
        public int id;
        public string name;
        public Action runningAction;
        public Action startAction;
        public Service(int ID, string NAME, Action RUNNINGACTION, Action STARTACTION)
        {
            id = ID;
            name = NAME;
            runningAction = RUNNINGACTION;
            startAction = STARTACTION;
        }

        public void ServiceStart() => startAction();
        public void Run() => runningAction();
    }
}
