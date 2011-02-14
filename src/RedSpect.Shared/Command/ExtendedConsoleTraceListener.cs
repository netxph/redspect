using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RedSpect.Shared.Contracts
{
    public class ExtendedConsoleTraceListener : ConsoleTraceListener
    {

        Dictionary<TraceEventType, ConsoleColor> eventColor = new Dictionary<TraceEventType, ConsoleColor>();

        public ExtendedConsoleTraceListener()
        {
            //color configuration
            eventColor.Add(TraceEventType.Verbose, ConsoleColor.DarkGray);
            eventColor.Add(TraceEventType.Information, ConsoleColor.Cyan);
            eventColor.Add(TraceEventType.Warning, ConsoleColor.Yellow);
            eventColor.Add(TraceEventType.Error, ConsoleColor.Red);
            eventColor.Add(TraceEventType.Critical, ConsoleColor.DarkRed);
            eventColor.Add(TraceEventType.Start, ConsoleColor.DarkCyan);
            eventColor.Add(TraceEventType.Stop, ConsoleColor.DarkCyan);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            TraceEvent(eventCache, source, eventType, id, "{0}", message);
        }


        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = getEventColor(eventType, originalColor);
            base.WriteLine(string.Format(format, args));
            Console.ForegroundColor = originalColor;
        }

        private ConsoleColor getEventColor(TraceEventType eventType, ConsoleColor defaultColor)
        {
            if (!eventColor.ContainsKey(eventType))
            {
                return defaultColor;
            }

            return eventColor[eventType];
        }

    }

}

