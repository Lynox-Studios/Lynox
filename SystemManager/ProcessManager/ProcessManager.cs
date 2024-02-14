using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.SystemManager.ProcessManager
{
    public static class ProcessManager
    {

        static Dictionary<int,Process> processes = new Dictionary<int,Process>();

        public static void KillProcess(int id)
        {

            processes.Remove(id);

        }
        public static void KillProcess(Process process)
        {

            processes.Remove(GetIDFromProcess(process));

        }
        public static Dictionary<int,Process> GetCurrentProcesses() 
        {

            return processes;

        }
        public static Process GetProcessByID(int id)
        {

            return processes[id];

        }
        public static int GetIDFromProcess(Process process)
        {

            foreach (var item in processes)
            {
                if (item.Value == process)
                {
                    return item.Key;
                }
            }
            return -1;

        }
        public static void StartProcess(Process process,int id = 0)
        {

            processes.Add(CheckProcessID(id), process);

        }

        private static int CheckProcessID(int id) 
        {

            if (!processes.ContainsKey(id))
            {
                return id;
            }
            else
            {
                return CheckProcessID(id+1);
            }

        }

    }
}
