using System.Collections.Generic;

namespace Lynox.SEF.SEFStandardLibs;

// ReSharper disable once InconsistentNaming
public class stdio
{
    // DOCUMENTATION FOR THE PRINT FUNCTION:
    // This is part of the SEF stdio library, it will take only 1 parameter and that will be the text
    // printed on the screen.
    public Function printFunction = new Function()
    {
        Name = "printf", // No, This printf means print function. :)
        Params = param,
        FunctionEvent = new List<Event>()
        {
            new() { EventType = EventType.SEND_TO_STANDARD_OUTPUT, ActionValue = param.Split(',')[0] },
            new() { EventType = EventType.EXIT_PROGRAM, ActionValue = "0" }
        }
    };
    
    // DOCUMENTATION FOR THE PRINT FUNCTION:
    // This is part of the SEF stdio library, it will take only 1 parameter and that will be the register
    // where you want to save your input.
    public Function readFunction = new Function()
    {
        Name = "readf", // Yes, This is also readf meaning read function. :)
        Params = param,
        FunctionEvent = new List<Event>()
        {
            new() { EventType = EventType.FETCH_STANDARD_INPUT, ActionValue = param.Split(',')[0] },
            new() { EventType = EventType.EXIT_PROGRAM, ActionValue = "0" }
        }
    };
    
    public override void ProgramRunning()
    {
        var param = "";
        
        // DOCUMENTATION FOR THE PRINT FUNCTION:
        // This is part of the SEF stdio library, it will take only 1 parameter and that will be the text
        // printed on the screen.
        var printFunction = new Function()
        {
            Name = "printf", // No, This printf means print function. :)
            Params = param,
            FunctionEvent = new List<Event>()
            {
                new() { EventType = EventType.SEND_TO_STANDARD_OUTPUT, ActionValue = param.Split(',')[0] },
                new() { EventType = EventType.EXIT_PROGRAM, ActionValue = "0" }
            }
        };
        
        
    }
}