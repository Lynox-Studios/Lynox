using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading;
using Cosmos.System;
using Lynox.LynoxAPI;
using Lynox.SEF.SEFStandardLibs;
using Console = System.Console;

namespace Lynox.SEF
{
    public static class SEF
    {
        public static Dictionary<string, Function> StdLibs = new Dictionary<string, Function>()
        {
            {"printf", new stdio().printFunction},
            {"readf", new stdio().readFunction}
        };
        
        public struct CPU
        {
            public CPU(string ax, string bx, string cx, string dx, bool cpuOn) { this.Ax = ax; this.Bx = bx; this.Cx = cx; this.Dx = dx; _cpuOn = cpuOn; }
            public string Ax { get; set; }
            public string Bx { get; set; }
            public string Cx { get; set; }
            public string Dx { get; set; }
            private bool _cpuOn;
            
            public bool GetCPUState() { return _cpuOn; }
        }
    }

    public struct Function
    {
        public string Name;
        public string Params;
        public List<Event> FunctionEvent;
    }
    
    public struct Event
    {
        public EventType EventType;
        public string ActionValue;
        public Action<int> EventFinishedAction;
    }

    public enum EventType
    {
        EXIT_PROGRAM,
        SHUTDOWN_KERNEL,
        REBOOT_KERNEL,
        FETCH_OS_CONFIG,
        SLEEP_KERNEL,
        EXEC_ANOTHER_PROGRAM,
        TERMINATE_PROGRAM,
        FETCH_STANDARD_INPUT,
        SEND_TO_STANDARD_OUTPUT,
        ACCESS_FUNCTION_FROM_A_PRE_LOADED_STANDARD_LIBRARY,
        SEND_ERROR_VIA_THE_LYNOX_API,
        MODIFY_REGISTER_VAL,
        CLEAR_REGISTER_VAL,
        SYSTEM_CALL_FOR_REGISTER_VALUES,
        CALL_THE_KERNEL = 0x0
    }
    
    public class SEFProgram
    {
        public SEF.CPU CPU;
        public string ProgramName;
        public Action<int> Finished;
        internal List<Event> allEvents;

        public SEFProgram()
        {
            
        }

        public virtual void ProgramRunning() => Finished(0);

        public void BindEvents(List<Event> eventsToAdd)
        {
            allEvents.AddRange(eventsToAdd);
        }
        public void BindEvents(Event eventsToAdd)
        {
            allEvents.Add(eventsToAdd);
        }
    }

    public class SEFExec
    {
        public static SEFProgram ParseFile(string text)
        {
            var Parsed = new SEFProgram();
            
            return Parsed;
        }
        public static void Start(SEFProgram sefProgram)
        {
            int returnCode = 0;
            
            foreach (var Event in sefProgram.allEvents)
            {
                switch (Event.EventType)
                {
                    case EventType.EXIT_PROGRAM:
                        Kernel.lastProcReturnCode = Convert.ToInt32(Event.ActionValue.Split(',')[0]);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[Process exited with return code ");
                        Console.Write(Kernel.lastProcReturnCode);
                        Console.Write("]\n");
                        Console.ResetColor();
                        return;
                    case EventType.SHUTDOWN_KERNEL:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("System shutting down in 3 seconds.");
                        Thread.Sleep(3000);
                        Power.Shutdown();
                        return;
                    case EventType.REBOOT_KERNEL:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("System reboot in 3 seconds.");
                        Thread.Sleep(3000);
                        Power.Reboot();
                        return;
                    case EventType.FETCH_OS_CONFIG:
                        sefProgram.CPU.Dx = OSConfig.FetchOSConfig(Event.ActionValue.Split(',')[0]);
                        break;
                    case EventType.SLEEP_KERNEL:
                        Thread.Sleep(Convert.ToInt32(sefProgram.CPU.Ax));
                        break;
                    case EventType.EXEC_ANOTHER_PROGRAM:
                        SEFExec.Start(ParseFile(File.ReadAllText(Kernel.SystemPath + "\\" + Event.ActionValue.Split(',')[0])));
                        break;
                    case EventType.TERMINATE_PROGRAM:
                        Kernel.lastProcReturnCode = -1;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[Process exited with return code ");
                        Console.Write(Kernel.lastProcReturnCode);
                        Console.Write("]\n");
                        Console.ResetColor();
                        return;
                    case EventType.FETCH_STANDARD_INPUT:
                        sefProgram.CPU.Dx = Console.ReadLine();
                        break;
                    case EventType.SEND_TO_STANDARD_OUTPUT:
                        Console.Write(sefProgram.CPU.Ax);
                        break;
                    case EventType.ACCESS_FUNCTION_FROM_A_PRE_LOADED_STANDARD_LIBRARY:
                        break;
                }
            }
        }
    }
}
